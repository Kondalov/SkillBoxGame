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
    public partial class Form1 : Form
    {
        bool turn = true;

        int turn_count = 0;

        static String player1, player2;

        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Выход из игры. Кнопка "Exit"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Метод, который отвечает за имена вводимые пользователем в Forms2
        /// </summary>
        /// <param name="n1">playeer 1</param>
        /// <param name="n2">playeer 2</param>
        public static void SetPlayersName(String n1, String n2)
        {
            player1 = n1;
            player2 = n2;
        }

        /// <summary>
        /// Информация об авторе. Кнопка "Help". Да, кнопка help - автор так решил!!!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutMe(object sender, EventArgs e)
        {
            MessageBox.Show("Игра создана исключетельно в учебных целях!\n Разработчик: Кондалов Николай Николаевич", "Справка");
        }

        /// <summary>
        /// Метод, который отвечает за новую игру. Кнопка "New Game"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewGame(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }

            }
        }
        /// <summary>
        /// Метод, который делает проверку игроков
        /// </summary>
        private void CheckForWinner()
        {
            bool three_is_a_winner = false;

            //горизонтальные проверки
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
            {
                three_is_a_winner = true;
            }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            {
                three_is_a_winner = true;
            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            {
                three_is_a_winner = true;
            }

            //вертикальные проверки
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            {
                three_is_a_winner = true;
            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            {
                three_is_a_winner = true;
            }
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            {
                three_is_a_winner = true;
            }

            //диоганаль справа
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            {
                three_is_a_winner = true;
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
            {
                three_is_a_winner = true;
            }

            if (three_is_a_winner)
            {
                DisabledButton();

                string winner;
                if (turn)
                {
                    //winner = "O";
                    winner = player2;
                    o_win_count.Text = (Int32.Parse(o_win_count.Text) + 1).ToString();
                }

                else
                {
                    //winner = "X";
                    winner = player1;
                    x_win_count.Text = (Int32.Parse(x_win_count.Text) + 1).ToString();
                }

                MessageBox.Show(winner + " - You Win!!!", "Winner Panel");
            }

            else
            {
                DisabledButton();
                if (turn_count == 9)
                {
                    draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
                    MessageBox.Show("Ничья", "Winner Panel");
                }
            }
        }
        /// <summary>
        /// Метод, который отключает кнопки если игрок выйграл или была ничья
        /// </summary>
        private void DisabledButton()
        {
            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                    b.Text = "('..')";
                }
                catch { }

            }
        }

        /// <summary>
        /// Метод, который подсказывает ход(имя) игрока
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)

                    //b.Text = "X";
                    b.Text = "ход\n" + player1;
                else
                    //b.Text = "O";
                    b.Text = "ход\n" + player2;
            }
        }
        /// <summary>
        /// Метод, который очищает поле если курсор мышки находится за пределами кнопок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = ""; // Если мышка за пределами кнопки, то поле будет снова пустым
            }
        }
        /// <summary>
        /// Сброс очков
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetCount(object sender, EventArgs e)
        {
            o_win_count.Text = "0";
            x_win_count.Text = "0";
            draw_count.Text = "0";
        }

        private void LoadForms(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog(); // загрузить Form2 первым
            NameOne.Text = player1;
            NameTwo.Text = player2;
        }

        /// <summary>
        /// Метод, который назначает кнопки согласно ходу игрока
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn;

            b.Enabled = false;

            turn_count++;

            CheckForWinner();
        }

        
    }
}
