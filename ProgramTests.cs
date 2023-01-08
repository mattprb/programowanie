using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    internal class ProgramTests
    {
        [Test]
        public void TestCreateDirectory()
        {
            // Arrange
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderName = Path.Combine(desktopPath, "dane");

            // Act
            if (Directory.Exists(folderName))
            {
                Directory.Delete(folderName, true); //usuwa plik jak bedzie on na dysku
            }
        
            Directory.CreateDirectory(folderName);

            // Assert
            Assert.IsTrue(Directory.Exists(folderName));
            Directory.Delete(folderName, true);
        }

    }
}
