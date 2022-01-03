using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkillBoxGame
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.ControlBox = false; // отключаем крестик (закрыть окно)
        }

        private void PlayGameButton_Click(object sender, EventArgs e)
        {

            if (NameOne.Text == "")
            {
                error_form2.Visible = true;
                NameOne.BackColor = Color.Red;
            }
            else if (NameTwo.Text == "")
            {
                error_form2.Visible = true;
                NameOne.BackColor = default;
                NameTwo.BackColor = Color.Red;

            }
            else
            {
                error_form2.Visible = false;
                NameOne.BackColor = default;
                Form1.SetPlayersName(NameOne.Text, NameTwo.Text);
                this.Close();
            }
            
        }
        /// <summary>
        /// Метод, который проверяет правильность ввода имени пользователем.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckTextBox(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                DialogResult dia = MessageBox.Show("Ошибка ввода! Вводите только буквы...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (e.KeyChar.ToString() == "\r")
            {
                button1.PerformClick();
            }

        }
    }
}
