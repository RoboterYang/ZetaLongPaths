﻿namespace ZetaLongPaths.UnitTests
{
    using System.IO;
    using NUnit.Framework;

    [TestFixture]
    public class PathHelperTest
    {
        [Test]
        public void TestGeneral1()
        {
            const string path = "C:\\Users\\cliente\\Desktop\\DRIVES~2\\mdzip\\PASTAC~1\\SUBPAS~1\\PASTAC~1\\SUBPAS~1\\SUBDAS~1\\bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb.txt";
            var info = new ZlpFileInfo(path);
            Assert.AreEqual(info.Length, 0);
        }

        [Test]
        public void TestGeneral2()
        {
            var s1 =
                @"C:\Users\ukeim\Documents\Visual Studio 2008\Projects\Zeta Producer 9\Zeta Producer Main\Deploy\Origin\Enterprise\C-Allgaier\Windows\Packaging\Stationary\DEU\FirstStart\StandardProject";
            var s2 = ZlpPathHelper.GetFullPath(s1);

            Assert.AreEqual(
                @"C:\Users\ukeim\Documents\Visual Studio 2008\Projects\Zeta Producer 9\Zeta Producer Main\Deploy\Origin\Enterprise\C-Allgaier\Windows\Packaging\Stationary\DEU\FirstStart\StandardProject",
                s2);

            // --

            s1 = @"c:\ablage\..\windows\notepad.exe";
            s2 = ZlpPathHelper.GetFullPath(s1);

            Assert.AreEqual(@"c:\windows\notepad.exe", s2);

            //--

            s1 = @"lalala-123";
            s2 = ZlpPathHelper.GetFileNameWithoutExtension(s1);

            Assert.AreEqual(@"lalala-123", s2);

            //--

            s1 = @"lalala-123.txt";
            s2 = ZlpPathHelper.GetFileNameWithoutExtension(s1);

            Assert.AreEqual(@"lalala-123", s2);

            //--

            s1 = @"C:\Ablage\lalala-123.txt";
            s2 = ZlpPathHelper.GetFileNameWithoutExtension(s1);

            Assert.AreEqual(@"lalala-123", s2);

            //--

            s1 = @"\\nas001\data\folder\lalala-123.txt";
            s2 = ZlpPathHelper.GetFileNameWithoutExtension(s1);

            Assert.AreEqual(@"lalala-123", s2);

            //--

            s1 = @"c:\ablage\..\windows\notepad.exe";
            s2 = ZlpPathHelper.GetFileNameWithoutExtension(s1);

            Assert.AreEqual(@"notepad", s2);

            //--

            s1 = @"c:\ablage\..\windows\notepad.exe";
            s2 = ZlpPathHelper.GetExtension(s1);

            Assert.AreEqual(@".exe", s2);

            //--

            s1 = @"c:\ablage\..\windows\notepad.exe";
            s2 = ZlpPathHelper.ChangeExtension(s1, @".com");

            Assert.AreEqual(@"c:\ablage\..\windows\notepad.com", s2);

            // --

            s1 = @"file.ext";
            s2 = @"c:\ablage\path1\path2";
            var s3 = @"c:\ablage\path1\path2\file.ext";
            var s4 = ZlpPathHelper.GetAbsolutePath(s1, s2);

            Assert.AreEqual(s3, s4);

            // --

            s1 = @"c:\folder1\folder2\folder4\";
            s2 = @"c:\folder1\folder2\folder3\file1.txt";
            s3 = ZlpPathHelper.GetRelativePath(s1, s2);

            s4 = @"..\folder3\file1.txt";

            Assert.AreEqual(s3, s4);
        }

        [Test]
        public void TestCompareWithFrameworkFunctions()
        {
            string s1;
            string s2;

            // --

            s1 = ZlpPathHelper.GetFileNameFromFilePath(@"/suchen.html");
            s2 = Path.GetFileName(@"/suchen.html");

            Assert.AreEqual(s1, s2);

            // --

            s1 = ZlpPathHelper.GetDirectoryPathNameFromFilePath(@"sitemap.xml");
            s2 = Path.GetDirectoryName(@"sitemap.xml");

            Assert.AreEqual(s1, s2);

            //s1 = ZlpPathHelper.GetDirectoryPathNameFromFilePath(@"");
            //s2 = Path.GetDirectoryName(@"");

            //Assert.AreEqual(s1, s2);

            s1 = ZlpPathHelper.GetDirectoryPathNameFromFilePath(@"c:\ablage\sitemap.xml");
            s2 = Path.GetDirectoryName(@"c:\ablage\sitemap.xml");

            Assert.AreEqual(s1, s2);

            s1 = ZlpPathHelper.GetDirectoryPathNameFromFilePath(@"c:\ablage\");
            s2 = Path.GetDirectoryName(@"c:\ablage\");

            Assert.AreEqual(s1, s2);

            s1 = ZlpPathHelper.GetDirectoryPathNameFromFilePath(@"c:\ablage");
            s2 = Path.GetDirectoryName(@"c:\ablage");

            Assert.AreEqual(s1, s2);

            s1 = ZlpPathHelper.GetDirectoryPathNameFromFilePath(@"c:/ablage/sitemap.xml");
            s2 = Path.GetDirectoryName(@"c:/ablage/sitemap.xml");

            Assert.AreEqual(s1, s2);

            // --

            s1 = @"c:\folder1\folder2\folder3\file1.txt";

            var s3 = ZlpPathHelper.GetFileNameFromFilePath(s1);
            var s4 = Path.GetFileName(s1);

            Assert.AreEqual(s3, s4);

            // --

            s1 = @"c:\folder1\folder2\folder3\file1";

            s3 = ZlpPathHelper.GetFileNameFromFilePath(s1);
            s4 = Path.GetFileName(s1);

            Assert.AreEqual(s3, s4);

            // --

            s1 = @"c:\folder1\folder2\folder3\file1.";

            s3 = ZlpPathHelper.GetFileNameFromFilePath(s1);
            s4 = Path.GetFileName(s1);

            Assert.AreEqual(s3, s4);

            // --

            s1 = @"file1.txt";

            s3 = ZlpPathHelper.GetFileNameFromFilePath(s1);
            s4 = Path.GetFileName(s1);

            Assert.AreEqual(s3, s4);

            // --

            s1 = @"file1";

            s3 = ZlpPathHelper.GetFileNameFromFilePath(s1);
            s4 = Path.GetFileName(s1);

            Assert.AreEqual(s3, s4);

            // --

            s1 = @"file1.";

            s3 = ZlpPathHelper.GetFileNameFromFilePath(s1);
            s4 = Path.GetFileName(s1);

            Assert.AreEqual(s3, s4);

            // --

            s1 = @"c:\folder1\folder2\folder3\file1.txt";

            s3 = ZlpPathHelper.GetFileNameWithoutExtension(s1);
            s4 = Path.GetFileNameWithoutExtension(s1);

            Assert.AreEqual(s3, s4);

            // --

            s1 = @"c:\folder1\folder2\folder3\file1";

            s3 = ZlpPathHelper.GetFileNameWithoutExtension(s1);
            s4 = Path.GetFileNameWithoutExtension(s1);

            Assert.AreEqual(s3, s4);

            // --

            s1 = @"c:\folder1\folder2\folder3\file1.";

            s3 = ZlpPathHelper.GetFileNameWithoutExtension(s1);
            s4 = Path.GetFileNameWithoutExtension(s1);

            Assert.AreEqual(s3, s4);

            // --

            s1 = @"file1.txt";

            s3 = ZlpPathHelper.GetFileNameWithoutExtension(s1);
            s4 = Path.GetFileNameWithoutExtension(s1);

            Assert.AreEqual(s3, s4);

            // --

            s1 = @"file1";

            s3 = ZlpPathHelper.GetFileNameWithoutExtension(s1);
            s4 = Path.GetFileNameWithoutExtension(s1);

            Assert.AreEqual(s3, s4);

            // --

            s1 = @"file1.";

            s3 = ZlpPathHelper.GetFileNameWithoutExtension(s1);
            s4 = Path.GetFileNameWithoutExtension(s1);

            Assert.AreEqual(s3, s4);
        }

        [Test]
        public void TestEvenMoreFunctions()
        {
            var r = ZlpPathHelper.GetFileNameWithoutExtension(@"\\?\C:\Simulazioni\Albero\scratch_file.txt");
            Assert.AreEqual(r, @"scratch_file");

            r = ZlpPathHelper.GetFileNameWithoutExtension(@"\\?\C:\Simulazioni\Albero\scratch_file.");
            Assert.AreEqual(r, @"scratch_file");

            r = ZlpPathHelper.GetFileNameWithoutExtension(@"\\?\C:\Simulazioni\Albero\scratch_file");
            Assert.AreEqual(r, @"scratch_file");
        }
    }
}