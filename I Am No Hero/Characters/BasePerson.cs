/**       
 * -------------------------------------------------------------------
 * 	   File name: BasePerson.cs
 * 	Project name: I Am No Hero
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	03/20/2022	
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
    /*
     * BasePerson is an abstract class. 
     * It provides the framework for:
     *  - Allies (including the Hero)
     *  - Enemies
     * 
     * Date Created: 3/20/2022
     * Last Modified: 04/01/2022
     */
    public abstract class BasePerson : IComparable<BasePerson>
    {
        //Armor is sorted in the same way as in the enum BodyPart:
        //Head, Torso, Leg, Feet, Arms, Hands, Neck, Charm
        internal Armor[] EquippedArmor { get; set; } = new Armor[8];

        internal Weapon? EquippedWeapon { get; set; } = new Weapon();

        internal Specialization Specialization { get; set; }

        internal SkillSet? SkillSet { get; set; }

        internal string? Name { get; set; }
        internal string? Description { get; set; }

        internal List<Effect> StatusEffects = new();

        /// <summary>
        /// Article determines whether the base person created should be described with "a", "the", or "".
        /// <br></br> Example: The Goblin Leader (IsImportant = true)
        /// <br></br> Example 2: A Deskil Knight (IsImportant = false)
        /// <br></br> Example 3: A Bandit (IsImportant = false)
        /// </summary>
        internal string Article = "a";


        /// <summary>
        /// Vitality is the statistic that makes this RPG unique to others.
        /// Constitution, Affinity, Resistance, and Speed are affected by Vitality.
        /// </summary>
        //internal double Vitality = 100.0;


        /// <summary>
        /// Battle Rating (BR) is an MMO Game Term that summarizes an RPG character's capabilities in battle.
        /// <br></br>BR is calculated as follows:
        /// <br></br> - 1 HP Point     represents 1 BR.
        /// <br></br> - 1 SP Point     represents 1 BR.
        /// <br></br> - 1 Constitution represents 3 BR.
        /// <br></br> - 1 Affinity     represents 3 BR.
        /// <br></br> - 1 Defense      represents 2 BR.
        /// <br></br> - 1 Resistance   represents 2 BR.
        /// <br></br> - 1 Speed        represents 2 BR.
        /// <br></br> - 1 Strength     represents 15 BR.
        /// <br></br> - 1 Agility      represents 10 BR.
        /// <br></br> - 1 Mana         represents 15 BR.
        /// </summary>
        internal int BattleRating
        {
            get
            {
                return this.ActualHP + this.ActualSP + this.ActualConstitution * 3 + this.ActualAffinity * 3
                    + this.ActualDefense * 2 + this.ActualResistance * 2 + this.ActualSpeed * 2
                    + this.ActualStrength * 15 + this.ActualAgility * 10 + this.ActualMana * 15;
            }
        }


        /*-----------------------------*/
        /***** General Attributes *****/

        //HP stands for Health Points. The person is defeated when it reaches 0.
        internal int BaseHP { get; set; } = 0;
        internal int ActualHP { get; set; } = 0;

        //SP stands for Special Points. This is used to perform Special Attacks.
        internal int BaseSP { get; set; } = 0;
        internal int ActualSP { get; set; } = 0;

        //BaseRecovery provides HP and SP to the Person after a round.
        internal int BaseHPRecovery { get; set; } = 0;
        internal int ActualHPRecovery { get; set; } = 0;
        internal int BaseSPRecovery { get; set; } = 0;
        internal int ActualSPRecovery { get; set; } = 0;

        //ParryFocus is added onto the Parry value of a weapon. Allows the parrying of enemy moves. 
        internal int ParryFocus { get; set; } = 0;

        //Base Constitution and Affinity determine the amount of damage the person deals.
        internal int BaseConstitution { get; set; } = 0;
        internal int ActualConstitution { get; set; } = 0;
        internal int BaseAffinity { get; set; } = 0;
        internal int ActualAffinity { get; set; } = 0;

        //Speed determines who goes first.
        internal int BaseSpeed { get; set; } = 0;
        internal int ActualSpeed { get; set; } = 0;


        internal int BaseDefense { get; set; } = 0;
        internal int ActualDefense { get; set; } = 0;
        internal int BaseResistance { get; set; } = 0;
        internal int ActualResistance { get; set; } = 0;

        /*-----------------------------------*/
        /***** Class Specific Attributes *****/
        //Mage Classes.
        //Mana provides extra SP regeneration and SP.
        //Mana also judges the level of equipment a mage can use.
        internal int BaseMana { get; set; } = 0;
        internal int ActualMana { get; set; } = 0;

        //Ample Focus allows Mages to perform an Ultimate move.
        internal int Focus { get; set; } = 0;

        //Strength is for Warrior Classes.
        //Strength determines the level of equipment they may wear,
        //as well as the Warrior's weapon.
        internal int BaseStrength { get; set; } = 0;
        internal int ActualStrength { get; set; } = 0;

        //Ample Rage allows Warriors to perform an Ultimate move.
        internal int Rage { get; set; } = 0;

        //Agility is for Thief Classes.
        //Agility determines the level of equipment they may wear,
        //as well as the Thief's weapon.
        internal int BaseAgility { get; set; } = 0;
        internal int ActualAgility { get; set; } = 0;

        //Ample Boldness allows Thieves to perform an Ultimate move.
        internal int Boldness { get; set; } = 0;

        //HealingFactor & BuffFactor is for Clerical Classes.
        //Healing done by support classes is multiplied by HealingFactor.
        //Buffs done by support classes are multiplied by BuffFactor.
        internal double BaseHealingFactor { get; set; } = 1.0;
        internal double ActualHealingFactor { get; set; } = 1.0;
        internal double BaseHealingBuffFactor { get; set; } = 1.0;
        internal double ActualHealingBuffFactor { get; set; } = 1.0;

        //SupportBuffFactor and DebuffFactor are for Leader classes.
        //Support buffs provided by Leaders are multipled by SupportBuffFactor
        //Debuff buffs provided by Leaders are multiplied by DebuffFactor.
        internal double BaseSupportBuffFactor { get; set; } = 1.0;
        internal double ActualSupportBuffFactor { get; set; } = 1.0;
        internal double BaseDebuffFactor { get; set; } = 1.0;
        internal double ActualDebuffFactor { get; set; } = 1.0;


        /***** Intermediate Class Attributes *****/
        //DaamgeReduction is for Guardian Classes.
        //Damage Reduction reduces the overall damage dealt to the Person.
        internal double BaseDamageReduction { get; set; } = 0.0;
        internal double ActualDamageReduction { get; set; } = 0.0;


        /******************************************
         * 
         *          Constructor
         *          
         ******************************************/
        // -- Side Note: Because this is an abstract class, a constructor is not necessary.
        // -- The constructors are coded in the child classes: Ally and Enemy.

        //Commented out - kept throwing CS7036 when trying to simplify enemy construction.
        /*public BasePerson(int BHP, int BSP, int BHPR, int BSPR, int BC, int BA, int BS,
            int BD, int BR, int BM, int BStr, int BAgi, double HF = 0.0, double HBF = 0.0,
            double SBF = 0.0, double DF = 0.0, double DR = 0.0,
            Specialization spec = I_Am_No_Hero.Specialization.Myrmidon)
        {
            //Base attributes only change in level ups.
            BaseHP = BHP;
            BaseSP = BSP;
            BaseHPRecovery = BHPR;
            BaseSPRecovery = BSPR;
            BaseConstitution = BC;
            BaseAffinity = BA;
            BaseSpeed = BS;
            BaseDefense = BD;
            BaseResistance = BR;
            BaseMana = BM;
            BaseStrength = BStr;
            BaseAgility = BAgi;
            HealingFactor = HF;
            HealingBuffFactor = HBF;
            SupportBuffFactor = SBF;
            DebuffFactor = DF;
            DamageReduction = DR;


            //Base attributes only change in level ups.
            //This is a more simplified version of the commented-out code above and below.
            //BaseHP is first set to BHP,  then ActualHP is set to BaseHP, and so on.
            ActualHP = BaseHP = BHP;
            ActualSP = BaseSP = BSP;
            ActualHPRecovery = BaseHPRecovery = BHPR;
            ActualSPRecovery = BaseSPRecovery = BSPR;
            ActualConstitution = BaseConstitution = BC;
            ActualAffinity = BaseAffinity = BA;
            ActualSpeed = BaseSpeed = BS;
            ActualDefense = BaseDefense = BD;
            ActualResistance = BaseResistance = BR;
            ActualMana = BaseMana = BM;
            ActualStrength = BaseStrength = BStr;
            ActualAgility = BaseAgility = BAgi;
            ActualHealingFactor = HealingFactor = HF;
            ActualHealingBuffFactor = HealingBuffFactor = HBF;
            ActualSupportBuffFactor = SupportBuffFactor = SBF;
            ActualDebuffFactor = DebuffFactor = DF;
            ActualDamageReduction = DamageReduction = DR;
            Specialization = spec;

            //The null in the SkillSet parameter is a pretense.
            //After we intiialize Specialization, we then initialize SkillSet.

            SkillSet = new SkillSet(Specialization);



            //Initialize Actual Values.
            //They reference Base values, but are altered in battle.

            ActualHP = BaseHP;
            ActualSP = BaseSP;
            ActualHPRecovery = BaseHPRecovery;
            ActualSPRecovery = BaseSPRecovery;
            ActualConstitution = BaseConstitution;
            ActualAffinity = BaseAffinity;
            ActualSpeed = BaseSpeed;
            ActualDefense = BaseDefense;
            ActualResistance = BaseResistance;
            ActualMana = BaseMana;
            ActualStrength = BaseStrength;
            ActualAgility = BaseAgility;
            ActualHealingFactor = HealingFactor;
            ActualHealingBuffFactor = HealingBuffFactor;
            ActualSupportBuffFactor = SupportBuffFactor;
            ActualDebuffFactor = DebuffFactor;
            ActualDamageReduction = DamageReduction;

        }//End constructor*/


        /*
         * Resets all actual values to their base values.
         * Also accepts a boolean.
         * 
         * Date Created: 04/20/2022
         * Last Modified: 04/20/2022
         * -------------------------
         * @param Boolean individualValueReset
         */
        public void ResetActualValues(Boolean individualValueReset = false, string? valueToReset = null) 
        {
            if (!individualValueReset)
            {
                //In other words, we reset all actual values to base values.
                ActualHP = BaseHP;
                ActualSP = BaseSP;
                ActualHPRecovery = BaseHPRecovery;
                ActualSPRecovery = BaseSPRecovery;
                ActualConstitution = BaseConstitution;
                ActualAffinity = BaseAffinity;
                ActualSpeed = BaseSpeed;
                ActualDefense = BaseDefense;
                ActualResistance = BaseResistance;
                ActualMana = BaseMana;
                ActualStrength = BaseStrength;
                ActualAgility = BaseAgility;
                ActualHealingFactor = BaseHealingFactor;
                ActualHealingBuffFactor = BaseHealingBuffFactor;
                ActualSupportBuffFactor = BaseSupportBuffFactor;
                ActualDebuffFactor = BaseDebuffFactor;
                ActualDamageReduction = BaseDamageReduction;
            }
            else 
            {
                if (valueToReset != null)
                {
                    //Reset an individual attribute.
                    switch (valueToReset.ToLower())
                    {
                        case "actualhp":
                            ActualHP = BaseHP;
                            break;
                        case "actualsp":
                            ActualSP = BaseSP;
                            break;
                        case "actualhprecovery":
                            ActualHPRecovery = BaseHPRecovery;
                            break;
                        case "actualsprecovery":
                            ActualSPRecovery = BaseSPRecovery;
                            break;
                        case "actualconstitution":
                            ActualConstitution = BaseConstitution;
                            break;
                        case "actualaffinity":
                            ActualAffinity = BaseAffinity;
                            break;
                        case "actualspeed":
                            ActualSpeed = BaseSpeed;
                            break;
                        case "actualdefence":
                            ActualDefense = BaseDefense;
                            break;
                        case "actualresistance":
                            ActualResistance = BaseResistance;
                            break;
                        case "actualmana":
                            ActualMana = BaseMana;
                            break;
                        case "actualstrength":
                            ActualStrength = BaseStrength;
                            break;
                        case "actualagility":
                            ActualAgility = BaseAgility;
                            break;
                        case "actualhealingfactor":
                            ActualHealingFactor = BaseHealingFactor;
                            break;
                        case "actualhealingbufffactor":
                            ActualHealingBuffFactor = BaseHealingBuffFactor;
                            break;
                        case "actualsupportbufffactor":
                            ActualSupportBuffFactor = BaseSupportBuffFactor;
                            break;
                        case "actualdebufffactor":
                            ActualDebuffFactor = BaseDebuffFactor;
                            break;
                        case "actualdamagereduction":
                            ActualDamageReduction = BaseDamageReduction;
                            break;
                        case "parryfocus":
                            ParryFocus = 0;
                            break;
                        default:
                            Console.WriteLine($"Oops! There may have been a typo!\nInput: \"{valueToReset}\"");
                            break;
                    }
                }
                else 
                {
                    Console.WriteLine("Error: valueToReset was Null!\n(Nothing was reset)");
                }
            }
        }

        /// <summary>
        /// Get the basic values of the person.
        /// </summary>
        /// <returns></returns>
        public string GetBasicValues() 
        {
            StringBuilder sb = new();
            sb.Append($"Battle Rating: {BattleRating}BR\n");
            sb.Append($"({ActualHP}HP/{BaseHP}HP) | ({ActualSP}SP/{BaseSP}SP)\n");
            sb.Append($"Constitution: {ActualConstitution}\n");
            sb.Append($"Affinity: {ActualAffinity}\n");
            sb.Append($"Defense: {ActualDefense}\n");
            sb.Append($"Resistance: {ActualResistance}\n");
            sb.Append($"Speed: {ActualSpeed}\n");
            sb.Append($"====================\n");

            if (StatusEffects.Count > 0)
            {
                foreach (Effect effect in StatusEffects) 
                {
                    sb.Append($"{effect.EffectName}\n");
                    sb.Append($"{effect.EffectDescription}\n");

                    //Small grammar fix:
                    if (effect.EffectLength != 1)
                    {
                        sb.Append($"This effect will end in {effect.EffectLength} turns.");
                    }
                    else
                    {
                        sb.Append($"This effect will end in {effect.EffectLength} turn.");
                    }
                }
            }
            else 
            {
                sb.Append("Healthy - Unaffected by Status Effects.\n");
            }
            sb.Append("====================");
            return sb.ToString();
        }

        public int CompareTo(BasePerson? other)
        {
            //Both this [the baseperson being compared] and other could potentially be null.
            if (this != null && other != null)
            {
                if ((this.ActualSpeed + (this.ActualAgility * 5)) > (other.ActualSpeed + (other.ActualAgility * 5)))
                {
                    return -1;
                }
                else if ((this.ActualSpeed + (this.ActualAgility * 5)) == (other.ActualSpeed + (other.ActualAgility * 5)))
                {
                    //We want the weaker person to go first.
                    if (this.BattleRating > other.BattleRating)
                    {
                        //This happens when the person being compared is stronger than the other.
                        //In this case, this person goes AFTER the other person.
                        return 1;
                    }
                    else 
                    {
                        return -1;
                    }
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }
    }// End BasePerson Class
}
