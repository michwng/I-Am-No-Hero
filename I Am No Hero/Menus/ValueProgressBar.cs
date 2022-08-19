/**       
 * -------------------------------------------------------------------
 * 	   File name: ValueProgressBar.cs
 * 	Project name: I Am No Hero
 * -------------------------------------------------------------------
 *  Author�s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	04/24/2022	
 *            Last Modified:    04/24/2022
 * -------------------------------------------------------------------
 */



namespace I_Am_No_Hero.Menus
{
    /*
     * A custom Progress Bar class.
     * Apparently, C# doesn't let Labels be on top of Progress Bars.
     * So, we make a custom class.
     * 
     * Date Created: 04/24/2022
     * Last Modified: 04/24/2022
     */
    //Thanks to:
    //https://social.msdn.microsoft.com/Forums/vstudio/en-US/5d3eee65-730b-488f-a858-a341b8d61714/progressbar-with-percentage-label
    public class ValueProgressBar : ProgressBar
    {
        public string StringValue { get; set; }

        public ValueProgressBar() 
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ProgressBarRenderer.DrawHorizontalBar(e.Graphics, new Rectangle(0, 0, this.Width, this.Height));
            int ProgressWidth = (this.Width / (this.Maximum - this.Minimum) * Value);
            ProgressBarRenderer.DrawHorizontalChunks(e.Graphics, new Rectangle(0, 0, ProgressWidth, this.Height));
            int ProgressPercent = (this.Maximum - this.Minimum) / 100;
            ProgressPercent = ProgressPercent * Value;

            //TextBoxRenderer.DrawTextBox(e.Graphics, new Rectangle(0, 0, Width, Height), System.Windows.Forms.VisualStyles.TextBoxState.Normal);
            //TextRenderer.DrawText(e.Graphics, StringValue, SystemFonts.DefaultFont, new Rectangle(0, 0, Width, Height), Color.Black, TextFormatFlags.TextBoxControl);

            //Thanks to:
            //https://stackoverflow.com/questions/7991/center-text-output-from-graphics-drawstring
            StringFormat format = new();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            e.Graphics.DrawString(StringValue, SystemFonts.MessageBoxFont, Brushes.Black, ClientRectangle, format);
        }
    }



}