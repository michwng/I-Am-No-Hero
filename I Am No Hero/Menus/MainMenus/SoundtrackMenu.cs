/**       
 * -------------------------------------------------------------------
 * 	   File name: SoundtrackMenu.cs
 * 	Project name: I Am No Hero
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	03/19/2022	
 *            Last Modified:    03/20/2022
 * -------------------------------------------------------------------
 */

using System.Text;
using System.Media;
using System.Runtime.InteropServices;
using System.Timers;

namespace I_Am_No_Hero
{
    public partial class SoundtrackMenu : Form
    {
        //Big Note: You can add Music Files by putting them in the Soundtrack folder.
        // The Soundtrack folder is located at (starting at the Directory with the solution):
        // I Am No Hero\bin\Soundtrack.
        
        //Note: The application can ONLY play .wav files.

        private string SoundTrackLocation { get; init; }
        private readonly SoundPlayer player = new();
        private readonly List<string> TrackNames = new();
        private readonly List<string> TrackPaths = new();

        private static System.Timers.Timer timer = new(1000);

        /// <summary>
        /// IntSeekTime represents the current second of the song being played.
        /// </summary>
        private int IntSeekTime = 0;

        /// <summary>
        /// CurrentSongLength represents the full length of the song being played.
        /// </summary>
        private int CurrentSongLength = 0;

        /**
         * The base constructor for the SoundtrackMenu class.
         * 
         * Date Created: 03/19/2022
         * Last Modified: 05/21/2022
         */
        public SoundtrackMenu()
        {
            InitializeComponent();

            SoundTrackLocation = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.ToString() + Path.DirectorySeparatorChar + "Soundtrack" + Path.DirectorySeparatorChar;
            Program.StopTrack();

            string[] files = Directory.GetFiles(SoundTrackLocation);

            foreach (string file in files)
            {
                string[] split = file.Split(Path.DirectorySeparatorChar);

                //A bit convoluted, but it basically removes the ".wav" from the file name.
                //string fileName = split[split.Length - 1].Substring(0, split[split.Length - 1].Length - 4);
                

                //The prettier version of the above code, according to the Compiler.
                string fileName = split[^1][..(split[^1].Length - 4)];

                string word = split[^1];
                Console.WriteLine("SL: " + word.Substring(0, word.Length-3));
                if (file.Contains(".wav"))
                {
                    TrackNames.Add(fileName);
                    TrackPaths.Add(file);
                    listBox1.Items.Add(fileName);
                }
                else 
                {
                    Console.WriteLine($"We didn't add {fileName} because it isn't a .WAV file.");
                }

            }
        }

        /**
         * References the "Stop" Button.
         * This method is called when the user clicks on the "Stop" Button. 
         * (This is an EventHandler Method)
         * 
         * Starts a new game.
         * 
         * Date Created: 03/18/2022
         * @param object sender, EventArgs e
         */
        private void Button1_Click(object sender, EventArgs e)
        {
            player.Stop();
            timer.Enabled = false;
        }

        /**
         * References the "Exit" Button.
         * This method is called when the user clicks on the "Exit" Button. 
         * (This is an EventHandler Method)
         * 
         * Starts a new game.
         * 
         * Date Created: 03/18/2022
         * @param object sender, EventArgs e
         */
        private void Button2_Click(object sender, EventArgs e)
        {
            Program.PlaySoundTrack("Echoes");
            this.Dispose();
            this.Enabled = false;

            //Quite important - otherwise the system would throw an exception every second.
            timer.Enabled = false;
        }

        /**
         * References listBox1.
         * This method is called when the user selects a different index in the listBox. 
         * (This is an EventHandler Method)
         * 
         * Plays the selected .wav file.
         * 
         * Date Created: 03/18/2022
         * @param object sender, EventArgs e
         */
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0 && listBox1.SelectedIndex < listBox1.Items.Count)
            {
                player.SoundLocation = TrackPaths[listBox1.SelectedIndex];
                label4.Text = TrackNames[listBox1.SelectedIndex];

                this.Width = 492;

                int songLength = GetSoundLength(TrackPaths[listBox1.SelectedIndex]);

                //For example, a value of 210510 has 210 seconds and 510 milliseconds. we try to get seconds here.
                int seconds = (int)(songLength / 1000);
                //Console.WriteLine("Seconds: " + seconds);

                int minutes = (int)(seconds / 60);
                //Console.WriteLine("Minutes: " + seconds);

                //Not many songs go over an hour, but I added it here just in case.
                int hours = (int)(minutes / 60);
                //Console.WriteLine("Hours: " + seconds);


                //remainder variables.
                string secondsRemainder = (int)(seconds % 60) + "";
                //Console.WriteLine("Seconds Remainder: " + secondsRemainder);
                string minutesRemainder = (int)(minutes % 60) + "";
                //Console.WriteLine("Minutes Remainder: " + minutesRemainder);

                //(In other words, it's 1 digit)
                if ((int)(seconds % 60) < 10) 
                {
                    secondsRemainder = "0" + secondsRemainder;
                }
                if ((int)(minutes % 60) < 10)
                {
                    minutesRemainder = "0" + minutesRemainder;
                }

                string formattedTime;
                if (hours == 0)
                {
                    formattedTime = string.Format("{0}:{1}", minutes, secondsRemainder);
                }
                else 
                {
                    formattedTime = string.Format("{0}:{1}:{2}", hours, minutesRemainder, secondsRemainder);
                }

                CurrentSongLength = seconds;
                Console.WriteLine("Current Song Length: " + CurrentSongLength);

                label7.Text = formattedTime + "";
                label6.Text = "0:00";
                IntSeekTime = 0;

                player.PlayLooping();

                timer.Stop();
                //We reset the timer back to 0 seconds.
                //If we changed a song, the elapsed millseconds could
                //carry over without resetting the timer like this.
                timer = new(1000);

                //We also reset the position of the SliderCircle.
                BeginInvoke(new MethodInvoker(() => Refresh()));


                timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                timer.Enabled = true;
            }
            //Console.WriteLine("T:" + transparentLabel2.Text);
        }


        // This method continually updates label6 every 1000 milliseconds.
        //This is done based on the parameter passed to the timer field on line 40.
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            IntSeekTime++;
            if (IntSeekTime > CurrentSongLength) 
            {
                IntSeekTime = 0;
            }
            int minutes = (int)(IntSeekTime / 60);
            //Console.WriteLine("Minutes: " + seconds);

            //Not many songs go over an hour, but I added it here just in case.
            int hours = (int)(minutes / 60);
            //Console.WriteLine("Hours: " + seconds);


            //remainder variables.
            string secondsRemainder = (int)(IntSeekTime % 60) + "";
            //Console.WriteLine("Seconds Remainder: " + secondsRemainder);
            string minutesRemainder = (int)(minutes % 60) + "";
            //Console.WriteLine("Minutes Remainder: " + minutesRemainder);

            //(In other words, it's 1 digit)
            if ((int)(IntSeekTime % 60) < 10)
            {
                secondsRemainder = "0" + secondsRemainder;
            }
            if ((int)(minutes % 60) < 10)
            {
                minutesRemainder = "0" + minutesRemainder;
            }

            string formattedTime;
            if (hours == 0)
            {
                //We don't need to display hours if it's at 0.
                formattedTime = string.Format("{0}:{1}", minutes, secondsRemainder);
            }
            else
            {
                formattedTime = string.Format("{0}:{1}:{2}", hours, minutesRemainder, secondsRemainder);
            }

            //These 2 statements basically update label6 and update it to reflect the change on the form.
            try
            {
                label6.BeginInvoke(new MethodInvoker(() => label6.Text = formattedTime));
                label6.BeginInvoke(new MethodInvoker(() => label6.Update()));
                BeginInvoke(new MethodInvoker(() => Refresh()));
            }
            catch(Exception ex)
            {
                //Do nothing.
                Console.WriteLine("Error! Description: " + ex.Message);
            }


            //It is done this way because these simpler statements will throw a System.InvalidOperationException exception.
            /*label6.Text = formattedTime;
            label6.Update();*/

            //A System.InvalidOperationException means that a thread tried to access label6, despite not being the thread that created label6.
            //BeginInvoke allows the thread that created label6 to perform the actions instead.
        }

        /// <summary>
        /// This method paints solid bars onto the screen, as well as the borders.
        /// This is because the progress bars and lines are more difficult to work with.
        /// 
        /// <list type="bullet">
        /// <item>Date Created: 05/21/2022</item>
        /// <item>Last Modified: 05/21/2022</item>
        /// </list>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SoundtrackMenu_Paint(object sender, PaintEventArgs e)
        {
            int BARWIDTH = label5.Size.Width;
            int BARHEIGHT = label5.Size.Height;

            Pen grayPen = new(Color.Black);
            Brush grayBrush = new SolidBrush(Color.Black);

            //Drawing the slider for the Soundtrack Menu
            Rectangle SliderBar = new(label5.Location.X, label5.Location.Y, BARWIDTH, BARHEIGHT);
            e.Graphics.FillRectangle(grayBrush, SliderBar);
            e.Graphics.DrawRectangle(grayPen, SliderBar);

            int determineSliderCircleSeekPosition = 0;
            //In other words, is a song selected?
            if (CurrentSongLength != 0 && IntSeekTime != 0)
            {
                //If so, we 
                determineSliderCircleSeekPosition = label5.Location.X + 3 + ((IntSeekTime * (BARWIDTH-15)) / CurrentSongLength);
            }
            else 
            {
                //We set it to the default position.
                determineSliderCircleSeekPosition = label5.Location.X + 3;
            }



            //Drawing the slider circle for the Soundtrack Menu
            //Why are we making a rectangle, you ask?
            //The way the code works, we draw the circle based on the dimensions of the Rectangle created below.
            Rectangle SliderCircle = new(determineSliderCircleSeekPosition, label5.Location.Y - 4, 10, 10);
            e.Graphics.FillEllipse(grayBrush, SliderCircle);
            e.Graphics.DrawEllipse(grayPen, SliderCircle);

            //An alternative method to represent the song's position.
            /*Rectangle SliderLine = new(determineSliderCircleSeekPosition, label5.Location.Y - 4, 3, 10);
            e.Graphics.FillRectangle(grayBrush, SliderLine);
            e.Graphics.DrawRectangle(grayPen, SliderLine);*/


        }

        //Thanks to: https://stackoverflow.com/questions/82319/how-can-i-determine-the-length-i-e-duration-of-a-wav-file-in-c
        [DllImport("winmm.dll")]
        private static extern uint mciSendString(
            string command,
            StringBuilder returnValue,
            int returnLength,
            IntPtr winHandle);

        public static int GetSoundLength(string fileName)
        {
            StringBuilder lengthBuf = new StringBuilder(32);

            mciSendString(string.Format("open \"{0}\" type waveaudio alias wave", fileName), null, 0, IntPtr.Zero);
            mciSendString("status wave length", lengthBuf, lengthBuf.Capacity, IntPtr.Zero);
            mciSendString("close wave", null, 0, IntPtr.Zero);

            int length = 0;
            int.TryParse(lengthBuf.ToString(), out length);

            return length;
        }
    }
}
