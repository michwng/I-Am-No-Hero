/**       
 * -------------------------------------------------------------------
 * 	   File name: StatAttribute.cs
 * 	Project name: I Am No Hero
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	04/20/2022	
 *            Last Modified:    04/20/2022
 * -------------------------------------------------------------------
 */

namespace I_Am_No_Hero
{
    /*
     * StatAttribute specifies all attributes in-game.
     * Helpful for effect moves.
     * Note that these values will reference Actual values.
     * 
     * Date Created: 04/20/2022
     * Last Modified: 04/20/2022
     */
    public enum StatAttribute
    {
        HP,
        SP,
        HPRecovery,
        SPRecovery,
        Constitution,
        Affinity,
        Speed,
        Defense,
        Resistance,
        Mana,
        Strength,
        Agility,
        HealingFactor,
        HealingBuffFactor,
        SupportBuffFactor,
        DebuffFactor,
        DamageReduction,
        ParryFocus
    }
}