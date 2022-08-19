/**       
 * -------------------------------------------------------------------
 * 	   File name: Story.cs
 * 	Project name: I Am No Hero
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	04/02/2022	
 *            Last Modified:    04/02/2022
 * -------------------------------------------------------------------
 */

using System;

namespace I_Am_No_Hero
{
    
    public class Story
    {
        private string selectedStoryLine { get; set;}

        /*
         * The default constructor for the Story class.
         * 
         * Date Created: 04/02/2022
         * Last Modified: 04/02/2022
         */
        public Story()
        {
            selectedStoryLine = "Yilaska";
            selectedStoryLine = "Etna";
            selectedStoryLine = "Elase";
            selectedStoryLine = "Mackley";

        }

        /*
         * The primary constructor of the Story class.
         * Allows the construction of a storyline based on progress.
         * 
         * Date Created: 04/02/2022
         * Last Modified: 04/20/2022
         * -------------------------
         * @param string storyLine
         */
        public Story(string storyLine)
        {
            selectedStoryLine = storyLine;
        }



    }

}






















