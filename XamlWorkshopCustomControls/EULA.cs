using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace XamlWorkshopCustomControls
{
    [ContentProperty("Text")]
    public sealed class EULA : UserControl
    {
        public EULA() => DefaultStyleKey = typeof(EULA);

        public event RoutedEventHandler Click;


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(EULA), new PropertyMetadata(string.Empty));

        public override void OnApplyTemplate()
        {
            if (GetTemplateChild("PART_BUTTON") is Button b)
            {
                b.Click += (s, e) => Click?.Invoke(s, e);
            }
        }
    }
}
