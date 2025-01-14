using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/* The Thrusters class is responsible for the logic behind the verticle thrusters
 * on the lander as well as the horizontal and angular side thrusters */
namespace WaiteJordanCS3309LunarLander {
    public class Thrusters {
        // Class fields
        public double verticalThrustPower;
        public double horizontalThrustPower;
        public bool verticalThrusterIsActive;
        public bool leftThrusterIsActive;
        public bool rightThrusterIsActive;
        // Constructor
        public Thrusters(double verticalPower, double horizontalPower) {
            verticalThrustPower = verticalPower;
            horizontalThrustPower = horizontalPower;
        }
        // ***Class Methods***
        // Activate and deactivate vertical thruster
        public void activateVerticalThruster() {
            //System.Diagnostics.Debug.WriteLine("Vertical thruster activated.");
            verticalThrusterIsActive = true;
        }
        public void deactivateVerticalThruster() {
            verticalThrusterIsActive = false;
        }
        // Apply vertical thrust power to lander
        public void applyVerticalThrust(Lander lander, double deltaTime) {
            // Reduce downward velocity or cause upward movement
            double thrustForce = verticalThrustPower * deltaTime;
            //System.Diagnostics.Debug.WriteLine($"Applying thrust: {thrustForce}");
            lander.VelocityY -= thrustForce;
        }
        // Return vertical thrustForce
        public double getVerticalThrustForce(double deltaTime) {
            double thrustForce = verticalThrustPower * deltaTime;
            return thrustForce;
        }
        // Activate and deactivate left thruster
        public void activateLeftThruster() {
            leftThrusterIsActive = true;
        }
        public void deactivateLeftThruster() {
            leftThrusterIsActive = false;
        }
        // Activate and deactivate right thruster
        public void activateRightThruster() {
            rightThrusterIsActive = true;
        }
        public void deactivateRightThruster() {
            rightThrusterIsActive = false;
        }
        // Apply horizontal thrust power to lander
        public void applyLeftThrust(Lander lander, double deltaTime) {
            double thrustForce = horizontalThrustPower * deltaTime;
            lander.VelocityX -= deltaTime;
        }
        public void applyRightThrust(Lander lander, double deltaTime) {
            double thrustForce = horizontalThrustPower * deltaTime;
            lander.VelocityX += deltaTime;
        }
        // Applying counter-clockwise rotation
        public void applyLeftRotation(Lander lander, double deltaTime) {
            double thrustForce = horizontalThrustPower * deltaTime / 7;
            lander.angularVelocity += thrustForce * -1;
        }
        // Applying clockwise rotation
        public void applyRightRotation(Lander lander, double deltaTime) {
            double thrustForce = horizontalThrustPower * deltaTime / 7;
            lander.angularVelocity += thrustForce;
        }
    }
}