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
using System.Xml.Linq;


namespace Spotter_group
{
    /// <summary>
    /// Interaction logic for Nutrition.xaml
    /// </summary>
    public partial class Nutrition : UserControl
    {
        public Nutrition()
        {
            InitializeComponent();
        }

        string shanePath = @"C:/Users/xbox_000/Source/Repos/Spotter/Spotter_group/Spotter_group/Data/Food.xml";
        // PATH LOCATION
        private void btnSaveMeal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                string protein = cboBox_Proteins.Text;
                int proteinCalories = Convert.ToInt32(tboxProteinCalories.Text);
                int veggieCalories = Convert.ToInt32(tboxVeggieCalories.Text);
                int fruitsCalories = Convert.ToInt32(tboxFruitsCalories.Text);
                int alcoholCalories = Convert.ToInt32(tboxAlcoholCalories.Text);
                int miscCalories = Convert.ToInt32(tboxMiscCalories.Text);
                int totalCalories = proteinCalories + veggieCalories + fruitsCalories + alcoholCalories + miscCalories;
                txtBlock_CaloriesToConsume.Text = totalCalories.ToString();
                string display = txtBlock_CaloriesToConsume.Text;

                var converter = new System.Windows.Media.BrushConverter();
                var teal = (Brush)converter.ConvertFromString("#009999");

                if (totalCalories < 1500)
                {
                    txtBlock_CaloriesToConsume.Foreground = Brushes.Green;
                }
                else if (totalCalories >= 1800 && totalCalories < 2000)
                {
                    txtBlock_CaloriesToConsume.Foreground = Brushes.Yellow;
                }
                else if (totalCalories == 2000)
                {
                    
                    display = txtBlock_CaloriesToConsume.Text;
                    
                    txtBlock_CaloriesToConsume.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#009999")); ;
                    txtBlock_CaloriesToConsume.Text = "Great! " + display + " calories";
                }
                else if(totalCalories > 2000)
                {
                    txtBlock_CaloriesToConsume.Foreground = Brushes.Red;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Please enter a numeric value for each calorie count box");
            }
            
        }
        
        private void cboBox_Proteins_DropDownClosed(object sender, EventArgs e)
        {
            
            string refItem = cboBox_Proteins.Text;
            // MessageBox.Show(refItem);

            IEnumerable<string> CaloriesResult = from food_items in XDocument.Load(shanePath).Descendants("protein")
                                        where (string)food_items.Element("name") == refItem
                                                 select food_items.Element("calories").Value;
            
            tboxProteinCalories.Text = CaloriesResult.FirstOrDefault().ToString();
        }
    }
}
