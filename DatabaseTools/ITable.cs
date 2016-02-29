using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DatabaseTools
{
    public interface ITable<T> : System.Data.Linq.ITable<T> where T : class
    {
        
    }
}
