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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace copiedApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Instructions : Page
    {
        public Instructions()
        {
            this.InitializeComponent();
            textb.Text = "1. The app doesn’t claim to professionally diagnose psychological or emotional disorders in individuals and should not be used for the same." + "\n" +
                          "2. For best results avoid portraying fake/ forced emotions during the test as this may alter the authenticity of the results." + "\n" +
                          "3. Try to get a clear and bright view of the face to ensure high accuracy of results." + "\n" +
                          "4. The slideshow will move automatically." + "\n" +
                          "5. Do not try to think of anything else while taking the test. Do not take the test when dominated by one particular emotion.";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
