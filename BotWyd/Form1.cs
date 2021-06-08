using System;
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
            int segundos = int.Parse(textBox1.Text);
            _hook = new HookKeyboard(segundos);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para gravar as coordenadas de onde você deixar a PL na mochila, aperte HOME.\n" +
                "Para gravar as coordenadas do item que você quer refinar, aperte END\n" +
                "Para rodar o macro, aperte PgUp (primeiro grave as coordenadas)\n" +
                "SAIA DO PROGRAMA APERTANDO PgDn");
        }
    }
}
