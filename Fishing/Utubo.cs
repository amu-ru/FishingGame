using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing
{
    class Utubo:Fish
    {
        private bool sleep;
        private int saveSpeed;
        public Utubo(int positionX, int positionY, int speed, int distanceX, System.Windows.Forms.PictureBox picture)
       : base(positionX, positionY, speed, distanceX, picture)
        {
            saveSpeed = speed;
            sleep = false;
        }

        public void Sleep()
        {
            sleep = true;
            Speed = 0;
        }
        public void Wake()
        {
            sleep = false;
            Speed = saveSpeed;
        }

        public override int Eat(int score, System.Windows.Forms.PictureBox esa)
        {
            if (score >= 7 && sleep == false)
            {
                return score = base.Eat(score, esa);
            }
            else
                return score = 0;
        }

    }
}
