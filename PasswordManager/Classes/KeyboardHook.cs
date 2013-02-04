using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PasswordManager.Classes
{
    internal sealed class KeyboardHook : IDisposable
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private sealed class Window : NativeWindow, IDisposable
        {
            private const int WmHotkey = 0x0312;

            public Window()
            {
                CreateHandle(new CreateParams());
            }

            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);

                if (m.Msg != WmHotkey)
                    return;
                
                var key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                var modifier = (ModifierKeys)((int)m.LParam & 0xFFFF);

                if (KeyPressed != null)
                    KeyPressed(this, new KeyPressedEventArgs(modifier, key));
            }

            public event EventHandler<KeyPressedEventArgs> KeyPressed;

            #region IDisposable Members

            public void Dispose()
            {
                DestroyHandle();
            }

            #endregion
        }

        private class Hook
        {
            public Hook(int id, uint modifier, uint key)
            {
                ID = id;
                Modifier = modifier;
                Key = key;
            }

            public int ID
            {
                get;
                private set;
            }

            public uint Modifier
            {
                get;
                private set;
            }

            public uint Key
            {
                get;
                private set;
            }
        }

        private readonly Window _window;
        private readonly List<Hook> _hooks;

        private void WindowKeyPressed(object sender, KeyPressedEventArgs args)
        {
            if (KeyPressed != null)
                KeyPressed(this, args);
        }

        public KeyboardHook()
        {
            _window = new Window();
            _window.KeyPressed += WindowKeyPressed;
            _hooks = new List<Hook>();
        }

        public bool RegisterHotKey(ModifierKeys modifier, Keys key)
        {
            var id = (_hooks.Count > 0  ? _hooks.Max(x => x.ID) : 0) + 1;
            var hook = new Hook(id, (uint)modifier, (uint)key);

            if (!RegisterHotKey(_window.Handle, id, hook.Modifier, hook.Key))
                return false;
            
            _hooks.Add(hook);
            return true;
        }

        public bool UnregisterHotKey(ModifierKeys modifier, Keys key)
        {
            var m = (uint)modifier;
            var k = (uint)key;
            
            var hook = _hooks.FirstOrDefault(x => x.Modifier == m && x.Key == k);
            if (hook == null)
                return false;

            UnregisterHotKey(_window.Handle, hook.ID);
            _hooks.Remove(hook);
            
            return true;
        }

        public event EventHandler<KeyPressedEventArgs> KeyPressed;

        #region IDisposable Members

        public void Dispose()
        {
            foreach (var hook in _hooks)
                UnregisterHotKey(_window.Handle, hook.ID);

            _hooks.Clear();
            _window.Dispose();
        }

        #endregion
    }

    internal class KeyPressedEventArgs : EventArgs
    {
        public KeyPressedEventArgs(ModifierKeys modifier, Keys key)
        {
            Modifier = modifier;
            Key = key;
        }

        public ModifierKeys Modifier
        {
            get;
            private set;
        }

        public Keys Key
        {
            get;
            private set;
        }
    }

    [Flags]
    internal enum ModifierKeys : uint
    {
        Alt = 1,
        Control = 2,
        Shift = 4,
        Win = 8
    }
}