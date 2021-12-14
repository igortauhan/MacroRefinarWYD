using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;

namespace BotWyd.Entities
{
    static class Macro
    {
        private static InputSimulator _macro = new InputSimulator();

        public static int[] GetCoordenadas()
        {
            Point posicaoMouse = Cursor.Position;

            int[] coordenadas = new int[2];
            coordenadas[0] = posicaoMouse.X;
            coordenadas[1] = posicaoMouse.Y;

            return coordenadas;
        }

        public static void Refinar(int coordenadaX, int coordenadaY, int coordenadaXslot, int coordenadaYslot, int milisegundos, bool rightClick)
        {
            SetCursorPos(coordenadaX, coordenadaY);
            if (rightClick)
            {
                _macro.Mouse.RightButtonClick();
            }
            else
            {
                _macro.Mouse.LeftButtonClick();
            }
            Thread.Sleep(milisegundos * 1);

            SetCursorPos(coordenadaXslot, coordenadaYslot);
            if (rightClick)
            {
                _macro.Mouse.RightButtonClick();
            }
            else
            {
                _macro.Mouse.LeftButtonClick();
            }
 
            Thread.Sleep(milisegundos * 1);
        }

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int x, int y);
    }
}
