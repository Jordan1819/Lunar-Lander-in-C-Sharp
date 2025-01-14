using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

/* The GameMaster class is the central controller for the
 * game. It should instantiate instances of and orchestrate
 * interactions between relevant classes
 * and control the game loop. */
namespace WaiteJordanCS3309LunarLander {
    public class GameMaster {
        // Class Fields
        Lander lander;
        Terrain terrain;
        Graphics g;
        // Constructor
        public GameMaster(Graphics graphics, int screenHeight) {
            //System.Diagnostics.Debug.WriteLine("GameMaster instantiated"); // Debugging control flow
            terrain = new Terrain(screenHeight);
            g = graphics;
        }
        // ***Class Methods***
        // initializeGame(): Initialize game componenets
        public void initializeGame(int screenHeight, int screenWidth) {
            // Instantiate lander at starting position
            int landerWidth = 40;
            int landerHeight = 40;
            int startX = (screenWidth - landerWidth) / 2;
            int startY = 200; // Start near the top of the screen
            lander = new Lander(g, startX, startY, landerWidth, landerHeight, 0, 0);
        }
        // updateGame(): Update game state
        public void updateGame(double deltaTime, int screenWidth, bool isVerticalThrustActivated, bool isLeftThrustActivated, bool isRightThrustActivated, bool isLeftRotationActivated, bool isRightRotationActivated, bool isRotationVerticalThrustActivated) {
            //System.Diagnostics.Debug.WriteLine("Calling applyVerticalThrusters()");
            // Apply gravity to the lander
            lander.applyGravity(deltaTime);
            // Apply vertical thrust if activated
            if (isVerticalThrustActivated) {
                lander.drawThrusterFlame();
                lander.applyVerticalThrusters(deltaTime);
            }
            // Applying rotational vertical thrust if activated
            if (isRotationVerticalThrustActivated) {
                lander.drawThrusterFlame();
                lander.applyRotationalVerticalThrusters(deltaTime);
            }
            // Applying side thrusters / rotational thrusters
            if (isLeftThrustActivated) {
                lander.applyLeftThrust(deltaTime);
            }
            if (isRightThrustActivated) {
                lander.applyRightThrust(deltaTime);
            }
            if (isLeftRotationActivated) {
                lander.applyLeftRotation(deltaTime);
            }
            if (isRightRotationActivated) {
                lander.applyRightRotation(deltaTime);
            }
            // Update position
            lander.move(deltaTime, screenWidth);
        }
        // drawLander(): Draws the lander
        public void drawLander(Graphics g) {
            lander.draw();
        }
        // drawTerrain(): Draws the terrain with rocks - advanced mode
        public void drawTerrain(Graphics g) {
           terrain.drawTerrain(g);
        }
        // drawTerrainNoRocks(): Draw the terrain without rocks - conventional mode
        public void drawTerrainNoRocks(Graphics g) {
            terrain.drawTerrainNoRocks(g);
        }
        // getLanderVelocity(): Returns the vertical velocity of the lander
        public double getLanderVelocity() {
            return lander.VelocityY;
        }
        // getHorizontalLanderVelocity(): Returns the horizontal velocity of the lander
        public double getHorizontalLanderVelocity() {
            return lander.VelocityX;
        }
        // getLanderAltitude(): Returns the lander's altitude relative to 
        // the terrain height
        public double getLanderAltitude(int screenHeight) {
            double terrainY = screenHeight - 75 - 3;
            return terrainY - lander.Y;
        }
        // getLanderFuel(): Returns the fuel property of the lander object
        public int getLanderFuel() {
            return lander.fuel;
        }
        // isLanderCollidingWithTerrain(): Boolean - whether or not the lander
        // is colliding with the terrain
        public bool isLanderCollidingWithTerrain() {
            return terrain.IsLanderCollidingWithTerrain(lander);
        }
        // isLanderCollidingWithRocks(): Boolean - whether or not the lander
        // is colliding with any rocks
        public bool isLanderCollidingWithRocks() {
            return terrain.isLanderCollidingWithRocks(lander);
        }
        // explodeLander(): Explode the lander
        public void explodeLander() {
            lander.explode();
        }
    }
}