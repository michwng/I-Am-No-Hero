/**       
 * -------------------------------------------------------------------
 * 	   File name: SupportMenu.cs
 * 	Project name: I Am No Hero
 * -------------------------------------------------------------------
 *  Author�s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	05/09/2022	
 *            Last Modified:    05/09/2022
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

namespace I_Am_No_Hero.Menus.BattleMenus.BattleSubMenus
{
    public partial class SupportMenu : Form
    {
        //Ally 1 is assumed to be the hero.
        static Ally AllyOne { get; set; } = new Ally();
        static Ally? AllyTwo { get; set; }
        static Ally? AllyThree { get; set; }

        static Enemy? EnemyOne { get; set; }
        static Enemy? EnemyTwo { get; set; }
        static Enemy? EnemyThree { get; set; }

        static Ally AllyTarget = AllyOne;

        internal static Boolean TurnOver { get; private set; } = false;


        /*
         * The base constructor of the SupportMenu class.
         * 
         * Date Created: 04/25/2022
         * Last Modified: 04/25/2022
         */
        public SupportMenu()
        {
            InitializeComponent();

            HideNonCombatants(true, true);

            InitializeBattle();
        }


        /*
         * The primary constructor of the SupportMenu class.
         * 
         * 
         * Date Created: 04/25/2022
         * Last Modified: 04/25/2022
         */
        public SupportMenu(Ally a1, Ally? a2 = null, Ally? a3 = null)
        {
            InitializeComponent();

            if (a1 is not null)
            {
                AllyOne = a1;
            }

            AllyTwo = a2;
            AllyThree = a3;

            //If AllyTwo is null, we put true. Otherwise, we put false.
            bool AllyTwoIsNull = AllyTwo == null ? true : false;
            bool AllyThreeIsNull = AllyThree == null ? true : false;

            HideNonCombatants(AllyTwoIsNull, AllyThreeIsNull);

            InitializeBattle();
        }


        /*
         * The secondary constructor of the SupportMenu class.
         * Allows modification of enemies in battle.
         * 
         * Date Created: 04/25/2022
         * Last Modified: 04/25/2022
         */
        public SupportMenu(Ally a1, Ally? a2 = null, Ally? a3 = null, Enemy? e1 = null, Enemy? e2 = null, Enemy? e3 = null)
        {
            InitializeComponent();

            if (a1 is not null)
            {
                AllyOne = a1;
            }

            AllyTwo = a2;
            AllyThree = a3;

            //The enemies are not shown in the support menu. There is no need to hide.
            EnemyOne = e1;
            EnemyTwo = e2;
            EnemyThree = e3;

            //If AllyTwo is null, we put true. Otherwise, we put false.
            bool AllyTwoIsNull = AllyTwo == null ? true : false;
            bool AllyThreeIsNull = AllyThree == null ? true : false;

            HideNonCombatants(AllyTwoIsNull, AllyThreeIsNull);

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
        private void HideNonCombatants(bool allyTwoIsNull, bool allyThreeIsNull)
        {
            if (allyTwoIsNull)
            {
                pictureBox2.Hide();
                label5.Hide();
                transparentLabel4.Hide();
                transparentLabel5.Hide();
                transparentLabel11.Hide();
            }
            if (allyThreeIsNull)
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
            if (AllyTarget == AllyOne)
            {
                pictureBox1.BorderStyle = BorderStyle.FixedSingle;
                pictureBox2.BorderStyle = BorderStyle.None;
                pictureBox3.BorderStyle = BorderStyle.None;
                transparentLabel1.Location = new Point(464, 110);
            }
            else if (AllyTarget == AllyTwo)
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
            pictureBox1.ImageLocation = Program.FileRoot + "Sprites" + Path.DirectorySeparatorChar + AllyOne.Name + Path.DirectorySeparatorChar + AllyOne.Name + "Default.png";
            pictureBox1.Image = Image.FromFile(pictureBox1.ImageLocation);
            pictureBox1.Update();
            Console.WriteLine("Enemy Image Location: " + pictureBox1.ImageLocation);

            if (AllyTwo is not null)
            {
                /* Initialize Enemy 2 */
                pictureBox2.ImageLocation = Program.FileRoot + "Sprites" + Path.DirectorySeparatorChar + AllyTwo.Name + Path.DirectorySeparatorChar + AllyTwo.Name + "Default.png";
                pictureBox2.Image = Image.FromFile(pictureBox2.ImageLocation);
                pictureBox2.Update();
                Console.WriteLine("Enemy Image Location: " + pictureBox2.ImageLocation);
            }

            if (AllyThree is not null)
            {
                /* Initialize Enemy 3 */
                pictureBox3.ImageLocation = Program.FileRoot + "Sprites" + Path.DirectorySeparatorChar + AllyThree.Name + Path.DirectorySeparatorChar + AllyThree.Name + "Default.png";
                pictureBox3.Image = Image.FromFile(pictureBox3.ImageLocation);
                pictureBox3.Update();
                Console.WriteLine("Enemy Image Location: " + pictureBox3.ImageLocation);
            }

            AllyTarget = AllyOne;
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
            label4.Text = AllyOne.Name;
            transparentLabel2.Text = AllyOne.ActualHP + " / " + AllyOne.BaseHP;
            transparentLabel3.Text = AllyOne.ActualSP + " / " + AllyOne.BaseSP;

            if (AllyTwo != null)
            {
                label5.Text = AllyTwo.Name;
                transparentLabel4.Text = AllyTwo.ActualHP + " / " + AllyTwo.BaseHP;
                transparentLabel5.Text = AllyTwo.ActualSP + " / " + AllyTwo.BaseSP;
            }
            if (AllyThree != null)
            {
                label6.Text = AllyThree.Name;
                transparentLabel6.Text = AllyThree.ActualHP + " / " + AllyThree.BaseHP;
                transparentLabel7.Text = AllyThree.ActualSP + " / " + AllyThree.BaseSP;
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
            AllyTarget = AllyOne;
            UpdateBoxClick();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AllyTarget = AllyTwo;
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
            AllyTarget = AllyThree;
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

            SpecialSkill skillUsed = AllyOne.SkillSet.SupportSkills[comboBox1.SelectedIndex];
            int skillDamage = skillUsed.BaseDamage;
            bool skillHeals = skillUsed.IsHealingSkill;
            Target target = skillUsed.Target;

            List<Effect> effects = skillUsed.SkillEffects;
            
            //The damage can vary by -15 to 15.
            //This way, we don't repetitively deal
            //the same damage when casting the same move.
            int healVariable = rng.Next(-15, 16);

            Console.WriteLine("Skill Damage: " + skillDamage);
            Console.WriteLine("Heal Variation: " + healVariable);


            double healModifier = 1 + AllyOne.ActualHealingFactor;

            //There is no need to calculate accuracy here.
            //This switch calculates skill 
            switch (target)
            {
                case Target.Self:
                    if (skillHeals)
                    {
                        AllyOne.ActualHP += (int)(skillDamage * healModifier);
                    }
                    else 
                    {
                        AllyOne.ActualHP -= skillDamage;
                    }
                    break;
                case Target.SelfORAlly:
                    if (skillHeals)
                    {
                        AllyTarget.ActualHP += (int)(skillDamage * healModifier);
                    }
                    else
                    {
                        AllyTarget.ActualHP -= skillDamage;
                    }
                    break;
                case Target.SelfANDAllies:
                    if (skillHeals)
                    {
                        AllyOne.ActualHP += (int)(skillDamage * healModifier);
                        if(AllyTwo is not null)
                            AllyTwo.ActualHP += (int)(skillDamage * healModifier);
                        if(AllyThree is not null)
                        AllyThree.ActualHP += (int)(skillDamage * healModifier);
                    }
                    else
                    {
                        AllyOne.ActualHP -= skillDamage;
                        if(AllyTwo is not null)
                            AllyTwo.ActualHP += skillDamage;
                        if(AllyThree is not null)
                        AllyThree.ActualHP += skillDamage;
                    }
                    break;
                case Target.AllAllies:
                    if (skillHeals)
                    {
                        if(AllyTwo is not null)
                            AllyTwo.ActualHP += (int)(skillDamage * healModifier);
                        if(AllyThree is not null)
                        AllyThree.ActualHP += (int)(skillDamage * healModifier);
                    }
                    else
                    {
                        AllyOne.ActualHP -= skillDamage;
                        if (AllyTwo is not null)
                            AllyTwo.ActualHP += skillDamage;
                        if (AllyThree is not null)
                            AllyThree.ActualHP += skillDamage;
                    }
                    break;
            }

            foreach (Effect effect in effects)
            {
                if (effect.EffectLength == 0)
                {
                    //Add individual status effects here.
                }
                else
                {
                    switch (effect.EffectTarget) 
                    {
                        case Target.Self:
                            AllyOne.StatusEffects.Add(effect);
                            break;
                        case Target.AllAllies:
                            AllyTwo.StatusEffects.Add(effect);
                            AllyThree.StatusEffects.Add(effect);
                            break;
                        case Target.Ally:
                            if (AllyTarget == AllyOne)
                            {
                                if (AllyTwo is not null)
                                {
                                    AllyTwo.StatusEffects.Add(effect);
                                }
                                else if (AllyThree is not null)
                                {
                                    AllyThree.StatusEffects.Add(effect);
                                }
                            }
                            else 
                            {
                                //We don't incur any effects on any target. 
                            }
                            break;
                        case Target.Any:
                            AllyTarget.StatusEffects.Add(effect);
                            break;
                        case Target.SelfANDAllies:
                            AllyOne.StatusEffects.Add(effect);
                            AllyTwo.StatusEffects.Add(effect);
                            AllyThree.StatusEffects.Add(effect);
                            break;
                        case Target.SelfORAlly:
                            AllyTarget.StatusEffects.Add(effect);
                            break;
                        default:
                            AllyTarget.StatusEffects.Add(effect);
                            break;
                    }
                    string effectPositiveString = effect.IsPositiveEffect == true ? "Positive" : "Negative";

                    //Another way to set effectPositiveString.
                    /*if (effect.IsPositiveEffect == true)
                    {
                        effectPositiveString = "Positive";
                    }
                    else
                    {
                        effectPositiveString = "Negative";
                    }*/


                    Console.WriteLine($"{AllyTarget.Name} received a {effectPositiveString} Effect!\n - {effect.EffectName} \n   | ({effect.EffectDescription})");
                }
            }


            //Some support skills deal damage to the user.
            //We must make sure the user's HP is not less than or equal to 0
            //After casting the support skill.
            if (AllyTarget.ActualHP <= 0)
            {
                MessageDialog msgDialog = new($"{AllyTarget.Name} fainted!\nThey can no longer fight in this battle.");
                msgDialog.ShowDialog();
            }

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

        private void SupportMenu_Paint(object sender, PaintEventArgs e)
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
            BarWidthTotal = BARWIDTH * AllyOne.ActualHP / AllyOne.BaseHP;
            e.Graphics.FillRectangle(greenBrush, 787 - BarWidthTotal, 102, BarWidthTotal, BARHEIGHT);
            e.Graphics.DrawRectangle(grayPen, HPBarFour);

            Rectangle SPBarFour = new Rectangle(616, 131, BARWIDTH, BARHEIGHT);
            //e.Graphics.FillRectangle(blueBrush, 787 - 140, 110, 140, BARHEIGHT);
            BarWidthTotal = BARWIDTH * AllyOne.ActualSP / AllyOne.BaseSP;
            e.Graphics.FillRectangle(blueBrush, 787 - BarWidthTotal, 131, BarWidthTotal, BARHEIGHT);
            e.Graphics.DrawRectangle(grayPen, SPBarFour);

            if (AllyTwo != null)
            {
                //Character 2
                Rectangle HPBarFive = new Rectangle(616, 202, BARWIDTH, BARHEIGHT);
                //e.Graphics.FillRectangle(greenBrush, 787 - 140, 165, 140, BARHEIGHT);
                e.Graphics.FillRectangle(greenBrush, 787 - BarWidthTotal, 202, BARWIDTH * (AllyTwo.ActualHP) / (AllyTwo.BaseHP), BARHEIGHT);
                e.Graphics.DrawRectangle(grayPen, HPBarFive);

                Rectangle SPBarFive = new Rectangle(616, 230, BARWIDTH, BARHEIGHT);
                //e.Graphics.FillRectangle(blueBrush, 787 - 140, 191, 140, BARHEIGHT);
                e.Graphics.FillRectangle(blueBrush, 787 - BarWidthTotal, 230, BARWIDTH * (AllyTwo.ActualSP) / (AllyTwo.BaseSP), BARHEIGHT);
                e.Graphics.DrawRectangle(grayPen, SPBarFive);
            }

            if (AllyThree != null)
            {
                //Character 3
                Rectangle HPBarSix = new Rectangle(616, 303, BARWIDTH, BARHEIGHT);
                //e.Graphics.FillRectangle(greenBrush, 787 - 100, 246, 100, BARHEIGHT);
                e.Graphics.FillRectangle(greenBrush, 787 - BarWidthTotal, 303, BARWIDTH * (AllyThree.ActualHP) / (AllyThree.BaseHP), BARHEIGHT);
                e.Graphics.DrawRectangle(grayPen, HPBarSix);

                Rectangle SPBarSix = new Rectangle(616, 331, BARWIDTH, BARHEIGHT);
                //e.Graphics.FillRectangle(blueBrush, 787 - 160, 272, 160, BARHEIGHT);
                e.Graphics.FillRectangle(blueBrush, 787 - BarWidthTotal, 331, BARWIDTH * (AllyThree.ActualSP) / (AllyThree.BaseSP), BARHEIGHT);
                e.Graphics.DrawRectangle(grayPen, SPBarSix);
            }
        }
    }
}
