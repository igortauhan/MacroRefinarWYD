using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BotWyd.Entities;

namespace BotWyd
{
    public partial class Form1 : Form
    {
        private HookKeyboard _hook;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _hook = new HookKeyboard();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para gravar as coordenadas de onde você deixar a PL na mochila, aperte HOME.\n" +
                "Para gravar as coordenadas do item que você quer refinar, aperte END\n" +
                "Para rodar o macro, aperte PgUp (primeiro grave as coordenadas)\n" +
                "Caso você prefira, poderá fechar o programa apertando PgDn");
        }
    }
}
