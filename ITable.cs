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
    	string Name { get; set; }
    	IDataContext DataContext { get; }
        List<IColumn<Type>> Columns { get; }
    	
    	void Insert(T poco);
    	void Select(Predicate<T> selectThis);
    	void Delete(int Key);
    	void Delete(Predicate<T> deleteWhere);
    	void Update(T poco);
    	void Update(Func<T> updateWhere);
    	void Clear();
    }
}
