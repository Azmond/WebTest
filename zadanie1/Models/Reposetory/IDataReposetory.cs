using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1.Models.Reposetory
{
    public interface IDataReposetory
    {
        int GetMaxRow();
        List<MData> GetRows(int page, int rowsInPage);
        
    }
}
