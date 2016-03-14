using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseTools;
using MySql.Data;

namespace DatabaseTools.MySQL
{
    public class MySQLConnectionStringBuilder : ConnectionStringBuilder
    {
        #region Properties
        public override System.Data.Common.DbConnection DatabaseConnection
        {
            get { return new MySql.Data.MySqlClient.MySqlConnection(this.ConnectionString); }
        }

        public string Server { get; set; }
        public string Database { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }

        public override System.Data.Common.DbConnectionStringBuilder CommonStringBuilder
        {
            get
            {
                return MySQLStringBuilder;
            }
        }

        public MySql.Data.MySqlClient.MySqlConnectionStringBuilder MySQLStringBuilder
        {
            get
            {
                return new MySql.Data.MySqlClient.MySqlConnectionStringBuilder()
                {
                    Server = this.Server,
                    Database = this.Database,
                    UserID = this.UserId,
                    Password = this.Password
                };
            }
        }

        public override string ConnectionString
        {
            get { return Build(); }
        }
        #endregion

        #region Constructors
        public MySQLConnectionStringBuilder(string server, string database, string userId, string password)
        {
            this.Server = server;
            this.Database = database;
            this.UserId = userId;
            this.Password = password;
        }
        public MySQLConnectionStringBuilder(): base()
        {
            
        }
        #endregion

        #region Helpers
        private string Build()
        {
            return string.Format("SERVER={0};DATABASE={1};UID={2};PASSWORD={3};",
                this.Server, this.Database, this.UserId, this.Password);
        }
        #endregion
    }
}
