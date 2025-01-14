using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
/* The Terrain class creates the surface of the moon that our lander
 * is trying to land on. It should manage Rocks and 
 * manage the logic for collision checks. */
namespace WaiteJordanCS3309LunarLander {
    public class Terrain {

        // Class fields
        Pen terrainPen;
        List<Rocks> rocks;
        int screenHeight;
        Graphics g;

        // Constructor
        public Terrain(int screenHeight) {
            this.screenHeight = screenHeight;
            this.terrainPen = new Pen(Color.White, 10);
            this.rocks = new List<Rocks>();
        }

        // *****Class Methods****** 
        // drawTerrain(): Draws white line for moon surface and adds rocks for advanced mode
        public void drawTerrain(Graphics g) {
            // Draw the flat ground
            g.DrawLine(terrainPen, 0, screenHeight - 50, g.VisibleClipBounds.Width, screenHeight - 50);
            // Populate our list of rock objects
            generateRocks(5, g);
            // Draw each rock
            foreach (var rock in rocks) {
                rock.drawRock(g);
            }
        }
        // drawTerrainNoRocks(): Draws terrain without any rocks for conventional mode
        public void drawTerrainNoRocks(Graphics g) {
            // Only draw the flat ground
            g.DrawLine(terrainPen, 0, screenHeight - 50, g.VisibleClipBounds.Width, screenHeight - 50);
        }
        // *** This method caused all sorts of false positives for detecting collision with rocks
        // *** for some reason.
        /* generateRocks(): Add rock objects to our list of rocks at random x positions
        public void generateRocks(int r, Graphics g) {
            // CLear list (increase number of rocks each level)
            rocks.Clear();
            Random random = new Random();
            int numRocks = r;
            for (int i = 0; i < numRocks; i++) {
                // add x amount of rocks at random x coordinates along the moon's surface
                int x = random.Next(0, (int)g.VisibleClipBounds.Width);
                int y = screenHeight - 75;
                int size = 100;
                rocks.Add(new Rocks(x, y, size));
            }
        } */
        // generateRocks(): Add rock objects at fixed positions
        public void generateRocks(int r, Graphics g) {
            rocks.Clear();
            int screenWidth = (int)g.VisibleClipBounds.Width;
            int y = screenHeight - 75;
            int size = 100;
            // Calculate spacing between rocks
            int spacing = screenWidth / (r + 1);
            for (int i = 0; i < r; i++) {
                int x = (i + 1) * spacing - size / 2;
                rocks.Add(new Rocks(x, y, size));
            }
        }
        // isLanderCollidingWithTerrain(): Checks for collision between the lander and terrain
        public bool IsLanderCollidingWithTerrain(Lander lander) {
            int terrainY = screenHeight - 50; // The constant height of terrain
            return lander.Y + lander.Height >= terrainY;
        }
        // isLanderCollidingWithRocks(): Checks for collision between lander and rocks
        public bool isLanderCollidingWithRocks(Lander lander) {
            foreach(var rock in rocks) {
                if (rock.isCollidingWithLander(lander)) {
                    return true;
                }
            }
            return false; // No collision
        }
    }
}