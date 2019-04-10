using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace XamlWorkshop
{
    public class MessageBoxService : IMessageService
    {
        public MessageBoxResult ShowWhatever(string message)
        {
            return MessageBox.Show(message, "Info", MessageBoxButton.YesNo);
        }
    }
}
