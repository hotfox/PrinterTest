using System;
using System.Text;
using PrinterTest.Infrastructure;
using IniParser.Parser;
using IniParser.Model;
using System.ComponentModel.Composition;
using IniParser.Exceptions;
using System.IO;
using Microsoft.VisualBasic;

namespace AskInformation
{
    [Export(typeof(ITest))]
    [ExportMetadata("Name", "AskInformation")]
    [Serializable]
    public class AskInformation : ITest
    {
        public AskInformation()
        {
            LoadDefaultConfigString();
        }
        public string ConfigString { get; private set; }

        public string Name { get; set; }

        public int Execute(Context context)
        {
            IniDataParser parser = new IniDataParser();
            IniData data = parser.Parse(ConfigString);

            if (data.Sections["Interface"]["HasLan"] == "True")
            {
                string lan =  Interaction.InputBox("Input Lan Mac Address:");
                context.SaveVariable("LanMac", lan);
            }
            if (data.Sections["Interface"]["HasWlan"] == "True")
            {
                string wlan = Interaction.InputBox("Input Wlan Mac Address:");
                context.SaveVariable("WlanMac", wlan);
            }
            return 0;
        }

        public void LoadDefaultConfigString()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            sw.WriteLine("[Interface]");
            sw.WriteLine("HasLan=True");
            sw.WriteLine("HasWlan=True");
            ConfigString =  sb.ToString();
        }

        public bool SaveConfigString(string config)
        {
            IniDataParser parser = new IniDataParser();
            try
            {
                parser.Parse(config);
                ConfigString = config;
                return true;
            }
            catch(ParsingException e)
            {
                return false;
            }
        }
    }
}
