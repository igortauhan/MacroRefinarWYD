using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace BotWyd.Entities
{
    class Macro
    {
        private InputSimulator _macro = new InputSimulator();

        public int[] GetCoordenadas()
        {
            Point posicaoMouse = new Point();

            int[] coordenadas = new int[2];
            coordenadas[0] = posicaoMouse.X;
            coordenadas[1] = posicaoMouse.Y;

            return coordenadas;
        }

        public void Refinar(int coordenadaX, int coordenadaY, int coordenadaXslot, int coordenadaYslot)
        {
            _macro.Mouse.MoveMouseTo(coordenadaXslot, coordenadaYslot);
            _macro.Mouse.LeftButtonClick();

            _macro.Mouse.MoveMouseTo(coordenadaX, coordenadaY);
            _macro.Mouse.LeftButtonClick();
        }
    }
}
