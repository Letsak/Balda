using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.DirectX;
using Microsoft.DirectX.AudioVideoPlayback;


namespace Balda_Sharp
{
    public partial class Form_Game : Form
    {
        char[] alphabet = Enumerable.Range(0, 32).Select((x, i) => (char)('А' + i)).ToArray();
        char alphabet_char = '\0';
        int[][] MatrixColor = new int[5][];
        string startSlovo;
        string slovo = "";
        int XGreen = 0, YGreen = 0;
        bool round = false;
        bool timer_flag = Form_Menu.time;
        int timer_interval = 1000;
        int time = 60;
        int pos_time = 60;
        


        public Form_Game()
        {
            InitializeComponent();
            menu = new Form_Menu();

            // Инициальзация таблицы-поля
            dataGridView_Pole.Rows.Clear();
            dataGridView_Pole.ColumnCount = 5;
            dataGridView_Pole.Rows.Add(5 - 1);
            for (int i = 0; i < dataGridView_Pole.ColumnCount; i++)
                dataGridView_Pole.Columns[i].Width = 50;
            dataGridView_Pole.AllowUserToResizeRows = false;
            dataGridView_Pole.AllowUserToResizeColumns = false;

            // Инициализация таблицы-алфавита
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

            InputStart(); // Ввести первое слово
            ClearColor(); // Очистить цвет
            if (timer_flag)
            {
                timer1.Interval = timer_interval;
                timer1.Enabled = true;
                label_timer.Text = time.ToString();
            }
            else label_timer.Visible = false;
            
        }

        Audio audio = new Audio("IND.mp3");
        Form_Menu menu;

        

        
        // Функция сброса стандартного выделения DataGrid
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            ((DataGridView)sender).CurrentCell.Selected = false;
        }

        private void dataGridView_Pole_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Ввод буквы
            if ((slovo == "") && (CheckFourSidesMatrixColor(e.RowIndex, e.ColumnIndex, 1)) && (MatrixColor[e.RowIndex][e.ColumnIndex] != 2) && (alphabet_char == '\0') && (MatrixColor[e.RowIndex][e.ColumnIndex] != 1) && (!CheckSelection()))
            {
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                        if (MatrixColor[i][j] == 2) // Проверка на синий цвет
                        {
                            dataGridView_Pole.Rows[i].Cells[j].Value = null; // Сброс буквы клетки поля
                            MatrixColor[i][j] = 0; // Сброс цвета клетки поля
                        }
                panel_Alphabet.Enabled = true;
                button_Clear.Enabled = true;
                MatrixColor[e.RowIndex][e.ColumnIndex] = 2; // Запись синего цвета в ячейку матрицы цвета
                ClearColor();
            }
            //Выделение слова
            else if (CheckBlueAndValue() && (!CheckSelection() || CheckFourSidesPole(e.RowIndex, e.ColumnIndex)) && (MatrixColor[e.RowIndex][e.ColumnIndex] == 1 || MatrixColor[e.RowIndex][e.ColumnIndex] == 2) && !CheckGreen(e.RowIndex, e.ColumnIndex))
            {
                if(slovo.Length == 0) dataGridView_Pole.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                else dataGridView_Pole.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightGreen;
                panel_Alphabet.Enabled = false;
                XGreen = e.RowIndex;
                YGreen = e.ColumnIndex;
                slovo += dataGridView_Pole.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (CheckGreenInBlue() && CountGreen() >= 2) button_Add.Enabled = true;
            }
        }

        // Функция ввода первого слова
        private void InputStart()
        {
            string[] temp_mas = File.ReadAllLines("slovar.txt", UnicodeEncoding.Default);
            string[] FiveStart = new string[0];
            for (int i = 0, k = 0; i < temp_mas.Length; i++)
            {
                if (temp_mas[i].Length == 5)
                {
                    Array.Resize(ref FiveStart, FiveStart.Length + 1);
                    FiveStart[k] = temp_mas[i].ToUpper();
                    k++;
                }
            }
            Random FiveStartRandom = new Random();
            startSlovo = FiveStart[FiveStartRandom.Next(0, FiveStart.Length - 1)];
            for (int i = 0; i < dataGridView_Pole.ColumnCount; i++)
            {
                MatrixColor[2][i] = 1;
                dataGridView_Pole.Rows[2].Cells[i].Value = startSlovo[i].ToString();
            }
        }

        // Функция очистки цвета по матрице цвета
        private void ClearColor()
        {
            // Проверка на цвета в матрице цветов и присвоение их полю
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    switch (MatrixColor[i][j])
                    {
                        case 0: dataGridView_Pole.Rows[i].Cells[j].Style.BackColor = Color.White; break;
                        case 1: dataGridView_Pole.Rows[i].Cells[j].Style.BackColor = Color.LightSkyBlue; break;
                        case 2: dataGridView_Pole.Rows[i].Cells[j].Style.BackColor = Color.LightBlue; break;
                    }
            // Динамическое выделение редактируемых ячеек
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (MatrixColor[i][j] == 1)
                    {
                        if (((i - 1) >= 0) && (MatrixColor[i - 1][j] == 0)) dataGridView_Pole.Rows[i - 1].Cells[j].Style.BackColor = Color.LightGray;
                        if (((j + 1) < 5) && (MatrixColor[i][j + 1] == 0)) dataGridView_Pole.Rows[i].Cells[j + 1].Style.BackColor = Color.LightGray;
                        if (((i + 1) < 5) && (MatrixColor[i + 1][j] == 0)) dataGridView_Pole.Rows[i + 1].Cells[j].Style.BackColor = Color.LightGray;
                        if (((j - 1) >= 0) && (MatrixColor[i][j - 1] == 0)) dataGridView_Pole.Rows[i].Cells[j - 1].Style.BackColor = Color.LightGray;
                    }
            button_Add.Enabled = false;
        }

        private bool CheckFourSidesPole(int row, int col)
        {
            // color - цвет в матрице цвета
            if ((((row - 1) >= 0) && (((row - 1) == XGreen) && (col == YGreen))) || (((col + 1) < 5) && ((row == XGreen) && ((col + 1) == YGreen))) || (((row + 1) < 5) && (((row + 1) == XGreen) && (col == YGreen))) || (((col - 1) >= 0) && ((row == XGreen) && ((col - 1) == YGreen)))) return true;
            else return false;
        }
        bool CheckFourSidesMatrixColor(int row, int col, int color)
        {
            // color - цвет в матрице цвета
            if ((((row - 1) >= 0) && (MatrixColor[row - 1][col] == color)) || (((col + 1) < 5) && (MatrixColor[row][col + 1] == color)) || (((row + 1) < 5) && (MatrixColor[row + 1][col] == color)) || (((col - 1) >= 0) && (MatrixColor[row][col - 1] == color))) return true;
            else return false;
        }

        // Функция проверки поля на наличие выделения
        private bool CheckSelection()
        {
            bool flag = false;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (dataGridView_Pole.Rows[i].Cells[j].Style.BackColor == Color.LightGreen || dataGridView_Pole.Rows[i].Cells[j].Style.BackColor == Color.Red)
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
        private bool CheckGreen(int row, int col)
        {
            if (dataGridView_Pole.Rows[row].Cells[col].Style.BackColor == Color.LightGreen) return true;
            else return false;
        }

        // Функция подсчета длины выделенного слова
        private int CountGreen()
        {
            int count = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (dataGridView_Pole.Rows[i].Cells[j].Style.BackColor == Color.LightGreen || dataGridView_Pole.Rows[i].Cells[j].Style.BackColor == Color.Red)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        // Функция проверки поля на наличие введенной буквы
        private bool CheckBlue()
        {
            bool flag = false;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (MatrixColor[i][j] == 2)
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

        private bool CheckBlueAndValue()
        {
            bool flag = false;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (MatrixColor[i][j] == 2 && Convert.ToString(dataGridView_Pole.Rows[i].Cells[j].Value) != "")
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

        // Функция проверки выделения на временной букве
        private bool CheckGreenInBlue()
        {
            bool flag = false;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (MatrixColor[i][j] == 2 && (dataGridView_Pole.Rows[i].Cells[j].Style.BackColor == Color.LightGreen || dataGridView_Pole.Rows[i].Cells[j].Style.BackColor == Color.Red))
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

        // Функция проверки на наличие слова в словаре
        private bool FindWord(string str)
        {
            bool flag = false;
            string[] mas = File.ReadAllLines("slovar.txt", UnicodeEncoding.Default);
            for (int i = 0; i < mas.Length; i++)
            {
                if (str.ToLower() == mas[i].ToLower())
                {
                    flag = true;
                    break;
                }
                else flag = false;
            }
            return flag;
        }

        // Функция проверки на наличие слова в уже использованных словах
        private bool FindExistWord(string str)
        {
            bool flag = false;
            if (str == startSlovo) flag = true;
            for (int i = 0; i < listBox_gamer1.Items.Count; i++)
            {
                if (str == listBox_gamer1.Items[i].ToString())
                {
                    flag = true;
                    break;
                }
            }
            for (int i = 0; i < listBox_gamer2.Items.Count; i++)
            {
                if (str == listBox_gamer2.Items[i].ToString())
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        private bool FindWriteSpace(){
            int count = 0;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (MatrixColor[i][j] == 1) count++;
            if (count < 5 * 5) return true;
            else return false;
        }

        // Функция замены временной буквы на постоянную
        private void ReplaceBlue()
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (MatrixColor[i][j] == 2)
                        MatrixColor[i][j] = 1;
        }

        // Функция смены игроков
        private void ChangeRound()
        {
            if (round == false)
            {
                if (slovo != "")
                {
                    listBox_gamer1.Items.Add(slovo);
                    label_gamer1_score.Text = (int.Parse(label_gamer1_score.Text) + slovo.Length).ToString();
                }
                label_gamer1.ForeColor = Color.Black;
                label_gamer2.ForeColor = Color.Yellow;
                this.label_gamer2.Font = new Font(label_gamer2.Font, FontStyle.Underline);
                this.label_gamer1.Font = new Font(label_gamer1.Font, FontStyle.Regular);
                round = true;
            }
            else
            {
                if (slovo != "")
                {
                    listBox_gamer2.Items.Add(slovo);
                    label_gamer2_score.Text = (int.Parse(label_gamer2_score.Text) + slovo.Length).ToString();
                }
                label_gamer2.ForeColor = Color.Black;
                label_gamer1.ForeColor = Color.Yellow;
                this.label_gamer2.Font = new Font(label_gamer2.Font, FontStyle.Regular);
                this.label_gamer1.Font = new Font(label_gamer1.Font, FontStyle.Underline);
                round = false;
            }
            if (int.Parse(label_gamer1_score.Text) > int.Parse(label_gamer2_score.Text))
            {
                label_gamer1_score.ForeColor = Color.Green;
                label_gamer2_score.ForeColor = Color.Red;
            }
            else if (int.Parse(label_gamer1_score.Text) == int.Parse(label_gamer2_score.Text))
            {
                label_gamer1_score.ForeColor = Color.Black;
                label_gamer2_score.ForeColor = Color.Black;
            }
            else
            {
                label_gamer2_score.ForeColor = Color.Green;
                label_gamer1_score.ForeColor = Color.Red;
            }
            slovo = "";

            if (timer_flag)
            {
                timer1.Enabled = false;
                time = pos_time;
                timer1.Enabled = true;
            }
        }

        private void ClearBlue()
        {
            for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 5; j++)
                        if (MatrixColor[i][j] == 2)
                        {
                            MatrixColor[i][j] = 0;
                            dataGridView_Pole.Rows[i].Cells[j].Value = "";
                        }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            if (CheckSelection())
            {
                slovo = "";
                ClearColor(); // Очистить цвета
                panel_Alphabet.Enabled = true;
            }
            else if (CheckBlue())
            {
                slovo = ""; 
                ClearBlue();
                ClearColor(); // Очистить цвета
                slovo = "";
                button_Clear.Enabled = false;
                panel_Alphabet.Enabled = false;
            }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FindExistWord(slovo))
                {
                    if (FindWord(slovo))
                    {
                        ReplaceBlue();
                        ClearColor();
                        if (!FindWriteSpace())
                        {
                            if (int.Parse(label_gamer1_score.Text) > int.Parse(label_gamer2_score.Text))
                                if (MessageBox.Show("Победил игрок1!", "Конец игры!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                                {
                                    if (MessageBox.Show("Вернуться в меню?", "Конец игры!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                                    {
                                        Form_Game fm = new Form_Game();
                                        audio.Stop();
                                        Hide();
                                        menu.Show();
                                    }
                                    else
                                    {
                                        Application.Exit();
                                    }
                                }
                            else if (int.Parse(label_gamer1_score.Text) < int.Parse(label_gamer2_score.Text))
                                    if (MessageBox.Show("Победил игрок2!", "Конец игры!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                                    {
                                        if (MessageBox.Show("Вернуться в меню?", "Конец игры!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                                        {
                                            Form_Game fm = new Form_Game();
                                            audio.Stop();
                                            Hide();
                                            menu.Show();
                                        }
                                        else
                                        {
                                            Application.Exit();
                                        }
                                    }
                            else
                                        if (MessageBox.Show("Ничья!", "Конец игры!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                                        {
                                            if (MessageBox.Show("Вернуться в меню?", "Конец игры!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                                            {
                                                Form_Game fm = new Form_Game();
                                                audio.Stop();
                                                Hide();
                                                menu.Show();
                                            }
                                            else
                                            {
                                                Application.Exit();
                                            }
                                        }
                        }
                        ChangeRound();
                        panel_Alphabet.Enabled = false;
                        button_Clear.Enabled = false;
                    }
                    else
                    {
                        if (MessageBox.Show("Такого слова нет в словаре. Добавить?", "Уведомление", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            StreamWriter s = new StreamWriter("slovar.txt", true);
                            s.WriteLine(slovo.ToLower());
                            s.Close();
                            ReplaceBlue();
                            ClearColor();
                            if (!FindWriteSpace())
                            {
                                if (int.Parse(label_gamer1_score.Text) > int.Parse(label_gamer2_score.Text))
                                    if (MessageBox.Show("Победил игрок1!", "Конец игры!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                                    {
                                        if (MessageBox.Show("Вернуться в меню?", "Конец игры!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                                        {
                                            Form_Game fm = new Form_Game();
                                            audio.Stop();
                                            Hide();
                                            menu.Show();
                                        }
                                        else
                                        {
                                            Application.Exit();
                                        }
                                    }
                                else if (int.Parse(label_gamer1_score.Text) < int.Parse(label_gamer2_score.Text))
                                        if (MessageBox.Show("Победил игрок2!", "Конец игры!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                                        {
                                            if (MessageBox.Show("Вернуться в меню?", "Конец игры!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                                            {
                                                Form_Game fm = new Form_Game();
                                                audio.Stop();
                                                Hide();
                                                menu.Show();
                                            }
                                            else
                                            {
                                                Application.Exit();
                                            }
                                        }
                                else
                                            if (MessageBox.Show("Ничья!", "Конец игры!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                                            {
                                                if (MessageBox.Show("Вернуться в меню?", "Конец игры!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                                                {
                                                    Form_Game fm = new Form_Game();
                                                    audio.Stop();
                                                    Hide();
                                                    menu.Show();
                                                }
                                                else
                                                {
                                                    Application.Exit();
                                                }
                                            }
                            }
                            ChangeRound();
                            button_Clear.Enabled = false;
                        }
                        else
                        {
                            ClearColor();
                            slovo = "";
                            panel_Alphabet.Enabled = true;
                        }
                    }
                }
                else
                {
                    ClearColor();
                    slovo = "";
                    throw new Exception("Такое слово уже есть!");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Балда", MessageBoxButtons.OK);
            }
        }

        private void button_char_Click(object sender, EventArgs e)
        {
            alphabet_char = Convert.ToChar(((Button)sender).Text);
            int x = 0, y = 0;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (MatrixColor[i][j] == 2)
                    {
                        x = i;
                        y = j;
                        dataGridView_Pole.Rows[x].Cells[y].Value = alphabet_char.ToString();
                        break;
                    }
            alphabet_char = '\0';
            button_Clear.Enabled = true;
        }

        public void Form_Game_Load(object sender, EventArgs e)
        {
            bool fl = Form_Menu.flag;
            if (fl == false) Application.Exit();

            string puth = Environment.CurrentDirectory + @"\Music\";
            DirectoryInfo dir = new DirectoryInfo(puth);

            string[] s = new string[0];
            Array.Resize(ref s, 0);
            foreach (FileInfo files in dir.GetFiles())
            {
                Array.Resize(ref s, s.Length + 1);
                s[s.Length - 1] = puth + files.Name;
            }

            Random Random = new Random();
            string startmusic = s[Random.Next(0, s.Length - 1)];

             
            bool music = Form_Menu.music;
            if (music == true) { 
                audio.Play();
                button_music.BackgroundImage = Image.FromFile("off.jpg");
            }
            else {
                button_music.BackgroundImage = Image.FromFile("on.png");
                audio.Stop();
            }
        }

        public void Form_Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }




        public void button_exit_menu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно желаете завершить игру? Результаты не будут сохранены!", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK){
                Form_Game fm = new Form_Game();
                audio.Stop();
                Hide();
                menu.Show();
            }
        }

        private void button_music_Click(object sender, EventArgs e)
        {
            bool music = Form_Menu.music;
            if (music == true)
            {
                button_music.BackgroundImage = Image.FromFile("on.png");
                audio.Pause();
                Form_Menu.music = false;
                
            }
            else {
                button_music.BackgroundImage = Image.FromFile("off.jpg");
                Form_Menu.music = true;
                audio.Play();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_Help h = new Form_Help();
            h.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Enabled = true;
            time--;
            label_timer.Text = time.ToString();
            if (time <= 5)
                label_timer.ForeColor = Color.Red;
            if (time == 0)
            {
                slovo = "";
                time = pos_time + 1;
                label_timer.ForeColor = Color.Black;
                ClearBlue();
                ClearColor();
                ChangeRound();
            }
        }

    }
}