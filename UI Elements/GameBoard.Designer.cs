namespace President.UI_Elements
{
    partial class GameBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameBoard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPlayerDone = new System.Windows.Forms.Button();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblPlayerNameLabel = new System.Windows.Forms.Label();
            this.btnShowHide = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.kupaUI = new President.KupaUI();
            this.rightComputerHand = new President.ComputerHand();
            this.leftComputerHand = new President.ComputerHand();
            this.playerHand = new President.PlayerHand();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnShowHide);
            this.panel1.Controls.Add(this.btnMainMenu);
            this.panel1.Controls.Add(this.btnPlayerDone);
            this.panel1.Controls.Add(this.txtMessages);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 461);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 61);
            this.panel1.TabIndex = 3;
            // 
            // btnPlayerDone
            // 
            this.btnPlayerDone.Enabled = false;
            this.btnPlayerDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnPlayerDone.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnPlayerDone.Location = new System.Drawing.Point(379, 6);
            this.btnPlayerDone.Name = "btnPlayerDone";
            this.btnPlayerDone.Size = new System.Drawing.Size(85, 49);
            this.btnPlayerDone.TabIndex = 2;
            this.btnPlayerDone.Text = "Player Done";
            this.btnPlayerDone.UseVisualStyleBackColor = true;
            // 
            // txtMessages
            // 
            this.txtMessages.Enabled = false;
            this.txtMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtMessages.Location = new System.Drawing.Point(118, 16);
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ReadOnly = true;
            this.txtMessages.Size = new System.Drawing.Size(239, 26);
            this.txtMessages.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnStart.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnStart.Location = new System.Drawing.Point(12, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(85, 50);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start Round";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // lblPlayerNameLabel
            // 
            this.lblPlayerNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlayerNameLabel.BackColor = System.Drawing.Color.Green;
            this.lblPlayerNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblPlayerNameLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPlayerNameLabel.Location = new System.Drawing.Point(235, 25);
            this.lblPlayerNameLabel.Name = "lblPlayerNameLabel";
            this.lblPlayerNameLabel.Size = new System.Drawing.Size(292, 63);
            this.lblPlayerNameLabel.TabIndex = 7;
            // 
            // btnShowHide
            // 
            this.btnShowHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowHide.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowHide.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnShowHide.Location = new System.Drawing.Point(575, 6);
            this.btnShowHide.Name = "btnShowHide";
            this.btnShowHide.Size = new System.Drawing.Size(85, 49);
            this.btnShowHide.TabIndex = 3;
            this.btnShowHide.Text = "Show\\Hide";
            this.btnShowHide.UseVisualStyleBackColor = true;
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnMainMenu.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnMainMenu.Location = new System.Drawing.Point(666, 6);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(85, 49);
            this.btnMainMenu.TabIndex = 2;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            // 
            // kupaUI
            // 
            this.kupaUI.BackColor = System.Drawing.Color.Gold;
            this.kupaUI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.kupaUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kupaUI.Location = new System.Drawing.Point(210, 0);
            this.kupaUI.Name = "kupaUI";
            this.kupaUI.Size = new System.Drawing.Size(343, 311);
            this.kupaUI.TabIndex = 6;
            // 
            // rightComputerHand
            // 
            this.rightComputerHand.BackColor = System.Drawing.Color.Gold;
            this.rightComputerHand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rightComputerHand.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightComputerHand.Location = new System.Drawing.Point(553, 0);
            this.rightComputerHand.Name = "rightComputerHand";
            this.rightComputerHand.Size = new System.Drawing.Size(210, 311);
            this.rightComputerHand.TabIndex = 5;
            // 
            // leftComputerHand
            // 
            this.leftComputerHand.BackColor = System.Drawing.Color.Gold;
            this.leftComputerHand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leftComputerHand.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftComputerHand.Location = new System.Drawing.Point(0, 0);
            this.leftComputerHand.Name = "leftComputerHand";
            this.leftComputerHand.Size = new System.Drawing.Size(210, 311);
            this.leftComputerHand.TabIndex = 5;
            // 
            // playerHand
            // 
            this.playerHand.BackColor = System.Drawing.Color.Gold;
            this.playerHand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playerHand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.playerHand.Location = new System.Drawing.Point(0, 311);
            this.playerHand.Name = "playerHand";
            this.playerHand.Size = new System.Drawing.Size(763, 150);
            this.playerHand.TabIndex = 4;
            // 
            // GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 522);
            this.Controls.Add(this.lblPlayerNameLabel);
            this.Controls.Add(this.kupaUI);
            this.Controls.Add(this.rightComputerHand);
            this.Controls.Add(this.leftComputerHand);
            this.Controls.Add(this.playerHand);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "GameBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "President";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnPlayerDone;
        public System.Windows.Forms.Button btnStart;
        private PlayerHand playerHand;
        private ComputerHand leftComputerHand;
        private ComputerHand rightComputerHand;
        private KupaUI kupaUI;
        public System.Windows.Forms.TextBox txtMessages;
        public System.Windows.Forms.Label lblPlayerNameLabel;
        public System.Windows.Forms.Button btnShowHide;
        public System.Windows.Forms.Button btnMainMenu;
    }
}