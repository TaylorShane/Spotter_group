﻿using System;
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

namespace Spotter_group
{
    /// <summary>
    /// Interaction logic for Workout.xaml
    /// </summary>
    public partial class Workout : UserControl
    {
        public Workout()
        {
            InitializeComponent();
            setWorkoutInformation();
        }

        public void setWorkoutInformation()
        {
            workout_description_1.Text = "HI!";
        }
    }
}
