using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/* The GameScreen form serves as the form with which we will display the game and game elements. */
namespace WaiteJordanCS3309LunarLander {
    public partial class GameScreen : Form {
        // Use an enumerated type to represent the three game modes
        public enum GameMode {
            Conventional, 
            Advanced,
            Rotation
        }
        private GameMode mode;
        private MenuEffects menuEffects;
        GameMaster gameMaster;
        System.Windows.Forms.Timer gameTimer;
        System.Windows.Forms.Timer hudTimer;
        double deltaTime;
        bool move = true;
        Graphics g;
        public bool isVerticalThrustActivated;
        public bool isLeftThrustActivated;
        public bool isRightThrustActivated;
        public bool isLeftRotationActivated;
        public bool isRightRotationActivated;
        public bool isRotationVerticalThrustActivated;
        HUD hud = new HUD();
        public GameScreen(GameMode mode) {
            InitializeComponent();
            this.mode = mode;
            // Initialize other settings or game states here
            this.Load += GameScreen_Load;
        }
        private void GameScreen_Load(object sender, EventArgs e) {
            // Initialize game objects
            g = this.CreateGraphics();
            gameMaster = new GameMaster(g, this.ClientSize.Height);
            gameMaster.initializeGame(this.ClientSize.Height, this.ClientSize.Width);
            // Create  and start a game timer 
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = 16;
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();
        }
        // This method will be called with every tick of the game timer
        private void GameTimer_Tick(object sender, EventArgs e) {
            // Calculate deltaTime based on time between ticks
            deltaTime = gameTimer.Interval / 100.0;
            gameMaster.updateGame(deltaTime, this.ClientSize.Width, isVerticalThrustActivated, isLeftThrustActivated, isRightThrustActivated, isLeftRotationActivated, isRightRotationActivated, isRotationVerticalThrustActivated);
            // Update HUD elements
            double velocity = gameMaster.getLanderVelocity();
            lblVelocity.Text = $"Vertical Velocity: {gameMaster.getLanderVelocity() * -1:0.00} m/s";
            lblHorizontalVelocity.Text = $"Horizontal Velocity: {gameMaster.getHorizontalLanderVelocity():0.00} m/s";
            lblAltitude.Text = $"Altitude: {gameMaster.getLanderAltitude(this.ClientSize.Height):0.00} m";
            lblFuel.Text = $"Fuel: {gameMaster.getLanderFuel():0}";
            // Display velocity in red if it's greater than safe landing speed: 45 m/s
            if (velocity > 45) {
                lblVelocity.ForeColor = Color.Red;
            }
            else {
                lblVelocity.ForeColor = Color.White;
            }
            // Check for collisions
            bool collidedWithTerrain = gameMaster.isLanderCollidingWithTerrain();
            bool collidedWithRocks = gameMaster.isLanderCollidingWithRocks();
            // If we get collision with terrain
            if (collidedWithTerrain) {
                // If velocity is too great when we collide with terrain
                if (velocity > 45) {
                    gameMaster.explodeLander();
                    GameOver("You landed too fast!");
                }
                else {
                    GameWin();
                }
            }
            else if (collidedWithRocks) {
                // If we collide with a rock at all - game over
                gameMaster.explodeLander();
                GameOver("You collided with a rock!");
            }
        }
        // Override OnPaint to draw terrain when game loads
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            // Draw the terrain with rocks - advanced mode/ rotation mode
            if (mode == GameMode.Advanced || mode == GameMode.Rotation) {
                gameMaster.drawTerrain(e.Graphics);
            }
            // Draw the terrain with no rocks - conventional mode
            if (mode == GameMode.Conventional) {
                gameMaster.drawTerrainNoRocks(e.Graphics);
            }
            // Drawing the stars in the background - causes lag
            //menuEffects.DrawDots(e.Graphics);
        }
        // OnKeyDown(): Logic for holding & releasing certain keyboard inputs
        protected override void OnKeyDown(KeyEventArgs e) {
            base.OnKeyDown(e);
            // If rotation mode enabled
            if (mode == GameMode.Rotation) {
                if (e.KeyCode == Keys.Space) {
                    isRotationVerticalThrustActivated = true;
                }
            }
            // If either other game mode enabled
            if (mode == GameMode.Conventional || mode == GameMode.Advanced) {
                if (e.KeyCode == Keys.Space) {
                    //System.Diagnostics.Debug.WriteLine("Spacebar held"); // Debugging
                    isVerticalThrustActivated = true;
                }
            }
            // If advanced mode enable left and right thrusters
            if (mode == GameMode.Advanced) {
                if (e.KeyCode == Keys.A) {
                    isLeftThrustActivated = true;
                }
                if (e.KeyCode == Keys.D) {
                    isRightThrustActivated = true;
                }
            }
            // If rotation mode enabled
            if (mode == GameMode.Rotation) {
                if (e.KeyCode == Keys.A) {
                    isRightRotationActivated = true;
                }
                if (e.KeyCode == Keys.D) {
                    isLeftRotationActivated = true;
                }
            }
        }
        // OnKeyUp(): Logic for releasing certain keyboard inputs
        protected override void OnKeyUp(KeyEventArgs e) {
            base.OnKeyUp(e);
            if (e.KeyCode == Keys.Space) {
                isVerticalThrustActivated = false;
                isRotationVerticalThrustActivated = false;
            }
            if (e.KeyCode == Keys.A) {
                isLeftThrustActivated = false;
                isRightRotationActivated = false;
            }
            if (e.KeyCode == Keys.D) {
                isRightThrustActivated = false;
                isLeftRotationActivated = false;
            }
        }
        // GameOver(): Display the game over message and give the user the option to retry
        private void GameOver(string message) {
            gameTimer.Stop();
            DialogResult result = MessageBox.Show($"Game Over! {message}\n\nWould you like to retry?", "Game Over!",
            MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes) {
                RestartGame();
            }
            else {
                this.Close();
            }
        }
        // GameWin(): Display the game win message and give the user the option to retry
        private void GameWin() {
            gameTimer.Stop();
            DialogResult result = MessageBox.Show("You Win!\n\nWould you like to retry?", "Successful Landing!",
            MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes) {
                RestartGame();
            }
            else {
                this.Close();
            }
        }
        // RestartGame(): Restarts the game
        private void RestartGame() {
            // Re-initialize the game state
            gameMaster.initializeGame(this.ClientSize.Height, this.ClientSize.Width);
            // Reset timers and game variables
            gameTimer.Start();
            isVerticalThrustActivated = false;
            // Update HUD labels to initial state
            lblVelocity.Text = "Velocity: 0.00 m/s";
            lblAltitude.Text = "Altitude: 0.00 m";
            lblFuel.Text = "Fuel: 2000"; // Assuming starting fuel is 2000
            lblVelocity.ForeColor = Color.White;
            // Redraw terrain and lander
            this.Invalidate(); // Triggers the OnPaint method
        }
    }
}