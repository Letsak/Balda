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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView_Pole = new System.Windows.Forms.DataGridView();
            this.dataGridView_Alphabet = new System.Windows.Forms.DataGridView();
            this.button_Clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Pole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Alphabet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Pole
            // 
            this.dataGridView_Pole.ColumnHeadersHeight = 15;
            this.dataGridView_Pole.ColumnHeadersVisible = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Pole.DefaultCellStyle = dataGridViewCellStyle7;
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
            // dataGridView_Alphabet
            // 
            this.dataGridView_Alphabet.ColumnHeadersHeight = 15;
            this.dataGridView_Alphabet.ColumnHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Alphabet.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView_Alphabet.Location = new System.Drawing.Point(271, 12);
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
            // Form_Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 315);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.dataGridView_Alphabet);
            this.Controls.Add(this.dataGridView_Pole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form_Game";
            this.Text = "Балда";
            this.Load += new System.EventHandler(this.Form_Game_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Pole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Alphabet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Pole;
        private System.Windows.Forms.DataGridView dataGridView_Alphabet;
        private System.Windows.Forms.Button button_Clear;
    }
}

