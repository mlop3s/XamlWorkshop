using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlWorkshop.ViewModel
{
    public class AncientEventArgs : EventArgs
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
