using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkillBoxGame
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            //this.ControlBox = false; // отключаем крестик (закрыть окно)
        }

        private void PlayGameButton_Click(object sender, EventArgs e)
        {
            if (NameOne.Text == "")
            {
                this.ControlBox = false;
                error_form2.Visible = true;
                NameOne.BackColor = Color.Red;
            }
            else if (NameTwo.Text == "")
            {
                this.ControlBox = false;
                error_form2.Visible = true;
                NameOne.BackColor = default;
                NameTwo.BackColor = Color.Red;

            }
            else
            {
                Form1.SetPlayersName(NameOne.Text, NameTwo.Text);
                this.Close();
            }
            
        }

        private void KeyPress_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
                
            {
                button1.PerformClick();
            }
        }
    }
}
