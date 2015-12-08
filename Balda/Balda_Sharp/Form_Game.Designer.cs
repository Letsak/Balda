namespace Balda_Sharp
{
    partial class Form_Game
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView_Pole = new System.Windows.Forms.DataGridView();
            this.button_Clear = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.dataGridView_Alphabet = new System.Windows.Forms.DataGridView();
            this.button_new_game = new System.Windows.Forms.Button();
            this.button_option = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_player_vs_computer = new System.Windows.Forms.Button();
            this.button_player_vs_player = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Pole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Alphabet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_Pole
            // 
            this.dataGridView_Pole.ColumnHeadersHeight = 15;
            this.dataGridView_Pole.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Pole.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Pole.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_Pole.MultiSelect = false;
            this.dataGridView_Pole.Name = "dataGridView_Pole";
            this.dataGridView_Pole.ReadOnly = true;
            this.dataGridView_Pole.RowHeadersVisible = false;
            this.dataGridView_Pole.RowTemplate.Height = 50;
            this.dataGridView_Pole.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView_Pole.Size = new System.Drawing.Size(253, 253);
            this.dataGridView_Pole.TabIndex = 0;
            this.dataGridView_Pole.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Pole_CellMouseClick);
            this.dataGridView_Pole.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionClear);
            // 
            // button_Clear
            // 
            this.button_Clear.Enabled = false;
            this.button_Clear.Location = new System.Drawing.Point(12, 271);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(75, 35);
            this.button_Clear.TabIndex = 1;
            this.button_Clear.Text = "Очистить";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // button_Add
            // 
            this.button_Add.Enabled = false;
            this.button_Add.Location = new System.Drawing.Point(190, 271);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 35);
            this.button_Add.TabIndex = 2;
            this.button_Add.Text = "Ввести слово";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // dataGridView_Alphabet
            // 
            this.dataGridView_Alphabet.ColumnHeadersHeight = 15;
            this.dataGridView_Alphabet.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Alphabet.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Alphabet.Location = new System.Drawing.Point(253, 0);
            this.dataGridView_Alphabet.MultiSelect = false;
            this.dataGridView_Alphabet.Name = "dataGridView_Alphabet";
            this.dataGridView_Alphabet.ReadOnly = true;
            this.dataGridView_Alphabet.RowHeadersVisible = false;
            this.dataGridView_Alphabet.RowTemplate.Height = 31;
            this.dataGridView_Alphabet.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView_Alphabet.Size = new System.Drawing.Size(143, 253);
            this.dataGridView_Alphabet.TabIndex = 0;
            this.dataGridView_Alphabet.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Alphabet_CellMouseClick);
            this.dataGridView_Alphabet.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionClear);
            // 
            // button_new_game
            // 
            this.button_new_game.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_new_game.Location = new System.Drawing.Point(131, 75);
            this.button_new_game.Name = "button_new_game";
            this.button_new_game.Size = new System.Drawing.Size(153, 38);
            this.button_new_game.TabIndex = 0;
            this.button_new_game.Text = "Новая игра";
            this.button_new_game.UseVisualStyleBackColor = true;
            this.button_new_game.Click += new System.EventHandler(this.button_new_game_Click);
            // 
            // button_option
            // 
            this.button_option.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_option.Location = new System.Drawing.Point(131, 135);
            this.button_option.Name = "button_option";
            this.button_option.Size = new System.Drawing.Size(153, 38);
            this.button_option.TabIndex = 1;
            this.button_option.Text = "Опции";
            this.button_option.UseVisualStyleBackColor = true;
            this.button_option.Click += new System.EventHandler(this.button_option_Click_1);
            // 
            // button_exit
            // 
            this.button_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_exit.Location = new System.Drawing.Point(131, 194);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(153, 38);
            this.button_exit.TabIndex = 2;
            this.button_exit.Text = "Выход";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click_1);
            // 
            // button_player_vs_computer
            // 
            this.button_player_vs_computer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_player_vs_computer.Location = new System.Drawing.Point(89, 52);
            this.button_player_vs_computer.Name = "button_player_vs_computer";
            this.button_player_vs_computer.Size = new System.Drawing.Size(236, 44);
            this.button_player_vs_computer.TabIndex = 6;
            this.button_player_vs_computer.Text = "Игрок против компьютера";
            this.button_player_vs_computer.UseVisualStyleBackColor = true;
            this.button_player_vs_computer.Visible = false;
            // 
            // button_player_vs_player
            // 
            this.button_player_vs_player.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_player_vs_player.Location = new System.Drawing.Point(117, 119);
            this.button_player_vs_player.Name = "button_player_vs_player";
            this.button_player_vs_player.Size = new System.Drawing.Size(179, 41);
            this.button_player_vs_player.TabIndex = 7;
            this.button_player_vs_player.Text = "Друг против друга";
            this.button_player_vs_player.UseVisualStyleBackColor = true;
            this.button_player_vs_player.Visible = false;
            this.button_player_vs_player.Click += new System.EventHandler(this.button_player_vs_player_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView_Alphabet);
            this.panel1.Controls.Add(this.button_player_vs_player);
            this.panel1.Controls.Add(this.button_player_vs_computer);
            this.panel1.Controls.Add(this.button_exit);
            this.panel1.Controls.Add(this.button_option);
            this.panel1.Controls.Add(this.button_new_game);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 312);
            this.panel1.TabIndex = 4;
            // 
            // Form_Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 318);
            this.Controls.Add(this.dataGridView_Pole);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_Game";
            this.Text = "Балда";
            this.Load += new System.EventHandler(this.Form_Game_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Pole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Alphabet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Pole;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.DataGridView dataGridView_Alphabet;
        private System.Windows.Forms.Button button_new_game;
        private System.Windows.Forms.Button button_option;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_player_vs_computer;
        private System.Windows.Forms.Button button_player_vs_player;
        private System.Windows.Forms.Panel panel1;
    }
}

