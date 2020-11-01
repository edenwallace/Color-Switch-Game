using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Color_Switch_Game.Properties;

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
        int difficulty = 1;
        
public Form1()
        {

            this.KeyPreview = true; 
            InitializeComponent();

            playerComboBox.Items.AddRange(Resources.names.Split(new[] { Environment.NewLine }, StringSplitOptions.None));
            scoreList.Items.AddRange(Resources.scores.Split(new[] { Environment.NewLine }, StringSplitOptions.None));

            resetGame();
            gameTimer.Stop();

        }

        private void playGame(object sender, EventArgs e)
        {
            if (speedComboBox.Text.Contains("Slow")) {
                difficulty = 1;
                speed = 5;
            }
            else if (speedComboBox.Text.Contains("Medium")) {
                difficulty = 2;
                speed = 7;
            }
            else if (speedComboBox.Text.Contains("Fast")) {
                difficulty = 9;
            }

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
                    //scoreList.Items.Add("" + score + " @" + string.Format(" {0:HH:mm:ss tt}", DateTime.Now));
                    scoreList.Items.Add("" + score + " - " + playerComboBox.Text);
                    gameTimer.Stop(); 
                    gameOver = true; 
                }
            }

            if (player.Bounds.IntersectsWith(block2.Bounds))
            {
                if (player.BackColor != block2.BackColor)
                {
                    //scoreList.Items.Add("Scored: " + score + " @" + string.Format(" {0:HH:mm:ss tt}", DateTime.Now));
                    scoreList.Items.Add("" + score + " - " + playerComboBox.Text);
                    gameTimer.Stop(); 
                    gameOver = true;
                }
            }

            if (score > 5 && difficulty == 1)
            {
                speed = 6;
            }

            if (score > 10 && difficulty == 1)
            {
                speed = 8;
            }

            if (score > 5 && difficulty == 2)
            {
                speed = 8;
            }

            if (score > 10 && difficulty == 2)
            {
                speed = 10;
            }

            if (score > 5 && difficulty == 3)
            {
                speed = 10;
            }

            if (score > 10 && difficulty == 3)
            {
                speed = 12;
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
            if ((e.KeyChar == (char)Keys.R || e.KeyChar == char.ToLower((char)Keys.R)) && gameOver)
            {
                resetGame();
                gameOver = false; 
            }
            if (e.KeyChar == (char)Keys.R || e.KeyChar == char.ToLower((char)Keys.R))
            {
                player.BackColor = colors[0];
            }
            if (e.KeyChar == (char)Keys.Y || e.KeyChar == char.ToLower((char)Keys.Y))
            {
                player.BackColor = colors[1];
            }
            if (e.KeyChar == (char)Keys.W || e.KeyChar == char.ToLower((char)Keys.W))
            {
                player.BackColor = colors[2];
            }
            if (e.KeyChar == (char)Keys.P || e.KeyChar == char.ToLower((char)Keys.P))
            {
                player.BackColor = colors[3];
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

        private void button1_Click(object sender, EventArgs e)
        {
            resetGame();
            panel1.Select();
        }

        private void scoreList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void speedComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void playerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gameTimer.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gameTimer.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }


}
