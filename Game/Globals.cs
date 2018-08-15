using Game.Spaceships;
using System.Collections.Generic;
using System.Drawing;

namespace Game
{
    public static class Globals
    {
        public static int selectedLevel = 0;
        public static int selectedSpaceship = 0;
        public static int missileY = Consts.PLAYER_Y - Consts.MISSILE_HEIGHT;

        public static string message;

        public static bool missileFired = false;

        public static Font defaultFont = new Font("Tahoma", 20);

        public static List<int[]> allLevels = new List<int[]>()
        {
            Levels.levelZero,
            Levels.levelOne,
            Levels.levelTwo,
            Levels.levelThree,
            Levels.levelFour,
        };

        public static List<Spaceship> spaceships = new List<Spaceship>()
        {
            new Destroyer(),
            new Scout(),
            new Tank(),
        };

        public static List<Record> allRecords = new List<Record>();
    }
}
