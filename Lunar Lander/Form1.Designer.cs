namespace WaiteJordanCS3309LunarLander {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnStartGame = new Button();
            titleText = new Label();
            btnInstructions = new Button();
            lblInstructions1 = new Label();
            btnBackToMenu = new Button();
            lblInstructions2 = new Label();
            lblInstructions0 = new Label();
            lblInstructions3 = new Label();
            lblInstructions4 = new Label();
            btnStartConventionalGame = new Button();
            lblInstructions5 = new Label();
            btnStartRotationGame = new Button();
            SuspendLayout();
            // 
            // btnStartGame
            // 
            btnStartGame.Anchor = AnchorStyles.Top;
            btnStartGame.BackColor = SystemColors.ControlLightLight;
            btnStartGame.Font = new Font("Snap ITC", 16.125F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnStartGame.ForeColor = SystemColors.ActiveCaptionText;
            btnStartGame.Location = new Point(787, 810);
            btnStartGame.Name = "btnStartGame";
            btnStartGame.Size = new Size(467, 129);
            btnStartGame.TabIndex = 0;
            btnStartGame.Text = "Advanced Mode - No Rotation";
            btnStartGame.UseVisualStyleBackColor = true;
            btnStartGame.Click += btnStartGame_Click;
            // 
            // titleText
            // 
            titleText.Anchor = AnchorStyles.Top;
            titleText.AutoSize = true;
            titleText.Font = new Font("Showcard Gothic", 72F, FontStyle.Italic, GraphicsUnit.Point, 0);
            titleText.ForeColor = SystemColors.ButtonHighlight;
            titleText.Location = new Point(305, 47);
            titleText.Name = "titleText";
            titleText.Size = new Size(1463, 237);
            titleText.TabIndex = 1;
            titleText.Text = "Lunar Lander";
            titleText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnInstructions
            // 
            btnInstructions.Anchor = AnchorStyles.Top;
            btnInstructions.Font = new Font("Snap ITC", 16.125F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnInstructions.Location = new Point(787, 1208);
            btnInstructions.Name = "btnInstructions";
            btnInstructions.Size = new Size(467, 129);
            btnInstructions.TabIndex = 2;
            btnInstructions.Text = "Instructions";
            btnInstructions.UseVisualStyleBackColor = true;
            btnInstructions.Click += btnInstructions_Click;
            // 
            // lblInstructions1
            // 
            lblInstructions1.Anchor = AnchorStyles.Top;
            lblInstructions1.Font = new Font("Showcard Gothic", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblInstructions1.ForeColor = SystemColors.ButtonHighlight;
            lblInstructions1.Location = new Point(188, 613);
            lblInstructions1.Name = "lblInstructions1";
            lblInstructions1.Size = new Size(1655, 64);
            lblInstructions1.TabIndex = 3;
            lblInstructions1.Text = "1. Hold SPACEBAR to activate thrusters. Release to deactivate.";
            lblInstructions1.TextAlign = ContentAlignment.MiddleCenter;
            lblInstructions1.Visible = false;
            // 
            // btnBackToMenu
            // 
            btnBackToMenu.Anchor = AnchorStyles.Top;
            btnBackToMenu.BackColor = SystemColors.ControlLightLight;
            btnBackToMenu.Font = new Font("Snap ITC", 16.125F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnBackToMenu.ForeColor = SystemColors.ActiveCaptionText;
            btnBackToMenu.Location = new Point(93, 1208);
            btnBackToMenu.Name = "btnBackToMenu";
            btnBackToMenu.Size = new Size(467, 129);
            btnBackToMenu.TabIndex = 4;
            btnBackToMenu.Text = "Back";
            btnBackToMenu.UseVisualStyleBackColor = false;
            btnBackToMenu.Visible = false;
            btnBackToMenu.Click += btnBackToMenu_Click;
            // 
            // lblInstructions2
            // 
            lblInstructions2.Anchor = AnchorStyles.Top;
            lblInstructions2.Font = new Font("Showcard Gothic", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblInstructions2.ForeColor = SystemColors.ButtonHighlight;
            lblInstructions2.Location = new Point(62, 694);
            lblInstructions2.Name = "lblInstructions2";
            lblInstructions2.Size = new Size(1949, 139);
            lblInstructions2.TabIndex = 5;
            lblInstructions2.Text = "2. Advanced Mode - Hold \"A\" and \"D\" to activate the left and right thrusters respectively.";
            lblInstructions2.TextAlign = ContentAlignment.MiddleCenter;
            lblInstructions2.Visible = false;
            // 
            // lblInstructions0
            // 
            lblInstructions0.Anchor = AnchorStyles.Top;
            lblInstructions0.Font = new Font("Showcard Gothic", 25.875F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblInstructions0.ForeColor = SystemColors.ButtonHighlight;
            lblInstructions0.Location = new Point(188, 372);
            lblInstructions0.Name = "lblInstructions0";
            lblInstructions0.Size = new Size(1655, 145);
            lblInstructions0.TabIndex = 6;
            lblInstructions0.Text = "Mission Briefing For All Lunar Cadets:";
            lblInstructions0.TextAlign = ContentAlignment.MiddleCenter;
            lblInstructions0.Visible = false;
            // 
            // lblInstructions3
            // 
            lblInstructions3.Anchor = AnchorStyles.Top;
            lblInstructions3.Font = new Font("Showcard Gothic", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblInstructions3.ForeColor = SystemColors.ButtonHighlight;
            lblInstructions3.Location = new Point(12, 848);
            lblInstructions3.Name = "lblInstructions3";
            lblInstructions3.Size = new Size(1653, 64);
            lblInstructions3.TabIndex = 7;
            lblInstructions3.Text = "3. Land in flat safe zones. Avoid rocks at all costs!";
            lblInstructions3.TextAlign = ContentAlignment.MiddleCenter;
            lblInstructions3.Visible = false;
            // 
            // lblInstructions4
            // 
            lblInstructions4.Anchor = AnchorStyles.Top;
            lblInstructions4.Font = new Font("Showcard Gothic", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblInstructions4.ForeColor = SystemColors.ButtonHighlight;
            lblInstructions4.Location = new Point(-145, 942);
            lblInstructions4.Name = "lblInstructions4";
            lblInstructions4.Size = new Size(1949, 64);
            lblInstructions4.TabIndex = 8;
            lblInstructions4.Text = "4. You must land at velocity no faster than 45 m/s.";
            lblInstructions4.TextAlign = ContentAlignment.MiddleCenter;
            lblInstructions4.Visible = false;
            // 
            // btnStartConventionalGame
            // 
            btnStartConventionalGame.Anchor = AnchorStyles.Top;
            btnStartConventionalGame.Font = new Font("Snap ITC", 16.125F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnStartConventionalGame.Location = new Point(787, 622);
            btnStartConventionalGame.Name = "btnStartConventionalGame";
            btnStartConventionalGame.Size = new Size(467, 123);
            btnStartConventionalGame.TabIndex = 9;
            btnStartConventionalGame.Text = "Classic Mode";
            btnStartConventionalGame.UseVisualStyleBackColor = true;
            btnStartConventionalGame.Click += btnStartConventionalGame_Click;
            // 
            // lblInstructions5
            // 
            lblInstructions5.Anchor = AnchorStyles.Top;
            lblInstructions5.Font = new Font("Showcard Gothic", 18F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblInstructions5.ForeColor = SystemColors.ButtonHighlight;
            lblInstructions5.Location = new Point(-36, 1029);
            lblInstructions5.Name = "lblInstructions5";
            lblInstructions5.Size = new Size(1949, 64);
            lblInstructions5.TabIndex = 10;
            lblInstructions5.Text = "5. Running out of fuel will render your thrusters useless!";
            lblInstructions5.TextAlign = ContentAlignment.MiddleCenter;
            lblInstructions5.Visible = false;
            // 
            // btnStartRotationGame
            // 
            btnStartRotationGame.Anchor = AnchorStyles.Top;
            btnStartRotationGame.Font = new Font("Snap ITC", 16.125F, FontStyle.Italic, GraphicsUnit.Point, 0);
            btnStartRotationGame.Location = new Point(787, 1003);
            btnStartRotationGame.Name = "btnStartRotationGame";
            btnStartRotationGame.Size = new Size(467, 123);
            btnStartRotationGame.TabIndex = 11;
            btnStartRotationGame.Text = "Advanced Mode - Rotation";
            btnStartRotationGame.UseVisualStyleBackColor = true;
            btnStartRotationGame.Click += btnStartRotationGame_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlText;
            ClientSize = new Size(2000, 1443);
            Controls.Add(btnStartRotationGame);
            Controls.Add(lblInstructions5);
            Controls.Add(btnStartConventionalGame);
            Controls.Add(lblInstructions4);
            Controls.Add(lblInstructions3);
            Controls.Add(lblInstructions0);
            Controls.Add(lblInstructions2);
            Controls.Add(btnBackToMenu);
            Controls.Add(lblInstructions1);
            Controls.Add(btnInstructions);
            Controls.Add(titleText);
            Controls.Add(btnStartGame);
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lunar Lander";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStartGame;
        private Label titleText;
        private Button btnInstructions;
        private Label lblInstructions1;
        private Button btnBackToMenu;
        private Label lblInstructions2;
        private Label lblInstructions0;
        private Label lblInstructions3;
        private Label lblInstructions4;
        private Button btnStartConventionalGame;
        private Label lblInstructions5;
        private Button btnStartRotationGame;
    }
}
