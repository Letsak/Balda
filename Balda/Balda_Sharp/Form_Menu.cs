using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Balda_Sharp
{
    public partial class Form_Menu : Form
    {
        public Form_Menu()
        {
            InitializeComponent();
            
        }
        static public bool flag = false;
        static public bool music = true;
        static public bool time = true;
        private void Form_Menu_Load(object sender, EventArgs e)
        {

        }

        private void button_new_game_Click(object sender, EventArgs e)
        {
            if (checkBox_music.Checked)
                music = true;
            else music = false;

            if (checkBox_time.Checked)
                time = true;
            else time = false;


            flag = true;
            Form_Game fm = new Form_Game();
            fm.Activate();
            fm.Visible = true;
            //Form_Game.ActiveForm.Activate();
            Form_Menu MyForm2 = new Form_Menu();
            Hide();
        }
        

        private void button_option_Click(object sender, EventArgs e)
        {
            button_exit.Visible = false;
            button_new_game.Visible = false;
            button_option.Visible = false;
            checkBox_time.Visible = true;
            checkBox_music.Visible = true;
            button_back.Visible = true;
            button_help.Visible = false;
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            button_exit.Visible = true;
            button_new_game.Visible = true;
            button_option.Visible = true;
            checkBox_time.Visible = false;
            checkBox_music.Visible = false;
            button_back.Visible = false;
            button_help.Visible = true;
        }

        private void button_help_Click(object sender, EventArgs e)
        {
            Form_Help h = new Form_Help();
            h.ShowDialog();
        }
    }
}
