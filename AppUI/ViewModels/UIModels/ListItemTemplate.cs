using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System;
using System.Text.RegularExpressions;

namespace ProjektP4.AppUI.ViewModels.UIModels
{
    public class ListItemTemplate
    {
        public ListItemTemplate(Type type, string iconKey)
        {
            ModelType = type;
            Label = Regex.Replace(type.Name.Replace("PageViewModel", ""), "(\\B[A-Z])", " $1");

            if (Application.Current?.TryFindResource(iconKey, out var res) == true && res is StreamGeometry geometry)
                ListItemIcon = geometry;
            else
                ListItemIcon = new StreamGeometry(); // lub null, jeśli zmienisz typ
        }
        public string Label { get; }
        public Type ModelType { get; }
        public StreamGeometry ListItemIcon { get; }
    }
}
