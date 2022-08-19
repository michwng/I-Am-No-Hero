/**       
 * -------------------------------------------------------------------
 * 	   File name: LoadGameMenu.cs
 * 	Project name: I Am No Hero
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	03/19/2022	
 *            Last Modified:    03/19/2022
 * -------------------------------------------------------------------
 */

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
    public partial class LoadGameMenu : Form
    {
        Boolean File1Found { get; init; } = false;
        Boolean File2Found { get; init; } = false;
        string SaveFileDirectory { get; init; }

        /*
         * The public constructor for the LoadGameMenu.
         * 
         * Date Created: 03/19/2022
         */
        public LoadGameMenu()
        {
            InitializeComponent();

            
            SaveFileDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.ToString() + Path.DirectorySeparatorChar + "Save Files" + Path.DirectorySeparatorChar;

            //Determine if the save files are found in the "Save Files" folder in the bin.
            if (File.Exists(SaveFileDirectory + "File 1.txt"))
            {
                //Instead of Button 1 saying "File 1 (?)", it becomes "File 1".
                button1.Text = "File 1";
                File1Found = true;
            }
            if (File.Exists(SaveFileDirectory + "File 2.txt"))
            {
                //Instead of Button 2 saying "File 2 (?)", it becomes "File 2".
                button2.Text = "File 2";
                File1Found = true;
            }
        }

        /**
         * References the "File 1" Button in the LoadGameMenu.
         * This method is called when the user clicks on the "File 1" Button. 
         * (This is an EventHandler Method)
         * 
         * Tells the Program to load File 1.txt if it exists.
         * Otherwise, prints an error message.
         * 
         * Date Created: 03/19/2022
         * @param object sender, EventArgs e
         */
        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
            if (File1Found)
                Program.LoadFile(1);
            else
            {
                MessageDialog msgDialog = new();
                msgDialog.label1.Text = "File 1 Not Found.\nPlease start a New Game!";
                msgDialog.ShowDialog();
            }

        }


        /**
         * References the "File 2" Button in the LoadGameMenu.
         * This method is called when the user clicks on the "File 2" Button. 
         * (This is an EventHandler Method)
         * 
         * Tells the Program to load File 2.txt if it exists.
         * Otherwise, prints an error message.
         * 
         * Date Created: 03/19/2022
         * @param object sender, EventArgs e
         */
        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
            if (File2Found)
                Program.LoadFile(2);
            else
            {
                MessageDialog msgDialog = new();
                msgDialog.label1.Text = "File 2 Not Found.\nPlease start a New Game!";
                msgDialog.ShowDialog();
            }
        }
    }
}
