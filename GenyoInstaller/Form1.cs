using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static GenyoInstaller.UC_Options;

namespace GenyoInstaller
{
    public partial class Form1 : Form
    {
        public string CurrentVersion = "";

        public UC_Installer uc_installer;

        // Options
        public bool manualInstallLocation;
        public bool explicitLauncher;
        public LauncherTypes selectedExplicitLauncher;
        public bool ignoreFabricMeteor;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            uc_installer = new(this);
            uc_installer.Dock = DockStyle.Fill;
            tbInstaller.Controls.Clear();
            tbInstaller.Controls.Add(uc_installer);

            UC_Options ucO = new(this);
            ucO.Dock = DockStyle.Fill;
            tbOptions.Controls.Clear();
            tbOptions.Controls.Add(ucO);

            var version = Assembly.GetExecutingAssembly().GetName().Version;
            CurrentVersion = $"{version.Major}.{version.Minor}.{version.Build}";
            label7.Text = $"v{CurrentVersion}";
        }

        public void ReloadUCInstaller(UC_Installer newUC)
        {
            newUC.Dock = DockStyle.Fill;
            tbInstaller.Controls.Clear();
            tbInstaller.Controls.Add(newUC);
        }
    }
}
