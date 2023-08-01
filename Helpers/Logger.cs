using NUnit.Framework;
using System.Reflection;

namespace XECurrencyConverter.Helpers
{
    public class Logger
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public Logger(string folder, string FileName = "Scenario.Log") 
        { 
            //folder = string.Join(".", folder.Split(Path.GetInvalidFileNameChars()));
            FilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Directory.CreateDirectory(FilePath);
            this.FileName = Path.Combine(FilePath, FileName);
        }

        public void Info(string message)
        {
            Log(message);
        }

        public void Log(string message)
        {
            TestContext.WriteLine(message);
        }

        public void LogWrite(string message)
        {
            using StreamWriter writer = File.AppendText(FileName);
            writer.WriteLine(message);
        }
    }
}
