using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.DirectX;
using Microsoft.DirectX.AudioVideoPlayback;

namespace Balda_Sharp
{
    public partial class Form_Game : Form
    {
        char alphabet_char;
        int[][] MatrixColor = new int[5][];
        string slovo = "";
        int XGreen = 0;
        int YGreen = 0;
        
        public Form_Game()
        {
            InitializeComponent();
        }

        

        private void Form_Game_Load(object sender, EventArgs e)
        {
            
            // Инициальзация таблицы-поля
            dataGridView_Pole.Rows.Clear();
            dataGridView_Pole.ColumnCount = 5;
            dataGridView_Pole.Rows.Add(4);
            for (int i = 0; i < dataGridView_Pole.ColumnCount; i++)
                dataGridView_Pole.Columns[i].Width = 50;
            dataGridView_Pole.AllowUserToResizeRows = false;
            dataGridView_Pole.AllowUserToResizeColumns = false;

            // Инициализация таблицы-алфавита
            char[] alphabet = Enumerable.Range(0, 32).Select((x, i) => (char)('А' + i)).ToArray();
            dataGridView_Alphabet.Rows.Clear();
            dataGridView_Alphabet.ColumnCount = 4;
            dataGridView_Alphabet.Rows.Add(7);
            for (int i = 0; i < dataGridView_Alphabet.ColumnCount; i++)
                dataGridView_Alphabet.Columns[i].Width = 35;
            dataGridView_Alphabet.AllowUserToResizeRows = false;
            dataGridView_Alphabet.AllowUserToResizeColumns = false;
            for (int i = 0, j = 0, k = 0; k < 32; k++)
            {
                dataGridView_Alphabet.Rows[i].Cells[j].Value = alphabet[k].ToString();
                if (j == 3)
                {
                    i++;
                    j = 0;
                }
                else j++;
            }
            for (int i = 0; i < 5; i++)
            {
                MatrixColor[i] = new int[5];
                for (int j = 0; j < 5; j++)
                    MatrixColor[i][j] = 0;
            }
            ClearColor(); // Очистить цвет
            InputStart(); // Ввести первое слово
        }

        private void dataGridView_SelectionClear(object sender, EventArgs e)
        {
            ((DataGridView)sender).CurrentCell.Selected = false; // Сброс стандартного выделения DataGrid
        }

        private void dataGridView_Pole_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Ввод буквы
            if ((slovo == "") && (alphabet_char != '\0') && (MatrixColor[e.RowIndex][e.ColumnIndex] != 1) && (!CheckGreen()) && (Convert.ToChar(dataGridView_Pole.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) != alphabet_char))
            {
                if (CheckFourSidesMatrixColor(e.RowIndex, e.ColumnIndex, 1))
                {
                    for (int i = 0; i < 5; i++)
                        for (int j = 0; j < 5; j++)
                            if (MatrixColor[i][j] == 2) // Проверка на синий цвет
                            {
                                dataGridView_Pole.Rows[i].Cells[j].Value = null; // Сброс буквы клетки поля
                                MatrixColor[i][j] = 0; // Сброс цвета клетки поля
                            }
                    MatrixColor[e.RowIndex][e.ColumnIndex] = 2; // Запись синего цвета в ячейку матрицы цвета
                    dataGridView_Pole.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = alphabet_char.ToString();
                    ClearAlphabet();
                }
                ClearColor();
            }
            //Выделение слова
            else if ((CheckBlue() || CheckGreen()) && (!CheckGreen() || (CheckFourSidesPole(e.RowIndex, e.ColumnIndex))) && ((MatrixColor[e.RowIndex][e.ColumnIndex] == 1) || (MatrixColor[e.RowIndex][e.ColumnIndex] == 2)) && !CheckGreen(e.RowIndex, e.ColumnIndex))
            {
                dataGridView_Pole.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = System.Drawing.Color.LightGreen;
                button_Clear.Enabled = true;
                XGreen = e.RowIndex;
                YGreen = e.ColumnIndex;
                slovo += dataGridView_Pole.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                button_Add.Enabled = true;
                ClearAlphabet();
            }
        }

        // Функция ввода первого слова
        void InputStart()
        {
            string[] temp_mas = File.ReadAllLines("slovar.txt", UnicodeEncoding.Default);
            string[] FiveStart = new string[0];
            int k = 0;
            for (int i = 0; i < temp_mas.Length; i++)
            {
                if (temp_mas[i].Length == 5)
                {
                    Array.Resize(ref FiveStart, FiveStart.Length + 1);
                    FiveStart[k] = temp_mas[i].ToUpper();
                    k++;
                }

            }
            Random FiveStartRandom = new Random();
            string str = FiveStart[FiveStartRandom.Next(0, FiveStart.Length - 1)];
            for (int i = 0; i < dataGridView_Pole.ColumnCount; i++)
            {
                MatrixColor[2][i] = 1;
                dataGridView_Pole.Rows[2].Cells[i].Value = str[i].ToString();
            }
            ClearColor();
        }

        private void dataGridView_Alphabet_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Выбор буквы из алфавита
            if (!CheckGreen())
            {
                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 4; j++)
                        dataGridView_Alphabet.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.White;
                dataGridView_Alphabet.CurrentCell.Style.BackColor = System.Drawing.Color.LightGreen;
                alphabet_char = char.Parse(dataGridView_Alphabet.CurrentCell.Value.ToString());
            }
        }

        // Функция очистки цвета по матрице цвета
        void ClearColor()
        {
            button_Add.Enabled = false;
            // Проверка на цвета в матрице цветов и присвоение их полю
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    switch (MatrixColor[i][j])
                    {
                        case 0: dataGridView_Pole.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.White; if (!CheckGreen()) button_Clear.Enabled = false; break;
                        case 1: dataGridView_Pole.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.LightSkyBlue; if (!CheckGreen()) button_Clear.Enabled = false; break;
                        case 2: dataGridView_Pole.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.LightBlue; if (!CheckGreen()) button_Clear.Enabled = false; break;
                   }
            // Динамическое выделение редактируемых ячеек
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (MatrixColor[i][j] == 1)
                    {
                        if (((i - 1) >= 0) && (MatrixColor[i - 1][j] == 0)) dataGridView_Pole.Rows[i - 1].Cells[j].Style.BackColor = System.Drawing.Color.LightGray;
                        if (((j + 1) < 5) && (MatrixColor[i][j + 1] == 0)) dataGridView_Pole.Rows[i].Cells[j + 1].Style.BackColor = System.Drawing.Color.LightGray;
                        if (((i + 1) < 5) && (MatrixColor[i + 1][j] == 0)) dataGridView_Pole.Rows[i + 1].Cells[j].Style.BackColor = System.Drawing.Color.LightGray;
                        if (((j - 1) >= 0) && (MatrixColor[i][j - 1] == 0)) dataGridView_Pole.Rows[i].Cells[j - 1].Style.BackColor = System.Drawing.Color.LightGray;
                    }
        }

        void ClearAlphabet()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 8; j++)
                    if (dataGridView_Alphabet.CurrentCell.Style.BackColor == System.Drawing.Color.LightGreen) // Проверка на выделение буквы алфавита в таблице
                    {
                        dataGridView_Alphabet.CurrentCell.Style.BackColor = System.Drawing.Color.White; // Сброс выделения
                    }
            alphabet_char = '\0';
        }

        // Функция проверки налиция цвета в четырех направлениях длинной в одну клетку
        bool CheckFourSidesMatrixColor(int row, int col, int color)
        {
            // color - цвет в матрице цвета
            if ((((row - 1) >= 0) && (MatrixColor[row - 1][col] == color)) || (((col + 1) < 5) && (MatrixColor[row][col + 1] == color)) || (((row + 1) < 5) && (MatrixColor[row + 1][col] == color)) || (((col - 1) >= 0) && (MatrixColor[row][col - 1] == color))) return true;
            else return false;
        }

        bool CheckFourSidesPole(int row, int col)
        {
            // color - цвет в матрице цвета
            if ((((row - 1) >= 0) && (((row - 1) == XGreen) && (col == YGreen))) || (((col + 1) < 5) && ((row == XGreen) && ((col + 1) == YGreen))) || (((row + 1) < 5) && (((row + 1) == XGreen) && (col == YGreen))) || (((col - 1) >= 0) && ((row == XGreen) && ((col - 1) == YGreen)))) return true;
            else return false;
        }

        // Функция проверки поля на наличие выделения
        bool CheckGreen()
        {
           bool flag = false;
           for (int i = 0; i < 5; i++)
           {
               for (int j = 0; j < 5; j++)
               {
                   if (dataGridView_Pole.Rows[i].Cells[j].Style.BackColor == System.Drawing.Color.LightGreen)
                   {
                       flag = true;
                       break;
                   }
               }
               if (flag) break;
           }
           if (flag) return true;
           else return false;
        }

        // Функция проверки поля на наличие выделения
        bool CheckGreen(int row, int col)
        {
            if (dataGridView_Pole.Rows[row].Cells[col].Style.BackColor == System.Drawing.Color.LightGreen) return true;
            else return false;
        }

        // Функция проверки поля на наличие введенной буквы
        bool CheckBlue()
        {
            bool flag = false;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (dataGridView_Pole.Rows[i].Cells[j].Style.BackColor == System.Drawing.Color.LightBlue)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag) break;
            }
            if (flag) return true;
            else return false;
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            slovo = "";
            ClearColor(); // Очистить цвета
        }



        bool slovo_str()
        {
            bool flag = false;
            string[] mas = File.ReadAllLines("slovar.txt", UnicodeEncoding.Default);
            for (int i = 0; i < mas.Length; i++)
            {
                if (slovo.ToLower() == mas[i])
                {
                    flag = true;
                    break;
                }
                else
                {
                    flag = false;
                }
            }
            return flag;
        }


        void ZamenaBlue()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (MatrixColor[i][j] == 2)
                    {
                        MatrixColor[i][j] = 1;
                    }
                }
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if (slovo_str() == true)
            {
                ZamenaBlue();
                ClearColor();
                slovo = "";
            }
            else
            {
                if (MessageBox.Show("Такого слова нет в словаре. Добавить?", "Уведомление", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    StreamWriter s = new StreamWriter("slovar.txt", true);
                    s.WriteLine(slovo);
                    s.Close();
                    ZamenaBlue();
                    ClearColor();
                    slovo = "";
                }
                else
                {
                    ClearColor();
                    slovo = "";
                }


            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_option_Click(object sender, EventArgs e)
        {

        }

        private void button_player_vs_player_Click(object sender, EventArgs e)
        {
            
        }

        private void button_new_game_Click(object sender, EventArgs e)
        {
            button_exit.Visible = false;
            button_new_game.Visible = false;
            button_option.Visible = false;
            button_player_vs_computer.Visible = true;
            button_player_vs_player.Visible = true;
        }

        private void button_player_vs_player_Click_1(object sender, EventArgs e)
        {
            audio.Play();
            panel1.Visible = false;
                //Microsoft.DirectX.AudioVideoPlayback.Audio audio =
                //    new Microsoft.DirectX.AudioVideoPlayback.Audio(@"C:\kuni.mp3");


                //System.Media.SoundPlayer sp = new System.Media.SoundPlayer(@"C:\kuni.mp3");
                //sp.Play();
           
        }

        private void button_exit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_option_Click_1(object sender, EventArgs e)
        {
            button_exit.Visible = false;
            button_new_game.Visible = false;
            button_option.Visible = false;
            button_player_vs_computer.Visible = false;
            button_player_vs_player.Visible = false;
        }
    }
}