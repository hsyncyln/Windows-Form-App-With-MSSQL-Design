namespace NorthWnd2
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnConnect = new System.Windows.Forms.Button();
            this.treeViewDatabase = new System.Windows.Forms.TreeView();
            this.cntxtMenuTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconList = new System.Windows.Forms.ImageList(this.components);
            this.cntxtMenuTreeView.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(86, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // treeViewDatabase
            // 
            this.treeViewDatabase.ContextMenuStrip = this.cntxtMenuTreeView;
            this.treeViewDatabase.ImageIndex = 6;
            this.treeViewDatabase.ImageList = this.iconList;
            this.treeViewDatabase.Location = new System.Drawing.Point(22, 50);
            this.treeViewDatabase.Name = "treeViewDatabase";
            this.treeViewDatabase.SelectedImageIndex = 6;
            this.treeViewDatabase.Size = new System.Drawing.Size(248, 324);
            this.treeViewDatabase.TabIndex = 2;
            this.treeViewDatabase.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewDatabase_AfterSelect);
            // 
            // cntxtMenuTreeView
            // 
            this.cntxtMenuTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateToolStripMenuItem});
            this.cntxtMenuTreeView.Name = "cntxtMenuTreeView";
            this.cntxtMenuTreeView.Size = new System.Drawing.Size(152, 26);
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.generateToolStripMenuItem.Text = "Generate Class";
            this.generateToolStripMenuItem.Click += new System.EventHandler(this.GenerateToolStripMenuItem_Click);
            // 
            // iconList
            // 
            this.iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList.ImageStream")));
            this.iconList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconList.Images.SetKeyName(0, "server.png");
            this.iconList.Images.SetKeyName(1, "database.png");
            this.iconList.Images.SetKeyName(2, "table.png");
            this.iconList.Images.SetKeyName(3, "column.jpg");
            this.iconList.Images.SetKeyName(4, "primary_key.png");
            this.iconList.Images.SetKeyName(5, "Foreign_key.jpg");
            this.iconList.Images.SetKeyName(6, "imlec.png");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 386);
            this.Controls.Add(this.treeViewDatabase);
            this.Controls.Add(this.btnConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.cntxtMenuTreeView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TreeView treeViewDatabase;
        private System.Windows.Forms.ContextMenuStrip cntxtMenuTreeView;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ImageList iconList;
    }
}

