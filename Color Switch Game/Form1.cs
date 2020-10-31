using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Color_Switch_Game
{
    
    public partial class Form1 : Form
    {
        List<Color> colors;
        Random rnd = new Random();
        Random blockPosition = new Random();
        int blockColor = 0;
        int i;
        int speed = 5;
        int score = 0;
        bool gameOver = false;

        public Form1()
        {
            this.KeyPreview = true;
            InitializeComponent();
            resetGame();
            gameTimer.Stop();

        }

        private void playGame(object sender, EventArgs e)
        {
            block1.Top += speed; 
            block2.Top += speed; 
            label1.Text = "Score " + score;

            if (block1.Top > 500)
            { 
                blockColor = rnd.Next(colors.Count);
                block1.BackColor = colors[blockColor]; 
                block1.Top = blockPosition.Next(200, 300) * -1; 
                score++; 
            }

            if (block2.Top > 500)
            {
               
                if (block1.Top > 100)
                {
                    blockColor = rnd.Next(colors.Count); 
                    block2.BackColor = colors[blockColor]; 
                    block2.Top = (block1.Top * 8) * -1;
                    score++; 
                }
            }

            if (player.Bounds.IntersectsWith(block1.Bounds))
            {
                if (player.BackColor != block1.BackColor)
                {
                    scoreList.Items.Add("Scored: " + score + " @" + string.Format(" {0:HH:mm:ss tt}", DateTime.Now));
                    gameTimer.Stop(); 
                    gameOver = true; 
                }
            }

            if (player.Bounds.IntersectsWith(block2.Bounds))
            {
                if (player.BackColor != block2.BackColor)
                {
                    scoreList.Items.Add("Scored: " + score + " @" + string.Format(" {0:HH:mm:ss tt}", DateTime.Now));
                    gameTimer.Stop(); 
                    gameOver = true;
                }
            }

            if (score > 5)
            {
                speed = 6;
            }

            if (score > 10)
            {
                speed = 8;
            }

            block1.Refresh();
            block2.Refresh();
        }

        private void KeyisDown(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                i++; 

                    if (i > colors.Count - 1)
                {
                    i = 0;
                }
                player.BackColor = colors[i];
            }
            if (e.KeyChar == (char)Keys.R || e.KeyChar == char.ToLower((char)Keys.R) && gameOver)
            {
                resetGame();
                gameOver = false; 
            }
        }

        public void resetGame()
        {
            block1.Top = -80;
            block2.Top = -300;

            colors = new List<Color> { System.Drawing.Color.Red, System.Drawing.Color.Yellow, System.Drawing.Color.White, System.Drawing.Color.Purple };

            i = 0;
            gameTimer.Start();
            speed = 5;
            score = 0; 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            resetGame();
             
        }
    }


}
