using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FortniteLauncher
{
    public partial class MainForm : Form
    {
         // Fortnite path and server info
        private string fortnitePath = @ "D:\Epic Games\Fortnite\FortniteGame\Binaries\Win64FortniteClient-Win64-Shipping_BE.exe"
           private string ogfnServer = "ogfn_server_address"; // 
            private string ogfnPort = "port"; // 
              public MainForm()
        {
            InitializeComponent();
        }

        private void launchButton_Click(object sender, EventArgs e)
        {
            LaunchFortnite();
        }

        private void LaunchFortnite()
        {
            if (File.Exists(fortnitePath))
            {
                try
                {
                    // Prepare the command with server and port
                    string arguments = $"-server={ogfnServer} -port={ogfnPort}";
                    ProcessStartInfo processStartInfo = new ProcessStartInfo(fortnitePath, arguments)
                    {
                        UseShellExecute = false
                    };

                    // Start the process
                    Process.Start(processStartInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to launch Fortnite: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Fortnite not found at {fortnitePath}. Please check your installation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}