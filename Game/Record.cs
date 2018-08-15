using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Record
    {
        private int score;

        private string spaceshipName;

        public int Score
        {
            get
            {
                return this.score;
            }
            set
            {
                this.score = value;
            }
        }

        public string SpaceshipName
        {
            get
            {
                return this.spaceshipName;
            }
            set
            {
                this.spaceshipName = value;
            }
        }

        public Record(int score, string spaceshipName)
        {
            this.score = score;
            this.spaceshipName = spaceshipName;
        }
    }
}
