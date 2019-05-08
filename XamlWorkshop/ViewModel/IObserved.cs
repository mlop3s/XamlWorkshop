using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlWorkshop.ViewModel
{
    public interface IObserved
    {
        event EventHandler<AncientEventArgs> AncientOne;
    }
}
