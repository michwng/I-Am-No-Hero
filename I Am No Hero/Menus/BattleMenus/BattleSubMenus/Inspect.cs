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
    public partial class Inspect : Form
    {
        public Inspect()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method takes in any child of the BasePerson Class (Ally or Enemy).
        /// <list type="bullet">
        /// <item>This Method Initializes values based on the BasePerson provided.</item>
        /// </list>
        /// </summary>
        /// <param name="bp"></param>
        public Inspect(BasePerson bp)
        {
            InitializeComponent();

            if (bp.GetType() == typeof(Enemy))
            {
                //Because we have a different method of retrieving sprites, we have to see whether bp is of Ally or Enemy.
                pictureBox1.ImageLocation = Program.FileRoot + "Sprites" + Path.DirectorySeparatorChar + "BattleIcons" + Path.DirectorySeparatorChar + bp.Specialization.ToString() + ".png";
                //Console.WriteLine("Enemy Image Location: " + pictureBox1.ImageLocation);
            }
            else 
            {
                pictureBox1.ImageLocation = Program.FileRoot + "Sprites" + Path.DirectorySeparatorChar + bp.Name + Path.DirectorySeparatorChar + bp.Name + "Default.png";
                //Console.WriteLine("Ally Image Location: " + pictureBox1.ImageLocation);
            }
            pictureBox1.Image = Image.FromFile(pictureBox1.ImageLocation);
            pictureBox1.Update();

            label1.Text = bp.Name;
            label2.Text = bp.GetBasicValues();
        }

        /// <summary>
        /// References the More Info Button in the Inspect Menu.
        /// <list type="bullet">
        ///     <item>Whenever the More Info Button is clicked, this method is called.</item>
        /// </list>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MoreInfoButton_Press(object sender, EventArgs e) 
        {
            StringBuilder sb = new();
            sb.Append($"HP represents Health Points - the person's lifeforce.\n" +
                $"  - If HP reaches 0, the person becomes incapacitated.\n");
            sb.Append($"SP represents Skill Points.\n" +
                $"  - A person can perform Special Skills as long as they have enough SP.\n");
            sb.Append($"Constitution represents Physical Prowess.\n" +
                $"  - Constitution directly contributes to Physical-damaging moves.\n");
            sb.Append($"Affinity represents Magical Prowess.\n" +
                $"  - Affinity directly contributes to Magical-damaging moves.\n");
            sb.Append($"Defense reduces damage from Physical Damage.\n");
            sb.Append($"Resistance reduces damage from Magical Damage.\n");
            sb.Append($"Speed determines who goes first in a battle round.\n");

            //MessageBox.Show(sb.ToString());
            MessageDialog msg = new MessageDialog(sb.ToString());
            msg.ResizeMessageBox();
            msg.ShowDialog();
            
        }

        /// <summary>
        /// References the Ok Button in the Inspect Menu.
        /// <list type="bullet">
        ///     <item>Whenever the Ok Button is clicked, this method is called.</item>
        /// </list>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OkButton_Press(object sender, EventArgs e)
        {
            Hide();
        }


    }
}
