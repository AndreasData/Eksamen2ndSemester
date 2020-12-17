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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ReqeustSystem
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public RequestViewModel ViewModel { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            ViewModel = new RequestViewModel();
        }

        public void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NotificationLabel.Text = "Request Submited";
        }

        private void j(object sender, SelectionChangedEventArgs e)
        {
            BuildingComboBox.Text = NotificationLabel.Text;
        }
        private void BuildingComboBox_SelectedIndexChanged(Object sender, EventArgs e) 
        {
            BuildingComboBox.Text = NotificationLabel.Text;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
