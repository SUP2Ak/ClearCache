namespace ClearCache
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            menuStrip1 = new MenuStrip();
            fichierToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.WindowFrame;
            resources.ApplyResources(button1, "button1");
            button1.FlatAppearance.BorderSize = 2;
            button1.ForeColor = SystemColors.InfoText;
            button1.Name = "button1";
            button1.TabStop = false;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fichierToolStripMenuItem });
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Name = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // fichierToolStripMenuItem
            // 
            fichierToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { quitToolStripMenuItem });
            fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            resources.ApplyResources(fichierToolStripMenuItem, "fichierToolStripMenuItem");
            fichierToolStripMenuItem.Click += fichierToolStripMenuItem_Click;
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            resources.ApplyResources(quitToolStripMenuItem, "quitToolStripMenuItem");
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            //
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            BackgroundImage = Properties.Resources.redm;
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            ShowInTaskbar = false;
            TransparencyKey = Color.Black;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fichierToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private Button button1;
    }
}