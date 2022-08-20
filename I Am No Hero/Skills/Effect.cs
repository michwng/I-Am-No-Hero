

using I_Am_No_Hero.Skills;
/**       
* -------------------------------------------------------------------
* 	   File name: Effect.cs
* 	Project name: I Am No Hero
* -------------------------------------------------------------------
*  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
*            Creation Date:	04/20/2022	
*            Last Modified:    06/12/2022
* -------------------------------------------------------------------
*/
namespace I_Am_No_Hero
{
    public class Effect
    {
        //There's a lot to decode here.

        //The name of the effect.
        internal string EffectName { get; private set; }
        //A description of the effect.
        internal string EffectDescription { get; private set; }

        //The description of the effect when incurred on a target.
        internal string ActualEffectDescription { get; private set; }
        //The chance for the effect to proc on the target.
        internal int EffectChance { get; private set; }

        //The strength of the effect.
        //For example, the Bleeding effect with an effect strength of 5
        //will cause the target to lose 5 HP a turn.
        internal int EffectStrength { get; private set; }

        //Determines if EffectStrength represents a percentage.
        //For example, if StrengthIsPercentage is true and Effect strength is 5,
        //will cause the target to lose 5% of their total HP a turn.
        internal Boolean StrengthIsPercentage { get; private set; }

        //The length of the effect in turns.
        internal int EffectLength { get; private set; }
        //CanStack determines if, for example,
        //The Bleeding effect can affect the same target multiple times at the same time.
        internal Boolean CanStack { get; private set; } = false;

        /// <summary>
        /// EffectTarget determines who the effect targets.
        /// This can be different from the skill target, because
        /// effects can give support buffs while also dealing damage 
        /// at the same time.
        /// For example, a draining attack will give the attacker 50% of the damage done.
        /// This requires the Effect Target to be the attacker and the Skill target to be the Enemy.
        /// </summary>
        internal Target EffectTarget { get; private set; }

        /// <summary>
        /// AttributeBase determines what stats the Effect should target. <br></br>
        /// - For example, if we wanted to reduce HP, we add StatAttribute.HP in here. <br></br>
        /// - If we wanted to reduce Constitution, we add StatAttribute.Constitution and so on. <br></br><br></br>
        /// We can add multiple stats here for dynamicism.
        /// </summary>

        internal List<StatAttribute> AttributeBase { get; private set; }

        /// <summary>
        /// PercentageBase determines if the AttributeBase references the attacker's stats or the target's stats. <br></br>
        /// So, if we wanted to reduce the enemy's HP by 10% of the attacker's constitution every turn,
        /// we set PercentageBase to Target.Self (we use the attacker's constitution for damage calculcation rather than the enemy's constitution).
        /// 
        /// </summary>
        internal Target? PercentageBase { get; private set; }

        /// <summary>
        /// TargetAttributes determines what stat attributes should be affected by the effect. <br></br>
        /// Normally, Target.HP is the only stat, but if we wanted to reduce constitution, we can make a new list with Target.Constitution here.
        /// </summary>
        internal List<StatAttribute> TargetAttributes { get; private set; } = new List<StatAttribute>() { StatAttribute.HP };


        /* AttributeBase, PercentageBase, and TargetAttributes work together in order to make a fully customizable effect.
         * Allow me to show an example of a customizeable effect:
         *  - AttributeBase = new List<StatAttribute> { StatAttribute.HP, StatAttribute.SP }
         *  - PercentageBase = Target.Enemy
         *  - TargetAttributes = new List<StatAttribute> { StatAttribute.Constitution, StatAttribute.Constitution}
         *  
         *  Utilizing this, we reduce the enemy's constitution based on their HP and SP.
         *  So, if the strength were equal to 20 and strengthIsPercentage is true,
         *  we reduce the enemy's constitution by 20% of their HP and SP combined.
         *  
         *  If the strength were 20 and strengthIsPercentage is false,
         *  we reduce the enemy's constitution by 20 for each StatAttribute.Constitution that exists in TargetAttributes.
         *  Note that StrengthIsPercentage must be enabled for the system to work in this manner.
         */


        /// <summary>
        /// IsPositiveEffect determines if the skill will heal or damage the target.
        /// <br></br>
        /// - If True, the effect will heal the target.
        /// - If False, the effect will damage the target.
        /// </summary>
        /// 
        internal bool IsPositiveEffect { get; private set; } = true;

        /// <summary>
        /// A quick way of making a simple effect. Utilized in the tertiary constructor.
        /// </summary>
        internal EffectClass EffectClass { get; private set; } = EffectClass.None;

        /*
         * The base effect constructor.
         * Intializes base values for an effect.
         * 
         * Date Created: 04/20/2022
         * Last Modified: 04/20/2022
         * -------------------------
         */
        /// <summary>
        /// The base effect constructor.
        /// <br></br>
        /// Intializes base values for an effect.
        /// <br></br><br></br>
        /// Date Created: 04/20/2022
        /// <br></br>
        /// Last Modified: 04/20/2022
        /// </summary>
        public Effect() 
        {
            EffectName = "None";
            EffectDescription = "None";
            EffectStrength = 0;
            EffectLength = 0;
            EffectChance = 0;
            EffectTarget = Target.Enemy;
            StrengthIsPercentage = false;
        }


        /// <summary>
        /// The primary effect constructor.<br></br>
        /// Intializes base values based on parameter values.
        /// <br></br><br></br>
        /// Date Created: 04/20/2022 <br></br>
        /// Last Modified: 06/13/2022
        /// </summary>
        /// <param name="effectName">The Name of the Effect.</param>
        /// <param name="effectDescription">A Description of what the effect does.</param>
        /// <param name="actualEffectDescription">The displayed description of the effect in battle.</param>
        /// <param name="effectStrength">The strength of the effect.</param>
        /// <param name="effectLength">The amount of turns the effect will affect the target.</param>
        /// <param name="effectChance">The probability that the effect will be incurred on the target.</param>
        /// <param name="effectTarget">Who the effect targets. (For example: All Allies | Enemies | Self | Ally)</param>
        /// <param name="targetAttributes">The attributes being targetted.
        ///                             <br></br>For example, if we used a weakening skill, we'd probably be targetting constitution, so we'd use a new list with constitution, so <br></br> - new List[StatAttribute] {StatAttribute.Constitution}.
        ///                             <br></br> If we wanted to reduce multiple stats at once, for instance, defense, constitution, affinity, and resistance then it is possible with <br></br> - new List[StatAttribute] {StatAttribute.Defense, StatAttribute.Constitution, StatAttribute.Affinity, StatAttribute.Resistance}.</param>
        /// <param name="strengthIsPercentage">Determines if the strength parameter signifies a parcentage.</param>
        /// <param name="percentageBase">If we are basing a percentage, what value should we be referencing?
        ///                             <br></br>For example, if we had Speed in attributebase, should that be based off the enemy's speed or the caster's speed?
        ///                             <br></br>So, if we had an effect that decreased the Enemy's HP by 20% of the <b><i>caster's</i></b> speed, we'd put Target.Self for percentageBase.
        ///                             <br></br></param>
        /// <param name="canStack">Determines if the effect can affect the same target multiple times, whether or not they already have the effect already on them.</param>
        public Effect(string effectName, string effectDescription, string actualEffectDescription, int effectStrength, int effectLength, int effectChance, Target effectTarget, List<StatAttribute> targetAttributes, bool isPositiveEffect = true, bool strengthIsPercentage = false, Target? percentageBase = null, Boolean canStack = false)
        {
            EffectName = effectName;
            EffectDescription = effectDescription;
            ActualEffectDescription = actualEffectDescription;
            EffectStrength = effectStrength;
            EffectLength = effectLength;
            EffectChance = effectChance;
            EffectTarget = effectTarget;
            TargetAttributes = targetAttributes;
            StrengthIsPercentage = strengthIsPercentage;
            PercentageBase = percentageBase;
            CanStack = canStack;
        }

        /// <summary>
        /// The secondary effect constructor. <br></br>
        /// Utilizes TargetAttributes, <br></br>
        /// Intializes base values based on parameter values.<br></br><br></br>
        /// Date Created: 04/20/2022 <br></br>
        /// Last Modified: 06/13/2022
        /// </summary>
        /// <param name="effectName">The Name of the Effect.</param>
        /// <param name="effectDescription">A Description of what the effect does.</param>
        /// <param name="actualEffectDescription">The displayed description of the effect in battle.</param>
        /// <param name="effectStrength">The strength of the effect.</param>
        /// <param name="effectLength">The amount of turns the effect will affect the target.</param>
        /// <param name="effectChance">The probability that the effect will be incurred on the target.</param>
        /// <param name="effectTarget">Who the effect targets. (For example: All Allies | Enemies | Self | Ally)</param>
        /// <param name="attributeBase">If we want to reduce the target's HP by 20% of, say, the user's speed, this is used.
        ///                             <br></br>(In the example provided above, we just put in a new list containing speed.)
        ///                             <br></br> - If we wanted to reduce target HP by 20% of our Constitution and Affinity, we add both of those attributes to the list.</param>
        /// <param name="targetAttributes">The attributes being targetted.
        ///                             <br></br>For example, if we used a weakening skill, we'd probably be targetting constitution, so we'd use a new list with constitution, so <br></br> - new List[StatAttribute] {StatAttribute.Constitution}.
        ///                             <br></br> If we wanted to reduce multiple stats at once, for instance, defense, constitution, affinity, and resistance then it is possible with <br></br> - new List[StatAttribute] {StatAttribute.Defense, StatAttribute.Constitution, StatAttribute.Affinity, StatAttribute.Resistance}.</param>
        /// <param name="strengthIsPercentage">Determines if the strength parameter signifies a percentage.</param>
        /// <param name="isPositiveEffect">Determines if the effect will heal or damage the target.</param>
        /// <param name="strengthIsPercentage">Determines if the strength parameter signifies a parcentage.</param>
        /// <param name="percentageBase">If we are basing a percentage, what value should we be referencing?
        ///                             <br></br>For example, if we had Speed in attributebase, should that be based off the enemy's speed or the caster's speed?
        ///                             <br></br>So, if we had an effect that decreased the Enemy's HP by 20% of the <b><i>caster's</i></b> speed, we'd put Target.Self for percentageBase.
        ///                             <br></br></param>
        /// <param name="canStack">Determines if the effect can affect the same target multiple times, whether or not they already have the effect already on them.</param>
        /// <param name="effectClass">Determines what the effect does to the target.</param>
        public Effect(string effectName, string effectDescription, string actualEffectDescription, int effectStrength, int effectLength, int effectChance, Target effectTarget, List<StatAttribute> attributeBase, List<StatAttribute> targetAttributes, bool isPositiveEffect = true, bool strengthIsPercentage = false, Target? percentageBase = null, Boolean canStack = false, EffectClass effectClass = EffectClass.None)
        {
            EffectName = effectName;
            EffectDescription = effectDescription;
            ActualEffectDescription = actualEffectDescription;
            EffectStrength = effectStrength;
            EffectLength = effectLength;
            EffectChance = effectChance;
            EffectTarget = effectTarget;
            AttributeBase = attributeBase;
            TargetAttributes = targetAttributes;
            IsPositiveEffect = isPositiveEffect;
            StrengthIsPercentage = strengthIsPercentage;
            PercentageBase = percentageBase;
            CanStack = canStack;
            EffectClass = effectClass;
        }


        /// <summary>
        /// The tertiary effect constructor.
        /// Simplifies effect creation by utilizing the EffectClass enum.
        /// Date Created: 06/13/2022
        /// Last Modified: 06/13/2022
        /// </summary>
        /// <param name="effectName">The Name of the Effect.</param>
        /// <param name="effectDescription">A Description of what the effect does.</param>
        /// <param name="actualEffectDescription">The displayed description of the effect in battle.</param>
        /// <param name="effectStrength">The strength of the effect.</param>
        /// <param name="effectLength">The amount of turns the effect will affect the target.</param>
        /// <param name="effectChance">The probability that the effect will be incurred on the target.</param>
        /// <param name="effectClass">Utilizes the EffectClass enum to predetermine what the effect does. See the EffectClass enum for more details on what each predetermined effect does.</param>
        public Effect(string effectName, string effectDescription, string actualEffectDescription, int effectStrength, int effectLength, int effectChance, EffectClass effectClass)
        {
            EffectName = effectName;
            EffectDescription = effectDescription;
            ActualEffectDescription = actualEffectDescription;
            EffectStrength = effectStrength;
            EffectLength = effectLength;
            EffectChance = effectChance;
            EffectClass = effectClass;
        }
    }
}