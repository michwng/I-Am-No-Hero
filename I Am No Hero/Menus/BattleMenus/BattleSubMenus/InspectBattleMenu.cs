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
    public partial class InspectBattleMenu : Form
    {
        //Ally 1 is assumed to be the hero.
        Ally AllyOne;
        Ally? AllyTwo;
        Ally? AllyThree;

        Enemy EnemyOne;
        Enemy? EnemyTwo;
        Enemy? EnemyThree;

        private static Inspect InspectMenu { get; set; } = null;

        public InspectBattleMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The primary constructor for the InspectBattleMenu class.
        /// Initializes Allies and Enemies to ones specified in the constructor.
        /// </summary>
        /// <param name="allyOne"></param>
        /// <param name="enemyOne"></param>
        /// <param name="allyTwo"></param>
        /// <param name="enemyTwo"></param>
        /// <param name="allyThree"></param>
        /// <param name="enemyThree"></param>
        public InspectBattleMenu(Ally allyOne, Enemy enemyOne, Ally? allyTwo = null, Enemy? enemyTwo = null, Ally? allyThree = null, Enemy? enemyThree = null)
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

            HideNonCombatants(AllyTwoIsNull, AllyThreeIsNull, EnemyTwoIsNull, EnemyThreeIsNull);

            InitializeBattle();
        }/*
         * This method updates the values in the bars.
         * This is called after every turn and at the beginning of battle.
         * 
         * Date Created: 04/25/2022
         * Last Modified: 04/25/2022
         */
        private void InitializeBattle()
        {
            /* Initialize Ally 1 */
            allyPicture1.ImageLocation = Program.FileRoot + "Sprites" + Path.DirectorySeparatorChar + AllyOne.Name + Path.DirectorySeparatorChar + AllyOne.Name + "Default.png";
            allyPicture1.Image = Image.FromFile(allyPicture1.ImageLocation);
            allyPicture1.Update();
            Console.WriteLine("Ally Image Location: " + allyPicture1.ImageLocation);


            /* Initialize Ally 2 */
            if (AllyTwo is not null)
            {
                allyPicture2.ImageLocation = Program.FileRoot + "Sprites" + Path.DirectorySeparatorChar + AllyTwo.Name + Path.DirectorySeparatorChar + AllyTwo.Name + "Default.png";
                allyPicture2.Image = Image.FromFile(allyPicture2.ImageLocation);
                allyPicture2.Update();
                Console.WriteLine("Ally Image Location: " + allyPicture2.ImageLocation);
            }


            /* Initialize Ally 3 */
            if (AllyThree is not null)
            {
                allyPicture3.ImageLocation = Program.FileRoot + "Sprites" + Path.DirectorySeparatorChar + AllyThree.Name + Path.DirectorySeparatorChar + AllyThree.Name + "Default.png";
                allyPicture3.Image = Image.FromFile(allyPicture3.ImageLocation);
                allyPicture3.Update();
                Console.WriteLine("Ally Image Location: " + allyPicture3.ImageLocation);
            }

            //--------------------

            /* Initialize Enemy 1 */
            enemyPicture1.ImageLocation = Program.FileRoot + "Sprites" + Path.DirectorySeparatorChar + "BattleIcons" + Path.DirectorySeparatorChar + EnemyOne.Specialization.ToString() + ".png";
            enemyPicture1.Image = Image.FromFile(enemyPicture1.ImageLocation);
            enemyPicture1.Update();
            Console.WriteLine("Enemy Image Location: " + enemyPicture1.ImageLocation);


            /* Initialize Enemy 2 */
            if (EnemyTwo is not null)
            {
                enemyPicture2.ImageLocation = Program.FileRoot + "Sprites" + Path.DirectorySeparatorChar + "BattleIcons" + Path.DirectorySeparatorChar + EnemyTwo.Specialization.ToString() + ".png";
                enemyPicture2.Image = Image.FromFile(enemyPicture2.ImageLocation);
                enemyPicture2.Update();
                Console.WriteLine("Enemy Image Location: " + enemyPicture2.ImageLocation);
            }

            /* Initialize Enemy 3 */
            if (EnemyThree is not null) 
            {
                enemyPicture3.ImageLocation = Program.FileRoot + "Sprites" + Path.DirectorySeparatorChar + "BattleIcons" + Path.DirectorySeparatorChar + EnemyThree.Specialization.ToString() + ".png";
                enemyPicture3.Image = Image.FromFile(enemyPicture3.ImageLocation);
                enemyPicture3.Update();
                Console.WriteLine("Enemy Image Location: " + enemyPicture3.ImageLocation);
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
        internal void UpdateBarValues()
        {
            //Initialize Ally 1's Bar values.
            label2.Text = AllyOne.Name;
            transparentLabel1.Text = AllyOne.ActualHP + " / " + AllyOne.BaseHP;
            transparentLabel2.Text = AllyOne.ActualSP + " / " + AllyOne.BaseSP;

            if (AllyTwo != null)
            {
                //Intiialize Ally 2's Bar values.
                label3.Text = AllyTwo.Name;
                transparentLabel3.Text = AllyTwo.ActualHP + " / " + AllyTwo.BaseHP;
                transparentLabel4.Text = AllyTwo.ActualSP + " / " + AllyTwo.BaseSP;
            }
            if (AllyThree != null)
            {
                //Initialize Ally 3's Bar values.
                label4.Text = AllyThree.Name;
                transparentLabel5.Text = AllyThree.ActualHP + " / " + AllyThree.BaseHP;
                transparentLabel6.Text = AllyThree.ActualSP + " / " + AllyThree.BaseSP;
            }

            //Initialize Enemy 1's Bar values.
            label5.Text = EnemyOne.Name;
            transparentLabel7.Text = EnemyOne.ActualHP + " / " + EnemyOne.BaseHP;
            transparentLabel8.Text = EnemyOne.ActualSP + " / " + EnemyOne.BaseSP;

            if (EnemyTwo != null)
            {
                label6.Text = EnemyTwo.Name;
                transparentLabel9.Text = EnemyTwo.ActualHP + " / " + EnemyTwo.BaseHP;
                transparentLabel10.Text = EnemyTwo.ActualSP + " / " + EnemyTwo.BaseSP;
            }
            if (EnemyThree != null)
            {
                label7.Text = EnemyThree.Name;
                transparentLabel11.Text = EnemyThree.ActualHP + " / " + EnemyThree.BaseHP;
                transparentLabel12.Text = EnemyThree.ActualSP + " / " + EnemyThree.BaseSP;
            }
        }

        /// <summary>
        /// This method modifies the menu based on the available combatants.
        /// If any Ally or Enemy is initialized as null, 
        /// this method hides their UI element.
        /// <list type="bullet">
        /// <item>Date Created: 04/25/2022</item>
        /// <item>Last Modified: 05/08/2022</item>
        /// </list>
        /// </summary>
        /// <param name="allyTwoIsNull"></param>
        /// <param name="allyThreeIsNull"></param>
        /// <param name="enemyTwoIsNull"></param>
        /// <param name="enemyThreeIsNull"></param>
        private void HideNonCombatants(bool allyTwoIsNull, bool allyThreeIsNull, bool enemyTwoIsNull, bool enemyThreeIsNull)
        {
            if (allyTwoIsNull)
            {
                allyPicture2.Hide();
                label3.Hide();
                transparentLabel3.Hide();
                transparentLabel4.Hide();
                transparentLabel14.Hide();
            }
            if (allyThreeIsNull)
            {
                allyPicture3.Hide();
                label4.Hide();
                transparentLabel5.Hide();
                transparentLabel6.Hide();
                transparentLabel15.Hide();
            }
            if (enemyTwoIsNull)
            {
                enemyPicture2.Hide();
                label6.Hide();
                transparentLabel9.Hide();
                transparentLabel10.Hide();
                transparentLabel17.Hide();
            }
            if (enemyThreeIsNull)
            {
                enemyPicture3.Hide();
                label7.Hide();
                transparentLabel11.Hide();
                transparentLabel12.Hide();
                transparentLabel18.Hide();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            InspectMenu = new Inspect(AllyOne);
            InspectMenu.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            InspectMenu = new Inspect(AllyTwo);
            InspectMenu.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            InspectMenu = new Inspect(AllyThree);
            InspectMenu.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            InspectMenu = new Inspect(EnemyOne);
            InspectMenu.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            InspectMenu = new Inspect(EnemyTwo);
            InspectMenu.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            InspectMenu = new Inspect(EnemyThree);
            InspectMenu.ShowDialog();
        }

        private void ChangeMouseTypeOnHover(object sender, EventArgs e) 
        {
            this.Cursor = Cursors.Hand;
        }

        private void ResetMouseCursor(object sender, EventArgs e) 
        {
            this.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// This method paints solid bars onto the screen, as well as the borders.
        /// This is because the progress bars and lines are more difficult to work with.
        /// 
        /// <list type="bullet">
        /// <item>Date Created: 05/08/2022</item>
        /// <item>Last Modified: 05/08/2022</item>
        /// </list>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InspectBattleMenu_Paint(object sender, PaintEventArgs e)
        {
            const int BARWIDTH = 170;
            const int BARHEIGHT = 20;

            Pen grayPen = new Pen(SystemColors.ActiveBorder);
            Brush greenBrush = new SolidBrush(Color.LightGreen);
            Brush blueBrush = new SolidBrush(Color.LightBlue);

            //Draw Borders
            Rectangle topLine = new(label8.Location.X, label8.Location.Y, label8.Size.Width, label8.Size.Height);
            Rectangle middleLine = new(label9.Location.X, label9.Location.Y, label9.Size.Width, label9.Size.Height);
            Rectangle bottomLine = new(label10.Location.X, label10.Location.Y, label10.Size.Width, label10.Size.Height);

            if (AllyThree is null && EnemyThree is null)
            {
                middleLine.Height = allyPicture1.Size.Height + allyPicture2.Size.Height + 40;
                bottomLine.Y = middleLine.Height + middleLine.Y;

                if (AllyTwo is null && EnemyTwo is null)
                {
                    middleLine.Height = allyPicture1.Size.Height + 20;
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
    }
}
