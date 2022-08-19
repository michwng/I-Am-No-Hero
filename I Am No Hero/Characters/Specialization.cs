/**       
 * -------------------------------------------------------------------
 * 	   File name: Specialization.cs
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
    /*
     * Specialization is an enum of the available classes.
     * 
     * Date Created: 3/20/2022
     * Last Modified: 04/01/2022
     */
    public enum Specialization
    {
        /***** Basic Classes *****/

        //Acolytes are basic mage classes.
        //Their skillset relies on Affinity.
        Acolyte,

        //Myrmidions are basic warrior classes.
            //Their skillset relies on Strength.
        Myrmidon,

        //Thieves are a mixture of Acolyte and Warrior.
            //Their skillset at first will rely on Strength.
        Thief,

        //Clerics are basic healer and support classes.
        Cleric,

        //Speakers are basic support classes.
        Speaker,

        //Psychologicals are the most powerful but also the most unwieldy class.
        //They can specialize in magical damage.
        Psychological,




        /***** Intermediate Classes *****/

        //Wizards possess mediocre
        //damage and status effect spells.
        Wizard,

        //Mages specialize in magical damage output.
        Mage,

        //Destroyers specialize in physical damage output.
        Destroyer,

        //Guardians specialize in defense.
        Guardian,

        //Archers deal bursts of physical damage.
        Archer,

        //Rogues are quick and wield strong bleed status effects.
        Rogue,

        //Field Medics are effective at single-hand healing.
        //They can also dispel bad status effects.
        FieldMedic,

        //Priests can cast area heals on their team mates.
        //They can also dispel bad status effects.
        Priest,

        //Inspirers grant mediocre damage buffs to their team.
        //They can also 'inspire' enemies to relax.
        Inspirer,

        //Leaders provide passive buffs to their team,
        //and have a wide range of supportive buffs.
        Leader,

        //Psychopaths maximize their magical damage output
        //by attacking their allies and gaining buffs at the same time.
        Psychopath,

        //Perception is reality.
        //Superliminals can summon items out of thin air.
        Superliminal,


        /***** Advanced Classes *****/
        //Casters specialize in magical damage output.
        Caster,
        //Elementals have a range of status effect skills.
        Elemental,

        //Demons are incredibly powerful creatures.
        //This type of demon specializes in magic.
        Demon,

        //Chaos mages can target the battlefield with debuffs.
        //They can also cause panic to enemies.
        ChaosMage,

        //Slayers deal a great amount of physical damage to enemies.
        Slayer,

        //Reapers have powerful status effects that can take out bosses efficiently.
        Reaper,

        //Fortresses are extremely tough and can resist many physical attacks.
        Fortress,

        //Frontlines can resist many incoming magical attacks.
        Frontline,

        //Snipers deal great bursts of damage with
        //an array of self-boosting status effects.
        Sniper,

        //Angels can deal damage bursts and
        //incur strong status effects on targets.
        Angel,

        //Agents are secretive and exceed in agility.
        //Their boldness increases quickly.
        Agent,

        //Arsonists are the essence of fire.
        //They can deal damage to an entire team.
        Arsonist,

        //Combat Medics can deal damage and
        //heal themselves at the same time.
        CombatMedic,

        //Charmers can heal efficiently
        //and are not targeted as much as other classes.
        Charmer,

        //Field Priests carry stronger team-wide healing spells.
        //They also have more SP for healing.
        FieldPriest,

        //Dark Priests can curse enemies and bless allies.
        DarkPriest,

        //As long as the Flag Holder lives, the team
        //gains a passive boost in morale and stats.
        FlagHolder,

        //Ralliers grant many supportive buffs to their team.
        Rallier,

        //Motivators have stronger individual supportive buffs.
        Motivator,
        //Lieutenants deal great damage and passively
        //inspire the team as long as they are in battle.
        Lieutenant,

        //Griplesses can attack the entire battlefield at once (including allies).
        //They also prioritize damage over status effects.
        Gripless,

        //Corpses passively scare enemies and have
        //many physical debuff skills. 
        //They also regenerate 1/10 of their HP per round.
        Corpse,

        //Imaginers take superliminalism one step further.
        //They can turn enemies against others.
        Imaginer,

        //Psychics have gained a more controlled experience of the mind.
        //They feature powerful movesets without intense unwieldiness.
        Psychic,



        /***** Expert Classes *****/

        //Controllers are able to 'control' the battlefield
        //with status effects and damaging spells at their disposal.
        Controller,

        //Spirits have mastered status effects and can
        //incur strong damage-over-time attacks.
        Spirit,

        //Doombringers deal strong area-wide magical damage.
        Doombringer,

        //Necromancers can summon allies if there is not already a third ally.
        //They also possess magical debuffs.
        Necromancer,

        //Dragon Warriors can dish out a lot of physical damage
        //across areas and take in a lot as well.
        DragonWarrior,

        //Death Knights can ignore armor and
        //deal out strong status effects.
        DeathKnight,

        //Citadels are extremely tough opponents that can
        //tank just about any physical hit.
        //They also have a large HP Pool.
        Citadel,

        //Will Masters are extremely resistant to magical attacks.
        //They also have a large HP Pool.
        WillMaster,

        //Marksmen can deal large bursts of
        //physical damage with the right buffs equipped.
        Marksman,

        //Ascendants can deal great bursts of damage
        //while also incapacitating their targets.
        Ascendant,

        //Hitmen are laser focused with high agility
        //and can unleash ultimates in succession.
        Hitman,

        //Pyromanics can deal great status
        //effect damage across entire teams.
        //Their ultimates charge faster, too.
        Pyromaniac,

        //Angel Medics can heal the entire team for a great amount.
        AngelMedic,

        //Ressurectors lack good healing spells,
        //but can ressurect fallen units, apart from themselves..
        Ressurector,

        //Cultists can perform rituals to curse enemies and sacrifice
        //some of their stats for the betterment of the team.
        Cultist,

        //Enforcers ensure that a team functions with strong support and healing buffs.
        Enforcer,

        //Generals employ strong buffs to boost the damage output of teams.
        General,

        //Psychotics are the ultimate in damage dealing.
        //They are also the most vulnerable.
        Psychotic,

        //Zombiess passively scare enemies and have many Physical skills. 
        //They also regenerate 1/5 of their HP per round.
        Zombie,

        //Godly Servants tend to think they are god, being able to wield this power.
        //Whatever they command, people must obey, or they will suffer the consequences.
        GodlyServant,

        //Monks have full control of their body and mind.
        //They offer strong movesets and buffs,
        //while also being able to heal and buff others.
        Monk,



        /***** Enemy-Specific Classes *****/

        //Dear Leaders are the leaders of cult groups.
        //They possess devestating status effects.
        TheDearLeader,

        //Council Members possess strong magical attacks.
        CouncilMember,

        //Council Leaders bolster the damage of Council members.
        CouncilLeader,

        //Secret Policemen deal physical damage and
        //inflict physical status effects.
        SecretPolice,

        //Information Agents are well trained and can utilize great debuffs.
        InformationAgent,

        //The Chief Information Agent passively boosts the stats of
        //Information Agents and deals great damage.
        ChiefInformationAgent,

        //Robots specialize in physical damage and status effects,
        //defense, and have a large HP Pool.
        Robot,

        //Drones are agile robots that deal burst damage.
        //They are quick, but very fragile.
        Drone,

        //Sentries are heavily defended turrets.
        //They also deal consistent damage.
        Sentry
    }
}
