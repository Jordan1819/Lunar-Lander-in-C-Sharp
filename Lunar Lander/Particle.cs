using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* The Particle class defines the particle objects that will
 * be used for the lander explode() animation upon crashing into the terrain
 * too quickly or upon colliding with a rock. */
namespace WaiteJordanCS3309LunarLander {
    public class Particle {
        // Class fields
        private double x;
        private double y;
        private double angle;
        private double speed;
        private int lifetime = 30;
        // Constructor
        public Particle(double startX, double startY, double angle,  double speed) {
            this.x = startX;
            this.y = startY;
            this.angle = angle;
            this.speed = speed;
        }

        //***Class methods***

        // move(): move the particle outward by updating its
        // position using trig functions
        public void move() {
            x += Math.Cos(angle) * speed;
            y += Math.Sin(angle) * speed;
            speed = 2.0;
            lifetime--;
        }
        // draw(): Draws the particle as a small blue circle
        public void draw(Graphics g) {
            // Create particle at the center of the lander
            g.FillEllipse(Brushes.DodgerBlue, (float)x, (float)y, 3, 3);
        }
        // isFinished(): returns true when the lifetime (animation time) of a particle finishes
        public bool isFinished() {
            return lifetime <= 0;
        }
    }
}
