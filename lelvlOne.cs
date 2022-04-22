using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game3
{
    
    public partial class lelvlOne : Form
    {
        
        
        bool goRight, goLeft, jumping, isGameOver;

        int jumpSpeed;
        int force;
        int score = 0;
        int playerSpeed = 7;

        int horizontalSpeed = 5;
        int verticalSpeed = 3;

        int enemyOneSpeed = 5;
        int enemyTwoSpeed = 3;
        int enemyThreeSpeed = 4;

        public lelvlOne()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void MainGameTimer(object sender, EventArgs e)
        {
            txtScore.Text = "Score:" + score;
            player.Top += jumpSpeed;
            
            if (goLeft == true)           
                player.Left -= playerSpeed;         
            if (goRight == true)           
                player.Left += playerSpeed;          

            if (jumping == true && force < 0)
                jumping = false;           

            if (jumping == true)
            {
                jumpSpeed = -8;
                force -= 1;
            }
            else 
                jumpSpeed = 10;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {


                    if ((string)x.Tag == "platform")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            force = 8;
                            player.Top = x.Top - player.Height;


                            if ((string)x.Name == "horizontalPlatform" && goLeft == false || (string)x.Name == "horizontalPlatform" && goRight == false)
                            {
                                player.Left -= horizontalSpeed;
                            }


                        }

                        x.BringToFront();

                    }

                    if ((string)x.Tag == "coin")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            score++;
                        }
                    }


                    if ((string)x.Tag == "enemy")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameTimer.Stop();
                            isGameOver = true;
                            txtScore.Text = "Score: " + score + Environment.NewLine + "GAME OVER!";
                        }
                    }

                }
            }

            if (player.Bounds.IntersectsWith(endOfMission.Bounds))
            {
                gameTimer.Stop();
                isGameOver = true;
                txtScore.Text = "Score: " + score + Environment.NewLine + "You win!";
            }
            
            enemyOne.Left -= enemyOneSpeed;
            if (enemyOne.Left < pictureBox3.Left || enemyOne.Left + enemyOne.Width > pictureBox3.Left + pictureBox3.Width)
            {
                enemyOneSpeed = -enemyOneSpeed;
            }

            enemyTwo.Left += enemyTwoSpeed;
            if (enemyTwo.Left < pictureBox1.Left || enemyTwo.Left + enemyTwo.Width > pictureBox1.Left + pictureBox1.Width)
            {
                enemyTwoSpeed = -enemyTwoSpeed;
            }

            enemyThree.Left -= enemyThreeSpeed;
            if (enemyThree.Left < pictureBox5.Left || enemyThree.Left + enemyThree.Width > pictureBox5.Left + pictureBox5.Width)
            {
                enemyThreeSpeed = -enemyThreeSpeed;
            }


            horizontalPlatform.Left -= horizontalSpeed;
            if (horizontalPlatform.Left < 0 || horizontalPlatform.Left + horizontalPlatform.Width > this.ClientSize.Width)
            {
                horizontalSpeed = -horizontalSpeed;
            }

            verticalPlatform.Top += verticalSpeed;
            if (verticalPlatform.Top < 149 || verticalPlatform.Top > 334)
            {
                verticalSpeed = -verticalSpeed;
            }

            if (player.Top + player.Height > this.ClientSize.Height + 60)
            {
                gameTimer.Stop();
                isGameOver = true;
                txtScore.Text = "Score:" + score + Environment.NewLine + "You fell :(";
            }

            
            
        }

       

        private void RestartGame()
        {
            jumping = false;
            goLeft = false;
            goRight = false;
            isGameOver = false;
            score = 0;

            txtScore.Text = "Score:" + score;
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
            }

            player.Left = 318;
            player.Top = 599;

            enemyOne.Left = 168;
            enemyTwo.Left = 615;
            enemyThree.Left = 613;

            horizontalPlatform.Left = 258;
            verticalPlatform.Top = 260;

            gameTimer.Start();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.D)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.D)
            {
                goRight = false;
            }
            if (jumping == true)
            {
                jumping = false;
            }

            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                RestartGame();
            }
        }
    }
}
