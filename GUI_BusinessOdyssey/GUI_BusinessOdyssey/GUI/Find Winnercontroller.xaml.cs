using GUI_BusinessOdyssey.Management;
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

namespace GUI_BusinessOdyssey.GUI
{
    /// <summary>
    /// Interaction logic for Find_Winnercontroller.xaml
    /// </summary>
    public partial class Find_Winnercontroller : UserControl
    {
        Office of = new Office();

        public Find_Winnercontroller()
        {
            InitializeComponent();
            this.DataContext = of;

            of.findWinner();
        }
    }
}
