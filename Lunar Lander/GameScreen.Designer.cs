namespace WaiteJordanCS3309LunarLander {
    partial class GameScreen {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameScreen));
            lblVelocity = new Label();
            lblAltitude = new Label();
            lblFuel = new Label();
            lblHorizontalVelocity = new Label();
            SuspendLayout();
            // 
            // lblVelocity
            // 
            lblVelocity.AutoSize = true;
            lblVelocity.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVelocity.ForeColor = SystemColors.ControlLightLight;
            lblVelocity.Location = new Point(34, 32);
            lblVelocity.Name = "lblVelocity";
            lblVelocity.Size = new Size(21, 29);
            lblVelocity.TabIndex = 0;
            lblVelocity.Text = "-";
            // 
            // lblAltitude
            // 
            lblAltitude.AutoSize = true;
            lblAltitude.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAltitude.ForeColor = SystemColors.ControlLightLight;
            lblAltitude.Location = new Point(34, 151);
            lblAltitude.Name = "lblAltitude";
            lblAltitude.Size = new Size(21, 29);
            lblAltitude.TabIndex = 2;
            lblAltitude.Text = "-";
            // 
            // lblFuel
            // 
            lblFuel.AutoSize = true;
            lblFuel.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFuel.ForeColor = SystemColors.ControlLightLight;
            lblFuel.Location = new Point(34, 214);
            lblFuel.Name = "lblFuel";
            lblFuel.Size = new Size(21, 29);
            lblFuel.TabIndex = 3;
            lblFuel.Text = "-";
            // 
            // lblHorizontalVelocity
            // 
            lblHorizontalVelocity.AutoSize = true;
            lblHorizontalVelocity.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHorizontalVelocity.ForeColor = SystemColors.ControlLightLight;
            lblHorizontalVelocity.Location = new Point(34, 95);
            lblHorizontalVelocity.Name = "lblHorizontalVelocity";
            lblHorizontalVelocity.Size = new Size(21, 29);
            lblHorizontalVelocity.TabIndex = 4;
            lblHorizontalVelocity.Text = "-";
            // 
            // GameScreen
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1605, 932);
            Controls.Add(lblHorizontalVelocity);
            Controls.Add(lblFuel);
            Controls.Add(lblAltitude);
            Controls.Add(lblVelocity);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GameScreen";
            Text = "GameScreen";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblVelocity;
        private Label lblAltitude;
        private Label lblFuel;
        private Label lblHorizontalVelocity;
    }
}