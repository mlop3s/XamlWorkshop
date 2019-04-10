using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace XamlWorkshop
{
    public interface IMessageService
    {
        MessageBoxResult ShowWhatever(string message);
    }
}
