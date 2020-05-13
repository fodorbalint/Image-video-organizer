using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace GymnasticsVideoGallery
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public bool overWriteAll;
        public bool abort = true; //for when the user closes the window by X
        private bool firstKey = true; //even if isDefault is set true, OverwriteButton will look the same as the other buttons when we set the focus on it.
        //Without setting focus, it looks different. But then left-right key don't work for navigation.
        //We will set focus, when the first key is pressed.

        public Window2()
        {
            InitializeComponent();            
        }

        private void OverwriteButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            overWriteAll = false;
            this.Close();
        }

        private void OverwriteAllButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            overWriteAll = true;
            this.Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            abort = false;
            this.Close();
        }

        private void AbortButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            abort = true;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //OverwriteButton.Focus(); //will not put visual focus. Instead, it makes the button look like the others.
            Debug.Print("Window_Loaded Raising events");
            
            //not working: not putting visual focus
            /*this.RaiseEvent(new KeyEventArgs(Keyboard.PrimaryDevice,PresentationSource.FromVisual(this),0,Key.Tab) { RoutedEvent=Keyboard.PreviewKeyDownEvent });
            this.RaiseEvent(new KeyEventArgs(Keyboard.PrimaryDevice, PresentationSource.FromVisual(this), 0, Key.Tab) { RoutedEvent = Keyboard.KeyDownEvent });
            this.RaiseEvent(new KeyEventArgs(Keyboard.PrimaryDevice, PresentationSource.FromVisual(this), 0, Key.Tab) { RoutedEvent = Keyboard.PreviewKeyUpEvent });
            this.RaiseEvent(new KeyEventArgs(Keyboard.PrimaryDevice, PresentationSource.FromVisual(this), 0, Key.Tab) { RoutedEvent = Keyboard.KeyUpEvent });*/
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Debug.Print("Window_PreviewKeyDown " + e.Key.ToString());
            if (e.Key == Key.Escape) //abort
            {
                this.DialogResult = false;
                abort = true;
                this.Close();
            }

            if (firstKey)
            {
                firstKey = false;
                OverwriteButton.Focus();
            }
        }
    }
}
