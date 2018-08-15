
namespace Game
{
    public static class Consts
    {
        // Forms
        public const int FORM_WIDTH = 800;
        public const int FORM_HEIGHT = 600;
        public const int MARGIN_TOP = 80;
        public const int BUTTON_WIDTH = 300;
        public const int BUTTON_HEIGHT = 100;
        public const int BUTTON_GAP = 50;
        public const int LEADERBOARDS_GAP = 80;
        // Player
        public const int PLAYER_WIDTH = 40;
        public const int PLAYER_HEIGHT = 20;
        public const int PLAYER_Y = 570;
        public const int PLAYER_BOTTOM_EDGE = PLAYER_Y + PLAYER_HEIGHT;
        // Aliens
        public const int ALIEN_WIDTH = 40;
        public const int ALIEN_HEIGHT = 20;
        public const int ALIEN_LIGHT_HP = 1;
        public const int ALEIN_TROOPER_HP = 2;
        public const int ALIEN_HEAVY_HP = 3;
        // Level Grid
        public const int GRID_COLUMNS = 16;
        public const int GRID_ROWS = 20;
        // Shots
        public const int MISSILE_WIDTH = 3;
        public const int MISSILE_HEIGHT = 12;

        public const int GAP = 5;
        public const int LABEL_OFF = 50;

        // Space Ships Default Values
        public static class Destroyer
        {
            public const int SPEED = 4;
            public const int MISSILE_SPEED = 15;

            public const string NAME = "DESTROYER";
        }

        public static class Scout
        {
            public const int SPEED = 5;
            public const int MISSILE_SPEED = 12;

            public const string NAME = "SCOUT";
        }

        public static class Tank
        {
            public const int SPEED = 3;
            public const int MISSILE_SPEED = 18;

            public const string NAME = "TANK";
        }

    }
}
