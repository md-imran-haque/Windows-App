using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MyStoreApp.MyService;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyStoreApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        dbServiceSoapClient db = new dbServiceSoapClient();
        public MainPage()
        {
            this.InitializeComponent();
            List<string> tittles = new List<string>
            {
                "Mr.",
                "Md.",
                "Miss",
                "Ms"
            };
            this.cmbTittle.ItemsSource = tittles;
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Windows.UI.Popups.MessageDialog msgShow = new Windows.UI.Popups.MessageDialog("Id : " + txtId.Text + "\nTittle : " + cmbTittle.SelectedItem.ToString() + "\nFirst Name : " + txtFName.Text + "\nLast Name : " + txtLName + "\nEmail : " + txtEmail.Text + "\nMobile No : " + txtMobileNo.Text + "\nCourse : " + txtCourse.Text);
            msgShow.ShowAsync();
        }

        private async void btninsert_Click(object sender, RoutedEventArgs e)
        {
            var a = await db.InsertDataAsync(int.Parse(txtId.Text), cmbTittle.SelectedItem.ToString(), txtFName.Text, txtLName.Text, txtEmail.Text, txtMobileNo.Text, txtCourse.Text);
            if (a.Body.InsertDataResult > 0)
            {
                Windows.UI.Popups.MessageDialog msgShow = new Windows.UI.Popups.MessageDialog("Data Inserted successfully!!!");
                msgShow.ShowAsync();
            }
            txtId.Text = "";
            txtFName.Text = "";
            txtLName.Text = "";
            txtEmail.Text = "";
            txtMobileNo.Text = "";
            txtCourse.Text = "";
            cmbTittle.SelectedValue = -1;

            //Windows.UI.Popups.MessageDialog msgShow = new Windows.UI.Popups.MessageDialog("Id : " + txtId.Text + "\nTitle : " + cmbTitle.SelectedItem.ToString() + "\nFirst Name : " + txtFirstName.Text + "\nLast Name : " + txtLastName.Text + "\nEmail :" + txtEmail.Text + "\nPhone No : " + txtPhone.Text);
            //msgShow.ShowAsync();
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var a = await db.UpdateDataAsync(int.Parse(txtId.Text), cmbTittle.SelectedItem.ToString(), txtFName.Text, txtLName.Text, txtEmail.Text, txtMobileNo.Text, txtCourse.Text);
            if (a.Body.UpdateDataResult > 0)
            {
                Windows.UI.Popups.MessageDialog msgShow = new Windows.UI.Popups.MessageDialog("Data Inserted successfully!!!");
                msgShow.ShowAsync();
            }
            txtId.Text = "";
            txtFName.Text = "";
            txtLName.Text = "";
            txtEmail.Text = "";
            txtMobileNo.Text = "";
            txtCourse.Text = "";
            cmbTittle.SelectedValue = -1;
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var a = await db.DeleteDataAsync(int.Parse(txtId.Text));
            if (a > 0)
            {
                Windows.UI.Popups.MessageDialog msgShow = new Windows.UI.Popups.MessageDialog("Data Deleted successfully!!!");
                msgShow.ShowAsync();
            }
            txtId.Text = "";
            txtFName.Text = "";
            txtLName.Text = "";
            txtEmail.Text = "";
            txtMobileNo.Text = "";
            txtCourse.Text = "";
            cmbTittle.SelectedValue = -1;
        }
    }
}
