using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labaratorka01d01.AppData
{
    internal class Connect
    {
        public static TestEntities c;
        public static TestEntities Context 
        { 
            get 
            {
                if(c == null)
                    c = new TestEntities(); 
                return c;
            } 
        }
    }
}
