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
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : UserControl
    {
        public SignIn()
        {
            InitializeComponent();
            
        }

        string visiblePath = @"C:\Users\admin\Source\Repos\Spotter_group\Spotter_group\Data\Visible.xml";
        string currentPath = @"C:\Users\admin\Source\Repos\Spotter_group\Spotter_group\Data\CurrentUser.xml";
        string jasonPath = @"C:\Users\admin\Source\Repos\Spotter_group\Spotter_group\Data\Users.xml";
        string stevePath = @"C:/Users/drof/Source/Repos/Spotter_group/Spotter_group/Data/Users.xml";
        string shanePath = @"C:/Users/xbox_000/Source/Repos/Spotter/Spotter_group/Spotter_group/Data/Users.xml";
        string ShaneCurrentPath = @"C:/Users/xbox_000/Source/Repos/Spotter/Spotter_group/Spotter_group/Data/CurrentUser.xml";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //this is trying to signin
                string user_name1 = user_name.Text;
                string pass_word1 = pass_word.Password;

                IEnumerable<string> UserPassword = from Users in XDocument.Load(shanePath).Descendants("User")
                                                   where (string)Users.Element("Username") == user_name1
                                                   select Users.Element("Password").Value;


                string s2 = UserPassword.FirstOrDefault().ToString();
                

                if (s2 != pass_word1)
                {
                    throw new Exception("Password Mismatch");
                }

                else
                {
                    XDocument xmlDocument = XDocument.Load(ShaneCurrentPath);
                    xmlDocument.Element("CurrentUser").Add(
                       new XElement("User", new XAttribute("ID", 0),
                       new XElement("UserName", user_name1)));
                    xmlDocument.Save(ShaneCurrentPath);

                    MessageBox.Show("Successful Login! \n Please return to profile");

                }

            }

            //when login and password dont match, we catch the error and display box you are a naughty person
            catch (Exception err)
            {
                MessageBox.Show("Please Ty Aain! Password Mismatch!");
            }
        }
    }
}
 