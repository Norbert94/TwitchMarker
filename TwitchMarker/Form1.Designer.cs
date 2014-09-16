namespace TwitchMarker
{
    partial class Form1
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
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_hotkey = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(157, 37);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(230, 20);
            this.txt_Name.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter your twitch username:";
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(157, 63);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(230, 23);
            this.btn.TabIndex = 2;
            this.btn.Text = "Submit";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(17, 63);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(134, 23);
            this.cancel_btn.TabIndex = 3;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hotkey:";
            // 
            // txt_hotkey
            // 
            this.txt_hotkey.Location = new System.Drawing.Point(156, 9);
            this.txt_hotkey.Name = "txt_hotkey";
            this.txt_hotkey.ReadOnly = true;
            this.txt_hotkey.Size = new System.Drawing.Size(51, 20);
            this.txt_hotkey.TabIndex = 5;
            this.txt_hotkey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 95);
            this.Controls.Add(this.txt_hotkey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Name);
            this.Name = "Form1";
            this.Text = "TwitchMarker";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_hotkey;

    }
}

