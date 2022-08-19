/**       
 * -------------------------------------------------------------------
 * 	   File name: MessageDialog.Designer.cs
 * 	Project name: I Am No Hero
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	03/17/2022	
 *            Last Modified:    03/17/2022
 * -------------------------------------------------------------------
 */

namespace I_Am_No_Hero
{
    partial class MessageDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.MaximumSize = new System.Drawing.Size(575, 1020);
            this.label1.MinimumSize = new System.Drawing.Size(575, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(575, 95);
            this.label1.TabIndex = 0;
            this.label1.Text = "(Message Here)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(240, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(8, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(579, 2);
            this.label2.TabIndex = 2;
            // 
            // MessageDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(594, 170);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MessageDialog";
            this.Opacity = 0.98D;
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.Text = "Message";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// The resize message box resizes the message based on the contents of label 1.
        /// </summary>
        internal void ResizeMessageBox() 
        {
            label2.Location = new System.Drawing.Point(8, label1.Location.Y + label1.Size.Height + 10);
            button1.Location = new System.Drawing.Point(240, label2.Location.Y + label2.Size.Height + 10);
        }


        #endregion

        internal Label label1;
        private Label label2;
        private Button button1;
    }
}