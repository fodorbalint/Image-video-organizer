using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private string resourceDir = AppDomain.CurrentDomain.BaseDirectory + @"resources\";
        private bool mouseIn; //no closing action, when the mouse button was pressed down outside the image, but released in it.
        public double dragStartX = -1;
        public double dragStartY;
        private string fileName, skillsPath;
        private double videoFrameRate;
        //private Stopwatch selStw;
        private Timer selTimer;
        private MainWindow parentWindow;

        public Window1(string arg1, string arg2, int arg3, double arg4)
        {
            try
            {
                InitializeComponent();
                
                CloseButton.Source = new BitmapImage(new Uri(resourceDir + "\\close.png", UriKind.Absolute)); //relative source is not working
                //Environment.CurrentDirectory cannot be used, when we open a video file with the program.
                this.Topmost = true;
                this.WindowStyle = WindowStyle.None;
                this.Top = 0;
                this.Left = System.Windows.SystemParameters.PrimaryScreenWidth - this.Width;

                //Getting parent window (Parent is not working)
                foreach (Window win in App.Current.Windows)
                {
                    //In case of "MainWindow" here you can set your respective MainWindow object in wpf
                    if (win.GetType() == typeof(MainWindow))
                    {
                        parentWindow = (MainWindow)win;
                        break;
                    }
                }

                fileName = arg1;
                skillsPath = arg2;
                int videoDuration = arg3;
                videoFrameRate = arg4;

                string[] arr = IndexToOrigWoRoot(fileName);
                FileNameText1.Text = arr[0];
                FileNameText2.Text = arr[1];

                string[] text = File.ReadAllLines(fileName);
                string line;
                string nextline;
                string printline;
                int count = text.Length;

                line = text[0];
                string[] lineArr = line.Split(',');
                double thistime = double.Parse(lineArr[1], CultureInfo.InvariantCulture) * 1000;

                for (int i = 0; i < count - 1; i++)
                {
                    nextline = text[i + 1];
                    string[] nextlineArr = nextline.Split(',');

                    double nexttime = double.Parse(nextlineArr[1], CultureInfo.InvariantCulture) * 1000;

                    string timeStamp0 = thistime.ToString("0,000.000", CultureInfo.InvariantCulture);
                    printline = timeStamp0 + " " + lineArr[2] + "-" + lineArr[0] + " " + (nexttime - thistime).ToString("0.000", CultureInfo.InvariantCulture);
                    var l = new ListViewItem();
                    l.Content = printline;
                    l.Height = 18;
                    l.Padding = new Thickness(10, 0, 0, 0);
                    //l.VerticalAlignment = VerticalAlignment.Top;
                    //l.VerticalContentAlignment = VerticalAlignment.Top;
                    FramesText.Items.Add(l);

                    if (lineArr[2] == "I")
                    {
                        l.FontWeight = FontWeights.Bold;
                    }

                    lineArr = nextlineArr;
                    thistime = nexttime;
                }

                string timeStamp1 = thistime.ToString("0,000.000", CultureInfo.InvariantCulture);

                printline = timeStamp1 + " " + lineArr[2] + "-" + lineArr[0] + " " + (videoDuration - thistime).ToString("0.000", CultureInfo.InvariantCulture);
                var li = new ListViewItem();
                li.Content = printline;
                li.Height = 18;
                li.Padding = new Thickness(10, 0, 0, 0);
                FramesText.Items.Add(li);

                if (lineArr[2] == "I")
                {
                    li.FontWeight = FontWeights.Bold;
                }

                FramesText.PreviewMouseLeftButtonDown += FramesText_PreviewMouseLeftButtonDown;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\n" + e.StackTrace);
            }
        }

        private void CloseButton_MouseEnter(object sender, MouseEventArgs e)
        {
            CloseButton.Source = new BitmapImage(new Uri(resourceDir + "\\close_over.png", UriKind.Absolute));
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                mouseIn = false;
            }
            else
            {
                mouseIn = true;
            }
        }

        private void CloseButton_MouseLeave(object sender, MouseEventArgs e)
        {
            CloseButton.Source = new BitmapImage(new Uri(resourceDir + "\\close.png", UriKind.Absolute));
            mouseIn = false;
        }

        private void CloseButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CloseButton.Source = new BitmapImage(new Uri(resourceDir + "\\close_down.png", UriKind.Absolute));
        }

        private void CloseButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mouseIn)
            {
                this.Close();
            }
            else
            {
                mouseIn = true;
            }
        }

        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragStartX != -1 && e.LeftButton == MouseButtonState.Pressed)
            {
                double x = e.GetPosition(Rect).X;
                double y = e.GetPosition(Rect).Y;
                Left += x - dragStartX;
                Top += y - dragStartY;
            }
        }        

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            dragStartX = e.GetPosition(Rect).X;
            dragStartY = e.GetPosition(Rect).Y;
        }

        private void Rectangle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (dragStartX != -1)
            {
                dragStartX = -1;
            }            
        }

        private void ReindexButton_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                //ffmpeg -y -i 20180206_210930.mp4 -c copy -f h264 20180206_210930.h264
                //ffmpeg -y -i 20180206_210930.mp4 -vn -acodec copy 20180206_210930.aac
                //ffmpeg -y -framerate 59.104 -i 20180206_210930.h264 -i 20180206_210930.aac -c copy 20180206_210930_1.mp4
                string videoFile = IndexToOrig(fileName);
                string dir = System.IO.Path.GetDirectoryName(videoFile) + "\\";
                string fileWoExt = System.IO.Path.GetFileNameWithoutExtension(videoFile);
                string newFileh264 = dir + fileWoExt + ".h264";

                var process = new Process();
                var startInfo = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    FileName = @"resources\ffmpeg.exe",
                    Arguments = "-y -i \"" + videoFile + "\" -c copy -f h264 \"" + newFileh264 + "\""
                };
                process.StartInfo = startInfo;
                Debug.Print(process.StartInfo.Arguments);
                process.Start();
                process.WaitForExit();

                string newFileaac = dir + fileWoExt + ".aac";

                process = new Process();
                startInfo = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    FileName = @"resources\ffmpeg.exe",
                    Arguments = "-y -i \"" + videoFile + "\" -vn -acodec copy \"" + newFileaac + "\""
                };
                process.StartInfo = startInfo;
                Debug.Print(process.StartInfo.Arguments);
                process.Start();
                process.WaitForExit();

                string newFile = dir + fileWoExt + parentWindow.settings["ReindexRenameRule"] + ".mp4";

                process = new Process();
                startInfo = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    FileName = @"resources\ffmpeg.exe",
                    Arguments = "-y -framerate " + videoFrameRate.ToString(CultureInfo.InvariantCulture) + " -i \"" + newFileh264 + "\" -i \"" + newFileaac + "\" -c copy \"" + newFile + "\""
                };
                process.StartInfo = startInfo;
                Debug.Print(process.StartInfo.Arguments);
                process.Start();
                process.WaitForExit();

                File.Delete(newFileh264);
                File.Delete(newFileaac);

                MessageBox.Show(newFile + " was created.");

                if (!parentWindow.isPictureFullscreen || !parentWindow.isVideoFullscreen) //will update thumbnails in thumbnail view
                {
                    string selectedSkill = parentWindow.settings["SelectedSkill"] == "." ? parentWindow.settings["SkillsPath"] : parentWindow.settings["SkillsPath"] + parentWindow.settings["SelectedSkill"] + @"\";
                    if (selectedSkill == dir)
                    {
                        parentWindow.StartUpdateThumbs();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message + " " + ex.StackTrace);
            }

            //MessageBox.Show(IndexToOrig(fileName));
        }

        //private Stopwatch selStw; //for testing

        private void FramesText_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) //GotFocus event is not firing, when it gets focus without the selection changing.
        //here we don't yet know if we clicked on another list item, the selection is not yet changed.
        {
            Debug.Print("FramesText_PreviewMouseLeftButtonDown");
            /*selStw = new Stopwatch(); //5-13 ms until SelectionChanged
            selStw.Start();*/

            selTimer = new Timer();
            selTimer.Interval = 30;
            selTimer.Elapsed += selTimer_Tick;
            selTimer.Start();
        }

        private void selTimer_Tick(object sender, ElapsedEventArgs e) //if the selection didn't change, this function is called. We use the current selection to update the video's position.
        {
            //error, when clicking into frame window for the first time, how exactly? selTimer is null.
            if (selTimer != null)
            {
                selTimer.Stop();
                selTimer = null;
            }
            //selTimer.Stop();
            //selTimer = null;
            this.Dispatcher.Invoke(() =>
            {
                if (FocusManager.GetFocusedElement(this) != null) //like when clicking on the scrollbar, when the window opens
                {
                    FramesText_SelectionChanged(null, null);
                }
            });
        }

        private void FramesText_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            if (parentWindow.videoLoaded)
            {
                Debug.Print("FramesText_SelectionChanged---" + IndexToOrig(fileName) + "---" + parentWindow.videoSource);
                /*Debug.Print(selStw.ElapsedMilliseconds.ToString());
                selStw.Stop();*/
                
                if (selTimer != null) //Cancels action from FramesText_PreviewMouseLeftButtonDown.
                {
                    selTimer.Stop();
                    selTimer = null;
                }

                this.Dispatcher.Invoke(() =>
                {
                    if (IndexToOrig(fileName) == parentWindow.videoSource)
                    {
                        string frame = ((ListViewItem)FramesText.SelectedItem).Content.ToString();
                        string[] arr = frame.Split(' ');
                        parentWindow.GetMiddleIndexPos(double.Parse(arr[0], CultureInfo.InvariantCulture));
                        parentWindow.TimelineSlider.Value = parentWindow.middleIndexPos;
                        parentWindow.MediaElement1.Position = TimeSpan.FromMilliseconds(parentWindow.middleIndexPos);

                        //since it is possible to add marker with comment field open by pressing M from the frame window, we also have to close it, if we select another frame.
                        //in the main window the PreviewMouseDown event would take care of it.
                        if (parentWindow.currentCommentPosIndex != -1)
                        {
                            parentWindow.CloseCommentPos();
                            parentWindow.currentCommentPosIndex = -1;
                        }
                    }
                });
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Up && e.Key != Key.Down && e.Key != Key.PageUp && e.Key != Key.PageDown) //these keys are used to navigate the list, but in the main window they are stepping keyframe
            {
                parentWindow.MainWindow1_PreviewKeyDown(sender, e);
            }            
        }


        private string IndexToOrig(string fileName)
        {
            string indexFileNameWoExt = System.IO.Path.GetFileNameWithoutExtension(fileName);
            //replaces all occurrences of FileNameSeparator
            //string selectedFile = indexFileNameWoExt.Replace(parentWindow.settings["FileNameSeparator"], @"\") + ".mp4";
            //replaces only the first occurrence
            var regex = new Regex(Regex.Escape(parentWindow.settings["FileNameSeparator"]));
            string selectedFile = regex.Replace(indexFileNameWoExt, @"\", 1) + ".mp4";

            return Directory.GetFiles(skillsPath, selectedFile).FirstOrDefault(); //Gets the case-sensitive file name.
        }

        private string[] IndexToOrigWoRoot(string fileName)
        {
            string indexFileNameWoExt = System.IO.Path.GetFileNameWithoutExtension(fileName);
            //replaces all occurrences of FileNameSeparator
            //string selectedFile = indexFileNameWoExt.Replace(parentWindow.settings["FileNameSeparator"], @"\") + ".mp4";
            //replaces only the first occurrence
            var regex = new Regex(Regex.Escape(parentWindow.settings["FileNameSeparator"]));
            string selectedFile = regex.Replace(indexFileNameWoExt, @"\", 1) + ".mp4";

            string videoFile = Directory.GetFiles(skillsPath, selectedFile).FirstOrDefault();
            videoFile = videoFile.Replace(skillsPath, "");
            if (videoFile.IndexOf("\\") != -1)
            {
                return videoFile.Split('\\');
            }
            else
            {
                return new string[]{".",videoFile};
            }
            
        }
    }
}
