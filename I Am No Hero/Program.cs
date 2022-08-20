/**       
 * -------------------------------------------------------------------
 * 	   File name: Program.cs
 * 	Project name: I Am No Hero
 * -------------------------------------------------------------------
 *  Author�s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	03/17/2022	
 *            Last Modified:    03/20/2022
 * -------------------------------------------------------------------
 */

using System.Media;
using System.Diagnostics;

namespace I_Am_No_Hero
{
    internal static class Program
    {
        public static string FileRoot { get; } = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.ToString() + Path.DirectorySeparatorChar;
        private static string? FileLoad { get; set; }
        internal static string Difficulty { get; set; } = "Easy";
        internal static int ExpMultiplier { get; set; } = 1;

        //Player will be used for background music.
        private static readonly SoundPlayer Player = new();


        /**
         * The Main method. Starts and Runs the game.
         * 
         * Date Created: 03/18/2022
         */
        [System.STAThread]
        public static void Main()
        {
            ApplicationConfiguration.Initialize();

            //Application.Run(new BattleMenu());
            //This should take the following path, starting from the folder where the solution is located at: 
            //I Am No Hero\bin\Soundtrack\Echoes.wav
            //Debug.WriteLine(FileRoot + "Soundtrack" + Path.DirectorySeparatorChar + "Echoes.wav");


            PlaySoundTrack("Symphony Of Specters - Fight For Your Freedom");
            Application.Run(new MainMenu());
        
            //TODO Knight captured by the Evil Lord, ransom exchange for princess. Princess Yilaska sets out to rescue him.
            //TODO Elase leads a revolution to liberate Cyronia from the corrupt government.
        }

        /**
         * Plays a music file in the "Soundtrack" folder.
         * 
         * Date Created: 03/15/2022
         * Last Modified: 04/01/2022
         * 
         * @param string trackName, Boolean loopTrack
         * Correct usage example: playSoundTrack("Echoes");
         * Example 2: playSoundTrack("Echoes", False);
         */
        public static void PlaySoundTrack(string trackName, Boolean loopTrack = true) 
        {
            //The question marks remove the warning CS8602 - "Dereference of a possibly null value". 
            //The question marks let the compiler know that we are fine if the value is null.
            //Console.WriteLine(FileRoot + "Soundtrack" + Path.DirectorySeparatorChar + trackName + ".wav");
            Player.SoundLocation = FileRoot + "Soundtrack" + Path.DirectorySeparatorChar + trackName  + ".wav";

            if (loopTrack)
                Player.PlayLooping();
            else
                Player.Play();
        }

        /**
         * Stops a music file that is currently playing.
         * 
         * Date Created: 03/15/2022
         * 
         * @param string trackName, Boolean loopTrack
         * Correct usage example: playSoundTrack("Echoes");
         * Example 2: playSoundTrack("Echoes", False);
         */
        public static void StopTrack()
        {
            Player.Stop();
        }


        /**
         * Loads a text file in the "Save Files" folder.
         * 
         * Date Created: 03/15/2022
         * Last Modified: 04/01/2022
         * 
         * @param string trackName, Boolean loopTrack
         * Correct usage example: playSoundTrack("Echoes");
         * Example 2: playSoundTrack("Echoes", False);
         */
        public static void LoadFile(int fileNum) 
        {
            FileLoad = FileRoot + "Save Files" + Path.DirectorySeparatorChar + "File " + fileNum + ".txt";

            Debug.WriteLine("Loaded File " + fileNum);

            string[] fileLines;
            try
            {
                fileLines = File.ReadAllLines(FileLoad);
            }
            catch (FileNotFoundException) 
            {
                //Very rare chance to happen.
                //May happen if the Save File is deleted after entering the LoadGameMenu,
                //but before loading a game.
                MessageDialog msgDialog = new();
                msgDialog.label1.Text = $"Oops! File {fileNum} couldn't be found!\nPlease start a New Game!";
                msgDialog.ShowDialog();
                return;
            }

            //TODO code loadfile after savegame.

        }
    }
}