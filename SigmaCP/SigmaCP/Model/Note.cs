using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SigmaCP.Model
{
    public class Note
    {
        public string LoadedData;

        public Note()
        {

        }
        public Note(string rawData)
        {
            this.LoadedData = rawData;
        }

        public string GetData()
        {
            return LoadedData;
        }

        

    }
}
