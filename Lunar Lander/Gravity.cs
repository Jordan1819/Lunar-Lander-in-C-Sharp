using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/* The Gravity Class is a simple class that encapsulates
 * the logic  and constants related to gravitational forces.  */
namespace WaiteJordanCS3309LunarLander {
    public class Gravity {
        // Lunar gravity should 1/6 of earths gravity but per the doc
        // specifications we will use 9m/s^2
        public const double lunarGravity = 9.00; // m/s^2

        // getAccelerationDueToGravity(): return the gravity constant
        public double getAccelerationDueToGravity() {
            return lunarGravity;
        }
    }
}