namespace Hyper_V_Assistant
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fichierDeConfigurationcsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonCreationVSwitch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDeleteVMSwitch = new System.Windows.Forms.Button();
            this.buttonAjoutVMSwitch = new System.Windows.Forms.Button();
            this.checkBoxINT = new System.Windows.Forms.CheckBox();
            this.checkBoxLAN = new System.Windows.Forms.CheckBox();
            this.checkBoxWAN = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNameVMSwitch = new System.Windows.Forms.TextBox();
            this.checkedListBoxVMSwitch = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkedListBoxMaster = new System.Windows.Forms.CheckedListBox();
            this.buttonParcourirMaster = new System.Windows.Forms.Button();
            this.textBoxMasterPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonAjoutVMSwitchToVM = new System.Windows.Forms.Button();
            this.buttonParcourirVHDPath = new System.Windows.Forms.Button();
            this.buttonCreateVM = new System.Windows.Forms.Button();
            this.textBoxRAM = new System.Windows.Forms.TextBox();
            this.textBoxVHDPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBarRAM = new System.Windows.Forms.TrackBar();
            this.textBoxVMName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonDeleteVM = new System.Windows.Forms.Button();
            this.checkedListBoxVM = new System.Windows.Forms.CheckedListBox();
            this.buttonParcourirVMPath = new System.Windows.Forms.Button();
            this.textBoxVMPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBoxLogs = new System.Windows.Forms.ListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRAM)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.aideToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1022, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierDeConfigurationcsvToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // fichierDeConfigurationcsvToolStripMenuItem
            // 
            this.fichierDeConfigurationcsvToolStripMenuItem.Name = "fichierDeConfigurationcsvToolStripMenuItem";
            this.fichierDeConfigurationcsvToolStripMenuItem.Size = new System.Drawing.Size(291, 26);
            this.fichierDeConfigurationcsvToolStripMenuItem.Text = "Fichier de configuration (.csv)... ";
            this.fichierDeConfigurationcsvToolStripMenuItem.Click += new System.EventHandler(this.FichierDeConfigurationcsvToolStripMenuItem_Click);
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.aideToolStripMenuItem.Text = "Aide";
            this.aideToolStripMenuItem.Click += new System.EventHandler(this.AideToolStripMenuItem_Click);
            // 
            // ButtonCreationVSwitch
            // 
            this.ButtonCreationVSwitch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCreationVSwitch.Location = new System.Drawing.Point(12, 31);
            this.ButtonCreationVSwitch.Name = "ButtonCreationVSwitch";
            this.ButtonCreationVSwitch.Size = new System.Drawing.Size(272, 32);
            this.ButtonCreationVSwitch.TabIndex = 1;
            this.ButtonCreationVSwitch.Text = "Création des VSwitch de Base";
            this.ButtonCreationVSwitch.UseVisualStyleBackColor = true;
            this.ButtonCreationVSwitch.Click += new System.EventHandler(this.Button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDeleteVMSwitch);
            this.groupBox1.Controls.Add(this.buttonAjoutVMSwitch);
            this.groupBox1.Controls.Add(this.checkBoxINT);
            this.groupBox1.Controls.Add(this.checkBoxLAN);
            this.groupBox1.Controls.Add(this.checkBoxWAN);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxNameVMSwitch);
            this.groupBox1.Controls.Add(this.checkedListBoxVMSwitch);
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 426);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "VSwitches";
            // 
            // buttonDeleteVMSwitch
            // 
            this.buttonDeleteVMSwitch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonDeleteVMSwitch.Location = new System.Drawing.Point(6, 390);
            this.buttonDeleteVMSwitch.Name = "buttonDeleteVMSwitch";
            this.buttonDeleteVMSwitch.Size = new System.Drawing.Size(260, 30);
            this.buttonDeleteVMSwitch.TabIndex = 3;
            this.buttonDeleteVMSwitch.Text = "Supprimer";
            this.buttonDeleteVMSwitch.UseVisualStyleBackColor = true;
            this.buttonDeleteVMSwitch.Click += new System.EventHandler(this.Button3_Click);
            // 
            // buttonAjoutVMSwitch
            // 
            this.buttonAjoutVMSwitch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonAjoutVMSwitch.Location = new System.Drawing.Point(6, 78);
            this.buttonAjoutVMSwitch.Name = "buttonAjoutVMSwitch";
            this.buttonAjoutVMSwitch.Size = new System.Drawing.Size(260, 28);
            this.buttonAjoutVMSwitch.TabIndex = 3;
            this.buttonAjoutVMSwitch.Text = "Ajouter";
            this.buttonAjoutVMSwitch.UseVisualStyleBackColor = true;
            this.buttonAjoutVMSwitch.Click += new System.EventHandler(this.Button2_Click);
            // 
            // checkBoxINT
            // 
            this.checkBoxINT.AccessibleDescription = "";
            this.checkBoxINT.AutoSize = true;
            this.checkBoxINT.Location = new System.Drawing.Point(214, 53);
            this.checkBoxINT.Name = "checkBoxINT";
            this.checkBoxINT.Size = new System.Drawing.Size(52, 21);
            this.checkBoxINT.TabIndex = 3;
            this.checkBoxINT.Text = "INT";
            this.checkBoxINT.UseVisualStyleBackColor = true;
            this.checkBoxINT.Click += new System.EventHandler(this.CheckBox3_Click);
            // 
            // checkBoxLAN
            // 
            this.checkBoxLAN.AccessibleDescription = "";
            this.checkBoxLAN.AutoSize = true;
            this.checkBoxLAN.Location = new System.Drawing.Point(107, 53);
            this.checkBoxLAN.Name = "checkBoxLAN";
            this.checkBoxLAN.Size = new System.Drawing.Size(57, 21);
            this.checkBoxLAN.TabIndex = 3;
            this.checkBoxLAN.Text = "LAN";
            this.checkBoxLAN.UseVisualStyleBackColor = true;
            this.checkBoxLAN.Click += new System.EventHandler(this.CheckBox2_Click);
            // 
            // checkBoxWAN
            // 
            this.checkBoxWAN.AccessibleDescription = "";
            this.checkBoxWAN.AutoSize = true;
            this.checkBoxWAN.Location = new System.Drawing.Point(9, 53);
            this.checkBoxWAN.Name = "checkBoxWAN";
            this.checkBoxWAN.Size = new System.Drawing.Size(62, 21);
            this.checkBoxWAN.TabIndex = 3;
            this.checkBoxWAN.Text = "WAN";
            this.checkBoxWAN.UseVisualStyleBackColor = true;
            this.checkBoxWAN.Click += new System.EventHandler(this.CheckBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nom du VSwitch";
            // 
            // textBoxNameVMSwitch
            // 
            this.textBoxNameVMSwitch.Location = new System.Drawing.Point(122, 21);
            this.textBoxNameVMSwitch.Name = "textBoxNameVMSwitch";
            this.textBoxNameVMSwitch.Size = new System.Drawing.Size(144, 22);
            this.textBoxNameVMSwitch.TabIndex = 3;
            this.textBoxNameVMSwitch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyDown);
            // 
            // checkedListBoxVMSwitch
            // 
            this.checkedListBoxVMSwitch.CheckOnClick = true;
            this.checkedListBoxVMSwitch.FormattingEnabled = true;
            this.checkedListBoxVMSwitch.Location = new System.Drawing.Point(6, 112);
            this.checkedListBoxVMSwitch.Name = "checkedListBoxVMSwitch";
            this.checkedListBoxVMSwitch.Size = new System.Drawing.Size(260, 276);
            this.checkedListBoxVMSwitch.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkedListBoxMaster);
            this.groupBox2.Controls.Add(this.buttonParcourirMaster);
            this.groupBox2.Controls.Add(this.textBoxMasterPath);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(290, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(358, 250);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Masters";
            // 
            // checkedListBoxMaster
            // 
            this.checkedListBoxMaster.CheckOnClick = true;
            this.checkedListBoxMaster.FormattingEnabled = true;
            this.checkedListBoxMaster.Location = new System.Drawing.Point(6, 70);
            this.checkedListBoxMaster.Name = "checkedListBoxMaster";
            this.checkedListBoxMaster.Size = new System.Drawing.Size(346, 174);
            this.checkedListBoxMaster.TabIndex = 4;
            this.checkedListBoxMaster.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckedListBox2_ItemCheck);
            // 
            // buttonParcourirMaster
            // 
            this.buttonParcourirMaster.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonParcourirMaster.Location = new System.Drawing.Point(262, 15);
            this.buttonParcourirMaster.Name = "buttonParcourirMaster";
            this.buttonParcourirMaster.Size = new System.Drawing.Size(89, 23);
            this.buttonParcourirMaster.TabIndex = 4;
            this.buttonParcourirMaster.Text = "Parcourir";
            this.buttonParcourirMaster.UseVisualStyleBackColor = true;
            this.buttonParcourirMaster.Click += new System.EventHandler(this.Button4_Click);
            // 
            // textBoxMasterPath
            // 
            this.textBoxMasterPath.Location = new System.Drawing.Point(114, 16);
            this.textBoxMasterPath.Name = "textBoxMasterPath";
            this.textBoxMasterPath.ReadOnly = true;
            this.textBoxMasterPath.Size = new System.Drawing.Size(142, 22);
            this.textBoxMasterPath.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Chemin Master";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonAjoutVMSwitchToVM);
            this.groupBox3.Controls.Add(this.buttonParcourirVHDPath);
            this.groupBox3.Controls.Add(this.buttonCreateVM);
            this.groupBox3.Controls.Add(this.textBoxRAM);
            this.groupBox3.Controls.Add(this.textBoxVHDPath);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.trackBarRAM);
            this.groupBox3.Controls.Add(this.textBoxVMName);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.buttonDeleteVM);
            this.groupBox3.Controls.Add(this.checkedListBoxVM);
            this.groupBox3.Controls.Add(this.buttonParcourirVMPath);
            this.groupBox3.Controls.Add(this.textBoxVMPath);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(654, 31);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(358, 464);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "VMs";
            // 
            // buttonAjoutVMSwitchToVM
            // 
            this.buttonAjoutVMSwitchToVM.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonAjoutVMSwitchToVM.Location = new System.Drawing.Point(181, 428);
            this.buttonAjoutVMSwitchToVM.Name = "buttonAjoutVMSwitchToVM";
            this.buttonAjoutVMSwitchToVM.Size = new System.Drawing.Size(171, 30);
            this.buttonAjoutVMSwitchToVM.TabIndex = 16;
            this.buttonAjoutVMSwitchToVM.Text = "Add VSwitch";
            this.buttonAjoutVMSwitchToVM.UseVisualStyleBackColor = true;
            this.buttonAjoutVMSwitchToVM.Click += new System.EventHandler(this.Button9_Click);
            // 
            // buttonParcourirVHDPath
            // 
            this.buttonParcourirVHDPath.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonParcourirVHDPath.Location = new System.Drawing.Point(265, 79);
            this.buttonParcourirVHDPath.Name = "buttonParcourirVHDPath";
            this.buttonParcourirVHDPath.Size = new System.Drawing.Size(89, 23);
            this.buttonParcourirVHDPath.TabIndex = 15;
            this.buttonParcourirVHDPath.Text = "Parcourir";
            this.buttonParcourirVHDPath.UseVisualStyleBackColor = true;
            this.buttonParcourirVHDPath.Click += new System.EventHandler(this.Button8_Click);
            // 
            // buttonCreateVM
            // 
            this.buttonCreateVM.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCreateVM.Location = new System.Drawing.Point(238, 120);
            this.buttonCreateVM.Name = "buttonCreateVM";
            this.buttonCreateVM.Size = new System.Drawing.Size(114, 28);
            this.buttonCreateVM.TabIndex = 4;
            this.buttonCreateVM.Text = "Ajouter";
            this.buttonCreateVM.UseVisualStyleBackColor = true;
            this.buttonCreateVM.Click += new System.EventHandler(this.Button7_Click);
            // 
            // textBoxRAM
            // 
            this.textBoxRAM.Location = new System.Drawing.Point(53, 126);
            this.textBoxRAM.Name = "textBoxRAM";
            this.textBoxRAM.ReadOnly = true;
            this.textBoxRAM.Size = new System.Drawing.Size(113, 22);
            this.textBoxRAM.TabIndex = 12;
            // 
            // textBoxVHDPath
            // 
            this.textBoxVHDPath.Location = new System.Drawing.Point(117, 79);
            this.textBoxVHDPath.Name = "textBoxVHDPath";
            this.textBoxVHDPath.ReadOnly = true;
            this.textBoxVHDPath.Size = new System.Drawing.Size(142, 22);
            this.textBoxVHDPath.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Chemin VHD";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "RAM";
            // 
            // trackBarRAM
            // 
            this.trackBarRAM.Location = new System.Drawing.Point(6, 154);
            this.trackBarRAM.Name = "trackBarRAM";
            this.trackBarRAM.Size = new System.Drawing.Size(346, 56);
            this.trackBarRAM.TabIndex = 8;
            this.trackBarRAM.Scroll += new System.EventHandler(this.TrackBar1_Scroll);
            // 
            // textBoxVMName
            // 
            this.textBoxVMName.Location = new System.Drawing.Point(117, 18);
            this.textBoxVMName.Name = "textBoxVMName";
            this.textBoxVMName.Size = new System.Drawing.Size(142, 22);
            this.textBoxVMName.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Nom de la VM";
            // 
            // buttonDeleteVM
            // 
            this.buttonDeleteVM.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonDeleteVM.Location = new System.Drawing.Point(6, 428);
            this.buttonDeleteVM.Name = "buttonDeleteVM";
            this.buttonDeleteVM.Size = new System.Drawing.Size(169, 30);
            this.buttonDeleteVM.TabIndex = 4;
            this.buttonDeleteVM.Text = "Supprimer";
            this.buttonDeleteVM.UseVisualStyleBackColor = true;
            this.buttonDeleteVM.Click += new System.EventHandler(this.Button6_Click);
            // 
            // checkedListBoxVM
            // 
            this.checkedListBoxVM.CheckOnClick = true;
            this.checkedListBoxVM.FormattingEnabled = true;
            this.checkedListBoxVM.Location = new System.Drawing.Point(6, 216);
            this.checkedListBoxVM.Name = "checkedListBoxVM";
            this.checkedListBoxVM.Size = new System.Drawing.Size(346, 208);
            this.checkedListBoxVM.TabIndex = 8;
            // 
            // buttonParcourirVMPath
            // 
            this.buttonParcourirVMPath.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonParcourirVMPath.Location = new System.Drawing.Point(265, 48);
            this.buttonParcourirVMPath.Name = "buttonParcourirVMPath";
            this.buttonParcourirVMPath.Size = new System.Drawing.Size(89, 23);
            this.buttonParcourirVMPath.TabIndex = 7;
            this.buttonParcourirVMPath.Text = "Parcourir";
            this.buttonParcourirVMPath.UseVisualStyleBackColor = true;
            this.buttonParcourirVMPath.Click += new System.EventHandler(this.Button5_Click);
            // 
            // textBoxVMPath
            // 
            this.textBoxVMPath.Location = new System.Drawing.Point(117, 48);
            this.textBoxVMPath.Name = "textBoxVMPath";
            this.textBoxVMPath.ReadOnly = true;
            this.textBoxVMPath.Size = new System.Drawing.Size(142, 22);
            this.textBoxVMPath.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Chemin VM";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBoxLogs);
            this.groupBox4.Controls.Add(this.progressBar1);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(290, 281);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(358, 214);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Moniteur";
            // 
            // listBoxLogs
            // 
            this.listBoxLogs.FormattingEnabled = true;
            this.listBoxLogs.ItemHeight = 16;
            this.listBoxLogs.Location = new System.Drawing.Point(6, 92);
            this.listBoxLogs.Name = "listBoxLogs";
            this.listBoxLogs.Size = new System.Drawing.Size(346, 116);
            this.listBoxLogs.TabIndex = 2;
            this.listBoxLogs.Click += new System.EventHandler(this.ListBox1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 41);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(346, 41);
            this.progressBar1.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Barre d\'état";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 507);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ButtonCreationVSwitch);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Assistant Hyper-V";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRAM)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fichierDeConfigurationcsvToolStripMenuItem;
        private System.Windows.Forms.Button ButtonCreationVSwitch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox checkedListBoxVMSwitch;
        private System.Windows.Forms.Button buttonDeleteVMSwitch;
        private System.Windows.Forms.Button buttonAjoutVMSwitch;
        private System.Windows.Forms.CheckBox checkBoxINT;
        private System.Windows.Forms.CheckBox checkBoxLAN;
        private System.Windows.Forms.CheckBox checkBoxWAN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNameVMSwitch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxMasterPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonParcourirMaster;
        private System.Windows.Forms.CheckedListBox checkedListBoxMaster;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonParcourirVMPath;
        private System.Windows.Forms.TextBox textBoxVMPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxVMName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonDeleteVM;
        private System.Windows.Forms.CheckedListBox checkedListBoxVM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackBarRAM;
        private System.Windows.Forms.TextBox textBoxRAM;
        private System.Windows.Forms.Button buttonCreateVM;
        private System.Windows.Forms.Button buttonParcourirVHDPath;
        private System.Windows.Forms.TextBox textBoxVHDPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBoxLogs;
        private System.Windows.Forms.Button buttonAjoutVMSwitchToVM;
    }
}

