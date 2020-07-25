using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;

namespace GymnasticsVideoGallery
{
    public class CustomSlider : Slider
    {
        private bool mouseIn;

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            this.ApplyTemplate();
            Thumb thumb = (this.Template.FindName("PART_Track", this) as Track).Thumb;
            thumb.MouseEnter += new System.Windows.Input.MouseEventHandler(thumb_MouseEnter);
        }

        private void thumb_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && mouseIn)// && e.MouseDevice.Captured == null) what is this? makes no difference
            {
                //Debug.Print("thumb mouse entered, no action");
                // the left button is pressed on mouse enter
                // but the mouse isn't captured, so the thumb
                // must have been moved under the mouse in response
                // to a click on the track.
                // Generate a MouseLeftButtonDown event.
                MouseButtonEventArgs args = new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, MouseButton.Left)
                {
                    RoutedEvent = MouseLeftButtonDownEvent
                };
                (sender as Thumb).RaiseEvent(args);
                this.Focus(); //needed for the thumbSizeSlider. Otherwise it only gets focus, when we grab the slider thumb, not when we click on the track.
            }
        }

        protected override void OnPreviewMouseMove(System.Windows.Input.MouseEventArgs e)
        {
            //Debug.Print("-----OnPreviewMouseMove start, value: "+this.Value);
            base.OnPreviewMouseMove(e);
            //Debug.Print("OnPreviewMouseMove end, value: " + this.Value);
            if (mouseIn && e.LeftButton == MouseButtonState.Pressed)
            {
                //MouseButtonEventArgs args = new MouseButtonEventArgs(Mouse.PrimaryDevice, e.Timestamp, MouseButton.Left);
                //args.RoutedEvent = MouseLeftButtonDownEvent;
                //OnPreviewMouseLeftButtonDown(args);
                //this.OnThumbDragStarted(new DragStartedEventArgs(7.5, 7.5));                
                //base.OnPreviewMouseMove(e);
            }
        }

        protected override void OnMouseMove(System.Windows.Input.MouseEventArgs e)
        {
            //Debug.Print("-----OnMouseMove");
            //base.OnMouseMove(e);
        }

        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            //Debug.Print("-----OnPreviewMouseLeftButtonDown start, value: "+this.Value);
            double oldValue = this.Value;

            //sets new value to the slider
            base.OnPreviewMouseLeftButtonDown(e);

            double newValue = this.Value;
            //Debug.Print("OnPreviewMouseLeftButtonDown mid, value: " + this.Value + ", difference: " + (newValue - oldValue));
            //OnThumbDragCompleted(new DragCompletedEventArgs(newValue-oldValue, 0, false));   

            /*System.Windows.Input.MouseEventArgs args = new System.Windows.Input.MouseEventArgs(e.MouseDevice, e.Timestamp);
            OnPreviewMouseMove(args);
            OnMouseMove(args);

            thumb_MouseEnter((this.Template.FindName("PART_Track", this) as Track).Thumb, new System.Windows.Input.MouseEventArgs(e.MouseDevice, e.Timestamp));*/

            /*

            OnPreviewMouseUp(e);
            OnPreviewMouseLeftButtonUp(e);
            OnMouseUp(e);
            OnMouseLeftButtonUp(e);

            OnPreviewMouseDown(e);
            Debug.Print("-----OnPreviewMouseLeftButtonDown2 start, value: " + this.Value);
            base.OnPreviewMouseLeftButtonDown(e);
            Debug.Print("-----OnPreviewMouseLeftButtonDown2 end, value: " + this.Value);

            OnPreviewMouseMove(args);
            OnMouseMove(args);

            OnThumbDragStarted(new DragStartedEventArgs(7.5, 7.5));*/

            /*this.ApplyTemplate();
            Thumb thumb = (this.Template.FindName("PART_Track", this) as Track).Thumb;
            MouseButtonEventArgs args2 = new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, MouseButton.Left);
            args2.RoutedEvent = MouseLeftButtonDownEvent;
            thumb.RaiseEvent(args2);*/


            //base.OnPreviewMouseLeftButtonUp(e);
            //base.OnPreviewMouseLeftButtonDown(e);
            //OnThumbDragDelta(new DragDeltaEventArgs(newValue - oldValue+1, 0));

            //Debug.Print("OnPreviewMouseLeftButtonDown end, value: " + this.Value);
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            //Debug.Print("-----OnMouseLeftButtonDown");
            base.OnMouseLeftButtonDown(e);
            //this.OnThumbDragStarted(new DragStartedEventArgs(7.5, 7.5));            
        }

        protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
        {
            //Debug.Print("-----OnPreviewMouseDown");
            base.OnPreviewMouseDown(e);
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            //Debug.Print("-----OnMouseDown");
            base.OnMouseDown(e);
        }



        protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            //Debug.Print("-----OnPreviewMouseLeftButtonUp");
            base.OnPreviewMouseLeftButtonUp(e);
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            //Debug.Print("-----OnMouseLeftButtonUp");
            base.OnMouseLeftButtonUp(e);
        }

        protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
        {
            //Debug.Print("-----OnPreviewMouseUp");
            base.OnPreviewMouseUp(e);
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            //Debug.Print("-----OnMouseUp");
            base.OnMouseUp(e);
        }



        protected override void OnThumbDragStarted(DragStartedEventArgs e)
        {
            //Debug.Print("-----OnThumbDragStarted, HorizontalOffset: " + e.HorizontalOffset + ", VerticalOffset: " + e.VerticalOffset);
            base.OnThumbDragStarted(e);
        }

        protected override void OnThumbDragCompleted(DragCompletedEventArgs e)
        {
            //Debug.Print("-----OnThumbDragCompleted");
            base.OnThumbDragCompleted(e);
        }

        protected override void OnThumbDragDelta(DragDeltaEventArgs e)
        {
            //Debug.Print("-----OnThumbDragDelta, HorizontalChange: " + e.HorizontalChange + ", value: " + this.Value);
            base.OnThumbDragDelta(e);
        }

        protected override void OnValueChanged(double oldValue, double newValue)
        {
            //Debug.Print("-----OnValueChanged, old: " + oldValue + ", new: " + newValue);
            base.OnValueChanged(oldValue, newValue);
        }



        protected override void OnMouseEnter(System.Windows.Input.MouseEventArgs e)
        {
            if (mouseIn == false && e.LeftButton == MouseButtonState.Pressed)
            {
                mouseIn = false;
            }
            else
            {
                mouseIn = true;
            }
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                mouseIn = false;
            }
            base.OnMouseLeave(e);
        }
    }

    public class SliderIgnoreDelta : Slider
    {
        public bool sliderDragging = false;
        //volume can be bound, but not speedratio, which should only be updated after the drag is finished, or we clicked on the slider somewhere. For performance reasons. (the video freezes)
        //we need to prevent valueChange while the thumb is dragging, but it needs to change, when the thumb is released, and when we click on the track.
        //though restoring the value in OnThumbDragDelta does not work (as a result, the thumb will not move at all), we can set a variable to keep track is dragging is in progress.

        protected override void OnThumbDragStarted(DragStartedEventArgs e)
        {
            sliderDragging = true;
            base.OnThumbDragStarted(e);
        }

        protected override void OnThumbDragCompleted(DragCompletedEventArgs e)
        {
            sliderDragging = false;
            base.OnValueChanged(Value, Value);
            base.OnThumbDragCompleted(e);
        }
    }

    public class NumericField : System.Windows.Controls.TextBox
    {
        public static DependencyProperty ValueMinProperty;
        public static DependencyProperty ValueMaxProperty;

        static NumericField()
        {
            ValueMinProperty = DependencyProperty.Register("ValueMin", typeof(int), typeof(NumericField));
            ValueMaxProperty = DependencyProperty.Register("ValueMax", typeof(int), typeof(NumericField));
        }

        public int ValueMin
        {
            get { return (int)base.GetValue(ValueMinProperty); }
            set { base.SetValue(ValueMinProperty, value); }
        }

        public int ValueMax
        {
            get { return (int)base.GetValue(ValueMaxProperty); }
            set { base.SetValue(ValueMaxProperty, value); }
        }
    }

    public class SettingDimensionsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value * -1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
