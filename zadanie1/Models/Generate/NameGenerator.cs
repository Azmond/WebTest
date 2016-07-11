using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace zadanie1.Models.Generate
{
    public class NameGenerator
    {
        public List<string> gname;
        public List<string> mname;
        public List<string> gsurname;
        public List<string> msurname;


        public NameGenerator()
        {
            var names = new StringNames();
            gname = names.gname.Split(';').ToList();
            mname = names.mname.Split(';').ToList();
            var surname = names.surname.Split(';');
            gsurname = surname.Where(x => x.Last().Equals('а') || x.Contains("ая\r")).ToList();
            msurname = surname.Where(x => !x.Last().Equals('а') && !x.Contains("ая\r")).ToList();
        }

        public string GenerateName()
        {
            Random r = new Random();
            var str = String.Empty;
            if (r.Next(100) > 49)
            {
                str = gname.ElementAt(r.Next(0, gname.Count() - 1));
                str = str + " " + gsurname.ElementAt(r.Next(0, gsurname.Count() - 1));
            }
            else
            {
                str = mname.ElementAt(r.Next(0, mname.Count() - 1));
                str = str + " " + msurname.ElementAt(r.Next(0, msurname.Count() - 1));
            }
            return str;
        }



    }
}
