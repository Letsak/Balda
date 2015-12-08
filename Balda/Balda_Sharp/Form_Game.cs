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
            else if ((CheckBlue() || CheckGreen()) && (!CheckGreen() || (CheckFourSidesPole(e.RowIndex, e.ColumnIndex))) && ((MatrixColor[e.RowIndex][e.ColumnIndex] == 1) || (MatrixColor[e.RowIndex][e.ColumnIndex] == 2)))
            {
                dataGridView_Pole.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = System.Drawing.Color.LightGreen;
                button_Clear.Enabled = true;
                XGreen = e.RowIndex;
                YGreen = e.ColumnIndex;
                ClearAlphabet();
            }
        }

        // Функция ввода первого слова
        void InputStart()
        {
            string[] FiveStart = new string[5];
            FiveStart[0] = "СТОЛБ";
            FiveStart[1] = "ЛАМПА";
            FiveStart[2] = "ЧАШКА";
            FiveStart[3] = "МАРКА";
            FiveStart[4] = "БАЛДА";
            Random FiveStartRandom = new Random();
            string str = FiveStart[FiveStartRandom.Next(0, 4)];
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
                        if (((i - 1) >= 0) && (MatrixColor[i - 1][j] != 1) && (MatrixColor[i - 1][j] != 2)) dataGridView_Pole.Rows[i - 1].Cells[j].Style.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                        if (((j + 1) < 5) && (MatrixColor[i][j + 1] != 1) && (MatrixColor[i][j + 1] != 2)) dataGridView_Pole.Rows[i].Cells[j + 1].Style.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                        if (((i + 1) < 5) && (MatrixColor[i + 1][j] != 1) && (MatrixColor[i + 1][j] != 2)) dataGridView_Pole.Rows[i + 1].Cells[j].Style.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                        if (((j - 1) >= 0) && (MatrixColor[i][j - 1] != 1) && (MatrixColor[i][j - 1] != 2)) dataGridView_Pole.Rows[i].Cells[j - 1].Style.BackColor = System.Drawing.Color.LightGoldenrodYellow;
                    }
        }

        void ClearAlphabet()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 8; j++)
                    if (dataGridView_Alphabet.CurrentCell.Style.BackColor == System.Drawing.Color.LightGreen) // Проверка на выделение буквы алфавита в таблице
                    {
                        dataGridView_Alphabet.CurrentCell.Style.BackColor = System.Drawing.Color.White; // Сброс выделения
                        alphabet_char = '\0';
                    }
        }

        // Функция проверки налиция цвета в четырех направлениях длинной в одну клетку
        bool CheckFourSidesMatrixColor(int row, int col, int color)
        {
            // color - цвет в матрице цвета
            if ((((row - 1) >= 0) && MatrixColor[row - 1][col] == color) || (((col + 1) < 5) && MatrixColor[row][col + 1] == color) || (((row + 1) < 5) && MatrixColor[row + 1][col] == color) || (((col - 1) >= 0) && MatrixColor[row][col - 1] == color)) return true;
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
            ClearColor(); // Очистить цвета
        }
    }
}