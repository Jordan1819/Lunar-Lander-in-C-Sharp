using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
/* The HUD class defines the different HUD elements we want to draw to the 
 * screen and update as the game progresses. */
namespace WaiteJordanCS3309LunarLander {
    public class HUD {
        // Class fields
        private Font hudFont = new Font("Arial", 12, FontStyle.Bold);
        private Brush hudBrush = Brushes.White;

        // Class Methods
        public void drawHUD(Graphics g, double landerVelocity, double altitude, int fuel) {
            // Draw velocity
            string velocityText = $"Velocity: {landerVelocity:F2} m/s";
            g.DrawString(velocityText, hudFont, hudBrush, new PointF(10, 10));
            // Draw altitude
            string altitudeText = $"Altitude: {altitude:F2} m";
            g.DrawString(altitudeText, hudFont, hudBrush, new PointF(10, 50));
            // Draw fuel
            string fuelText = $"Fuel: {fuel}";
            g.DrawString(fuelText, hudFont, hudBrush, new PointF(10, 90));
        }
    }
}