/**       
 * -------------------------------------------------------------------
 * 	   File name: AttackMenu.cs
 * 	Project name: I Am No Hero
 * -------------------------------------------------------------------
 *  Author�s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	04/25/2022	
 *            Last Modified:    04/25/2022
 * -------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace I_Am_No_Hero.Menus.BattleSubMenus
{
    public partial class AttackMenu : Form
    {

        //Ally 1 is assumed to be the hero.
        Ally AllyOne { get; set; } = new Ally();

        static Enemy EnemyOne { get; set; } = new Enemy();
        static Enemy? EnemyTwo { get; set; }
        static Enemy? EnemyThree { get; set; }

        Enemy EnemyTarget = EnemyOne;

        internal static Boolean TurnOver { get; private set; } = false;
        internal static Skill Skill { get; set; } = new();
        internal static List<Effect> TriggeredEffects = new();

        /*
         * The base constructor of the AttackMenu class.
         * 
         * Date Created: 04/25/2022
         * Last Modified: 04/25/2022
         */
        public AttackMenu()
        {
            InitializeComponent();

            HideNonCombatants(true, true);

            InitializeBattle();
        }


        /*
         * The primary constructor of the AttackMenu class.
         * 
         * 
         * Date Created: 04/25/2022
         * Last Modified: 04/25/2022
         */
        public AttackMenu(Ally a1, Enemy e1, Enemy? e2 = null, Enemy? e3 = null)
        {
            InitializeComponent();

            if (a1 is not null)
            {
                AllyOne = a1;
            }
            if (e1 is not null)
            {
                EnemyOne = e1;
            }

            EnemyTwo = e2;
            EnemyThree = e3;

            //If EnemyTwo is null, we put true. Otherwise, we put false.
            bool EnemyTwoIsNull = EnemyTwo == null ? true : false;
            bool EnemyThreeIsNull = EnemyThree == null ? true : false;

            HideNonCombatants(EnemyTwoIsNull, EnemyThreeIsNull);

            InitializeBattle();
        }

        /*
         * This method modifies the menu based on the available combatants.
         * If any Ally or Enemy is initialized as null, 
         * this method hides their UI element.
         * 
         * 
         * Date Created: 04/25/2022
         * Last Modified: 04/25/2022
         */
        private void HideNonCombatants(bool enemyTwoIsNull, bool enemyThreeIsNull)
        {
            if (enemyTwoIsNull)
            {
                pictureBox2.Hide();
                label5.Hide();
                transparentLabel4.Hide();
                transparentLabel5.Hide();
                transparentLabel11.Hide();
            }
            if (enemyThreeIsNull)
            {
                pictureBox3.Hide();
                label6.Hide();
                transparentLabel6.Hide();
                transparentLabel7.Hide();
                transparentLabel12.Hide();
            }
        }

        /*
         * Everytime the user clicks on an icon, we add
         * a border around it to signify it is selected.
         * We also move the "ATTACKING >" label accordingly.
         * 
         * Date Created: 04/25/2022
         * Last Modified: 04/25/2022
         */
        private void UpdateBoxClick()
        {
            if (EnemyTarget == EnemyOne)
            {
                pictureBox1.BorderStyle = BorderStyle.FixedSingle;
                pictureBox2.BorderStyle = BorderStyle.None;
                pictureBox3.BorderStyle = BorderStyle.None;
                transparentLabel1.Location = new Point(464, 110);
            }
            else if (EnemyTarget == EnemyTwo)
            {
                pictureBox1.BorderStyle = BorderStyle.None;
                pictureBox2.BorderStyle = BorderStyle.FixedSingle;
                pictureBox3.BorderStyle = BorderStyle.None;
                transparentLabel1.Location = new Point(464, 210);
            }
            else
            {
                pictureBox1.BorderStyle = BorderStyle.None;
                pictureBox2.BorderStyle = BorderStyle.None;
                pictureBox3.BorderStyle = BorderStyle.FixedSingle;
                transparentLabel1.Location = new Point(464, 312);
            }
        }


        /*
         * This method updates the values in the bars.
         * This is called after every turn and at the beginning of battle.
         * 
         * 
         * Date Created: 04/25/2022
         * Last Modified: 04/25/2022
         */
        private void InitializeBattle()
        {
            /* Initialize Enemy 1 */
            pictureBox1.ImageLocation = Program.FileRoot + "Sprites" + Path.DirectorySeparatorChar + "BattleIcons" + Path.DirectorySeparatorChar + EnemyOne.Specialization.ToString() + ".png";
            pictureBox1.Image = Image.FromFile(pictureBox1.ImageLocation);
            pictureBox1.Update();
            Console.WriteLine("Enemy Image Location: " + pictureBox1.ImageLocation);

            if (EnemyTwo is not null)
            {
                /* Initialize Enemy 2 */
                pictureBox2.ImageLocation = Program.FileRoot + "Sprites" + Path.DirectorySeparatorChar + "BattleIcons" + Path.DirectorySeparatorChar + EnemyTwo.Specialization.ToString() + ".png";
                pictureBox2.Image = Image.FromFile(pictureBox2.ImageLocation);
                pictureBox2.Update();
                Console.WriteLine("Enemy Image Location: " + pictureBox2.ImageLocation);
            }

            if (EnemyThree is not null)
            {
                /* Initialize Enemy 3 */
                pictureBox3.ImageLocation = Program.FileRoot + "Sprites" + Path.DirectorySeparatorChar + "BattleIcons" + Path.DirectorySeparatorChar + EnemyThree.Specialization.ToString() + ".png";
                pictureBox3.Image = Image.FromFile(pictureBox3.ImageLocation);
                pictureBox3.Update();
                Console.WriteLine("Enemy Image Location: " + pictureBox3.ImageLocation);
            }

            EnemyTarget = EnemyOne;
            UpdateBoxClick();

            UpdateBarValues();

            InitializeComboBox();
        }


        /*
         * This method updates the values in the bars.
         * This is called after every turn and at the beginning of battle.
         * "Borrowed" from the BattleMenu class.
         * 
         * Date Created: 04/25/2022
         * Last Modified: 04/25/2022
         */
        internal void UpdateBarValues()
        {
            //Initialize Enemy 1's Bar values.
            label4.Text = EnemyOne.Name;
            transparentLabel2.Text = EnemyOne.ActualHP + " / " + EnemyOne.BaseHP;
            transparentLabel3.Text = EnemyOne.ActualSP + " / " + EnemyOne.BaseSP;

            if (EnemyTwo != null)
            {
                label5.Text = EnemyTwo.Name;
                transparentLabel4.Text = EnemyTwo.ActualHP + " / " + EnemyTwo.BaseHP;
                transparentLabel5.Text = EnemyTwo.ActualSP + " / " + EnemyTwo.BaseSP;
            }
            if (EnemyThree != null)
            {
                label6.Text = EnemyThree.Name;
                transparentLabel6.Text = EnemyThree.ActualHP + " / " + EnemyThree.BaseHP;
                transparentLabel7.Text = EnemyThree.ActualSP + " / " + EnemyThree.BaseSP;
            }
        }

        /*
         * Initializes the combo box to display moves.
         * 
         * Date Created: 04/26/2022
         * Last Modified: 04/26/2022
         */
        private void InitializeComboBox()
        {
            foreach (Skill skill in AllyOne.SkillSet.BaseSkills)
            {
                comboBox1.Items.Add(skill);
            }
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            EnemyTarget = EnemyOne;
            UpdateBoxClick();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            EnemyTarget = EnemyTwo;
            UpdateBoxClick();
        }

        /*
         * References the 3rd Enemy's Icon.
         * Everytime the 3rd Enemy's Icon is clicked, we
         * set them as the new target and Update the UI.
         * 
         * Date Created: 04/25/2022
         * Last Modified: 04/25/2022
         */
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            EnemyTarget = EnemyThree;
            UpdateBoxClick();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = AllyOne.SkillSet.BaseSkills[comboBox1.SelectedIndex].GetSkillInfo();
        }

        /// <summary>
        ///  References the Attack button. 
        ///  When clicked, "Attack" the enemy with the selected skill.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            TurnOver = false;
            Random rng = new Random();
            //MessageDialog msgDialog = new MessageDialog();

            Skill skillUsed = AllyOne.SkillSet.BaseSkills[comboBox1.SelectedIndex];


            int skillDamage = skillUsed.BaseDamage;
            char damageType = skillUsed.DamageType;
            int accuracy = skillUsed.Accuracy;
            List<Effect> effects = skillUsed.SkillEffects == null ? new(): skillUsed.SkillEffects;
            List<Effect> triggeredEffects = new();

            if (effects != null)
            {
                //We randomly generate a number and test it against proc chance.
                foreach (Effect effect in effects)
                {
                    int randomNumber = rng.Next(100);

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

            int enemyDefense = EnemyOne.ActualDefense;
            int enemyResistance = EnemyOne.ActualResistance;
            //The damage can vary by -15 to 15.
            //This way, we don't repetitively deal
            //the same damage when casting the same move.
            int damageVariable = rng.Next(-15, 16);

            double enemyDamageReduction = EnemyOne.ActualDamageReduction;

            Console.WriteLine("SD: " + skillDamage);
            Console.WriteLine("DV: " + damageVariable);
            Console.WriteLine("ED: " + enemyDefense);

            //First, we see if we actually hit our skill.
            //rng.Next(100) gets a number from 0 - 99.
            //If we get less than accuracy, we use the skill.
            if (rng.Next(100) < accuracy)
            {
                int damageDone = (int)(skillDamage + damageVariable);

                int physicalDamageMitigated = (int)(enemyDefense + (damageDone * EnemyTarget.ActualDamageReduction));
                int magicalDamageMitigated = (int)(enemyResistance + (damageDone * damageDone * EnemyTarget.ActualDamageReduction));

                int physicalDamageTaken = damageDone - physicalDamageMitigated;
                int magicalDamageTaken = damageDone - magicalDamageMitigated;

                switch (damageType)
                {
                    case 'M':
                        if (EnemyTarget.ActualHP - magicalDamageTaken <= 0)
                        {
                            magicalDamageTaken = EnemyTarget.ActualHP;
                            EnemyTarget.ActualHP = 0;
                        }
                        else
                        {
                            if (magicalDamageTaken > 0)
                            {
                                EnemyTarget.ActualHP -= magicalDamageTaken;
                            }
                            else
                            {
                                magicalDamageTaken = 0;
                            }
                        }

                        //TO DO - Implement variables from Battle to AttackMenu, SpecialAttackMenu, and SupportMenu.
                        StringBuilder sb = new StringBuilder();
                        sb.Append($"{AllyOne.Article} {AllyOne.Name} used the Special Skill {skillUsed.SkillName} on {EnemyTarget.Article} {EnemyTarget.Name}!" +
                            $"\n(Description: {skillUsed.SkillDescription} | Deals {skillUsed.BaseDamage}HP of Physical Damage)" +
                            $"{EnemyTarget.Article} {EnemyTarget.Name}'s Defense ({EnemyTarget.ActualDefense}) and Damage Reduction stat ({EnemyTarget.ActualDamageReduction}) reduced the incoming damage by {physicalDamageMitigated}" +
                            $"\n{EnemyTarget.Article} {EnemyTarget.Name} took {physicalDamageTaken}HP of Physical damage!");

                        Skill = skillUsed;
                        
                        if (triggeredEffects.Count > 0)
                        {
                            sb.Append($"\n\n{EnemyTarget.Name} is now suffering the following effects: ");
                            foreach (Effect effect in triggeredEffects)
                            {
                                sb.Append($"\n - {effect.EffectName} \n({effect.EffectDescription})");
                            }
                        }

                        //msgDialog.label1.Text = sb.ToString();
                        MessageBox.Show(sb.ToString());
                        Console.WriteLine($"Cast! The {EnemyTarget.Name} took {magicalDamageTaken}HP of Magical damage!");
                        break;

                    //by default, just attack using physical damage.
                    default:
                        if (EnemyTarget.ActualHP - physicalDamageTaken <= 0)
                        {
                            physicalDamageTaken = EnemyTarget.ActualHP;
                            EnemyTarget.ActualHP = 0;
                        }
                        else
                        {
                            if (physicalDamageTaken > 0)
                            {
                                EnemyTarget.ActualHP -= physicalDamageTaken;
                            }
                            else
                            {
                                physicalDamageTaken = 0;
                            }
                        }

                        StringBuilder stb = new StringBuilder();
                        stb.Append($"{AllyOne.Article} {AllyOne.Name} used the Skill {skillUsed.SkillName} on {EnemyTarget.Article} {EnemyTarget.Name}!" +
                            $"\n(Description: {skillUsed.SkillDescription} | Deals {skillUsed.BaseDamage}HP of Physical Damage)" +
                            $"{EnemyTarget.Article} {EnemyTarget.Name}'s Resistance ({EnemyTarget.ActualResistance}) and Damage Reduction stat ({EnemyTarget.ActualDamageReduction}) reduced the incoming damage by {physicalDamageMitigated}" +
                            $"\n{EnemyTarget.Article} {EnemyTarget.Name} took {physicalDamageTaken}HP of Physical damage!");

                        Skill = skillUsed;

                        if (triggeredEffects.Count > 0)
                        {
                            stb.Append($"\n\n{EnemyTarget.Name} is now suffering the following effects: ");
                            foreach (Effect effect in triggeredEffects)
                            {
                                stb.Append($"\n - {effect.EffectName} \n({effect.EffectDescription})");
                            }
                        }


                        //msgDialog.label1.Text = stb.ToString();
                        MessageBox.Show(stb.ToString());
                        Console.WriteLine($"Slash! {EnemyTarget.Article} {EnemyTarget.Name} took {physicalDamageTaken}HP of Physical damage!");
                        break;
                }

                if (EnemyTarget.ActualHP == 0)
                {
                    Console.WriteLine($"The {EnemyTarget.Name} fainted!\nThey can no longer fight in this battle.");
                }

            }
            else 
            {
                //Oops! We missed the skill!
                MessageBox.Show($"Oops! The skill missed!\n{skillUsed} has {accuracy}% accuracy!");
                //msgDialog = new MessageDialog();
                //msgDialog.Text = $"Oops! The skill missed!\n{skillUsed} has {accuracy}% accuracy!";
            }

            //msgDialog.ShowDialog();

            TurnOver = true;
            this.Hide();

            this.UpdateBarValues();
            this.Refresh();
            Refresh();
        }


        /*
         * References the Go Back button.
         * Closes the menu, returning focus to the BattleMenu.
         * 
         * Date Created: 04/25/2022
         * Last Modified: 04/25/2022
         */
        private void button2_Click(object sender, EventArgs e)
        {
            TurnOver = false;
            this.Hide();
        }

        private void AttackMenu_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void AttackMenu_Paint(object sender, PaintEventArgs e)
        {
            Pen grayPen = new Pen(SystemColors.ActiveBorder);
            Brush greenBrush = new SolidBrush(Color.LightGreen);
            Brush blueBrush = new SolidBrush(Color.LightBlue);

            int BARWIDTH = 170;
            int BARHEIGHT = 20;


            //Drawing HP/SP Bars for Enemies

            //Helps to reduce excess code.
            int BarWidthTotal = 0;

            //Character 1
            Rectangle HPBarFour = new Rectangle(616, 102, BARWIDTH, BARHEIGHT);
            //e.Graphics.FillRectangle(greenBrush, 787 - 66, 84, 66, BARHEIGHT);
            BarWidthTotal = BARWIDTH * EnemyOne.ActualHP / EnemyOne.BaseHP;
            e.Graphics.FillRectangle(greenBrush, 787 - BarWidthTotal, 102, BarWidthTotal, BARHEIGHT);
            e.Graphics.DrawRectangle(grayPen, HPBarFour);

            Rectangle SPBarFour = new Rectangle(616, 131, BARWIDTH, BARHEIGHT);
            //e.Graphics.FillRectangle(blueBrush, 787 - 140, 110, 140, BARHEIGHT);
            BarWidthTotal = BARWIDTH * EnemyOne.ActualSP / EnemyOne.BaseSP;
            e.Graphics.FillRectangle(blueBrush, 787 - BarWidthTotal, 131, BarWidthTotal, BARHEIGHT);
            e.Graphics.DrawRectangle(grayPen, SPBarFour);

            if (EnemyTwo != null)
            {
                //Character 2
                Rectangle HPBarFive = new Rectangle(616, 202, BARWIDTH, BARHEIGHT);
                //e.Graphics.FillRectangle(greenBrush, 787 - 140, 165, 140, BARHEIGHT);
                e.Graphics.FillRectangle(greenBrush, 787 - BarWidthTotal, 202, BARWIDTH * (EnemyTwo.ActualHP) / (EnemyTwo.BaseHP), BARHEIGHT);
                e.Graphics.DrawRectangle(grayPen, HPBarFive);

                Rectangle SPBarFive = new Rectangle(616, 230, BARWIDTH, BARHEIGHT);
                //e.Graphics.FillRectangle(blueBrush, 787 - 140, 191, 140, BARHEIGHT);
                e.Graphics.FillRectangle(blueBrush, 787 - BarWidthTotal, 230, BARWIDTH * (EnemyTwo.ActualSP) / (EnemyTwo.BaseSP), BARHEIGHT);
                e.Graphics.DrawRectangle(grayPen, SPBarFive);
            }

            if (EnemyThree != null)
            {
                //Character 3
                Rectangle HPBarSix = new Rectangle(616, 303, BARWIDTH, BARHEIGHT);
                //e.Graphics.FillRectangle(greenBrush, 787 - 100, 246, 100, BARHEIGHT);
                e.Graphics.FillRectangle(greenBrush, 787 - BarWidthTotal, 303, BARWIDTH * (EnemyThree.ActualHP) / (EnemyThree.BaseHP), BARHEIGHT);
                e.Graphics.DrawRectangle(grayPen, HPBarSix);

                Rectangle SPBarSix = new Rectangle(616, 331, BARWIDTH, BARHEIGHT);
                //e.Graphics.FillRectangle(blueBrush, 787 - 160, 272, 160, BARHEIGHT);
                e.Graphics.FillRectangle(blueBrush, 787 - BarWidthTotal, 331, BARWIDTH * (EnemyThree.ActualSP) / (EnemyThree.BaseSP), BARHEIGHT);
                e.Graphics.DrawRectangle(grayPen, SPBarSix);
            }
        }
    }
}
