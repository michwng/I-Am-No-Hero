

using System.Text;
/**       
* -------------------------------------------------------------------
* 	   File name: Ally.cs
* 	Project name: I Am No Hero
* -------------------------------------------------------------------
*  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
*            Creation Date:	04/20/2022	
*            Last Modified:    04/22/2022
* -------------------------------------------------------------------
*/
namespace I_Am_No_Hero
{
    /*
     * Ally is a class specialized for all protagonists in the game.
     * It inherits from the abstract BasePerson class, so it has access
     * to all the fields, methods, and constructors from the BasePerson class.
     * 
     * Date Created: 04/20/2022
     * Last Modified: 04/22/2022
     */
    public class Ally : BasePerson
    {
        //New fields introduced in the Ally class.
        //Enemies will not use these attributes,
        //which is why we separate Allies and Enemies
        //into 2 classes.
        internal int Experience { get; set; } = 0;

        internal int CarryWeight { get; set; } = 5;


        //"Constants". We initialize them in the constructor.
        //These determine the probability of a stat increasing.
        private int HP_GROWTH_CHANCE { get; init; } = 0;
        private int SP_GROWTH_CHANCE { get; init; } = 0;
        private int CONSTITUTION_GROWTH_CHANCE { get; init; } = 0;
        private int AFFINITY_GROWTH_CHANCE { get; init; } = 0;
        private int DEFENSE_GROWTH_CHANCE { get; init; } = 0;
        private int RESISTANCE_GROWTH_CHANCE { get; init; } = 0;
        private int SPEED_GROWTH_CHANCE { get; init; } = 0;
        private int MANA_GROWTH_CHANCE { get; init; } = 0;
        private int STRENGTH_GROWTH_CHANCE { get; init; } = 0;
        private int AGILITY_GROWTH_CHANCE { get; init; } = 0;
        private int HEALINGFACTOR_GROWTH_CHANCE { get; init; } = 0;
        private int HEALINGBUFFFACTOR_GROWTH_CHANCE { get; init; } = 0;
        private int SUPPORTBUFFFACTOR_GROWTH_CHANCE { get; init; } = 0;
        private int DEBUFFFACTOR_GROWTH_CHANCE { get; init; } = 0;
        private int DAMAGEREDUCTION_GROWTH_CHANCE { get; init; } = 0;
        private int CARRYWEIGHT_GROWTH_CHANCE { get; init; } = 0;


        /*
         * The primary constructor of the Ally class.
         * Takes a string parameter and compares it to 
         * a "list" of allies. Then, initializes the Ally
         * based on that name.
         * 
         * Date Created: 04/20/2022
         * Last Modified: 04/22/2022
         */
        public Ally(string name = "REVIA") 
        {
            //Since all allies are unique, they are denoted with "".
            Article = "";
            name = name.ToUpper().Trim();
            //Yilaska's Story Allies
            if (name == "Yilaska")
            {
                Name = "Yilaska";
                ArticleName = Name;
                Description = "The Princess of Pyronia.";

                BaseHP = 150;
                BaseSP = 100;
                BaseHPRecovery = 5;
                BaseSPRecovery = 15;
                BaseConstitution = 10;
                BaseAffinity = 25;
                BaseDefense = 20;
                BaseResistance = 20;
                BaseSpeed = 10;
                BaseMana = 5;
                
                Specialization = Specialization.Myrmidon;
                SkillSet = new SkillSet(Specialization, BaseAffinity, BaseConstitution, BaseSpeed, BaseStrength, BaseMana, BaseAgility);

                //You might notice that we don't have Affinity or Mana or all that.
                //Since Revia is a Myrmidion, those attributes are unnecessary.
                //They're automatically set to 0. No need to include it here.
                HP_GROWTH_CHANCE = 80;
                SP_GROWTH_CHANCE = 70;
                CONSTITUTION_GROWTH_CHANCE = 30;
                AFFINITY_GROWTH_CHANCE = 90;
                DEFENSE_GROWTH_CHANCE = 75;
                RESISTANCE_GROWTH_CHANCE = 75;
                SPEED_GROWTH_CHANCE = 55;
                MANA_GROWTH_CHANCE = 75;
                CARRYWEIGHT_GROWTH_CHANCE = 75;
            }
            else if (name == "REVIA")
            {
                Name = "Revia";
                ArticleName = Name;
                Description = "Yilaska's assigned retainer. Capable with Swords.";

                BaseHP = 200;
                BaseSP = 50;
                BaseHPRecovery = 10;
                BaseSPRecovery = 10;
                BaseConstitution = 20;
                BaseAffinity = 10;
                BaseDefense = 25;
                BaseResistance = 10;
                BaseSpeed = 15;
                BaseStrength = 5;
                Specialization = Specialization.Myrmidon;
                SkillSet = new SkillSet(Specialization, BaseAffinity, BaseConstitution, BaseSpeed, BaseStrength, BaseMana, BaseAgility);

                //You might notice that we don't have Affinity or Mana or all that.
                //Since Revia is a Myrmidion, those attributes are unnecessary.
                //They're automatically set to 0. No need to include it here.
                HP_GROWTH_CHANCE = 80;
                SP_GROWTH_CHANCE = 50;
                CONSTITUTION_GROWTH_CHANCE = 80;
                DEFENSE_GROWTH_CHANCE = 80;
                RESISTANCE_GROWTH_CHANCE = 55;
                SPEED_GROWTH_CHANCE = 55;
                STRENGTH_GROWTH_CHANCE = 75;
                CARRYWEIGHT_GROWTH_CHANCE = 75;
            }
            else 
            {
                Console.WriteLine($"A Random Dude was created. The Name parameter was \"{name}\"");
                Name = "A Random Dude";
                ArticleName = Name;
                Description = "Who is this guy? Why is he fighting with us?\nIt looks like something went wrong.";

                BaseHP = 500;
                BaseSP = 100;
                BaseHPRecovery = 50;
                BaseSPRecovery = 10;
                BaseConstitution = 100;
                BaseAffinity = 65;
                BaseDefense = 25;
                BaseResistance = 35;
                BaseSpeed = 35;
                BaseAgility = 20;
                Specialization = Specialization.Arsonist;
                SkillSet = new SkillSet(Specialization, BaseAffinity, BaseConstitution, BaseSpeed, BaseStrength, BaseMana, BaseAgility);

                HP_GROWTH_CHANCE = 95;
                SP_GROWTH_CHANCE = 75;
                CONSTITUTION_GROWTH_CHANCE = 60;
                DEFENSE_GROWTH_CHANCE = 55;
                RESISTANCE_GROWTH_CHANCE = 55;
                SPEED_GROWTH_CHANCE = 100;
                AGILITY_GROWTH_CHANCE = 65;
                CARRYWEIGHT_GROWTH_CHANCE = 65;
            }

            //Reset the Actual values to the Base values.
            //See the BasePerson class.
            ResetActualValues();
        }


        /*
         * Checks if Experience is greater than 100.
         * If so, the character is leveled up until 
         * Experience is less than 100.
         * 
         * 
         * Date Created: 04/20/2022
         * Last Modified: 04/20/2022
         */
        internal void CheckForLevelUp()
        {
            if (Experience > 100)
            {
                while (Experience > 100)
                {
                    Experience -= 100;
                    IncreaseStats();
                }
            }
        }


        /*
         * Increases the character's stats.
         * The Probability of increase is dependent on 
         * the character's GROWTH stats.
         * 
         * Date Created: 04/20/2022
         * Last Modified: 04/22/2022
         */
        private double[] IncreaseStats()
        {
            double[] statIncreases = new double[16];

            Random random = new();
            int randomNum;
            //A random number between 0-99 is compared with HP_Growth_Chance.
            //If the random number is below, increase the Ally's HP.
            if (random.Next(100) < HP_GROWTH_CHANCE) 
            {
                //Increase HP by 10, 20, or 30.
                randomNum = (random.Next(3) + 1) * 10;
                BaseHP += randomNum;
                statIncreases[0] = randomNum;
            }
            //A random number between 0-99 is compared with SP_GROWTH_CHANCE.
            //If the random number is below, increase the Ally's SP.
            if (random.Next(100) < SP_GROWTH_CHANCE)
            {
                //Increase SP by 5, 10, or 15.
                randomNum = (random.Next(3) + 1) * 5;
                BaseSP += randomNum;
                statIncreases[1] = randomNum;
            }
            //A random number between 0-99 is compared with CONSTITUTION_GROWTH_CHANCE.
            //If the random number is below, increase the Ally's Constitution.
            if (random.Next(100) < CONSTITUTION_GROWTH_CHANCE)
            {
                //Increase Constitution by 1-10.
                BaseConstitution += randomNum = (random.Next(10) + 1);
                statIncreases[2] = randomNum;
            }
            //A random number between 0-99 is compared with AFFINITY_GROWTH_CHANCE.
            //If the random number is below, increase the Ally's Affinity.
            if (random.Next(100) < AFFINITY_GROWTH_CHANCE)
            {
                //Increase Affinity by 1-10.
                BaseAffinity += randomNum = (random.Next(10) + 1);
                statIncreases[3] = randomNum;
            }
            //A random number between 0-99 is compared with DEFENSE_GROWTH_CHANCE.
            //If the random number is below, increase the Ally's Defense.
            if (random.Next(100) < DEFENSE_GROWTH_CHANCE)
            {
                //Increase Defense by 1-10.
                BaseDefense += randomNum = (random.Next(10) + 1);
                statIncreases[4] = randomNum;
            }
            //A random number between 0-99 is compared with RESISTANCE_GROWTH_CHANCE.
            //If the random number is below, increase the Ally's Resistance.
            if (random.Next(100) < RESISTANCE_GROWTH_CHANCE)
            {
                //Increase Resistance by 1-10.
                BaseResistance += randomNum = (random.Next(10) + 1);
                statIncreases[5] = randomNum;
            }
            //A random number between 0-99 is compared with SPEED_GROWTH_CHANCE.
            //If the random number is below, increase the Ally's Speed.
            if (random.Next(100) < SPEED_GROWTH_CHANCE)
            {
                //Increase Speed by 1-10.
                BaseSpeed += randomNum = (random.Next(10) + 1);
                statIncreases[6] = randomNum;
            }
            //A random number between 0-99 is compared with MANA_GROWTH_CHANCE.
            //If the random number is below, increase the Ally's Mana.
            if (random.Next(100) < MANA_GROWTH_CHANCE)
            {
                //Increase Mana by 10, 20, or 30.
                BaseMana += randomNum = (random.Next(3) + 1);
                statIncreases[7] = randomNum;
            }
            //A random number between 0-99 is compared with STRENGTH_GROWTH_CHANCE.
            //If the random number is below, increase the Ally's Strength.
            if (random.Next(100) < STRENGTH_GROWTH_CHANCE)
            {
                //Increase Strength by 10, 20, or 30.
                BaseStrength += randomNum = (random.Next(3) + 1);
                statIncreases[8] = randomNum;
            }
            //A random number between 0-99 is compared with AGILITY_GROWTH_CHANCE.
            //If the random number is below, increase the Ally's Agility.
            if (random.Next(100) < AGILITY_GROWTH_CHANCE)
            {
                //Increase Agility by 10, 20, or 30.
                BaseAgility += randomNum = (random.Next(3) + 1);
                statIncreases[9] = randomNum;
            }
            //A random number between 0-99 is compared with HEALINGFACTOR_GROWTH_CHANCE.
            //If the random number is below, increase the Ally's Healing Factor.
            if (random.Next(100) < HEALINGFACTOR_GROWTH_CHANCE)
            {
                //Increase Healing Factor by 0 - 0.5.
                double doubleNum = (random.Next(2) * 0.5);
                BaseHealingFactor += doubleNum;
                statIncreases[10] = doubleNum;
            }
            //A random number between 0-99 is compared with HEALINGBUFFFACTOR_GROWTH_CHANCE.
            //If the random number is below, increase the Ally's Healing Buff Factor.
            if (random.Next(100) < HEALINGBUFFFACTOR_GROWTH_CHANCE)
            {
                //Increase Healing Buff Factor by 0 - 0.5.
                double doubleNum = (random.Next(2) * 0.5);
                BaseHealingBuffFactor += doubleNum;
                statIncreases[11] = doubleNum;
            }
            //A random number between 0-99 is compared with SUPPORTBUFFFACTOR_GROWTH_CHANCE.
            //If the random number is below, increase the Ally's Support Buff Factor.
            if (random.Next(100) < SUPPORTBUFFFACTOR_GROWTH_CHANCE)
            {
                //Increase Support Buff Factor by 0 - 0.5.
                double doubleNum = (random.Next(2) * 0.5);
                BaseSupportBuffFactor += doubleNum;
                statIncreases[12] = doubleNum;
            }
            //A random number between 0-99 is compared with DEBUFFFACTOR_GROWTH_CHANCE.
            //If the random number is below, increase the Ally's Debuff Factor.
            if (random.Next(100) < DEBUFFFACTOR_GROWTH_CHANCE)
            {
                //Increase Debuff Factor by 0 - 0.5.
                double doubleNum = (random.Next(2) * 0.5);
                BaseDebuffFactor += doubleNum;
                statIncreases[13] = doubleNum;
            }
            //A random number between 0-99 is compared with DAMAGEREDUCTION_GROWTH_CHANCE.
            //If the random number is below, increase the Ally's Damage Reduction.
            if (random.Next(100) < DAMAGEREDUCTION_GROWTH_CHANCE)
            {
                //Increase Damage Reduction by 0% - 1.99%.
                double doubleNum = (double)(Math.Round((decimal)(random.Next(2)), 2));
                BaseDamageReduction += doubleNum;
                statIncreases[14] = doubleNum;
            }
            //A random number between 0-99 is compared with CARRYWEIGHT_GROWTH_CHANCE.
            //If the random number is below, increase the Ally's Carry Weight.
            if (random.Next(100) < CARRYWEIGHT_GROWTH_CHANCE)
            {
                //Increase Carry Weight by 1, 2, or 3.
                CarryWeight += randomNum = (random.Next(3) + 1);
                statIncreases[15] = randomNum;
            }

            return statIncreases;
        }
    }
}