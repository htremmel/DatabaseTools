using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System;
using System.Data;
using DatabaseTools;
using DatabaseTools_Tests;
using InvoiceTracker.Database;
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
        
        [Test]
    	public void ConnectionTest_Open()
    	{            
            MsAccessDatabase conn = new MsAccessDatabase(new FileInfo(_dbPath));
    		Assert.IsTrue(conn.Open(),"Connection opened successfully.");
    		conn.Close();
    	}    	
        
        [Test]
        public void ConnectionTest_Close()
        {
            MsAccessDatabase conn = new MsAccessDatabase(new FileInfo(_dbPath));
            conn.Open();
            Assert.IsTrue(conn.Close(), "Connection closed successfully.");
        }
		
        [Test]
    	public void ConnectionTest_Insert()
    	{
    		MsAccessDatabase conn = new MsAccessDatabase(new FileInfo(_dbPath));
            DataTable dt = conn.GetTable("Test");
            TestRecordFactory factory = new TestRecordFactory(10,dt);
            foreach (DataRow r in factory.CreateTestRecords())
            {
                dt.Rows.Add(r);
            }
            conn.Update(dt);
            
        }
		
    	[Test]
        public void InsertCmdTest()
        {
            MsAccessDatabase conn = new MsAccessDatabase(new FileInfo(_dbPath));
            string str = MsAccessDatabase.OleDbInsertCommandString("Test",conn.GetColumnNames("Test").ToArray(),new object[] {"Hans","Tremmel","Now",1,"File","File_Name"});
            string actual = "INSERT INTO Test (Access_Time, File_Name, Local_Id, Sample_File_Binary, Some_Rnd_Num, User_First_Name, User_Last_Name) VALUES ('Hans','Tremmel','Now','1','File','File_Name')";
            Console.WriteLine(str);
            Console.WriteLine(actual);
            Assert.AreEqual(actual, str);
        } 
		
        [Test]
        public void CreateDatabaseTest()
        {
        	FileInfo fi = new FileInfo(_testDir+ "test " + DateTime.Now.ToString("hh-mm-ss") + ".accdb");
            Console.WriteLine(fi.FullName);
            InvoiceTrackerDatabase db = new InvoiceTrackerDatabase();
        	MsAccessDatabase adb = 
        		MsAccessDatabase.CreateAccessDatabase(fi, db);
        	Assert.IsNotNull(adb);
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
