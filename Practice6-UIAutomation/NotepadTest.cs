using System.IO;
using FlaUI.Core.Input;
using NUnit.Framework;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;
using FluentAssertions;

namespace Practice6_UIAutomation
{
    public class NotepadTest
    {
        private Notepad _notepad; 

        [SetUp]
        public void Setup()
        {
            _notepad = new Notepad();
        }

        [TearDown]
        public void TearDown()
        {
            _notepad.Dispose();
        }

        [Test]
        public void ZoomTest()
        {
            _notepad.GetWindowTitle().Should().Be("Безымянный – Блокнот");
        
            _notepad.GetZoomPercent().Should().Be(100, "it is a default notepad zoom value.");
            
            _notepad.ZoomIn();
            _notepad.GetZoomPercent().Should().Be(110, "scale has been zoomed in by 10%");
            
            _notepad.ZoomOut();
            _notepad.ZoomOut();
            _notepad.GetZoomPercent().Should().Be(90, "scale has been zoomed out by 20%");
        }
        
        [Test]
        public void WriteFile()
        {
            const string text = "Hello World!";
            _notepad.WriteToDocument(text);
            
            const string path = @"C:\Users\blakk\OneDrive\Desktop\test.txt";
            _notepad.SaveDocument(path);
            
            Retry.WhileTrue(() => !File.Exists(path));
            Assert.That(File.Exists(path), "File has not been saved.");
        
            _notepad.OpenDocument(path).Should().Be(text, "this text has been written to the document.");
            File.ReadAllText(path).Should().Be(text, "this text has been written to the document.");
            
            File.Delete(path);
        }
    }
}