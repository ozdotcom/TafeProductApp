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

namespace ProductApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Product cProduct;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                cProduct = new Product(Convert.ToDecimal(priceTextBox.Text), Convert.ToInt16(quantityTextBox.Text));
                cProduct.calTotalPayment();
                totalPaymentTextBlock.Text = Convert.ToString(cProduct.TotalPayment);
                
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter data again", "Data Entry Error");
            }
            calTotalCharge();
            calTotalWrap();
            calTotalGST();
        }
        private double calTotalCharge()
        {
            double totalPayment = (double)Convert.ToDecimal(totalPaymentTextBlock.Text);
            double totalCharge = totalPayment + 25;
            totalChargeTextBlock.Text = totalCharge.ToString();
            return totalCharge;
        }
        private double calTotalWrap()
        {
            double totalPayment = (double)Convert.ToDecimal(totalPaymentTextBlock.Text);
            double totalCharge = (totalPayment + 25 + 5);
            totalWrapTextBlock.Text = totalCharge.ToString();
            return totalCharge;
        }
        private double calTotalGST()
        {
            double totalPayment = (double)Convert.ToDecimal(totalPaymentTextBlock.Text);
            double totalCharge = (totalPayment + 25 + 5) * 1.1;
            totalGSTTextBlock.Text = totalCharge.ToString();
            return totalCharge;
        }
        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            productTextBox.Text = "";
            priceTextBox.Text = "";
            quantityTextBox.Text = "";
            totalPaymentTextBlock.Text = "";
            totalChargeTextBlock.Text = "";
            totalGSTTextBlock.Text = "";
            totalWrapTextBlock.Text = "";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
