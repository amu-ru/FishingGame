using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing
{
    class Fish
    {
        private System.Windows.Forms.PictureBox picture;

        //コンストラクター
        public Fish(int positionX,int positionY,int speed,int distanceX, System.Windows.Forms.PictureBox picture)
        {
            PositionX = positionX;
            PositionY = positionY;
            Speed = speed;
            DistanceX = distanceX;
            this.picture = picture;
        }

        //プロパティ
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Speed { get; set; }
        public int DistanceX { get; set; }

        //進む
        //true(前進
        public bool Swim(out int x,out int y)
        {
            bool fs = true;

            PositionX += Speed; //位置を進める

            if (PositionX > DistanceX)
            {
                PositionX = DistanceX;
                fs= false;
                PositionX = -picture.Size.Width;
            }

            x = PositionX;
            y = PositionY;
            if (fs == false)//左に戻る
                fs = true;
            return fs;

        }

        public virtual int Eat(int score, System.Windows.Forms.PictureBox esa)
        {
            int fishX = picture.Location.X + picture.Width;
            int esaX = esa.Location.X + esa.Width;

            if (esaX <= fishX && fishX <= esaX + 30)
            {
                PositionX = -picture.Size.Width * 2;
                PictureMove(PositionX, PositionY);
            }
            else
                score = 0;

            return score;
        }

            //絵の移動
            public void PictureMove(int x,int y)
        {
            picture.Location = new System.Drawing.Point(x, y);
        }


    }
}
