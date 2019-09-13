namespace AAC_FINAL
{
    partial class Main
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fecharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.user_name = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ExpireTime = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.revalid_key = new System.Windows.Forms.Label();
            this.update_servers = new System.Windows.Forms.Label();
            this.sv2_connect = new System.Windows.Forms.Label();
            this.sv2_status = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.sv1_status = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.sv1_connect = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.aac_status = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.l4d2_status = new System.Windows.Forms.Label();
            this.steam_status = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.general_checking = new System.Windows.Forms.Timer(this.components);
            this.validation_timer = new System.Windows.Forms.Timer(this.components);
            this.photo_1 = new System.Windows.Forms.Timer(this.components);
            this.photo_2 = new System.Windows.Forms.Timer(this.components);
            this.photo_3 = new System.Windows.Forms.Timer(this.components);
            this.main_photo_timer = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.fecharToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(110, 48);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(109, 22);
            this.toolStripMenuItem1.Text = "Abrir";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // fecharToolStripMenuItem
            // 
            this.fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            this.fecharToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.fecharToolStripMenuItem.Text = "Fechar";
            this.fecharToolStripMenuItem.Click += new System.EventHandler(this.FecharToolStripMenuItem_Click);
            // 
            // user_name
            // 
            this.user_name.AutoSize = true;
            this.user_name.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_name.Location = new System.Drawing.Point(99, 35);
            this.user_name.Name = "user_name";
            this.user_name.Size = new System.Drawing.Size(11, 15);
            this.user_name.TabIndex = 28;
            this.user_name.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(13, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 15);
            this.label11.TabIndex = 27;
            this.label11.Text = "Jogador:";
            // 
            // ExpireTime
            // 
            this.ExpireTime.AutoSize = true;
            this.ExpireTime.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpireTime.Location = new System.Drawing.Point(99, 71);
            this.ExpireTime.Name = "ExpireTime";
            this.ExpireTime.Size = new System.Drawing.Size(11, 15);
            this.ExpireTime.TabIndex = 26;
            this.ExpireTime.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(13, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 15);
            this.label12.TabIndex = 25;
            this.label12.Text = "Expira em:";
            // 
            // revalid_key
            // 
            this.revalid_key.AutoSize = true;
            this.revalid_key.Cursor = System.Windows.Forms.Cursors.Hand;
            this.revalid_key.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.revalid_key.ForeColor = System.Drawing.Color.Black;
            this.revalid_key.Location = new System.Drawing.Point(158, 52);
            this.revalid_key.Name = "revalid_key";
            this.revalid_key.Size = new System.Drawing.Size(57, 15);
            this.revalid_key.TabIndex = 24;
            this.revalid_key.Text = "Revalidar";
            this.revalid_key.Visible = false;
            // 
            // update_servers
            // 
            this.update_servers.AutoSize = true;
            this.update_servers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.update_servers.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update_servers.ForeColor = System.Drawing.Color.Black;
            this.update_servers.Location = new System.Drawing.Point(131, 136);
            this.update_servers.Name = "update_servers";
            this.update_servers.Size = new System.Drawing.Size(55, 15);
            this.update_servers.TabIndex = 23;
            this.update_servers.Text = "Atualizar";
            this.update_servers.Click += new System.EventHandler(this.Update_servers_Click);
            // 
            // sv2_connect
            // 
            this.sv2_connect.AutoSize = true;
            this.sv2_connect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sv2_connect.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sv2_connect.ForeColor = System.Drawing.Color.Teal;
            this.sv2_connect.Location = new System.Drawing.Point(81, 177);
            this.sv2_connect.Name = "sv2_connect";
            this.sv2_connect.Size = new System.Drawing.Size(72, 15);
            this.sv2_connect.TabIndex = 22;
            this.sv2_connect.Text = "Conectar-se";
            this.sv2_connect.Visible = false;
            this.sv2_connect.Click += new System.EventHandler(this.Sv2_connect_Click);
            // 
            // sv2_status
            // 
            this.sv2_status.AutoSize = true;
            this.sv2_status.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sv2_status.ForeColor = System.Drawing.Color.Green;
            this.sv2_status.Location = new System.Drawing.Point(55, 178);
            this.sv2_status.Name = "sv2_status";
            this.sv2_status.Size = new System.Drawing.Size(25, 15);
            this.sv2_status.TabIndex = 21;
            this.sv2_status.Text = "ON";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(13, 177);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 15);
            this.label15.TabIndex = 20;
            this.label15.Text = "Status:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(13, 161);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(277, 15);
            this.label16.TabIndex = 19;
            this.label16.Text = "[4x4] HARD VERSUS - T1 & PILLS @ T100 @ PX @ GC";
            // 
            // sv1_status
            // 
            this.sv1_status.AutoSize = true;
            this.sv1_status.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sv1_status.ForeColor = System.Drawing.Color.Green;
            this.sv1_status.Location = new System.Drawing.Point(55, 216);
            this.sv1_status.Name = "sv1_status";
            this.sv1_status.Size = new System.Drawing.Size(25, 15);
            this.sv1_status.TabIndex = 17;
            this.sv1_status.Text = "ON";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Status:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(13, 200);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(261, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "[4x4] HARD VERSUS - T1 & PILLS @ T100 @ MYTH";
            // 
            // sv1_connect
            // 
            this.sv1_connect.AutoSize = true;
            this.sv1_connect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sv1_connect.Font = new System.Drawing.Font("Calibri", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sv1_connect.ForeColor = System.Drawing.Color.Teal;
            this.sv1_connect.Location = new System.Drawing.Point(81, 216);
            this.sv1_connect.Name = "sv1_connect";
            this.sv1_connect.Size = new System.Drawing.Size(72, 15);
            this.sv1_connect.TabIndex = 18;
            this.sv1_connect.Text = "Conectar-se";
            this.sv1_connect.Visible = false;
            this.sv1_connect.Click += new System.EventHandler(this.Sv1_connect_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 15);
            this.label10.TabIndex = 14;
            this.label10.Text = "Servidores com AAC";
            // 
            // aac_status
            // 
            this.aac_status.AutoSize = true;
            this.aac_status.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aac_status.Location = new System.Drawing.Point(99, 54);
            this.aac_status.Name = "aac_status";
            this.aac_status.Size = new System.Drawing.Size(11, 15);
            this.aac_status.TabIndex = 13;
            this.aac_status.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(13, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "AAC:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Status";
            // 
            // l4d2_status
            // 
            this.l4d2_status.AutoSize = true;
            this.l4d2_status.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l4d2_status.Location = new System.Drawing.Point(99, 107);
            this.l4d2_status.Name = "l4d2_status";
            this.l4d2_status.Size = new System.Drawing.Size(11, 15);
            this.l4d2_status.TabIndex = 8;
            this.l4d2_status.Text = "-";
            // 
            // steam_status
            // 
            this.steam_status.AutoSize = true;
            this.steam_status.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.steam_status.Location = new System.Drawing.Point(99, 89);
            this.steam_status.Name = "steam_status";
            this.steam_status.Size = new System.Drawing.Size(11, 15);
            this.steam_status.TabIndex = 7;
            this.steam_status.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Steam:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 252);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(296, 49);
            this.button1.TabIndex = 4;
            this.button1.Text = "Minimizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.user_name);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.ExpireTime);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.revalid_key);
            this.panel1.Controls.Add(this.update_servers);
            this.panel1.Controls.Add(this.sv2_connect);
            this.panel1.Controls.Add(this.sv2_status);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.sv1_connect);
            this.panel1.Controls.Add(this.sv1_status);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.aac_status);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.l4d2_status);
            this.panel1.Controls.Add(this.steam_status);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(0, 149);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 314);
            this.panel1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Left 4 dead 2:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AAC_FINAL.Properties.Resources.aac_logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 150);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // general_checking
            // 
            this.general_checking.Interval = 1000;
            this.general_checking.Tick += new System.EventHandler(this.General_checking_Tick);
            // 
            // validation_timer
            // 
            this.validation_timer.Interval = 1000;
            this.validation_timer.Tick += new System.EventHandler(this.Validation_timer_Tick);
            // 
            // photo_1
            // 
            this.photo_1.Interval = 3000;
            this.photo_1.Tick += new System.EventHandler(this.Photo_1_Tick_1);
            // 
            // photo_2
            // 
            this.photo_2.Interval = 3000;
            this.photo_2.Tick += new System.EventHandler(this.Photo_2_Tick_1);
            // 
            // photo_3
            // 
            this.photo_3.Interval = 3000;
            this.photo_3.Tick += new System.EventHandler(this.Photo_3_Tick_1);
            // 
            // main_photo_timer
            // 
            this.main_photo_timer.Interval = 3000;
            this.main_photo_timer.Tick += new System.EventHandler(this.Main_photo_timer_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 463);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[AAC] Validator Client by Px";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_Closing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fecharToolStripMenuItem;
        private System.Windows.Forms.Label user_name;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label ExpireTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label revalid_key;
        private System.Windows.Forms.Label update_servers;
        private System.Windows.Forms.Label sv2_connect;
        private System.Windows.Forms.Label sv2_status;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label sv1_status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label sv1_connect;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label aac_status;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label l4d2_status;
        private System.Windows.Forms.Label steam_status;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer general_checking;
        private System.Windows.Forms.Timer validation_timer;
        private System.Windows.Forms.Timer photo_1;
        private System.Windows.Forms.Timer photo_2;
        private System.Windows.Forms.Timer photo_3;
        private System.Windows.Forms.Timer main_photo_timer;
    }
}

