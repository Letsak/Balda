namespace Balda_Sharp
{
    partial class Form_Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Menu));
            this.button_back = new System.Windows.Forms.Button();
            this.checkBox_music = new System.Windows.Forms.CheckBox();
            this.checkBox_time = new System.Windows.Forms.CheckBox();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_option = new System.Windows.Forms.Button();
            this.button_new_game = new System.Windows.Forms.Button();
            this.button_help = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_back
            // 
            this.button_back.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_back.Location = new System.Drawing.Point(56, 214);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(226, 32);
            this.button_back.TabIndex = 11;
            this.button_back.Text = "Вернуться в главное меню";
            this.button_back.UseVisualStyleBackColor = false;
            this.button_back.Visible = false;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // checkBox_music
            // 
            this.checkBox_music.AutoSize = true;
            this.checkBox_music.Location = new System.Drawing.Point(98, 164);
            this.checkBox_music.Name = "checkBox_music";
            this.checkBox_music.Size = new System.Drawing.Size(119, 17);
            this.checkBox_music.TabIndex = 10;
            this.checkBox_music.Text = "Играть с музыкой";
            this.checkBox_music.UseVisualStyleBackColor = true;
            this.checkBox_music.Visible = false;
            // 
            // checkBox_time
            // 
            this.checkBox_time.AutoSize = true;
            this.checkBox_time.Checked = true;
            this.checkBox_time.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_time.Location = new System.Drawing.Point(98, 107);
            this.checkBox_time.Name = "checkBox_time";
            this.checkBox_time.Size = new System.Drawing.Size(126, 17);
            this.checkBox_time.TabIndex = 9;
            this.checkBox_time.Text = "Играть с временем";
            this.checkBox_time.UseVisualStyleBackColor = true;
            this.checkBox_time.Visible = false;
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_exit.Location = new System.Drawing.Point(86, 273);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(153, 38);
            this.button_exit.TabIndex = 8;
            this.button_exit.Text = "Выход";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // button_option
            // 
            this.button_option.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_option.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_option.Location = new System.Drawing.Point(86, 151);
            this.button_option.Name = "button_option";
            this.button_option.Size = new System.Drawing.Size(153, 38);
            this.button_option.TabIndex = 7;
            this.button_option.Text = "Опции";
            this.button_option.UseVisualStyleBackColor = false;
            this.button_option.Click += new System.EventHandler(this.button_option_Click);
            // 
            // button_new_game
            // 
            this.button_new_game.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_new_game.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_new_game.Location = new System.Drawing.Point(86, 94);
            this.button_new_game.Name = "button_new_game";
            this.button_new_game.Size = new System.Drawing.Size(153, 38);
            this.button_new_game.TabIndex = 6;
            this.button_new_game.Text = "Новая игра";
            this.button_new_game.UseVisualStyleBackColor = false;
            this.button_new_game.Click += new System.EventHandler(this.button_new_game_Click);
            // 
            // button_help
            // 
            this.button_help.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_help.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_help.Location = new System.Drawing.Point(86, 211);
            this.button_help.Name = "button_help";
            this.button_help.Size = new System.Drawing.Size(153, 38);
            this.button_help.TabIndex = 12;
            this.button_help.Text = "Справка";
            this.button_help.UseVisualStyleBackColor = false;
            this.button_help.Click += new System.EventHandler(this.button_help_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(338, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // Form_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(340, 341);
            this.ControlBox = false;
            this.Controls.Add(this.button_help);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_option);
            this.Controls.Add(this.button_new_game);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.checkBox_music);
            this.Controls.Add(this.checkBox_time);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form_Menu";
            this.Text = "Балда";
            this.Load += new System.EventHandler(this.Form_Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.CheckBox checkBox_music;
        private System.Windows.Forms.CheckBox checkBox_time;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_option;
        private System.Windows.Forms.Button button_new_game;
        private System.Windows.Forms.Button button_help;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}