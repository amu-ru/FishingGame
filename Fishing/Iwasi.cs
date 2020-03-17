using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing
{
    class Iwasi:Fish
    {
        private bool sleep;

        public Iwasi(int positionX, int positionY, int speed, int distanceX, System.Windows.Forms.PictureBox picture)
        : base(positionX, positionY, speed, distanceX, picture)
        {

        }
        public void Sleep()
        {
            sleep = true;
        }
        public void Wake()
        {
            sleep = false;
        }

        public override int Eat(int score, System.Windows.Forms.PictureBox esa)
        {
            if (score <=3 && sleep==false)
            {
                return score=base.Eat(score, esa);
            }
            else
                return score = 0;
        }

    }
}
