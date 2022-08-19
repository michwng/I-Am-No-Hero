/**       
 * -------------------------------------------------------------------
 * 	   File name: MainMenu.cs
 * 	Project name: I Am No Hero
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	03/19/2022	
 *            Last Modified:    03/19/2022
 * -------------------------------------------------------------------
 */

namespace I_Am_No_Hero
{
    public partial class MainMenu : Form
    {
        //internal static MessageDialog? output;

        /**
         * The base constructor for the CreditsMenu class.
         * 
         * Date Created: 03/19/2022
         */
        public MainMenu()
        {
            InitializeComponent();
        }

        /**
         * References the "New Game" Button.
         * This method is called when the user clicks on the "New Game" Button. 
         * (This is an EventHandler Method)
         * 
         * Starts a new game.
         * 
         * Date Created: 03/18/2022
         * @param object sender, EventArgs e
         */
        private void Button1_Click(object sender, EventArgs e)
        {
            //TODO New Game
            Hide();
            Battle battle = new Battle(new Ally("Revia"), new Enemy());
            Show();
        }

        /**
         * References the "Load Game" Button.
         * This method is called when the user clicks on the "Load Game" Button. 
         * (This is an EventHandler Method)
         * 
         * Loads a previously saved game.
         * 
         * Date Created: 03/16/2022
         * @param object sender, EventArgs e
         */
        private void Button2_Click(object sender, EventArgs e)
        {
            LoadGameMenu lgm = new();
            lgm.ShowDialog();
            lgm.Dispose();
        }

        /**
         * References the "Settings" Button.
         * This method is called when the user clicks on the "Settings" Button. 
         * (This is an EventHandler Method)
         * 
         * Opens up the settings menu.
         * 
         * Date Created: 03/16/2022
         * @param object sender, EventArgs e
         */
        private void Button3_Click(object sender, EventArgs e)
        {
            //TODO Settings Menu
            Settings settings = new();
            settings.ShowDialog();
            settings.Dispose();
        }

        /**
         * References the "Credits" Button.
         * This method is called when the user clicks on the "Credits" Button. 
         * (This is an EventHandler Method)
         * 
         * Displays the credits.
         * 
         * Date Created: 03/16/2022
         * @param object sender, EventArgs e
         */
        private void Button4_Click(object sender, EventArgs e)
        {
            //TODO Credits Menu
            CreditsMenu creditsMenu = new();
            creditsMenu.ShowDialog();
            creditsMenu.Dispose();
        }

        /**
         * References the "Soundtrack" Button.
         * This method is called when the user clicks on the "Soundtrack" Button. 
         * (This is an EventHandler Method)
         * 
         * Allows the user to listen to the game's soundtrack!
         * 
         * Date Created: 03/16/2022
         * @param object sender, EventArgs e
         */
        private void Button5_Click(object sender, EventArgs e)
        {
            //TODO Soundtrack Menu
            SoundtrackMenu soundtrackMenu = new();
            try
            {
                soundtrackMenu.ShowDialog();
                soundtrackMenu.Close();
            }
            catch (InvalidOperationException) 
            {
                //There is a chance that the file selected is an MP3 File.
                //In this case, we let the user know that we cannot play the file.
                MessageDialog msgDialog = new();
                msgDialog.label1.Text = "Oops! We can't play MP3 Files!";
                msgDialog.ShowDialog();
            }


        }

        /**
         * This method is called right before the form has completed loading. 
         * 
         * Date Created: 03/16/2022
         * @param object sender, EventArgs e
         */
        private void Form1_Load(object sender, EventArgs e)
        {
            //output = new MessageDialog();
            //output.label1.Text = "The Application has been Loaded!";
            //output.ShowDialog();

            //System.Windows.Forms.MessageBox.Show("The Application has been Loaded!");
        }
    }
}