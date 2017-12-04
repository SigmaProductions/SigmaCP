using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SigmaCP.Model
{
    public class JsonInterpreter
    {
        private Script Script;
        private Note Note;

        public JsonInterpreter(string script, string note)
        {
            this.Note = new Note(note);
            this.Script = new Script(script);
        }

        public Script GetScript()
        {
            return this.Script;
        }
        public Note GetNote()
        {
            return this.Note;
        }
    }
}
