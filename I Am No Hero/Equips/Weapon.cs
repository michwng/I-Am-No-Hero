/**       
 * -------------------------------------------------------------------
 * 	   File name: Weapon.cs
 * 	Project name: I Am No Hero
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	03/20/2022	
 *            Last Modified:    03/20/2022
 * -------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_Am_No_Hero
{
    internal class Weapon
    {
        internal string Name { get; set; }
        internal string Description { get; set; }
        internal int PhysicalDamage { get; set; }
        internal int MagicalDamage { get; set; }
        internal int Accuracy { get; set; }
        internal int Dexterity { get; set; }
        internal int ParryChance { get; set; }
        internal WeaponClassification WeaponClass { get; set; }

        /*
         * The base constructor of the Weapon class.
         * Automatically assigns values to the weapon.
         * 
         * Date Created: 3/20/2022
         */
        public Weapon() 
        {
            Name = "Base Weapon";
            Description = "Basic Weapon.";
            PhysicalDamage = 0;
            MagicalDamage = 0;
            Accuracy = 0;
            Dexterity = 0;
            ParryChance = 0;
        }

        /*
         * The primary constructor of the weapon class.
         * Weapon is created based upon the constructor.
         * 
         * Date Created: 3/20/2022
         * @param string name, description
         * @param int pdmg, mdmg, weight
         * @param WeaponClassification weaponClass
         * 
         * Correct Usage Examples: 
         *  1. Weapon weapon = new Weapon("Scythe", "A sharp blade that is lethal in the right hands.", 45, 10, 90, 25, 5, WeaponClassification.MediumMelee);
         *  2. Weapon weapon = new Weapon("Greatbow", "A large bow with a very resilient string.", 75, 0, 95, 1, 10, WeaponClassification.HeavyBow);
         *  2. Weapon weapon = new Weapon("Small Wand", "A lightweight wand. Perfect for beginner spellcasters.", 2, 22, 80, 20, 0, WeaponClassification.LightStaff);
         */
        public Weapon(string name, string description, int pdmg, int mdmg, int accuracy, int dexterity, int parryChance, WeaponClassification weaponClass)
        {
            Name = name;
            Description = description;
            PhysicalDamage = pdmg;
            MagicalDamage = mdmg;
            Accuracy = accuracy;
            Dexterity = dexterity;
            ParryChance = parryChance;
            WeaponClass = weaponClass;
        }


        /*
         * Returns a formatted string containing the weapon's 
         * PhysicalDaMaGe (PDMG), MagicalDaMaGe (MDMG), Accuracy, Dexterity, Parry Percentage, and its Description.
         * 
         * @return sb.ToString();
         */
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append(Name + " (" + PhysicalDamage + "PDEF / " + MagicalDamage + "MDEF / " + Accuracy + "% Accurate / " + Dexterity + "DEX / " + ParryChance + "% Parry" + "\n");
            sb.Append(Description);

            return sb.ToString();
        }
    }
}
