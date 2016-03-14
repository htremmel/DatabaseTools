using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DatabaseTools
{
	public interface ITable<T>: System.Data.Linq.ITable<T> where T : class
    {
    	string Name { get; set; }
    	IDataContext DataContext { get; }
        List<IColumn> Columns { get; }
    	
    	void Insert(T entity);
        void InsertWithKey(T entity);
    	void Select(Predicate<T> selectThis);
    	void Delete(int Key);
    	void Delete(Predicate<T> deleteWhere);
        void Update(int key, T entity);
    	void Update(Func<T> updateWhere);
    	void Clear();
    }
}
