using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

namespace GenyoInstaller
{
    public partial class Form1 : Form
    {
        public string CurrentVersion = "";

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            UC_Installer uc = new(this);
            uc.Dock = DockStyle.Fill;
            tbInstaller.Controls.Clear();
            tbInstaller.Controls.Add(uc);

            UC_Options ucO = new();
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
