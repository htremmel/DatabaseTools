using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseTools.Excel;
using NUnit.Framework;
using System.Reflection;
using System.IO;

namespace DatabaseTools_Tests.ExcelTests
{
    [TestFixture]
    public class ExcelTests
    {
        ExcelConnectionStringBuilder eConnStr;
        FileInfo target;
        [SetUp]
        public void Setup()
        {
            string targetPath = @"\0-TestDatabases\MyExcelDatabase.xlsx";
            FileInfo sourceDir = new FileInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            var tDir = new DirectoryInfo(sourceDir.FullName);
            string excelDbPath = tDir.Parent.Parent.FullName + targetPath;
            target = new FileInfo(excelDbPath);
        }

        [TestCase(ExcelConnectionStringBuilder.Driver.Ace)]
        [TestCase(ExcelConnectionStringBuilder.Driver.Jet)]
        [TestCase(ExcelConnectionStringBuilder.Driver.Odbc)]
        public void ExcelStringBuilder_Test(ExcelConnectionStringBuilder.Driver driver)
        {
            eConnStr = new ExcelConnectionStringBuilder(driver, target);
            Console.WriteLine(eConnStr.ConnectionString);
            Assert.IsTrue(eConnStr.TryConnection(), eConnStr.ConnectionString);
        }

        [Test]
        public void ExcelACEConnString_Test()
        {
            eConnStr = new ExcelConnectionStringBuilder(ExcelConnectionStringBuilder.Driver.Ace, new FileInfo(@"c:\myFolder\myExcel2007file.xlsx"));
            Console.WriteLine("Test connection string");
            Console.WriteLine(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\myFolder\myExcel2007file.xlsx;Extended Properties=""Excel 12.0 Xml;HDR=YES"";");
            Console.WriteLine("Method conncection string");
            Console.WriteLine(eConnStr.ConnectionString);
        }
    }
}
