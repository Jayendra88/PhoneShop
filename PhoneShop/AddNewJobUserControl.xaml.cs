﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhoneShop
{
    /// <summary>
    /// Interaction logic for AddNewJobUserControl.xaml
    /// </summary>
    public partial class AddNewJobUserControl : UserControl
    {
        public AddNewJobUserControl()
        {
            InitializeComponent();
        }

        private void CancelJobBtnClicked(object sender, RoutedEventArgs e)
        {
            customrNameTxtBox.Text = "";
            mobileNoTxtBox.Text = "";
            landNoTxtBox.Text = "";
            emailTxtBox.Text = "";

            brandNameTxtBox.Text = "";
            emiNoTxtBox.Text = "";
            jobNoteTxtBox.Text = "";

            isPhoneChkBox.IsChecked = false;
            isCharterChkBox.IsChecked = false;
            isBatteryChkBox.IsChecked = false;
            isMemoryChkBox.IsChecked = false;
            isSimChkBox.IsChecked = false;
            otherAccessoryTxtBox.Text = "";

            otherJobDetailTxtBox.Text = "";
            advancePaymentTxtBox.Text = "";
        }

        private void SaveJobBtnClicked(object sender, RoutedEventArgs e)
        {
            if (nicNoCBox.Text == null) { nicNoCBox.Focus(); return; }
            else if (customrNameTxtBox.Text == null) { customrNameTxtBox.Focus(); return; }
            else if (phoneModelNoCBox.Text == null) { brandNameTxtBox.Focus(); return; }
            else if (emiNoTxtBox.Text == null) { emiNoTxtBox.Focus(); return; }


        }
    }
}