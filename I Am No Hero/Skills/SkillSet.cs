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
    internal class SkillSet
    {
        internal List<Skill> BaseSkills { get; set; } = new();
        internal List<SpecialSkill> SPSkills { get; set; } = new();
        internal List<SpecialSkill> SupportSkills { get; set; } = new();

        //Only 5 basic moves can be equipped at once,
        internal Skill[] CurrentBasicSet { get; set; } = new Skill[5];

        internal SpecialSkill[] CurrentSpecialSet { get; set; } = new SpecialSkill[4];

        internal SpecialSkill[] CurrentSupportSet { get; set; } = new SpecialSkill[3];

        /*
         * The base constructor for the SkillSet class.
         * Adds some base skills to the Skills list.
         * 
         * Date Created: 04/20/2022
         * Last Modified: 04/20/2022
         */
        public SkillSet() 
        {
            BaseSkills.Add(new Skill());
            BaseSkills.Add(new Skill());
            BaseSkills.Add(new Skill());
        }


        /*
         * The primary constructor for the SkillSet class.
         * Adds skills to the Skills list based on the class.
         * 
         * Date Created: 04/20/2022
         * Last Modified: 04/27/2022
         */
        public SkillSet(Specialization spec, int affinity = 0, int constitution = 0, int speed = 0, int strength = 0, int mana = 0, int agility = 0)
        {
            switch (spec)
            {
                //Basic Classes
                case Specialization.Acolyte:
                    BaseSkills.Add(new Skill("Simple Cast", "Cast a magic projectile at the enemy.", affinity, 90, null, Target.Enemy, 'M'));

                    //Basic Heal's effect is Restoration, which heals 5% of the ally's HP per turn.
                    BaseSkills.Add(new Skill("Basic Heal", "Cast Restorative Magic on an Ally.", (int)(affinity * 0.9), 100,
                        new List<Effect>
                        {
                            new Effect ("Restoration", "Heal the afflicted user for 5% of their HP every turn.", "This unit is healing 5% of their HP every turn.", 5, 3, 100, Target.Ally, new List<StatAttribute> { StatAttribute.HP }, true)
                        }, Target.SelfORAlly, 'M'));

                    BaseSkills.Add(new Skill("Weaken", "Weaken an Enemy's weapon, causing them to deal less Physical DMG.", (int)(affinity * 0.5), 80,
                        new List<Effect>
                        {
                            new Effect ("Brittle Weapon", "Make the target's weapon appear Brittle, causing them to deal less Physical Damage.", "\"My weapon looks weak... perhaps I should be careful when swinging it...\"", 25, 3, 55, Target.Enemy, new List<StatAttribute> { StatAttribute.Constitution }, false, true, Target.Enemy)
                        }, Target.Enemy, 'M'));

                    SPSkills.Add(new SpecialSkill("Fireball", "Launch a Fireball at the Enemy.", (int)(affinity * 1.2), 80,
                        new List<Effect>
                        {
                            new Effect("Burning", "Burn the target for 3% of their HP for 1 turn.", "HOT! HOT! Gotta put it out NOW!", 3, 1, 50, Target.Enemy, new List<StatAttribute> { StatAttribute.HP }, false, true, Target.Enemy),
                            new Effect("Searing Pain", "Reduce the target's constitution and affinity by 15%.", "The unplesant burn has left a painful mark on the target.", 15, 3, 50, Target.Enemy, new List<StatAttribute> { StatAttribute.Affinity, StatAttribute.Constitution }, false, true, Target.Enemy)
                        }, Target.Enemy, 15, 'M'));
                    break;

                case Specialization.Myrmidon:
                    BaseSkills.Add(new Skill("Strike", "Strike at the enemy with a sword.", (int)(constitution + (strength * 5)), 95, null, Target.Enemy));
                    BaseSkills.Add(new Skill("Jab", "Jab the sword into an enemy.", (int)(constitution * 0.5), 80,
                        new List<Effect>
                        {
                            new Effect("Minor Bleeding", "The target takes 1% of their HP as damage for 3 turns.", "Looks like some red liquid's coming out of that wound.", 1, 3, 75, Target.Enemy, new List<StatAttribute> { StatAttribute.HP }, false, true, Target.Enemy)
                        }, Target.Enemy));

                    BaseSkills.Add(new Skill("Detect", "Prepare for an incoming Enemy Attack. The unit also gains 20% of their SP upon using this move.", 0, 100, 
                        new List<Effect> 
                        { 
                            new Effect("Detection", "Apply Parry Focus to yourself, ensuring that an attack on this unit in the next turn is parried.", "This unit is focused and ready to parry the next attack.", 100, 1, 100, Target.Self, new List<StatAttribute> { StatAttribute.ParryFocus }, true, true, Target.Self),
                            new Effect("Focus", "Restore 20% of your SP immediately.", "This unit has restored 20% of their SP.", 20, 0, 100, Target.Self, new List<StatAttribute> { StatAttribute.SP }, true, true, Target.Self)
                        }, Target.Self));

                    SPSkills.Add(new SpecialSkill("Jump Slash", "Slash the enemy with the assistance of Gravity.", (int)(constitution * 1.5 + strength * 5), 80,
                        new List<Effect>
                        {
                            new Effect("Jump Slash Courage", "The energy of a Jump Slash gives warriors more energy. Constitution increased by 10%.", "\"That Jump Slash was AMAZING. I've gotta try again!\"", 10, 1, 100, Target.Self, new List<StatAttribute> { StatAttribute.Constitution }, true, true, Target.Self, true)
                        }, Target.Enemy, 10));
                    break;

                case Specialization.Thief:
                    BaseSkills.Add(new Skill("Slash", "Slash at the enemy with a knife.", constitution + (agility * 2), 95, null, Target.Enemy));
                    BaseSkills.Add(new Skill("Jab", "Jab a knife into an enemy.", (int)(constitution * 0.5), 85,
                        new List<Effect>
                        {
                            new Effect("Bleeding", "The target takes 2% of their HP as damage for 3 turns.", "Some red liquid's coming out of that wound.", 2, 3, 75, Target.Enemy, new List<StatAttribute> { StatAttribute.HP }, true, true, Target.Enemy, true)
                        }, Target.Enemy));

                    BaseSkills.Add(new Skill("Trip", "Trip an enemy, dealing damage equal to their defense.", 0, 100, 
                        new List<Effect> 
                        { 
                            new Effect("Tripped", "The target unit trips, dealing damage equal to their defense.", "Oww... Falling on that armor is rough.", 100, 0, 100, Target.Enemy, new List<StatAttribute> { StatAttribute.Defense }, new List<StatAttribute> { StatAttribute.HP}, false, true, Target.Enemy),
                            new Effect("Slip Recovery", "The target loses 20% of their SP and Speed temporarily.", "After a dreadful fall, this unit must refocus on the battle.", 20, 0, 100, Target.Enemy, new List<StatAttribute> { StatAttribute.SP, StatAttribute.Speed }, false, true, Target.Enemy)
                        }, Target.Self));

                    SPSkills.Add(new SpecialSkill("Gut", "Thrust your knife deeply into the enemy.", (int)(agility * 5), 80,
                        new List<Effect>
                        {
                            new Effect("Bleeding", "The target takes 3% of their HP as damage for 3 turns.", "Quite a bit of red liquid's coming out of that wound.", 2, 3, 70, Target.Enemy, new List<StatAttribute> { StatAttribute.HP }, false, true, Target.Enemy, true),
                            new Effect("Wounded", "By knife, I meant the one that slices things. Ow.", "Bleeding for 10 HP every 3 turns.", 10, 3, 95, Target.Enemy, new List<StatAttribute> { StatAttribute.HP }, false, false, Target.Enemy, true)
                        }, Target.Enemy, 10));
                    break;

                case Specialization.Cleric:
                    BaseSkills.Add(new Skill("Siphon", "Leech the Enemy's Mana.", (int)(affinity), 95,
                        new List<Effect>
                        {
                            new Effect("Weakened", "The enemy is weakened for 20% of their stolen SP.", "I feel somewhat weaker after that spell.", 20, 2, 75, Target.Enemy, new List<StatAttribute> { StatAttribute.SP }, new List<StatAttribute> { StatAttribute.Constitution }, false, true, Target.DamageDealtEnemy, true),
                            new Effect("SP Drain", "The user gains 50% of the SP based on the damage dealt.", "The user gained 50% of the SP from damage.", 50, 0, 100, Target.Self, new List<StatAttribute> { StatAttribute.SP }, true, true, Target.DamageDealtEnemy, false)
                        }, Target.Enemy, 'M'));
                    BaseSkills.Add(new Skill("Club", "Attack the enemy with your staff.", (int)(constitution), 85,
                        new List<Effect>
                        {
                            new Effect("Stunned", "Stun the target! They cannot act for 2 turns.", "The world's kinda... wobbly right now. Maybe I should sit it out for a moment.", 0, 2, 40, Target.Enemy, null, false, true, Target.Enemy, true)
                        }, Target.Enemy));

                    SupportSkills.Add(new SpecialSkill("Mend", "Mend an ally for twice your affinity.", affinity * 2, 100,
                        new List<Effect>
                        {
                            new Effect("Mending", "The resulting mend continues to mend the unit for 20HP for 3 turns.", "Healing for 20HP for 3 turns.", 20, 3, 100, Target.Ally, null, true, false, null, true),
                        }, Target.Self, 45, 'M', true));

                    SPSkills.Add(new SpecialSkill("Gut", "Thrust your knife deeply into the enemy.", (int)(constitution), 80,
                        new List<Effect>
                        {
                            new Effect("Bleeding", "The target takes 3% of their HP as damage for 3 turns.", "Quite a bit of red liquid's coming out of that wound.", 2, 3, 75, Target.Enemy, new List<StatAttribute> { StatAttribute.HP }, false, true, Target.Enemy, true),
                        }, Target.Enemy, 10));
                    break;

                case Specialization.Speaker:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Psychological:
                    BaseSkills.Add(new Skill("Episode", "A psychotic episode engulfs this unit, increasing their affinity and mana by 30% for 9 turns.", mana * 3, 100, 
                    new List<Effect> 
                    {
                        new Effect("Episode", "Increase the unit's Affinity and Mana by 30% for 9 turns.", "No contact with external reality increases this unit's mental focus.", 30, 9, 100, Target.Self, new List<StatAttribute> { StatAttribute.Affinity, StatAttribute.Mana }, true, true, Target.Self, false)
                    }, Target.Self, 'M', false));

                    BaseSkills.Add(new Skill("Desperation", "Decay the enemy's mind for 200% of your affinity and mana.", (affinity + mana) * 2, 90, 
                        new List<Effect>
                        { 
                            new Effect("Mind Decay", "The mind is a limited resource... and a weak point.", "Argh! This headache! It's unbearable!", 20, 1, 40, Target.Enemy, new List<StatAttribute> { StatAttribute.Affinity, StatAttribute.Resistance }, false, true, Target.Enemy, false),
                            new Effect("Cooldown", "The attack will reduce this unit's affinity and mana by 50% for 1 turn.", "My mind aches. I must wait for it to pass.", 50, 1, 75, Target.Self, new List<StatAttribute> { StatAttribute.Affinity, StatAttribute.Mana }, new List<StatAttribute> { StatAttribute.Affinity, StatAttribute.Mana }, false, true, Target.Self, false),
                            new Effect("Self-Harm", "This attack also deals 20HP of damage to the user.", "Striking with all your mind leaves open holes.", 20, 0, 100, Target.Self, new List<StatAttribute> { StatAttribute.HP }, false, false, Target.Self, false)
                        }, Target.Enemy, 'M', false));
                    BaseSkills.Add(new Skill());



                    SPSkills.Add(new SpecialSkill("Betray", "Betray an Ally by attacking them!", (int)(affinity), 80,
                        new List<Effect>
                        {
                            new Effect("Salvation", "Increase Affinity and Mana by 100% for 3 turns.", "The feeling of betrayal leaves a sense of salvation... of freedom. Affinity and Mana for this unit is increased by 100%.", 100, 3, 100, Target.Self, new List<StatAttribute> { StatAttribute.Affinity, StatAttribute.Mana }, true, true, Target.Self, true),
                            new Effect("Unsettled", "Being backstabbed by an ally leaves this unit more weary. Constitution, Affinity, Defense, and Resistance are lowered by 10 points.", "Did my friend just BETRAY me? I must keep an eye on them.", 10, 3, 75, Target.Ally, new List<StatAttribute> { StatAttribute.Constitution, StatAttribute.Affinity, StatAttribute.Defense, StatAttribute.Resistance }, new List<StatAttribute> { StatAttribute.Constitution, StatAttribute.Affinity, StatAttribute.Defense, StatAttribute.Resistance}, false, false, Target.Ally, true)
                        }, Target.Ally, 15, 'M', false));
                    break;

                //Intermediate Classes
                case Specialization.Wizard:
                    BaseSkills.Add(new Skill("Scorch", "Cast pure flames towards the target.", (int)(affinity * 1.25), 95, 
                        new List<Effect> 
                        {
                            new Effect("On Fire", "The scorch leaves this target on fire. They take 5% of their HP as damage for 1 turn.", "Hot! Hot! Gotta put it out NOW!", 5, 1, 55, Target.Enemy, new List<StatAttribute> { StatAttribute.HP }, false, true, Target.Enemy, true)
                        }, Target.Enemy, 'M', false));
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Mage:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Destroyer:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Guardian:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Archer:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Rogue:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.FieldMedic:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Priest:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Inspirer:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Leader:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Psychopath:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Superliminal:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                //Advanced Classes
                case Specialization.Caster:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Elemental:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Demon:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.ChaosMage:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Slayer:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Reaper:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Fortress:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Frontline:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Sniper:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Angel:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Agent:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Arsonist:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.CombatMedic:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Charmer:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.FieldPriest:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.DarkPriest:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.FlagHolder:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Rallier:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Motivator:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Lieutenant:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                //Expert Classes
                case Specialization.Controller:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Necromancer:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.DragonWarrior:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Citadel:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Marksman:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Hitman:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.AngelMedic:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Ressurector:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Cultist:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.Enforcer:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                case Specialization.General:
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    BaseSkills.Add(new Skill());
                    break;

                default:
                    break;
            }//end switch

        }//end constructor


        /*
         * Restores skills to the person.
         * Used when loading a save file.
         * 
         * 
         * 
         */
        public void RestoreSkills(List<Skill> savedSkills, List<Skill> allSkills) 
        {
            
        }
    }
}