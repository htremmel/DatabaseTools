using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Common;
using System.Data;
using DatabaseTools;

namespace DatabaseTools.Access
{
    public partial class AccessDatabase : IDataContext
    {
        private OleDbConnection db;

        public FileInfo File { get; private set; }

        #region Constructors
        public AccessDatabase(string connectionString) 
        {
            this.ConnectionString = connectionString;
        }

        public AccessDatabase(FileInfo fi)
        {
            AccessConnectionStringBuilder ab = AccessConnectionStringBuilder.AccessOleDb(fi.FullName);
            this.ConnectionString = db.ConnectionString;
            this.File = ab.File;
        }
        #endregion

        #region Static methods
        public static AccessDatabase CreateFromFileDialog()
        {
            try
            {
                return new AccessDatabase(AccessOpenDialog());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [STAThread]
        public static FileInfo AccessSaveAsDialog()
        {
            try
            {
                SaveFileDialog sv = new SaveFileDialog()
                {
                    RestoreDirectory = true,
                    Filter = "Access 2000-2003 (*.mdb)|*.mdb|Access 2007 (*.accdb)|*accdb",
                    Title = "Create New Access Database"
                };
                if (sv.ShowDialog() == DialogResult.OK)
                {
                    return new FileInfo(sv.FileName);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [STAThread]
        public static FileInfo AccessOpenDialog()
        {
            try
            {
                OpenFileDialog di = new OpenFileDialog()
                {
                    RestoreDirectory = true,
                    Filter = "Access 2000-2003 (*.mdb)|*.mdb|Access 2007 (*.accdb)|*accdb",
                    Title = "Select an Access Database.",
                    CheckFileExists = true,
                    CheckPathExists = true
                };
                if (di.ShowDialog() == DialogResult.OK)
                {
                    return new FileInfo(di.FileName);
                }
                throw new Exception();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Inherited members
        public ITable<T> GetTable<T>() where T : class
        {
            return new Table<T>(this);
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            throw new NotImplementedException();
        }

        public IDbTransaction BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void ChangeDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public string ConnectionString
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

        public int ConnectionTimeout
        {
            get { throw new NotImplementedException(); }
        }

        public IDbCommand CreateCommand()
        {
            throw new NotImplementedException();
        }

        public string Database
        {
            get { throw new NotImplementedException(); }
        }

        public void Open()
        {
            throw new NotImplementedException();
        }

        public ConnectionState State
        {
            get { throw new NotImplementedException(); }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion

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

        public string Server
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



        public List<object> GetTables()
        {
            throw new NotImplementedException();
        }
    }
}
