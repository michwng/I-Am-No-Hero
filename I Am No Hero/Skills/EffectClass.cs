/**       
 * -------------------------------------------------------------------
 * 	   File name: Skill.cs
 * 	Project name: I Am No Hero
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	06/12/2022
 *            Last Modified:    06/12/2022
 * -------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_Am_No_Hero.Skills
{
    public enum EffectClass
    {
        /*****************************
         *     STUNS & INHIBITS      *
         *****************************/
        // Stuns and Inhibits prevent people from moving or doing certain actions.
        
        //Prevent a person from moving.
        Stun,

        //Prevent a person from Fleeing the Battlefield.
        Courageous,

        //Prevent a person from Inspecting the Battlefield.
        ADHD,

        //Prevent a person from using Supportive Skills.
        Reckless,

        //Prevent a person from using Supportive Skills on Allies.
        Selfish,

        //Prevent a person from using Supportive Skills on themself.
        Selfless,

        //Prevent a person from using SP Skills.
        Inhibit,



        /*****************************
         *     Nullifying Values     *
         *****************************/
        //Nullifying values set them to 0. 
        //Nullify HP will rarely be used, but it is provided in case.
        NullifyHP,
        NullifySP,
        NullifyConstitution,
        NullifyAffinity,
        NullifyDefense,
        NullifyResistance,
        NullifySpeed,
        NullifyStrength,
        NullifyMana,
        NullifyAgility,
        NullifyParryFocus,


        /*****************************
         *       Stat Reduction      *
         *****************************/
        //Stat Reductions reduce stats by a set value until the effect expires.
        HPReduction,
        SPReduction,
        ConstitutionReduction,
        AffinityReduction,
        DefenseReduction,
        ResistanceReduction,
        SpeedReduction,
        StrengthReduction,
        ManaReduction,
        AgilityReduction,
        ParryFocusReduction,
        HealingFactorReduction,
        HealingBuffFactorReduction,
        SupportBuffFactorReduction,
        DebuffFactorReduction,
        DamageReductionReduction,


        /*****************************
         * Reducing Values Over Time *
         *****************************/
        //Reduces stat values over time.
        //The effect accumulates and reaches its maximum strength on its final turn.
        //After the final turn, the person's stats will be restored to the original value (if the effect has expired).
        HPReductionOverTime,
        SPReductionOverTime,
        ConstitutionReductionOverTime,
        AffinityReductionOverTime,
        DefenseReductionOverTime,
        ResistanceReductionOverTime,
        SpeedReductionOverTime,
        StrengthReductionOverTime,
        ManaReductionOverTime,
        AgilityReductionOverTime,
        ParryFocusReductionOverTime,
        HealingFactorReductionOverTime,
        HealingBuffFactorReductionOverTime,
        SupportBuffFactorReductionOverTime,
        DebuffFactorReductionOverTime,
        DamageReductionReductionOverTime,
        RageReductionOverTime,
        FocusReductionOverTime,
        BoldnessReductionOverTime,

        /*****************************
         *     Increasing Stats     *
         *****************************/
        //Stat Increases improve stats by a set value until the effect expires.
        Heal,
        SPIncrease,
        ConstitutionIncrease,
        AffinityIncrease,
        DefenseIncrease,
        ResistanceIncrease,
        SpeedIncrease,
        StrengthIncrease,
        ManaIncrease,
        AgilityIncrease,
        ParryFocusIncrease,
        HealingFactorIncrease,
        HealingBuffFactorIncrease,
        SupportBuffFactorIncrease,
        DebuffFactorIncrease,
        DamageReductionIncrease,


        /******************************
         * Increasing Stats Over Time *
         ******************************/
        //Increases stat values over time.
        //The effect accumulates and reaches its maximum strength on its final turn.
        //After the final turn, the person's stats will be restored to the original value (if the effect has expired).
        HealOverTime,
        SPIncreaseOverTime,
        ConstitutionIncreaseOverTime,
        AffinityIncreaseOverTime,
        DefenseIncreaseOverTime,
        ResistanceIncreaseOverTime,
        SpeedIncreaseOverTime,
        StrengthIncreaseOverTime,
        ManaIncreaseOverTime,
        AgilityIncreaseOverTime,
        ParryFocusIncreaseOverTime,
        HealingFactorIncreaseOverTime,
        HealingBuffFactorIncreaseOverTime,
        SupportBuffFactorIncreaseOverTime,
        DebuffFactorIncreaseOverTime,
        DamageReductionIncreaseOverTime,
        RageIncreaseOverTime,
        FocusIncreaseOverTime,
        BoldnessIncreaseOverTime,



        /******************************
         *      Damage Modifiers      *
         ******************************/
        //Damage Modifiers adjust the amount of damage or healing one receives.
        //This can be applied to the caster or the patient.

        //TO SELF
        //Vulnerable increases damage done to the person with the effect.
        //Typically denotes a 1% - 50% damage increase to the person. 
        Vulnerable,

        //Exposed increases damage done to the person with the effect.
        //Typically denotes a 51% - 100% damage increase to the person. 
        Exposed,

        //Weakened increases damage done to the person with the effect.
        //Typically denotes a damage increase above 100% to the person. 
        Weakened,

        //Defended decreases damage done to the person with the effect.
        //Typically denotes a 1% - 20% damage decrease to the person. 
        Defended,

        //Guarded decreases damage done to the person with the effect.
        //Typically denotes a 21% - 40% damage decrease to the person. 
        Guarded,

        //Protected decreases damage done to the person with the effect.
        //Typically denotes a damage decrease above 41% to the person. 
        Protected,


        //TO OTHER PERSON
        //Sharp increases damage done to the targetted person.
        //Typically denotes a 1% - 50% damage increase to the person. 
        Sharp,

        //Seething increases damage done to the targetted person.
        //Typically denotes a 51% - 100% damage increase to the person. 
        Seething,

        //Enraged increases damage done to the targetted person.
        //Typically denotes a damage increase above 100% to the person. 
        Enraged,

        //Tired decreases damage done to the targetted person.
        //Typically denotes a 1% - 20% damage decrease to the target. 
        Tired,

        //Fatigued decreases damage done to the targetted person.
        //Typically denotes a 21% - 40% damage decrease to the target. 
        Fatigued,

        //Exhausted decreases damage done to the targetted person.
        //Typically denotes a damage decrease above 41% to the target. 
        Exhausted,




        /****************************
         *   BATTLEFIELD CONTROL    *
         ****************************/
        //Status Effects that allow the user to control the battlefield.

        /// <summary>
        /// This skill was inspired directly by Sonny 2.
        /// <br></br>
        /// Make the target appear bigger, making them less likely to be targetted.
        /// </summary>
        Mirage,

        /// <summary>
        /// This unit affected with this ability gains the ability to attack their own teammates.
        /// </summary>
        Confuse,

        /// <summary>
        /// Panic causes the afflicted unit to focus on using supportive skills, but with a lesser effect.
        /// </summary>
        Panic,

        /// <summary>
        /// Fear causes the afflicted unit to attempt to run away.
        /// <br></br> 
        ///Allies and several enemies will decide to do nothing instead.
        /// </summary>
        Fear, 

        /// <summary>
        /// Exertion forces the afflicted user to use their strongest move on the next turn.
        /// <br></br>
        /// If Exertion is applied to the player character, the player character can decide to choose which move to use.
        /// <br></br>
        /// - The move's damage is increased by 275%, but will stun the user for 2 turns.
        /// </summary>
        Exertion,

        /// <summary>
        /// Apathetic units cannot heal or provide supportive buffs to their allies.
        /// <br></br>
        /// They also deal 25% less damage when using Special Skills, but deal 10% more damage with normal Skills.
        /// </summary>
        Apathetic,


        /// <summary>
        /// Another skill inspired by Sonny.
        /// <br></br>
        /// Switches healing with damage and damage with healing.
        /// <br></br>
        /// - If an ally were to heal a unit afflicted with Subversion, the unit would take damage equal to 100% of the healing amount.
        /// <br></br>
        /// - If an enemy attacked a unit afflicted with Subversion, the unit would heal for an amount equal to 100% of the damage dealt.
        /// </summary>
        Subverted,

        /// <summary>
        /// Units that are incorrigible will not be healed by allies.
        /// <br></br>
        /// The only exception to this are area heals.
        /// <br><br></br></br>
        /// The official definition of Incorrigible: "(of a person or their tendencies) <b>not able to be</b> corrected, improved, or <b><i>reformed</i></b>"
        /// </summary>
        Incorrigible,

        /// <summary>
        /// None is the default EffectClass and signifies that the effect does nothing.
        /// </summary>
        None

    }
}
