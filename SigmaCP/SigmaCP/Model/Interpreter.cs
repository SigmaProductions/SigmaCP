using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoonSharp;

namespace SigmaCP.Model
{
    public class Interpreter
    {
        private MoonSharp.Interpreter.Script Action;
        private Script script;
        private Note note;

        public Interpreter()
        {
            
        }
        public Interpreter(JsonInterpreter jsonInterpreter)
        {
            Action = new MoonSharp.Interpreter.Script();
            script = jsonInterpreter.GetScript();
            note = jsonInterpreter.GetNote();

            Action.Globals["note"] = note.LoadedData;
            Action.Globals["Vibrate"]=(Func<string,int>)Controllers.SocketServer.sendData;
          
        }

        public void Run()
        {
            
            var x = Action.DoString(script.GetScriptBody());
            ;
            
        }
    }
}
