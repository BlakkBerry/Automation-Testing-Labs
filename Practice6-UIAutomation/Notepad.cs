using System;
using FlaUI.UIA3;
using FlaUI.Core;
using System.Linq;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using FlaUI.Core.Definitions;
using FlaUI.Core.AutomationElements;
using System.Text.RegularExpressions;

namespace Practice6_UIAutomation
{
    public class Notepad : IDisposable
    {
        private readonly Window _window;

        public Notepad()
        {
            var application = Application.Launch(@"C:\Windows\System32\notepad.exe");
            var automation = new UIA3Automation();
            _window = application.GetMainWindow(automation);
        }

        public void ZoomIn()
        {
            var scaleUpBtn = GetZoomMenuItems().Single(menuItem => menuItem.Name == "Увеличить");

            scaleUpBtn.WaitUntilClickable();
            scaleUpBtn.Click();
        }

        public void ZoomOut()
        {
            var scaleUpBtn = GetZoomMenuItems().Single(menuItem => menuItem.Name == "Уменьшить");

            scaleUpBtn.WaitUntilClickable();
            scaleUpBtn.Click();
        }

        public int GetZoomPercent()
        {
            var zoomText = _window.FindAllByXPath("/StatusBar/Text[3]")[0].Name;
            var zoomNumberString = Regex.Match(zoomText, @"[0-9]+").ToString();
            return Convert.ToInt32(zoomNumberString);
        }

        public void WriteToDocument(string text)
        {
            var document = _window.FindAllChildren().Single(element =>
                element.ControlType == ControlType.Document && element.ClassName == "Edit");

            document.Click();
            Keyboard.Type(text);
        }

        public string OpenDocument(string path)
        {
            var openBtn = GetFileMenuItems().Single(menuItem =>
                menuItem.ControlType == ControlType.MenuItem && menuItem.Name == "Открыть...");
            openBtn.WaitUntilClickable();
            openBtn.Click();
            
            Retry.WhileTrue(() => _window.ModalWindows.Length == 0);
            var openingModal = _window.ModalWindows[0].AsWindow();

            var nameEdit = openingModal.FindAllDescendants().Single(element =>
                element.ControlType == ControlType.Edit && element.Name == "Имя файла:");
            
            Retry.WhileTrue(() => !nameEdit.FrameworkAutomationElement.HasKeyboardFocus);
            Keyboard.Type(path);
            
            var openingBtn = _window.FindAllByXPath("/Window/Button[1]")[0];
            openingBtn.WaitUntilClickable();
            openingBtn.Click();

            var document = _window.FindAllChildren().Single(element =>
                element.ControlType == ControlType.Document && element.ClassName == "Edit");
            
            return document.AsTextBox().Text;
        }

        public void SaveDocument(string path)
        {
            var saveBtn = GetFileMenuItems().Single(menuItem =>
                menuItem.ControlType == ControlType.MenuItem && menuItem.Name == "Сохранить");
            saveBtn.WaitUntilClickable();
            saveBtn.Click();
                
            Retry.WhileTrue(() => _window.ModalWindows.Length == 0);
            var savingModal = _window.ModalWindows[0].AsWindow();

            var nameEdit = savingModal.FindAllDescendants().Single(element =>
                element.ControlType == ControlType.Edit && element.Name == "Имя файла:");

            Retry.WhileTrue(() => !nameEdit.FrameworkAutomationElement.HasKeyboardFocus);
            Keyboard.Type(path);

            var savingBtn = savingModal.FindAllDescendants().Single(element =>
                element.ControlType == ControlType.Button && element.Name == "Сохранить");
            savingBtn.WaitUntilClickable();
            savingBtn.Click();
        }

        public string GetWindowTitle()
        {
            return _window.Title;
        }

        private MenuItems GetZoomMenuItems()
        {
            var menuItems = GetMenuItems();
            
            var viewTab = menuItems.Single(menuItem =>
                menuItem.ControlType == ControlType.MenuItem && menuItem.Name == "Вид");
            viewTab.WaitUntilClickable();
            viewTab.Click();
            
            var viewMenu = _window.FindAllDescendants().Single(element =>
                element.ControlType == ControlType.Menu && element.Name == "Вид");
            
            var scaleTab = viewMenu.FindAllChildren().Single(
                menuItem => menuItem.ControlType == ControlType.MenuItem && menuItem.Name == "Масштаб");
            scaleTab.WaitUntilClickable();
            scaleTab.Click();
            
            var scaleMenu = _window.FindAllDescendants().Single(element =>
                element.ControlType == ControlType.Menu && element.Name == "Масштаб");

            return scaleMenu.AsMenu().Items;
        }

        private MenuItems GetFileMenuItems()
        {
            var fileTab = GetMenuItems().Single(menuItem =>
                menuItem.ControlType == ControlType.MenuItem && menuItem.Name == "Файл");
            fileTab.WaitUntilClickable();
            fileTab.Click();

            return _window.FindAllChildren().Single(element =>
                element.ControlType == ControlType.Menu && element.Name == "Файл").AsMenu().Items;
        }
        
        private MenuItems GetMenuItems()
        {
            return _window.FindAllByXPath("/MenuBar")[0].AsMenu().Items;
        }

        public void Dispose()
        {
            _window.Close();
        }
    }
}