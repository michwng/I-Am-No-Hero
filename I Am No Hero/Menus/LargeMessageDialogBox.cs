/**       
 * -------------------------------------------------------------------
 * 	   File name: LargeMessageDialogBox.cs
 * 	Project name: I Am No Hero
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	03/17/2022	
 *            Last Modified:    03/17/2022
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
    public partial class LargeMessageDialogBox : Form
    { 
        /**
         * The base constructor for the LargeMessageDialogBox class.
         * 
         * Date Created: 03/17/2022
         * @param object sender, EventArgs e
         */
        public LargeMessageDialogBox()
        {
            InitializeComponent();
        }


        /// <summary>
        /// The primary constructor for LargeMessageDialogBox.
        /// Accepts a string parameter and sets the label text
        /// equal to the value in the parameter.
        /// </summary>
        /// <param name="labelText"></param>
        public LargeMessageDialogBox(string? labelText)
        {
            InitializeComponent();
            label1.Text = labelText;
            Console.WriteLine(label1.Text);
        }

        /**
         * References the "Ok" Button.
         * This method is called when the user clicks on the "Ok" Button. 
         * (This is an EventHandler Method)
         * 
         * Removes the message when the "Ok" button is pressed.
         * 
         * Date Created: 03/17/2022
         * @param object sender, EventArgs e
         */
        private void Button1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
