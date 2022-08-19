/**       
 * -------------------------------------------------------------------
 * 	   File name: WeaponClassification.cs
 * 	Project name: I Am No Hero
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	03/20/2022	
 *            Last Modified:    03/20/2022
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
    * WeaponClassification is an enum used to classify 
    * a weapon and how it is used.
    * 
    * Date Created: 3/20/2022
    */
    public enum WeaponClassification
    {
        LightMelee,
        MediumMelee,
        HeavyMelee,
        LightBow,
        MediumBow,
        HeavyBow,
        LightStaff,
        HeavyStaff,
        DarkStaff,
    }
}
