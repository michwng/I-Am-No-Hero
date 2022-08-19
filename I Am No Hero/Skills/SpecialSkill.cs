

using System.Text;
/**       
* -------------------------------------------------------------------
* 	   File name: SkillSet.cs
* 	Project name: I Am No Hero
* -------------------------------------------------------------------
*  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
*            Creation Date:	04/20/2022	
*            Last Modified:    04/20/2022
* -------------------------------------------------------------------
*/
namespace I_Am_No_Hero
{
    internal class SpecialSkill : Skill
    {
        internal int SPCost { get; set; }


        /* 
         * The base constructor for the SpecialSkill class.
         * Initializes fields using basic values.
         * 
         * Date Created: 04/20/2022
         * Last Modified: 04/20/2022
         * -------------------------
         */
        public SpecialSkill()
        {
            SkillName = "Slash";
            SkillDescription = "Slash the Enemy.";
            BaseDamage = 25;
            Accuracy = 95;
            SkillEffects = null;
            Target = Target.Enemy;
            SPCost = 5;
            DamageType = 'P';
        }


        /* 
         * The primary constructor for the Skill class.
         * Initializes fields based on parameter values.
         * 
         * Date Created: 04/20/2022
         * Last Modified: 04/20/2022
         * -------------------------
         * @param string skillName, skillDescription, baseDamage
         * @param List<Effect> skillEffects
         * @param Target target
         */
        public SpecialSkill(string skillName, string skillDescription, int baseDamage, int accuracy, List<Effect> skillEffects, Target target, int spCost = 0, char damageType = 'P', Boolean isHealingSkill = false)
        {
            SkillName = skillName;
            SkillDescription = skillDescription;
            BaseDamage = baseDamage;
            Accuracy = accuracy;
            SkillEffects = skillEffects;
            Target = target;
            SPCost = spCost;
            DamageType = damageType;
            IsHealingSkill = isHealingSkill;
        }


        /*
         * Returns a formatted string containing the Skill's attributes.
         * 
         * Date Created: 04/20/2022
         * Last Modified: 04/26/2022
         */
        public new string GetSkillInfo()
        {
            StringBuilder sb = new();

            sb.Append($"==============================\n");
            sb.Append(SkillName + "\n");
            sb.Append($"{SkillDescription}\n");
            sb.Append($"------------------------------\n");
            sb.Append($"Base Damage: {BaseDamage} ");
            if (DamageType == 'P')
            {
                sb.Append($"Physical DMG ({Accuracy}% chance to hit)\n");
            }
            else
            {
                sb.Append($"Magical DMG ({Accuracy}% chance to hit)\n");
            }

            if (SkillEffects != null)
            {
                sb.Append($" -------EFFECTS-------\n");
                for (int i = 0; i < SkillEffects.Count; i++)
                {
                    Effect effect = SkillEffects[i];
                    sb.Append(" |" + effect.EffectName + "|\n");
                    sb.Append("  - " + effect.EffectDescription + "\n");

                    /*sb.Append("     Proc Chance: " + effect.EffectChance + "%\n");
                    sb.Append("     Lasts for: " + effect.EffectLength + " turns.\n");
                    sb.Append("     The Effect Targets: " + effect.EffectTarget + ".\n");*/

                    /*if (i + 1 != SkillEffects.Count) 
                    {
                        sb.Append($"  -----\n");
                    }*/
                }
            }
            sb.Append($"------------------------------\n");

            sb.Append($"{SkillName} Targets: {Target.ToString()}\n");
            sb.Append($"==============================\n");

            return sb.ToString();
        }


    }
}