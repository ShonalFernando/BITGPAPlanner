using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Client.View.Dialogs
{
    public static class BitvaDialogs
    {
        public static string ShowInputDialog(string prompt = "Please enter a value:", string caption = "Input Box", string current = "")
        {
            InputDialog dialog = new InputDialog(prompt, caption, current);
            var dialogResult = dialog.ShowDialog();
            if(dialogResult.HasValue)
            {
                return dialog.InputText;
            }

            return "";
        }

        public static string ShowSelectorDialog(List<string> stringCollection, string prompt = "Please enter a value:", string caption = "Input Box", string current = "")
        {
            DropSelectorDialog dialog = new DropSelectorDialog(stringCollection, prompt, caption, current);
            var dialogResult = dialog.ShowDialog();
            if (dialogResult.HasValue)
            {
                if(!string.IsNullOrEmpty(dialog.SelectedString))
                {
                    return dialog.SelectedString;
                }
                else
                {
                    return "";
                }
            }
            return "";
        }

        public static object? ShowGridDialog<T>(List<T> objectCollection, string prompt = "Please enter a value:", string caption = "Input Box", string current = "")
        {
            GridSelector dialog = new GridSelector(objectCollection.Cast<object>().ToList(), prompt, caption, current);
            var dialogResult = dialog.ShowDialog();
            if (dialogResult.HasValue)
            {
                if (dialog.SelectedObject != null)
                {
                    return dialog.SelectedObject;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        public static (string?, string?) ShowResourceAdder(string prompt = "Please enter a value:", string caption = "Input Box")
        {
            AddResourceDialog dialog = new AddResourceDialog(prompt, caption);
            var dialogResult = dialog.ShowDialog();
            if (dialogResult.HasValue)
            {
                if (dialog.PathString != null)
                {
                    return (dialog.PathString, dialog.Category);
                }
                else
                {
                    return (null, null);
                }
            }
            return (null, null);
        }
    }
}
