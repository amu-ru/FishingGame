using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fishing
{
    public partial class FormFish : Form
    {
        int count;
        private Utubo utubo;
        private Anko anko;
        private Iwasi iwasi;
        private int UtuboSpeed = 10;
        private const int AnkoSpeed = 10;
        private const int IwasiSpeed = 20;
        private int score = 0;


        private void FormFish_Load(object sender, EventArgs e)
        {

            int formSizeW = this.ClientSize.Width;


            //ウツボのインスタンス
            int x = pictureBoxUtubo.Location.X;
            int y = pictureBoxUtubo.Location.Y;
            int distanceW = formSizeW - pictureBoxUtubo.Size.Width;
            utubo = new Utubo(x, y, UtuboSpeed, distanceW, pictureBoxUtubo);

            //アンコウインスタンス
            x = pictureBoxAnko.Location.X;
            y = pictureBoxAnko.Location.Y;
            distanceW = formSizeW - pictureBoxAnko.Size.Width;
            anko = new Anko(x, y, AnkoSpeed, distanceW, pictureBoxAnko);

            //イワシインスタンス
            x = pictureBoxIwasi.Location.X;
            y = pictureBoxIwasi.Location.Y;
            distanceW = formSizeW - pictureBoxIwasi.Size.Width;
            iwasi = new Iwasi(x, y, IwasiSpeed, distanceW, pictureBoxIwasi);




            labelTime.Text = "制限時間:60秒";
            labelScore.Text = "0";
            
        }

        public FormFish()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            SwimFish();
            count = 600;
           labelScore.Text = "0";

        }

        private void SwimFish()
        {

            //位置を進める
            bool fs1 = utubo.Swim(out int x1, out int y1);
            bool fs2 = anko.Swim(out int x2, out int y2);
            bool fs3 = iwasi.Swim(out int x3, out int y3);
            utubo.PictureMove(x1, y1);
            anko.PictureMove(x2, y2);
            iwasi.PictureMove(x3, y3);
           

        }

        //制限時間
        private void timer1_Tick(object sender, EventArgs e)
        {
            SwimFish();

            if (count > 0)
            {
                count--;
                labelTime.Text =$"残り時間：{count/10}秒";
            }
            if (count == 0)
            {
                timer1.Stop();
                if (score != 0)
                    labelTime.Text = "ゲーム終了";
            }

            //昼と夜
            if (count <= 500 && 450 <= count || count <= 350 && 300 <= count || count <= 200 && 150 <= count || 0 < count && count <= 50)
            {
                this.BackColor = Color.Navy;
                utubo.Sleep();
                iwasi.Sleep();
            }
            else
            {
                this.BackColor = Color.DeepSkyBlue;
                utubo.Wake();
                iwasi.Wake();
            }

        }

        private void FormFish_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '1' && e.KeyChar <= '9')
            {
               score += utubo.Eat(int.Parse(e.KeyChar.ToString()), pictureBoxUtuboEsa);
               score += iwasi.Eat(int.Parse(e.KeyChar.ToString()), pictureBoxIwasiEsa);
               score += anko.Eat(int.Parse(e.KeyChar.ToString()), pictureBoxAnkoEsa);

            }
            labelScore.Text = $"{score}";
        }




    }
}
