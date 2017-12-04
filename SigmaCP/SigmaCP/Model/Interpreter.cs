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

        public Interpreter(JsonInterpreter jsonInterpreter)
        {
            script = jsonInterpreter.GetScript();
            note = jsonInterpreter.GetNote();

            Action.Globals["note"] = note.GetData();
            //ActionGlobals["Vibrate"]=(Func<List<int>>);
            Action = new MoonSharp.Interpreter.Script();
        }

        public void Run()
        {
            Action.DoString(script.GetScriptBody());
        }
    }
}
