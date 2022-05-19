namespace chatClient
{
    partial class chatForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(chatForm));
            this.enterChat = new System.Windows.Forms.Button();
            this.userLogin = new System.Windows.Forms.TextBox();
            this.chatBox = new System.Windows.Forms.TextBox();
            this.chat_msg = new System.Windows.Forms.TextBox();
            this.chat_send = new System.Windows.Forms.Button();
            this.gui_chat = new System.Windows.Forms.Label();
            this.userPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.showReg = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gui_userName = new System.Windows.Forms.Label();
            this.logPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.regLogin = new System.Windows.Forms.TextBox();
            this.regPass = new System.Windows.Forms.TextBox();
            this.regButton = new System.Windows.Forms.Button();
            this.regPanel = new System.Windows.Forms.Panel();
            this.chatPanel = new System.Windows.Forms.Panel();
            this.usersBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.logPanel.SuspendLayout();
            this.regPanel.SuspendLayout();
            this.chatPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // enterChat
            // 
            this.enterChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.enterChat.Location = new System.Drawing.Point(624, 9);
            this.enterChat.Name = "enterChat";
            this.enterChat.Size = new System.Drawing.Size(135, 23);
            this.enterChat.TabIndex = 0;
            this.enterChat.Text = "Войти в чат";
            this.enterChat.UseVisualStyleBackColor = false;
            this.enterChat.Click += new System.EventHandler(this.enterChat_Click);
            // 
            // userLogin
            // 
            this.userLogin.Location = new System.Drawing.Point(115, 12);
            this.userLogin.Name = "userLogin";
            this.userLogin.Size = new System.Drawing.Size(170, 20);
            this.userLogin.TabIndex = 2;
            // 
            // chatBox
            // 
            this.chatBox.BackColor = System.Drawing.SystemColors.Control;
            this.chatBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chatBox.Location = new System.Drawing.Point(13, 40);
            this.chatBox.Multiline = true;
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatBox.Size = new System.Drawing.Size(560, 192);
            this.chatBox.TabIndex = 3;
            // 
            // chat_msg
            // 
            this.chat_msg.Location = new System.Drawing.Point(13, 249);
            this.chat_msg.Name = "chat_msg";
            this.chat_msg.Size = new System.Drawing.Size(431, 20);
            this.chat_msg.TabIndex = 4;
            // 
            // chat_send
            // 
            this.chat_send.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chat_send.Location = new System.Drawing.Point(450, 246);
            this.chat_send.Name = "chat_send";
            this.chat_send.Size = new System.Drawing.Size(123, 23);
            this.chat_send.TabIndex = 5;
            this.chat_send.Text = "Отправить";
            this.chat_send.UseVisualStyleBackColor = false;
            this.chat_send.Click += new System.EventHandler(this.chat_send_Click);
            // 
            // gui_chat
            // 
            this.gui_chat.AutoSize = true;
            this.gui_chat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gui_chat.Location = new System.Drawing.Point(10, 14);
            this.gui_chat.Name = "gui_chat";
            this.gui_chat.Size = new System.Drawing.Size(35, 16);
            this.gui_chat.TabIndex = 6;
            this.gui_chat.Text = "Чат:";
            // 
            // userPass
            // 
            this.userPass.Location = new System.Drawing.Point(422, 11);
            this.userPass.Name = "userPass";
            this.userPass.PasswordChar = '*';
            this.userPass.Size = new System.Drawing.Size(170, 20);
            this.userPass.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "У вас нет учётной записи?";
            // 
            // showReg
            // 
            this.showReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.showReg.Location = new System.Drawing.Point(159, 52);
            this.showReg.Name = "showReg";
            this.showReg.Size = new System.Drawing.Size(133, 23);
            this.showReg.TabIndex = 9;
            this.showReg.Text = "Регистрация";
            this.showReg.UseVisualStyleBackColor = false;
            this.showReg.Click += new System.EventHandler(this.showReg_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(308, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Введите пароль: ";
            // 
            // gui_userName
            // 
            this.gui_userName.AutoSize = true;
            this.gui_userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gui_userName.Location = new System.Drawing.Point(10, 14);
            this.gui_userName.Name = "gui_userName";
            this.gui_userName.Size = new System.Drawing.Size(99, 15);
            this.gui_userName.TabIndex = 1;
            this.gui_userName.Text = "Введите логин: ";
            // 
            // logPanel
            // 
            this.logPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.logPanel.Controls.Add(this.label2);
            this.logPanel.Controls.Add(this.userPass);
            this.logPanel.Controls.Add(this.userLogin);
            this.logPanel.Controls.Add(this.gui_userName);
            this.logPanel.Controls.Add(this.enterChat);
            this.logPanel.Location = new System.Drawing.Point(0, 0);
            this.logPanel.Name = "logPanel";
            this.logPanel.Size = new System.Drawing.Size(772, 45);
            this.logPanel.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(18, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Придумайте себе логин: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(18, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Придумайте себе пароль: ";
            // 
            // regLogin
            // 
            this.regLogin.Location = new System.Drawing.Point(184, 11);
            this.regLogin.Name = "regLogin";
            this.regLogin.Size = new System.Drawing.Size(231, 20);
            this.regLogin.TabIndex = 11;
            // 
            // regPass
            // 
            this.regPass.Location = new System.Drawing.Point(184, 38);
            this.regPass.Name = "regPass";
            this.regPass.PasswordChar = '*';
            this.regPass.Size = new System.Drawing.Size(231, 20);
            this.regPass.TabIndex = 13;
            // 
            // regButton
            // 
            this.regButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.regButton.Location = new System.Drawing.Point(450, 12);
            this.regButton.Name = "regButton";
            this.regButton.Size = new System.Drawing.Size(272, 46);
            this.regButton.TabIndex = 14;
            this.regButton.Text = "Зарегистрироваться";
            this.regButton.UseVisualStyleBackColor = false;
            this.regButton.Click += new System.EventHandler(this.regButton_Click);
            // 
            // regPanel
            // 
            this.regPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.regPanel.Controls.Add(this.regButton);
            this.regPanel.Controls.Add(this.regPass);
            this.regPanel.Controls.Add(this.regLogin);
            this.regPanel.Controls.Add(this.label4);
            this.regPanel.Controls.Add(this.label3);
            this.regPanel.Location = new System.Drawing.Point(11, 97);
            this.regPanel.Name = "regPanel";
            this.regPanel.Size = new System.Drawing.Size(748, 74);
            this.regPanel.TabIndex = 15;
            this.regPanel.Visible = false;
            // 
            // chatPanel
            // 
            this.chatPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.chatPanel.Controls.Add(this.usersBox);
            this.chatPanel.Controls.Add(this.label5);
            this.chatPanel.Controls.Add(this.gui_chat);
            this.chatPanel.Controls.Add(this.chat_send);
            this.chatPanel.Controls.Add(this.chat_msg);
            this.chatPanel.Controls.Add(this.chatBox);
            this.chatPanel.Enabled = false;
            this.chatPanel.Location = new System.Drawing.Point(0, 198);
            this.chatPanel.Name = "chatPanel";
            this.chatPanel.Size = new System.Drawing.Size(772, 287);
            this.chatPanel.TabIndex = 16;
            // 
            // usersBox
            // 
            this.usersBox.BackColor = System.Drawing.SystemColors.Control;
            this.usersBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.usersBox.Location = new System.Drawing.Point(597, 40);
            this.usersBox.Multiline = true;
            this.usersBox.Name = "usersBox";
            this.usersBox.ReadOnly = true;
            this.usersBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.usersBox.Size = new System.Drawing.Size(162, 229);
            this.usersBox.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(594, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Сейчас в сети:";
            // 
            // chatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(771, 482);
            this.Controls.Add(this.chatPanel);
            this.Controls.Add(this.regPanel);
            this.Controls.Add(this.logPanel);
            this.Controls.Add(this.showReg);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "chatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OnlineChat";
            this.logPanel.ResumeLayout(false);
            this.logPanel.PerformLayout();
            this.regPanel.ResumeLayout(false);
            this.regPanel.PerformLayout();
            this.chatPanel.ResumeLayout(false);
            this.chatPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enterChat;
        private System.Windows.Forms.TextBox userLogin;
        private System.Windows.Forms.TextBox chatBox;
        private System.Windows.Forms.TextBox chat_msg;
        private System.Windows.Forms.Button chat_send;
        private System.Windows.Forms.Label gui_chat;
        private System.Windows.Forms.TextBox userPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button showReg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label gui_userName;
        private System.Windows.Forms.Panel logPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox regLogin;
        private System.Windows.Forms.TextBox regPass;
        private System.Windows.Forms.Button regButton;
        private System.Windows.Forms.Panel regPanel;
        private System.Windows.Forms.Panel chatPanel;
        private System.Windows.Forms.TextBox usersBox;
        private System.Windows.Forms.Label label5;
    }
}

