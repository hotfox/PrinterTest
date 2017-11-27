using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterTest.Infrastructure
{
    public class Context
    {
        private Dictionary<string, string> variables = new Dictionary<string, string>();
        public IPrinter Printer { get; set; }
        public void SaveVariable(string key, string value)
        {
            variables.Add(key, value);
        }
        public string ReadVariable(string key)
        {
            return variables[key];
        }
        public void ClearVariables()
        {
            variables.Clear();
        }
        public bool ContainVariable(string key)
        {
            return variables.ContainsKey(key);
        }
        public string LastErrorMessage { get; set; }
        public virtual void LogMessage(string msg) { return; }
    }
}
