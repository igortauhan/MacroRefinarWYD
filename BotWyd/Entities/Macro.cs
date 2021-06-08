using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;

namespace BotWyd.Entities
{
    class Macro
    {
        private InputSimulator _macro = new InputSimulator();

        public int[] GetCoordenadas()
        {
            Point posicaoMouse = Cursor.Position;

            int[] coordenadas = new int[2];
            coordenadas[0] = posicaoMouse.X;
            coordenadas[1] = posicaoMouse.Y;

            return coordenadas;
        }

        public void Refinar(int coordenadaX, int coordenadaY, int coordenadaXslot, int coordenadaYslot, int segundos)
        {
            SetCursorPos(coordenadaX, coordenadaY);
            _macro.Mouse.LeftButtonClick();

            SetCursorPos(coordenadaXslot, coordenadaYslot);
            _macro.Mouse.LeftButtonClick();
            Thread.Sleep(segundos * 1000);
        }

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int x, int y);

    }
}
