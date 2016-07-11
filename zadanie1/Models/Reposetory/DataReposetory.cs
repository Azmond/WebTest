using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1.Models.Reposetory
{
    public class DataReposetory : IDataReposetory
    {
        private DataContext context = new DataContext();

        public int GetMaxRow()
        {
            return context.Data.Count();
        }

        public List<MData> GetRows(int page, int rowsInPage)
        {
            return context.Data.OrderBy(o => o.Id).Skip((page - 1) * rowsInPage).Take(rowsInPage).ToList();
        }
    }
}
