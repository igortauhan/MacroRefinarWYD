using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BotWyd.Entities
{
    class HookKeyboard
    {
        private static Macro _macro = new Macro();

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        public static int[] CoordenadasItem { get; set; }
        public static int[] CoordenadasSlot{ get; set; }
        public static int Milisegundos { get; set; }

        public HookKeyboard(int milisegundos)
        {
            Milisegundos = milisegundos;
            _hookID = SetHook(_proc);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using Process curProcess = Process.GetCurrentProcess();
            using ProcessModule curModule = curProcess.MainModule;
            return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if (vkCode == 33)
                {
                    try
                    {
                        _macro.Refinar(CoordenadasItem[0], CoordenadasItem[1], CoordenadasSlot[0], CoordenadasSlot[1], Milisegundos);
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine("Ocorreu um erro: " + error.ToString());
                    }
                }

                if (vkCode == 36)
                {
                    CoordenadasItem = _macro.GetCoordenadas();
                }

                if (vkCode == 35)
                {
                    CoordenadasSlot = _macro.GetCoordenadas();
                }

                if (vkCode == 34)
                {
                    UnhookWindowsHookEx(_hookID);
                    Application.Exit();
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
