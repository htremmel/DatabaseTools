using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System;
using System.Data;
using DatabaseTools.Access;
using System.Reflection;


namespace DatabaseTools_Tests.AccessDBTests
{	
    [TestFixture]
    public class DatabaseTests
    {
        string _baseDir;
        string _dbPath;
        string _testDir;

        [SetUp]
        public void Setup()
        {
            _baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _dbPath = TestFolder(_baseDir, 2) + @"\0-TestDatabases\InvoiceTracker.accdb";
            _testDir = TestFolder(_baseDir, 2) + @"\0-TestDatabases\";
        }
        /// <summary>
        /// 20151212 Bug when testing open on Lenovo.  Solved with installation MS Access Database Engine is not installed... Will this be an issue on 
        /// work computer.. Idk ref http://www.mikesdotnetting.com/article/280/solved-the-microsoft-ace-oledb-12-0-provider-is-not-registered-on-the-local-machine
        /// </summary>
        /// <param name="path"></param>
        
        [TestCase(AccessConnectionStringBuilder.Drivers.ACE)]
        [TestCase(AccessConnectionStringBuilder.Drivers.Jet)]
        [TestCase(AccessConnectionStringBuilder.Drivers.Odbc)]
    	public void AccessStringBuilder_Test(AccessConnectionStringBuilder.Drivers driver)
    	{
            AccessConnectionStringBuilder adb = new AccessConnectionStringBuilder(_dbPath, driver);
            Console.Write(adb.ConnectionString);
            Assert.IsTrue(adb.TryConnection());
    	}

        void adb_DatabaseConnectionError(object sender, ErrorEventArgs e)
        {
            throw new NotImplementedException();
        }    	
        
        string TestFolder(string path, int depth)
        {
            for (int i = 0; i < depth; i++)
            {
                path = Directory.GetParent(path).ToString();
            }
            return path;
        }
    }   
}
