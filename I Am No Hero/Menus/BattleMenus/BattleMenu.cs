/**       
 * -------------------------------------------------------------------
 * 	   File name: BattleMenu.cs
 * 	Project name: I Am No Hero
 * -------------------------------------------------------------------
 *  Author�s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	04/23/2022	
 *            Last Modified:    04/24/2022
 * -------------------------------------------------------------------
 */

using I_Am_No_Hero.Menus.BattleMenus.BattleSubMenus;
using I_Am_No_Hero.Menus.BattleSubMenus;

namespace I_Am_No_Hero.Menus
{
    public partial class BattleMenu : Form
    {
        public const int BARWIDTH = 170;
        public const int BARHEIGHT = 20;

        //Ally 1 is assumed to be the hero.
        Ally AllyOne;
        Ally? AllyTwo;
        Ally? AllyThree;

        Enemy EnemyOne;
        Enemy? EnemyTwo;
        Enemy? EnemyThree;

        AttackMenu AttackMenu = new();
        SpecialAttackMenu SpecialAttackMenu = new();
        InspectBattleMenu InspectBattleMenu = new();
        SupportMenu SupportMenu = new();

        internal Boolean UsedTurn { get; set; } =  false;

        /*
         * The base constructor of the Battle Menu class.
         * 
         * Date Created: 04/25/2022
         * Last Modified: 04/25/2022
         */
        public BattleMenu()
        {
            InitializeComponent();
            //This will set the size of the window to the screen size.
            //Without this, the size of the window is set to the default size,
            //which is 756X739.
            //this.Width = SystemInformation.VirtualScreen.Width;
            //this.Height = SystemInformation.VirtualScreen.Height;
            AllyOne = new Ally();
            EnemyOne = new Enemy();

            AttackMenu = new(AllyOne, EnemyOne, EnemyTwo, EnemyThree);
            SpecialAttackMenu = new(AllyOne, EnemyOne, EnemyTwo, EnemyThree);
            InspectBattleMenu = new(AllyOne, EnemyOne, AllyTwo, EnemyTwo, AllyThree, EnemyThree);

            HideNonCombatants(true, true, true, true);

            InitializeBattle();
        }

        /*
         * The main constructor of the Battle Menu class.
         * Requires an Ally and an Enemy object. 
         * 
         * Date Created: 04/25/2022
         * Last Modified: 04/25/2022
         * @param Ally allyOne, allyTwo, allyThree
         * @param Enemy enemyOne, enemyTwo, enemyThree
         */
        public BattleMenu(Ally allyOne, Enemy enemyOne, Ally? allyTwo = null, Enemy? enemyTwo = null, Ally? allyThree = null, Enemy? enemyThree = null)
        {
            InitializeComponent();
            AllyOne = allyOne;
            EnemyOne = enemyOne;
            AllyTwo = allyTwo;
            EnemyTwo = enemyTwo;
            AllyThree = allyThree;
            EnemyThree = enemyThree;

            bool AllyTwoIsNull = false;
            bool AllyThreeIsNull = false;
            bool EnemyTwoIsNull = false;
            bool EnemyThreeIsNull = false;

            if (AllyTwo is null) 
            {
                AllyTwoIsNull = true;
            }
            if (AllyThree is null)
            {
                AllyThreeIsNull = true;
            }
            if (EnemyTwo is null)
            {
                EnemyTwoIsNull = true;
            }
            if (EnemyThree is null)
            {
                EnemyThreeIsNull = true;
            }

            AttackMenu = new(AllyOne, EnemyOne, EnemyTwo, EnemyThree);
            SpecialAttackMenu = new(AllyOne, EnemyOne, EnemyTwo, EnemyThree);
            InspectBattleMenu = new(AllyOne, EnemyOne, AllyTwo, EnemyTwo, AllyThree, EnemyThree);

            HideNonCombatants(AllyTwoIsNull, AllyThreeIsNull, EnemyTwoIsNull, EnemyThreeIsNull);

            InitializeBattle();
        }


        /*
         * This method updates the values in the bars.
         * This is called after every turn and at the beginning of battle.
         * 
         * Date Created: 04/25/2022
         * Last Modified: 04/25/2022
         */
        private void InitializeBattle()
        {
            /* Initialize Ally 1 */
            pictureBox1.ImageLocation = Program.FileRoot + "Sprites" + Path.DirectorySeparatorChar + AllyOne.Name + Path.DirectorySeparatorChar + AllyOne.Name + "Default.png";
            pictureBox1.Image = Image.FromFile(pictureBox1.ImageLocation);
            pictureBox1.Update();
            Console.WriteLine("Ally Image Location: " + pictureBox1.ImageLocation);


            /* Initialize Ally 2 */
            if (AllyTwo is not null)
            {
                pictureBox2.ImageLocation = Program.FileRoot + "Sprites" + Path.DirectorySeparatorChar + AllyTwo.Name + Path.DirectorySeparatorChar + AllyTwo.Name + "Default.png";
                pictureBox2.Image = Image.FromFile(pictureBox2.ImageLocation);
                pictureBox2.Update();
                Console.WriteLine("Ally Image Location: " + pictureBox2.ImageLocation);
            }


            /* Initialize Ally 3 */
            if (AllyThree is not null)
            {
                pictureBox3.ImageLocation = Program.FileRoot + "Sprites" + Path.DirectorySeparatorChar + AllyThree.Name + Path.DirectorySeparatorChar + AllyThree.Name + "Default.png";
                pictureBox3.Image = Image.FromFile(pictureBox3.ImageLocation);
                pictureBox3.Update();
                Console.WriteLine("Ally Image Location: " + pictureBox3.ImageLocation);
            }

            //--------------------

            /* Initialize Enemy 1 */
            pictureBox4.ImageLocation = Program.FileRoot + "Sprites" + Path.DirectorySeparatorChar + "BattleIcons" + Path.DirectorySeparatorChar + EnemyOne.Specialization.ToString() + ".png";
            pictureBox4.Image = Image.FromFile(pictureBox4.ImageLocation);
            pictureBox4.Update();
            Console.WriteLine("Enemy Image Location: " + pictureBox4.ImageLocation);


            /* Initialize Enemy 2 */
            if (EnemyTwo is not null)
            {
                pictureBox5.ImageLocation = Program.FileRoot + "Sprites" + Path.DirectorySeparatorChar + "BattleIcons" + Path.DirectorySeparatorChar + EnemyTwo.Specialization.ToString() + ".png";
                pictureBox5.Image = Image.FromFile(pictureBox5.ImageLocation);
                pictureBox5.Update();
                Console.WriteLine("Enemy Image Location: " + pictureBox5.ImageLocation);
            }

            /* Initialize Enemy 3 */
            if (EnemyThree is not null)
            {
                pictureBox6.ImageLocation = Program.FileRoot + "Sprites" + Path.DirectorySeparatorChar + "BattleIcons" + Path.DirectorySeparatorChar + EnemyThree.Specialization.ToString() + ".png";
                pictureBox6.Image = Image.FromFile(pictureBox6.ImageLocation);
                pictureBox6.Update();
                Console.WriteLine("Enemy Image Location: " + pictureBox6.ImageLocation);
            }


            UpdateBarValues();
        }
        
        /*
         * This method updates the values in the bars.
         * This is called after every turn and at the beginning of battle.
         * 
         * 
         * Date Created: 04/25/2022
         * Last Modified: 04/25/2022
         */
        private void UpdateBarValues() 
        {
            //Initialize Ally 1's Bar values.
            label11.Text = AllyOne.Name;
            transparentLabel1.Text = AllyOne.ActualHP + " / " + AllyOne.BaseHP;
            transparentLabel2.Text = AllyOne.ActualSP + " / " + AllyOne.BaseSP;

            if (AllyTwo != null) 
            {
                //Intiialize Ally 2's Bar values.
                label12.Text = AllyTwo.Name;
                transparentLabel3.Text = AllyTwo.ActualHP + " / " + AllyTwo.BaseHP;
                transparentLabel4.Text = AllyTwo.ActualSP + " / " + AllyTwo.BaseSP;
            }
            if (AllyThree != null) 
            {
                //Initialize Ally 3's Bar values.
                label13.Text = AllyThree.Name;
                transparentLabel5.Text = AllyThree.ActualHP + " / " + AllyThree.BaseHP;
                transparentLabel6.Text = AllyThree.ActualSP + " / " + AllyThree.BaseSP;
            }

            //Initialize Enemy 1's Bar values.
            label14.Text = EnemyOne.Name;
            transparentLabel7.Text = EnemyOne.ActualHP + " / " + EnemyOne.BaseHP;
            transparentLabel8.Text = EnemyOne.ActualSP + " / " + EnemyOne.BaseSP;

            if (EnemyTwo != null)
            {
                label15.Text = EnemyTwo.Name;
                transparentLabel9.Text = EnemyTwo.ActualHP + " / " + EnemyTwo.BaseHP;
                transparentLabel10.Text = EnemyTwo.ActualSP + " / " + EnemyTwo.BaseSP;
            }
            if (EnemyThree != null)
            {
                label16.Text = EnemyThree.Name;
                transparentLabel11.Text = EnemyThree.ActualHP + " / " + EnemyThree.BaseHP;
                transparentLabel12.Text = EnemyThree.ActualSP + " / " + EnemyThree.BaseSP;
            }
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
        private void HideNonCombatants(bool allyTwoIsNull, bool allyThreeIsNull, bool enemyTwoIsNull, bool enemyThreeIsNull)
        {
            if (allyTwoIsNull) 
            {
                pictureBox2.Hide();
                label12.Hide();
                transparentLabel3.Hide();
                transparentLabel4.Hide();
                transparentLabel14.Hide();
            }
            if (allyThreeIsNull)
            {
                pictureBox3.Hide();
                label13.Hide();
                transparentLabel5.Hide();
                transparentLabel6.Hide();
                transparentLabel15.Hide();
            }
            if (enemyTwoIsNull)
            {
                pictureBox5.Hide();
                label15.Hide();
                transparentLabel9.Hide();
                transparentLabel10.Hide();
                transparentLabel17.Hide();
            }
            if (enemyThreeIsNull)
            {
                pictureBox6.Hide();
                label16.Hide();
                transparentLabel11.Hide();
                transparentLabel12.Hide();
                transparentLabel18.Hide();
            }
        }


        /*  
         * -------------------------------------------------------------------
         * 	            
         * 	            UI Interaction Methods
         * 	            
         * -------------------------------------------------------------------
         */


        /*
         * References the Attack Button.
         * Brings up a submenu, allowing the user 
         * to pick who to attack and which move to use.
         * 
         * Date Created: 04/23/2022
         * Last Modified: 
         */
        private void Attack_Click(object sender, EventArgs e)
        {
            AttackMenu.UpdateBarValues();

            //When Show() is called, the method contiues to execute this.UpdateBarValues
            //and the Console.WriteLine without waiting for the atkMenu to finish.
            //atkMenu.Show();

            //ShowDialog allows the Thread to wait on the atkMenu to finish.
            AttackMenu.ShowDialog();


            UpdateAllMenus();

            if (AttackMenu.TurnOver == true)
            {
                Console.WriteLine("Attack Menu Utilized.");
                UsedTurn = true;
                this.Hide();
            }
        }

        /*
         * References the Special Attack Button.
         * Brings up a submenu, allowing the user 
         * to pick who to attack and which special move to use.
         * 
         * Date Created: 04/23/2022
         * Last Modified: 04/23/2022
         */
        private void SpecialAttack_Click(object sender, EventArgs e)
        {
            SpecialAttackMenu.UpdateBarValues();

            //When Show() is called, the method contiues to execute this.UpdateBarValues
            //and the Console.WriteLine without waiting for the atkMenu to finish.
            //atkMenu.Show();

            //ShowDialog allows the Thread to wait on the atkMenu to finish.
            SpecialAttackMenu.ShowDialog();


            UpdateAllMenus();

            if (SpecialAttackMenu.TurnOver == true)
            {
                Console.WriteLine("Special Attack Menu Utilized.");
                UsedTurn = true;
                this.Hide();
            }
        }

        /*
         * References the Inspect Battle Button.
         * Brings up a submenu, allowing the user 
         * to observe all combatants' stats and statuses.
         * 
         * Date Created: 04/23/2022
         * Last Modified: 04/23/2022
         */
        private void InspectBattle_Click(object sender, EventArgs e)
        {
            InspectBattleMenu.UpdateBarValues();
            InspectBattleMenu.ShowDialog();
            UpdateAllMenus();
        }

        /*
         * References the Mend/Support Button.
         * Brings up a submenu, allowing the user 
         * to pick who to support and which move to use.
         * 
         * Date Created: 04/23/2022
         * Last Modified: 04/23/2022
         */
        private void MendSupport_Click(object sender, EventArgs e)
        {
            SupportMenu.UpdateBarValues();
            SupportMenu.ShowDialog();
            UpdateAllMenus();

            if (SupportMenu.TurnOver == true) 
            {
                Console.WriteLine("Support Menu Utilized.");
                UsedTurn = true;
                this.Hide();
            }
        }

        /*
         * References the Flee the Battle Button.
         * Escapes the current battle.
         * 
         * Date Created: 04/23/2022
         * Last Modified: 04/23/2022
         */
        private void FleeTheBattle_Click(object sender, EventArgs e)
        {
            DecisionDialog decisionDialog = new();
            decisionDialog.label1.Text = "Are You Sure You Want to Flee?";
            decisionDialog.ShowDialog();
            
            if (decisionDialog.Choice == true) 
            {
                //Flee the Battle
                UsedTurn = true;
                this.Close();
                Battle.BattleOutcome = 'f';
            }

            //Else, go back to the battle.
            UpdateAllMenus();
        }

        /*
         * This method paints solid bars onto the screen, as well as borders.
         * This is because the progress bars and lines are more difficult to work with.
         * 
         * Date Created: 04/23/2022
         * Last Modified: 04/25/2022
         */
        private void BattleMenu_Paint(object sender, PaintEventArgs e) 
        {
            Pen grayPen = new Pen(SystemColors.ActiveBorder);
            Brush greenBrush = new SolidBrush(Color.LightGreen);
            Brush blueBrush = new SolidBrush(Color.LightBlue);

            //Draw Borders
            Rectangle topLine = new(12, 45, 700, 1);
            Rectangle middleLine = new(362, 46, 1, 318);
            Rectangle bottomLine = new(12, 364, 700, 1);

            if (AllyThree is null && EnemyThree is null)
            {
                middleLine.Height = pictureBox1.Size.Height + pictureBox2.Size.Height + 40;
                bottomLine.Y = middleLine.Height + middleLine.Y;

                if (AllyTwo is null && EnemyTwo is null)
                {
                    middleLine.Height = pictureBox1.Size.Height + 20;
                    bottomLine.Y = middleLine.Height + middleLine.Y;
                }
            }

            e.Graphics.Clear(SystemColors.Control);
            e.Graphics.DrawRectangle(grayPen, topLine);
            e.Graphics.DrawRectangle(grayPen, middleLine);
            e.Graphics.DrawRectangle(grayPen, bottomLine);


            //Drawing HP/SP Bars for Allies
            //Ally 1
            Rectangle HPBarOne = new(progressBar1.Location.X, progressBar1.Location.Y, BARWIDTH, BARHEIGHT);
            //e.Graphics.FillRectangle(greenBrush, 168, 84, 140, BARHEIGHT);
            e.Graphics.FillRectangle(greenBrush, progressBar1.Location.X, progressBar1.Location.Y, BARWIDTH * (AllyOne.ActualHP) / (AllyOne.BaseHP), BARHEIGHT);
            e.Graphics.DrawRectangle(grayPen, HPBarOne);

            Rectangle SPBarOne = new Rectangle(progressBar2.Location.X, progressBar2.Location.Y, BARWIDTH, BARHEIGHT);
            //e.Graphics.FillRectangle(blueBrush, 168, 110, 140, BARHEIGHT);
            e.Graphics.FillRectangle(blueBrush, progressBar2.Location.X, progressBar2.Location.Y, BARWIDTH * (AllyOne.ActualSP) / (AllyOne.BaseSP), BARHEIGHT);
            e.Graphics.DrawRectangle(grayPen, SPBarOne);

            //TODO - Copy top BARWIDTH * (AllyOne.ActualSP) / (AllyOne.BaseSP) to statements below.

            if (AllyTwo != null)
            {
                //Ally 2
                Rectangle HPBarTwo = new Rectangle(progressBar3.Location.X, progressBar3.Location.Y, BARWIDTH, BARHEIGHT);
                //e.Graphics.FillRectangle(greenBrush, 162, 191, 140, BARHEIGHT);
                e.Graphics.FillRectangle(greenBrush, progressBar3.Location.X, progressBar3.Location.Y, BARWIDTH * (AllyTwo.ActualHP) / (AllyTwo.BaseHP), BARHEIGHT);
                e.Graphics.DrawRectangle(grayPen, HPBarTwo);

                Rectangle SPBarTwo = new Rectangle(progressBar4.Location.X, progressBar4.Location.Y, BARWIDTH, BARHEIGHT);
                //e.Graphics.FillRectangle(blueBrush, 162, 219, 140, BARHEIGHT); 
                e.Graphics.FillRectangle(blueBrush, progressBar4.Location.X, progressBar4.Location.Y, BARWIDTH * (AllyTwo.ActualSP) / (AllyTwo.BaseSP), BARHEIGHT);
                e.Graphics.DrawRectangle(grayPen, SPBarTwo);
            }
            if (AllyThree != null)
            {
                //Ally 3
                Rectangle HPBarThree = new Rectangle(progressBar5.Location.X, progressBar5.Location.Y, BARWIDTH, BARHEIGHT);
                //e.Graphics.FillRectangle(greenBrush, 162, 292, 140, BARHEIGHT);
                e.Graphics.FillRectangle(greenBrush, progressBar5.Location.X, progressBar5.Location.Y, BARWIDTH * (AllyThree.ActualHP) / (AllyThree.BaseHP), BARHEIGHT);
                e.Graphics.DrawRectangle(grayPen, HPBarThree);

                Rectangle SPBarThree = new Rectangle(progressBar6.Location.X, progressBar6.Location.Y, BARWIDTH, BARHEIGHT);
                //e.Graphics.FillRectangle(blueBrush, 162, 320, 140, BARHEIGHT);
                e.Graphics.FillRectangle(blueBrush, progressBar6.Location.X, progressBar6.Location.Y, BARWIDTH * (AllyThree.ActualSP) / (AllyThree.BaseSP), BARHEIGHT);
                e.Graphics.DrawRectangle(grayPen, SPBarThree);
            }


            //Drawing HP/SP Bars for Enemies

            //Helps to reduce excess code.
            int BarWidthTotal = 0;
            //Painting enemy HP and SP values are different then allies.
            //We must also take into concern each enemy's HP and SP value,
            //so we can accurately display it in the menu.
            int EnemyBarPaintWidth = 0;

            //Enemy 1
            Rectangle HPBarFour = new Rectangle(progressBar7.Location.X, progressBar7.Location.Y, BARWIDTH, BARHEIGHT);
            //e.Graphics.FillRectangle(greenBrush, 557 - 66, 84, 66, BARHEIGHT);
            BarWidthTotal = BARWIDTH * (EnemyOne.ActualHP) / (EnemyOne.BaseHP);
            EnemyBarPaintWidth = progressBar7.Location.X + progressBar7.Size.Width - BarWidthTotal;
            e.Graphics.FillRectangle(greenBrush, EnemyBarPaintWidth, progressBar7.Location.Y, BarWidthTotal, BARHEIGHT);
            e.Graphics.DrawRectangle(grayPen, HPBarFour);

            Rectangle SPBarFour = new Rectangle(progressBar8.Location.X, progressBar8.Location.Y, BARWIDTH, BARHEIGHT);
            //e.Graphics.FillRectangle(blueBrush, 566 - 140, 110, 140, BARHEIGHT);
            BarWidthTotal = BARWIDTH * (EnemyOne.ActualSP) / (EnemyOne.BaseSP);
            EnemyBarPaintWidth = progressBar8.Location.X + progressBar8.Size.Width - BarWidthTotal;
            e.Graphics.FillRectangle(blueBrush, EnemyBarPaintWidth, progressBar8.Location.Y, BarWidthTotal, BARHEIGHT);
            e.Graphics.DrawRectangle(grayPen, SPBarFour);

            if (EnemyTwo != null)
            {
                //Enemy 2
                Rectangle HPBarFive = new Rectangle(progressBar9.Location.X, progressBar9.Location.Y, BARWIDTH, BARHEIGHT);
                //e.Graphics.FillRectangle(greenBrush, 557 - 140, 165, 140, BARHEIGHT);
                BarWidthTotal = BARWIDTH * (EnemyTwo.ActualHP) / (EnemyTwo.BaseHP);
                EnemyBarPaintWidth = progressBar9.Location.X + progressBar9.Size.Width - BarWidthTotal;
                e.Graphics.FillRectangle(greenBrush, EnemyBarPaintWidth, progressBar9.Location.Y, BarWidthTotal, BARHEIGHT);
                e.Graphics.DrawRectangle(grayPen, HPBarFive);

                Rectangle SPBarFive = new Rectangle(progressBar10.Location.X, progressBar10.Location.Y, BARWIDTH, BARHEIGHT);
                //e.Graphics.FillRectangle(blueBrush, 557 - 140, 191, 140, BARHEIGHT);
                BarWidthTotal = BARWIDTH * (EnemyTwo.ActualSP) / (EnemyTwo.BaseSP);
                EnemyBarPaintWidth = progressBar10.Location.X + progressBar10.Size.Width - BarWidthTotal;
                e.Graphics.FillRectangle(blueBrush, EnemyBarPaintWidth, progressBar10.Location.Y, BarWidthTotal, BARHEIGHT);
                e.Graphics.DrawRectangle(grayPen, SPBarFive);
            }

            if (EnemyThree != null)
            {
                //Enemy 3
                Rectangle HPBarSix = new Rectangle(progressBar11.Location.X, progressBar11.Location.Y, BARWIDTH, BARHEIGHT);
                //e.Graphics.FillRectangle(greenBrush, 557 - 100, 246, 100, BARHEIGHT);
                BarWidthTotal = BARWIDTH * (EnemyThree.ActualHP) / (EnemyThree.BaseHP);
                EnemyBarPaintWidth = progressBar11.Location.X + progressBar11.Size.Width - BarWidthTotal;
                e.Graphics.FillRectangle(greenBrush, EnemyBarPaintWidth, progressBar11.Location.Y, BarWidthTotal, BARHEIGHT);
                e.Graphics.DrawRectangle(grayPen, HPBarSix);

                Rectangle SPBarSix = new Rectangle(progressBar11.Location.X, progressBar11.Location.Y, BARWIDTH, BARHEIGHT);
                //e.Graphics.FillRectangle(blueBrush, 557 - 160, 272, 160, BARHEIGHT);
                BarWidthTotal = BARWIDTH * BARWIDTH * (EnemyThree.ActualSP) / (EnemyThree.BaseSP);
                EnemyBarPaintWidth = progressBar11.Location.X + progressBar11.Size.Width - BarWidthTotal;
                e.Graphics.FillRectangle(blueBrush, EnemyBarPaintWidth, progressBar12.Location.Y, BarWidthTotal, BARHEIGHT);
                e.Graphics.DrawRectangle(grayPen, SPBarSix);
            }
        }

        /// <summary>
        /// UpdateAllmenus updates the bars and values of all menus.
        /// </summary>
        private void UpdateAllMenus()
        {
            this.UpdateBarValues();
            this.Refresh();

            AttackMenu.UpdateBarValues();
            AttackMenu.Refresh();

            SpecialAttackMenu.UpdateBarValues();
            SpecialAttackMenu.Refresh();
            
            InspectBattleMenu.UpdateBarValues();
            InspectBattleMenu.Refresh();

            SupportMenu.UpdateBarValues();
            SupportMenu.Refresh();
        }
    }
}
