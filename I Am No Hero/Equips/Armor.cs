/**       
 * -------------------------------------------------------------------
 * 	   File name: Armor.cs
 * 	Project name: I Am No Hero
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	04/20/2022	
 *            Last Modified:    04/20/2022
 * -------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_Am_No_Hero
{
    internal class Armor
    {
        internal int PhysicalDefense { get; set; }
        internal int MagicalDefense { get; set; }
        internal int Weight { get; set; }
        internal string Name { get; set; }
        internal string Description { get; set; }
        internal BodyPart Part { get; set; }

        /*
         * The base constructor of the Armor class.
         * Automatically assigns values to the armor.
         * 
         * Date Created: 3/20/2022
         */
        public Armor() 
        {
            PhysicalDefense = 0;
            MagicalDefense = 0;
            Weight = 0;
            Name = "Base Armor";
            Description = "Basic Armor.";
            Part = BodyPart.Head;
        }

        /*
         * The primary constructor of the armor class.
         * Armor is created based upon the constructor.
         * 
         * Date Created: 3/20/2022
         * @param int pdef, mdef, weight
         * @param string name, description
         * @param BodyPart part
         * 
         * Correct Usage Examples: 
         *  1. Armor armor = new Armor(5, 10, 0, "Scout's Helmet", "A lightweight cap that allows for quick perception.", BodyPart.Head);
         *  2. Armor armor = new Armor(45, 0, 0, "Heavy Knight's Leggings", "A metal legging designed to withstand lethal blows.", BodyPart.Legs);
         */
        public Armor(int pdef, int mdef, int weight, string name, string description, BodyPart part)
        {
            PhysicalDefense = pdef;
            MagicalDefense = mdef;
            Weight = weight;
            Name = name;
            Description = description;
            Part = part;
        }


        /*
         * Returns a formatted string containing the armor's 
         * PhysicalDEFense (PDEF), MagicalDEFense (MDEF), Weight, and its Description.
         * 
         * @return sb.ToString();
         */
        public override string ToString() 
        {
            StringBuilder sb = new();
            sb.Append(Name + " (" + PhysicalDefense + "PDEF / " + MagicalDefense + "MDEF / " + Weight + "lbs.)\n");
            sb.Append(Description);

            return sb.ToString();
        }
    }
}
