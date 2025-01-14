using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/* Form1 serves as the main menu of the game, where players can choose their game mode and 
 * view the instructions of how to play */
namespace WaiteJordanCS3309LunarLander {
    public partial class Form1 : Form {
        private MenuEffects menuEffects;
        public Form1() {
            InitializeComponent();
            menuEffects = new MenuEffects(this);
            menuEffects.GenerateDots(50);
        }
        // Starts the advanced mode of the game with no rotation
        private void btnStartGame_Click(object sender, EventArgs e) {
            // Hide the title screen and open the game screen
            this.Hide();
            GameScreen gameScreen = new GameScreen(GameScreen.GameMode.Advanced);
            gameScreen.Show();
        }
        // Starts the conventional mode of the game
        private void btnStartConventionalGame_Click(object sender, EventArgs e) {
            // Hide the title screen and open the game screen
            this.Hide();
            GameScreen gameScreen = new GameScreen(GameScreen.GameMode.Conventional);
            gameScreen.Show();
        }
        // Starts the advanced mode with rotation
        private void btnStartRotationGame_Click(object sender, EventArgs e) {
            this.Hide();
            GameScreen gameScreen = new GameScreen(GameScreen.GameMode.Rotation);
            gameScreen.Show();
        }
        private void Form1_Load(object sender, EventArgs e) {
            centerButton(btnStartGame);
            centerButton(btnInstructions);
            centerButton(btnStartConventionalGame);
            centerButton(btnStartRotationGame);
        }
        // centerButton(): Horizontally center buttons on title screen
        private void centerButton(Button button) {
            button.Left = (this.ClientSize.Width - button.Width) / 2;
        }
        // Override Onpaint to draw the dots from MenuEffects
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            menuEffects.DrawDots(e.Graphics);
        }
        // Navigate back to the menu from the instructions screen
        private void btnBackToMenu_Click(object sender, EventArgs e) {
            // Hide the instructions and back button
            btnBackToMenu.Visible = false;
            lblInstructions0.Visible = false;
            lblInstructions1.Visible = false;
            lblInstructions2.Visible = false;
            lblInstructions3.Visible = false;
            lblInstructions4.Visible = false;
            lblInstructions5.Visible = false;
            // Display the "Start Game" and "Instructions" buttons
            btnStartGame.Visible = true;
            btnInstructions.Visible = true;
            btnStartConventionalGame.Visible = true;
            btnStartRotationGame.Visible = true;
        }
        // btnInstructions(): Display the instructions for gameplay
        private void btnInstructions_Click(object sender, EventArgs e) {
            // Hide the "Start Game" and "Instructions" buttons
            btnStartGame.Visible = false;
            btnInstructions.Visible = false;
            btnStartConventionalGame.Visible = false;
            btnStartRotationGame.Visible = false;
            // Display the instructions and back button
            btnBackToMenu.Visible = true;
            lblInstructions0.Visible = true;
            lblInstructions1.Visible = true;
            lblInstructions2.Visible = true;
            lblInstructions3.Visible = true;
            lblInstructions4.Visible = true;
            lblInstructions5.Visible = true;
        }


    }

}
