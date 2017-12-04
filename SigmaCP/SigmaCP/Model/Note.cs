using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SigmaCP.Model
{
    public class DataManager
    {
        private string LoadedData;
        public DataManager()
        {

        }
        public DataManager(string rawData)
        {
            this.LoadedData = rawData;
        }

        public string GetData()
        {
            return LoadedData;
        }


    }
}
