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
using System.Data.OleDb;

namespace DatabaseTools.Access
{
    public partial class AccessDatabase : DbConnection, IDataContext
    {
        private OleDbConnection db;

        public FileInfo File { get; private set; }

        #region Constructors
        private AccessDatabase() : base() { }

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
            //TODO: How to get connectivity to the table?  A dicitionary that translates the POCO to the table. 
            throw new NotImplementedException();
        }

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            throw new NotImplementedException();
        }

        public override void ChangeDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        public override void Close()
        {
            try
            {
                this.db.Close();
            }
            catch (Exception)
            {
                
            }
        }

        public override string ConnectionString { get; set; }

        protected override DbCommand CreateDbCommand()
        {
            throw new NotImplementedException();
        }

        public override string DataSource
        {
            get { throw new NotImplementedException(); }
        }

        public override string Database
        {
            get { throw new NotImplementedException(); }
        }

        public override void Open()
        {
            //OleDbConnection db = new OleDbConnection(this.ConnectionString);
            //try
            //{
            //    do
            //    {

            //    } while (true);
            //    if (db.State != ConnectionState.Open) 
            //}
            throw new NotImplementedException();
        }

        public override string ServerVersion
        {
            get { throw new NotImplementedException(); }
        }

        public override ConnectionState State
        {
            get { throw new NotImplementedException(); }
        }
        #endregion

    }
}
