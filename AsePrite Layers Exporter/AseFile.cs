using System.Text;
using System.Configuration;
using Newtonsoft.Json;

namespace AsePrite_Layers_Exporter
{
    public class AseFile
    {
        public string AseFilePath { get; set; }

        public string AseExportPath { get; set; }

        public string AseExportFileName { get; set; }

        public string AseFileNameFormat { get; set; }

        public string AppCallAfterConversion { get; set; }

        [JsonIgnore]
        public string Command
        {
            get
            {
                var sb = new StringBuilder();
                sb.AppendFormat("\"\"{0}\" -b --split-layers ", ConfigurationManager.AppSettings["AsePritePath"]);
                sb.Append("\"");
                sb.Append(AseFilePath);
                sb.Append("\" ");
                sb.AppendFormat("--filename-format {0} --trim --save-as ", this.AseFileNameFormat);
                sb.Append("\"");
                sb.Append(AseExportPath);
                sb.Append(AseExportFileName);
                sb.Append("\"\"");

                return sb.ToString();
            }
        }
    }
}
