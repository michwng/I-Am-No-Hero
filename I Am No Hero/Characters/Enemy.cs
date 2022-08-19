/**       
 * -------------------------------------------------------------------
 * 	   File name: Enemy.cs
 * 	Project name: I Am No Hero
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	04/20/2022	
 *            Last Modified:    04/20/2022
 * -------------------------------------------------------------------
 */

namespace I_Am_No_Hero
{
    public class Enemy : BasePerson
    {
        /*
         * The base constructor for the enemy class.
         * Chooses a random enemy to battle.
         * 
         * Date Created: 04/20/2022
         * Last Modified: 04/20/2022
         */
        public Enemy(Boolean boss = false) 
        {
            Random random = new();
            if (boss)
            {
                //Generate a random number between 0 - 10 (inclusive).
                CreateBossEnemy(random.Next(2));
            }
            else 
            {
                //Generate a random number between 0 - 20 (inclusive).
                CreateEnemy(random.Next(3));
            }
        }

       /*
        * The primary constructor for the enemy class.
        * Chooses a random enemy to battle.
        * 
        * Date Created: 04/20/2022
        * Last Modified: 04/20/2022
        */
        public Enemy(int enemyNum, Boolean boss = false)
        {
            if (boss)
            {
                //Generate a random number between 0 - 10 (inclusive).
                CreateBossEnemy(enemyNum);
            }
            else
            {
                //Generate a random number between 0 - 20 (inclusive).
                CreateEnemy(enemyNum);
            }
        }


        /*
         * The CreateBossEnemy method chooses a boss 
         * out of a variety of options, based on
         * the value of BossNum.
         * This method is called in any 
         * constructor of the Enemy class.
         * 
         * Date Created: 04/20/2022
         * Last Modified: 04/20/2022
         * -------------------------
         * @param int BossNum
         */
        private void CreateBossEnemy(int BossNum)
        {
            //Creating individual bosses. This takes up a lot of lines of code per boss.
            
            //Yilaska's Story Line Bosses
            switch (BossNum) 
            {
                case 0:
                    Name = "Slayte";
                    Description = "A Knight of the Deskil.";
                    BaseHP = 500;
                    BaseSP = 25;
                    BaseHPRecovery = 20;
                    BaseSPRecovery = 5;
                    BaseConstitution = 35;
                    BaseAffinity = 0;
                    BaseSpeed = 15;
                    BaseDefense = 25;
                    BaseResistance = 10;
                    BaseStrength = 10;
                    BaseDamageReduction = 10.0;
                    Specialization = Specialization.Leader;

                    //Armor Equips
                    //Value names are as follows: PDEF, MDEF, Weight, Name, Description, and Bodypart.
                    EquippedArmor[0] = new Armor(15, 10, 3, "Bronze Helm", "The standard helmet for Deskil Knights.", BodyPart.Head);
                    EquippedArmor[1] = new Armor(30, 10, 6, "Bronze Chestplate", "Bronze armor allows for quick stance shifts while also providing adequate protection.", BodyPart.Torso);
                    EquippedArmor[2] = new Armor(10, 10, 2, "Bronze Chainmail", "Bronze Chainmail allows for easy leg movement while also protecting the sensitive spots.", BodyPart.Legs);
                    EquippedArmor[3] = new Armor(15, 10, 2, "Bronze Boots", "Comfortable on the inside, with bronze plating on the outside.", BodyPart.Feet);
                    EquippedArmor[4] = new Armor(10, 10, 3, "Bronze Arm Plating", "Allows for comfortable and quick arm movement while also providing protection.", BodyPart.Arms);
                    EquippedArmor[6] = new Armor(10, 10, 1, "Bronze Gauntlet", "A protective glove that enhances grip strength and hand protection.", BodyPart.Hands);
                    EquippedArmor[5] = new Armor(5, 25, 0, "Brunz's Pact", "A gleaming necklace with ever-glowing lava inside. The symbol of the Deskil Knights.", BodyPart.Neck);
                    EquippedArmor[7] = new Armor(3, 15, 0, "In Memoriam", "A ring adorned on Slayte's Lance, dedicated to those who fell under Slayte.", BodyPart.Charm);


                    //Weapon Equip
                    //Value names are as follows: Name, Description, PDMG, MDMG, Accuracy, Dexterity, ParryChance, WeaponClassification
                    EquippedWeapon = new Weapon("Slayte's Lance", "A renowned lance, having fought many bandits in its lifetime.", 35, 0, 95, 10, 15, WeaponClassification.LightMelee);

                    ActualHP = BaseHP;
                    ActualSP = BaseSP;
                    ActualHPRecovery = BaseHPRecovery;
                    ActualSPRecovery = BaseSPRecovery;
                    ActualConstitution = BaseConstitution;
                    ActualAffinity = BaseAffinity;
                    ActualSpeed = BaseSpeed;
                    ActualDefense = BaseDefense;
                    ActualResistance = BaseResistance;
                    ActualStrength = BaseStrength;
                    ActualDamageReduction = BaseDamageReduction;
                    break;
            } //End of switch















        } //End of CreateBossEnemy Method.





        /*
         * The CreateEnemy method chooses an enemy 
         * out of a variety of options, based on
         * the value of EnemyNum.
         * This method is called in any 
         * constructor of the Enemy class.
         * 
         * Date Created: 04/20/2022
         * Last Modified: 04/20/2022
         * -------------------------
         * @param int EnemyNum
         */
        private void CreateEnemy(int EnemyNum) 
        {
            //Creating individual enemies. This takes up a lot of lines of code.
            switch (EnemyNum)
            {
                case 0:
                    Article = "The";
                    Name = "Deskil Aspirant Myrmidon";
                    Description = "A follower of the Deskil Knights.";
                    BaseHP = 250;
                    BaseSP = 50;
                    BaseHPRecovery = 25;
                    BaseSPRecovery = 8;
                    BaseConstitution = 20;
                    BaseAffinity = 10;
                    BaseSpeed = 15;
                    BaseDefense = 35;
                    BaseResistance = 10;
                    BaseMana = 5;
                    BaseStrength = 5;
                    BaseAgility = 5;
                    Specialization = Specialization.Myrmidon;
                    SkillSet = new SkillSet(Specialization);

                    //Armor Equips
                    //Value names are as follows: PDEF, MDEF, Weight, Name, Description, and Bodypart.
                    EquippedArmor[0] = new Armor(4, 5, 0, "Plain Cap", "A newspaper boy's cap. Also, the standard cap for Deskil aspirants.", BodyPart.Head);
                    EquippedArmor[1] = new Armor(2, 4, 0, "Plain Shirt", "Simple clothing that provides little protection.", BodyPart.Torso);
                    EquippedArmor[2] = new Armor(3, 4, 0, "Simple Jeans", "Jeans that are ripped at the knees. Provides little protection.", BodyPart.Legs);
                    EquippedArmor[3] = new Armor(2, 3, 0, "Runner's Shoes", "Simple shoes for the avid runner. Proides little protection.", BodyPart.Feet);
                    EquippedArmor[4] = new Armor(0, 0, 0, "No Arm Armor", "These recruits don't seem to have arm armor.", BodyPart.Arms);
                    EquippedArmor[6] = new Armor(5, 10, 1, "Simple Gloves", "Gloves that enhance the wielder's grip on a weapon. However, they provide little protection.", BodyPart.Hands);
                    EquippedArmor[5] = new Armor(5, 10, 0, "Aspirant Pact", "\"The Deskil Aspirant always pushes until the end.\" Such is the way of the Deskil.", BodyPart.Neck);
                    EquippedArmor[7] = new Armor(3, 15, 0, "Money", "Money makes society run. Wouldn't hurt to have it on hand.", BodyPart.Charm);


                    //Weapon Equip
                    //Value names are as follows: Name, Description, PDMG, MDMG, Accuracy, Dexterity, ParryChance, WeaponClassification
                    EquippedWeapon = new Weapon("Combat Knife", "A good weapon of choice for close encounters.", 20, 0, 99, 25, 5, WeaponClassification.LightMelee);

                    ActualHP = BaseHP;
                    ActualSP = BaseSP;
                    ActualHPRecovery = BaseHPRecovery;
                    ActualSPRecovery = BaseSPRecovery;
                    ActualConstitution = BaseConstitution;
                    ActualAffinity = BaseAffinity;
                    ActualSpeed = BaseSpeed;
                    ActualDefense = BaseDefense;
                    ActualResistance = BaseResistance;
                    ActualMana = BaseMana;
                    ActualStrength = BaseStrength;
                    ActualAgility = BaseAgility;
                    break;

                case 1:
                    Article = "The";
                    Name = "Deskil Aspirant Acolyte";
                    Description = "A follower of the Deskil Knights.";
                    BaseHP = 150;
                    BaseSP = 100;
                    BaseHPRecovery = 15;
                    BaseSPRecovery = 20;
                    BaseConstitution = 10;
                    BaseAffinity = 35;
                    BaseSpeed = 15;
                    BaseDefense = 5;
                    BaseResistance = 25;
                    BaseMana = 5;
                    Specialization = Specialization.Acolyte;
                    SkillSet = new SkillSet(Specialization);

                    //Armor Equips
                    //Value names are as follows: PDEF, MDEF, Weight, Name, Description, and Bodypart.
                    EquippedArmor[0] = new Armor(4, 5, 0, "Plain Cap", "A newspaper boy's cap. Also, the standard cap for Deskil aspirants.", BodyPart.Head);
                    EquippedArmor[1] = new Armor(2, 4, 0, "Plain Shirt", "Simple clothing that provides little protection.", BodyPart.Torso);
                    EquippedArmor[2] = new Armor(3, 4, 0, "Simple Jeans", "Jeans that are ripped at the knees. Provides little protection.", BodyPart.Legs);
                    EquippedArmor[3] = new Armor(2, 3, 0, "Runner's Shoes", "Simple shoes for the avid runner. Proides little protection.", BodyPart.Feet);
                    EquippedArmor[4] = new Armor(0, 0, 0, "No Arm Armor", "These recruits don't seem to have arm armor.", BodyPart.Arms);
                    EquippedArmor[6] = new Armor(5, 10, 1, "Acolyte's Gloves", "Gloves that allow one to focus their inner affinity.", BodyPart.Hands);
                    EquippedArmor[5] = new Armor(5, 10, 0, "Aspirant Pact", "\"The Deskil Aspirant always pushes until the end.\" Such is the way of the Deskil.", BodyPart.Neck);
                    EquippedArmor[7] = new Armor(3, 15, 0, "Money", "Money makes society run. Wouldn't hurt to have it on hand.", BodyPart.Charm);


                    //Weapon Equip
                    //Value names are as follows: Name, Description, PDMG, MDMG, Accuracy, Dexterity, ParryChance, WeaponClassification
                    EquippedWeapon = new Weapon("Staff", "A sturdy stick that can support an old person.", 0, 20, 99, 10, 1, WeaponClassification.LightStaff);

                    ActualHP = BaseHP;
                    ActualSP = BaseSP;
                    ActualHPRecovery = BaseHPRecovery;
                    ActualSPRecovery = BaseSPRecovery;
                    ActualConstitution = BaseConstitution;
                    ActualAffinity = BaseAffinity;
                    ActualSpeed = BaseSpeed;
                    ActualDefense = BaseDefense;
                    ActualResistance = BaseResistance;
                    ActualMana = BaseMana;
                    break;

                default: //case 2:
                    Article = "The";
                    Name = "Deskil Aspirant Thief";
                    Description = "A follower of the Deskil Knights.";
                    BaseHP = 150;
                    BaseSP = 30;
                    BaseHPRecovery = 5;
                    BaseSPRecovery = 5;
                    BaseConstitution = 25;
                    BaseAffinity = 0;
                    BaseSpeed = 5;
                    BaseDefense = 10;
                    BaseResistance = 10;
                    BaseAgility = 5;
                    Specialization = Specialization.Thief;
                    SkillSet = new SkillSet(Specialization);

                    //Armor Equips
                    //Value names are as follows: PDEF, MDEF, Weight, Name, Description, and Bodypart.
                    EquippedArmor[0] = new Armor(4, 5, 0, "Plain Cap", "A newspaper boy's cap. Also, the standard cap for Deskil aspirants.", BodyPart.Head);
                    EquippedArmor[1] = new Armor(2, 4, 0, "Plain Shirt", "Simple clothing that provides little protection.", BodyPart.Torso);
                    EquippedArmor[2] = new Armor(3, 4, 0, "Simple Jeans", "Jeans that are ripped at the knees. Provides little protection.", BodyPart.Legs);
                    EquippedArmor[3] = new Armor(2, 3, 0, "Runner's Shoes", "Simple shoes for the avid runner. Proides little protection.", BodyPart.Feet);
                    EquippedArmor[4] = new Armor(0, 0, 0, "No Arm Armor", "These recruits don't seem to have arm armor.", BodyPart.Arms);
                    EquippedArmor[6] = new Armor(5, 10, 0, "Aspirant Pact", "\"The Deskil Aspirant always pushes until the end.\" Such is the way of the Deskil.", BodyPart.Neck);
                    EquippedArmor[5] = new Armor(5, 10, 1, "Archer's Gloves", "Gloves that protect archers when overusing their bow.", BodyPart.Hands);
                    EquippedArmor[7] = new Armor(3, 15, 0, "Money", "Money makes society run. Wouldn't hurt to have it on hand.", BodyPart.Charm);


                    //Weapon Equip
                    //Value names are as follows: Name, Description, PDMG, MDMG, Accuracy, Dexterity, ParryChance, WeaponClassification
                    EquippedWeapon = new Weapon("Staff", "A sturdy stick that can support an old person.", 0, 20, 99, 10, 1, WeaponClassification.LightStaff);

                    ActualHP = BaseHP;
                    ActualSP = BaseSP;
                    ActualHPRecovery = BaseHPRecovery;
                    ActualSPRecovery = BaseSPRecovery;
                    ActualConstitution = BaseConstitution;
                    ActualAffinity = BaseAffinity;
                    ActualSpeed = BaseSpeed;
                    ActualDefense = BaseDefense;
                    ActualResistance = BaseResistance;
                    ActualAgility = BaseAgility;
                    break;
            } //End of switch statement.

        } //End of CreateEnemy Method.
    }
}