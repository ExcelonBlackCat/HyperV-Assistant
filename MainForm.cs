using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Collections;
using System.IO;

namespace Hyper_V_Assistant
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            foreach (PSObject outputItem in SendCommand("Get-WMIObject -class Win32_PhysicalMemory |Measure-Object -Property capacity -Sum | select Sum"))
            {
                string retour = outputItem.Properties["Sum"].ToString().Split('=').Last();
                int parsed = Convert.ToInt32(double.Parse(retour)/1024/1024/1024);
                trackBarRAM.Maximum = parsed;

            }
            trackBarRAM.Minimum = 1;
            trackBarRAM.Value = 1;
            textBoxRAM.Text = trackBarRAM.Value.ToString() + "GB";
            if (Directory.Exists("C:\\Hyper-V\\VHDs\\")&&Directory.Exists("C:\\Hyper-V\\VMs\\")&&Directory.Exists("C:\\Hyper-V\\MASTER\\"))
            {
                textBoxVHDPath.Text = "C:\\Hyper-V\\VHDS\\";
                textBoxVMPath.Text = "C:\\Hyper-V\\VMs\\";
                textBoxMasterPath.Text = "C:\\Hyper-V\\MASTER\\";
            }else{
                Directory.CreateDirectory("C:\\Hyper-V\\");
                Directory.CreateDirectory("C:\\Hyper-V\\VMS\\");
                Directory.CreateDirectory("C:\\Hyper-V\\VHDs\\");
                Directory.CreateDirectory("C:\\Hyper-V\\MASTER\\");
                SendCommand("SET-VMHOST -virtualmachinepath ‘C:\\Hyper-V\\VMs\\’");
                SendCommand("SET-VMHOST –virtualharddiskpath 'C:\\Hyper-V\\VHDs\\'");
                textBoxVHDPath.Text = "C:\\Hyper-V\\VHDS\\";
                textBoxVMPath.Text = "C:\\Hyper-V\\VMs\\";
                textBoxMasterPath.Text = "C:\\Hyper-V\\MASTER\\";
            }
            foreach (PSObject outputItem in SendCommand("Get-VMSwitch|select SwitchType"))
            {
                if (outputItem.Properties["SwitchType"].ToString().Split('=').Last() == "External")
                {
                    checkBoxWAN.Enabled = false;
                }
            }
            ReloadMCheckBox();
            ReloadVSCheckBox();
            ReloadVMCheckBox();
            UpdateCreationVSwitchButton();
        }

        private bool IsValidPath(string path, bool allowRelativePaths = false)
        {
            bool isValid = true;
            isValid = NewMethod(path, allowRelativePaths);

            return isValid;
        }

        private static bool NewMethod(string path, bool allowRelativePaths)
        {
            bool isValid;
            try
            {
                string fullPath = Path.GetFullPath(path);

                if (allowRelativePaths)
                {
                    isValid = Path.IsPathRooted(path);
                }
                else
                {
                    string root = Path.GetPathRoot(path);
                    isValid = string.IsNullOrEmpty(root.Trim(new char[] { '\\', '/' })) == false;
                }
            }
            catch (Exception)
            {
                isValid = false;
            }

            return isValid;
        }

        private Collection<PSObject> SendCommand(string command)
        {
            Collection<PSObject> PSOutput;
            using (PowerShell pipeline = PowerShell.Create())
            {
                pipeline.AddScript(command);
                PSOutput = pipeline.Invoke();
                if (listBoxLogs.Items.Count >= 100)
                {
                    listBoxLogs.Items.Clear();
                }
                if (!command.Contains("Get"))
                {
                    listBoxLogs.Items.Add(command);
                }
            }
            return PSOutput;
        }

        private void ReloadVSCheckBox()
        {
            checkedListBoxVMSwitch.Items.Clear();
            foreach (PSObject outputItem in SendCommand("Get-VMSwitch|select Name"))
            {
                checkedListBoxVMSwitch.Items.Add(outputItem.Properties["name"].ToString().Split('=').Last());
            }
        }

        private void ReloadMCheckBox()
        {
            checkedListBoxMaster.Items.Clear();
            foreach (PSObject outputItem in SendCommand("Get-ChildItem -Path "+textBoxMasterPath.Text+" -Filter *.vhdx | select Name"))
            {
                checkedListBoxMaster.Items.Add(outputItem.Properties["name"].ToString().Split('=').Last().Split('.').First());
            }
        }
        private void ReloadVMCheckBox()
        {
            checkedListBoxVM.Items.Clear();
            foreach (PSObject outputItem in SendCommand("Get-VM |select Name"))
            {
                checkedListBoxVM.Items.Add(outputItem.Properties["name"].ToString().Split('=').Last());
            }
        }

        private void UpdateCreationVSwitchButton()
        {
            if (checkedListBoxVMSwitch.Items.Contains("LAN1") || checkedListBoxVMSwitch.Items.Contains("LAN2") || checkedListBoxVMSwitch.Items.Contains("LAN3") || checkedListBoxVMSwitch.Items.Contains("INT1") || checkedListBoxVMSwitch.Items.Contains("WAN"))
            {
                ButtonCreationVSwitch.Enabled = false;
            }
            else
            {
                ButtonCreationVSwitch.Enabled = true;
            }
        }

        private void AideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.google.fr/search?dcr=0&ei=OeenWuq0O8ytU8P0rYgL&q=comment+scripter+en+powershell&oq=comment+scripter+en+powershell&gs_l=psy-ab.3...6101.9630.0.10287.9.9.0.0.0.0.57.402.9.9.0....0...1c.1.64.psy-ab..0.7.322...0i7i30k1j0i8i30k1j0i8i7i30k1.0.HzOtbAgIgf4");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string pwsh;
            ButtonCreationVSwitch.Enabled=false;
            //VSwitch WAN
            pwsh = "New-VMSwitch -Name 'WAN' -NetAdapterName '(Get-NetAdapter -Name ethernet).Name' -AllowManagementOS '$true' -Notes 'Parent OS, VMs, LAN'";
            SendCommand(pwsh);
            //Vswitch INT1
            pwsh = "New-VMSwitch -Name 'INT1' -SwitchType Internal -Notes 'Parent OS, and internal VMs'";
            SendCommand(pwsh);
            //Vswitch LAN1
            pwsh = "New-VMSwitch -Name 'LAN1' -SwitchType Private -Notes 'Internal VMs only'";
            SendCommand(pwsh);
            //Vswitch LAN2
            pwsh = "New-VMSwitch -Name 'LAN2' -SwitchType Private -Notes 'Internal VMs only'";
            SendCommand(pwsh);
            //Vswitch LAN3
            pwsh = "New-VMSwitch -Name 'LAN3' -SwitchType Private -Notes 'Internal VMs only'";
            SendCommand(pwsh);
            //on reload la checklist box
            ReloadVSCheckBox();
            UpdateCreationVSwitchButton();
        }

        private void CheckBox1_Click(object sender, EventArgs e)
        {
            checkBoxLAN.Checked = false;
            checkBoxINT.Checked = false;
        }

        private void CheckBox2_Click(object sender, EventArgs e)
        {
            checkBoxWAN.Checked = false;
            checkBoxINT.Checked = false;
        }

        private void CheckBox3_Click(object sender, EventArgs e)
        {
            checkBoxWAN.Checked = false;
            checkBoxLAN.Checked = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            buttonAjoutVMSwitch.Enabled = false;
            bool validName = true;
            foreach (string vswitch in checkedListBoxVMSwitch.Items)
            {
                if (vswitch == textBoxNameVMSwitch.Text)
                {
                    validName = false;
                    listBoxLogs.Items.Add("Erreur :: Nom VSwitch Déjà utilisé");
                    return;
                }
            }
            if (!(checkBoxWAN.Checked == true || checkBoxLAN.Checked == true || checkBoxINT.Checked == true))
            {
                listBoxLogs.Items.Add("Erreur :: Choisir un type de VSwitch");
                return;
            }
            if (textBoxNameVMSwitch.Text != "" && validName)
            {
                string pwsh;
                if (checkBoxWAN.Checked == true)
                {
                    pwsh = "New-VMSwitch -Name " + textBoxNameVMSwitch.Text + " -NetAdapterName '(Get-NetAdapter -Name ethernet).Name' -AllowManagementOS '$true' -Notes 'Parent OS, VMs, LAN'";
                    SendCommand(pwsh);
                }
                if (checkBoxLAN.Checked == true)
                {
                    pwsh = "New-VMSwitch -Name " + textBoxNameVMSwitch.Text + " -SwitchType Private -Notes 'Internal VMs only'";
                    SendCommand(pwsh);
                }
                if (checkBoxINT.Checked == true)
                {
                    pwsh = "New-VMSwitch -Name " + textBoxNameVMSwitch.Text + " -SwitchType Internal -Notes 'Parent OS, and internal VMs'";
                    SendCommand(pwsh);
                }
            }
            else
            {
                listBoxLogs.Items.Add("Erreur :: Aucun nom donné au VSwitch");
            }
            ReloadVSCheckBox();
            UpdateCreationVSwitchButton();
            buttonAjoutVMSwitch.Enabled = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            buttonDeleteVMSwitch.Enabled = false;
            foreach(string vswitch in checkedListBoxVMSwitch.CheckedItems)
            {
               SendCommand("Remove-VMSwitch -Name "+vswitch+" -Force");
            }
            ReloadVSCheckBox();
            UpdateCreationVSwitchButton();
            buttonDeleteVMSwitch.Enabled = true;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowDialog();
            textBoxMasterPath.Text = folder.SelectedPath +"\\";
            ReloadMCheckBox();
        }

        private void CheckedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < checkedListBoxMaster.Items.Count; ++ix)
                if (ix != e.Index)
                    checkedListBoxMaster.SetItemChecked(ix, false);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowDialog();
            textBoxVMPath.Text = folder.SelectedPath + "\\";
            ReloadMCheckBox();
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            textBoxRAM.Text = trackBarRAM.Value.ToString() + "GB";
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            buttonCreateVM.Enabled = false;
            string pwsh;
            progressBar1.Value = 25;
            if (CheckVarCreateVM())
            {
                buttonCreateVM.Enabled = true;
                return;
            }
            pwsh = "New-VHD -ParentPath " + textBoxMasterPath.Text + checkedListBoxMaster.SelectedItem.ToString() + ".vhdx -Path " + textBoxVHDPath.Text + textBoxVMName.Text + ".vhdx -Differencing | select Path";
            foreach(PSObject outputItem in SendCommand(pwsh))
            {
                if (!outputItem.Properties["path"].ToString().Contains((textBoxVHDPath.Text + textBoxVMName.Text + ".vhdx")))
                {
                    listBoxLogs.Items.Add("ERREUR :: Création VHDx");
                    buttonCreateVM.Enabled = true;
                    return;
                }
            }
            progressBar1.Value = 50;
            pwsh = "New-VM -MemoryStartupBytes " + textBoxRAM.Text + " -Name " + textBoxVMName.Text + " -Generation 2 -VHDPath " + textBoxVHDPath.Text + textBoxVMName.Text + ".vhdx -Path " + textBoxVMPath.Text + "|select Name";
            foreach (PSObject outputItem in SendCommand(pwsh))
            {
                if (!outputItem.Properties["name"].ToString().Contains(textBoxVMName.Text))
                {
                    listBoxLogs.Items.Add("ERREUR :: Création De la Machine Virtuel");
                    buttonCreateVM.Enabled = true;
                    return;
                }
            }
            progressBar1.Value = 75;
            foreach (string vswitch in checkedListBoxVMSwitch.CheckedItems)
            {
                pwsh = "Add-VMNetworkAdapter -VMName " + textBoxVMName.Text + " -SwitchName " + vswitch + " -Name " + vswitch;
                SendCommand(pwsh);
            }
            progressBar1.Value = 100;
            ReloadVMCheckBox();
            buttonCreateVM.Enabled = true;
        }

        private bool CheckVarCreateVM()
        {
            if (textBoxVMName.Text == "")
            {
                listBoxLogs.Items.Add("Erreur :: Nom VM null");
                return true;
            }
            if (textBoxVMPath.Text == "")
            {
                listBoxLogs.Items.Add("Erreur :: Path VM null");
                return true;
            }
            if (textBoxVHDPath.Text == "")
            {
                listBoxLogs.Items.Add("Erreur :: Path VHD null");
                return true;
            }
            foreach (string vswitch in checkedListBoxVM.Items)
            {
                if (vswitch == textBoxVMName.Text)
                {
                    listBoxLogs.Items.Add("Erreur :: Nom VM Déjà utilisé");
                    return true;
                }
            }
            if (checkedListBoxMaster.CheckedItems.Count != 1)
            {
                listBoxLogs.Items.Add("Erreur :: Choisir un Master");
                return true;
            }
            return false;
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowDialog();
            textBoxVHDPath.Text = folder.SelectedPath + "\\";
            ReloadMCheckBox();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            buttonDeleteVM.Enabled = false;
            foreach (string vm in checkedListBoxVM.CheckedItems)
            {
                SendCommand("Remove-VM -Name " + vm + " -Force");
            }
            ReloadVMCheckBox();
            buttonDeleteVM.Enabled = true;
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonAjoutVMSwitch.Enabled = false;
                bool validName = true;
                foreach (string vswitch in checkedListBoxVMSwitch.Items)
                {
                    if (vswitch == textBoxNameVMSwitch.Text)
                    {
                        validName = false;
                        listBoxLogs.Items.Add("Erreur :: Nom VSwitch Déjà utilisé");
                        return;
                    }
                }
                if (!(checkBoxWAN.Checked == true || checkBoxLAN.Checked == true || checkBoxINT.Checked == true))
                {
                    listBoxLogs.Items.Add("Erreur :: Choisir un type de VSwitch");
                    return;
                }
                if (textBoxNameVMSwitch.Text != "" && validName)
                {
                    string pwsh;
                    if (checkBoxWAN.Checked == true)
                    {
                        pwsh = "New-VMSwitch -Name " + textBoxNameVMSwitch.Text + " -NetAdapterName '(Get-NetAdapter -Name ethernet).Name' -AllowManagementOS '$true' -Notes 'Parent OS, VMs, LAN'";
                        SendCommand(pwsh);
                    }
                    if (checkBoxLAN.Checked == true)
                    {
                        pwsh = "New-VMSwitch -Name " + textBoxNameVMSwitch.Text + " -SwitchType Private -Notes 'Internal VMs only'";
                        SendCommand(pwsh);
                    }
                    if (checkBoxINT.Checked == true)
                    {
                        pwsh = "New-VMSwitch -Name " + textBoxNameVMSwitch.Text + " -SwitchType Internal -Notes 'Parent OS, and internal VMs'";
                        SendCommand(pwsh);
                    }
                }
                else
                {
                    listBoxLogs.Items.Add("Erreur :: Aucun nom donné au VSwitch");
                }
                ReloadVSCheckBox();
                UpdateCreationVSwitchButton();
                buttonAjoutVMSwitch.Enabled = true;
            }
        }

        private void ListBox1_Click(object sender, EventArgs e)
        {
            foreach(string box in listBoxLogs.SelectedItems)
            {
                if (MessageBox.Show(box, "Copier dans le press-papier ?", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                { Clipboard.SetText(box); }
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            string pwsh;
            foreach (string vswitch in checkedListBoxVMSwitch.CheckedItems)
            {
                foreach(string vm in checkedListBoxVM.CheckedItems)
                {
                    pwsh = "Add-VMNetworkAdapter -VMName " + vm + " -SwitchName " + vswitch + " -Name " + vswitch;
                    SendCommand(pwsh);
                }
            }
        }

        private void FichierDeConfigurationcsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog
            {
                Filter = "Fichier CSV (.csv)|*.csv",
                FilterIndex = 1
            };
            file.ShowDialog();
            using (var reader = new StreamReader(file.FileName))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    buttonCreateVM.Enabled = false;
                    string pwsh;
                    progressBar1.Value = 25;
                    pwsh = "New-VHD -ParentPath " + textBoxMasterPath.Text + values[3] + ".vhdx -Path " + textBoxVHDPath.Text + values[0] + ".vhdx -Differencing | select Path";
                    foreach (PSObject outputItem in SendCommand(pwsh))
                    {
                        if (!outputItem.Properties["path"].ToString().Contains((textBoxVHDPath.Text + values[0] + ".vhdx")))
                        {
                            listBoxLogs.Items.Add("ERREUR :: Création VHDx");
                            buttonCreateVM.Enabled = true;
                            return;
                        }
                    }
                    progressBar1.Value = 50;
                    pwsh = "New-VM -MemoryStartupBytes " + values[2] + " -Name " + values[0] + " -Generation 2 -VHDPath " + textBoxVHDPath.Text + values[0] + ".vhdx -Path " + textBoxVMPath.Text + "|select Name";
                    foreach (PSObject outputItem in SendCommand(pwsh))
                    {
                        if (!outputItem.Properties["name"].ToString().Contains(values[0]))
                        {
                            listBoxLogs.Items.Add("ERREUR :: Création De la Machine Virtuel");
                            buttonCreateVM.Enabled = true;
                            return;
                        }
                    }
                    progressBar1.Value = 75;
                    for (int i=4;i<values.Count();i++)
                    {
                        if (values[i].ToString()!="")
                        {
                            pwsh = "Add-VMNetworkAdapter -VMName " + values[0] + " -SwitchName " + values[i] + " -Name " + values[i];
                            SendCommand(pwsh);
                        }
                    }
                    progressBar1.Value = 100;
                    ReloadVMCheckBox();
                    buttonCreateVM.Enabled = true;
                }
                
            }
        }
    }
}
