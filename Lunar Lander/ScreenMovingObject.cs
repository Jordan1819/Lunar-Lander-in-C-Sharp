using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
/* The ScreenMovingObject class defines the basic
 * class fields and properties that an object that moves
 * on the screen needs to have (the lander). */
namespace WaiteJordanCS3309LunarLander {
    public class ScreenMovingObject {
        // Class fields/ properties
        Graphics g;
        public double X { get; set; }
        public double Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public double VelocityX { get; set; }
        public double VelocityY { get; set; }
        public int gWidth;  
        public int gHeight;
        // Constructor 
        public ScreenMovingObject(Graphics graphics, double x, double y, int width, int height, double velocityX, double velocityY) {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            VelocityX = 0;
            VelocityY = 0;
            g = graphics;
        }
        // Class methods
        // Draw method (will be overridden by subclasses)
        public virtual void draw() {

        }
        // Update position
        public void updatePosition(double deltaTime) {
            X += VelocityX * deltaTime;
            Y += VelocityY * deltaTime;
        }
        // Methods to convert X and Y to int for drawing
        public int getDrawX() => (int)Math.Round(X);
        public int getDrawY() => (int)Math.Round(Y);
    }
}
