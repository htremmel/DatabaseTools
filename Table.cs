using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTools
{
    public partial class Table: ITable<T> where T : class
    {
        #region Constructors
        public Table(IDataContext dataContext)
        {
            this.DataContext = dataContext;
        }
        #endregion       

        #region Inherited members
        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IDataContext DataContext { get; private set; }

        public List<IColumn<Type>> Columns
        {
            get { throw new NotImplementedException(); }
        }

        public void Insert(T poco)
        {
            throw new NotImplementedException();
        }

        public void Select(Predicate<T> selectThis)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Key)
        {
            throw new NotImplementedException();
        }

        public void Delete(Predicate<T> deleteWhere)
        {
            throw new NotImplementedException();
        }

        public void Update(T poco)
        {
            throw new NotImplementedException();
        }

        public void Update(Func<T> updateWhere)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Attach(T entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteOnSubmit(T entity)
        {
            throw new NotImplementedException();
        }

        public void InsertOnSubmit(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public Type ElementType
        {
            get { throw new NotImplementedException(); }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get { throw new NotImplementedException(); }
        }

        public IQueryProvider Provider
        {
            get { throw new NotImplementedException(); }
        }
        #endregion
    }
}
