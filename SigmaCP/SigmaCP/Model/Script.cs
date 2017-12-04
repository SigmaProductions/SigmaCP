using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SigmaCP.Model
{
    public class Script
    {
        private string Name;
        private string ScriptBody;
        public Script()
        {

        }
        public Script(string name, string scriptBody)
        {
            this.Name = name;
            this.ScriptBody = scriptBody;
        }

        public string GetName()
        {
            return this.Name;
        }

        public string GetScriptBody()
        {
            return this.ScriptBody;
        }
    }
}
