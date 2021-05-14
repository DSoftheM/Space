using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Space
{
    class GameController
    {
        public void PressKey(Player player, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                player.goLeft = true;

            if (e.KeyCode == Keys.Right)
                player.goRight = true;
        }
    }
}
