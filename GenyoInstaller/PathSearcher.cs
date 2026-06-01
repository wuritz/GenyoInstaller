using System;
using System.Collections.Generic;
using System.Text;

namespace GenyoInstaller
{
    internal class PathSearcher
    {
        bool usingPrism = false;

        public string SearchMC()
        {
            string outputDir = "";
            string dir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft"
            );

            if (!Directory.Exists(dir))
            {
                // look for prism
                string prismDir = SearchPrism();

                if (prismDir == string.Empty || prismDir == null)
                {
                    // handle manual select
                    return string.Empty;
                }

                usingPrism = true;
                outputDir = prismDir;
            }
            else
            {
                outputDir = dir;
            }

            return outputDir;
        }

        public string SearchPrism()
        {
            string outputDir = "";
            string dir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PrismLauncher"
            );

            if (!Directory.Exists(dir))
            {
                return string.Empty;
            }
            else
            {
                outputDir = dir;
            }

            return outputDir;
        }

        public bool IsUsingPrism()
        {
            return usingPrism;
        }
    }
}
