using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjektP4
{
    public class MenuItem
    {
        public string Label { get; set; }
        public ObservableCollection<MenuItem> Children { get; set; } = new();
    }
}

