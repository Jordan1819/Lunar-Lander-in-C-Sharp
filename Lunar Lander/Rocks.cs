using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/* The Rocks class defines specific areas on Terrain
 * that the lander must avoid. It will interact
 * with the Terrain & Lander classes and contain logic
 * for collision checks with the lander. */
namespace WaiteJordanCS3309LunarLander {
    public class Rocks {
        // Our rock objects will have read-only xy coordinates and size properties
        public int X { get; }
        public int Y { get; }
        public int Size { get; }

        // Constructor
        public Rocks(int x, int y, int size) {
            X = x;
            Y = y;
            Size = size;
        }
        // ***Class methods***

        // drawRock(): Draws a rock as a gray circle at x position
        public void drawRock(Graphics g) {
            int radius = Size / 2;
            g.FillEllipse(Brushes.LightGray, X - radius, Y - radius, Size, Size);

            // Draw a red rectangle around the collision boundary for debugging
            //Pen debugPen = new Pen(Color.Red, 2);
            //g.DrawRectangle(debugPen, X - radius, Y - radius, Size, Size);
        }
        // getBoundingBox(): Gets the bounding box for the rock object - collision
        public Rectangle getBoundingBox() {
            int radius = Size / 2;
            int x = this.X - radius;
            int y = this.Y - radius;
            return new Rectangle(x, y, Size, Size);
        }
        // isCollidingWithLander(): Determines if the lander ever collides with a rock
        public bool isCollidingWithLander(Lander lander) {
            // Get the bounding boxes (rectangles with same width and height) of
            // the rocks and lander
            Rectangle rockBounds = this.getBoundingBox();
            Rectangle landerBounds = lander.getBoundingBox();
            // Return true if the bounding boxes intersect - collision
            return landerBounds.IntersectsWith(rockBounds);
        }
    }
}