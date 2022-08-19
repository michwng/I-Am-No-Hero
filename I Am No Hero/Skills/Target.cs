/**       
 * -------------------------------------------------------------------
 * 	   File name: Target.cs
 * 	Project name: I Am No Hero
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	04/20/2022	
 *            Last Modified:    04/28/2022
 * -------------------------------------------------------------------
 */
using System.ComponentModel.DataAnnotations;

namespace I_Am_No_Hero
{
    public enum Target
    {
        //Enums for combatants.
        Self,
        Ally,
        Enemy,
        [Display(Name="Self or Ally")]
        SelfORAlly,

        [Display(Name = "Ally or Ally")]
        AllyOREnemy,

        [Display(Name = "Self or Enemy")]
        SelfOREnemy,

        Any,

        [Display(Name = "Self and Allies")]
        SelfANDAllies,

        [Display(Name = "Self and Enemies")]
        SelfANDEnemies,

        [Display(Name = "Allies and Enemies")]
        AlliesANDEnemies,

        [Display(Name = "All Allies")]
        AllAllies,

        [Display(Name = "All Enemies")]
        AllEnemies,

        All,

        //Enums for calculating damage to combatants.
        [Display(Name = "Damage Done to the Enemy")]
        DamageDealtEnemy,

        [Display(Name = "Damage Done to the Ally")]
        DamageDealtAlly,

        [Display(Name = "Damage Done to Self")]
        DamageDealtSelf,

        [Display(Name = "Damage Done to All Combatants")]
        DamageDealtAll,

        [Display(Name = "Damage Done to Any Combatant")]
        DamageDealtAny
    }
}