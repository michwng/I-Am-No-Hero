using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace I_Am_No_Hero
{
    public partial class Settings : Form
    {
        private string Difficulty { get; set; } = "Easy";

        private int ExpMultiplier { get; set; } = 1;

        public Settings()
        {
            InitializeComponent();
        }

        /**
         * References the "Change Difficulty" Button in the Settings Menu.
         * This method is called when the user clicks on the "Change Difficulty" Button. 
         * (This is an EventHandler Method)
         * 
         * Changes the value of Difficulty.
         * 
         * Date Created: 03/16/2022
         * @param object sender, EventArgs e
         */
        private void Button1_Click(object sender, EventArgs e)
        {
            switch (Difficulty) 
            {
                case "Easy":
                    Difficulty = "Medium";
                    label3.Text = Difficulty;
                    label5.Text = "Enemy attributes are unaffected.";
                    break;
                case "Medium":
                    Difficulty = "Hard";
                    label3.Text = Difficulty;
                    label5.Text = "Enemy attributes have a x1.5 modifier!";
                    break;
                case "Hard":
                    Difficulty = "Easy";
                    label3.Text = Difficulty;
                    label5.Text = "Enemy attributes have a x0.5 Modifier!";
                    break;
                default:
                    break;
            }
        }

        /**
         * References the "Change Experience Multiplier" Button in the Settings Menu.
         * This method is called when the user clicks on the "Credits" Button. 
         * (This is an EventHandler Method)
         * 
         * Changes the value of Experience Multiplier.
         * 
         * Date Created: 03/16/2022
         * @param object sender, EventArgs e
         */
        private void Button2_Click(object sender, EventArgs e)
        {
            switch (ExpMultiplier)
            {
                case 1:
                    ExpMultiplier = 2;
                    label4.Text = "x" + ExpMultiplier;
                    label6.Text = "You will receive double the experience after battles.";
                    break;
                case 2:
                    ExpMultiplier = 3;
                    label4.Text = "x" + ExpMultiplier;
                    label6.Text = "You will receive triple the experience after battles.";
                    break;
                case 3:
                    ExpMultiplier = 1;
                    label4.Text = "x" + ExpMultiplier;
                    label6.Text = "You will receive the normal experience after battles.";
                    break;
                default:
                    break;
            }
        }

        /**
         * References the "Exit Settings" Button in the Settings Menu.
         * This method is called when the user clicks on the "Credits" Button. 
         * (This is an EventHandler Method)
         * 
         * Removes the settings menu and 
         * updates Difficulty and ExpMultiplier in Program.cs.
         * 
         * Date Created: 03/16/2022
         * @param object sender, EventArgs e
         */
        private void Button3_Click(object sender, EventArgs e)
        {
            Program.Difficulty = Difficulty;
            Program.ExpMultiplier = ExpMultiplier;
            Dispose();
        }
    }
}
