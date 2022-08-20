/**       
 * -------------------------------------------------------------------
 * 	   File name: Battle.cs
 * 	Project name: I Am No Hero
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	03/20/2022	
 *            Last Modified:    08/19/2022
 * -------------------------------------------------------------------
 */

using I_Am_No_Hero.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_Am_No_Hero
{
    internal class Battle
    {
        private static Ally AllyOne { get; set; }
        private static Ally AllyTwo { get; set; }
        private static Ally AllyThree { get; set; }

        private static Enemy EnemyOne { get; set; }
        private static Enemy EnemyTwo { get; set; }
        private static Enemy EnemyThree { get; set; }

        private static List<BasePerson> TurnOrder { get; set; }

        private static BattleMenu BattleScenario { get; set; }

        private static Boolean TurnOver { get; set; }

        /// <summary>
        /// Battle Outcomes start as null as can become the following upon reaching a condition:
        /// <list type="bullet">
        /// <item>'v': Victory - All enemies in the enemy team have been incapacitated.</item>
        /// <item>'d': Defeat - All allies in the ally team have been incapacitated.</item>
        /// <item>'f': Fled - The user chose to flee the battle.</item>
        /// </list>
        /// <br></br> This property is static so BattleMenu can access BattleOutcome when the user decides to flee.
        /// <br></br> This way, we don't have to add another field to BattleMenu. BattleOutcome will revert to null after a battle.
        /// </summary>
        internal static char? BattleOutcome { get; set; } = null;


        internal static LargeMessageDialogBox msgDialog = new();


        /*
         * The primary constructor of the Battle class.
         * Intializes Ally and Enemy fields, and prepares for battle.
         * 
         * Date Created: 04/20/2022
         * Last Modified: 04/20/2022
         * ------------------------------
         * @param Ally aOne, aTwo, aThree
         * @param Enemy eOne, eTwo, eThree
         */
        public Battle(Ally aOne, Enemy eOne, Enemy eTwo = null, Enemy eThree = null, Ally aTwo = null, Ally aThree = null) 
        {
            Program.StopTrack();
            AllyOne = aOne;
            AllyTwo = aTwo;
            AllyThree = aThree;

            EnemyOne = eOne;
            EnemyTwo = eTwo;
            EnemyThree = eThree;

            TurnOrder = new() { AllyOne, AllyTwo, AllyThree, EnemyOne, EnemyTwo, EnemyThree };

            DetermineTurnOrder();
            BeginBattle();
        }

        /*
         * The Determine Turn Order method is simple.
         * It compares all combatants' speed + agility values,
         * and creates a turn order based on that value.
         * Characters will move in order according to the turn order.
         * 
         * Date Created: 04/20/2022
         * Last Modified: 04/20/2022
         */
        private void DetermineTurnOrder()
        {

            //I call this section the "Purging Section".
            foreach (BasePerson basePerson in TurnOrder.ToList<BasePerson>()) 
            {
                //We remove all null persons in the array.
                if (basePerson == null)
                {
                    TurnOrder.Remove(basePerson);
                }
                //Alongside all incapacitated persons in the array.
                else if (basePerson.ActualHP == 0) 
                {
                    TurnOrder.Remove(basePerson);
                    //If someone were to ressurect someone, we add them back to TurnOrder manually.
                }
            }

            //After the purge, we sort the list.
            TurnOrder.Sort();

            Console.WriteLine("Turn order has been determined as follows:");
            foreach (BasePerson person in TurnOrder) 
            {
                Console.WriteLine($"   - {person.Name} ({person.ActualSpeed})");
            }
        }


        private void BeginBattle()
        {
            Program.StopTrack();
            Program.PlaySoundTrack("Call to Arms", true);
            BattleScenario = new BattleMenu(AllyOne, EnemyOne, AllyTwo, EnemyTwo, AllyThree, EnemyThree);
            //BattleScenario.ShowDialog();

            //We check to see if all parties have at least one member standing.
            //While at least one stands, the battle continues.
            while (IsEntirePartyAlive(AllyOne, AllyTwo, AllyThree) && IsEntirePartyAlive(EnemyOne, EnemyTwo, EnemyThree) && BattleOutcome == null) 
            {
                foreach (BasePerson person in TurnOrder)
                {
                    Console.WriteLine(person.Name + " is going!");
                    IterateTurn(person);
                    Console.WriteLine(person.Name + " has gone!");
                }

                //We recalculate the turn order to reflect speed changes for people who used speed buffs/debuffs.
                DetermineTurnOrder();
            }

            if (IsEntirePartyAlive(AllyOne, AllyTwo, AllyThree)) 
            {
                BattleOutcome = 'f';
            }

            switch (BattleOutcome) 
            {
                case 'v':
                    //victory
                    break;
                case 'd':
                    //defeat
                    break;
                default:
                    //usually flee, but can also be an error.
                    break;
            }
            //BattleResults = battle.GetResult();
        }

        /// <summary>
        /// Allows a unit to move on their turn. 
        /// The unit moves based on their available skills.
        /// 
        /// <br><br></br></br>
        /// Date Created: 04/25/2022
        /// Last Modified: 06/15/2022
        /// </summary>
        /// 
        /// <param name="person"></param>
        private void IterateTurn(BasePerson person)
        {
            //AllyTarget and EnemyTarget help simplify who the person targets.
            Ally allyTarget = AllyOne;
            Enemy enemyTarget = EnemyOne;

            Random random = new Random();

            if (person.GetType() == typeof(Enemy))
            {
                //Iterate an enemy's turn.
                Random rng = new Random();

                //Basically, we add all the skills that the enemy currently has.
                int numberOfSkills = person.SkillSet.BaseSkills.Count + person.SkillSet.SPSkills.Count + person.SkillSet.SupportSkills.Count - 3;

                Skill skillUsed = new();
                SpecialSkill SPSkillUsed = new();
                bool UsingNormalSkill = true;

                //Get a random number from 0-2.
                //This randomly decides if the enemy will use a Base Skill, Special Skill, or a Support Skill.
                int temp = rng.Next(3);


                bool hasEnoughSPForSupportSkill = false;
                bool hasEnoughSPForSPSkill = false;

                //We check to make sure the person has enough SP for at least 1 support skill.
                foreach (SpecialSkill skill in person.SkillSet.SupportSkills) 
                {
                    if (skill.SPCost <= person.ActualSP) 
                    {
                        hasEnoughSPForSupportSkill = true;
                    }
                }

                //We check to make sure the person has enough SP for at least 1 SP skill.
                foreach (SpecialSkill skill in person.SkillSet.SPSkills)
                {
                    if (skill.SPCost <= person.ActualSP)
                    {
                        hasEnoughSPForSPSkill = true;
                    }
                }

                //Determines which skill the enemy will use. We randomly pick.
                switch (temp) 
                {
                    case 0:
                        if (person.SkillSet.SupportSkills.Count > 0 && hasEnoughSPForSupportSkill)
                        {
                            SPSkillUsed = person.SkillSet.SupportSkills[rng.Next(person.SkillSet.SupportSkills.Count)];
                            UsingNormalSkill = false;
                        }
                        else 
                        {
                            //default to the base skill, which every skillset has.
                            skillUsed = person.SkillSet.BaseSkills[rng.Next(person.SkillSet.BaseSkills.Count)];
                            UsingNormalSkill = true;
                        }
                        break;
                    case 1:
                        if (person.SkillSet.SPSkills.Count > 0 && hasEnoughSPForSPSkill)
                        {
                            SPSkillUsed = person.SkillSet.SPSkills[rng.Next(person.SkillSet.SPSkills.Count)];
                            UsingNormalSkill = false;
                        }
                        else 
                        {
                            //default to the base skill, which every skillset has.
                            skillUsed = person.SkillSet.BaseSkills[rng.Next(person.SkillSet.BaseSkills.Count)];
                            UsingNormalSkill = true;
                        }
                        break;
                    default:
                        skillUsed = person.SkillSet.BaseSkills[rng.Next(person.SkillSet.BaseSkills.Count)];
                        UsingNormalSkill = true;
                        break;
                }

                //Next, the enemy determine who the enemy targets.
                temp = rng.Next(3);

                switch (skillUsed.Target)
                {
                    //The skill targets the other team.
                    //Context: The enemy is using a skill that targets the Ally team.
                    case Target.Enemy:
                        switch (temp)
                        {
                            case 0:
                                if (AllyThree is not null)
                                {
                                    allyTarget = AllyThree;
                                }
                                else if (AllyTwo is not null && AllyTwo.ActualHP > 0)
                                {
                                    allyTarget = AllyTwo;
                                }
                                else
                                {
                                    allyTarget = AllyOne;
                                }
                                break;
                            case 1:
                                if (AllyTwo is not null && AllyTwo.ActualHP > 0)
                                {
                                    allyTarget = AllyTwo;
                                }
                                else
                                {
                                    allyTarget = AllyOne;
                                }
                                break;
                            default:
                                allyTarget = AllyOne;
                                break;
                        }
                        break;
                    //The skill targets the enemy's team.
                    //Context: The enemy is using a skill that targets one of their allies.
                    case Target.Ally:
                        switch (temp)
                        {
                            case 0:
                                if (EnemyThree is not null)
                                {
                                    enemyTarget = EnemyThree;
                                }
                                else if (EnemyTwo is not null)
                                {
                                    enemyTarget = EnemyTwo;
                                }
                                else
                                {
                                    enemyTarget = EnemyOne;
                                }
                                break;
                            case 1:
                                if (AllyTwo is not null)
                                {
                                    enemyTarget = EnemyTwo;
                                }
                                else
                                {
                                    enemyTarget = EnemyOne;
                                }
                                break;
                            default:
                                enemyTarget = EnemyOne;
                                break;
                        }
                        break;
                    default:
                        allyTarget = AllyOne;
                        enemyTarget = EnemyOne;
                        break;
                }

                int skillDamage = skillUsed.BaseDamage;
                char damageType = skillUsed.DamageType;
                int accuracy = skillUsed.Accuracy;
                List<Effect> effects = skillUsed.SkillEffects;
                List<Effect> triggeredEffects = new();

                if (effects != null)
                {
                    //We randomly generate a number and test it against proc chance.
                    foreach (Effect effect in effects)
                    {
                        int randomNumber = random.Next(100);

                        if (effect.EffectChance > randomNumber)
                        {
                            //Increasing the effect's effect chance increases the proability of proccing the effect on the target.
                            //Here, since it successfully procced, we add true to the triggeredEffects list.
                            triggeredEffects.Add(effect);
                        }
                        else
                        {
                            //In this case, the effect did not successfully proc, and so we add nothing to the triggeredEffects list.
                        }
                    }
                }

                int allyDefense = allyTarget.ActualDefense;
                int allyResistance = allyTarget.ActualResistance;
                //The damage can vary by -15 to 15.
                //This way, we don't repetitively deal
                //the same damage when casting the same move.
                int damageVariable = rng.Next(-15, 16);

                double enemyDamageReduction = EnemyOne.ActualDamageReduction;

                Console.WriteLine("Skill Damage: " + skillDamage);
                Console.WriteLine("Damage Variable: " + damageVariable);
                Console.WriteLine("Ally Defense: " + allyDefense);

                //First, we see if we actually hit our skill.
                //rng.Next(100) gets a number from 0 - 99.
                //If we get less than accuracy, we use the skill.
                if (rng.Next(100) < accuracy)
                {
                    int damageDone = (int)(skillDamage + damageVariable);

                    int physicalDamageMitigated = (int)(allyDefense + (damageDone * enemyTarget.ActualDamageReduction));
                    int magicalDamageMitigated = (int)(allyResistance + (damageDone * enemyTarget.ActualDamageReduction));

                    int physicalDamageTaken = damageDone - physicalDamageMitigated;
                    int magicalDamageTaken = damageDone - magicalDamageMitigated;


                    if (skillUsed.IsHealingSkill)
                    {
                        //TODO - Implement bypass defense/resistance for heals.
                        switch (damageType)
                        {
                            case 'M':
                                if (magicalDamageTaken > allyTarget.ActualHP)
                                {
                                    magicalDamageTaken = allyTarget.ActualHP;
                                    allyTarget.ActualHP = 0;
                                }
                                else
                                {
                                    if (magicalDamageTaken > 0)
                                    {
                                        allyTarget.ActualHP -= magicalDamageTaken;
                                    }
                                    else
                                    {
                                        //If the damage done would be less than 0, we deal 0 damage
                                        //instead of, say, -4 damage (which heals the target).
                                        magicalDamageTaken = 0;
                                    }
                                }

                                msgDialog.label1.Text = $"{allyTarget.ArticleName} took {magicalDamageTaken}HP of Magical damage!";
                                msgDialog.ShowDialog();
                                //msgDialog.ShowDialog();
                                Console.WriteLine($"{allyTarget.ArticleName} took {magicalDamageTaken}HP of Magical damage!");
                                break;

                            //by default, just attack using physical damage.
                            default:
                                if (physicalDamageTaken > allyTarget.ActualHP)
                                {
                                    physicalDamageTaken = allyTarget.ActualHP;
                                    allyTarget.ActualHP = 0;
                                }
                                else
                                {
                                    if (physicalDamageTaken > 0)
                                    {
                                        allyTarget.ActualHP -= physicalDamageTaken;
                                    }
                                    else
                                    {
                                        //If the damage done would be less than 0, we deal 0 damage
                                        //instead of, say, -4 damage (which heals the target).
                                        physicalDamageTaken = 0;
                                    }
                                }

                                ClearMessageBox();
                                if (UsingNormalSkill)
                                {
                                    StringBuilder sb = new StringBuilder();
                                    sb.Append($"{enemyTarget.ArticleName} used the Skill {skillUsed.SkillName} on {allyTarget.ArticleName}!" +
                                        $"\n(Description: {skillUsed.SkillDescription} | Deals {skillUsed.BaseDamage}HP of Physical Damage)" +
                                        $"\n{allyTarget.ArticleName}'s Defense ({allyTarget.ActualDefense}) and Damage Reduction stat ({allyTarget.ActualDamageReduction}), reduced the incoming damage by {physicalDamageMitigated}" +
                                        $"\n{allyTarget.ArticleName} took {physicalDamageTaken}HP of Physical damage!");


                                    TriggerEffects(triggeredEffects, person, allyTarget);
                                    if (triggeredEffects.Count > 0)
                                    {
                                        sb.Append($"\n\n{allyTarget.Name} is now suffering the following effects: ");
                                        foreach (Effect effect in triggeredEffects)
                                        {
                                            sb.Append($"\n - {effect.EffectName} \n({effect.EffectDescription})");
                                        }
                                    }

                                    msgDialog.label1.Text = sb.ToString();
                                    msgDialog.ShowDialog();
                                }
                                else 
                                {
                                    StringBuilder sb = new StringBuilder();
                                    sb.Append($"{enemyTarget.ArticleName} used the Special Skill {SPSkillUsed.SkillName} on {allyTarget.ArticleName}!" +
                                        $"\n(Description: {SPSkillUsed.SkillDescription} | Deals {SPSkillUsed.BaseDamage}HP of Physical Damage)" +
                                        $"\n{allyTarget.ArticleName}'s Defense ({allyTarget.ActualDefense}) and Damage Reduction stat ({allyTarget.ActualDamageReduction}) reduced the incoming damage by {physicalDamageMitigated}" +
                                        $"\n{allyTarget.ArticleName} took {physicalDamageTaken}HP of Physical damage!");


                                    TriggerEffects(triggeredEffects, person, allyTarget);
                                    if (triggeredEffects.Count > 0) 
                                    {
                                        sb.Append($"\n\n{allyTarget.Name} is now suffering the following effects: ");
                                        foreach (Effect effect in triggeredEffects)
                                        {
                                            sb.Append($"\n - {effect.EffectName} \n({effect.EffectDescription})");
                                        }
                                    }

                                    msgDialog.label1.Text = sb.ToString();
                                    msgDialog.ShowDialog();
                                }
                                
                                //msgDialog.ShowDialog();
                                Console.WriteLine($"{allyTarget.ArticleName} took {physicalDamageTaken}HP of Physical damage!");
                                break;

                                //TODO - Add MsgDialog box to Special Attacks.
                        }
                    }
                    else 
                    {
                        //If the skill is not a healing skill.
                        switch (damageType)
                        {
                            case 'M':
                                if (allyTarget.ActualHP - magicalDamageTaken <= 0)
                                {
                                    magicalDamageTaken = allyTarget.ActualHP;
                                    allyTarget.ActualHP = 0;
                                }
                                else
                                {
                                    if (magicalDamageTaken > 0)
                                    {
                                        allyTarget.ActualHP -= magicalDamageTaken;
                                    }
                                    else
                                    {
                                        //If the damage done would be less than 0, we deal 0 damage
                                        //instead of, say, -4 damage (which heals the target).
                                        magicalDamageTaken = 0;
                                    }
                                }

                                msgDialog.label1.Text = $"{allyTarget.ArticleName} took {magicalDamageTaken}HP of Physical damage!";
                                msgDialog.ShowDialog();
                                //msgDialog.ShowDialog();
                                Console.WriteLine($"{allyTarget.ArticleName} took {magicalDamageTaken}HP of Magical damage!");
                                break;

                            //by default, just attack using physical damage.
                            default:
                                if (allyTarget.ActualHP - physicalDamageTaken <= 0)
                                {
                                    physicalDamageTaken = allyTarget.ActualHP;
                                    allyTarget.ActualHP = 0;
                                }
                                else
                                {
                                    if (physicalDamageTaken > 0)
                                    {
                                        allyTarget.ActualHP -= physicalDamageTaken;
                                    }
                                    else
                                    {
                                        physicalDamageTaken = 0;
                                    }
                                }


                                ClearMessageBox();
                                if (UsingNormalSkill)
                                {
                                    StringBuilder sb = new StringBuilder();
                                    sb.Append($"{enemyTarget.ArticleName} used the Skill {skillUsed.SkillName} on {allyTarget.ArticleName}!" +
                                        $"\n(Description: {skillUsed.SkillDescription} | Deals {skillUsed.BaseDamage}HP of Physical Damage)" +
                                        $"\n{allyTarget.Article} {allyTarget.Name}'s Defense ({allyTarget.ActualDefense}) and Damage Reduction stat ({allyTarget.ActualDamageReduction}), reduced the incoming damage by {physicalDamageMitigated}" +
                                        $"\n{allyTarget.Article} {allyTarget.Name} took {physicalDamageTaken}HP of Physical damage!");


                                    TriggerEffects(triggeredEffects, person, allyTarget);
                                    if (triggeredEffects.Count > 0)
                                    {
                                        sb.Append($"\n\n{allyTarget.Name} is now suffering the following effects: ");
                                        foreach (Effect effect in triggeredEffects)
                                        {
                                            sb.Append($"\n - {effect.EffectName} \n({effect.EffectDescription})");
                                        }
                                    }

                                    msgDialog.label1.Text = sb.ToString();
                                    msgDialog.ShowDialog();
                                }
                                else
                                {
                                    StringBuilder sb = new StringBuilder();
                                    sb.Append($"{enemyTarget.ArticleName} used the Special Skill {SPSkillUsed.SkillName} on {allyTarget.ArticleName}!" +
                                        $"\n(Description: {SPSkillUsed.SkillDescription} | Deals {SPSkillUsed.BaseDamage}HP of Physical Damage)" +
                                        $"\n{allyTarget.ArticleName}'s Defense ({allyTarget.ActualDefense}) and Damage Reduction stat ({allyTarget.ActualDamageReduction}), reduced the incoming damage by {physicalDamageMitigated}" +
                                        $"\n{allyTarget.ArticleName} took {physicalDamageTaken}HP of Physical damage!");


                                    TriggerEffects(triggeredEffects, person, allyTarget);
                                    if (triggeredEffects.Count > 0)
                                    {
                                        sb.Append($"\n\n{allyTarget.Name} is now suffering the following effects: ");
                                        foreach (Effect effect in triggeredEffects)
                                        {
                                            sb.Append($"\n - {effect.EffectName} \n({effect.EffectDescription})");
                                        }
                                    }

                                    msgDialog.label1.Text = sb.ToString();
                                    msgDialog.ShowDialog();

                                }

                                //msgDialog.ShowDialog();
                                Console.WriteLine($"{allyTarget.ArticleName} took {physicalDamageTaken}HP of Physical damage!");
                                break;
                        }
                    }

                    if (allyTarget.ActualHP == 0)
                    {
                        Console.WriteLine($"{allyTarget.ArticleName} fainted!\nThey can no longer fight in this battle.");
                    }

                }
                else
                {
                    //The enemy missed the skill!
                    MessageDialog msgDialog = new MessageDialog();
                    msgDialog.label1.Text = $"{person.Name} tried to attack {allyTarget.Name}, but missed!";
                    msgDialog.ShowDialog();
                }
            }
            else
            {
                if (person == AllyOne)
                {
                    TurnOver = false;
                    while (!TurnOver) 
                    {
                        BattleScenario.UsedTurn = false;
                        BattleScenario.ShowDialog();
                        if (BattleScenario.UsedTurn) 
                        {
                            TurnOver = true;
                            BattleScenario.Hide();
                        }
                    }
                }
                else 
                {
                    
                }
            }

            ClearMessageBox();

        }

        /// <summary>
        /// The TriggerEffects method manages incurring effects on BasePersons during battles.
        /// <br></br>Effects are tracked by inspecting every battlefield participant.
        /// </summary>
        /// <param name="triggeredEffects">The List of Effects that were successfully incurred on the target.</param>
        /// <param name="caster">The BasePerson incurring the effect on the target.
        /// <br></br>This is necessary to calculate which team they are on and who they are.</param>
        /// <param name="target">The BasePerson being targetted by the caster. 
        /// <br></br>This may be an Ally or Enemy.</param>
        internal static void TriggerEffects(List<Effect> triggeredEffects, BasePerson caster, BasePerson target)
        {
            Random rand = new Random();
            int randomNumber = 0;

            foreach (Effect effect in triggeredEffects)
            {
                switch(effect.EffectTarget)
                {
                    case Target.Self:
                        caster.StatusEffects.Add(effect);
                        break;
                    case Target.Ally:

                        //If an ally is attacking an enemy, the effect is randomly given to one of the other two allies.
                        if (caster.GetType() == typeof(Ally) && target.GetType() == typeof(Enemy))
                        {
                            //randomly incur the effect on one of two allies, if they are present.
                            randomNumber = rand.Next(2);

                            if (caster == Battle.AllyOne)
                            {
                                if (randomNumber == 0 && IsAllyTwoAlive())
                                {
                                    AllyTwo.StatusEffects.Add(effect);
                                }
                                else
                                {
                                    if (IsAllyThreeAlive())
                                    {
                                        AllyThree.StatusEffects.Add(effect);
                                    }
                                    else
                                    {
                                        AllyTwo.StatusEffects.Add(effect);
                                    }
                                }
                            }
                            else if (caster == EnemyTwo)
                            {
                                if (randomNumber == 0 && IsAllyOneAlive())
                                {
                                    AllyOne.StatusEffects.Add(effect);
                                }
                                else
                                {
                                    if (IsAllyThreeAlive())
                                    {
                                        AllyThree.StatusEffects.Add(effect);
                                    }
                                    else
                                    {
                                        AllyOne.StatusEffects.Add(effect);
                                    }
                                }
                            }
                            else
                            {
                                if (randomNumber == 0 && IsAllyOneAlive())
                                {
                                    AllyOne.StatusEffects.Add(effect);
                                }
                                else
                                {
                                    if (IsAllyTwoAlive())
                                    {
                                        AllyTwo.StatusEffects.Add(effect);
                                    }
                                    else
                                    {
                                        AllyOne.StatusEffects.Add(effect);
                                    }
                                }
                            }
                        }
                        //If an enemy is attacking an ally, the effect is randomly given to one of the other two enemies.
                        else if (caster.GetType() == typeof(Enemy) && target.GetType() == typeof(Ally))
                        {
                            //randomly incur the effect on an enemy, if they are present and are not the caster.
                            randomNumber = rand.Next(2);

                            if (caster == EnemyOne)
                            {
                                if (randomNumber == 0 && IsEnemyTwoAlive())
                                {
                                    EnemyTwo.StatusEffects.Add(effect);
                                }
                                else
                                {
                                    if (IsEnemyThreeAlive())
                                    {
                                        EnemyThree.StatusEffects.Add(effect);
                                    }
                                    else
                                    {
                                        EnemyTwo.StatusEffects.Add(effect);
                                    }
                                }
                            }
                            else if (caster == EnemyTwo)
                            {
                                if (randomNumber == 0 && IsEnemyOneAlive())
                                {
                                    EnemyOne.StatusEffects.Add(effect);
                                }
                                else
                                {
                                    if (IsEnemyThreeAlive())
                                    {
                                        EnemyThree.StatusEffects.Add(effect);
                                    }
                                    else
                                    {
                                        EnemyOne.StatusEffects.Add(effect);
                                    }
                                }
                            }
                            else
                            {
                                if (randomNumber == 0 && IsEnemyOneAlive())
                                {
                                    EnemyOne.StatusEffects.Add(effect);
                                }
                                else
                                {
                                    if (IsEnemyTwoAlive())
                                    {
                                        EnemyTwo.StatusEffects.Add(effect);
                                    }
                                    else
                                    {
                                        EnemyOne.StatusEffects.Add(effect);
                                    }
                                }
                            }
                        }
                        //If the character has no allies, we don't incur the effect on anything.

                        //If an ally is targetting an ally, the effect is given to the targetted ally.
                        else if (caster.GetType() == typeof(Ally) && target.GetType() == typeof(Ally)) 
                        {
                            target.StatusEffects.Add(effect);
                        
                        }
                        //If an enemy is targetting an enemy, the effect is given to the targetted enemy.
                        else //if (caster.GetType() == typeof(Enemy) && target.GetType() == typeof(Enemy)) 
                        {
                            target.StatusEffects.Add(effect);
                        }
                        break;
                        ///////////////////////////FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF

                    case Target.Enemy:
                        if (caster.GetType() == typeof(Ally) && target.GetType() == typeof(Enemy))
                        {
                            //if who we have targetted is an enemy, we add the status effect to that enemy.
                            target.StatusEffects.Add(effect);
                        }
                        else 
                        {
                            //if we're, for instance, targetting an ally, we randomly choose an enemy to incur the effect on.
                            randomNumber = rand.Next(3);
                            if (randomNumber == 0 && IsEnemyThreeAlive())
                            {
                                EnemyThree.StatusEffects.Add(effect);
                            }
                            else
                            {
                                if (randomNumber == 1 && IsEnemyTwoAlive())
                                {
                                    EnemyTwo.StatusEffects.Add(effect);
                                }
                                else 
                                {
                                    EnemyOne.StatusEffects.Add(effect);
                                }
                            }
                        }
                        break;

                    case Target.AllAllies:
                        if (IsAllyOneAlive())
                            AllyOne.StatusEffects.Add(effect);
                        if (IsAllyTwoAlive())
                            AllyTwo.StatusEffects.Add(effect);
                        if (IsAllyThreeAlive())
                            AllyThree.StatusEffects.Add(effect);
                        break;

                    case Target.AllEnemies:
                        if (IsEnemyOneAlive())
                            EnemyOne.StatusEffects.Add(effect);
                        if (IsEnemyTwoAlive())
                            EnemyTwo.StatusEffects.Add(effect);
                        if (IsEnemyThreeAlive())
                            EnemyThree.StatusEffects.Add(effect);
                        break;

                    case Target.All:
                        if (IsAllyOneAlive())
                            AllyOne.StatusEffects.Add(effect);
                        if(IsAllyTwoAlive())
                            AllyTwo.StatusEffects.Add(effect);
                        if(IsAllyThreeAlive())
                            AllyThree.StatusEffects.Add(effect);
                        if(IsEnemyOneAlive())
                            EnemyOne.StatusEffects.Add(effect);
                        if(IsEnemyTwoAlive())
                            EnemyTwo.StatusEffects.Add(effect);
                        if(IsEnemyThreeAlive())
                            EnemyThree.StatusEffects.Add(effect);
                        break;
                    default:
                        Console.WriteLine("It seems we encountered an error. " +
                            "\nTarget: " + effect.EffectTarget + 
                            $"\nEffect: {effect.EffectName}, " +
                            $"\n({effect.EffectDescription})\n " +
                            $"The Effect was not procced at this time.");
                        break;
                }
                target.StatusEffects.Add(effect);
            }
        }


       


        /// <summary>
        /// An assistant method that checks if all base persons on the battlefield are alive.
        /// </summary>
        /// <returns></returns>
        private Boolean IsEntirePartyAlive(BasePerson bp1, BasePerson bp2 = null, BasePerson bp3 = null) 
        {
            //We check to see if the entire party is alive.
            //First, we start with one person in the party.
            if (bp2 == null && bp3 == null)
            {
                if (bp1.ActualHP > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (bp3 == null && bp2 != null)
            {
                if (bp1.ActualHP > 0 || bp2.ActualHP > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (bp3 != null && bp2 == null)
            {
                if (bp1.ActualHP > 0 || bp3.ActualHP > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else 
            {
                if (bp2 != null && bp3 != null)
                {
                    if (bp1.ActualHP > 0 || bp2.ActualHP > 0 || bp3.ActualHP > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else 
                {
                    Console.WriteLine("Looks like there was an error. We couldn't calculate HP values.");
                    Console.WriteLine($"BP1 HP: {bp1.ActualHP}");
                    if (bp2 != null) 
                    {
                        Console.WriteLine($"BP2 HP: {bp2.ActualHP}");
                    }
                    if (bp3 != null)
                    {
                        Console.WriteLine($"BP3 HP: {bp3.ActualHP}");
                    }

                    //a debug section.
                    if (bp1.GetType() == typeof(Enemy))
                    {
                        Console.WriteLine($"Context: Enemy");
                    }
                    else 
                    {
                        Console.WriteLine($"Context: Ally");
                    }

                    return false;
                }
            }
        }

        /// <summary>
        /// Determines if AllyOne can fight and is present in battle.
        /// 
        /// <br><br></br></br>
        /// Date Created: 06/15/2022
        /// <br>Last Modified: 06/15/2022</br>
        /// </summary>
        /// <returns>
        ///     True - If AllyOne is not null and their HP is greater than 0. 
        /// <br>False - Otherwise</br>
        /// </returns>
        internal static Boolean IsAllyOneAlive() 
        {
            if (AllyOne != null && AllyOne.ActualHP > 0) 
            {
                return true; 
            }
            return false;
        }

        /// <summary>
        /// Determines if AllyTwo can fight and is present in battle.
        /// 
        /// <br><br></br></br>
        /// Date Created: 06/15/2022
        /// <br>Last Modified: 06/15/2022</br>
        /// </summary>
        /// <returns>
        ///     True - If AllyTwo is not null and their HP is greater than 0. 
        /// <br>False - Otherwise</br>
        /// </returns>
        internal static Boolean IsAllyTwoAlive()
        {
            if (AllyTwo != null && AllyTwo.ActualHP > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if AllyThree can fight and is present in battle.
        /// 
        /// <br><br></br></br>
        /// Date Created: 06/15/2022
        /// <br>Last Modified: 06/15/2022</br>
        /// </summary>
        /// <returns>
        ///     True - If AllyThree is not null and their HP is greater than 0. 
        /// <br>False - Otherwise</br>
        /// </returns>
        internal static Boolean IsAllyThreeAlive()
        {
            if (AllyThree != null && AllyThree.ActualHP > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if EnemyOne can fight and is present in battle.
        /// 
        /// <br><br></br></br>
        /// Date Created: 06/15/2022
        /// <br>Last Modified: 06/15/2022</br>
        /// </summary>
        /// <returns>
        ///     True - If EnemyOne is not null and their HP is greater than 0. 
        /// <br>False - Otherwise</br>
        /// </returns>
        internal static Boolean IsEnemyOneAlive()
        {
            if (EnemyOne != null && EnemyOne.ActualHP > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if EnemyTwo can fight and is present in battle.
        /// 
        /// <br><br></br></br>
        /// Date Created: 06/15/2022
        /// <br>Last Modified: 06/15/2022</br>
        /// </summary>
        /// <returns>
        ///     True - If EnemyTwo is not null and their HP is greater than 0. 
        /// <br>False - Otherwise</br>
        /// </returns>
        internal static Boolean IsEnemyTwoAlive()
        {
            if (EnemyTwo != null && EnemyTwo.ActualHP > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Determines if EnemyThree can fight and is present in battle.
        /// 
        /// <br><br></br></br>
        /// Date Created: 06/15/2022
        /// <br>Last Modified: 06/15/2022</br>
        /// </summary>
        /// <returns>
        ///     True - If EnemyThree is not null and their HP is greater than 0. 
        /// <br>False - Otherwise</br>
        /// </returns>
        internal static Boolean IsEnemyThreeAlive()
        {
            if (EnemyThree != null && EnemyThree.ActualHP > 0)
            {
                return true;
            }
            return false;
        }



        /// <summary>
        /// The ClearMessageBox method clears any contents within the msgDialog LargeMessageDialogBox.
        /// </summary>
        internal static void ClearMessageBox() 
        {
            msgDialog = new();        
        }
    }
}
