using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
/* The menu effects class generates and moves small white dots
 * from the top of the screen to the bottom when the user is at
 * the main menu. The idea is to simulate a "traveling through space" 
 * effect. */
namespace WaiteJordanCS3309LunarLander {
    public class MenuEffects {
        // Class fields
        private List<PointF> dots; // List to hold the coordinates of the dots
        private Random random;
        private System.Windows.Forms.Timer timer;
        private Form targetForm;
        // Dot size and speed settings
        private const float DotSize = 5f;
        private const float Speed = 8f;
        // Constructor
        public MenuEffects(Form targetForm) {
            this.targetForm = targetForm;
            random = new Random();
            dots = new List<PointF>();
            InitializeTimer();
        }
        // InitializeTimer(): Create and start the timer for our menu space effect
        private void InitializeTimer() {
            // Create a timer to update the position of the stars
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 30; // Update every 30ms (about 33 FPS)
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        // GenerateDots(): Generate random white dots at the top of the screen
        public void GenerateDots(int numberOfDots) {
            for (int i = 0; i < numberOfDots; i++) {
                // Random x position
                float x = random.Next(0, targetForm.ClientSize.Width);
                float y = random.Next(-targetForm.ClientSize.Height, 0); // Start from above the screen
                dots.Add(new PointF(x, y));
            }
        }
        // TimerTick(): Called with each tick of the timer - updates the position of the dots each frame
        private void Timer_Tick(object sender, EventArgs e) {
            List<PointF> updatedDots = new List<PointF>();

            foreach (var dot in dots) {
                // Move each dot downwards
                updatedDots.Add(new PointF(dot.X, dot.Y + Speed));
            }
            // Remove dots that have moved past the bottom of the screen
            updatedDots.RemoveAll(dot => dot.Y > targetForm.ClientSize.Height);
            dots = updatedDots;
            // Generate more dots to keep the effect going
            if (dots.Count < 100) { // Ensure there are always at least 100 dots
                GenerateDots(5); // Add 5 more dots
            }
            // Redraw the form to update the visual effect
            targetForm.Invalidate();
        }
        // DrawDots(): Draw the dots on the screen
        public void DrawDots(Graphics g) {
            foreach (var dot in dots) {
                g.FillEllipse(Brushes.White, dot.X, dot.Y, DotSize, DotSize);
            }
        }
    }
}
