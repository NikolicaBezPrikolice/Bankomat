
namespace Bankomat
{
    partial class Home
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.AccNumlbl = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 83);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poor Richard", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(765, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 36);
            this.label2.TabIndex = 3;
            this.label2.Text = "X";
            this.label2.Click += new System.EventHandler(this.ExitApp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poor Richard", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(268, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Izaberite transakciju";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Font = new System.Drawing.Font("Poor Richard", 15.75F);
            this.button1.Location = new System.Drawing.Point(57, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 36);
            this.button1.TabIndex = 8;
            this.button1.Text = "Uplata";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Deposit_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button2.Font = new System.Drawing.Font("Poor Richard", 15.75F);
            this.button2.Location = new System.Drawing.Point(530, 144);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(176, 36);
            this.button2.TabIndex = 9;
            this.button2.Text = "Isplata";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Withdraw_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button4.Font = new System.Drawing.Font("Poor Richard", 15.75F);
            this.button4.Location = new System.Drawing.Point(530, 230);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(176, 36);
            this.button4.TabIndex = 11;
            this.button4.Text = "Transakcije";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.MiniStatement_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button5.Font = new System.Drawing.Font("Poor Richard", 15.75F);
            this.button5.Location = new System.Drawing.Point(57, 312);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(176, 36);
            this.button5.TabIndex = 12;
            this.button5.Text = "Promeni PIN";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.ChangePin_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button6.Font = new System.Drawing.Font("Poor Richard", 15.75F);
            this.button6.Location = new System.Drawing.Point(530, 312);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(176, 36);
            this.button6.TabIndex = 13;
            this.button6.Text = "Stanje";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.Balance_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 422);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 28);
            this.panel2.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poor Richard", 15.75F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(348, 395);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 24);
            this.label5.TabIndex = 15;
            this.label5.Text = "Izloguj se";
            this.label5.Click += new System.EventHandler(this.Logout_Click);
            // 
            // AccNumlbl
            // 
            this.AccNumlbl.AutoSize = true;
            this.AccNumlbl.Font = new System.Drawing.Font("Poor Richard", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccNumlbl.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.AccNumlbl.Location = new System.Drawing.Point(281, 86);
            this.AccNumlbl.Name = "AccNumlbl";
            this.AccNumlbl.Size = new System.Drawing.Size(163, 36);
            this.AccNumlbl.TabIndex = 16;
            this.AccNumlbl.Text = "Broj Racuna";
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button7.Font = new System.Drawing.Font("Poor Richard", 15.75F);
            this.button7.Location = new System.Drawing.Point(57, 230);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(176, 36);
            this.button7.TabIndex = 17;
            this.button7.Text = "Transfer";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.Transfer_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.AccNumlbl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label AccNumlbl;
        private System.Windows.Forms.Button button7;
    }
}