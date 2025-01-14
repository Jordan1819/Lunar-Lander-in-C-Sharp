using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

/* The Lander class is responsible for instantiating our 
 * lunar lander object and updating position.
 * The main object that the player controls.
 * Lander should inherit from (is a) ScreenMovingObject which allows
 * it to have movement. It works directly with Thrusters, PhysicsEngine, and GameMaster */
namespace WaiteJordanCS3309LunarLander {
    public class Lander : ScreenMovingObject {
        // Class fields & instantiated objects/ classes
        public int fuel { get; private set; }
        public double angle { get; private set; }
        public double angularVelocity = 0;
        Graphics g;
        private Pen landerPen = new Pen(Color.DodgerBlue, 10);
        private Pen eraser = new Pen(Color.Black, 10);
        PhysicsEngine physics = new PhysicsEngine();
        Thrusters thruster = new Thrusters(17.0, 17.0);
        private List<Particle> particles = new List<Particle>();
        private Random random = new Random();
        System.Windows.Forms.Timer explosionTimer;
        // Constructor
        public Lander(Graphics graphics, double x, double y, int width, int height, double velocityX, double velocityY) : base(graphics, x, y, width, height, velocityX, velocityY) {
            g = graphics;
            fuel = 300;
        }

        // ***Class methods involving drawing, erasing, and movement***

        // draw(): Overridden inherited method: Draw the lander
        public override void draw() {
            // Save graphics state to restore later
            GraphicsState state = g.Save();
            //System.Diagnostics.Debug.WriteLine($"Drawing lander with angle: {angle}");
            // Translate the graphics object to the center of the lander - crucial for rotation
            float centerX = getDrawX() + Width / 2;
            float centerY = getDrawY() + Height / 2;
            g.TranslateTransform(centerX, centerY);
            // Apply rotation around the center of the lander
            g.RotateTransform((float)angle);
            // Translate back to top-left of the lander
            g.TranslateTransform(-centerX, -centerY);
            // Create the body of the lander
            g.FillEllipse(Brushes.DodgerBlue, getDrawX(), getDrawY(), Width, Height);
            // Create diagonal lines for the side thrusters
            g.DrawLine(landerPen, getDrawX(), getDrawY(), getDrawX() - 10, getDrawY() + Height);
            g.DrawLine(landerPen, getDrawX() + Width, getDrawY(), getDrawX() + Width + 10, getDrawY() + Height);
            // Restore graphics state to undo transformation
            g.Restore(state);
            // Debugging: Draw collision boundary
            //Pen debugPen = new Pen(Color.Red, 2);
            //g.DrawRectangle(debugPen, getDrawX(), getDrawY(), Width, Height);
        }
        // getBoundingBox(): Gets the bounding box for the lander - collision
        public Rectangle getBoundingBox() {
            int x = getDrawX();
            int y = getDrawY();
            return new Rectangle(x, y, Width, Height);
        }
        // drawThrusterFlame(): If the vertical thruster is activated, draws red flames coming from the bottom center of
        // the lander
        public void drawThrusterFlame() {
            float centerX = getDrawX() + Width / 2;
            float centerY = getDrawY() + Height;
            Pen thrusterPen = new Pen(Color.Red, 5);
            // Draw the flame
            g.DrawLine(thrusterPen, centerX, centerY, centerX, centerY + 20);
            // Start a timer to erase the flame after a delay
            System.Windows.Forms.Timer flameTimer = new System.Windows.Forms.Timer();
            flameTimer.Interval = 100; 
            // Define what happens when the timer ticks using event handling combined
            // with a lambda expression anonymous method
            flameTimer.Tick += (sender, e) => {
                // Erase the flame
                Pen eraserPen = new Pen(Color.Black, 5);
                g.DrawLine(eraserPen, centerX, centerY, centerX, centerY + 20);
                // Stop and delete the timer
                flameTimer.Stop();
                flameTimer.Dispose();
            };
            flameTimer.Start();
        }
        // erase(): Erase the lander - same as draw method but with the background color
        public void erase() {
            GraphicsState state = g.Save();
            // Translate the graphics object to the center of the lander
            float centerX = getDrawX() + Width / 2;
            float centerY = getDrawY() + Height / 2;
            g.TranslateTransform(centerX, centerY);
            // Apply the rotation around the center of the lander
            g.RotateTransform((float)angle);
            // Translate back to the top-left corner of the lander (origin of drawing)
            g.TranslateTransform(-centerX, -centerY);
            // Erase the lander at its transformed position
            g.FillRectangle(Brushes.Black, getDrawX(), getDrawY(), Width, Height);
            g.DrawLine(eraser, getDrawX(), getDrawY(), getDrawX() - 10, getDrawY() + Height);
            g.DrawLine(eraser, getDrawX() + Width, getDrawY(), getDrawX() + Width + 10, getDrawY() + Height);
            // Restore the graphics state to prevent transformations affecting future operations
            g.Restore(state);
        }
        // applyGravity(): Apply gravity to the lander
        public void applyGravity(double deltaTime) {
            physics.applyGravity(this, deltaTime);
        }
        // move(): Update the landers position
        public void move(double deltaTime, int screenWidth) {
            erase();
            // Update position based on velocity and time
            X += VelocityX * deltaTime;
            Y += VelocityY * deltaTime;
            // Checking/ updating for rotation
            angle += angularVelocity * deltaTime;
            if (angle >= 360) angle -= 360;
            if (angle < 0) angle += 360;
            // Debugging
            //System.Diagnostics.Debug.WriteLine($"Lander angle: {angle}, Angular Velocity: {angularVelocity}");
            // Check for boundary crossing and wrap around the screen
            // If the lander moves off the left side of the screen
            if (X + Width < 0) {
                X = screenWidth;
            // If the lander moves off the right side of the screen
            } else if (X > screenWidth) {
                X = -Width;
            }
            draw();
        }
        // explode(): Generates a short animation showing the lander exploding
        public void explode() {
            // Generate particles for the explosion animation
            int numParticles = 30;
            for (int i = 0; i < numParticles; i++) {
                // Random directions
                double angle = random.NextDouble() * Math.PI * 2;
                // Random speed between 5 - 15
                double speed = random.Next(5, 15);
                // Generate this particle with the random angle and speed
                particles.Add(new Particle(getDrawX() + Width / 2, getDrawY() + Height / 2, angle, speed));
            }
            // Set up and start the timer for the explosion animation
            explosionTimer = new System.Windows.Forms.Timer();
            explosionTimer.Interval = 30; //in ms
            // Call the tick method each time the timer ticks
            explosionTimer.Tick += ExplosionTimer_Tick;
            explosionTimer.Start();
        }
        // ExplosionTimer_Tick(): Called each time the explosion animation timer ticks
        public void ExplosionTimer_Tick(object sender, EventArgs e) {
            // Erase the lander
            erase();
            // Instantiate flag for animation being finished
            bool isAnimationFinished = true;
            // Draw and move each particle
            foreach (var particle in particles) {
                particle.move();
                particle.draw(g);
                if (!particle.isFinished()) {
                    isAnimationFinished = false;
                }
            }
            if (isAnimationFinished) {
                explosionTimer.Stop();
                explosionTimer.Dispose();
            }
        }

        // ***Class methods involving thrusters***

        // Activate and deactivate vertical thrusters
        public void ActivateVerticalThruster() {
            thruster.activateVerticalThruster();
        }
        public void DeactivateThruster() {
            thruster.deactivateVerticalThruster();
        }
        // Apply the vertical thruster to the lander and decrease fuel
        public void applyVerticalThrusters(double deltaTime) {
            if (fuel > 0) {
                //System.Diagnostics.Debug.WriteLine("Applying vertical thrust in lander...");
                thruster.applyVerticalThrust(this, deltaTime);
                fuel--; // Decrease fuel with each tick as the thrusters are activated
            }
        }
        // Apply vertical thruster when rotational engines are enabled
        public void applyRotationalVerticalThrusters(double deltaTime) {
            if (fuel > 0) {
                //Convert current angle to radians - C# trig expects radians
                double angleInRadians = Math.PI * angle / 180.0;
                // Calculate the X and Y components of thrust by using vector trig
                // and treating 'angle' as theta relative to the Y axis
                double thrustX = Math.Sin(angleInRadians) * thruster.verticalThrustPower;
                double thrustY = Math.Cos(angleInRadians) * thruster.verticalThrustPower;
                // Apply the thrust in the direction the lander is facing
                VelocityX += thrustX * deltaTime;
                VelocityY -= thrustY * deltaTime;
                // Decrease fuel
                fuel--;
            }
        }
        // Activate and deactivate left and right thrusters
        public void activateLeftThruster() {
            thruster.activateLeftThruster();
        }
        public void deactivateLeftThruster() {
            thruster.deactivateLeftThruster();
        }
        public void activateRightThruster() {
            thruster.activateRightThruster();
        }
        public void deactivateRightThruster() {
            thruster.deactivateRightThruster();
        }
        // Apply horizontal thrusters
        public void applyLeftThrust(double deltaTime) {
            thruster.applyLeftThrust(this, deltaTime);
        }
        public void applyRightThrust(double deltaTime) {
            thruster.applyRightThrust(this, deltaTime);
        }
        // Apply rotational thrusters
        public void applyLeftRotation(double deltaTime) {
            thruster.applyLeftRotation(this, deltaTime);
        }
        public void applyRightRotation(double deltaTime) {
            thruster.applyRightRotation(this, deltaTime);
        }
    }
} 