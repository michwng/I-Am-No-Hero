

using System.Text;
/**       
* -------------------------------------------------------------------
* 	   File name: Skill.cs
* 	Project name: I Am No Hero
* -------------------------------------------------------------------
*  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
*            Creation Date:    04/20/2022	
*            Last Modified:    04/26/2022
* -------------------------------------------------------------------
*/
namespace I_Am_No_Hero
{
    internal class Skill
    {
        /// <summary>
        /// The name of the skill.
        /// </summary>
        internal string SkillName { get; set; }

        /// <summary>
        /// A description of the skill.
        /// </summary>
        internal string SkillDescription { get; set; }

        /// <summary>
        /// The calculated damage the skill may deal.
        /// This value does not consider Enemy Defense, Resistance, or Damage Reduction.
        /// </summary>
        internal int BaseDamage { get; set; }
        internal char DamageType { get; set; }

        /// <summary>
        /// Accuracy represents a value between 0 - 100.
        /// </summary>
        internal int Accuracy { get; set; }

        /// <summary>
        /// The effects that this skill incurs.
        /// </summary>
        internal List<Effect>? SkillEffects { get; set; }

        /// <summary>
        /// Who the skill targets. 
        /// Values are based on the Target enum.
        /// </summary>
        internal Target Target { get; set; }

        internal Boolean IsHealingSkill { get; set; } = false;

        ///

        /// <summary>
        /// The base constructor for the Skill class. 
        /// <list type="bullet">Initializes fields using basic values. </list>
        /// <para>Date Created: 04/20/2022</para>
        /// <para>Last Modified: 04/20/2022</para>
        /// </summary>
        public Skill()
        {
            SkillName = "Quick Attack";
            SkillDescription = "Attack the enemy.";
            BaseDamage = 25;
            Accuracy = 100;
            DamageType = 'P';
            SkillEffects = null;
            Target = Target.Enemy;
        }

        /// <summary>
        /// The primary constructor for the Skill class.
        /// <list type="bullet">Initializes fields based on parameter values.</list>
        /// <para>Date Created: 04/20/2022</para>
        /// <para>Last Modified: 04/20/2022</para>
        /// </summary>
        /// <param name="skillName"></param>
        /// <param name="skillDescription"></param>
        /// <param name="baseDamage"></param>
        /// <param name="accuracy"></param>
        /// <param name="skillEffects"></param>
        /// <param name="target"></param>
        /// <param name="damageType"></param>
        public Skill(string skillName, string skillDescription, int baseDamage, int accuracy, List<Effect>? skillEffects, Target target, char damageType = 'P', Boolean isHealingSkill = false)
        {
            SkillName = skillName;
            SkillDescription = skillDescription;
            BaseDamage = baseDamage;
            Accuracy = accuracy;
            SkillEffects = skillEffects;
            Target = target;
            DamageType = damageType;
            IsHealingSkill = isHealingSkill;
        }


        /*
         * Returns the name of the skill.
         * Overridden this way to display the attackmenu's 
         * combobox correctly.
         * 
         * Date Created: 04/20/2022
         * Last Modified: 04/26/2022
         */
        public override string ToString() 
        {
            return SkillName;
        }


        /*
         * Returns a formatted string containing the Skill's attributes.
         * 
         * Date Created: 04/20/2022
         * Last Modified: 04/26/2022
         */
        public string GetSkillInfo() 
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
                for(int i = 0; i < SkillEffects.Count; i++)
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