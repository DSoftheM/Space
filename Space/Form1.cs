using System;
using System.Drawing;
using System.Windows.Forms;

namespace Space
{
    public partial class Form1 : Form
    {
        PictureBox[] sadInvadersArray;
        Game game = new Game();
        Player player = new Player();
        Enemy enemy = new Enemy();
        GameController gameController = new GameController();

        public Form1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();
            game.GameSetup(1, game, gameTimer, enemy, TxtScore, Controls, sadInvadersArray);
            MakeInvaders(++game.Count);
        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            TxtScore.Text = "Score: " + game.Score;
            totalScore.Text = "Total score: " + game.TotalSum;
            Invalidate();
            if (player.goLeft)
            {
                plant.Left -= player.Speed;
            }
            if (player.goRight)
            {
                plant.Left += player.Speed;
            }
            enemy.BulletTimer -= 2; //12
            if (enemy.BulletTimer < 1)
            {
                enemy.BulletTimer = 300;
                makeBullet("sadBullet");
            }

            foreach (Control x in Controls)
            {
                if (x is PictureBox && (string)x.Tag == "sadInvaders")
                {
                    x.Left += enemy.Speed;
                    if (x.Left > 730)
                    {
                        x.Top += 65;
                        x.Left = -80;
                    }

                    if (x.Bounds.IntersectsWith(plant.Bounds))
                        game.GameOver("☹ Game Over! ☹", TxtScore, gameTimer, game);

                    foreach (Control y in Controls)
                    {
                        if (y is PictureBox && (string)y.Tag == "bullet")
                        {
                            if (y.Bounds.IntersectsWith(x.Bounds))
                            {
                                Controls.Remove(x);
                                Controls.Remove(y);
                                game.Score += 1;
                                game.TotalSum += 1;
                                game.Shooting = false;
                            }
                        }
                    }
                }

                if (x is PictureBox && (string)x.Tag == "bullet")
                {
                    x.Top -= 20;
                    if (x.Top < 15)
                    {
                        Controls.Remove(x);
                        game.Shooting = false;
                    }
                }

                if (x is PictureBox && (string)x.Tag == "sadBullet")
                {
                    x.Top += 12; //Enemy bullet speed
                    if (x.Top > 620) // Player height
                    {
                        Controls.Remove(x);
                    }
                    if (x.Bounds.IntersectsWith(plant.Bounds))
                    {
                        Controls.Remove(x);
                        game.GameOver("☹ Game Over! ☹", TxtScore, gameTimer, game);
                        game.TotalSum = 0;
                    }
                }
            }
            if (game.Score > 2 && game.Score % 3 == 0)
            {
                enemy.BulletTimer -= 12;
                enemy.Speed = game.Score / 3;
            }

            if (game.Score == sadInvadersArray.Length)
            {
                game.GameSetup(++game.Count, game, gameTimer, enemy, TxtScore, Controls, sadInvadersArray);
                MakeInvaders(game.Count);
                game.Count++;
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            gameController.PressKey(player, e);
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                player.goLeft = false;

            if (e.KeyCode == Keys.Right)
                player.goRight = false;

            if (e.KeyCode == Keys.Space && game.Shooting == false)
            {
                game.Shooting = true;
                makeBullet("bullet");
            }
            if (e.KeyCode == Keys.Enter && game.IsGameOver == true)
            {
                game.RemoveAll(sadInvadersArray, Controls);
                game.GameSetup(1, game, gameTimer, enemy, TxtScore, Controls, sadInvadersArray);
            }
        }

        public void MakeInvaders(int count)
        {
            sadInvadersArray = new PictureBox[count];
            int left = 0;
            for (var i = 0; i < sadInvadersArray.Length; i++)
            {
                sadInvadersArray[i] = new PictureBox();
                sadInvadersArray[i].Size = new Size(60, 50);
                sadInvadersArray[i].Image = Properties.Resources.invader;
                sadInvadersArray[i].Top = 5;
                sadInvadersArray[i].Tag = "sadInvaders";
                sadInvadersArray[i].Left = left;
                //sadInvadersArray[i].BackColor = Color.Transparent;
                sadInvadersArray[i].SizeMode = PictureBoxSizeMode.StretchImage;
                Controls.Add(sadInvadersArray[i]);
                left = left - 80;
            }
        }


        //private void GameSetup(int count)
        //{
        //    TxtScore.Text = "Score: 0";
        //    game.Score = 0;
        //    game.IsGameOver = false;
        //    enemy.BulletTimer = 300;
        //    enemy.Speed = 6;
        //    game.Shooting = false;
        //    MakeInvaders(count);
        //    gameTimer.Start();
        //}

        //private void GameOver(string message)
        //{
        //    game.IsGameOver = true;
        //    gameTimer.Stop();
        //    TxtScore.Text = "Score: " + game.Score + " " + message;
        //}

        //private void RemoveAll()
        //{
        //    foreach (var i in sadInvadersArray)
        //    {
        //        Controls.Remove(i);
        //    }

        //    foreach (Control x in Controls)
        //    {
        //        if (x is PictureBox)
        //        {
        //            if ((string)x.Tag == "bullet" || (string)x.Tag == "sadbullet")
        //            {
        //                Controls.Remove(x);
        //            }
        //        }
        //    }
        //}

        private void makeBullet(string bulletTag)
        {
            var bullet = new PictureBox();

            bullet.Image = Properties.Resources.bullet4;
            bullet.Size = new Size(64, 57); //image size
            bullet.Tag = bulletTag;
            bullet.Left = plant.Left + plant.Width / 2;
            //bullet.BackColor = Color.Transparent;
            if ((string)bullet.Tag == "bullet")
            {
                bullet.Top = plant.Top - 20;
            }
            else if ((string)bullet.Tag == "sadBullet")
            {
                bullet.Top = -100;
            }
            Controls.Add(bullet);
            bullet.BringToFront();
        }

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
