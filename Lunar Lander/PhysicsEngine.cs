using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/* The PhysicsEngine class handles the implementation gravitational.
 * acceleration and applying it to the lander.  */
namespace WaiteJordanCS3309LunarLander {
    public class PhysicsEngine {
        // Fields
        private Gravity gravity;
        // Constructor
        public PhysicsEngine() {
            gravity = new Gravity();
        }

        // ***Class Methods***
        // applyGravity(): Applies gravity to a lander object
        public void applyGravity(Lander lander, double deltaTime) {
            // Update velocity
            double acceleration = gravity.getAccelerationDueToGravity();
            lander.VelocityY += acceleration * deltaTime;
        }
    }
}