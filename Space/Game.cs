using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Space
{
    class Game
    {
        public int Score { get; set; }
        public bool Shooting { get; set; }
        public bool IsGameOver { get; set; }
        public int Count { get; set; }
        public int TotalSum { get; set; }

        public void RemoveAll(PictureBox[] sadInvadersArray, Control.ControlCollection Controls)
        {
            foreach (var i in sadInvadersArray)
            {
                Controls.Remove(i);
            }

            foreach (Control x in Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "bullet" || (string)x.Tag == "sadbullet")
                    {
                        Controls.Remove(x);
                    }
                }
            }
        }

        public void GameSetup(int count, Game game, Timer gameTimer, Enemy enemy, Label TxtScore, Control.ControlCollection Controls, PictureBox[] sadInvadersArray)
        {
            TxtScore.Text = "Score: 0";
            game.Score = 0;
            game.IsGameOver = false;
            enemy.BulletTimer = 300;
            enemy.Speed = 6;
            game.Shooting = false;
            //Form1.MakeInvaders(count);
            gameTimer.Start();
        }

        public void GameOver(string message, Label TxtScore, Timer gameTimer, Game game)
        {
            game.IsGameOver = true;
            gameTimer.Stop();
            TxtScore.Text = "Score: " + game.Score + " " + message;
        }
    }
}
