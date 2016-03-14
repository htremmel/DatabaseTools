using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseTools.MySQL;
using NUnit.Framework;

namespace DatabaseTools_Tests.MySQLTests
{
    [TestFixture]
    public class MySqlTest
    {
        MySQLConnectionStringBuilder bldr;
        [SetUp]
        public void Setup()
        {
            bldr = new MySQLConnectionStringBuilder() 
            {
                Server = "http://pelagodromo.synology.me/phpMyAdmin/index.php?db=&token=500554880eb4af0f12e0d006b7f452c3&old_usr=root",
                UserId = "root",
                Password = "rzvDPqBQBSFuNGYt",
                Database = "test"
            };  
        }

        [Test]
        public void TestConnection()
        {
            Assert.IsTrue(bldr.TryConnection(),bldr.ConnectionString);            
        }
    }
}
