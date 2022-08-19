/**       
 * -------------------------------------------------------------------
 * 	   File name: TransparentLabel.cs
 * 	Project name: I Am No Hero
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Date Added:	    04/23/2022	
 *            Last Modified:    04/23/2022
 * -------------------------------------------------------------------
 */

using System;
using System.Windows.Forms;

//For some odd reason, we can't set label backgrounds to be transparent.
//They still retain the gray background even when the background color is set to transparent.
//This class fixes the issue. Thanks to:
//https://stackoverflow.com/questions/605920/reasons-for-why-a-winforms-label-does-not-want-to-be-transparent

namespace I_Am_No_Hero.Menus
{
    public class TransparentLabel : Label
    {
        public TransparentLabel()
        {
            this.SetStyle(ControlStyles.Opaque, true);
            //this.SetStyle(ControlStyles.ContainerControl, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams parms = base.CreateParams;
                parms.ExStyle |= 0x20;  // Turn on WS_EX_TRANSPARENT
                return parms;
            }
        }
    }
}