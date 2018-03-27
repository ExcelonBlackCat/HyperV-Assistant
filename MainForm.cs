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
                trackBar1.Maximum = parsed;

            }
            trackBar1.Minimum = 1;
            trackBar1.Value = 1;
            textBox5.Text = trackBar1.Value.ToString() + "GB";
            if (!Directory.Exists("C:\\Hyper-V\\VHDs\\")||!Directory.Exists("C:\\Hyper-V\\VMs\\"))
            {
                Directory.CreateDirectory("C:\\Hyper-V");
                Directory.CreateDirectory("C:\\Hyper-V\\VHDs");
                Directory.CreateDirectory("C:\\Hyper-V\\VMs");
                SendCommand("SET-VMHOST –virtualharddiskpath 'C:\\Hyper-V\\VHDs\\'");
                textBox6.Text = "C:\\Hyper-V\\VHDS\\";
                SendCommand("SET-VMHOST -virtualmachinepath ‘C:\\Hyper-V\\VMs\\’");
                textBox3.Text = "C:\\Hyper-V\\VMs\\";
            }
            else
            {
                textBox6.Text = "C:\\Hyper-V\\VHDS\\";
                textBox3.Text = "C:\\Hyper-V\\VMs\\";
            }
            foreach (PSObject outputItem in SendCommand("Get-VMSwitch|select SwitchType"))
            {
                if (outputItem.Properties["SwitchType"].ToString().Split('=').Last() == "External")
                {
                    checkBox1.Enabled = false;
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
            catch (Exception ex)
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
                if (listBox1.Items.Count >= 100)
                {
                    listBox1.Items.Clear();
                }
                if (!command.Contains("Get"))
                {
                    listBox1.Items.Add(command);
                }
            }
            return PSOutput;
        }

        private void ReloadVSCheckBox()
        {
            checkedListBox1.Items.Clear();
            foreach (PSObject outputItem in SendCommand("Get-VMSwitch|select Name"))
            {
                checkedListBox1.Items.Add(outputItem.Properties["name"].ToString().Split('=').Last());
            }
        }

        private void ReloadMCheckBox()
        {
            checkedListBox2.Items.Clear();
            foreach (PSObject outputItem in SendCommand("Get-ChildItem -Path "+textBox2.Text+" -Filter *.vhdx | select Name"))
            {
                checkedListBox2.Items.Add(outputItem.Properties["name"].ToString().Split('=').Last().Split('.').First());
            }
        }
        private void ReloadVMCheckBox()
        {
            checkedListBox3.Items.Clear();
            foreach (PSObject outputItem in SendCommand("Get-VM |select Name"))
            {
                checkedListBox3.Items.Add(outputItem.Properties["name"].ToString().Split('=').Last());
            }
        }

        private void UpdateCreationVSwitchButton()
        {
            if (checkedListBox1.Items.Contains("LAN1") || checkedListBox1.Items.Contains("LAN2") || checkedListBox1.Items.Contains("LAN3") || checkedListBox1.Items.Contains("INT1") || checkedListBox1.Items.Contains("WAN"))
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void aideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.google.fr/search?dcr=0&ei=OeenWuq0O8ytU8P0rYgL&q=comment+scripter+en+powershell&oq=comment+scripter+en+powershell&gs_l=psy-ab.3...6101.9630.0.10287.9.9.0.0.0.0.57.402.9.9.0....0...1c.1.64.psy-ab..0.7.322...0i7i30k1j0i8i30k1j0i8i7i30k1.0.HzOtbAgIgf4");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pwsh;
            button1.Enabled=false;
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

        private void checkBox1_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox3.Checked = false;
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            bool validName = true;
            foreach (string vswitch in checkedListBox1.Items)
            {
                if (vswitch == textBox1.Text)
                {
                    validName = false;
                    listBox1.Items.Add("Erreur :: Nom VSwitch Déjà utilisé");
                    return;
                }
            }
            if (!(checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true))
            {
                listBox1.Items.Add("Erreur :: Choisir un type de VSwitch");
                return;
            }
            if (textBox1.Text != "" && validName)
            {
                string pwsh;
                if (checkBox1.Checked == true)
                {
                    pwsh = "New-VMSwitch -Name " + textBox1.Text + " -NetAdapterName '(Get-NetAdapter -Name ethernet).Name' -AllowManagementOS '$true' -Notes 'Parent OS, VMs, LAN'";
                    SendCommand(pwsh);
                }
                if (checkBox2.Checked == true)
                {
                    pwsh = "New-VMSwitch -Name " + textBox1.Text + " -SwitchType Private -Notes 'Internal VMs only'";
                    SendCommand(pwsh);
                }
                if (checkBox3.Checked == true)
                {
                    pwsh = "New-VMSwitch -Name " + textBox1.Text + " -SwitchType Internal -Notes 'Parent OS, and internal VMs'";
                    SendCommand(pwsh);
                }
            }
            else
            {
                listBox1.Items.Add("Erreur :: Aucun nom donné au VSwitch");
            }
            ReloadVSCheckBox();
            UpdateCreationVSwitchButton();
            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            foreach(string vswitch in checkedListBox1.CheckedItems)
            {
               SendCommand("Remove-VMSwitch -Name "+vswitch+" -Force");
            }
            ReloadVSCheckBox();
            UpdateCreationVSwitchButton();
            button3.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowDialog();
            textBox2.Text = folder.SelectedPath +"\\";
            ReloadMCheckBox();
        }

        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < checkedListBox2.Items.Count; ++ix)
                if (ix != e.Index)
                    checkedListBox2.SetItemChecked(ix, false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowDialog();
            textBox3.Text = folder.SelectedPath + "\\";
            ReloadMCheckBox();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox5.Text = trackBar1.Value.ToString() + "GB";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.Enabled = false;
            string pwsh;
            progressBar1.Value = 25;
            if (CheckVarCreateVM())
            {
                button7.Enabled = true;
                return;
            }
            pwsh = "New-VHD -ParentPath " + textBox2.Text + checkedListBox2.SelectedItem.ToString() + ".vhdx -Path " + textBox6.Text + textBox4.Text + ".vhdx -Differencing | select Path";
            foreach(PSObject outputItem in SendCommand(pwsh))
            {
                if (!outputItem.Properties["path"].ToString().Contains((textBox6.Text + textBox4.Text + ".vhdx")))
                {
                    listBox1.Items.Add("ERREUR :: Création VHDx");
                    button7.Enabled = true;
                    return;
                }
            }
            progressBar1.Value = 50;
            pwsh = "New-VM -MemoryStartupBytes " + textBox5.Text + " -Name " + textBox4.Text + " -Generation 2 -VHDPath " + textBox6.Text + textBox4.Text + ".vhdx -Path " + textBox3.Text + "|select Name";
            foreach (PSObject outputItem in SendCommand(pwsh))
            {
                if (!outputItem.Properties["name"].ToString().Contains(textBox4.Text))
                {
                    listBox1.Items.Add("ERREUR :: Création De la Machine Virtuel");
                    button7.Enabled = true;
                    return;
                }
            }
            progressBar1.Value = 75;
            foreach (string vswitch in checkedListBox1.CheckedItems)
            {
                pwsh = "Add-VMNetworkAdapter -VMName " + textBox4.Text + " -SwitchName " + vswitch + " -Name " + vswitch;
                SendCommand(pwsh);
            }
            progressBar1.Value = 100;
            ReloadVMCheckBox();
            button7.Enabled = true;
        }

        private bool CheckVarCreateVM()
        {
            if (textBox4.Text == "")
            {
                listBox1.Items.Add("Erreur :: Nom VM null");
                return true;
            }
            if (textBox3.Text == "")
            {
                listBox1.Items.Add("Erreur :: Path VM null");
                return true;
            }
            if (textBox6.Text == "")
            {
                listBox1.Items.Add("Erreur :: Path VHD null");
                return true;
            }
            foreach (string vswitch in checkedListBox3.Items)
            {
                if (vswitch == textBox4.Text)
                {
                    listBox1.Items.Add("Erreur :: Nom VM Déjà utilisé");
                    return true;
                }
            }
            if (checkedListBox2.CheckedItems.Count != 1)
            {
                listBox1.Items.Add("Erreur :: Choisir un Master");
                return true;
            }
            return false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowDialog();
            textBox6.Text = folder.SelectedPath + "\\";
            ReloadMCheckBox();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Enabled = false;
            foreach (string vm in checkedListBox3.CheckedItems)
            {
                SendCommand("Remove-VM -Name " + vm + " -Force");
            }
            ReloadVMCheckBox();
            button6.Enabled = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.Enabled = false;
                bool validName = true;
                foreach (string vswitch in checkedListBox1.Items)
                {
                    if (vswitch == textBox1.Text)
                    {
                        validName = false;
                        listBox1.Items.Add("Erreur :: Nom VSwitch Déjà utilisé");
                        return;
                    }
                }
                if (!(checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true))
                {
                    listBox1.Items.Add("Erreur :: Choisir un type de VSwitch");
                    return;
                }
                if (textBox1.Text != "" && validName)
                {
                    string pwsh;
                    if (checkBox1.Checked == true)
                    {
                        pwsh = "New-VMSwitch -Name " + textBox1.Text + " -NetAdapterName '(Get-NetAdapter -Name ethernet).Name' -AllowManagementOS '$true' -Notes 'Parent OS, VMs, LAN'";
                        SendCommand(pwsh);
                    }
                    if (checkBox2.Checked == true)
                    {
                        pwsh = "New-VMSwitch -Name " + textBox1.Text + " -SwitchType Private -Notes 'Internal VMs only'";
                        SendCommand(pwsh);
                    }
                    if (checkBox3.Checked == true)
                    {
                        pwsh = "New-VMSwitch -Name " + textBox1.Text + " -SwitchType Internal -Notes 'Parent OS, and internal VMs'";
                        SendCommand(pwsh);
                    }
                }
                else
                {
                    listBox1.Items.Add("Erreur :: Aucun nom donné au VSwitch");
                }
                ReloadVSCheckBox();
                UpdateCreationVSwitchButton();
                button2.Enabled = true;
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            foreach(string box in listBox1.SelectedItems)
            {
                if (MessageBox.Show(box, "Copier dans le press-papier ?", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                { Clipboard.SetText(box); }
            }
        }

        private void checkedListBox3_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < checkedListBox3.Items.Count; ++ix)
                if (ix != e.Index)
                    checkedListBox3.SetItemChecked(ix, false);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string pwsh;
            foreach (string vswitch in checkedListBox1.CheckedItems)
            {
                foreach(string vm in checkedListBox3.CheckedItems)
                {
                    pwsh = "Add-VMNetworkAdapter -VMName " + vm + " -SwitchName " + vswitch + " -Name " + vswitch;
                    SendCommand(pwsh);
                }
            }
        }

        private void fichierDeConfigurationcsvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Fichier CSV (.csv)|*.csv";
            file.FilterIndex = 1;
            file.ShowDialog();
            using (var textReader = new StreamReader(file.FileName))
            {
                string line = textReader.ReadLine();
                int skipCount = 0;
                while (line != null && skipCount < 1)
                {
                    line = textReader.ReadLine();

                    skipCount++;
                }

                while (line != null)
                {
                    string[] columns = line.Split(',');
                    MessageBox.Show(columns[0]);
                    line = textReader.ReadLine();
                }
            }
        }
    }
}
