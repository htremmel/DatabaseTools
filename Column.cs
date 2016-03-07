using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTools
{
    public partial class Column<T> : IColumn<T> where T : class
    {
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

        public System.Data.DbType DbType
        {
            get { throw new NotImplementedException(); }
        }

        public Type Type
        {
            get { throw new NotImplementedException(); }
        }

        public string TypeName
        {
            get { throw new NotImplementedException(); }
        }

        public int Order
        {
            get { throw new NotImplementedException(); }
        }

        public ITable<T> Parent
        {
            get { throw new NotImplementedException(); }
        }

        public ITable<T> RelatedTabe
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsKey
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsForeignKey
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsNullable
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
        #endregion
    }
}
