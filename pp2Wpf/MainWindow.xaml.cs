using pp2;
using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace pp2Wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var path = "C:/Users/alpha/source/repos/pp2/pp2/TestImages/a.png";
            var image = new Bitmap(path);

            var data = ImageConvert.Convert(image);

            string a = "";

            data.ToList().ForEach(x => {
                a += x.ToString();
            });

            tb.Text = a;
        }
    }
}
