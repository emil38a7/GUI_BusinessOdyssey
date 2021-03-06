﻿using GUI_BusinessOdyssey.Management;
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
    /// Interaction logic for ViewAllTeamsController.xaml
    /// </summary>
    public partial class ViewAllTeamsController : UserControl
    {
        Office office = null;
        public ViewAllTeamsController()
        {
            InitializeComponent();
            office = EventMenuControl.office;

            this.DataContext = office;
            office.groupView("sGroupName", "studentId");
            office.judgeGroupView("jGroupName", "judgeId");
        }
    }
}
