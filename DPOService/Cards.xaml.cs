using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DPOService
{
    /// <summary>
    /// Логика взаимодействия для Cards.xaml
    /// </summary>
    public partial class Cards : UserControl
    {
        public Cards()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); } 
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(Cards));

        public string Number
        {
            get { return (string)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        public static readonly DependencyProperty NumberProperty = DependencyProperty.Register("Number", typeof(string), typeof(Cards));

        public FontAwesome.Sharp.IconChar Icon
        {
            get { return (FontAwesome.Sharp.IconChar)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(FontAwesome.Sharp.IconChar), typeof(Cards));

        public Color BackGround1
        {
            get { return (Color)GetValue(BackGround1Property); }
            set { SetValue(BackGround1Property, value); }
        }

        public static readonly DependencyProperty BackGround1Property = DependencyProperty.Register("BackGround1", typeof(Color), typeof(Cards));

        public Color BackGround2
        {
            get { return (Color)GetValue(BackGround2Property); }
            set { SetValue(BackGround2Property, value); }
        }

        public static readonly DependencyProperty BackGround2Property = DependencyProperty.Register("BackGround2", typeof(Color), typeof(Cards));

        public Color EllipseBackGround1
        {
            get { return (Color)GetValue(EllipseBackGround1Property); }
            set { SetValue(EllipseBackGround1Property, value); }
        }

        public static readonly DependencyProperty EllipseBackGround1Property = DependencyProperty.Register("EllipseBackGround1", typeof(Color), typeof(Cards));

        public Color EllipseBackGround2
        {
            get { return (Color)GetValue(EllipseBackGround2Property); }
            set { SetValue(EllipseBackGround2Property, value); }
        }

        public static readonly DependencyProperty EllipseBackGround2Property = DependencyProperty.Register("EllipseBackGround2", typeof(Color), typeof(Cards));
    }
}
