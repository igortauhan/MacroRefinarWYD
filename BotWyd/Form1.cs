using System;
using System.Windows.Forms;
using BotWyd.Entities;

namespace BotWyd
{
    public partial class Form1 : Form
    {
        private HookKeyboard _hook;
        private bool _rightClick;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _rightClick = false;

            int segundos = int.Parse(textBox1.Text);
            if (checkBox1.Checked)
            {
                _rightClick = true;
            }
            _hook = new HookKeyboard(segundos, _rightClick);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para gravar as coordenadas de onde você deixar a PL na mochila, aperte HOME\n" +
                "Para gravar as coordenadas do item que você quer refinar, aperte END\n" +
                "Para rodar o macro, aperte PgUp (primeiro grave as coordenadas)\n" +
                "Para parar o macro, aperte PgUp tambem\n" +
                "SAIA DO PROGRAMA APERTANDO PgDn\n");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
