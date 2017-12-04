using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SigmaCP.Model
{
    public class Script
    {
        
        private string ScriptBody;
        public Script()
        {

        }
        public Script( string scriptBody)
        {
           
            this.ScriptBody = scriptBody;
        }
        
        public string GetScriptBody()
        {
            return this.ScriptBody;
        }
    }
}
