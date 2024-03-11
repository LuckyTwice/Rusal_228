using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusal_228
{
    class Prof_Choice
    {
        public int Id {get;set;}

        public override string ToString()
        {
            using (var db = new AluminContext())
            {
                string Name = db.Places.Where(p=>p.Id== Id).Single().Name;
                return Name;
            }
            
        }
    }
}
