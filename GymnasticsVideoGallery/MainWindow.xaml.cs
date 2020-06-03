using System;
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
using System.Windows.Forms;
using System.Diagnostics;

using System.Windows.Controls.Primitives;
using System.Windows.Threading;
//using Microsoft.WindowsAPICodePack.Shell;
//using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
//using Microsoft.Win32;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using System.ComponentModel;

using System.Windows.Markup;
using System.Threading;
using System.Collections.ObjectModel;
using System.Drawing.Drawing2D;

namespace GymnasticsVideoGallery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

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
        public bool sliderDragging=false;
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

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string rootDir = AppDomain.CurrentDomain.BaseDirectory;
        private string resourceDir = AppDomain.CurrentDomain.BaseDirectory + @"resources\";

        private bool isPlaying = false;
        public bool videoLoaded = false;
        private bool userIsDraggingSlider = false;
        private Stopwatch stw;
        private bool enteringFullscreen = false; //the mousemove listener is called, when we enter full screen, which would make the cursor appear.
        public bool isVideoFullscreen = false;
        public bool isPictureFullscreen = false;
        private bool pictureExiting = false;

        private int videoDuration = 0;
        private string videoFrameRateMode;
        private double videoFrameRate = 0;
        private double videoFrameLength = 0;

        private int currentFrameIndex; //index of the currently shown frame in frameIndex, calculated first when pressing space to pause the video.
        private double currentFrameIndexPos;
        private double secondcurrentFrameIndexPos;
        public double middleIndexPos; //this is the value we set at frame stepping

        private int currentPicIndex = -1; //used when showing pictures.
        private List<int> selectedPicIndexes = new List<int>(); //multiselection
        private int currentPicIndexExt = -1; //used when opening a file by association with the programm
        private List<string> filesExt; //list of files in external directory

        //private int currentMillis = 0; //rounded value

        //private int currentFrameMillis = 0; //used when analyzing the video
        //private int analyzeTo = 0;
        //private List<int> frames = new List<int>();
        //private string picstr;
        private DispatcherTimer sliderTimer;
        //private DispatcherTimer analtimer;

        public Dictionary<string, dynamic> settings;
        private Thread threadThumb;
        private Thread threadExt;

        private bool cutSelectionSet;
        private double cutStart;
        private double cutEnd;
        private double cutStartOffset;
        private double cutEndOffset;
        private double cutStartActual; //the base keyframe of cutStartOffset
        private double cutStartActualOffset; //the cutStartOffset that cutStartActual is based on. Preserving this value make it unecessary to query the keyframe if we move the selection a little to the left.

        private List<string> displayedThumbs = new List<string>();

        private int currentThumbIndex = -1; //used for showing floating filename labels, as opposed to currentPicIndex, which is for selection rectangle.
        private List<dynamic> hitList = new List<dynamic>();

        // We need this so that DataBindings are refreshed
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string strPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(strPropertyName));
        }
        #endregion

        public int thumbW
        {
            get { return settings["ThumbW"]; }
            set
            {
                //we save the setting separately, where it is needed.
                this.OnPropertyChanged("thumbW");
            }
        }

        public int thumbH
        {
            get { return settings["ThumbH"]; }
            set
            {
                //we save the setting separately, where it is needed.
                this.OnPropertyChanged("thumbH");
            }
        }

        private int contextItemIndex = -1;
        private int infoContextItemIndex = -1;

        //private bool threadAborted = false;
        private DispatcherTimer listTimer;

        private bool StartMarkerPressed = false;
        private bool EndMarkerPressed = false;
        private int markerCursorStartX;
        private double markerMargin;

        private bool videoContextOpen;

        public string videoSource; //when the frames window is open, we need to compare the source of the current video to that of the frames.
        
        private string extVideoSource; //allows us to watch anoter video while frames are being extracted.
        private int extVideoDuration;
        private string extractFramesOutput;
        private List<double> keyFrames;
        private List<double> frameIndex;
        private List<double> extKeyFrames;
        private List<double> extFrameIndex;

        private Window1 frameWindow;
        //private bool isCursorVisible = true; //there is no way to determine if the cursor is visible, and if we call the hide() function a certain amount of times, the same amount of times we need to call show() to make the cursor visible. (and vice-versa)

        private bool closeMouseIn;
        private bool thumbsMouseEnabledThumb = true; //used when renaming files. Field closes, when we click outside
        private bool thumbsMouseEnabledList = true; //used when renaming directories. Field closes, when we click outside.
        private int renameContextItemIndex = -1;

        private double availWidth; //available width for the thumbnail pictures (takes the existence of a scrollbar into account)
        private bool changedByProgramThumbs; //used when the thumbs are being created
        private bool changedByProgramList; //used when setting the list source
        private bool changedByProgramInit; //Used on startup. Affects list width and window layout, and prevent saving speed ratio and volume.
        private bool changedByProgramWindow; //used when resizing/positioning window
        private bool changedByProgramSettings; //Used on opening the settings page. Prevents registering settings and disabling/enabling window layout controls.

        private int _windowWidth = (int)SystemParameters.WorkArea.Width; //1920
        private int _windowHeight = (int)SystemParameters.WorkArea.Height; //1040

        private DispatcherTimer cutTimer;
        private bool cutSaveCalled; //used, when the actual start is not yet extracted, and we are cutting the video.
        private List<double> commentPositions;
        private List<string> commentPositionComments;
        public int currentCommentPosIndex = -1; //set when we set a marker; when we click on one; when we right-click on one. Removed on removing of a marker; on exitview and Loadcontent.

        public int windowWidth
        {
            get { return _windowWidth; }
            set
            {
                _windowWidth = value;
                this.OnPropertyChanged("windowWidth");
            }
        }

        public int windowHeight
        {
            get { return _windowHeight; }
            set
            {
                _windowHeight = value;
                this.OnPropertyChanged("windowHeight");
            }
        }

        private bool dialogActivation; //used to prevent updating thumbs on window activation. (On setting page. When cutting video, we make use of it.)
        private bool videoControlGridIsVisible; //used to prevent the controls from autohiding, when settig marker. That menuitem is high enough, so the program would hide the controlgrid.
        private bool addFramesLater; //for external files, comments have to be added when the media opens, otherwise timelineslider's width has a value of 0.

        private bool tbOpening; //we open the comment textbox for editing by pressing enter, but it will be saved too in the same event
        //ObservableCollection<string> SkillsListSource;
        List<string> SkillsListSource;

        #region Initializing

        public MainWindow()
        {
            try
            {
                changedByProgramInit = true; //will prevent the window layout and list width from being updated into settings. Also speed ratio and volume.
                InitializeComponent();

                FileOpen.Source = new BitmapImage(new Uri(resourceDir + "openfile.png", UriKind.Absolute));
                ActionsOpen.Source = new BitmapImage(new Uri(resourceDir + "actions.png", UriKind.Absolute));
                SettingsOpen.Source = new BitmapImage(new Uri(resourceDir + "settings.png", UriKind.Absolute));
                CloseButton.Source = new BitmapImage(new Uri(resourceDir + "close_big.png", UriKind.Absolute)); //relative source is not working                

                ReadSettings();

                SetWindowPosSize(); //important to set the size in all cases, otherwise starting from a maximized window, if we click normal size, we get a small window.

                if (settings["StartFullScreen"])
                {
                    EnterFullScreen(false);
                }
                else
                {
                    if (settings["StartMaximized"])
                    {
                        this.WindowState = WindowState.Maximized;
                    }
                    else //normal window
                    {
                        this.WindowStartupLocation = settings["WindowStartupLocationCenterScreen"] ? WindowStartupLocation.CenterScreen : WindowStartupLocation.Manual;
                    }
                }

                MainGrid.ColumnDefinitions[0].Width = new GridLength(settings["SkillsListWidth"]);

                //After settings the ThumbSizeSlider's value, now we can add event handler for valuechanging.            

                this.DataContext = this; //for data binding

                LoadToolbarSettings();

                //Unosquare.FFME.MediaElement.FFmpegDirectory = @"c:\Users\fodor\ffmpeg\";

                //Clicking on the slider, and moving the thumb while the mouse button is down
                /*TimelineSlider.ApplyTemplate();
                Thumb thumb = (TimelineSlider.Template.FindName("PART_Track", TimelineSlider) as Track).Thumb;
                Track track = TimelineSlider.Template.FindName("PART_Track", TimelineSlider) as Track;
                thumb.MouseEnter += new System.Windows.Input.MouseEventHandler(thumb_MouseEnter);*/
                //Debug.Print(track.ToString());
                //track.MouseLeftButtonDown += track_MouseLeftButtonDown;
                //track.MouseDown += track_MouseDown;                     

                //Stopwatch s = Stopwatch.StartNew();

                if (!Directory.Exists(settings["SkillsPath"]))
                {
                    DefaultPage.Visibility = Visibility.Visible;
                    SkillsListSource = new List<string>(); //so generate all thumbnails doesn't return an error.
                }
                else
                {
                    LoadDirList();
                }

                //ToolTipService.SetInitialShowDelay(ButtonLock, 1000);

                if (settings["SliderIsLocked"])
                {
                    PictureButtonLock.Source = ButtonLock.Source = new BitmapImage(new Uri(resourceDir + "visible.png", UriKind.Absolute));
                    PictureButtonLock.ToolTip = ButtonLock.ToolTip = "Controls visible";
                }
                else
                {
                    PictureButtonLock.Source = ButtonLock.Source = new BitmapImage(new Uri(resourceDir + "invisible.png", UriKind.Absolute));
                    PictureButtonLock.ToolTip = ButtonLock.ToolTip = "Controls hide";
                }
                if (settings["CommentsLocked"])
                {
                    ButtonComment.Source = new BitmapImage(new Uri(resourceDir + "comment.png", UriKind.Absolute));
                    ButtonComment.ToolTip = "Comments visible";
                }
                else
                {
                    ButtonComment.Source = new BitmapImage(new Uri(resourceDir + "nocomment.png", UriKind.Absolute));
                    ButtonComment.ToolTip = "Comments hide";
                }

                PictureButtonPrevious.Source = ButtonPrevious.Source = new BitmapImage(new Uri(resourceDir + "previous.png", UriKind.Absolute));
                ButtonPlayPause.Source = new BitmapImage(new Uri(resourceDir + "play.png", UriKind.Absolute));
                PictureButtonNext.Source = ButtonNext.Source = new BitmapImage(new Uri(resourceDir + "next.png", UriKind.Absolute));
                ActualSize.Source= new BitmapImage(new Uri(resourceDir + "actualsize.png", UriKind.Absolute));

                //Msgbox(s.ElapsedMilliseconds);//30 ms
                //s.Stop();
                string[] args = Environment.GetCommandLineArgs();
                if (args.Length == 2)
                {
                    string ext = System.IO.Path.GetExtension(args[1]).ToLower();
                    if (ext == ".mp4")
                    {
                        GetFilesExternal(args[1]);
                        currentCommentPosIndex = -1;
                        LoadVideo(args[1]);
                        dialogActivation = true;
                        //Msgbox(rootDir);
                        dialogActivation = false;
                    }
                    else if (ext == ".jpg" || ext == ".png")
                    {
                        GetFilesExternal(args[1]);
                        LoadPicture(args[1]);
                    }
                    else
                    {
                        Msgbox("This file type is not supported.");
                    }
                }
                Debug.Print("Initialize end");
            }
            catch (Exception e) //settings.ini does not exist
            {
                Msgbox(e.Message + " " + e.StackTrace);
            }
        }

        private void ReadSettings()
        {
            try
            {
                settings = new Dictionary<string, dynamic>();
                string[] settingsFile = File.ReadAllLines(resourceDir + "settings.ini");
                foreach (string l in settingsFile)
                {

                    if (l.Length > 0 && l[0] != '\'') //comments
                    {
                        if (l.IndexOf("=") != -1)
                        {
                            Regex regex = new Regex(@"\s+"); //remove multiple spaces, which can be a problem between type and key
                            string line = regex.Replace(l, " ");

                            string[] arr = line.Split('=');
                            string[] arr2 = arr[0].Trim().Split(' ');
                            //Debug.Print("---" + arr[0] + "---" + arr[1].Trim() + "---" + arr2[0] + "---" + arr2[1] + "---");
                            switch (arr2[0])
                            {
                                case "bool":
                                    settings[arr2[1]] = bool.Parse(arr[1].Trim());
                                    break;
                                case "string":
                                    settings[arr2[1]] = arr[1].Trim();
                                    break;
                                case "double":
                                    settings[arr2[1]] = double.Parse(arr[1].Trim(),CultureInfo.InvariantCulture);
                                    break;
                                case "int":
                                    settings[arr2[1]] = int.Parse(arr[1].Trim());
                                    break;
                                default:
                                    Msgbox("Error in settings.ini: Type not recognized." + Environment.NewLine + l);
                                    System.Environment.Exit(0);
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                Msgbox("Format error in settings.ini.");
                System.Environment.Exit(0);
            }
        }
        
        //saves all settings from the memory, not just the key and value.
        private void SaveSetting(string key, dynamic value) //ShowAllFilenames gets checked after window loading, or checkbox loading. Currently there is no way to prevent updating the settings, unless I use a timer.
        {
            Debug.Print("savesetting " + key + " = " + ((object)value).ToString());
            settings[key] = value;
            SaveSettings();
            
        }

        private void SaveSettings() //where multipe settings are updated at a time, this function should be called after updating the memory.
        {
            string[] settingsFile = File.ReadAllLines(resourceDir + "settings.ini");
            for (int i = 0; i < settingsFile.Length; i++)
            {
                string l = settingsFile[i];

                if (l.Length > 0 && l[0] != '\'') //comments
                {
                    if (l.IndexOf("=") != -1)
                    {
                        Regex regex = new Regex(@"\s+"); //remove multiple spaces, which can be a problem between type and key
                        string line = regex.Replace(l, " ");

                        string[] arr = line.Split('='); //reconstructing the line, keeping only the type and key, and reading the value from the runtime array.
                                                        //all lines will be formatted, not just the current key.
                        string[] arr2 = arr[0].Trim().Split(' '); //there must be only one space between type and key
                        settingsFile[i] = arr2[0] + " " + arr2[1] + " = " + settings[arr2[1]].ToString(CultureInfo.InvariantCulture);
                    }
                }
            }
            File.WriteAllLines(resourceDir + "settings.ini", settingsFile);
        }

        private void GetFilesExternal(string fileName)
        {
            BorderRect.Visibility = Visibility.Hidden;
            currentPicIndex = -1;
            selectedPicIndexes.Clear();
            DrawMultiSelection();
            string[] arr = Directory.GetFiles(System.IO.Path.GetDirectoryName(fileName));
            filesExt = new List<string>();
            int index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                string ext = System.IO.Path.GetExtension(arr[i]).ToLower();
                if (ext == ".jpg" || ext == ".png" || ext == ".mp4")
                {
                    filesExt.Add(arr[i]);
                    if (arr[i].ToLower() == fileName.ToLower())
                    {
                        currentPicIndexExt = index;
                    }
                    index++;
                }
            }
        }

        private void LoadDirList()
        {
            try
            {
                string[] contents = Directory.GetDirectories(settings["SkillsPath"]);
                //System.Windows.MessageBox.Show(Convert.ToString(contents.Length));
                //SkillsListSource = new ObservableCollection<string>(); //for an updateable list
                SkillsListSource = new List<string>();
                SkillsListSource.Add(".");
                foreach (string dirName in contents)
                {
                    SkillsListSource.Add(System.IO.Path.GetFileName(dirName));
                }
                SkillsListSource.Sort(); //Names are not sorted, maybe are in creation order?
                changedByProgramList = true;
                SkillsList.ItemsSource = SkillsListSource; //when changing root directory, the current selection is removed, and fires the change event, but the selecteditem is null.
                changedByProgramList = false;

                Debug.Print("LoadDirList, SkillsList.SelectedItem ---" + SkillsList.SelectedItem + "--- settings[selectedskill] ---" + (string)settings["SelectedSkill"] + "---");
                if (settings["SelectedSkill"].Trim() != "")
                { //check: if it exists.
                    SkillsList.SelectedItem = settings["SelectedSkill"];
                }
                else
                {
                    SkillsList.SelectedItem = "."; //will be saved in the change event
                }
            }
            catch (DirectoryNotFoundException) { //can be an issue, when we set the directory on the settings page.
                Msgbox("The selected directory was not found.");
            }
        }

        private void ChooseStartDir_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog obj = new FolderBrowserDialog();
            obj.Description = "Select the directory, which contains your subfolders.";
            obj.ShowDialog();
            if (obj.SelectedPath != "")
            {
                SaveSetting("SkillsPath", obj.SelectedPath + "\\");
                SaveSetting("SelectedSkill", ".");
                DefaultPage.Visibility = Visibility.Collapsed;
                LoadDirList(); //when setting the list, selection goes to the first item, . by default. We set the same selection again, ergo selection doesn't change to invoke thumbnail refresh.
                StartUpdateThumbs();
            }
        }

        private void LoadToolbarSettings()
        {
            SortBy.Text = settings["SortBy"];
            SortOrder.Text = settings["SortOrder"];
            ThumbSizeSlider.ValueChanged += ThumbSizeSlider_ValueChanged;
            DrawThumbSizeSliderTicks();
            //Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle); //does not help, now value get 0 instead of 10.
            ThumbSizeLabel.Text = settings["ThumbW"] + " x " + settings["ThumbH"];
            ShowAllFilenames.IsChecked = settings["ShowFileNames"];
        }

        private void DrawThumbSizeSliderTicks() //tickbar would not show, but because it has the same color as the background. These custom tickbars are the same, only there is sometimes 1 px difference.
        {
            for (double i = 0; i <= 9; i++)
            {
                double pos = i / 9 * ThumbSizeSliderCanvas.Width;
                Rectangle r = new Rectangle();
                r.Fill = Brushes.Black;
                r.Width = 1;
                r.Height = 4;
                r.Margin = new Thickness(pos - 0.5, 5, 0, 0);
                r.SnapsToDevicePixels = true;
                ThumbSizeSliderCanvas.Children.Add(r);
            }
        }

        #endregion

        #region Thumbs event handlers

        private void Thumbs_MouseMove(object sender, System.Windows.Input.MouseEventArgs e) //when co_ntext menu is open, it does not register. This is how it should be.
        {
            if (thumbsMouseEnabledThumb && thumbsMouseEnabledList)
            {
                //if we are over an empty area, it does not register.
                //Debug.Print("mousemove "+ contextItemIndex + " " + FileInfoGrid.Visibility.ToString());
                if (contextItemIndex == -1) //when the menu is open, no mousemove registers, but we need to prevent that we click the bottom of an image, the menu opens, we select show info, and the picture below will show its filename without moving the mouse.
                {
                    //Debug.Print("Thumbs_MouseMove sender: " + sender + ", e.Source: " + e.Source);
                    var obj = (e.Source != null) ? e.Source : sender; //the latter case occurs, when we got here from the finish of UpdateThumbs.
                    //if (!(e.Source is Border)) //can be Image, or nothing when we activate the window.
                    if (obj is Image)
                    {
                        if (currentThumbIndex != -2) //after drag to other folder, Thumbs_MouseMove is called, and e.Source is still the image that was just removed.
                                                     //thumbIndex is -1, but do not change, when we copied the file. CurrentThumbIndex will be changed now.
                        {
                            Image im = (Image)obj;
                            Border b = (Border)im.Parent;
                            int thumbIndex = Thumbs.Children.IndexOf(b);
                            FileNameGrid.Visibility = Visibility.Visible; 
                            PositionLabel(thumbIndex, im.Source.ToString());
                            CommentGrid.Margin = new Thickness(e.GetPosition(ThumbScroll).X + 10, e.GetPosition(ThumbScroll).Y + 10, 0, 0);
                        }
                        else
                        {
                            currentThumbIndex = -1;
                        }        
                    }
                    else if (obj is Border) //border
                    {
                        FileNameGrid.Visibility = Visibility.Hidden;
                        CommentGrid.Visibility = Visibility.Hidden;
                    }
                    else //window activation, make no change.
                    {
                    }
                }
            }
        }

        private void Thumbs_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (thumbsMouseEnabledThumb && thumbsMouseEnabledList)
            {
                if (contextItemIndex == -1) //mouse leave event can be triggered by opening the context menu. By this time, contextItemIndex is already set.
                {
                    FileNameGrid.Visibility = Visibility.Hidden;
                    CommentGrid.Visibility = Visibility.Hidden;
                    currentThumbIndex = -1;
                }
            }
        }

        private void ThumbScroll_GotFocus(object sender, RoutedEventArgs e)
        {
            Debug.Print("ThumbScroll_GotFocus");
            if (Mouse.LeftButton == MouseButtonState.Pressed || Keyboard.IsKeyDown(Key.D1) || Keyboard.IsKeyDown(Key.D2) || Keyboard.IsKeyDown(Key.D3)
                 || Keyboard.IsKeyDown(Key.D4) || Keyboard.IsKeyDown(Key.D5) || Keyboard.IsKeyDown(Key.D6) || Keyboard.IsKeyDown(Key.D7) || Keyboard.IsKeyDown(Key.D8)
                  || Keyboard.IsKeyDown(Key.D9))
            {
                //no action, selection will happen.
            }
            else if (Keyboard.IsKeyDown(Key.Tab)) //only tab is dealt with
            {
                Debug.Print("ThumbScroll_GotFocus");
                SelectFirstThumb();
            }
        }

        private void SelectFirstThumb()
        {
            if (Thumbs.Children.Count > 0)
            {
                BorderRect.Visibility = Visibility.Visible;
                if (currentPicIndex == -1) //no active selection existed before focus was removed from thumbscroll
                {
                    BorderRect.Stroke = Brushes.Lime;
                    if (selectedPicIndexes.Count == 0) //if there is no existing multiselection, put cursor to first item
                    {
                        currentPicIndex = 0;
                        selectedPicIndexes.Add(currentPicIndex);
                    }
                    else //cursor to first item in selection.
                    {
                        selectedPicIndexes.Sort();
                        currentPicIndex = selectedPicIndexes[0];
                    }
                    PositionBorderRect(currentPicIndex, true);
                }
                else //if thumbsizeslider value changes, we need to reposition the cursor.
                {
                    PositionBorderRect(currentPicIndex, true);
                }
            }
        }

        private void ThumbScroll_LostFocus(object sender, RoutedEventArgs e)
        {
            Debug.Print("ThumbScroll_LostFocus cancelThumbLosingFocus: " + cancelThumbLosingFocus);
            if (!cancelThumbLosingFocus)
            {
                Debug.Print("ThumbScroll_LostFocus 2");
                BorderRect.Visibility = Visibility.Hidden; //currentPicIndex remains.
            }            
        }

        private void ThumbScroll_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            //Debug.Print("scrollChanged " + BorderRect.Visibility);

            currentThumbIndex = -1; //to enforce refresh of the filename label. The mousemove event will be called now, hittest is not needed.

            if (BorderRect.Visibility == Visibility.Visible) // when the file info box is visible, or a thumb is selected (currentPicIndex != -1)
            {
                int index = (infoContextItemIndex != -1) ? infoContextItemIndex : currentPicIndex;
                PositionBorderRect(index,false);
            }
        }

        private void ThumbScroll_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) //makes it possible to move the selection rectangle with the keys
        {
            Debug.Print("ThumbScroll_PreviewMouseLeftButtonDown");
            if (windowActivatingTimer != null) //on window activation we do not change the selection.
            {
                return;
            }
            Point pt = e.GetPosition((UIElement)sender);
            HitTestResult result = VisualTreeHelper.HitTest((UIElement)sender, pt);
            if (result.VisualHit == ThumbScroll) //clicked on the gray area
            {
                if (!ThumbScroll.IsFocused || (selectedPicIndexes.Count == 0 && currentPicIndex == -1)) //this excludes a single red selection. 
                {
                    SelectFirstThumb(); //ThumbScroll_GotFocus will not call it, since the mouse button is pressed. So we call it here.
                }
                else
                {
                    //unselect all?
                    UnselectAll_Click(null, null);
                }
            }            
            ThumbScroll.Focus();               
        }

        private void ThumbScroll_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) //not getting called.
        {
            Debug.Print("ThumbScroll_MouseLeftButtonDown");
        }

        #endregion

        #region Thumbs functions

        private string updateThumbsDir;
        private string imageDownFileName; //only drag, if the image source while dragging is same as when the mouse button was pressed. 
                                          //Cases where it matters:
        //- Renaming file outside of program, and now clicking on that thumbnail to activate window. The image will be removed, and the next image gets under the mouse, which calls the mousemove event.
        //- Adding/deleting files before the current one
        
        private void ClearThumbs()
        {
            BorderRect.Visibility = Visibility.Hidden;
            currentPicIndex = -1;
            selectedPicIndexes.Clear();
            DrawMultiSelection();
            Thumbs.Children.RemoveRange(0, Thumbs.Children.Count); //it is faster than one by one in UpdateThumbs. 
            displayedThumbs.Clear();
            FileNameGridAllCanvas.Children.RemoveRange(0, FileNameGridAllCanvas.Children.Count);
        }

        public void StartUpdateThumbs()
        {
            try
            {
                Debug.Print("StartUpdateThumbs " + updateThumbsDir + " " + (string)settings["SelectedSkill"] + " " + threadThumb);
                if (threadThumb != null && threadThumb.IsAlive && updateThumbsDir != settings["SelectedSkill"]) //refresh is running. If a picture is being created, ffmpeg will finish it, it will not be aborted.
                {
                    //threadAborted = true;
                    threadThumb.Abort();
                }
                threadThumb = new System.Threading.Thread(new System.Threading.ThreadStart(() => UpdateThumbs()));
                threadThumb.Start();
            }
            catch (Exception e)
            {
                Debug.Print(e.Message + " " + e.StackTrace);
            }
        }

        private void UpdateThumbs() //runs when the window is activated; when the skill selection is changed (but not on startup), when we exit video or picture view.
        {
            try
            {
                //Debug.Print("UpdateThumbs dir path: " + (string)settings["SkillsPath"] + (string)settings["SelectedSkill"]);
                //Debug.Print(((bool)Directory.Exists(settings["SkillsPath"] + settings["SelectedSkill"])).ToString());
                if (!Directory.Exists(settings["SkillsPath"] + settings["SelectedSkill"]))
                {
                    return;
                }
                //Debug.Print("UpdateThumbs: skillpath: " + settings["SkillsPath"] + ", selectedskill: " + settings["SelectedSkill"]);
                //var watchUpdate = Stopwatch.StartNew();


                this.Dispatcher.Invoke(() =>
                {
                    StatusText.Text = "Updating thumbnails...";
                    StatusText.Visibility = Visibility.Visible;
                });

                updateThumbsDir = settings["SelectedSkill"];

                Debug.Print("UpdateThumbs dir path: " + (string)settings["SkillsPath"] + (string)settings["SelectedSkill"]);
                Debug.Print("Exists: " + (bool)Directory.Exists(settings["SkillsPath"] + settings["SelectedSkill"]));
                FileInfo[] files;
                DirectoryInfo info = new DirectoryInfo(settings["SkillsPath"] + settings["SelectedSkill"]);
                if (settings["SortBy"] == "Name")
                {
                    if (settings["SortOrder"] == "Ascending")
                    {
                        files = info.GetFiles().OrderBy(p => p.Name).ToArray();
                    }
                    else
                    {
                        files = info.GetFiles().OrderByDescending(p => p.Name).ToArray();
                    }
                }
                else
                {
                    if (settings["SortOrder"] == "Ascending")
                    {
                        files = info.GetFiles().OrderBy(p => p.LastWriteTime).ToArray();
                    }
                    else
                    {
                        files = info.GetFiles().OrderByDescending(p => p.LastWriteTime).ToArray();
                    }
                }

                //Debug.Print("selectedskill: " + settings["SelectedSkill"]);
                string baseDir = (settings["SelectedSkill"] == ".") ? settings["SkillsPath"] : settings["SkillsPath"] + settings["SelectedSkill"] + @"\";
                
                //Debug.Print("UpdateThumbs, basedir " + baseDir); //contains double \ at the end, if selectedskill is nothing.

                //displayedThumbs = new List<string> { "a", "c", "d", "e" };
                //contents = new string[] { "a", "b", "c", "e", "f" };

                //converting to thumbnail path
                List<string> contents = new List<string>();

                for (int i = 0; i < files.Length; i++)
                {
                    string ext = System.IO.Path.GetExtension(files[i].ToString()).ToLower();
                    if (ext == ".jpg" || ext == ".png" || ext == ".mp4")
                    {
                        contents.Add(OrigToThumb(baseDir + files[i]));
                    }
                }

                //removing elements
                int c = displayedThumbs.Count;
                for (int i = 0; i < c; i++)
                {
                    string pic = displayedThumbs[i];
                    if (contents.IndexOf(pic) == -1)
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            Thumbs.Children.RemoveAt(i);
                            FileNameGridAllCanvas.Children.RemoveAt(i);

                        });
                        if (selectedPicIndexes.IndexOf(i) != -1) //remove from selection
                        {
                            selectedPicIndexes.Remove(i);
                        }
                        for (int ix = 0; ix < selectedPicIndexes.Count; ix++) //step -1 every selected item that is greater than the deleted index
                        {
                            if (selectedPicIndexes[ix] > i)
                            {
                                selectedPicIndexes[ix]--;
                            }
                        }

                        Debug.Print("Removing elements currentPicIndex " + currentPicIndex + " i " + i);

                        if (currentPicIndex != -1) //it is to position borderRect right, when files are removed from the current directory. Color does not change.
                        {
                            if (i < currentPicIndex)
                            {
                                currentPicIndex--;
                                this.Dispatcher.Invoke(() =>
                                {
                                    PositionBorderRect(currentPicIndex, true);
                                });
                            }
                            else if (i == currentPicIndex)
                            {
                                this.Dispatcher.Invoke(() =>
                                {
                                    BorderRect.Visibility = Visibility.Hidden;
                                });
                                currentPicIndex = -1;
                            }
                        }

                        displayedThumbs.RemoveAt(i);
                        c = displayedThumbs.Count;
                        i--;
                    }
                }

                //adding elements
                for (int i = 0; i < contents.Count; i++)
                {
                    string targetFile = contents[i];
                    if (displayedThumbs.IndexOf(targetFile) == -1) //not yet exist
                    {
                        //Debug.Print("Adding new thumb: " + targetFile);
                        //if the orig file is newer than the thumb, we create new thumb.
                        FileInfo fileInfoThumb = new FileInfo(targetFile);
                        string origFile = ThumbToOrig(targetFile);
                        FileInfo fileInfoOrig = new FileInfo(origFile);

                        //Debug.Print(fileInfoThumb.LastWriteTime + " " + fileInfoOrig.LastWriteTime);
                        if (fileInfoOrig.LastWriteTime > fileInfoThumb.LastWriteTime && fileInfoThumb.LastWriteTime.ToString() != "01/01/1601 01.00.00")
                        {
                            Debug.Print("orig file is newer, orig: " + fileInfoOrig.LastWriteTime + " thumb: " + fileInfoThumb.LastWriteTime);
                            if (File.Exists(targetFile))
                            {
                                File.Delete(targetFile);
                            }
                        }

                        if (!File.Exists(targetFile)) //can only be video. We need to extract a frame from the middle.
                        {
                            if (System.IO.Path.GetExtension(origFile).ToLower() == ".mp4")
                            {
                                var watch = Stopwatch.StartNew();
                                //Debug.Print("Getting media info" + targetFile + "---" + sourceFile);
                                string[] arr = GetMediaInfo(origFile, "Video;%Duration%");
                                double middle = int.Parse(arr[0]) / 2;
                                //Debug.Print("Updatethumbs middle calculated: ");
                                watch.Stop();
                                var elapsedMs = watch.ElapsedMilliseconds;

                                watch.Restart();
                                GetStillImage(origFile, middle, targetFile);
                                //Debug.Print("Got image: ");
                                watch.Stop();
                                elapsedMs = watch.ElapsedMilliseconds;
                            }
                            else {
                                Imager.PerformImageResizeAndPutOnCanvas(origFile, settings["ThumbW"], settings["ThumbH"], targetFile);
                            }

                            CreateThumb(targetFile, i);
                        }
                        else //picture or video, image exists
                        {
                            CreateThumb(targetFile, i);
                        }
                        //Debug.Print("Updatethumbs, adding thumbs, i " + i + " currentPicIndex " + currentPicIndex);
                        if (currentPicIndex != -1 && i <= currentPicIndex) //it is to position borderRect right, when files are added to the current directory. 
                        {
                            currentPicIndex++; // 0 1 (2) 3 4, add 2 3, currentPicIndex => 4 
                            this.Dispatcher.Invoke(() =>
                            {
                                PositionBorderRect(currentPicIndex,true);
                            });
                        } 
                    }
                }

                this.Dispatcher.Invoke(() =>
                {
                    StatusText.Visibility = Visibility.Hidden;
                    //needed, when we activate the window, and the thumbnails are being refreshed under the mouse.
                    
                    if (currentThumbIndex != -1) //if the mouse is currently over a picture.
                    {
                        Debug.Print("Updatethumbs refreshes filename label currentThumbIndex " + currentThumbIndex);
                        int oldCurrentThubmIndex = currentThumbIndex;
                        currentThumbIndex = -1; //so the filename label appears correct under the mouse, if pictures were added outside program 
                        Thumbs_MouseMove(((Border)Thumbs.Children[oldCurrentThubmIndex]).Child, new System.Windows.Input.MouseEventArgs(Mouse.PrimaryDevice, 0));
                    }
                    
                    
                    ShowAllFilenames_Checked(null, null); //for startup, to show all filenames or not.

                    changedByProgramThumbs = true;
                    ThumbSizeSlider.Value = (int)(availWidth / (thumbW + 1)); //the scrollbar visibility could have changed depending on how many pictures were loaded. Important for positioning filename label correctly.
                    changedByProgramThumbs = false;
                    savingCutVideo = false;                    
                });

                //watchUpdate.Stop();
                //var elapsedMsUpdate = watchUpdate.ElapsedMilliseconds;
                //Msgbox(elapsedMsUpdate);
                //PrintArray(displayedThumbs.ToArray());
                /*this.Dispatcher.Invoke(() => //mousemove event is triggered, when we exit big view
                {
                    RefreshLabel();
                });*/
            }
            catch (Exception e) //if the program was closed while a picture was being generated, or the thread was aborted.
            {
                Debug.Print(e.Message + " " + e.StackTrace);//Exception thrown: 'System.FormatException' in mscorlib.dll
            }
        }

        private void CreateThumb(string src, int index)
        {
            //Console.WriteLine("CreateThumb src " + src + " index " + index);
            this.Dispatcher.Invoke(() =>
            {
                try
                {
                    BitmapImage imageBitmap = new BitmapImage();
                    imageBitmap.BeginInit();
                    imageBitmap.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                    imageBitmap.CacheOption = BitmapCacheOption.OnLoad;//makes it possible to delete the image, otherwise it will be locked. If I set it to OnLoad however, the image will not refresh when the thumbnail image file refreshes.
                    imageBitmap.UriSource = new Uri(src, UriKind.Absolute);
                    imageBitmap.EndInit();

                    var im = new Image();
                    im.Width = thumbW;
                    im.Height = thumbH;

                    im.Source = imageBitmap;
                    im.MouseLeftButtonDown += Im_MouseLeftButtonDown;
                    im.MouseLeftButtonUp += Im_MouseLeftButtonUp;                    
                    im.MouseMove += Im_MouseMove;
                    //im.Margin = new Thickness(1);

                    var b = new Border();
                    b.BorderThickness = new Thickness(0, 0, 1, 1);
                    b.BorderBrush = Brushes.LightGray;
                    b.Child = im;

                    //for the allfilename label and selection rectangle, image size used for positioning 
                    Grid g = new Grid();
                    g.Width = thumbW + 1;
                    g.Height = thumbH + 1;

                    //bottom grid
                    Grid g1 = new Grid();
                    SolidColorBrush br = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
                    br.Opacity = 0.9;
                    g1.Background = br;
                    g1.Height = FileNameGrid.Height;
                    g1.VerticalAlignment = VerticalAlignment.Bottom;
                    g1.Margin = new Thickness(0, 0, 1, 1);
                    g1.Visibility = (bool)ShowAllFilenames.IsChecked ? Visibility.Visible : Visibility.Hidden;
                    g.Children.Add(g1);

                    //filename
                    TextBlock t = new TextBlock();
                    t.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                    t.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                    t.Text = System.IO.Path.GetFileName(ThumbToOrig(src));
                    g1.Children.Add(t);

                    //multiselection rectangle
                    Rectangle r = new Rectangle();
                    r.Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00C000")); //lime is 00FF00
                    r.StrokeThickness = 3;
                    r.Margin = new Thickness(0, 0, 1, 1);
                    r.Visibility = Visibility.Hidden;
                    r.IsHitTestVisible = false;
                    g.Children.Add(r);

                    if (IsThumbVideo(src))
                    {
                        //frame index check mark
                        Image cm = new Image();
                        cm.Width = 23;
                        cm.Height = 18;
                        cm.Source = new BitmapImage(new Uri(resourceDir + "checkmark_green.png", UriKind.Absolute));
                        cm.Visibility = (settings["ShowExtractStatus"] && File.Exists(OrigToIndex(ThumbToOrig(src)))) ? Visibility.Visible : Visibility.Hidden;
                        cm.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                        cm.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                        cm.Margin = new Thickness(0, 10, 10, 0);
                        
                        g.Children.Add(cm);
                    }

                    //Debug.Print("CreateThumb: index: " + index + ", displayedThumbs.Count: " + displayedThumbs.Count);                    

                    displayedThumbs.Insert(index, src);
                    Thumbs.Children.Insert(index, b);
                    FileNameGridAllCanvas.Children.Insert(index, g);
                    for (int ix = 0; ix < selectedPicIndexes.Count; ix++) //step +1 every selected item that is greater or equal than the added index
                    {
                        if (selectedPicIndexes[ix] >= index)
                        {
                            selectedPicIndexes[ix]++;
                        }
                    }
                }
                catch (Exception e) //if the program was closed while a picture was being generated, or the thread was aborted
                {
                    Debug.Print(e.Message + " " + e.StackTrace);
                }
            });
        }        

        private void Im_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //we don't set selection here, because this is where dragging takes place.
            Debug.Print("Im_MouseLeftButtonDown");
            Image i = (Image)sender;
            imageDownFileName = new Uri(i.Source.ToString()).LocalPath;
        }

        private void Im_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Debug.Print("Im_MouseLeftButtonUp");

            if (noContentLoad) return;
            //if (windowActivatingTimer != null || (threadThumb != null && threadThumb.IsAlive)) return; //for cases where a file is renamed outside of program.
            // when clicking on that file, it disappears, and the next file will be loaded.
            Image i = (Image)sender;
            int index = Thumbs.Children.IndexOf((Border)i.Parent);

            if (index == -1) return; //renaming dir outside of program, and activating the window by clicking on a thumbnail. sender image is already removed.

            //Debug.Print("Im_MouseLeftButtonUp " + selectedPicIndexes.Count + " " + currentPicIndex);
            if (selectedPicIndexes.Count > 1 || selectedPicIndexes.Count == 1 && currentPicIndex != selectedPicIndexes[0] || Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl) || Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
            {
                //if multiple items are selected, we only unselect other items, we do not load video. 
                //Also when one item is selected, and the cursor is red on another item.
                if (SelectMultiple(index))
                {
                    currentPicIndex = index;
                    PositionBorderRect(currentPicIndex, true);
                    BorderRect.Visibility = Visibility.Visible;
                }
            }
            else
            {
                SelectMultiple(index); //cannot return false now
                currentPicIndex = index;
                PositionBorderRect(currentPicIndex, true);
                BorderRect.Visibility = Visibility.Visible;

                LoadContent(((Border)Thumbs.Children[currentPicIndex]).Child, null);
            }
        }

        private void Im_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {            
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Image i = (Image)sender;
                //for cases where a file is renamed outside of program. We return to the program by clicking on that thumbnail,
                //but it is deleted soon, and selection goes to next thumbnail.
                //Also when adding / deleting files before the selected position.
                //if we release the button fast enough, we can skip this phase, and content loads.
                Debug.Print("Im_MouseMove imageDownFileName " + imageDownFileName + " imagesource " + new Uri(i.Source.ToString()).LocalPath);
                if (new Uri(i.Source.ToString()).LocalPath != imageDownFileName)
                {
                    noContentLoad = true;
                    return;
                }                
                skillsListItem = (string)SkillsList.SelectedItem;
                skillsListIndex = SkillsList.SelectedIndex; //same variable we use for the context menu. These 2 events cannot happen at the same time.
                MainWindow1.AllowDrop = false; //Needed to limit the drop area to SkillsList. MainWindow1_Drop will run anyway, because SkillsList is enabled.
                //string origFile = ThumbToOrig(((BitmapImage)im.Source).UriSource.LocalPath);
                
                if (selectedPicIndexes.Count <= 1) //if nothing or one is selected, the current image will be set selected
                {
                    if (selectedPicIndexes.Count == 1 && currentPicIndex != selectedPicIndexes[0])
                    {
                        //situation: one pic is selected, another is selected with red. We don't change selection.
                    }
                    else
                    {
                        int index = Thumbs.Children.IndexOf((Border)i.Parent);
                        selectedPicIndexes.Clear();
                        if (SelectMultiple(index)) //cannot return false now
                        {
                            currentPicIndex = index;
                            PositionBorderRect(currentPicIndex, true);
                            BorderRect.Visibility = Visibility.Visible;
                        }
                    }                    
                }
                string[] files = GetFilesFromSelection().ToArray();

                Debug.Print("DoDragDrop before, joined array " + String.Join(";", selectedPicIndexes));

                /*
                 Possible drag-drop situations:

                 - Drag from internal to list:
                    - drag start before
                    - drop
                    - drag start after
                 - Drag from internal to no action:
                    - drag start before
                    - drag start after
                - Drag from internal to external:
                    - drag start before
                    - drag start after
                - Drag from external to internal (what if something is selected?):
                    - drop

                Desired behavior:
                Selection, incl active selection remains while dragging and after dragging. Also when dragging from external to internal.
                Solution: Not changing focus, when we select another list item depending on mouse position.            
                 */

                DragDrop.DoDragDrop(i, new System.Windows.DataObject(System.Windows.DataFormats.FileDrop, files), System.Windows.DragDropEffects.Move | System.Windows.DragDropEffects.Copy);
                //code here runs after drag ended                

                Debug.Print("DoDragDrop after 1 currentPicIndex " + currentPicIndex + " BorderRect.Visibility " + BorderRect.Visibility + " joined array " + String.Join(";", selectedPicIndexes));
                
                foreach(string origFile in files)
                {
                    if (!File.Exists(origFile)) //if move happened, to external program. 
                    {
                        RemoveThumb(ThumbToOrig(origFile),false);
                    }
                }
                Debug.Print("DoDragDrop after 2 currentPicIndex " + currentPicIndex + " BorderRect.Visibility " + BorderRect.Visibility + " joined array " + String.Join(";", selectedPicIndexes));
                changedByProgramList = true;
                SkillsList.SelectedItem = settings["SelectedSkill"]; //restore selection
                changedByProgramList = false;

                //focus didn't change, no need to restore it. It would scroll the list, so the curently selected dir gets into view.
                
                currentThumbIndex = -2; //for the invisibility of the filename label
                FileNameGrid.Visibility = Visibility.Hidden;//label would normally hide, when mouse leaves the thumbnail area, but it doesn't register during drag & drop.
                CommentGrid.Visibility = Visibility.Hidden;
                MainWindow1.AllowDrop = true;
                Debug.Print("DoDragDrop after 3");
            }
        }

        private void PositionLabel(int thumbIndex, string imgSrc) //runs when the mouse moves over the thumbnails; when we scroll the window with the mouse wheel; when pictures are being updated (incl. when we press Esc); when we switch to this window.
        {
            //Debug.Print("PositionLabel, thumbindex " + thumbIndex + " currentthumbindex " + currentThumbIndex);
            if (currentThumbIndex != thumbIndex)
            {
                if ((bool)ShowAllFilenames.IsChecked) //hide filename and make background transparent. We need to keep only the rename field.
                {
                    FileNameGrid.Background = null;
                    FileNameLabelText.Visibility = Visibility.Hidden;
                }
                else
                {
                    SolidColorBrush br = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
                    br.Opacity = 0.9;
                    FileNameGrid.Background = br;
                    FileNameLabelText.Visibility = Visibility.Visible;
                }
                currentThumbIndex = thumbIndex;
                int thumbRow = (int)ThumbSizeSlider.Value; // equals Thumbs.ActualWidth / thumbW+1
                int coorY = (int)Math.Floor((double)(thumbIndex / thumbRow));
                int coorX = thumbIndex - thumbRow * coorY;
                FileNameGrid.Margin = new Thickness(coorX * (settings["ThumbW"] + 1), (coorY + 1) * (settings["ThumbH"] + 1) - FileNameGrid.ActualHeight - ThumbScroll.ContentVerticalOffset, 0, 0);

                string thumbFile = new Uri(imgSrc).LocalPath;
                FileNameLabelText.Text = ThumbToOrigFileName(thumbFile);
                string commentFile = ThumbToComment(thumbFile);
                if (settings["ShowThumbComments"] && File.Exists(commentFile))
                {
                    string t = "";
                    string[] comments = File.ReadAllLines(commentFile);
                    foreach (string line in comments)
                    {
                        string[] larr = line.Split('\t');
                        t += Convert.ToString(Math.Round(double.Parse(larr[0], CultureInfo.InvariantCulture)) / 1000, CultureInfo.InvariantCulture) + "\t" + larr[1] + "\n";
                    }
                    t = t.TrimEnd(new char[] { '\n' });
                    CommentLabelText.Text = t;
                    CommentGrid.Visibility = Visibility.Visible;
                }
                else
                {
                    CommentGrid.Visibility = Visibility.Hidden;
                }
            }
        }

        private void PositionBorderRect(int thumbIndex, bool scrollChangeable)
        {
            int thumbRow = (int)ThumbSizeSlider.Value;//Error, divising by zero when using: Math.Floor(Thumbs.ActualWidth / settings["ThumbW"]);
            int coorY = (int)Math.Floor((double)(thumbIndex / thumbRow));
            int coorX = thumbIndex - thumbRow * coorY;
            double marginY = coorY * (settings["ThumbH"] + 1) - ThumbScroll.ContentVerticalOffset;

            if (scrollChangeable) //otherwise we scrolled the page, and the rectangle is allowed to go out of view.
            {
                if (marginY + BorderRect.ActualHeight > ThumbScroll.ActualHeight) // rectangle goes to bottom, we need to scroll page
                {
                    ThumbScroll.ScrollToVerticalOffset(ThumbScroll.ContentVerticalOffset + marginY + BorderRect.ActualHeight - ThumbScroll.ActualHeight);
                    marginY = ThumbScroll.ActualHeight - BorderRect.ActualHeight;
                }
                else if (marginY < 0) //goes towards the top
                {
                    ThumbScroll.ScrollToVerticalOffset(ThumbScroll.ContentVerticalOffset + marginY);
                    marginY = 0;
                }
            }
            BorderRect.Margin = new Thickness(coorX * (settings["ThumbW"] + 1), marginY, 0, 0);
        }

        private void DrawMultiSelection()
        {
            for (int i=0; i < FileNameGridAllCanvas.Children.Count; i++)
            {
                ((Grid)FileNameGridAllCanvas.Children[i]).Children[1].Visibility = Visibility.Hidden;
            }

            foreach (int index in selectedPicIndexes)
            {
                Debug.Print("DrawMultiSelection index: " + index + " count: " + FileNameGridAllCanvas.Children.Count);
                ((Grid)FileNameGridAllCanvas.Children[index]).Children[1].Visibility = Visibility.Visible;
            }
        }

        private bool SelectMultiple(int newIndex) //returns false, if only deselection with Ctrl happened. currentPicIndex should not be set now.
        
            //set by the arrows, numbers, or mouse click
        {
            Debug.Print("SelectMultiple " + newIndex);
            if ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && !isVideoFullscreen && !isPictureFullscreen) //add new
            {
                //remove selection from current item, when using the arrows with the control, and the new item is selected.
                if ((Keyboard.IsKeyDown(Key.Left) || Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.Up) || Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.PageUp) || Keyboard.IsKeyDown(Key.PageDown))
                    && selectedPicIndexes.IndexOf(currentPicIndex) != -1 && selectedPicIndexes.IndexOf(newIndex) != -1)
                {
                    selectedPicIndexes.Remove(currentPicIndex);
                }
                else if (selectedPicIndexes.IndexOf(newIndex) == -1) //if new index is not yet added to the multiselection
                {
                    selectedPicIndexes.Add(newIndex);
                    BorderRect.Stroke = Brushes.Lime;
                }
                else //new index is in the multiselection. Numbers were pressed, or mouse click. 
                {
                    selectedPicIndexes.Remove(newIndex);
                    if (newIndex == currentPicIndex) //if it is the same as the cursor
                    {
                        if (selectedPicIndexes.Count > 0) //we mark cursor as "not selected" with red.
                        {
                            BorderRect.Stroke = Brushes.Red;
                        }
                        else //if this is the only selected item, we remove the cursor.
                        {
                            BorderRect.Visibility = Visibility.Hidden;
                            currentPicIndex = -1;                            
                        }
                    }
                    DrawMultiSelection();
                    return false;
                }
            }
            else if ((Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)) && !isVideoFullscreen && !isPictureFullscreen) //add range
            {
                if (currentPicIndex != -1) //if cursor is present, no matter if it is green or red
                {
                    //if everything is selected between the start and end positions (including ends), remove that selection excluding current. Otherwise select all.
                    if (newIndex > currentPicIndex)
                    {
                        bool allIsSelected = true;
                        for (int i = currentPicIndex; i <= newIndex; i++) //checking if all is selected in the range.
                        {
                            if (selectedPicIndexes.IndexOf(i) == -1)
                            {
                                allIsSelected = false;
                            }
                        }

                        if (allIsSelected) //remove all from selection, excluding new.
                        {
                            for (int i = currentPicIndex; i < newIndex; i++)
                            {
                                selectedPicIndexes.Remove(i);
                            }
                        }
                        else //add all to selection from start to end
                        {
                            for (int i = currentPicIndex; i <= newIndex; i++) //add all to selection
                            {
                                if (selectedPicIndexes.IndexOf(i) == -1)
                                {
                                    selectedPicIndexes.Add(i);
                                }
                                BorderRect.Stroke = Brushes.Lime;
                            }
                        }
                    }
                    else if (newIndex < currentPicIndex)
                    {
                        bool allIsSelected = true;
                        for (int i = currentPicIndex; i >= newIndex; i--) //checking if all is selected in the range.
                        {
                            if (selectedPicIndexes.IndexOf(i) == -1)
                            {
                                allIsSelected = false;
                            }
                        }

                        if (allIsSelected) //remove all from selection, excluding new.
                        {
                            for (int i = currentPicIndex; i > newIndex; i--)
                            {
                                selectedPicIndexes.Remove(i);
                            }
                        }
                        else //add all to selection from start to end
                        {
                            for (int i = currentPicIndex; i >= newIndex; i--) //add all to selection
                            {
                                if (selectedPicIndexes.IndexOf(i) == -1)
                                {
                                    selectedPicIndexes.Add(i);
                                }
                                BorderRect.Stroke = Brushes.Lime;
                            }
                        }
                    }
                }
                else
                {
                    if (selectedPicIndexes.IndexOf(newIndex) == -1)
                    {
                        selectedPicIndexes.Add(newIndex);
                        BorderRect.Stroke = Brushes.Lime;
                    }
                }
            }
            else //no modifier button
            {
                //when mulitple items are selected, navigating with the arrows should not erase the selection
                //also when the cursor is red, and there is 1 other item selected.
                if ((selectedPicIndexes.Count > 1 || selectedPicIndexes.Count == 1 && currentPicIndex != selectedPicIndexes[0]) && (Keyboard.IsKeyDown(Key.Left) || Keyboard.IsKeyDown(Key.Right) || Keyboard.IsKeyDown(Key.Up) || Keyboard.IsKeyDown(Key.Down) || Keyboard.IsKeyDown(Key.PageUp) || Keyboard.IsKeyDown(Key.PageDown))) {
                    
                    if (selectedPicIndexes.IndexOf(newIndex) == -1)
                    {
                        //cursor is now not part of selection
                        BorderRect.Stroke = Brushes.Red;
                    }
                    else
                    {
                        BorderRect.Stroke = Brushes.Lime;
                    }
                }
                else //mouse click, numbers or arrows while 0 is selected, or 1 is normally selected.
                {
                    selectedPicIndexes.Clear();
                    selectedPicIndexes.Add(newIndex);
                    BorderRect.Stroke = Brushes.Lime;
                }                
            }
            DrawMultiSelection();
            return true;
        }

        private List<string> GetFilesFromSelection()
        {
            //List<string> lThumb = new List<string>();
            List<string> lOrig = new List<string>();
            selectedPicIndexes.Sort();
            foreach (int index in selectedPicIndexes)
            {
                Border b = (Border)Thumbs.Children[index];
                Image im = (Image)b.Child;
                string fileName = new Uri(im.Source.ToString()).LocalPath;
                string origFile = ThumbToOrig(fileName);
                //lThumb.Add(fileName);
                lOrig.Add(origFile);
            }
            Debug.Print("GetFilesFromSelection " + String.Join(";",lOrig.ToArray()));
            return lOrig;
            //return new Array[] { lThumb.ToArray(), lOrig.ToArray()};
        }

        #endregion

        #region Thumbs context menu event handlers

        private bool cancelThumbLosingFocus = false; //to prevent borderrect to disappear, when we rename a file, or open settings

        private void Thumbs_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (pictureExiting)
            {
                pictureExiting = false;
                e.Handled = true;
                return;
            }
            if (e.Source is Image)
            {
                Image im = (Image)e.Source;
                Border b = (Border)im.Parent;
                contextItemIndex = Thumbs.Children.IndexOf(b);
                string thumbPath = new Uri(im.Source.ToString()).LocalPath;
                if (IsThumbVideo(thumbPath)) //video
                {
                    videoSource = ThumbToOrig(thumbPath);
                    string indexFile = thumbPath.Replace("Thumbnails", "Indexes").Replace(".jpg", ".txt");
                    if (!File.Exists(indexFile))
                    {
                        MenuItemExtract.Header = "Extract frames";
                    }
                    else
                    {
                        MenuItemExtract.Header = "Show frames";
                    }
                    MenuItemExtract.Visibility = Visibility.Visible;
                    MenuItemRestore.Visibility = Visibility.Visible;
                }
                else
                { //picture
                    MenuItemExtract.Visibility = Visibility.Collapsed;
                    MenuItemRestore.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Thumbs_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            contextItemIndex = -1;
        }

        private void Context_ShowInfo(object sender, RoutedEventArgs e)
        {
            try
            {
                Debug.Print("Context_ShowInfo");
                int index = (contextItemIndex != -1) ? contextItemIndex : currentPicIndex;
                string baseDir, fileName;
                Image im = null;
                if (index == -1) //for external files
                {
                    if (isPictureFullscreen)
                    {
                        im = ImageElement1;
                        fileName = new Uri(im.Source.ToString()).LocalPath;
                        baseDir = System.IO.Path.GetDirectoryName(fileName);
                    }
                    else
                    {
                        fileName = new Uri(MediaElement1.Source.ToString()).LocalPath;
                        baseDir = System.IO.Path.GetDirectoryName(fileName);
                    }
                }
                else
                {
                    Border b = (Border)Thumbs.Children[index];
                    im = (Image)b.Child;
                    fileName = new Uri(im.Source.ToString()).LocalPath;
                    baseDir = System.IO.Path.GetDirectoryName(fileName);
                }

                string t = "";
                if ((baseDir == rootDir + "Thumbnails") && IsThumbVideo(fileName) || isVideoFullscreen) //video internal or external
                {
                    if (baseDir == rootDir + "Thumbnails")
                    {
                        fileName = ThumbToOrig(fileName);//for external video, fileName is already the original
                    }
                    
                    t += "Video\n";
                    t += fileName + "\n\n";
                    string[] arr = GetMediaInfo(fileName, "Video;%Duration%,%FrameRate_Mode%,%FrameRate%,%FrameCount%,%Width%,%Height%");
                    t += "Duration: ";
                    double durs = double.Parse(arr[0]) / 1000;
                    if (durs >= 3600)
                    {
                        int hours = (int)(durs / 3600);
                        durs = durs - hours * 3600;
                        t += hours.ToString() + " h ";
                    }
                    if (durs >= 60)
                    {
                        int min = (int)(durs / 60);
                        durs = durs - min * 60;
                        t += min.ToString() + " m ";
                    }
                    if (durs >= 1)
                    {
                        int sec = (int)(durs);
                        durs = durs - sec;
                        t += sec.ToString() + " s ";
                    }
                    t += ((int)(durs * 1000)).ToString() + " ms\n";
                    t += "Resolution: " + arr[4] + " x " + arr[5] + "\n";
                    t += "Frame rate mode: " + ((arr[1] == "CFR") ? "Constant" : "Variable") + "\n";
                    t += "Frame rate: " + arr[2] + " fps\n";
                    t += "Frame count: " + arr[3] + " \n\n";
                    FileInfo fileInfo = new FileInfo(fileName);
                    double length = fileInfo.Length;
                    double lengthMB = length / 1024 / 1024;
                    t += "File size: " + lengthMB.ToString("0.#", CultureInfo.InvariantCulture) + " MB\n";
                    t += "Date modified: " + fileInfo.LastWriteTime;
                    //t += "Created: " + fileInfo.CreationTime + "\n";
                    //t += "Last accessed: " + fileInfo.LastAccessTime;
                }
                else //picture
                {
                    if (baseDir == rootDir + "Thumbnails")
                    {
                        fileName = ThumbToOrig(fileName);
                    }
                    Console.WriteLine("Showinfo: " + fileName);

                    t += "Picture\n";
                    t += fileName + "\n\n";
                    string[] arr = GetMediaInfo(fileName, "Image;%Width%,%Height%");
                    t += "Resolution: " + arr[0] + " x " + arr[1] + "\n\n";

                    FileInfo fileInfo = new FileInfo(fileName);
                    double length = fileInfo.Length;
                    double lengthMB = length / 1024 / 1024;
                    t += "File size: " + lengthMB.ToString("0.#", CultureInfo.InvariantCulture) + " MB\n";
                    t += "Date modified: " + fileInfo.LastWriteTime;
                }
                FileInfoText.Text = t;
                FileInfoGrid.Visibility = Visibility.Visible;
                PositionBorderRect(index, true);
                BorderRect.Visibility = Visibility.Visible;
                infoContextItemIndex = index; //used for scrolling, contextItemIndex is reset as the right-click menu closes.
            }
            catch (Exception ex)
            {
                FileInfoText.Text = ex.Message + " " + ex.StackTrace;
                FileInfoGrid.Visibility = Visibility.Visible;
            }
            
            
            //Debug.Print("show info");
            //Debug.Print(FileNameGrid.Margin.ToString());
            //Thumbs.SetValue(ScrollViewer.CanContentScrollProperty, false); //not working
            //ThumbScroll.CanContentScroll = false;
        }

        private void ExtractShow_Click(object sender, RoutedEventArgs e)
        {
            string indexFile = OrigToIndex(videoSource);
            if (File.Exists(indexFile)) //show frames
            {
                string[] arr = GetMediaInfo(videoSource, "Video;%Duration%,%FrameRate%");
                videoDuration = int.Parse(arr[0]);
                videoFrameRate = double.Parse(arr[1],CultureInfo.InvariantCulture);

                if (frameWindow != null)
                {
                    frameWindow.Close();
                }
                frameWindow = new Window1(indexFile, settings["SkillsPath"], videoDuration, videoFrameRate);
                frameWindow.Show();
            }
            else //extract frames
            {
                string[] arr = GetMediaInfo(videoSource, "Video;%Duration%");
                videoDuration = int.Parse(arr[0]);
                Extract_Click(null, null);
            }
        }

       private void Rename_Click(object sender, RoutedEventArgs e)
        {
            
            //handle clicking away events, like clicking on a video, and mouseover event too.
            renameContextItemIndex = (contextItemIndex != -1) ? contextItemIndex : currentPicIndex;
            Debug.Print(" Rename_Click index " + renameContextItemIndex);
            Border b = (Border)Thumbs.Children[renameContextItemIndex];
            Image im = (Image)b.Child;
            PositionLabel(renameContextItemIndex, im.Source.ToString()); //when pressing key to rename image, the mouse might be over another image

            thumbsMouseEnabledThumb = false;
            FileNameGrid.IsHitTestVisible = true;
            FileNameGrid.Visibility = Visibility.Visible;
            FileRenameText.Visibility = Visibility.Visible;            
            FileRenameText.Text = FileNameLabelText.Text;
            FileRenameText.CaretIndex = System.IO.Path.GetFileNameWithoutExtension(FileRenameText.Text).Length;//set cursor at the end of filename before extension
            cancelThumbLosingFocus = true;
            FileRenameText.Focus();
            cancelThumbLosingFocus = false;
            CommentGrid.Visibility = Visibility.Hidden;
            Debug.Print("Rename_Click FileRenameText.Visibility " + FileRenameText.Visibility + " FileNameGrid.Visibility " + FileNameGrid.Visibility);
        }

        private void RestoreThumb_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle);
            string[] arr = GetMediaInfo(videoSource, "Video;%Duration%");
            double middle = int.Parse(arr[0]) / 2;

            string targetFile = OrigToThumb(videoSource);
            GetStillImage(videoSource, middle, targetFile); //it will overwrite the current file.

            RemoveThumb(targetFile,false);
            CreateThumb(targetFile, contextItemIndex);
        }

        private void Context_DeleteClick(object sender, RoutedEventArgs e) //delete from menu
        {
            Context_Delete(sender, e, true);
        }

        private void Context_Delete(object sender, RoutedEventArgs e, bool isNext)
        {
            Debug.Print("Context_Delete "  + isNext + " " + currentPicIndex);
            try
            {
                string fileName, type;
                if (isPictureFullscreen)
                {
                    fileName = ((BitmapImage)ImageElement1.Source).UriSource.LocalPath;
                    type = "picture";
                }
                else if (isVideoFullscreen)
                {
                    fileName = videoSource;
                    type = "video";
                }
                else //thumbnail view
                {
                    int i = (contextItemIndex != -1) ? contextItemIndex : currentPicIndex;//it will be reset, when the messagebox appears.
                    fileName = new Uri(((Image)((Border)Thumbs.Children[i]).Child).Source.ToString()).LocalPath;
                    if (IsThumbVideo(fileName)) //video
                    {
                        type = "video";
                    }
                    else
                    {
                        type = "picture";
                    }
                }

                dialogActivation = true;
                var confirmResult = (settings["DeletionConfirmation"] && !deleteSelectedPics) ? System.Windows.MessageBox.Show("Are you sure you want to delete this " + type + "?", "Confirm deletion", MessageBoxButton.YesNo) : MessageBoxResult.Yes;
                dialogActivation = false;

                if (confirmResult == MessageBoxResult.Yes)
                {
                    Debug.Print("Context_Delete before delete currentPicIndex " + currentPicIndex);
                    if (isPictureFullscreen)
                    {
                        if (currentPicIndexExt == -1)
                        {
                            RemoveThumb(OrigToThumb(fileName),true);
                        }
                        File.Delete(fileName); //must come after removethumb, because thumbtoorig will otherwise not find the file.
                        if (currentPicIndexExt != -1)
                        {
                            //refresh list of files in directory, currentPicIndexExt will not change, because the file is not found anymore.
                            GetFilesExternal(fileName);
                        }
                        NextContent(false);
                    }
                    else if (isVideoFullscreen)
                    {
                        Debug.Print("Context_Delete before delete2 currentPicIndex " + currentPicIndex);
                        StopVideo();
                        MediaElement1.Source = null;
                        Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle);

                        Debug.Print("Context_Delete before delete3 currentPicIndex " + currentPicIndex + " " + currentPicIndexExt);
                        if (currentPicIndexExt == -1)
                        {
                            RemoveThumb(OrigToThumb(fileName),true);
                        }
                        
                        //deleting video
                        File.Delete(fileName);
                        //deleting index
                        string index = settings["SkillsPath"] != "" ? OrigToIndex(fileName) : "";//c:\\temp becomes $temp for external files.

                        if (File.Exists(index))
                        {
                            File.Delete(index);
                        }
                        //deleting comment
                        string comment = settings["SkillsPath"] != "" ? OrigToComment(fileName) : "";
                        if (File.Exists(comment))
                        {
                            File.Delete(comment);
                        }
                        //deleting thumbnail
                        string thumb = settings["SkillsPath"] != "" ? OrigToThumb(fileName) : "";
                        if (File.Exists(thumb)) //it must exist, unless we are watching an external video.
                        {
                            File.Delete(thumb);
                        }

                        if (currentPicIndexExt != -1)
                        {
                            //refresh list of files in directory, currentPicIndexExt will not change, because the file is not found anymore.
                            GetFilesExternal(fileName);
                        }
                        NextContent(false);
                    }
                    else //thumbnail view
                    {
                        if (IsThumbVideo(fileName))
                        {
                            //deleting video
                            string orig = ThumbToOrig(fileName);

                            RemoveThumb(fileName, isNext); //fileName is already in thumbnail format
                            
                            File.Delete(orig);
                            //deleting index
                            string index = OrigToIndex(orig);
                            if (File.Exists(index))
                            {
                                File.Delete(index);
                            }
                            //deleting comment
                            string comment = OrigToComment(orig);
                            if (File.Exists(comment))
                            {
                                File.Delete(comment);
                            }
                            //deleting thumbnail
                            File.Delete(fileName);
                        }
                        else //picture
                        {
                            RemoveThumb(fileName, isNext); //fileName is already in thumbnail format
                            File.Delete(ThumbToOrig(fileName));
                        }

                        FileNameGrid.Visibility = Visibility.Hidden;
                        CommentGrid.Visibility = Visibility.Hidden;
                        contextItemIndex = -1; //menu closing event is not yet called, and Thumbs_mousemove will only run, if this is -1
                        currentThumbIndex = -1; 
                        //Thumb_mousemove will be raised now.
                    }
                }
            }
            catch (Exception ex) //How to evoke it? With some background program that deletes the file after I switched to this program?
            {
                if (ex is FileNotFoundException || ex is IOException)
                {//file not found, or is open, therefore locked
                    Msgbox(ex.Message + "\n" + ex.StackTrace);
                }
                else
                {
                    Msgbox(ex.Message + "\n" + ex.StackTrace);
                }
            }
        }        

        #endregion

        #region Thumbs context menu functions

        private string[] GetMediaInfo(string mname, string info) //mediaElement's NaturalDuration returns only the seconds.
        {
            try
            {
                var process = new Process();
                var startInfo = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    FileName = @"resources\Mediainfo.exe",
                    Arguments = "--Inform=\"" + info + "\" \"" + mname + "\""
                };
                process.StartInfo = startInfo;
                process.Start();
                while (!process.StandardOutput.EndOfStream) // exception can be thrown here, if the thread was aborted.
                {
                    string line = process.StandardOutput.ReadLine();
                    return line.Split(',');
                }
                return null;
            }
            catch (Exception e)
            {
                Debug.Print(e.Message + " " + e.StackTrace);
                return null;
            }
        }

        private void GetStillImage(string vname, double seektime, string outpath) //mediaElement's NaturalDuration returns only the seconds.
        {
            try
            {
                var process = new Process();
                var startInfo = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    FileName = @"resources\ffmpeg.exe",
                    Arguments = "-y -ss " + (seektime / 1000).ToString(CultureInfo.InvariantCulture) + " -i \"" + vname + "\" -qscale:v 2 -vframes 1 \"" + outpath + "\""
                };
                process.StartInfo = startInfo;
                Debug.Print(process.StartInfo.Arguments);
                process.Start();
                process.WaitForExit(); //if the skillslist selection is changed, and the thread is aborted, it will throw an exception.
            }
            catch (Exception e)
            {
                Debug.Print(e.Message + " " + e.StackTrace);
            }
        }

        private void Extract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (threadThumb != null && threadThumb.IsAlive || threadExt != null && threadExt.IsAlive) //thumb generation or frame extraction running.
                {
                    dialogActivation = true;
                    Msgbox("Wait until the current operation is finished, or restart the program.");
                    dialogActivation = false;
                }
                else
                {
                    extVideoSource = videoSource;
                    extVideoDuration = videoDuration;
                    threadExt = new System.Threading.Thread(new System.Threading.ThreadStart(() => ExtractVideoFrames(videoSource)));
                    threadExt.Start();
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message + " " + ex.StackTrace);
            }            
        }

        private void ExtractVideoFrames(string src)
        {
            string command = "-select_streams v -show_frames -show_entries frame=pict_type,pkt_pts_time -of csv \"" + src + "\"";
            Process process = new Process();
            var startInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                FileName = @"resources\ffprobe.exe",
                Arguments = command
            };
            //File.WriteAllText("command.txt", command);
            process.StartInfo = startInfo;
            process.OutputDataReceived += Process_OutputDataReceived;
            process.EnableRaisingEvents = true;

            if (allItemsCount == 0)
            {
                this.Dispatcher.Invoke(() =>
                {
                    if (isVideoFullscreen)
                    {
                        StatusTextVideo.Text = "Extracting frames: " + extVideoSource.Replace(settings["SkillsPath"], "") + " 0 %";
                        StatusTextVideo.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        StatusText.Text = "Extracting frames: " + extVideoSource.Replace(settings["SkillsPath"], "") + " 0 %";
                        StatusText.Visibility = Visibility.Visible;
                    }
                });
            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    if (isVideoFullscreen)
                    {
                        StatusTextVideo.Text = "Extracting frames " + currentItemCount + "/" + allItemsCount + ": " + extVideoSource.Replace(settings["SkillsPath"], "") + " 0 %";
                        StatusTextVideo.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        StatusText.Text = "Extracting frames " + currentItemCount + "/" + allItemsCount + ": " + extVideoSource.Replace(settings["SkillsPath"], "") + " 0 %";
                        StatusText.Visibility = Visibility.Visible;
                    }
                });
            }
            
            extractFramesOutput = "";

            extFrameIndex = new List<double>();
            extKeyFrames = new List<double>(); //it will not be used, when we extract the frames in thumbnail view.

            process.Start();
            process.BeginOutputReadLine();
            process.WaitForExit();
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                extractFramesOutput += e.Data + Environment.NewLine;

                string[] arr = e.Data.Split(',');
                double timeStamp = Math.Round(double.Parse(arr[1], CultureInfo.InvariantCulture) * 1000, 3); // without rounding, we get unequal values at GetMiddleIndexPos, even if the numbers look perfectly the same when written as a string.

                extFrameIndex.Add(timeStamp);
                Debug.Print(extFrameIndex.Count.ToString());
                if (arr[2] == "I")
                {
                    extKeyFrames.Add(timeStamp);
                }

                if (extVideoSource == videoSource && isVideoFullscreen) //if we are not seeing another video while the frames are being extracted, and we are not in thumbnail view with the context menu open (videoSource is set there)
                {
                    frameIndex.Add(timeStamp);
                    if (arr[2] == "I")
                    {
                        keyFrames.Add(timeStamp);
                        this.Dispatcher.Invoke(() =>
                        {
                            DrawKeyFrame(timeStamp);
                        });
                    }
                }

                int n = (int)(timeStamp / extVideoDuration * 100);
                if (allItemsCount == 0)
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        if (isVideoFullscreen)
                        {
                            StatusTextVideo.Text = "Extracting frames: " + extVideoSource.Replace(settings["SkillsPath"], "") + " " + n + " %";
                            StatusTextVideo.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            StatusText.Text = "Extracting frames: " + extVideoSource.Replace(settings["SkillsPath"], "") + " " + n + " %";
                            StatusText.Visibility = Visibility.Visible;
                        }
                    });
                }
                else
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        if (isVideoFullscreen)
                        {
                            StatusTextVideo.Text = "Extracting frames " + currentItemCount + "/" + allItemsCount + ": " + extVideoSource.Replace(settings["SkillsPath"], "") + " " + n + " %";
                            StatusTextVideo.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            StatusText.Text = "Extracting frames " + currentItemCount + "/" + allItemsCount + ": " + extVideoSource.Replace(settings["SkillsPath"], "") + " " + n + " %";
                            StatusText.Visibility = Visibility.Visible;
                        }
                    });
                }
            }
            else
            {
                Debug.Print("Writing index to file extFrameIndex.Count: " + extFrameIndex.Count); //1410
                File.WriteAllText(OrigToIndex(extVideoSource), extractFramesOutput);

                if (extVideoSource == videoSource && isVideoFullscreen)
                {
                    frameIndex = extFrameIndex.ToList(); //copies by value, not reference
                    keyFrames = extKeyFrames.ToList();
                    GetMiddleIndexPos(middleIndexPos); //need to set currentFrameIndexPos, otherwise frame stepping will start from the beginning. 
                }

                this.Dispatcher.Invoke(() =>
                {
                    if (settings["ShowExtractStatus"])
                    {
                        for (int i = 0; i < Thumbs.Children.Count; i++) //show check mark
                        {
                            Image im = (Image)((Border)Thumbs.Children[i]).Child;
                            BitmapImage bit = (BitmapImage)im.Source;
                            if (ThumbToOrig(bit.UriSource.LocalPath) == extVideoSource)
                            {
                                ((Grid)FileNameGridAllCanvas.Children[i]).Children[2].Visibility = Visibility.Visible;
                            }
                        }
                    }
                    if (isVideoFullscreen)
                    {
                        StatusTextVideo.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        StatusText.Visibility = Visibility.Hidden;
                    }
                });
                extVideoSource = null;
            }
        }

        private void FileRenameText_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                //Debug.Print("FileRenameText_KeyDown " + renameContextItemIndex);
                //Debug.Print(displayedThumbs[renameContextItemIndex]);
                if (e.Key == Key.Enter)
                {
                    string origFile = ThumbToOrig(displayedThumbs[renameContextItemIndex]);
                    string baseDir = (settings["SelectedSkill"] == ".") ? settings["SkillsPath"] : settings["SkillsPath"] + settings["SelectedSkill"] + @"\";
                    string newFile = baseDir + FileRenameText.Text;
                    Console.WriteLine("FileRenameText_KeyDown renameContextItemIndex " + renameContextItemIndex + " thumb " + displayedThumbs[renameContextItemIndex] + " origFile " + origFile + " newFile " + newFile);
                    if (origFile != newFile) //name changed
                    {
                        //Debug.Print("FileRenameText_KeyDown " + System.IO.Path.GetExtension(newFile) + " " + System.IO.Path.GetExtension(origFile));
                        if (System.IO.Path.GetExtension(newFile).ToLower() != System.IO.Path.GetExtension(origFile).ToLower())
                        {
                            Msgbox("Changing extension is not supported.");
                            FileRenameText.Focus();
                            return;
                        }

                        if (File.Exists(newFile) && origFile.ToLower() != newFile.ToLower()) //target file exists.
                        //In case of "cUt" and "cut", this section will not run, the filename had to be substantially changed (not just by case)
                        {
                            dialogActivation = true;
                            var confirmResult = System.Windows.MessageBox.Show("A file with this name already exists. Do you want to overwrite it?", "Confirm overwrite", MessageBoxButton.YesNo);
                            dialogActivation = false;
                            if (confirmResult == MessageBoxResult.Yes)
                            {
                                if (System.IO.Path.GetExtension(origFile).ToLower() == ".jpg" || System.IO.Path.GetExtension(origFile).ToLower() == ".png") //picture
                                {
                                    File.Delete(newFile);
                                    int removedIndex = RemoveThumb(newFile,false); //origtothumb is not needed here, as it is a picture.
                                    if (removedIndex < renameContextItemIndex) //moving index back. They cannot be equal, because origFile = newFile is already filtered out.
                                    {
                                        renameContextItemIndex--;
                                        FileNameGrid.Visibility = Visibility.Hidden; //since the indexes shifted, now another picture got under the mouse, but the filename hasn't been updated. At the end of the list, the filename just remains visible over empty space.
                                        CommentGrid.Visibility = Visibility.Hidden;
                                        currentThumbIndex = -1; //to enforce refresh of the filename label, because the mousemove event will be called now.
                                    }
                                    File.Move(origFile, newFile);

                                    Image im = (Image)((Border)Thumbs.Children[renameContextItemIndex]).Child;
                                    BitmapImage imageBitmap = new BitmapImage();
                                    imageBitmap.BeginInit();
                                    imageBitmap.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                                    imageBitmap.CacheOption = BitmapCacheOption.OnLoad;//makes it possible to delete the image, otherwise it will be locked. If I set it to OnLoad however, the image will not refresh when the thumbnail image file refreshes.
                                    imageBitmap.UriSource = new Uri(newFile, UriKind.Absolute);
                                    imageBitmap.EndInit();
                                    im.Source = imageBitmap;

                                    displayedThumbs[renameContextItemIndex] = newFile;
                                    ((TextBlock)((Grid)((Grid)FileNameGridAllCanvas.Children[renameContextItemIndex]).Children[0]).Children[0]).Text =
                                        System.IO.Path.GetFileName(newFile).Replace(settings["SelectedSkill"] + settings["FileNameSeparator"], "");
                                }
                                else //video
                                {
                                    File.Delete(newFile);
                                    File.Move(origFile, newFile);

                                    File.Delete(OrigToThumb(newFile));
                                    int removedIndex = RemoveThumb(OrigToThumb(newFile),false);
                                    if (removedIndex < renameContextItemIndex) //moving index back. They cannot be equal, because origFile = newFile is already filtered out.
                                    {
                                        renameContextItemIndex--;
                                        FileNameGrid.Visibility = Visibility.Hidden; //since the indexes shifted, now another picture got under the mouse, but the filename hasn't been updated. At the end of the list, the filename just remains visible over empty space.
                                        CommentGrid.Visibility = Visibility.Hidden;
                                        currentThumbIndex = -1; //to enforce refresh of the filename label, because the mousemove event will be called now.
                                    }

                                    File.Move(OrigToThumb(origFile), OrigToThumb(newFile));

                                    string index_orig = OrigToIndex(origFile);
                                    string index_new = OrigToIndex(newFile);

                                    if (File.Exists(index_orig))
                                    {
                                        if (File.Exists(index_new))
                                        {
                                            File.Delete(index_new);
                                        }
                                        File.Move(index_orig, index_new);
                                    }

                                    string comment_orig = OrigToComment(origFile);
                                    string comment_new = OrigToComment(newFile);

                                    if (File.Exists(comment_orig))
                                    {
                                        if (File.Exists(comment_new))
                                        {
                                            File.Delete(comment_new);
                                        }
                                        File.Move(comment_orig, comment_new);
                                    }

                                    Image im = (Image)((Border)Thumbs.Children[renameContextItemIndex]).Child;
                                    BitmapImage imageBitmap = new BitmapImage();
                                    imageBitmap.BeginInit();
                                    imageBitmap.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                                    imageBitmap.CacheOption = BitmapCacheOption.OnLoad;//makes it possible to delete the image, otherwise it will be locked. If I set it to OnLoad however, the image will not refresh when the thumbnail image file refreshes.
                                    imageBitmap.UriSource = new Uri(OrigToThumb(newFile), UriKind.Absolute);
                                    imageBitmap.EndInit();
                                    im.Source = imageBitmap;

                                    displayedThumbs[renameContextItemIndex] = OrigToThumb(newFile);
                                    ((TextBlock)((Grid)((Grid)FileNameGridAllCanvas.Children[renameContextItemIndex]).Children[0]).Children[0]).Text =
                                        System.IO.Path.GetFileName(ThumbToOrig(newFile)).Replace(settings["SelectedSkill"] + settings["FileNameSeparator"], "");
                                }
                                CloseRenameField(true);
                            }
                            else //user chose no
                            {
                                FileRenameText.Focus();
                            }
                        }
                        else //target file does not exist, or only the case changed.
                        {
                            if (System.IO.Path.GetExtension(origFile).ToLower() == ".jpg" || System.IO.Path.GetExtension(origFile).ToLower() == ".png") //picture
                            {
                                Console.WriteLine("Moving file " + origFile + " to " + newFile);
                                File.Move(origFile, newFile);
                                File.Move(OrigToThumb(origFile), OrigToThumb(newFile));

                                Image im = (Image)((Border)Thumbs.Children[renameContextItemIndex]).Child;
                                BitmapImage imageBitmap = new BitmapImage();
                                imageBitmap.BeginInit();
                                imageBitmap.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                                imageBitmap.CacheOption = BitmapCacheOption.OnLoad;//makes it possible to delete the image, otherwise it will be locked. If I set it to OnLoad however, the image will not refresh when the thumbnail image file refreshes.
                                imageBitmap.UriSource = new Uri(OrigToThumb(newFile), UriKind.Absolute);
                                imageBitmap.EndInit();
                                im.Source = imageBitmap;

                                displayedThumbs[renameContextItemIndex] = OrigToThumb(newFile);
                                ((TextBlock)((Grid)((Grid)FileNameGridAllCanvas.Children[renameContextItemIndex]).Children[0]).Children[0]).Text =
                                        System.IO.Path.GetFileName(newFile).Replace(settings["SelectedSkill"] + settings["FileNameSeparator"], "");
                                Console.WriteLine("Moving file end");
                            }
                            else //video
                            {
                                //Debug.Print("renaming " + origFile + " to " + newFile);
                                File.Move(origFile, newFile);
                                //thumbnail must not exist, unless the user copied it into the folder, or remained from a previous root setting.
                                File.Move(OrigToThumb(origFile), OrigToThumb(newFile));

                                string index_orig = OrigToIndex(origFile);
                                string index_new = OrigToIndex(newFile);

                                if (File.Exists(index_orig)) //index_new must not exist, unless the user copied it into the folder.
                                {
                                    if (File.Exists(index_new))
                                    {
                                        File.Delete(index_new);
                                    }
                                    File.Move(index_orig, index_new);
                                }

                                string comment_orig = OrigToComment(origFile);
                                string comment_new = OrigToComment(newFile);

                                if (File.Exists(comment_orig)) //comment_new must not exist, unless the user copied it into the folder.
                                {
                                    if (File.Exists(comment_new))
                                    {
                                        File.Delete(comment_new);
                                    }
                                    File.Move(comment_orig, comment_new);
                                }

                                Image im = (Image)((Border)Thumbs.Children[renameContextItemIndex]).Child;
                                BitmapImage imageBitmap = new BitmapImage();
                                imageBitmap.BeginInit();
                                imageBitmap.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                                imageBitmap.CacheOption = BitmapCacheOption.OnLoad;//makes it possible to delete the image, otherwise it will be locked. If I set it to OnLoad however, the image will not refresh when the thumbnail image file refreshes.
                                imageBitmap.UriSource = new Uri(OrigToThumb(newFile), UriKind.Absolute);
                                imageBitmap.EndInit();
                                im.Source = imageBitmap;

                                displayedThumbs[renameContextItemIndex] = OrigToThumb(newFile);
                                ((TextBlock)((Grid)((Grid)FileNameGridAllCanvas.Children[renameContextItemIndex]).Children[0]).Children[0]).Text =
                                        System.IO.Path.GetFileName(newFile).Replace(settings["SelectedSkill"] + settings["FileNameSeparator"], "");
                            }
                            CloseRenameField(true);
                        }
                    }
                    else
                    {
                        CloseRenameField(true);
                    }
                }
                else if (e.Key == Key.Escape)
                {
                    CloseRenameField(false);
                }
            }
            catch (Exception ex) //if the thumb and index files were renamed outside of program, or the target file is locked.
            {
                if (ex is IOException) //The process cannot access the file because it is being used by another process.
                {
                    if (extVideoSource != null)
                    {
                        Msgbox("Wait until frame extraction is finished.");
                    }
                    else
                    {
                        Msgbox("The file cannot be accessed right now." + ex.Message + "\n" + ex.StackTrace);
                    }
                }
            }
        }

        private void CloseRenameField(bool updateText)
        {
            Console.WriteLine("CloseRenameField");
            if (updateText)
            {
                FileNameLabelText.Text = FileRenameText.Text;
            }
            FileRenameText.Visibility = Visibility.Hidden;
            thumbsMouseEnabledThumb = true;
            FileNameGrid.IsHitTestVisible = false;
            
            //hide only if the mouse is not over the image that was renamed
            HitTestResult result = VisualTreeHelper.HitTest(ThumbScroll,Mouse.GetPosition(ThumbScroll));

            Debug.Print("CloseRenameField " + result.VisualHit);
            if (result.VisualHit is Image)
            {
                int index = Thumbs.Children.IndexOf((Border)((Image)result.VisualHit).Parent);
                if (renameContextItemIndex != index)
                {
                    FileNameGrid.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                FileNameGrid.Visibility = Visibility.Hidden;
            }

            renameContextItemIndex = -1;
            ThumbScroll.Focus();
            currentThumbIndex = -1; //so CommentGrid can appear on the same image.
        }

        private int RemoveThumb(string thumbName, bool isNext) //origtothumb must be used on filenames, before passing them to this function.
        {
            Debug.Print("RemoveThumb fileName " + thumbName + " currentPicIndex " + currentPicIndex);
            for (int i = 0; i < Thumbs.Children.Count; i++) //takes 160/10000 ms to cycle through 39 elements
            {
                Image im = (Image)((Border)Thumbs.Children[i]).Child;
                BitmapImage bit = (BitmapImage)im.Source;
                //Debug.Print(ThumbToOrig(bit.UriSource.LocalPath));
                if (bit.UriSource.LocalPath == thumbName)
                {
                    Debug.Print("RemoveThumb before " + String.Join(";", selectedPicIndexes));
                    Thumbs.Children.RemoveAt(i);
                    displayedThumbs.RemoveAt(i);
                    FileNameGridAllCanvas.Children.RemoveAt(i);
                    if (selectedPicIndexes.IndexOf(i) != -1) //remove from selection
                    {
                        selectedPicIndexes.Remove(i);
                    }
                    for (int ix = 0; ix < selectedPicIndexes.Count; ix++) //step -1 every selected item that is greater than the deleted index
                    {
                        if (selectedPicIndexes[ix] > i)
                        {
                            selectedPicIndexes[ix]--;
                        }
                    }

                    if (currentPicIndex != -1) //if cursor is set
                    {
                        Debug.Print("removethumb, cursor set " + i + " " + currentPicIndex);
                        if (i < currentPicIndex) //thumbnail view, cursor is at a greater position than the removed element
                        {
                            currentPicIndex--;
                            PositionBorderRect(currentPicIndex,true); //color is not affected.
                        }
                        else if (i == currentPicIndex) //thumbnail or video view, deleted at cursor. In video view, currentPicIndex should go to the next, and not be reset.
                        {
                            if (!isVideoFullscreen && !isPictureFullscreen) //thumbnail view
                            {
                                if ((currentPicIndex < Thumbs.Children.Count) && isNext) //selection rectangle goes to the next element
                                {
                                    Debug.Print("goes to next element");
                                    //if there is at least one remaining selected item, the item at the cursor will not be selected (if it is not that item).
                                    //Otherwise select it.
                                    if (selectedPicIndexes.Count > 0)
                                    {
                                        //change color of cursor depending on if the cursor position is among the selected indexes (indexes shifted!)
                                        if (selectedPicIndexes.IndexOf(i) != -1) //it is in the selection
                                        {
                                            BorderRect.Stroke = Brushes.Lime;
                                        }
                                        else
                                        {
                                            BorderRect.Stroke = Brushes.Red;
                                        }                                    
                                    }
                                    else
                                    {
                                        BorderRect.Stroke = Brushes.Lime;
                                        selectedPicIndexes.Add(currentPicIndex);
                                    }                  
                                }
                                else //last element was deleted, rectangle has to disappear.
                                {
                                    Debug.Print("hiding rect");
                                    BorderRect.Visibility = Visibility.Hidden;
                                    currentPicIndex = -1;                                    
                                }
                            }
                        }
                    }
                    Debug.Print("RemoveThumb after " + String.Join(";", selectedPicIndexes));
                    return i;
                }
            }
            return -1;
        }

        private void UpdateThumb(string fileName)
        {
            for (int i = 0; i < Thumbs.Children.Count; i++)
            {
                Image im = (Image)((Border)Thumbs.Children[i]).Child;
                BitmapImage bit = (BitmapImage)im.Source;
                if (bit.UriSource.LocalPath == fileName)
                {
                    BitmapImage imageBitmap = new BitmapImage();
                    imageBitmap.BeginInit();
                    imageBitmap.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                    imageBitmap.CacheOption = BitmapCacheOption.OnLoad;//makes it possible to delete the image, otherwise it will be locked. If I set it to OnLoad however, the image will not refresh when the thumbnail image file refreshes.
                    imageBitmap.UriSource = new Uri(fileName, UriKind.Absolute);
                    imageBitmap.EndInit();

                    im.Source = imageBitmap;
                }
            }
        }

        #endregion

        #region Video context menu event handlers

        private void MediaElement1_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (settings["SkillsPath"] == "" || videoSource.IndexOf(settings["SkillsPath"]) == -1) //only deletion is allowed for external files
            {
                MarkPosition.Visibility = Visibility.Collapsed;
                SetThumbnail.Visibility = Visibility.Collapsed;
                VideoMenuItemExtract.Visibility = Visibility.Collapsed;
                MarkPosition2.Visibility = Visibility.Collapsed;
                SetThumbnail2.Visibility = Visibility.Collapsed;
                VideoMenuItemExtract2.Visibility = Visibility.Collapsed;
            }
            else
            {
                MarkPosition.Visibility = Visibility.Visible;
                SetThumbnail.Visibility = Visibility.Visible;
                VideoMenuItemExtract.Visibility = Visibility.Visible;
                MarkPosition2.Visibility = Visibility.Visible;
                SetThumbnail2.Visibility = Visibility.Visible;
                VideoMenuItemExtract2.Visibility = Visibility.Visible;
                string indexFile = OrigToIndex(videoSource);
                if (!File.Exists(indexFile))
                {
                    VideoMenuItemExtract.Header = "Extract frames";
                    VideoMenuItemExtract2.Header = "Extract frames";
                }
                else
                {
                    VideoMenuItemExtract.Header = "Show frames";
                    VideoMenuItemExtract2.Header = "Show frames";
                }
                Debug.Print("MediaElement1_ContextMenuOpening setting videoControlGridIsVisible");
                //when opening the contextmenu of a marker, this function gets called too! setting videoControlGridIsVisible to true.
                videoControlGridIsVisible = VideoControlGrid.Visibility == Visibility.Visible ? true : false; //used so the controls do not autohide on setting marker (because that menuitem is high up)
            }
            //there is no system function to check if the cursor is visible, and the number of times we call the System.Windows.Forms.Cursor.Hide() function to hide it, the same number of times we need to call Show() to make the cursor visible again.
            this.Cursor = System.Windows.Input.Cursors.Arrow;
            /*if (!isCursorVisible)
            {
                System.Windows.Forms.Cursor.Show();
                isCursorVisible = true;
            }*/
            videoContextOpen = true;
            stw.Reset();
        }

        private void MediaElement1_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            videoContextOpen = false;
            if ((frameWindow == null || !frameWindow.IsVisible) && VideoControlGrid.Visibility == Visibility.Hidden)
            {
                this.Cursor = System.Windows.Input.Cursors.None;
                /*if (isCursorVisible)
                {
                    System.Windows.Forms.Cursor.Hide();
                    isCursorVisible = false;
                }*/
            }

        }

        private void MarkPosition_Click(object sender, RoutedEventArgs e)
        {
            if (videoLoaded)
            {
                if (isPlaying)
                {
                    GetMiddleIndexPos(MediaElement1.Position.TotalMilliseconds);
                }

                if (commentPositions.IndexOf(middleIndexPos) == -1)
                {
                    int i;
                    for (i = 0; i < commentPositions.Count; i++) //finding the saved position that is greater than the current. Cycle exits there.
                    //In case of empty array, i will get value of 0, and if the new position is greater than all that is saved, i will be equal to the number of elements in the array.
                    {
                        if (commentPositions[i] > middleIndexPos)
                        {
                            break;
                        }
                    }
                    AddCommentPos(i, middleIndexPos); //saves it to file
                    DrawCommentMarker(i, middleIndexPos, ""); //draws marker grid, and adds data to the memory

                    if (currentCommentPosIndex != -1) //closing existing open comments, in case we create multiple comment using the keyboard only
                    {
                        CloseCommentPos();
                    }

                    Debug.Print("Markposition_Click" + videoControlGridIsVisible);
                    if (videoControlGridIsVisible)
                    {
                        videoControlGridIsVisible = false; //reset variable, currentCommentPosIndex will be used to keep the controls visible
                        currentCommentPosIndex = i; //ensures, the controls remain visible. A click outside of the marker will be required to hide the controls.
                    }
                    else
                    {
                        currentCommentPosIndex = -1;
                    }
                    Debug.Print("MarkPosition_Click2 " + videoControlGridIsVisible + " " + currentCommentPosIndex);
                }
                else
                {
                    //open position's label
                }
            }
        }

        private void DrawCommentMarker(int index, double timePos, string comment) //draws marker grid, and adds data to the memory
        {
            try
            {
                commentPositions.Insert(index, timePos);
                commentPositionComments.Insert(index, comment);

                //File.WriteAllText(rootDir + "CommentMarker.txt","DrawcommentMarker " + timePos + " " + videoDuration + " " + TimelineSlider.ActualWidth);

                double pos = 7.5 + (timePos / videoDuration) * (TimelineSlider.ActualWidth - 15);

                Canvas c = new Canvas();
                //c.VerticalAlignment = VerticalAlignment.Center;
                c.Width = 15;
                c.Height = 32;
                /*SolidColorBrush br = new SolidColorBrush();
                br.Color = Color.FromRgb(255, 123, 45);
                br.Opacity = 0.6;
                g.Background = br;*/
                c.Margin = new Thickness(pos - 15 / 2, -29, 0, 0);
                
                //g.SizeChanged += CommentGrid_SizeChanged;

                CommentCanvas.Children.Insert(index, c);

                Image i = new Image();
                i.Margin = new Thickness(0, 20, 0, 0);
                i.Source = new BitmapImage(new Uri(resourceDir + "marker.png", UriKind.Absolute));
                i.MouseLeftButtonDown += CommentMarker_MouseLeftButtonDown;
                c.Children.Add(i);

                System.Windows.Controls.TextBox tb = new System.Windows.Controls.TextBox();
                tb.Text = comment;
                tb.Height = 20;
                tb.MinWidth = 15;
                //t.MaxWidth = windowWidth; //not the program's width, because it can be resized.
                tb.Visibility = (settings["CommentsLocked"] && tb.Text != "") ? Visibility.Visible : Visibility.Hidden; //hidden
                tb.IsReadOnly = true;               
                tb.Cursor = System.Windows.Input.Cursors.Arrow;
                tb.CaretIndex = 0;
                tb.CaretBrush = Brushes.White;
                SolidColorBrush br = new SolidColorBrush();
                br.Color = Color.FromRgb(255, 255, 255);
                br.Opacity = 0.9;
                tb.Background = br;

                tb.KeyDown += CommentTextBox_KeyDown;
                tb.SizeChanged += CommentTextBox_SizeChanged;
                c.Children.Add(tb);

                i.ContextMenu = new System.Windows.Controls.ContextMenu();
                i.ContextMenuOpening += CommentMarker_ContextMenuOpening;

                System.Windows.Controls.MenuItem m = new System.Windows.Controls.MenuItem();
                m.Header = "Remove marker";
                m.Click += CommentMarkerMenuRemove_Click;
                i.ContextMenu.Items.Add(m);

                m = new System.Windows.Controls.MenuItem();
                m.Header = ""; //Will be changed to either Add comment, or Edit comment.
                m.Click += CommentMarkerMenuAddEditComment_Click;
                i.ContextMenu.Items.Add(m);
                
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message + " " + ex.StackTrace);
            }
        }

        private void CommentTextBox_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            System.Windows.Controls.TextBox tb = (System.Windows.Controls.TextBox)sender;
            tb.Margin = new Thickness(-(tb.ActualWidth-15)/2,0,0,0);
        }
        
        private void CommentTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Debug.Print("CommentTextBox_KeyDown currentCommentPosIndex: " + currentCommentPosIndex + " key: " + e.Key);
            if (tbOpening)
            {
                tbOpening = false;
            }
            else if (e.Key == Key.Enter || e.Key == Key.Escape)
            {
                SaveCommentPos(sender);
                MainWindow1_MouseMove(null,null); //so the controlgrid will hide, if this is how it is set.
            }
        }

        public void SaveCommentPos(object sender) //saves comment into memory and file.
        {
            System.Windows.Controls.TextBox tb = (System.Windows.Controls.TextBox)sender;
            commentPositionComments[currentCommentPosIndex] = tb.Text; //update memory
            UpdateCommentPos(commentPositions[currentCommentPosIndex], tb.Text); //update file
            if (commentPositionComments[currentCommentPosIndex] != "")
            {
                //TraversalRequest r = new TraversalRequest(FocusNavigationDirection.Previous); //Next can put focus on the speedratio slider, previous can on the volume slider.
                //tb.MoveFocus(r); //to remove the caret
                //tb.IsReadOnlyCaretVisible = false; //it has no effect
                tb.IsReadOnly = true;
                tb.Cursor = System.Windows.Input.Cursors.Arrow;
                tb.CaretIndex = 0;
                tb.CaretBrush = Brushes.White; //will be slightly brighter than the background
                tb.IsReadOnlyCaretVisible = false; //it has no effect
                SolidColorBrush br = new SolidColorBrush();
                br.Color = Color.FromRgb(255, 255, 255);
                br.Opacity = 0.9;
                tb.Background = br;
            }
            else
            {
                tb.Visibility = Visibility.Hidden;
            }
        }

        private void AddCommentPos(int index, double pos) //saves new comment pos into file
        {
            string commentFile = OrigToComment(videoSource);
            if (File.Exists(commentFile))
            {
                List<string> arr = File.ReadAllLines(commentFile).ToList<string>();
                arr.Insert(index, pos.ToString(CultureInfo.InvariantCulture) + "\t");
                File.WriteAllLines(commentFile, arr);
            }
            else
            {
                string line = pos.ToString(CultureInfo.InvariantCulture) + "\t";
                File.WriteAllLines(commentFile, new string[] { line });
            }
        }

        private void UpdateCommentPos(double pos, string text) //modifies existing comment pos in file
        {
            string commentFile = OrigToComment(videoSource);
            string[] arr = File.ReadAllLines(commentFile);
            for (int i = 0; i < arr.Length; i++)
            {
                string[] arr2 = arr[i].Split('\t');
                if (arr2[0] == pos.ToString(CultureInfo.InvariantCulture))
                {
                    arr[i] = arr2[0] + "\t" + text;
                    break;
                }
            }
            File.WriteAllLines(commentFile, arr);
        }

        private void RemoveCommentPos(double pos) //removes comment pos from file
        {
            string commentFile = OrigToComment(videoSource);
            string[] arr = File.ReadAllLines(commentFile);
            List<string> newLines = new List<string>();
            for (int i = 0; i < arr.Length; i++)
            {
                string[] arr2 = arr[i].Split('\t');
                if (arr2[0] != pos.ToString(CultureInfo.InvariantCulture))
                {
                    newLines.Add(arr[i]);
                }
            }
            if (newLines.Count != 0)
            {
                File.WriteAllLines(commentFile, newLines);
            }
            else
            {
                File.Delete(commentFile);
            }
        }

        private void CommentMarker_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            currentCommentPosIndex = CommentCanvas.Children.IndexOf((Canvas)((Image)sender).Parent);
            Debug.Print("CommentMarker_MouseLeftButtonDown currentCommentPosIndex " + currentCommentPosIndex);

            if (e.ClickCount == 1)
            {
                System.Windows.Controls.TextBox tb = ((System.Windows.Controls.TextBox)(CommentCanvas.Children[currentCommentPosIndex] as Canvas).Children[1]);
                if (!tb.IsReadOnly) //textbox is in edit mode
                {
                    SaveCommentPos(tb);
                }
                SelectCommentPos();
            }
            else
            {
                AddEditCommentPos();
            }
        }

        private void CommentMarkerMenuRemove_Click(object sender, RoutedEventArgs e)
        {
            Debug.Print("CommentMarkerMenuRemove_Click, videoControlGridIsVisible " + videoControlGridIsVisible);
            CommentCanvas.Children.RemoveAt(currentCommentPosIndex);
            RemoveCommentPos(commentPositions[currentCommentPosIndex]); //removes from file
            commentPositions.RemoveAt(currentCommentPosIndex);
            commentPositionComments.RemoveAt(currentCommentPosIndex);
            currentCommentPosIndex = -1;
            //when opening a marker's context menu, mediaelement's cotextmenuopening gets called too, setting videoControlGridIsVisible
            //CommentMarker_ContextMenuClosing does not get called.
            videoControlGridIsVisible = false;
        }

        private void CommentMarkerMenuAddEditComment_Click(object sender, RoutedEventArgs e)
        {
            AddEditCommentPos();
        }

        private void SelectCommentPos()
        {
            if (commentPositionComments[currentCommentPosIndex] != "")
            {
                System.Windows.Controls.TextBox tb = ((System.Windows.Controls.TextBox)(CommentCanvas.Children[currentCommentPosIndex] as Canvas).Children[1]);
                SolidColorBrush br = new SolidColorBrush();
                br.Color = Color.FromRgb(255, 255, 255);
                br.Opacity = 0.9;
                tb.Background = br;
                tb.Visibility = Visibility.Visible;
            }
            GetMiddleIndexPos(commentPositions[currentCommentPosIndex]); //the data in the array is already a middleindexpos type, but we need to get the currentFrameIndex, so the frame by frame playback does not start from a different position.
            MediaElement1.Position = TimeSpan.FromMilliseconds(middleIndexPos);
            TimelineSlider.Value = middleIndexPos;
        }

        private void AddEditCommentPos()
        {
            System.Windows.Controls.TextBox tb = ((System.Windows.Controls.TextBox)((Canvas)CommentCanvas.Children[currentCommentPosIndex]).Children[1]);
            tb.Visibility = Visibility.Visible;
            tb.Background = Brushes.White;            
            tb.IsReadOnly = false;
            tb.Cursor = System.Windows.Input.Cursors.IBeam;
            tb.CaretBrush = Brushes.Black;
            tb.Focus();
            if (commentPositionComments[currentCommentPosIndex] != "")
            {
                tb.CaretIndex = tb.Text.Length;
            }
        }

        public void CloseCommentPos() //does not reset currentCommentPosIndex.
        {
            //Debug.Print("CloseCommentPos");
            System.Windows.Controls.TextBox tb = ((System.Windows.Controls.TextBox)(CommentCanvas.Children[currentCommentPosIndex] as Canvas).Children[1]);
            SaveCommentPos(tb);
            if (!settings["CommentsLocked"])
            {
                tb.Visibility = Visibility.Hidden;
            }
        }

        private void CommentMarker_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            Debug.Print("CommentMarker_ContextMenuOpening, videoControlGridIsVisible " + videoControlGridIsVisible);
            currentCommentPosIndex = CommentCanvas.Children.IndexOf((Canvas)((Image)sender).Parent);
            ((System.Windows.Controls.MenuItem)((Image)sender).ContextMenu.Items[1]).Header = commentPositionComments[currentCommentPosIndex] == "" ? "Add comment" : "Edit comment";
        }

        private void SetThumbnail_Click(object sender, RoutedEventArgs e)
        {
            if (videoLoaded)
            {
                Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle);
                StatusTextVideo.Text = "Updating thumbnail...";
                StatusTextVideo.Visibility = Visibility.Visible;
                Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle);

                string thumb = OrigToThumb(videoSource);

                if (isPlaying)
                {
                    double pos = MediaElement1.Position.TotalMilliseconds;
                    GetMiddleIndexPos(pos);
                }
                //GetStillImage(videoSource, middleIndexPos, thumb); //gets the next frame. It only gets the current frame, if the timestamp is set to the beginning of the frame. The quality in best case is no better than RenderTargetBitmap, and it is pale, if you compare the two.

                RenderTargetBitmap Rtb = new RenderTargetBitmap((int)DrawingCanvas.ActualWidth, (int)DrawingCanvas.ActualHeight, 96, 96, System.Windows.Media.PixelFormats.Default);
                Rtb.Render(DrawingCanvas);
                JpegBitmapEncoder Enc = new JpegBitmapEncoder();// PngBitmapEncoder();
                Enc.Frames.Add(BitmapFrame.Create(Rtb));
                System.IO.FileStream fileStream = new System.IO.FileStream(thumb, System.IO.FileMode.OpenOrCreate);
                Enc.Save(fileStream);
                fileStream.Close();

                UpdateThumb(thumb);

                StatusTextVideo.Visibility = Visibility.Hidden;
            }
        }

        #endregion

        #region MainWindow1 event handlers

        private bool savingCutVideo = false; //prevents duplicate thumbnail of the cut video, if we exit view immediately after cutting.
        private bool noContentLoad = false; //when closing the info box with mouse click, we do not want the button up to open a video.
        //Also when renaming/adding/deleting files outside of program, and click on a thumbnail to activate program. The current image can be removed or moved, thus there is another picture under the mouse now.

        //private Stopwatch windowActivating; //originally used to prevent the mouse click to open a video, when we just activating the window by clicking into it.
        //now it is used to prevent double refresh of thumbnails upon window activating and list selection change. Test stopwatch.
        private DispatcherTimer windowActivatingTimer;

        private void MainWindow1_Activated(object sender, EventArgs e) //runs on startup too instead of skillslist_selectionchanged.
        {
            //Debug.Print("MainWindow1_Activated");
            if (!dialogActivation && Directory.Exists(settings["SkillsPath"])) // if we are not coming from a msgbox, or are at the default page.
            {
                //refresh directory list
                int oldIndex = SkillsList.SelectedIndex;

                string[] contents = Directory.GetDirectories(settings["SkillsPath"]);               
                List<string> SkillsListSource_new = new List<string>();
                SkillsListSource_new.Add(".");
                foreach (string dirName in contents)
                {
                    SkillsListSource_new.Add(System.IO.Path.GetFileName(dirName));
                }
                SkillsListSource_new.Sort();
                if (String.Join(";", SkillsListSource_new) != String.Join(";", SkillsListSource))
                {
                    Debug.Print("Lists are not equal");
                    SkillsListSource = new List<string>(SkillsListSource_new); //passing list by value, not reference
                    changedByProgramList = true;
                    SkillsList.ItemsSource = null;
                    SkillsList.ItemsSource = SkillsListSource;

                    //restoring selection. If the selected dir is still found, we select it. Otherwise we keep the index (renaming / deleting happened)
                    if (SkillsListSource.IndexOf(settings["SelectedSkill"]) != -1)
                    {
                        SkillsList.SelectedItem = settings["SelectedSkill"];
                        changedByProgramList = false; //thumbs will update by timer.                        
                        FocusListItem();
                    }
                    else //puts focus also to the listbox.
                    {
                        changedByProgramList = false; //thumbs will update by list selectionchange event. Timer will not take place.
                        if (oldIndex >= SkillsListSource.Count) //old index is bigger than the current max, due to folder deletion
                        {
                            SkillsList.SelectedIndex = 0;
                            ListScroll.ScrollToVerticalOffset(0);
                        }
                        else
                        {
                            SkillsList.SelectedIndex = oldIndex; //list does not need to be scrolled.
                        }
                        FocusListItem();
                        return;
                    }
                    
                }

                //windowActivating = Stopwatch.StartNew();
                windowActivatingTimer = new DispatcherTimer();
                windowActivatingTimer.Interval = TimeSpan.FromMilliseconds(100);
                windowActivatingTimer.Tick += WindowActivatingTimer_Tick;
                windowActivatingTimer.Start();
            }           
        }

        private void WindowActivatingTimer_Tick(object sender, EventArgs e)
        {
            //error: windowActivatingTimer is null, when switching away from window while it is loading. 
            if (windowActivatingTimer != null)
            {
                windowActivatingTimer.Stop();
                windowActivatingTimer = null;
                StartUpdateThumbs();
            }
        }

        private void MainWindow1_Loaded(object sender, RoutedEventArgs e) //to prevent updating the settings, modifying the file's date.
        {
            changedByProgramInit = false;
            Debug.Print("MainWindow1_Loaded");
            if (Directory.Exists(settings["SkillsPath"]))
            {
                FocusListItem();
            }
            if (currentPicIndexExt != -1 && ImageElement1.Source != null) //MainGrid.Actual... is now right.
            {
                AlignExternalPic();
            }
        }

        private void AlignExternalPic()
        {
            BitmapImage imageBitmap = (BitmapImage)ImageElement1.Source;
            if (imageBitmap.PixelWidth < MainGrid.ActualWidth && imageBitmap.PixelHeight < MainGrid.ActualHeight)
            {
                double w = imageBitmap.PixelWidth;
                double h = imageBitmap.PixelHeight;
                ImageElement1.Width = w;
                ImageElement1.Height = h;
                ImageElement1.Margin = new Thickness((MainGrid.ActualWidth - w) / 2, (MainGrid.ActualHeight - h) / 2, 0, 0);

                ActualSize.Source = new BitmapImage(new Uri(resourceDir + "origsize.png", UriKind.Absolute));
                actualSizeView = true;
            }
            else
            {
                SetImageOrigSize(imageBitmap);
                ActualSize.Source = new BitmapImage(new Uri(resourceDir + "actualsize.png", UriKind.Absolute));
                actualSizeView = false;
            }
        }

        /*
        OK = visual focus at start, moves immediately
        move OK = no visual focus at start, moves immediately
        pos OK = focus=selected item, but one keypress is required for the focus to appear, and another to move it.

        Testing focusing list item:
        new dir
            before current: pos OK
            after current: pos OK
        delete dir / last dir: delete key: OK, context menu: move OK
        rename dir: OK
        list modified outside program
            deleted before: OK
            deleted after: OK
            new folder before: OK / move OK
            new folder after:  OK / move OK
            deleted current: OK
            deleted current last: move OK
            renamed current: OK
        dragover recover:
            internal / external: OK
        drop recover:
            from internal: move OK
            from external: OK
            to external, putting focus back on list: OK
        */
        private void FocusListItem()
        {
            //putting focus on selected item. When the window is not yet loaded, listBoxItem would return null.
            SkillsList.UpdateLayout(); // Pre-generates item containers 
            var listBoxItem = (ListBoxItem)SkillsList.ItemContainerGenerator.ContainerFromItem(SkillsList.SelectedItem);
            listBoxItem.Focus();
        }

        private void FocusListIndex(int offset) //not used. Test function.
        {
            //putting focus on selected item. When the window is not yet loaded, listBoxItem would return null.
            SkillsList.UpdateLayout(); // Pre-generates item containers 
            var listBoxItem = (ListBoxItem)SkillsList.ItemContainerGenerator.ContainerFromIndex(SkillsList.SelectedIndex + offset);
            listBoxItem.Focus();
        }

        private void MainWindow1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            /*if (windowActivating != null)
            {
                windowActivating.Stop();
                //Debug.Print("MainWindow1_PreviewMouseDown" + windowActivating.ElapsedMilliseconds);
                //prevent mouse click from having action, while we just want to activate the window.
                //problem: when we open the frames, we need to click twice to open a video (in thumbnail view), or to change slider position in video view.               
                if (windowActivating.ElapsedMilliseconds < 20) // 4-9 ms
                {
                    windowActivating = null;
                    e.Handled = true;
                    return;
                }
                else //normal click, function continues
                {
                    windowActivating = null;
                }
            }*/
            noContentLoad = false; //new click, content may load.
            if (!thumbsMouseEnabledThumb) //rename text box is open, if we clicked outside the box, it should close.
            {
                //Debug.Print("MainWindow1_PreviewMouseDown " + e.Source);
                if (!(e.Source is System.Windows.Controls.TextBox))
                {
                    CloseRenameField(false);
                    e.Handled = true;
                }
            }
            if (!thumbsMouseEnabledList) //list rename text box is open, if we clicked outside the box, it should close.
            {
                if (!(e.Source is System.Windows.Controls.TextBox))
                {
                    ListRenameField.Visibility = Visibility.Hidden;
                    thumbsMouseEnabledList = true;
                    e.Handled = true;
                }
            }
            if (FileInfoGrid.Visibility == Visibility.Visible) //the click should only close the info box
            {
                FileInfoGrid.Visibility = Visibility.Hidden;
                currentPicIndex = infoContextItemIndex;
                infoContextItemIndex = -1;
                // ThumbScroll.Focusable = true;
                ThumbScroll.Focus();
                // ThumbScroll.Focusable = false;
                noContentLoad = true;
                e.Handled = true;
            }
            if (contextItemIndex != -1) //context menu is open, the click should not do anything other than closing the menu. When the menu is open, the thumbs do not register movement over them.
            {
                e.Handled = true;
            }            

            if (isVideoFullscreen)
            {
                Debug.Print("MainWindow1_PreviewMouseDown isVideoFullscreen e.Source: " + e.Source);
                if (e.Source is System.Windows.Controls.TextBox) //we clicked into a selected or not selected comment. currentCommentPosIndex may be -1 or already set.
                {
                    //getting index, and reference to the textbox
                    System.Windows.Controls.TextBox tb = (System.Windows.Controls.TextBox)e.Source;
                    Canvas c = (Canvas)tb.Parent;
                    int newcurrentCommentPosIndex = CommentCanvas.Children.IndexOf(c);

                    if (currentCommentPosIndex != -1 && currentCommentPosIndex != newcurrentCommentPosIndex) //if a marker is selected, and we didn't click on its textbox
                    {
                        //save and close that comment. settings["CommentsLocked"] must be true, if a non-selected marker's textbox is visible.
                        System.Windows.Controls.TextBox tbOld = ((System.Windows.Controls.TextBox)(CommentCanvas.Children[currentCommentPosIndex] as Canvas).Children[1]);
                        SaveCommentPos(tbOld);
                    }
                    currentCommentPosIndex = newcurrentCommentPosIndex;

                    if (e.ClickCount == 1) //set video to position, if we are not editing the textbox.
                    {
                        if (tb.IsReadOnly)
                        {
                            //as in SelectCommentPos(), but textbox is already visible
                            GetMiddleIndexPos(commentPositions[currentCommentPosIndex]); //the data in the array is already a middleindexpos type, but we need to get the currentFrameIndex, so the frame by frame playback does not start from a different position.
                            MediaElement1.Position = TimeSpan.FromMilliseconds(middleIndexPos);
                            TimelineSlider.Value = middleIndexPos;
                        }
                    }
                    else //make textbox editable
                    {
                        if (tb.IsReadOnly)
                        {
                            //as in AddEditCommentPos(), but textbox is already visible
                            tb.Background = Brushes.White;
                            tb.IsReadOnly = false;
                            tb.Cursor = System.Windows.Input.Cursors.IBeam;
                            tb.CaretBrush = Brushes.Black;
                            tb.CaretIndex = tb.Text.Length;
                            e.Handled = true; //prevents selection of a word on double-click.
                        }
                    }
                }
                else if (currentCommentPosIndex != -1) //if a marker is selected
                {
                    System.Windows.Controls.TextBox tb = ((System.Windows.Controls.TextBox)(CommentCanvas.Children[currentCommentPosIndex] as Canvas).Children[1]);
                    if (e.Source == ((Image)(CommentCanvas.Children[currentCommentPosIndex] as Canvas).Children[0])) //right-clicked on marker
                    {
                        //will be handled in CommentMarker_MouseLeftButtonDown
                        //in case of right click, we save the comment, removing the focus from it.
                        if (e.ChangedButton==MouseButton.Right)
                        {
                            SaveCommentPos(tb);
                        }                        
                    }
                    else //hide textbox, if clicked anywhere except the selected marker's image. Like CloseCommentPos, here we just set the index to -1.
                    {
                        //like CloseCommentPos(), but we already have the tb.
                        SaveCommentPos(tb); 
                        if (!settings["CommentsLocked"])
                        {
                            tb.Visibility = Visibility.Hidden;
                        }
                        currentCommentPosIndex = -1;
                        MainWindow1_MouseMove(null,null); //this ensures, that if the controlgrid is set to hiding, a click outside the comment hides the controlgrid, we do not have to move the mouse also.
                    }                    
                }
            }
        }

        private void MainWindow1_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (isPictureFullscreen && !movingImage)
            {
                Debug.Print("MainWindow1_PreviewMouseUp" + e.Source);
                if ((e.Source is Image && ((Image)e.Source).Name == "ImageElement1") || e.Source == this) //to avoid controlgrid clicks.
                //Source will be MainWindow, if the picture doesn't fill the whole screen.
                {
                    if (e.ChangedButton == MouseButton.Left)
                    {
                        NextContent(true);
                    }
                    else
                    {
                        PrevContent();
                    }
                }
            }
        }

        private void PrevContent()
        {
            Debug.Print("Prevcontent currentPicIndex: " + currentPicIndex);
            if (currentPicIndexExt != -1) //external file
            {
                if (currentPicIndexExt > 0)
                {
                    currentPicIndexExt--;
                }
                else //start from end
                {
                    currentPicIndexExt = filesExt.Count - 1;
                }
                if (isVideoFullscreen)
                {
                    ExitVideo();
                }
                if (isPictureFullscreen)
                {
                    ExitPicture();
                }
                LoadContentExt(filesExt[currentPicIndexExt]);
            }
            else
            {
                if (currentPicIndex > 0)
                {
                    if (selectedPicIndexes.Count <= 1) //select new item, remove selection from old. 
                    {
                        selectedPicIndexes.Clear();
                        SelectMultiple(currentPicIndex - 1);
                    }
                    currentPicIndex--;

                    if (isVideoFullscreen)
                    {
                        ExitVideo();
                    }
                    if (isPictureFullscreen)
                    {
                        ExitPicture();
                    }
                    LoadContent(((Border)Thumbs.Children[currentPicIndex]).Child, new System.Windows.Input.MouseEventArgs(System.Windows.Input.Mouse.PrimaryDevice, DateTime.Now.Millisecond));
                }
                else //exit video/picture view
                {
                    BorderRect.Visibility = Visibility.Hidden;
                    currentPicIndex = -1; //when exiting from the last item, nothing should be selected.
                    if (selectedPicIndexes.Count <= 1) //select new item, remove selection from old. 
                    {
                        selectedPicIndexes.Clear();
                        DrawMultiSelection();
                    }
                    ExitView();
                }
            }
        }

        private void NextContent(bool increaseIndex)
        {
            Debug.Print("NextContent increaseIndex " + increaseIndex + " currentPicIndex " + currentPicIndex + " currentPicIndexExt " + currentPicIndexExt);

            if (currentPicIndexExt != -1) //external file
            {
                int limit = increaseIndex ? filesExt.Count - 1 : filesExt.Count;
                int newIndex = increaseIndex ? currentPicIndexExt + 1 : currentPicIndexExt;

                if (currentPicIndexExt < limit)
                {
                    currentPicIndexExt = newIndex;
                }
                else //start from beginning
                {
                    currentPicIndexExt = 0;
                }
                if (isVideoFullscreen)
                {
                    ExitVideo();
                }
                if (isPictureFullscreen)
                {
                    ExitPicture();
                }
                if (filesExt.Count != 0)
                {
                    LoadContentExt(filesExt[currentPicIndexExt]);
                }
                else
                {
                    ExitView();
                }
            }
            else
            {
                int limit = increaseIndex ? Thumbs.Children.Count - 1 : Thumbs.Children.Count;
                int newIndex = increaseIndex ? currentPicIndex + 1 : currentPicIndex;

                Debug.Print("Nextcontent limit: " + limit + " newIndex: " + newIndex + " Thumbs count: " + Thumbs.Children.Count);

                if (currentPicIndex < limit)
                {                    
                    if (selectedPicIndexes.Count <= 1) //select new item, remove selection from old. 
                    {
                        selectedPicIndexes.Clear();
                        Debug.Print("nextContent selecting mulitple newIndex " + newIndex);
                        SelectMultiple(newIndex);
                        Debug.Print(String.Join(";", selectedPicIndexes));
                    }
                    currentPicIndex = newIndex;
                    if (isVideoFullscreen)
                    {
                        Debug.Print("Nextcontent exiting video");
                        ExitVideo();
                    }
                    if (isPictureFullscreen)
                    {
                        ExitPicture();
                    }
                    Debug.Print("NextContent loading content " + currentPicIndex);
                    LoadContent(((Border)Thumbs.Children[currentPicIndex]).Child, new System.Windows.Input.MouseEventArgs(System.Windows.Input.Mouse.PrimaryDevice, DateTime.Now.Millisecond));
                    Debug.Print("NextContent content loaded " + currentPicIndex);
                }
                else //exit video/picture view
                {
                    BorderRect.Visibility = Visibility.Hidden;
                    currentPicIndex = -1; //when exiting from the last item, nothing should be selected.
                    if (selectedPicIndexes.Count <= 1) //select new item, remove selection from old. 
                    {
                        selectedPicIndexes.Clear();
                        DrawMultiSelection();
                    }
                    ExitView();
                }
            }
        }

        private void MainWindow1_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e) //without preview, if we release the mouse above the slider, it will handle the event, so we don't get here. 
        {
            if (StartMarkerPressed)
            {
                StartMarkerPressed = false;
            }
            if (EndMarkerPressed)
            {
                EndMarkerPressed = false;
            }
        }

        private void MainWindow1_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (videoLoaded)
            {
                //Debug.Print("MainWindow1_MouseMove " + stw.ElapsedMilliseconds);
                if (enteringFullscreen && stw.ElapsedMilliseconds > 500) //stw started at media opening. Mousemove is called automatically a few ms after, but we will only show the cursor, if a certain time elapsed, to avoid accidental mouse movements. This will be the first time we move the mouse and make the cursor visible.
                {
                    //Debug.Print("MainWindow1_MouseMove 2, enteringFullscreen: " + enteringFullscreen + " " + stw.ElapsedMilliseconds);
                    enteringFullscreen = false;
                    this.Cursor = System.Windows.Input.Cursors.Arrow;
                    /*if (!isCursorVisible)
                    {
                        System.Windows.Forms.Cursor.Show();
                        isCursorVisible = true;
                    }*/
                    stw.Restart(); // this is to control disappearence after a period of mouse inactivity.
                }
                else if (!enteringFullscreen && !videoContextOpen) //if the context menu opens, stw is stopped and reset, and it will remain like that until the first mouse move after closing the menu.
                {
                    //Debug.Print("MainWindow1_MouseMove 2, stw.isRunning: " + stw.IsRunning);
                    if (stw.IsRunning == true) //cursor is still visible
                    {
                        stw.Reset(); //reset the stopwatch, so a new timeout period can start.
                    }
                    else //cursor was hidden, appearig now.
                    {
                        this.Cursor = System.Windows.Input.Cursors.Arrow;
                        /*if (!isCursorVisible)
                        {
                            System.Windows.Forms.Cursor.Show();
                            isCursorVisible = true;
                        } //cursor appears now, stopwatch is already reset.*/
                    }
                    stw.Start(); //we restart the stopwatch, whether the cursor was visible or not.
                }

                if (StartMarkerPressed)
                {
                    double startMargin = markerMargin - (System.Windows.Forms.Cursor.Position.X - markerCursorStartX);
                    if (startMargin > TimelineSlider.ActualWidth - 7.5) //so it does not go out of the slider. It means, the start marker cannot go below 0.
                    {
                        startMargin = TimelineSlider.ActualWidth - 7.5;
                    }
                    cutStart = (TimelineSlider.ActualWidth - startMargin - 7.5) / (TimelineSlider.ActualWidth - 15) * videoDuration;
                    if (cutStart > cutEnd)
                    {
                        cutStart = cutEnd;
                        startMargin = TimelineSlider.ActualWidth - 7.5 - cutStart * (TimelineSlider.ActualWidth - 15) / videoDuration;
                    }
                    StartMarkerTextCanvas.Margin = new Thickness(0, -31, startMargin - 0.5, 0);
                    StartMarker.Margin = new Thickness(0, -31, startMargin - 0.5, 0);

                    UpdateCutRect(false, true);
                }
                if (EndMarkerPressed)
                {
                    double endMargin = markerMargin + System.Windows.Forms.Cursor.Position.X - markerCursorStartX;
                    if (endMargin > TimelineSlider.ActualWidth - 7.5) //so it does not go out of the slider
                    {
                        endMargin = TimelineSlider.ActualWidth - 7.5;
                    }
                    cutEnd = (endMargin - 7.5) * videoDuration / (TimelineSlider.ActualWidth - 15);
                    if (cutEnd < cutStart)
                    {
                        cutEnd = cutStart;
                        endMargin = cutEnd * (TimelineSlider.ActualWidth - 15) / videoDuration + 7.5;
                    }
                    EndMarkerTextCanvas.Margin = new Thickness(endMargin - 0.5, -31, 0, 0);
                    EndMarker.Margin = new Thickness(endMargin - 0.5, -31, 0, 0);

                    UpdateCutRect(false, false);
                }
            }
            //Debug.Print("MainWindow1_MouseMove " + System.Windows.Forms.Cursor.Position.Y.ToString() + " " + !(bool)settings["SliderIsLocked"] + " " + !userIsDraggingSlider + " " + !StartMarkerPressed + " " + !EndMarkerPressed + " " + currentCommentPosIndex + " " + !videoControlGridIsVisible);
            //&& currentCommentPosIndex == -1  was taken out. Instead, we make controlgrid always visible only, if a comment text box is open
            var element = FocusManager.GetFocusedElement(this);
            if (!settings["SliderIsLocked"] && !userIsDraggingSlider && !(element is System.Windows.Controls.TextBox && ((System.Windows.Controls.TextBox)element).IsReadOnly == false) && !StartMarkerPressed && !EndMarkerPressed && !videoControlGridIsVisible && Mouse.PrimaryDevice.LeftButton != MouseButtonState.Pressed)//the moment we lock the slider, it is visible, so it will not change.
            {
                //Debug.Print("MainWindow1_MouseMove hiding controls? " + System.Windows.Forms.Cursor.Position.Y.ToString());
                if (System.Windows.Forms.Cursor.Position.Y < MainGrid.ActualHeight - 100)
                {
                    if (videoLoaded)
                    {
                        //Debug.Print("MainWindow1_MouseMove hiding controls " + System.Windows.Forms.Cursor.Position.Y.ToString());
                        VideoControlGrid.Visibility = Visibility.Hidden;
                    }
                    else if (isPictureFullscreen)
                    {
                        PictureControlGrid.Visibility = Visibility.Hidden;
                    }
                }
                else if (System.Windows.Forms.Cursor.Position.Y >= MainGrid.ActualHeight - VideoControlGrid.ActualHeight) //make no change up until 65 px above the bar
                {
                    if (videoLoaded)
                    {
                        VideoControlGrid.Visibility = Visibility.Visible;
                    }
                    else if (isPictureFullscreen)
                    {
                        PictureControlGrid.Visibility = Visibility.Visible;
                    }
                }
            }

            if (frameWindow != null && frameWindow.IsVisible) //If it has been opened, and is visible now. A closed window will not get null value.
            {
                if (frameWindow.dragStartX != -1 && e.LeftButton == MouseButtonState.Pressed)
                //without the last clause, the window keep moving after releasing the mouse left button, because this window doesn't register the mouseup event, if the mouse was pressed down inside the child window.
                {
                    double x = e.GetPosition(frameWindow.Rect).X;
                    double y = e.GetPosition(frameWindow.Rect).Y;
                    frameWindow.Left += x - frameWindow.dragStartX;
                    frameWindow.Top += y - frameWindow.dragStartY;
                }
                else //instead of a mouseUp event, we register the end of drag here.
                {
                    frameWindow.dragStartX = -1;
                }
            }
        }

        public void MainWindow1_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //When Ctrl+Right is pressed, this function is called 3 times: LeftCtrl, RIghtAlt, Right.
            //Debug.Print("MainWindow1_PreviewKeyDown, source: " + e.Source + ", key: " + e.Key + " thumbsMouseEnabledThumb " + thumbsMouseEnabledThumb + " thumbsMouseEnabledList " + thumbsMouseEnabledList);

            //no extra action, like "O" should happen at renaming a file. Also when editing comments, except when pressing right alt to switch comment.
            if (settingsPageOpen)
            {
                if (e.Source is System.Windows.Controls.TextBox && !(e.Key == Key.S && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))) //only Ctrl+S will do action
                {
                    return;
                }
            }
            else if (FileInfoGrid.Visibility == Visibility.Visible)
            {
                if (e.Key != Key.Escape && e.Key != Key.Enter)
                {
                    return;
                }
            }
            else
            {
                if (!thumbsMouseEnabledThumb || !thumbsMouseEnabledList || (e.Source is System.Windows.Controls.TextBox && ((System.Windows.Controls.TextBox)e.Source).IsReadOnly == false
                && !((e.Key == Key.Right || e.Key == Key.Left) && Keyboard.IsKeyDown(Key.RightAlt))))
                {
                    return;
                }
            }            

            object element; //used to check which control has the focus.

            switch (e.Key)
            {
                case Key.O:
                    if (!settingsPageOpen)
                    {
                        if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                        {
                            OpenContentSelector(null, null);
                            e.Handled = true;
                        }
                    }
                    break;

                case Key.Space:
                    if (videoLoaded)
                    {
                        if (isPlaying)
                        {
                            MediaElement1.Pause();
                            MediaElement1.IsMuted = true;
                            isPlaying = false;
                            ButtonPlayPause.ToolTip = "Play";
                            ButtonPlayPause.Source = new BitmapImage(new Uri(resourceDir + "play.png", UriKind.Absolute));
                            //System.Threading.Thread.Sleep(10); might be needed, because after pausing the video goes forward a little.

                            double pos = MediaElement1.Position.TotalMilliseconds;
                            GetMiddleIndexPos(pos);
                            TimelineSlider.Value = middleIndexPos;
                        }
                        else
                        {
                            MediaElement1.Play();
                            MediaElement1.IsMuted = false;
                            isPlaying = true;
                            ButtonPlayPause.ToolTip = "Pause";
                            ButtonPlayPause.Source = new BitmapImage(new Uri(resourceDir + "pause.png", UriKind.Absolute));
                        }
                        e.Handled = true;
                    }
                    break;

                case Key.Escape:
                    Debug.Print("Key.Escape currentCommentPosIndex " + currentCommentPosIndex);
                    if (FileInfoGrid.Visibility == Visibility.Visible) //the click should only close the info box
                    {
                        FileInfoGrid.Visibility = Visibility.Hidden;
                        currentPicIndex = infoContextItemIndex;
                        infoContextItemIndex = -1;
                        // ThumbScroll.Focusable = true;
                        ThumbScroll.Focus();
                        // ThumbScroll.Focusable = false;
                    }
                    else if (settingsPageOpen)
                    {
                        SettingsCancelButton_Click(null, null);
                    }
                    else if (isVideoFullscreen)
                    {
                        //hide text box, if the comments are set to hiding, and ControlGrid is visible.
                        if (currentCommentPosIndex != -1 && !settings["CommentsLocked"] && VideoControlGrid.Visibility == Visibility.Visible)
                        {
                            //as in CloseCommentPos(), but comment is already saved.                            
                            System.Windows.Controls.TextBox tb = ((System.Windows.Controls.TextBox)(CommentCanvas.Children[currentCommentPosIndex] as Canvas).Children[1]);
                            tb.Visibility = Visibility.Hidden;
                            currentCommentPosIndex = -1;
                        }
                        else
                        {
                            ExitView();
                        }
                    }
                    else if (isPictureFullscreen)
                    {
                        //exiting enlarged view.
                        if (isPictureFullscreen && (Math.Round(ImageElement1.ActualWidth) > Math.Round(MainGrid.ActualWidth) || Math.Round(ImageElement1.ActualHeight) > Math.Round(MainGrid.ActualHeight))) //if in actualSizeView, and the image is larger than the screen
                        {
                            SetImageActualSize(null, null);
                        }
                        else
                        {
                            ExitView();
                        }
                    }
                    else //thumbnail view
                    {
                        if (ListNewFieldWindow.Visibility == Visibility.Visible)
                        {
                            ListNewFieldWindow.Visibility = Visibility.Hidden;
                        }
                        else //removing cursor and selection (cursor might already be invisible)
                        {
                            UnselectAll_Click(null, null);
                        }
                    }

                    e.Handled = true;
                    break;

                case Key.M:
                    if (currentPicIndexExt == -1 && isVideoFullscreen && videoSource.IndexOf(settings["SkillsPath"]) != -1)
                    {
                        VideoControlGrid.Visibility = Visibility.Visible;
                        videoControlGridIsVisible = true;
                        MarkPosition_Click(null, null);
                        AddEditCommentPos();
                    }
                    e.Handled = true;
                    break;

                case Key.D1:
                case Key.D2:
                case Key.D3:
                case Key.D4:
                case Key.D5:
                case Key.D6:
                case Key.D7:
                case Key.D8:
                case Key.D9:
                    if (isVideoFullscreen) //select marker
                    {
                        if (Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt)) //marker
                        {
                            int num = int.Parse(e.Key.ToString().Replace("D", ""));
                            if (currentCommentPosIndex != -1)
                            {
                                CloseCommentPos();
                            }
                            if (commentPositions.Count != 0)
                            {
                                currentCommentPosIndex = (num <= commentPositions.Count) ? num - 1 : commentPositions.Count - 1; //if the pressed number is greater than the number of comments we select the last one.
                                SelectCommentPos();
                            }
                            //no need to make it visible
                            //VideoControlGrid.Visibility = Visibility.Visible; //if the controls are hidden, moving the mouse to the bottom of screen will not make them visible after currentCommentPosIndex is set.
                        }
                    }
                    else if (!isPictureFullscreen && !settingsPageOpen) //thumbnail view
                    {
                        element = FocusManager.GetFocusedElement(this);
                        if (element == null || element == ThumbScroll)                        
                        {
                            if (element == null)
                            {
                                // ThumbScroll.Focusable = true;
                                ThumbScroll.Focus();
                                // ThumbScroll.Focusable = false;                                
                            }
                            int newIndex = int.Parse(e.Key.ToString().Replace("D", "")) - 1;
                            
                            if (SelectMultiple(newIndex))
                            {
                                currentPicIndex = newIndex;
                                PositionBorderRect(currentPicIndex, true);
                                BorderRect.Visibility = Visibility.Visible;
                            }
                        }
                        else if (element == ThumbSizeSlider)
                        {
                            ThumbSizeSlider.Value = int.Parse(e.Key.ToString().Replace("D", ""));
                        }
                    }
                    break;

                case Key.A:
                    if (!isVideoFullscreen && !isPictureFullscreen && !settingsPageOpen)
                    {
                        //scrollviewer focus is not needed, like at the numbers
                        if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) //select all
                        {
                            SelectAll_Click(null, null);
                        }
                    }
                    else if (isPictureFullscreen)
                    {
                        SetImageActualSize(null,null);
                    }
                    break;

                case Key.Left:
                    Debug.Print("Key.Left " + currentPicIndex + " " + settingsPageOpen);

                    if (isVideoFullscreen) //when several modified keys are pressed, conditions will run according to their order.
                    {
                        if (Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt)) //marker
                        {
                            if (currentCommentPosIndex != -1)
                            {
                                CloseCommentPos();
                                currentCommentPosIndex = (currentCommentPosIndex > 0) ? currentCommentPosIndex - 1 : commentPositions.Count - 1;
                                SelectCommentPos();
                                //VideoControlGrid.Visibility = Visibility.Visible;
                            }
                            else if (commentPositions.Count != 0)
                            {
                                currentCommentPosIndex = 0;
                                SelectCommentPos();
                                //VideoControlGrid.Visibility = Visibility.Visible;
                            }
                        }
                        else if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) //jump
                        {
                            if (isPlaying) //jump while playing (allowed with Ctrl)
                            {
                                MediaElement1.Position = TimeSpan.FromMilliseconds(MediaElement1.Position.TotalMilliseconds - (double)settings["JumpValue"]);
                                middleIndexPos = 0;
                            }
                            else //jump while paused
                            {
                                middleIndexPos -= (double)settings["JumpValue"];
                                middleIndexPos = (middleIndexPos < 0) ? 0 : middleIndexPos;
                                GetMiddleIndexPos(middleIndexPos); //recalculate center of frame.
                                MediaElement1.Position = TimeSpan.FromMilliseconds(middleIndexPos);
                                TimelineSlider.Value = middleIndexPos;
                            }
                        }                        
                        else if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)) //previous media
                        {
                            PrevContent();
                        }
                        else //jump or frame step
                        {
                            if (isPlaying) //jump while playing
                            {
                                MediaElement1.Position = TimeSpan.FromMilliseconds(MediaElement1.Position.TotalMilliseconds - (double)settings["JumpValue"]);
                                middleIndexPos = 0;
                            }
                            else //frame step
                            {
                                if (settings["SkillsPath"] != "" && File.Exists(OrigToIndex(videoSource))) // if the index of frame exists
                                {
                                    currentFrameIndex--;
                                    if (currentFrameIndex >= 0)
                                    {
                                        currentFrameIndexPos = frameIndex[currentFrameIndex];
                                        secondcurrentFrameIndexPos = frameIndex[currentFrameIndex + 1];
                                        middleIndexPos = (currentFrameIndexPos + secondcurrentFrameIndexPos) / 2;
                                        MediaElement1.Position = TimeSpan.FromMilliseconds(middleIndexPos);
                                        TimelineSlider.Value = middleIndexPos;
                                    }
                                    else
                                    {
                                        currentFrameIndex = 0; //do not allow index to decrease, so we can step forward.
                                    }
                                }
                                else
                                {
                                    middleIndexPos -= videoFrameLength;
                                    middleIndexPos = (middleIndexPos < 0) ? 0 : middleIndexPos;
                                    MediaElement1.Position = TimeSpan.FromMilliseconds(middleIndexPos);
                                    TimelineSlider.Value = middleIndexPos;
                                }
                            }
                        }
                        e.Handled = true;
                    }
                    else if (isPictureFullscreen) //previous media
                    {
                        if (Math.Round(ImageElement1.ActualWidth) > Math.Round(MainGrid.ActualWidth) || Math.Round(ImageElement1.ActualHeight) > Math.Round(MainGrid.ActualHeight)) //if in actualSizeView, and the image is larger than the screen
                        {
                            if (Math.Round(ImageElement1.ActualWidth) > Math.Round(MainGrid.ActualWidth))
                            {
                                double left = ImageElement1.Margin.Left;
                                double top = ImageElement1.Margin.Top;
                                double newLeft = left + settings["ImageMoveStep"];
                                newLeft = newLeft > 0 ? 0 : newLeft;
                                ImageElement1.Margin = new Thickness(newLeft, top, 0, 0);
                            }
                        }
                        else
                        {
                            PrevContent();
                            e.Handled = true;
                        }
                            
                    }
                    else if (currentPicIndex != -1 && !settingsPageOpen) //moving cursor rectangle
                    {

                        element = FocusManager.GetFocusedElement(this);
                        //if (!(element is ListBoxItem || element is System.Windows.Controls.ComboBox || element is CustomSlider)) //if the focus is not on the controls
                        if (element == ThumbScroll)
                        {
                            int newIndex = (currentPicIndex > 0) ? currentPicIndex - 1 : Thumbs.Children.Count - 1;
                            if (SelectMultiple(newIndex))
                            {
                                currentPicIndex = newIndex;
                                PositionBorderRect(currentPicIndex, true);
                            }
                        }
                    }
                    break;

                case Key.Right:
                    if (isVideoFullscreen) //when several modified keys are pressed, conditions will run according to their order.
                    {
                        //left alt does not register, no keypress registers in that case. Right alt registers as left control down and right alt down.
                        if (Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt)) //marker
                        {
                            if (currentCommentPosIndex != -1)
                            {
                                CloseCommentPos();
                                currentCommentPosIndex = (currentCommentPosIndex < commentPositions.Count - 1) ? currentCommentPosIndex + 1 : 0;
                                SelectCommentPos();
                                //VideoControlGrid.Visibility = Visibility.Visible;
                            }
                            else if (commentPositions.Count != 0)
                            {
                                currentCommentPosIndex = 0;
                                SelectCommentPos();
                                //VideoControlGrid.Visibility = Visibility.Visible;
                            }

                        }
                        else if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) //jump
                        {
                            if (isPlaying) //jump while playing (allowed with Ctrl)
                            {
                                MediaElement1.Position = TimeSpan.FromMilliseconds(MediaElement1.Position.TotalMilliseconds + (double)settings["JumpValue"]);
                                middleIndexPos = 0;
                            }
                            else //jump while paused
                            {
                                middleIndexPos += (double)settings["JumpValue"];
                                middleIndexPos = (middleIndexPos > videoDuration) ? videoDuration : middleIndexPos;
                                GetMiddleIndexPos(middleIndexPos); //recalculate center of frame.
                                MediaElement1.Position = TimeSpan.FromMilliseconds(middleIndexPos);
                                TimelineSlider.Value = middleIndexPos;
                            }
                        }                        
                        else if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)) //next media
                        {
                            NextContent(true);
                        }
                        else //jump or frame step
                        {
                            if (isPlaying) //jump while playing
                            {
                                MediaElement1.Position = TimeSpan.FromMilliseconds(MediaElement1.Position.TotalMilliseconds + (double)settings["JumpValue"]);
                                middleIndexPos = 0;
                            }
                            else //frame step
                            {
                                if (settings["SkillsPath"] != "" && File.Exists(OrigToIndex(videoSource))) //if the index of frames exist
                                {
                                    currentFrameIndex++;
                                    if (currentFrameIndex < frameIndex.Count - 1)
                                    {
                                        currentFrameIndexPos = frameIndex[currentFrameIndex];
                                        secondcurrentFrameIndexPos = frameIndex[currentFrameIndex + 1];
                                        middleIndexPos = (currentFrameIndexPos + secondcurrentFrameIndexPos) / 2;
                                        MediaElement1.Position = TimeSpan.FromMilliseconds(middleIndexPos);
                                        TimelineSlider.Value = middleIndexPos;
                                        //Debug.Print("Key.Right " + currentFrameIndexPos + " " + secondcurrentFrameIndexPos + " " + middleIndexPos);
                                    }
                                    else if (currentFrameIndex == frameIndex.Count - 1) //last frame, we use the length of the video as second frame value
                                    {
                                        currentFrameIndexPos = frameIndex[currentFrameIndex];
                                        secondcurrentFrameIndexPos = videoDuration;
                                        middleIndexPos = (currentFrameIndexPos + secondcurrentFrameIndexPos) / 2;
                                        MediaElement1.Position = TimeSpan.FromMilliseconds(middleIndexPos);
                                        TimelineSlider.Value = middleIndexPos;
                                    }
                                    else
                                    {
                                        currentFrameIndex = frameIndex.Count - 1; //do not allow index to increase, so we can step backwards.
                                    }
                                }
                                else
                                {
                                    middleIndexPos += videoFrameLength;
                                    middleIndexPos = (middleIndexPos > videoDuration) ? videoDuration : middleIndexPos;
                                    MediaElement1.Position = TimeSpan.FromMilliseconds(middleIndexPos);
                                    TimelineSlider.Value = middleIndexPos;
                                }
                            }
                        }
                        e.Handled = true;
                    }
                    else if (isPictureFullscreen) //move enlarged picture, or next media
                    {
                        if (Math.Round(ImageElement1.ActualWidth) > Math.Round(MainGrid.ActualWidth) || Math.Round(ImageElement1.ActualHeight) > Math.Round(MainGrid.ActualHeight)) //if in actualSizeView, and the image is larger than the screen
                        {
                            if (Math.Round(ImageElement1.ActualWidth) > Math.Round(MainGrid.ActualWidth))
                            {
                                double left = ImageElement1.Margin.Left;
                                double top = ImageElement1.Margin.Top;
                                double newLeft = left - settings["ImageMoveStep"];
                                newLeft = newLeft < MainGrid.ActualWidth - ImageElement1.ActualWidth ? MainGrid.ActualWidth - ImageElement1.ActualWidth : newLeft;
                                ImageElement1.Margin = new Thickness(newLeft, top, 0, 0);
                            }
                        }
                        else
                        {
                            NextContent(true);
                            e.Handled = true;
                        }
                    }
                    else if (currentPicIndex != -1 && !settingsPageOpen) //moving cursor rectangle
                    {
                        element = FocusManager.GetFocusedElement(this);
                        //if (!(element is ListBoxItem || element is System.Windows.Controls.ComboBox || element is CustomSlider)) //if the focus is not on the controls
                        if (element == ThumbScroll)
                        {
                            int newIndex = (currentPicIndex < Thumbs.Children.Count - 1) ? currentPicIndex + 1 : 0;
                            if (SelectMultiple(newIndex))
                            {
                                currentPicIndex = newIndex;
                                PositionBorderRect(currentPicIndex, true);
                            }
                        }
                    }
                    break;

                case Key.Down: //previous keyframe
                    if (isVideoFullscreen && keyFrames.Count != 0 && !isPlaying) //if frames have been or being extracted
                    {
                        double lastKeyframe = keyFrames[keyFrames.Count - 1];
                        if (lastKeyframe >= middleIndexPos || extVideoSource != videoSource) //we can certainly get the preceding keyframe, the frames has been extracted until the current position.
                        //lastKeyFrame cannot be equal to middleIndexPos, because the first is the start of a frame, and the latter is the middle.
                        //Except if middleIndexPos is already set to a keyframe.
                        //using extVideoSource we can decide if we are just standing at the end of a video.
                        {
                            double currentKey = GetPrevKeyFrame(middleIndexPos); // getting the keyframe of the current position. Cannot be equal to middleIndexPos.
                            double prevKey = (TimelineSlider.Value == currentKey) ? GetPrevKeyFrame(currentKey - 1) : currentKey; //stepping back, if we are already at a keyframe.                                                       
                            middleIndexPos = prevKey; //now it is not going to be the middle, but it will not affect frame by frame playback. Need to be on frame start for correct cutting marker pos.
                            GetMiddleIndexPos(middleIndexPos); //to get the currentframeindex
                            MediaElement1.Position = TimeSpan.FromMilliseconds(prevKey);
                            TimelineSlider.Value = prevKey; //this time we display the frame start, not the middle.
                        }
                    }
                    else if (isPictureFullscreen)
                    {
                        if (Math.Round(ImageElement1.ActualWidth) > Math.Round(MainGrid.ActualWidth) || Math.Round(ImageElement1.ActualHeight) > Math.Round(MainGrid.ActualHeight)) //if in actualSizeView, and the image is larger than the screen
                        {
                            if (Math.Round(ImageElement1.ActualHeight) > Math.Round(MainGrid.ActualHeight))
                            {
                                double left = ImageElement1.Margin.Left;
                                double top = ImageElement1.Margin.Top;
                                double newTop = top - settings["ImageMoveStep"];
                                newTop = newTop < MainGrid.ActualHeight - ImageElement1.ActualHeight ? MainGrid.ActualHeight - ImageElement1.ActualHeight : newTop;
                                ImageElement1.Margin = new Thickness(left, newTop, 0, 0);
                            }
                        }
                    }
                    else if (!isPictureFullscreen && currentPicIndex != -1 && !settingsPageOpen) //moving cursor rectangle
                    {
                        element = FocusManager.GetFocusedElement(this);
                        if (element == ThumbScroll)
                        {
                            int thumbRow = (int)ThumbSizeSlider.Value;
                            int newIndex = currentPicIndex + thumbRow;
                            newIndex = (newIndex < Thumbs.Children.Count) ? newIndex : currentPicIndex;
                            if (SelectMultiple(newIndex))
                            {
                                currentPicIndex = newIndex;
                                PositionBorderRect(currentPicIndex, true);
                            }
                            e.Handled = true;
                        }
                    }
                    break;

                case Key.Up: //next keyframe
                    Debug.Print("Key.Up skillslist focused " + SkillsList.IsFocused);
                    if (isVideoFullscreen && keyFrames.Count != 0 && !isPlaying) //if frames have been or being extracted
                    {
                        double lastKeyframe = keyFrames[keyFrames.Count - 1];
                        if (lastKeyframe >= middleIndexPos || extVideoSource != videoSource) //we can certainly get the preceding keyframe, the frames has been extracted until the current position.
                        //using extVideoSource we can decide if we are just standing at the end of a video. 
                        //lastKeyFrame cannot be equal to middleIndexPos, because the first is the start of a frame, and the latter is the middle.
                        //Except if middleIndexPos is already set to a keyframe.
                        {
                            double currentKey = GetPrevKeyFrame(middleIndexPos); // getting the keyframe of the current position. Cannot be equal to middleIndexPos.
                            double nextKey = GetNextKeyFrame(currentKey); //stepping forward. If we are at the end of the frames list, nextKey will be the same as currentKey.                                                    
                            middleIndexPos = nextKey; //now it is not going to be the middle, but it will not affect frame by frame playback. Need to be on frame start for correct cutting marker pos.
                            GetMiddleIndexPos(middleIndexPos); //to get the currentframeindex
                            MediaElement1.Position = TimeSpan.FromMilliseconds(nextKey);
                            TimelineSlider.Value = nextKey; //this time we display the frame start, not the middle.
                        }
                    }
                    else if (isPictureFullscreen)
                    {
                        if (Math.Round(ImageElement1.ActualWidth) > Math.Round(MainGrid.ActualWidth) || Math.Round(ImageElement1.ActualHeight) > Math.Round(MainGrid.ActualHeight)) //if in actualSizeView, and the image is larger than the screen
                        {
                            if (Math.Round(ImageElement1.ActualHeight) > Math.Round(MainGrid.ActualHeight))
                            {
                                double left = ImageElement1.Margin.Left;
                                double top = ImageElement1.Margin.Top;
                                double newTop = top + settings["ImageMoveStep"];
                                newTop = newTop > 0 ? 0 : newTop;
                                ImageElement1.Margin = new Thickness(left, newTop, 0, 0);
                            }
                        }
                    }
                    else if (!isPictureFullscreen && currentPicIndex != -1 && !settingsPageOpen) //moving cursor rectangle
                    {
                        element= FocusManager.GetFocusedElement(this);
                        if (element == ThumbScroll)
                        {
                            int thumbRow = (int)ThumbSizeSlider.Value;
                            int newIndex = currentPicIndex - thumbRow;
                            newIndex = (newIndex >= 0) ? newIndex : currentPicIndex;
                            if (SelectMultiple(newIndex))
                            {
                                currentPicIndex = newIndex;
                                PositionBorderRect(currentPicIndex, true);
                            }
                            e.Handled = true;
                        }
                    }
                    break;

                case Key.Enter:
                    if (FileInfoGrid.Visibility == Visibility.Visible) //the close the info box
                    {
                        FileInfoGrid.Visibility = Visibility.Hidden;
                        currentPicIndex = infoContextItemIndex;
                        infoContextItemIndex = -1;
                        // ThumbScroll.Focusable = true;
                        ThumbScroll.Focus();
                        // ThumbScroll.Focusable = false;
                    }
                    else if (!isVideoFullscreen && !isPictureFullscreen && currentPicIndex != -1 && !settingsPageOpen) //loading cursor rectangle content
                    {
                        element = FocusManager.GetFocusedElement(this);
                        if (element == ThumbScroll)
                        {
                            LoadContent(((Border)Thumbs.Children[currentPicIndex]).Child, null);
                            e.Handled = true;
                        }
                    }
                    else if (currentCommentPosIndex != -1)
                    {
                        tbOpening = true;
                        AddEditCommentPos(); //so we don't have to use the mouse to edit the comment
                    }
                    break;
                case Key.F2:
                    if (currentCommentPosIndex != -1)
                    {
                        tbOpening = true;
                        AddEditCommentPos(); //so we don't have to use the mouse to edit the comment
                    }
                    break;

                case Key.PageUp: //selection start
                    if (isVideoFullscreen)
                    {
                        if (!cutSelectionSet) //if the keyframes have not yet been drawn. We cannot draw them at LoadVideo, because TimelineSlider is wider than now.
                        {
                            cutSelectionSet = true;
                            DrawKeyFrames();//if extraction is running, that process draws keyframes one by one. Some keyframes will be drawn once again, but it doesn't matter.                           
                        }
                        if (isPlaying)
                        {
                            cutStart = MediaElement1.Position.TotalMilliseconds;
                        }
                        else //paused
                        {
                            cutStart = middleIndexPos;
                        }
                        //Debug.Print("pageup: " + TimelineSlider.Value);
                        cutEnd = (cutStart > cutEnd) ? cutStart : cutEnd;
                        KeyFrameCanvas.Visibility = Visibility.Visible;
                        UpdateCutRect(true, true);
                        e.Handled = true;
                    }
                    else if (!isPictureFullscreen && currentPicIndex != -1 && !settingsPageOpen) //moving cursor rectangle
                    {
                        element = FocusManager.GetFocusedElement(this);
                        if (element == ThumbScroll)
                        {
                            int rowChange = (int)Math.Floor(ThumbScroll.ActualHeight / (thumbH + 1));
                            int newIndex = currentPicIndex - rowChange * (int)ThumbSizeSlider.Value;
                            if (newIndex < 0) //move cursor to the first line
                            {
                                newIndex = currentPicIndex;
                                do
                                {
                                    newIndex -= (int)ThumbSizeSlider.Value;
                                }
                                while (newIndex >= 0);
                                newIndex += (int)ThumbSizeSlider.Value;
                            }

                            if (SelectMultiple(newIndex))
                            {
                                currentPicIndex = newIndex;
                                PositionBorderRect(currentPicIndex, true);
                            }
                            e.Handled = true;
                        }
                    }
                    break;

                case Key.PageDown: //selection end
                    if (isVideoFullscreen)
                    {
                        if (!cutSelectionSet) //if the keyframes have not yet been drawn. We cannot draw them at LoadVideo, because TimelineSlider is wider than now.
                        {
                            cutSelectionSet = true;
                            DrawKeyFrames();//if extraction is running, that process draws keyframes one by one. Some keyframes will be drawn once again, but it doesn't matter.
                        }
                        if (isPlaying)
                        {
                            cutEnd = MediaElement1.Position.TotalMilliseconds;
                        }
                        else //paused
                        {
                            cutEnd = middleIndexPos;
                        }
                        cutStart = (cutEnd < cutStart) ? cutEnd : cutStart;
                        KeyFrameCanvas.Visibility = Visibility.Visible;
                        UpdateCutRect(true, false);
                        e.Handled = true;
                    }
                    else if (!isPictureFullscreen && currentPicIndex != -1 && !settingsPageOpen) //moving cursor rectangle
                    {
                        element = FocusManager.GetFocusedElement(this);
                        if (element == ThumbScroll)
                        {
                            int rowChange = (int)Math.Floor(ThumbScroll.ActualHeight / (thumbH + 1));
                            int newIndex = currentPicIndex + rowChange * (int)ThumbSizeSlider.Value;
                            if (newIndex >= Thumbs.Children.Count) //move cursor to the first line
                            {
                                newIndex = currentPicIndex;
                                do
                                {
                                    newIndex += (int)ThumbSizeSlider.Value;
                                }
                                while (newIndex < Thumbs.Children.Count);
                                newIndex -= (int)ThumbSizeSlider.Value;
                            }

                            if (SelectMultiple(newIndex))
                            {
                                currentPicIndex = newIndex;
                                PositionBorderRect(currentPicIndex, true);
                            }
                            e.Handled = true;
                        }
                    }
                    break;

                case Key.Delete: //delete folder or media, or comment
                    Debug.Print("Key.Delete " + currentPicIndex + Keyboard.IsKeyDown(Key.LeftCtrl) + Keyboard.IsKeyDown(Key.RightAlt)+ currentCommentPosIndex);
                    if (SkillsList.IsKeyboardFocusWithin)
                    {
                        skillsListItem = (string)SkillsList.SelectedItem;
                        skillsListIndex = SkillsList.SelectedIndex;
                        ListDelete_Click(null, null);
                    }
                    /*if (FocusManager.GetFocusedElement(this) is ListBoxItem)
                    {
                        ListBoxItem li = (ListBoxItem)FocusManager.GetFocusedElement(this);
                        Debug.Print(li.ToString()); //VisualTreeHelper returns: VirtualizingStackPanel, itemsPresenter, SCrollContentPresenter , li.Parent returns null
                    }*/
                    else if (isVideoFullscreen && currentCommentPosIndex != -1 && Keyboard.IsKeyDown(Key.RightAlt))
                    {
                        int tempcurrentCommentPosIndex = currentCommentPosIndex;
                        CommentMarkerMenuRemove_Click(null, null); //resets currentCommentPosIndex
                        if (tempcurrentCommentPosIndex < commentPositions.Count) //select next comment
                        {
                            currentCommentPosIndex = tempcurrentCommentPosIndex;
                            SelectCommentPos();
                        }
                    }
                    else if (isVideoFullscreen || isPictureFullscreen)
                    {
                        Context_Delete(null, null, true);
                    }
                    else if (!settingsPageOpen) //delete selected items in thumbnail view
                    {
                        DeleteSelected_Click(null, null); //the function will check if there are selected items.
                    }
                    break;

                case Key.R:
                    if (!settingsPageOpen && !isPictureFullscreen && !isVideoFullscreen && currentPicIndex != -1 && ThumbScroll.IsFocused) //rename selected item in thumbnail view
                    {                        
                        Rename_Click(null,null);
                        e.Handled = true; //so r is not written into the textbox
                    }
                    break;

                case Key.I:
                    Debug.Print("Key.I currentPicIndex " + currentPicIndex + " " + ThumbScroll.IsFocused + " " + FocusManager.GetFocusedElement(this));
                    if (!settingsPageOpen && currentPicIndex != -1 && (ThumbScroll.IsFocused || FocusManager.GetFocusedElement(this) is System.Windows.Controls.TextBox)) //if we close a comment, the focus remains on the textbox.
                    {
                        Context_ShowInfo(null, null);
                    }
                    else if (isPictureFullscreen || isVideoFullscreen) //for external files
                    {
                        Context_ShowInfo(null, null);
                    }
                    break;

                case Key.C: //clear selection
                    if (isVideoFullscreen)
                    {
                        ClearCutRect();
                    }
                    break;

                case Key.S:
                    if (settingsPageOpen && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))) //save settings
                    {
                        var focusedEl = FocusManager.GetFocusedElement(this);
                        if (focusedEl is System.Windows.Controls.TextBox)
                        {
                            if (focusedEl == SettingSkillsPath)
                            {
                                SettingSkillsPath_LostFocus(focusedEl, null);
                            }
                            else if (focusedEl is NumericField)
                            {
                                SettingNumericField_LostFocus(focusedEl, null);
                            }
                            else
                            {
                                SettingFilteredField_LostFocus(focusedEl, null);
                            }
                        }
                        SettingsSaveButton_Click(null, null);
                    }
                    if (isVideoFullscreen && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && cutSelectionSet) //cut video
                    {
                        if (cutStartActual == -1) //wait until we get it.
                        {
                            cutSaveCalled = true;
                            StatusTextVideo.Text = "Extracting preceding keyframe...";
                            StatusTextVideo.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            CutVideo();
                        }
                        e.Handled = true;
                    }
                    break;
                case Key.F7: //changes fullscreen state in thumbnail and settings view
                    if (!isVideoFullscreen && !isPictureFullscreen && !settingsPageOpen && Directory.Exists(settings["SkillsPath"])) //no exit fullscreen in view mode.
                    {
                        ListNew_Click(null,null);
                    }
                    break;

                case Key.F11: //changes fullscreen state in thumbnail and settings view
                    if (!isVideoFullscreen && !isPictureFullscreen) //no exit fullscreen in view mode.
                    {
                        if (this.WindowStyle == WindowStyle.None)
                        {
                            ExitFullScreen(true);
                        }
                        else
                        {
                            EnterFullScreen(true);
                        }
                    }
                    break;
            }
        }

        private void CutVideo()
        {
            savingCutVideo = true;

            string file = MediaElement1.Source.LocalPath;
            string dir = System.IO.Path.GetDirectoryName(file) + "\\";
            string fileWoExt = System.IO.Path.GetFileNameWithoutExtension(file);
            string ext = System.IO.Path.GetExtension(file);
            string renameRule = settings["RenameRule"];
            string newFile;

            if (renameRule.IndexOf("[N]") != -1)
            {
                int n = 0;
                do
                {
                    n++;
                    newFile = dir + fileWoExt + renameRule.Replace("[N]", n.ToString()) + ext;
                } while (File.Exists(newFile));
            }
            else
            {
                newFile = dir + fileWoExt + renameRule + ext;
            }

            if (settings["SaveDialog"])
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "mp4 files (*.mp4)|*.mp4";
                if (settings["RememberDir"])
                {
                    saveFileDialog1.RestoreDirectory = true; //uses the previously selected directory, when we exited with ok. Remains after the program is closed for the next run.
                }
                else
                {
                    saveFileDialog1.InitialDirectory = dir;
                }

                saveFileDialog1.FileName = System.IO.Path.GetFileName(newFile);

                if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
                else
                {
                    newFile = saveFileDialog1.FileName;
                }
            }

            Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle); //otherwise StatusText with the filename will not be visible

            StatusTextVideo.Text = "Saving " + System.IO.Path.GetFileName(newFile);
            StatusTextVideo.Visibility = Visibility.Visible;

            Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle);

            double duration = cutEndOffset - cutStartActual;
            string command = "-y -ss " + Convert.ToString(cutStartActual / 1000, CultureInfo.InvariantCulture) + " -i \"" + file + "\" -to " + Convert.ToString(duration / 1000, CultureInfo.InvariantCulture) + " -c copy \"" + newFile + "\"";
            Debug.Print(command);
            var process = new Process();
            var startInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                FileName = @"resources\ffmpeg.exe",
                Arguments = command
            };
            process.StartInfo = startInfo;

            process.Start();
            process.WaitForExit();

            string msg = "Cut video saved to " + newFile;

            if (settings["IncludeMarkers"])
            {
                List<string> newMarkers = new List<string>();

                for (int i = 0; i < commentPositions.Count; i++)
                {
                    double pos = commentPositions[i];
                    if (pos >= cutStartActual && pos <= cutEndOffset)
                    {
                        double newpos = pos - cutStartActual;
                        newMarkers.Add(newpos.ToString(CultureInfo.InvariantCulture) + "\t" + commentPositionComments[i]);
                    } 
                }
                if (newMarkers.Count != 0)
                {
                    File.WriteAllLines(OrigToComment(newFile), newMarkers);
                    msg = "Cut video with markers saved to " + newFile;
                }
            }

            string thumb = settings["SkillsPath"] != "" ? OrigToThumb(newFile) : "";
            
            if (File.Exists(thumb))
            {
                File.Delete(thumb);
                RemoveThumb(thumb,false);//so the thumbnail will be refreshed.   
            }

            Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle); //so that the thumbnail will be refreshed

            if (settings["SuccessDialog"])
            {
                Msgbox(msg);
                if (StartMarkerPressed) //if the video was saved while dragging the markers, releasing the mouse button whle the message box is visible will not register MainWindow mouseup event.
                {
                    StartMarkerPressed = false;
                }
                if (EndMarkerPressed)
                {
                    EndMarkerPressed = false;
                }
                //Activating the window will call StartUpdateThumbs() now.
            }
            else
            {
                StartUpdateThumbs();
            }

            StatusTextVideo.Visibility = Visibility.Hidden;            
        }

        #endregion

        #region Size changed

        //When maximizing the window, the order of events are: Position change, State change, Size change.
        //In the Position change handler we don't know if the window is going to be maximized, or was just dragged.
        //in the State change event handler, if the window was maximized, we revert the position values.
        //private DispatcherTimer locChangeTimer;
        //private Stopwatch locChangeStw; // max 25 ms.

        private void MainWindow1_LocationChanged(object sender, EventArgs e)
        {

            if (changedByProgramWindow || changedByProgramInit) return;

            if (this.WindowState == WindowState.Normal)
            {
                //Debug.Print("Location changed, left: " + Left + " top: " + Top);
                //locChangeStw = new Stopwatch();
                //locChangeStw.Start();

                /*if (locChangeTimer != null) //in case the function is called quickly repeatedly.
                {
                    locChangeTimer.Stop();
                    locChangeTimer = null;
                }
                locChangeTimer = new DispatcherTimer();
                locChangeTimer.Interval = TimeSpan.FromMilliseconds(35);
                locChangeTimer.Tick += LocChangeTimer_Tick;  
                locChangeTimer.Start();*/

                //user moving window
                SaveSetting("NormalScreenLeft", (int)this.Left); //-8, -8 when we maximize the window (without going full screen), but in MainWindow1_StateChanged the values will be restored. 
                SaveSetting("NormalScreenTop", (int)this.Top);
                SaveSetting("WindowStartupLocationCenterScreen", false); //if the user moves the window, we set this to false, even if the new positon accidentally matches the center.

                if (settingsPageOpen)
                {
                    SettingNormalScreenLeft.Text = ((int)settings["NormalScreenLeft"]).ToString();
                    SettingNormalScreenTop.Text = ((int)settings["NormalScreenTop"]).ToString();
                    SettingWindowStartupLocationCenterScreen.IsChecked = settings["WindowStartupLocationCenterScreen"];
                }
            }
        }

        /*private void LocChangeTimer_Tick(object sender, EventArgs e)
        {
            Debug.Print("LocChangeTimer, Left: " + Left + " Top " + Top + " settingspageopen " + settingsPageOpen);
            locChangeTimer.Stop();
            locChangeTimer = null;

            /*SaveSetting("NormalScreenLeft", this.Left);
            SaveSetting("NormalScreenTop", this.Top);
            if (settingsPageOpen)
            {
                SettingNormalScreenLeft.Text = settings["NormalScreenLeft"];
                SettingNormalScreenTop.Text = settings["NormalScreenTop"];
            }
        }*/

        private void MainWindow1_StateChanged(object sender, EventArgs e)
        {
            if (changedByProgramWindow || changedByProgramInit) return; //on startup, or entering video/picture view. Settings page is certainly not visible.

            if (this.WindowState == WindowState.Maximized && !isVideoFullscreen && !isPictureFullscreen) //if we are not in video/picture view
            {
                //Debug.Print("MainWindow1_StateChanged, windowState: " + this.WindowState + " windowStyle: " + this.WindowStyle + " startMaximized: " + settings["StartMaximized"] + " Left: " + Left + " Top " + Top);// + ", Stopwatch: " + locChangeStw.ElapsedMilliseconds);
                //locChangeTimer.Stop(); //the position changes do not get saved
                //locChangeTimer = null;
                if (this.WindowStyle == WindowStyle.None)
                {
                    //the window was set to full screen, no need to save position values again, or if the window is maximized, when we go out of full screen.
                }
                else
                {
                    SaveSetting("StartMaximized", true);

                    SaveSetting("NormalScreenLeft", (int)this.Left);
                    SaveSetting("NormalScreenTop", (int)this.Top);
                    if (settingsPageOpen)
                    {
                        SettingNormalScreenLeft.Text = ((int)settings["NormalScreenLeft"]).ToString();
                        SettingNormalScreenTop.Text = ((int)settings["NormalScreenTop"]).ToString();
                    }
                }
            }
            else if (this.WindowState == WindowState.Normal)
            {
                SaveSetting("StartMaximized", false);
                SetWindowPosSize();
            }

            if (settingsPageOpen)
            {
                SettingStartMaximized.IsChecked = settings["StartMaximized"];
            }
        }

        private void MainWindow1_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            if (changedByProgramWindow || changedByProgramInit) return;

            if (this.WindowState == WindowState.Normal)
            {
                //user resizing window
                SaveSetting("NormalScreenWidth", (int)this.Width);
                SaveSetting("NormalScreenHeight", (int)this.Height);

                if (settingsPageOpen)
                {
                    SettingNormalScreenWidth.Text = ((int)settings["NormalScreenWidth"]).ToString();
                    SettingNormalScreenHeight.Text = ((int)settings["NormalScreenHeight"]).ToString();
                }
            }
        }

        private void SetWindowPosSize()
        {
            if (settings["NormalScreenLeft"] == -32000) //happend once or twice when debugging, not clear why. If it ever happens to the user, they will not find the window.
            {
                SaveSetting("NormalScreenLeft", 0);
            }
            if (settings["NormalScreenTop"] == -32000)
            {
                SaveSetting("NormalScreenTop", 0);
            }
            this.Width = settings["NormalScreenWidth"];
            this.Height = settings["NormalScreenHeight"];
            this.Left = settings["NormalScreenLeft"]; //when set to 0, it is actually 7 px.
            this.Top = settings["NormalScreenTop"];
        }

        private void SkillsList_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //Debug.Print("SkillsList_SizeChanged " + e.PreviousSize.Width + " " + e.NewSize.Width);
            if (!changedByProgramInit)
            {
                SaveSetting("SkillsListWidth", (int)ListScroll.ActualWidth);
            }
        }

        private void ThumbScroll_SizeChanged(object sender, SizeChangedEventArgs e) //for cases when we resize the window or the skill list.
        // thumb size does not change: instead, only the slider's value changes            
        {
            if (e.PreviousSize.Width != e.NewSize.Width) //
            {
                Thumbs_SizeChanged(null, null); //to update the availWidth
                changedByProgramThumbs = true;
                ThumbSizeSlider.Value = (int)(availWidth / (thumbW + 1));
                changedByProgramThumbs = false;

                //update position of selection rectangle
                if (BorderRect.Visibility == Visibility.Visible) // when the file info box is visible, or a thumb is selected (currentPicIndex != -1)
                {
                    int index = (infoContextItemIndex != -1) ? infoContextItemIndex : currentPicIndex;
                    PositionBorderRect(index, true);
                }
            }
        }

        private void Thumbs_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // ScrollableHeight is not the content's height, but how much we can scroll (content height - container height)             
            ThumbScroll.UpdateLayout(); //so the scrollbar visibility changes
            if (ThumbScroll.ScrollableHeight == 0) //no scrollbar
            {
                availWidth = ThumbScroll.ActualWidth;
            }
            else
            {
                availWidth = ThumbScroll.ActualWidth - 17;
            }
        }

        private void EnterFullScreen(bool toSave)
        {
            if (this.WindowState == WindowState.Maximized) //without switching to normal first, the window will no go full screen.
            {
                changedByProgramWindow = true;
                this.WindowState = WindowState.Normal;
                changedByProgramWindow = false;
            }
            this.WindowStyle = WindowStyle.None;
            CloseButton.Visibility = Visibility.Visible;

            if (toSave) //pressing F11
            {
                this.WindowState = WindowState.Maximized;
                SaveSetting("StartFullScreen", true);
                if (settingsPageOpen)
                {
                    SettingStartFullScreen.IsChecked = settings["StartFullScreen"];
                }
            }
            else //on startup, or loading video/picture
            {
                changedByProgramWindow = true;
                this.WindowState = WindowState.Maximized;
                changedByProgramWindow = false;
            }
        }

        private void ExitFullScreen(bool toSave)
        {
            //Debug.Print("ExitFullScreen" + settings["StartMaximized"] + settings["StartFullScreen"] + toSave);
            if (toSave) //F11 pressed, window has to exit full screen
            {
                this.WindowStyle = WindowStyle.SingleBorderWindow;
                CloseButton.Visibility = Visibility.Collapsed;
                if (settings["StartMaximized"]) //deciding where to return to.
                {
                    this.WindowState = WindowState.Maximized;
                }
                else
                {
                    this.WindowState = WindowState.Normal;
                }
                SaveSetting("StartFullScreen", false);
                if (settingsPageOpen)
                {
                    SettingStartFullScreen.IsChecked = settings["StartFullScreen"];//false
                }
            }
            else //exiting video / picture view. We only exit fullscreen, if the setting says so.
            {
                if (!settings["StartFullScreen"])
                {
                    this.WindowStyle = WindowStyle.SingleBorderWindow;
                    CloseButton.Visibility = Visibility.Collapsed;
                    if (settings["StartMaximized"])
                    {
                        this.WindowState = WindowState.Maximized;
                    }
                    else
                    {
                        this.WindowState = WindowState.Normal;
                    }
                }
            }
        }

        #endregion

        #region UI element event handlers
        
        private double initScrollHeight = -1; //I tried to set it as an optional parameter, but it gives error when adding the function to the event handler.

        private void SkillsList_SelectionChanged(object sender, SelectionChangedEventArgs e) //On startup, the Activated event runs at the same time as this function, but this function is the first. So this will not be executed.
        {
            if (changedByProgramList) return;

            Debug.Print("SkillsList_SelectionChanged");

            /*if (windowActivating != null) //ca. 35 ms
            {
                Debug.Print(windowActivating.ElapsedMilliseconds.ToString());
                windowActivating = null;
            }*/
            if (windowActivatingTimer!= null && windowActivatingTimer.IsEnabled) //if selection changes upon window activation, update from that event is cancelled, and will take place now.
            {
                windowActivatingTimer.Stop();
                windowActivatingTimer = null;
            }

            if (this.IsActive)
            {
                string selectedSkill = SkillsList.SelectedItem.ToString();
                SaveSetting("SelectedSkill", selectedSkill);
                //For smooth movement through the list with the arrows. If we select another item in less than 100 ms, the 2. function of the previous timer will not run. 
                if (listTimer != null)
                {
                    listTimer.Stop();
                }
                listTimer = new DispatcherTimer();
                listTimer.Interval = TimeSpan.FromMilliseconds(100);
                listTimer.Tick += SkillsList_SelectionChanged2;
                listTimer.Start();
            }
        }

        private void SkillsList_SelectionChanged2(object sender, EventArgs e)
        {
            Debug.Print("SkillsList_SelectionChanged2");
            listTimer.Stop();
            listTimer = null;
            ClearThumbs();            
            StartUpdateThumbs();
        }

        private void SortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.IsActive) //On startup, the Activated event runs at the same time as this function, but this function is the first.
            {
                //Debug.Print("SortBy_SelectionChanged");
                SaveSetting("SortBy", ((ComboBoxItem)SortBy.SelectedItem).Content.ToString());
                ClearThumbs();
                StartUpdateThumbs();
            }
        }

        private void SortOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.IsActive) //On startup, the Activated event runs at the same time as this function, but this function is the first.
            {
                //Debug.Print("SortOrder_SelectionChanged");
                SaveSetting("SortOrder", ((ComboBoxItem)SortOrder.SelectedItem).Content.ToString());
                ClearThumbs();
                StartUpdateThumbs();
            }
        }

        private void ThumbSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) //(int) will take a number's whole part, so 230.8 becames 230.
        {
            //Debug.Print("ThumbSizeSlider_ValueChanged changedByProgramThumbs" + changedByProgramThumbs);
            //do not resize the thumbnails, when: - the thumbs have finished loading - the scroll container changes size
            if (!changedByProgramThumbs)
            {
                thumbW = settings["ThumbW"] = (int)(availWidth / ThumbSizeSlider.Value - 1); //-1 is for the border
                thumbH = settings["ThumbH"] = (int)((availWidth / ThumbSizeSlider.Value - 1) * 9 / 16);
                
                ThumbSizeLabel.Text = thumbW + " x " + thumbH; // 9/16 * ThumbSizeSlider.Value gives 0.

                double oldScrollHeight = (initScrollHeight == -1) ? ThumbScroll.ScrollableHeight : initScrollHeight;
                for (int i = 0; i < Thumbs.Children.Count; i++) //takes 160/10000 ms to cycle through 39 elements
                {
                    Image im = (Image)((Border)Thumbs.Children[i]).Child;
                    im.Width = thumbW;
                    im.Height = thumbH;
                }
                //UpdateLayouts used to work, but not now, newScrollHeight is not right.
                //Thumbs.UpdateLayout();  //Thumbs_SizeChanged is called here, but availWidth doesn't change yet, because ThumbScroll hasn't updated its scrollableheight value yet. 
                //ThumbScroll.UpdateLayout();
                //double newScrollHeight = ThumbScroll.ScrollableHeight;
                //Debug.Print("ThumbSizeSlider_ValueChanged oldScrollHeight " + oldScrollHeight + " newScrollHeight " + newScrollHeight);
                
                //do manual calculation instead. 
                int rowNum = (int)Math.Ceiling(Thumbs.Children.Count / ThumbSizeSlider.Value);
                double newScrollHeight = rowNum * (thumbH + 1) > ThumbScroll.ActualHeight ? rowNum * (thumbH + 1) - ThumbScroll.ActualHeight : 0;
                Debug.Print("ThumbSizeSlider_ValueChanged oldScrollHeight " + oldScrollHeight + " newScrollHeight " + newScrollHeight);

                if (oldScrollHeight > 0 && newScrollHeight == 0) //if the content shrinked, so the scrollbar disappeared, we resize the pictures again.
                {
                    availWidth = ThumbScroll.ActualWidth;
                    initScrollHeight = newScrollHeight;
                    ThumbSizeSlider_ValueChanged(null, null);
                    initScrollHeight = -1;
                    return;
                }
                else if (oldScrollHeight == 0 && newScrollHeight > 0) //if the content grew, so the scrollbar appeared, we resize the pictures again.
                {
                    availWidth = ThumbScroll.ActualWidth - 17;
                    initScrollHeight = newScrollHeight;
                    ThumbSizeSlider_ValueChanged(null, null);
                    initScrollHeight = -1;
                    return;
                }
                initScrollHeight = -1;
                //update FileNameGridAllCanvas, FileNameGrid's width is set by Binding.
                for (int i = 0; i < FileNameGridAllCanvas.Children.Count; i++)
                {
                    ((Grid)FileNameGridAllCanvas.Children[i]).Width = thumbW + 1;
                    ((Grid)FileNameGridAllCanvas.Children[i]).Height = thumbH + 1;
                }
            }
        }

        private void ThumbSizeSlider_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                case Key.Down:
                    if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                    {
                        ThumbSizeSlider.Value = ThumbSizeSlider.Value + ThumbSizeSlider.LargeChange;
                        e.Handled = true;
                    }
                    break;
                case Key.Right:
                case Key.Up:
                    if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
                    {
                        ThumbSizeSlider.Value = ThumbSizeSlider.Value - ThumbSizeSlider.LargeChange;
                        e.Handled = true;
                    }
                    break;
            }
        }

        private void ShowAllFilenames_Checked(object sender, RoutedEventArgs e) //context menu closing, grid disappears.
        //runs on initialization, and window activation too. To decide whether we should update the settings, we examine is the checked value is different from what's stored in settings.
        {
            if (ShowAllFilenames.IsChecked != settings["ShowFileNames"])
            {
                SaveSetting("ShowFileNames", ShowAllFilenames.IsChecked);
            }

            if ((bool)ShowAllFilenames.IsChecked)
            {
                for (int i = 0; i < FileNameGridAllCanvas.Children.Count; i++)
                {
                    ((Grid)FileNameGridAllCanvas.Children[i]).Children[0].Visibility = Visibility.Visible;
                }
            }
            else
            {
                for (int i = 0; i < FileNameGridAllCanvas.Children.Count; i++)
                {
                    ((Grid)FileNameGridAllCanvas.Children[i]).Children[0].Visibility = Visibility.Hidden;
                }
            }
        }

        private void CloseButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            CloseButton.Source = new BitmapImage(new Uri(resourceDir + @"\close_big_over.png", UriKind.Absolute));
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                closeMouseIn = false;
            }
            else
            {
                closeMouseIn = true;
            }
        }

        private void CloseButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            CloseButton.Source = new BitmapImage(new Uri(resourceDir + @"\close_big.png", UriKind.Absolute));
            closeMouseIn = false;
        }

        private void CloseButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CloseButton.Source = new BitmapImage(new Uri(resourceDir + @"\close_big_down.png", UriKind.Absolute));
        }

        private void CloseButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (closeMouseIn)
            {
                this.Close();
            }
            else
            {
                closeMouseIn = true;
            }
        }

        #endregion        

        #region Video/picture opening-closing

        private void OpenContentSelector(object sender, RoutedEventArgs e)
        {
            OpenFileDialog obj = new OpenFileDialog();
            obj.AddExtension = true;
            obj.DefaultExt = "";
            obj.Title = "Find the media";
            obj.Filter = "mp4, jpg, png files|*.mp4;*.jpg;*.png";
            obj.ShowDialog();
            string fileName = obj.FileName;
            if (fileName != "")
            {
                string ext = System.IO.Path.GetExtension(fileName).ToLower();
                if (ext == ".mp4")
                {
                    GetFilesExternal(fileName);
                    LoadVideo(fileName);
                }
                else if (ext == ".jpg" || ext == ".png")
                {
                    GetFilesExternal(fileName);
                    LoadPicture(fileName);
                }
                else
                {
                    Msgbox("This file type is not supported.");
                }
                //Getting video framerate
                //ShellObject obj2 = ShellObject.FromParsingName(@SelectedFile);
                //ShellProperty<uint?> rateProp = obj2.Properties.GetProperty<uint?>("System.Video.FrameRate");
                //System.Windows.MessageBox.Show(System.Convert.ToString(rateProp.Value));                
            }
        }

        private void LoadContent(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Debug.Print("LoadContent");
            Image i = (Image)sender;
            currentPicIndexExt = -1;
            string fileName = new Uri(i.Source.ToString()).LocalPath;
            if (IsThumbVideo(fileName))
            {
                currentCommentPosIndex = -1;
                string origFile = ThumbToOrig(fileName);
                if (origFile != null && origFile != "") //folder renamed outside of program? if file is renamed, origFile would be null.
                {
                    LoadVideo(origFile);
                }                
            }
            else //picture
            {
                fileName = ThumbToOrig(fileName);
                if (File.Exists(fileName)) //folder renamed outside of program?
                {
                    LoadPicture(fileName);
                }                
            }
        }

        private void LoadContentExt(string fileName)
        {
            if (System.IO.Path.GetExtension(fileName).ToLower() == ".jpg" || System.IO.Path.GetExtension(fileName).ToLower() == ".png")
            {
                LoadPicture(fileName);
            }
            else //mp4
            {
                currentCommentPosIndex = -1;
                LoadVideo(fileName);
            }
        }

        private void LoadVideo(String fileName)
        {
            try
            {
                Debug.Print("LoadVideo, fileName: " + fileName);

                //Debug.Print("LoadVideo: ThumbScroll.ScrollableHeight: " + ThumbScroll.ScrollableHeight);
                isPictureFullscreen = false;
                ImageElement1.Source = null;

                //SkillsList.Visibility = Visibility.Hidden;
                ListScroll.Visibility = Visibility.Hidden;
                Splitter.Visibility = Visibility.Hidden;
                ToolbarAndThumbs.Visibility = Visibility.Hidden;

                if (settings["BackgroundBlack"])
                {
                    this.Background = Brushes.Black;
                }
                if (settings["BackgroundGray"])
                {
                    this.Background = Brushes.Gray;
                }
                if (settings["BackgroundWhite"])
                {
                    this.Background = Brushes.White;
                }

                videoSource = fileName; //used in extracting frames

                frameIndex = new List<double>();
                keyFrames = new List<double>();
                commentPositions = new List<double>();
                commentPositionComments = new List<string>();

                isVideoFullscreen = true; //have to come after setting the frames to an empty list, otherwise the extraction process will be unable to add items to an undefined list. 

                if (this.WindowStyle != WindowStyle.None) //have to come after setting isVideoFullScreen, for correctly handling the window events.
                {
                    EnterFullScreen(false);
                }

                //Debug.Print("loadvideo, controlgrid visible? " + MainGrid.ActualHeight + " " + VideoControlGrid.ActualHeight + " " + System.Windows.Forms.Cursor.Position.Y +  " " + Mouse.GetPosition(MainGrid).Y);
                //Mouse.GetPosition(MainGrid).Y gives 0, when deleting a picture, and loading a video. Not when we are just stepping forward.
                if (settings["SliderIsLocked"] || System.Windows.Forms.Cursor.Position.Y >= MainGrid.ActualHeight - VideoControlGrid.ActualHeight) //slider is set always visible, or the mouse is at the bottom of the window
                {
                    Debug.Print("control visible");
                    VideoControlGrid.Visibility = Visibility.Visible;
                }

                MediaElement1.SpeedRatio = SpeedRatioSlider.Value = settings["SpeedRatio"];
                MediaElement1.Volume = settings["VideoVolume"];
                MediaElement1.IsMuted = false;
                MediaElement1.Source = new Uri(videoSource, UriKind.Absolute);
                MediaElement1.Play();

                FilenameText.Text = System.IO.Path.GetFileName(videoSource);
                FilenameText.UpdateLayout();

                //Debug.Print("loadvideo");
                var watch = Stopwatch.StartNew();

                //Debug.Print("loadvideo, videosource: " + videoSource);
                string[] arr = GetMediaInfo(videoSource, "Video;%Duration%,%FrameRate_Mode%,%FrameRate%");

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;

                videoDuration = int.Parse(arr[0]);
                videoFrameRateMode = arr[1];
                videoFrameRate = float.Parse(arr[2], CultureInfo.InvariantCulture);
                videoFrameLength = 1000 / videoFrameRate;

                //Msgbox("MainGrid " + MainGrid.ActualWidth + " " + MainGrid.ActualHeight);

                TimeText.Text = "0:00:00.000";
                TimeText.UpdateLayout();
                TimeTextTotal.Text = " / " + TimeSpan.FromMilliseconds(videoDuration).ToString(@"h\:mm\:ss\.fff");
                TimeTextTotal.UpdateLayout();
                TimelineSlider.Maximum = videoDuration;

                ClearCutRect();

                if (TimelineSlider.ActualWidth != 0) //for external files, it is still 0 here.
                {
                    AddFrames(); //we cannot call this function before the timelineslider has not got its final size.
                }
                else
                {
                    addFramesLater = true;
                }
            }
            catch (Exception e)
            {
                Msgbox(e.Message + "\n" + e.StackTrace);
            }
        }

        private void LoadPicture(string fileName)
        {
            Debug.Print("LoadPicture " + fileName);

            isVideoFullscreen = false;
            isPictureFullscreen = true;
            MediaElement1.Source = null;
            
            BitmapImage imageBitmap = new BitmapImage();
            imageBitmap.BeginInit();
            imageBitmap.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            imageBitmap.CacheOption = BitmapCacheOption.OnLoad;//makes it possible to delete the image, otherwise it will be locked. If I set it to OnLoad however, the image will not refresh when the thumbnail image file refreshes.
            imageBitmap.UriSource = new Uri(fileName, UriKind.Absolute);
            imageBitmap.EndInit();
            ImageElement1.Source = imageBitmap;//new BitmapImage(new Uri(fileName, UriKind.Absolute)); //in this case deletion is not allowed even after we set the image's source to null

            //SkillsList.Visibility = Visibility.Hidden;
            ListScroll.Visibility = Visibility.Hidden;
            Splitter.Visibility = Visibility.Hidden;
            ToolbarAndThumbs.Visibility = Visibility.Hidden;

            if (settings["BackgroundBlack"])
            {
                this.Background = Brushes.Black;
            }
            if (settings["BackgroundGray"])
            {
                this.Background = Brushes.Gray;
            }
            if (settings["BackgroundWhite"])
            {
                this.Background = Brushes.White;
            }

            if (this.WindowStyle != WindowStyle.None)
            {
                EnterFullScreen(false);
            }

            //setting image size and position. Smaller than screen images will be shown in actual size.
            //Msgbox(imageBitmap.PixelWidth + " " + MainGrid.ActualWidth + " " + imageBitmap.PixelHeight + " " + MainGrid.ActualHeight);
            //When opening images extenally, MainGrid.Actual will be 0 at this point. Default layout will take effect, image will be positioned later.
            if (MainGrid.ActualWidth != 0 && MainGrid.ActualHeight!= 0) //not externally opened file, otherwise image will be sized after window loaded.
            {
                if (imageBitmap.PixelWidth < MainGrid.ActualWidth && imageBitmap.PixelHeight < MainGrid.ActualHeight)
                {
                    double w = imageBitmap.PixelWidth;
                    double h = imageBitmap.PixelHeight;
                    ImageElement1.Width = w;
                    ImageElement1.Height = h;
                    ImageElement1.Margin = new Thickness((MainGrid.ActualWidth - w) / 2, (MainGrid.ActualHeight - h) / 2, 0, 0);

                    ActualSize.Source = new BitmapImage(new Uri(resourceDir + "origsize.png", UriKind.Absolute));
                    actualSizeView = true;
                }
                else
                {
                    SetImageOrigSize(imageBitmap);
                    ActualSize.Source = new BitmapImage(new Uri(resourceDir + "actualsize.png", UriKind.Absolute));
                    actualSizeView = false;
                }
            }            
            
            lastActualLeft = 1000000; //indicating that it is unset. It can range from negative values to positive for smaller than screen images.
            lastActualTop = 1000000;

            if (settings["SliderIsLocked"]) //here we  don't have to check mouse position, mousemove call will take care of it.
            {
                PictureControlGrid.Visibility = Visibility.Visible;
            }
            PictureFilenameText.Text = System.IO.Path.GetFileName(fileName);
        }

        private void MediaElement1_MediaOpened(object sender, EventArgs e)
        {
            if (addFramesLater)
            {
                addFramesLater = false;
                AddFrames();    
            }
            //Debug.Print("mediaopened");
            videoLoaded = true;
            isPlaying = true;

            //it is too early to call in loadvideo,  external videos will not show.
            MediaElement1.Width = MainGrid.ActualWidth; //this.Actual... gives +14
            MediaElement1.Height = MainGrid.ActualHeight;

            //Msgbox(MediaElement1.ActualWidth + " " + MediaElement1.ActualHeight);

            //when opening a video by itself, the Actual dimensions are 0 at the time of LoadVideo()
            /*dialogActivation = true;
            Msgbox(MainGrid.ActualWidth + " " + MainGrid.ActualHeight + " " + this.ActualWidth + " " + this.ActualHeight);
            dialogActivation = false;*/
            
            ButtonPlayPause.ToolTip = "Pause";
            ButtonPlayPause.Source = new BitmapImage(new Uri(resourceDir + "pause.png", UriKind.Absolute));

            sliderTimer = new DispatcherTimer();
            sliderTimer.Interval = TimeSpan.FromMilliseconds(20);
            sliderTimer.Tick += Timer_Tick;
            sliderTimer.Start();

            enteringFullscreen = true; //500 ms after this point the cursor cannot be shown.

            if ((frameWindow == null || !frameWindow.IsVisible) && VideoControlGrid.Visibility == Visibility.Hidden)
            {
                Debug.Print("MediaElement1_MediaOpened, hiding cursor:  VideoControlGrid.Visibility: " + VideoControlGrid.Visibility + " PictureControlGrid.Visibility: " + PictureControlGrid.Visibility);
                this.Cursor = System.Windows.Input.Cursors.None;
                /*if (isCursorVisible)
                {
                    System.Windows.Forms.Cursor.Hide(); //this.Cursor = System.Windows.Input.Cursors.None;                 
                    isCursorVisible = false;
                }*/
            }

            stw = new Stopwatch();
            stw.Start(); //no cursor is shown within the first 500 ms, even if it moved.

        }

        private void MediaElement1_MediaEnded(object sender, EventArgs e) // When the media playback is finished. Stop() the media to seek to media start.
        {
            StopVideo();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (videoLoaded && !userIsDraggingSlider)
            {

                if (enteringFullscreen == false && stw.IsRunning && stw.ElapsedMilliseconds > 750 && VideoControlGrid.Visibility == Visibility.Hidden && !videoContextOpen && (frameWindow == null || !frameWindow.IsVisible)) //if at least 750 ms passed since the last mouse movement, we hide the cursor.
                {
                    stw.Reset();
                    this.Cursor = System.Windows.Input.Cursors.None;
                    /*Debug.Print("Timer_Tick, hiding cursor: " + isCursorVisible);
                    if (isCursorVisible)
                    {
                        System.Windows.Forms.Cursor.Hide();
                        isCursorVisible = false;
                    }*/
                }
                if (isPlaying) //when the video is paused, we manually update the slider's value, otherwise we can get imprecise values. We set the video to a position, but we will get back another.
                {
                    TimelineSlider.Value = MediaElement1.Position.TotalMilliseconds;
                    //Debug.Print(TimelineSlider.Value.ToString());
                }

            }
        }

        private void TimelineSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //Debug.Print("TimelineSlider_ValueChanged");
            TimeText.Text = TimeSpan.FromMilliseconds(TimelineSlider.Value).ToString(@"h\:mm\:ss\.fff");
        }

        private void ExitView()
        {
            Debug.Print("Exitview currentPicIndex: " + currentPicIndex + isVideoFullscreen + isPictureFullscreen);
            if (isVideoFullscreen)
            {
                ExitVideo();
                currentCommentPosIndex = -1;
            }
            else if (isPictureFullscreen)
            {
                ExitPicture();
            }

            currentPicIndexExt = -1; //important for deletion. If we exited from external directory into the program, we need to know later we are now watching the internal contents.

            //ThumbScroll.CanContentScroll = true;
            Debug.Print("Exitview2");

            this.Background = Brushes.Gray;
            //SkillsList.Visibility = Visibility.Visible;
            ListScroll.Visibility = Visibility.Visible;
            Splitter.Visibility = Visibility.Visible;
            ToolbarAndThumbs.Visibility = Visibility.Visible;
            ExitFullScreen(false);

            Debug.Print("Exitview3");

            //set cursor rectangle
            if (currentPicIndex != -1)
            {
                PositionBorderRect(currentPicIndex,true);
                if (selectedPicIndexes.IndexOf(currentPicIndex) != -1) //if max one item was selected before opening the video, we will get here.
                //Also when multiple items were selected, and the video we exited from is one of them.
                {
                    BorderRect.Stroke = Brushes.Lime;
                }
                else
                {
                    BorderRect.Stroke = Brushes.Red;
                }
                BorderRect.Visibility = Visibility.Visible;
            }
            else //if we are coming from external directory
            {
                BorderRect.Visibility = Visibility.Hidden;
            }
            // ThumbScroll.Focusable = true;
            ThumbScroll.Focus();
            // ThumbScroll.Focusable = false;
            if (!savingCutVideo)
            {
                StartUpdateThumbs();
            }            
        }

        private void ExitVideo()
        {
            isVideoFullscreen = false;
            MediaElement1.Source = null;
            videoSource = null;

            videoLoaded = false;
            isPlaying = false;

            TimelineSlider.Maximum = 1;
            TimelineSlider.Value = 0;
            TimeTextTotal.Text = " / " + TimeSpan.FromMilliseconds(0).ToString(@"h\:mm\:ss\.fff");
            ButtonPlayPause.ToolTip = "Play";
            ButtonPlayPause.Source = new BitmapImage(new Uri(resourceDir + "play.png", UriKind.Absolute));
            FilenameText.Text = "";

            if (stw != null)
            {
                stw.Stop();
                stw = null;
            }

            if (sliderTimer != null)
            {
                sliderTimer.Stop();
                sliderTimer = null;
            }

            this.Cursor = System.Windows.Input.Cursors.Arrow;
            /*if (!isCursorVisible)
            {
                System.Windows.Forms.Cursor.Show();
                isCursorVisible = true;
            }*/
            if (StatusTextVideo.Visibility == Visibility.Visible)
            {
                StatusTextVideo.Visibility = Visibility.Hidden;
            }
            cutSelectionSet = false; //this is to avoid that after cutting a video, if we extract the new video's frame in thumbnail view, and click on another video, upon setting selection the black lines are visible. The extracting function draws them if the selection is set.
            KeyFrameCanvas.Visibility = Visibility.Hidden;
            KeyFrameCanvas.Children.RemoveRange(0, KeyFrameCanvas.Children.Count);
            CommentCanvas.Children.RemoveRange(0, CommentCanvas.Children.Count);
            VideoControlGrid.Visibility = Visibility.Hidden; //makes cutting displays invisible too.
        }

        private void ExitPicture()
        {
            isPictureFullscreen = false;
            ImageElement1.Source = null;
            ImageElement1.Width = MainGrid.ActualWidth;
            ImageElement1.Height = MainGrid.ActualHeight;
            ImageElement1.Margin = new Thickness(0);
            PictureFilenameText.Text = "";
            this.Cursor = System.Windows.Input.Cursors.Arrow;
            pictureExiting = true; //needed to prevent context menu showing up upon right-clicking which exited the view.
            PictureControlGrid.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Picture control functions

        private bool actualSizeView;
        private bool movingImage;
        private int moveStartX;
        private int moveStartY;
        private int imageStartX;
        private int imageStartY;
        private double lastActualLeft;
        private double lastActualTop;

        private void ActualSize_ToolTipOpening(object sender, ToolTipEventArgs e)
        {
            ActualSize.ToolTip = actualSizeView ? "Screen size" : "Actual size";
        }

        private void SetImageActualSize(object sender, RoutedEventArgs e) // what if image is smaller than screen?
        {
            Debug.Print("SetImageActualSize actualSizeView " + actualSizeView  + " " + ImageElement1.ActualWidth + " " + MainGrid.ActualWidth + " " + ImageElement1.ActualHeight + " " + MainGrid.ActualHeight);

            BitmapImage b = (BitmapImage)ImageElement1.Source;
            if (!actualSizeView)
            //if (Math.Round(ImageElement1.ActualWidth) == Math.Round(MainGrid.ActualWidth) || Math.Round(ImageElement1.ActualHeight) == Math.Round(MainGrid.ActualHeight)) //default stretch mode. If image proportions are not the screen proportions, the image will be narrower or shorter.
            //There may be -2,27373675443232E-13 difference between the double values, so Math.Round has to be used.
            {
                ImageElement1.Width = b.PixelWidth;
                ImageElement1.Height = b.PixelHeight;
                if (lastActualLeft != 1000000 && lastActualTop != 1000000)
                {
                    ImageElement1.Margin = new Thickness(lastActualLeft, lastActualTop, 0, 0);
                }
                else
                {
                    //Debug.Print(b.PixelWidth + " " + b.PixelHeight + " " + ImageElement1.ActualWidth + " " + this.ActualWidth + " " + MainGrid.ActualWidth);
                    double newLeft = -(b.PixelWidth - MainGrid.ActualWidth) / 2;
                    double newTop = -(b.PixelHeight - MainGrid.ActualHeight) / 2;                    
                    ImageElement1.Margin = new Thickness(newLeft, newTop, 0, 0);
                }                
                ActualSize.Source = new BitmapImage(new Uri(resourceDir + "origsize.png", UriKind.Absolute));
                actualSizeView = true;
            }
            else
            {
                lastActualLeft = ImageElement1.Margin.Left;
                lastActualTop = ImageElement1.Margin.Top;
                SetImageOrigSize(b);
                ActualSize.Source = new BitmapImage(new Uri(resourceDir + "actualsize.png", UriKind.Absolute));
                actualSizeView = false;
            }
        }

        private void SetImageOrigSize(BitmapImage b)
        {
            double w;
            double h;
            Debug.Print("OrigSize " + b.PixelWidth + " " + b.PixelHeight + " " + (double)b.PixelWidth / (double)b.PixelHeight + " " + MainGrid.ActualWidth + " " + MainGrid.ActualHeight + " " + MainGrid.ActualWidth / MainGrid.ActualHeight);
            if ((double)b.PixelWidth / (double)b.PixelHeight >= MainGrid.ActualWidth / MainGrid.ActualHeight) //image is wider, or same ratio as screen. 2592/1456 gives 1, if (double) cast is not used.
            {
                w = MainGrid.ActualWidth;
                h = MainGrid.ActualWidth * b.PixelHeight / b.PixelWidth;
                Debug.Print("OrigSize, image is wide." + w + " " + h);
            }
            else
            {
                h = MainGrid.ActualHeight;
                w = MainGrid.ActualHeight * b.PixelWidth / b.PixelHeight;
                Debug.Print("OrigSize, image is tall." + w + " " + h);
            }
            ImageElement1.Width = w;
            ImageElement1.Height = h;
            ImageElement1.Margin = new Thickness((MainGrid.ActualWidth - w) / 2, (MainGrid.ActualHeight - h) / 2, 0, 0);
        }

        private void ImageElement1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var pos= e.GetPosition(this);
            moveStartX = (int)pos.X;
            moveStartY = (int)pos.Y;
            imageStartX = (int)ImageElement1.Margin.Left;
            imageStartY = (int)ImageElement1.Margin.Top;
            Debug.Print("ImageElement1_MouseLeftButtonDown imageStartX " + imageStartX + " imageStartY " + imageStartY);
        }

        private void ImageElement1_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                movingImage = true;
                var pos = e.GetPosition(this);
                BitmapImage b = (BitmapImage)ImageElement1.Source;
                
                double left = -(ImageElement1.ActualWidth - MainGrid.ActualWidth) / 2; //centered default value for small images.
                double top = -(ImageElement1.ActualHeight - MainGrid.ActualHeight) / 2;
                Debug.Print("ImageElement1_MouseMove " + ImageElement1.ActualWidth + " " + left);
                if (ImageElement1.ActualWidth > MainGrid.ActualWidth)
                {
                    int diffX = (int)pos.X - moveStartX;
                    left = imageStartX + diffX <= 0 ? imageStartX + diffX : 0;
                    left = left >= MainGrid.ActualWidth - ImageElement1.ActualWidth ? left : MainGrid.ActualWidth - ImageElement1.ActualWidth;
                }
                if (ImageElement1.ActualHeight> MainGrid.ActualHeight)
                {
                    int diffY = (int)pos.Y - moveStartY;
                    top = imageStartY + diffY <= 0 ? imageStartY + diffY : 0;
                    top = top >= MainGrid.ActualHeight - ImageElement1.ActualHeight ? top : MainGrid.ActualHeight - ImageElement1.ActualHeight;
                }
                Debug.Print("ImageElement1_MouseMove2 " + left + " " + top);
                ImageElement1.Margin = new Thickness(left, top, 0, 0);
            }
        }

        private void ImageElement1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            movingImage = false;
        }

        #endregion

        #region Cutting event handlers

        private void StartMarkerTextCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StartMarkerPressed = true;
            markerCursorStartX = System.Windows.Forms.Cursor.Position.X;
            markerMargin = StartMarkerTextCanvas.Margin.Right;
        }

        private void EndMarkerTextCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EndMarkerPressed = true;
            markerCursorStartX = System.Windows.Forms.Cursor.Position.X;
            markerMargin = EndMarkerTextCanvas.Margin.Left;
        }

        private void StartMarkerTextCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (System.Windows.Forms.Cursor.Position.X == markerCursorStartX) //no drag happened
            {
                GetMiddleIndexPos(cutStart);
                MediaElement1.Position = TimeSpan.FromMilliseconds(middleIndexPos);
                TimelineSlider.Value = middleIndexPos;
            }
        }

        private void EndMarkerTextCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (System.Windows.Forms.Cursor.Position.X == markerCursorStartX) //no drag happened
            {
                GetMiddleIndexPos(cutEnd);
                MediaElement1.Position = TimeSpan.FromMilliseconds(middleIndexPos);
                TimelineSlider.Value = middleIndexPos;
            }
        }

        #endregion

        #region Cutting functions

        private void UpdateCutRect(bool isFromKey, bool isStart)
        {
            double left = cutStart / videoDuration * (TimelineSlider.ActualWidth - 15) + 7.5;
            CutRect.Margin = new Thickness(left, 0, 0, 0);
            CutRect.Width = (cutEnd - cutStart) / videoDuration * (TimelineSlider.ActualWidth - 15);
            cutStartOffset = (cutStart < settings["CutMarginStart"]) ? 0 : cutStart - settings["CutMarginStart"]; //applying starting offset
            StartMarkerText.Text = (cutStart / 1000).ToString("0.000", CultureInfo.InvariantCulture);

            cutEndOffset = (cutEnd > videoDuration - settings["CutMarginEnd"]) ? videoDuration : (cutEnd + settings["CutMarginEnd"]); //applying ending offset
            CutRectOffset.Margin = new Thickness(cutStartOffset / videoDuration * (TimelineSlider.ActualWidth - 15) + 7.5, 0, 0, 0);
            CutRectOffset.Width = (cutEndOffset - cutStartOffset) / videoDuration * (TimelineSlider.ActualWidth - 15) - 1;
            double right = left + CutRect.Width;
            EndMarkerText.Text = (cutEnd / 1000).ToString("0.000", CultureInfo.InvariantCulture);


            if (extVideoSource == videoSource) //frames are being extracted of the current video. We are in video view mode.
            {
                Debug.Print("UpdateCutRect frames are being extracted");
                double lastKeyframe = (keyFrames.Count == 0) ? 0 : keyFrames[keyFrames.Count - 1];  //at the start of extraction, no keyframes exist.  
                Debug.Print("UpdateCutRect lastKeyframe " + lastKeyframe + " cutStartOffset " + cutStartOffset);
                if (lastKeyframe >= cutStartOffset) //we can certainly get the preceding keyframe
                {
                    cutStartActual = GetPrevKeyFrame(cutStartOffset);
                    Debug.Print("UpdateCutRect cutStartActual " + cutStartActual);
                    cutStartActualOffset = cutStartOffset; //only important, if the index file is deleted externally
                    CutRectActual.Margin = new Thickness(cutStartActual / videoDuration * (TimelineSlider.ActualWidth - 15) + 7.5, 0, 0, 0);
                    CutRectActual.Width = (cutEndOffset - cutStartActual) / videoDuration * (TimelineSlider.ActualWidth - 15) - 1;//-1 is to prevent visibility at the selection's end due to pixel rendering
                }
                else //extraction haven't reached the point of selection. Behavour as without frame index.
                //We start a second thread of ffprobe, getting the current position's keyframe.
                {
                    if (isStart) //start marker was set, we clear previous cut start
                    {
                        if (cutStartOffset > cutStartActualOffset || cutStartOffset < cutStartActual)
                        //the start marker was moved to the right, or to the left below the keyframe. Keyframe needs to be queried.
                        {
                            cutStartActual = -1;
                            cutStartActualOffset = -1;
                            CutRectActual.Width = 0;
                            GetActualStart();
                        } //no change otherwise
                    }
                    else //we just need to set the width of the actual rect.
                    {
                        if (cutStartActual == -1) //in case the start marker was not yet set.
                        {
                            cutStartActual = 0;
                            cutStartActualOffset = 0;
                            CutRectActual.Margin = new Thickness(cutStartActual / videoDuration * (TimelineSlider.ActualWidth - 15) + 7.5, 0, 0, 0);
                        }
                        CutRectActual.Width = (cutEndOffset - cutStartActual) / videoDuration * (TimelineSlider.ActualWidth - 15) - 1; //-1 is to prevent visibility at the selection's end due to pixel rendering
                    }
                }
            }
            else
            {
                if (keyFrames.Count != 0) //index exists
                {
                    cutStartActual = GetPrevKeyFrame(cutStartOffset);
                    cutStartActualOffset = cutStartOffset; //only important, if the index file is deleted externally
                    CutRectActual.Margin = new Thickness(cutStartActual / videoDuration * (TimelineSlider.ActualWidth - 15) + 7.5, 0, 0, 0);
                    CutRectActual.Width = (cutEndOffset - cutStartActual) / videoDuration * (TimelineSlider.ActualWidth - 15) - 1;//-1 is to prevent visibility at the selection's end due to pixel rendering
                }
                else //index does not exist.
                {
                    if (isStart) //start marker was set, we clear previous cut start
                    {
                        if (cutStartOffset > cutStartActualOffset || cutStartOffset < cutStartActual)
                        //the start marker was moved to the right, or to the left below the keyframe. Keyframe needs to be queried.
                        {
                            cutStartActual = -1;
                            cutStartActualOffset = -1;
                            CutRectActual.Width = 0;
                            GetActualStart();
                        } //no change otherwise
                    }
                    else //we just need to set the width of the actual rect.
                    {
                        if (cutStartActual == -1) //in case the start marker was not yet set.
                        {
                            cutStartActual = 0;
                            cutStartActualOffset = 0;
                            CutRectActual.Margin = new Thickness(cutStartActual / videoDuration * (TimelineSlider.ActualWidth - 15) + 7.5, 0, 0, 0);
                        }
                        CutRectActual.Width = (cutEndOffset - cutStartActual) / videoDuration * (TimelineSlider.ActualWidth - 15) - 1; //-1 is to prevent visibility at the selection's end due to pixel rendering
                    }
                }
            }

            if (isFromKey) // otherwise, the mousemove event already updated the margins.
            {
                StartMarker.Margin = new Thickness(0, -31, TimelineSlider.ActualWidth - left - 0.5, 0);
                StartMarker.Visibility = Visibility.Visible;
                StartMarkerTextCanvas.Margin = new Thickness(0, -31, TimelineSlider.ActualWidth - left - 0.5, 0);
                StartMarkerTextCanvas.Visibility = Visibility.Visible;
                EndMarker.Margin = new Thickness(right - 0.5, -31, 0, 0);
                EndMarker.Visibility = Visibility.Visible;
                EndMarkerTextCanvas.Margin = new Thickness(right - 0.5, -31, 0, 0);
                EndMarkerTextCanvas.Visibility = Visibility.Visible;
            }
        }

        private void GetActualStart()
        //get the preceding keyframe for determining the actual start. If the marker text is moved with the mouse, this function is called repeately in short intervals, so we implement a timer.
        {
            if (cutTimer != null)
            {
                cutTimer.Stop();
                cutTimer = null;
            }
            cutTimer = new DispatcherTimer();
            cutTimer.Interval = TimeSpan.FromMilliseconds(100);
            cutTimer.Tick += CutTimer_Tick;
            cutTimer.Start();
        }

        private void CutTimer_Tick(object sender, EventArgs e) //will run 100 ms after setting the marker.
        {
            cutTimer.Stop();
            cutTimer = null;

            var stwLocal = new Stopwatch();
            stwLocal.Start();

            cutStartActual = FindPrecedingKeyframe(cutStartOffset, videoSource);
            cutStartActualOffset = cutStartOffset;

            stwLocal.Stop();
            Debug.Print("Finding preceding keyframe: " + stwLocal.ElapsedMilliseconds.ToString());

            //update visual selection.
            CutRectActual.Margin = new Thickness(cutStartActual / videoDuration * (TimelineSlider.ActualWidth - 15) + 7.5, 0, 0, 0);
            CutRectActual.Width = (cutEndOffset - cutStartActual) / videoDuration * (TimelineSlider.ActualWidth - 15) - 1; //-1 is to prevent visibility at the selection's end due to pixel rendering

            if (cutSaveCalled)
            {
                cutSaveCalled = false;
                CutVideo();
            }
        }

        private void ClearCutRect()
        {
            cutSelectionSet = false;
            cutStartOffset = cutStart = 0;
            cutEndOffset = cutEnd = videoDuration;
            cutStartActual = -1; //we need to know it is set, when determining if we need to query the preceding keyframe with ffprobe  
            cutStartActualOffset = -1;
            CutRect.Margin = new Thickness(0);
            CutRectOffset.Margin = new Thickness(0);
            CutRectActual.Margin = new Thickness(0);
            CutRect.Width = 0;
            CutRectOffset.Width = 0;
            CutRectActual.Width = 0;
            StartMarker.Visibility = Visibility.Hidden;
            EndMarker.Visibility = Visibility.Hidden;
            StartMarkerTextCanvas.Visibility = Visibility.Hidden;
            EndMarkerTextCanvas.Visibility = Visibility.Hidden;
            KeyFrameCanvas.Visibility = Visibility.Hidden;
        }

        private double FindPrecedingKeyframe(double pos, string videoFile)
        {
            string command = "-select_streams v -show_frames -show_entries frame=pict_type,pkt_pts_time -of csv -read_intervals " + Convert.ToString(pos / 1000, CultureInfo.InvariantCulture) + "%+#1 \"" + videoFile + "\"";
            Debug.Print(command);
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                FileName = @"resources\ffprobe.exe",
                Arguments = command
            };
            process.StartInfo = startInfo;
            process.Start();
            while (!process.StandardOutput.EndOfStream)
            {
                string line = process.StandardOutput.ReadLine();
                string[] arr = line.Split(',');
                return double.Parse(arr[1], CultureInfo.InvariantCulture) * 1000;
            }
            return 0;
        }

        private void AddFrames()
        {
            string indexFile = settings["SkillsPath"] != "" ? OrigToIndex(videoSource) : "";
            if (File.Exists(indexFile))
            {
                string[] fileLines = File.ReadAllLines(indexFile);
                foreach (string line in fileLines)
                {
                    string[] arr = line.Split(',');
                    double timeStamp = Math.Round(double.Parse(arr[1], CultureInfo.InvariantCulture) * 1000, 3); // without rounding, we get unequal values at GetMiddleIndexPos, even if the numbers look perfectly the same when written as a string.
                    frameIndex.Add(timeStamp);
                    if (arr[2] == "I")
                    {
                        keyFrames.Add(timeStamp);
                    }
                }
            }
            else
            {
                if (extVideoSource == videoSource) //frames are being extracted of the current video. isVideoFullScreen is true.
                {
                    frameIndex = extFrameIndex.ToList(); //copies by value, not reference.
                    keyFrames = extKeyFrames.ToList();
                }
            }
            
            string commentFile = settings["SkillsPath"] != "" ? OrigToComment(videoSource) : "";
            if (File.Exists(commentFile))
            {
                string[] arr2 = File.ReadAllLines(commentFile);
                for (int i = 0; i < arr2.Length; i++)
                {
                    string[] arr3 = arr2[i].Split('\t');
                    Debug.Print("Drawing comment marker at " + i + ", " + double.Parse(arr3[0], CultureInfo.InvariantCulture) + " " + arr3[1]);
                    DrawCommentMarker(i, double.Parse(arr3[0], CultureInfo.InvariantCulture), arr3[1]);
                }
            }
        }

        private void DrawKeyFrames()
        {
            foreach (double kframe in keyFrames)
            {
                DrawKeyFrame(kframe);
            }
        }

        private void DrawKeyFrame(double kframe)
        {
            double pos = 7.5 + (kframe / videoDuration) * (TimelineSlider.ActualWidth - 15) - 0.5; //0.5 is to compensate for the thickness of the line
            Rectangle r = new Rectangle();
            r.Fill = Brushes.Black;
            r.Width = 1;
            r.Height = 20;
            r.Margin = new Thickness(pos, 0, 0, 0);
            r.SnapsToDevicePixels = true;
            KeyFrameCanvas.Children.Add(r);
        }

        private double GetPrevKeyFrame(double pos)
        {
            double ret = 0;
            foreach (double kframe in keyFrames)
            {
                if (kframe <= pos)
                {
                    ret = kframe;
                }
                else
                {
                    break;
                }
            }
            return ret;
        }

        private double GetNextKeyFrame(double pos)
        {
            double ret = keyFrames[keyFrames.Count - 1]; //setting it to the last keyframe
            foreach (double kframe in keyFrames)
            {
                if (kframe > pos)
                {
                    ret = kframe;
                    break;
                }
            }
            return ret;
        }

        #endregion

        #region Video controls

        private void ButtonLock_Click(object sender, RoutedEventArgs e)
        {
            if (!settings["SliderIsLocked"])
            {
                SaveSetting("SliderIsLocked", true);
                PictureButtonLock.Source = ButtonLock.Source = new BitmapImage(new Uri(resourceDir + "visible.png", UriKind.Absolute));
            }
            else
            {
                SaveSetting("SliderIsLocked", false);
                PictureButtonLock.Source = ButtonLock.Source = new BitmapImage(new Uri(resourceDir + "invisible.png", UriKind.Absolute));
            }
        }

        private void ButtonComment_Click(object sender, RoutedEventArgs e)
        {
            if (!settings["CommentsLocked"])
            {
                SaveSetting("CommentsLocked", true);
                ButtonComment.Source = new BitmapImage(new Uri(resourceDir + "comment.png", UriKind.Absolute));
                foreach(Canvas c in CommentCanvas.Children)
                {
                    System.Windows.Controls.TextBox tb = (System.Windows.Controls.TextBox)c.Children[1];
                    if (tb.Text != "")
                    {
                        tb.Visibility = Visibility.Visible;
                    }
                }
            }
            else
            {
                SaveSetting("CommentsLocked", false);
                ButtonComment.Source = new BitmapImage(new Uri(resourceDir + "nocomment.png", UriKind.Absolute));
                foreach (Canvas c in CommentCanvas.Children) //it should hide all comment, even the currently selected one, because we clicked outside of the textbox when we clicked the button.
                {
                    c.Children[1].Visibility = Visibility.Hidden;
                }
            }
        }

        private void ButtonLock_ToolTipOpening(object sender, ToolTipEventArgs e)
        {
            PictureButtonLock.ToolTip = ButtonLock.ToolTip = (settings["SliderIsLocked"]) ? "Controls visible" : "Controls hide";
        }

        private void ButtonComment_ToolTipOpening(object sender, ToolTipEventArgs e)
        {
            ButtonComment.ToolTip = (settings["CommentsLocked"]) ? "Comments visible" : "Comments hide";
        }

        private void ButtonPrevious_Click(object sender, RoutedEventArgs e)
        {
            PrevContent();
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            NextContent(true);
        }

        private void ButtonPlayPause_Click(object sender, RoutedEventArgs e)
        {
            if (videoLoaded)
            {
                if (isPlaying)
                {
                    PauseVideo();
                }
                else
                {
                    PlayVideo();
                }
            }
        }

        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            StopVideo();
        }

        private void TimelineSlider_DragStarted(object sender, DragStartedEventArgs e)
        {
            userIsDraggingSlider = true;
        }

        private void TimelineSlider_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            userIsDraggingSlider = false;
            GetMiddleIndexPos(TimelineSlider.Value);
            MediaElement1.Position = TimeSpan.FromMilliseconds(middleIndexPos);
        }

        private void SpeedRatioSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //Debug.Print("SpeedRatioSlider_ValueChanged, value: " + SpeedRatioSlider.Value + ", slider dragging " + SpeedRatioSlider.sliderDragging);
           if (!SpeedRatioSlider.sliderDragging && !changedByProgramInit)
            {
                MediaElement1.SpeedRatio = SpeedRatioSlider.Value;
                SaveSetting("SpeedRatio", Math.Round(SpeedRatioSlider.Value,1));
            }
        }

        private void VideoVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!changedByProgramInit)
            {
                SaveSetting("VideoVolume", Math.Round(VideoVolume.Value, 2));
            }
        }

        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (isVideoFullscreen)
            {
                double vol = MediaElement1.Volume;
                vol += (e.Delta > 0) ? 0.1 : -0.1;
                vol = (vol > 1) ? 1 : vol;
                vol = (vol < 0) ? 0 : vol;
                MediaElement1.Volume = vol;
            }
        }

        #endregion

        #region Video control functions

        private void PlayVideo()
        {
            MediaElement1.Play();
            isPlaying = true;
            ButtonPlayPause.ToolTip = "Pause";
            ButtonPlayPause.Source = new BitmapImage(new Uri(resourceDir + "pause.png", UriKind.Absolute));
        }

        private void PauseVideo()
        {
            MediaElement1.Pause();
            isPlaying = false;
            ButtonPlayPause.ToolTip = "Play";
            ButtonPlayPause.Source = new BitmapImage(new Uri(resourceDir + "play.png", UriKind.Absolute));
        }

        private void StopVideo()
        {
            //Debug.Print("StopVideo: " + MediaElement1.Position.TotalMilliseconds);
            MediaElement1.Stop();
            TimelineSlider.Value = 0;
            GetMiddleIndexPos(0);
            isPlaying = false;
            ButtonPlayPause.ToolTip = "Play";
            ButtonPlayPause.Source = new BitmapImage(new Uri(resourceDir + "play.png", UriKind.Absolute));
        }

        public void GetMiddleIndexPos(double pos)
        {
            Debug.Print("GetMiddleIndexPos frameIndex.Count " + frameIndex.Count);
            if (settings["SkillsPath"] != "" && File.Exists(OrigToIndex(videoSource)))  //if the index of frame exists, we will find the middle position of the current frame.
            {
                //Debug.Print("GetMiddleIndexPos: pos: " + pos);
                double perc = pos / videoDuration;
                //Example:
                //Frames at 0 10 20, duration is 30
                //pos = 12, perc: 40%, index: 1.2 -> 1
                //pos = 18, perc: 60%, index: 1.8 -> 2
                currentFrameIndex = (int)(perc * frameIndex.Count);               

                if (currentFrameIndex < frameIndex.Count)
                {
                    currentFrameIndexPos = frameIndex[currentFrameIndex]; //milliseconds with microseconds
                }
                else
                {
                    currentFrameIndex = frameIndex.Count - 1;
                    currentFrameIndexPos = frameIndex[currentFrameIndex];
                }

                Debug.Print("GetMiddleIndexPos: " + pos + " " + currentFrameIndex + " " + currentFrameIndexPos + " " + frameIndex.Count);

                //Debug.Print("GetMiddleIndexPos: currentFrameIndexPos: " + currentFrameIndexPos);

                //Example:
                //forward frame step: 0, 16, 29, 57, 72, 85, 99
                //backward frame step: 0, 13, 28, 56, 69, 84, 98
                //ffprobe (rounded milliseconds): 0, 14, 28, 56, 70, 84, 98
                //seeking to 15 shows the second frame. 14 shows first frame. (ffprobe 14.067)
                //(ffprobe 140.671) 140 shows old frame, 141 shows new frame

                secondcurrentFrameIndexPos = currentFrameIndexPos;
                if (currentFrameIndexPos > pos) //find previous frame, until we find the one that is lower equal than pos.
                {
                    do
                    {
                        currentFrameIndex--;
                        currentFrameIndexPos = secondcurrentFrameIndexPos;
                        secondcurrentFrameIndexPos = frameIndex[currentFrameIndex];
                    }
                    while (secondcurrentFrameIndexPos > pos);
                    //the average time will belong to the newly found previous frame
                }
                else // pos >= currentFrameIndexPos, find next frame
                {
                    do
                    {
                        currentFrameIndex++; //in case of last frame, this now equals to frameIndex.Count.
                        currentFrameIndexPos = secondcurrentFrameIndexPos; //in case of last frame, this is the last frame's timestamp
                        if (currentFrameIndex < frameIndex.Count)
                        {
                            secondcurrentFrameIndexPos = frameIndex[currentFrameIndex];
                        }
                        else //last frame, currentFrameIndex = frameIndex.Count
                        {
                            secondcurrentFrameIndexPos = videoDuration;
                        }
                        //Debug.Print("secondcurrentFrameIndexPos: " + secondcurrentFrameIndexPos.ToString(CultureInfo.InvariantCulture) + ", pos: " + pos.ToString(CultureInfo.InvariantCulture));

                        //what if duration is 345 ms, but pos is 345.5? Loop will end, when secondcurrentFrameIndexPos reaches videoDuration.
                        //what if duration is 345 ms, but pos is 344.5? Loop will end of both terms.

                        //rounding is done now upon adding the timestamps to frameIndex.
                        //Debug.Print((secondcurrentFrameIndexPos == pos).ToString()); //false
                        //both of these will work:
                        //secondcurrentFrameIndexPos = double.Parse(secondcurrentFrameIndexPos.ToString(CultureInfo.InvariantCulture),CultureInfo.InvariantCulture);
                        //secondcurrentFrameIndexPos = Math.Round(secondcurrentFrameIndexPos, 3);
                        //Debug.Print((secondcurrentFrameIndexPos == pos).ToString()); //true
                    }
                    while ((secondcurrentFrameIndexPos <= pos) && (secondcurrentFrameIndexPos < videoDuration));
                    currentFrameIndex--; //the average time belongs to the previous frame
                }
                //Debug.Print(currentFrameIndexPos + " " + secondcurrentFrameIndexPos);
                middleIndexPos = (currentFrameIndexPos + secondcurrentFrameIndexPos) / 2;

                if (secondcurrentFrameIndexPos < currentFrameIndexPos) //take the lower value as the current frame's position
                {
                    currentFrameIndexPos = secondcurrentFrameIndexPos;
                }
            }
            else
            {
                middleIndexPos = (Math.Floor(pos / videoFrameLength) + 0.5) * videoFrameLength;
            }
            //WriteStatus();
        }

        #endregion

        #region Path converters

        private string OrigToThumb(string fileName)
        {
            fileName = fileName.Replace(settings["SkillsPath"], ""); //removing root directory
            fileName = fileName.Replace(@"\", settings["FileNameSeparator"]); //replacing \, 0 or 1 times
            if (System.IO.Path.GetExtension(fileName).ToLower() == ".png")
            {
                fileName = rootDir + @"Thumbnails\" + System.IO.Path.GetFileNameWithoutExtension(fileName) + ".png";
            }
            else
            {
                if (System.IO.Path.GetExtension(fileName).ToLower() == ".jpg")
                {
                    fileName = rootDir + @"Thumbnails\" + System.IO.Path.GetFileNameWithoutExtension(fileName) + ".jpg";
                }
                else
                {
                    fileName = rootDir + @"Thumbnails\" + System.IO.Path.GetFileNameWithoutExtension(fileName) + settings["FileNameSeparator"] + "mp4.jpg";
                }
            }
                    
            return fileName;
        }

        private string OrigToIndex(string fileName)
        {
            //must be video
            fileName = fileName.Replace(settings["SkillsPath"], ""); //removing root directory
            fileName = fileName.Replace(@"\", settings["FileNameSeparator"]); //replacing \, 0 or 1 times
            fileName = rootDir + @"Indexes\" + System.IO.Path.GetFileNameWithoutExtension(fileName) + ".txt"; //Adding program directory and .txt
            return fileName;
        }

        private string OrigToComment(string fileName)
        {
            //must be video
            fileName = fileName.Replace(settings["SkillsPath"], ""); //removing root directory
            fileName = fileName.Replace(@"\", settings["FileNameSeparator"]); //replacing \, 0 or 1 times
            fileName = rootDir + @"Comments\" + System.IO.Path.GetFileNameWithoutExtension(fileName) + ".txt"; //Adding program directory and .txt
            return fileName;
        }

        private string ThumbToOrig(string fileName) //file:/// have to be not present.
        {
            string thumbName = System.IO.Path.GetFileName(fileName);

            int pos = thumbName.LastIndexOf(settings["FileNameSeparator"]);
            int periodPos = thumbName.LastIndexOf(".");
            string end = thumbName.Substring(pos + 1, periodPos - pos - 1);

            var regex = new Regex(Regex.Escape(settings["FileNameSeparator"]));
            string selectedFile;

            if (end == "mp4")
            {
                selectedFile = regex.Replace(thumbName.Substring(0, pos), @"\", 1) + ".mp4";
            }
            else
            {
                selectedFile = regex.Replace(thumbName, @"\", 1);
            }

            try //when a selected folder is renamed outside of program, the folder we got from the thumb name does not exit anymore. LoadContent calls this function.  
            //if the file is renamed, no error will occur, instead the function returns null.
            {
                return Directory.GetFiles((string)settings["SkillsPath"], selectedFile).FirstOrDefault(); //Gets the case-sensitive file name.
            }
            catch (Exception)
            {
                return "";
            }
        }

        private string ThumbToOrigFileName(string fileName) //PositionLabel uses it.
        //situation:  when a selected folder is renamed outside of program, the folder we got from the thumb name does not exit anymore, therefore ThumbToOrig cannot be used.
        //we just get the filename and ignore its folder instead.        
        {
            string thumbName = System.IO.Path.GetFileName(fileName);
            int pos = thumbName.LastIndexOf(settings["FileNameSeparator"]);
            int periodPos = thumbName.LastIndexOf(".");
            string end = thumbName.Substring(pos + 1, periodPos - pos - 1);

            var regex = new Regex(Regex.Escape(settings["FileNameSeparator"]));
            string selectedFileName;

            if (end == "mp4")
            {
                selectedFileName = regex.Replace(thumbName.Substring(0, pos), @"\", 1) + ".mp4";
            }
            else
            {
                selectedFileName = regex.Replace(thumbName, @"\", 1);
            }
            pos = selectedFileName.LastIndexOf(@"\");
            selectedFileName = selectedFileName.Substring(pos + 1);

            return selectedFileName;
        }

        private string ThumbToComment(string fileName) //PositionLabel uses it.
        //situation:  when a selected folder is renamed outside of program, the folder we got from the thumb name does not exit anymore, therefore OrigToComment(ThumbToOrig) cannot be used.
        {
            return rootDir + @"Comments\" + System.IO.Path.GetFileNameWithoutExtension(fileName) + ".txt";
        }

        private bool IsThumbVideo(string fileName)
        {
            string thumbName = System.IO.Path.GetFileName(fileName);
            int pos = thumbName.LastIndexOf(settings["FileNameSeparator"]);
            int periodPos = thumbName.LastIndexOf(".");
            string end = thumbName.Substring(pos + 1, periodPos - pos - 1);

            var regex = new Regex(Regex.Escape(settings["FileNameSeparator"]));
            string selectedFileName;

            if (end == "mp4")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Other 

        private void Msgbox(dynamic s)
        {
            System.Windows.MessageBox.Show(Convert.ToString(s, CultureInfo.InvariantCulture));
        }

        private void CW(string s)
        {
            Console.WriteLine("---------- " + s + " ----------");
        }

        #endregion

        #region Debug

        private void WriteStatus()
        {
            double pos = MediaElement1.Position.TotalMilliseconds;
            //milliText.Text = " middleIndexPos: " + Convert.ToString(middleIndexPos) + ", from video: " + Convert.ToString(pos) + ", currentFrameIndexPos: " + Convert.ToString(currentFrameIndexPos) + ", currentFrameIndex: " + Convert.ToString(currentFrameIndex);
        }

        private void PrintArrayDouble(double[] arr)
        {
            string s = "";
            foreach (double elem in arr)
            {
                s += Convert.ToString(elem, CultureInfo.InvariantCulture) + "\n";
            }
            Msgbox(s);
        }

        private void Context_GetTemplate(object sender, RoutedEventArgs e) //for getting the template of the context menu
        {
            var str = new StringBuilder();
            using (var writer = new StringWriter(str))
                XamlWriter.Save(MyContext.Template, writer);
            Debug.Write(str);
        }

        #endregion

        #region Settings

        //private Dictionary<string, string> changedStartSettings;
        private Dictionary<string, dynamic> changedSettings;
        private bool settingsPageOpen;
        IInputElement FocusElement; //focused element before opening the settings page.
        //private List<string> shortCuts = new List<string>() { "one", "two", "three", "four", "five" };

        private void SettingsOpen_Click(object sender, RoutedEventArgs e)
        {
            LoadSettings();
            settingsPageOpen = true;
            SettingsPage.Visibility = Visibility.Visible;
            FocusElement = FocusManager.GetFocusedElement(this);
            cancelThumbLosingFocus = true; //so the active selection doesn't disappear.
            SettingsSaveButton.Focus();
            cancelThumbLosingFocus = false;
            SettingsBackground.Visibility = Visibility.Visible;
            //changedStartSettings = new Dictionary<string, string>();
            changedSettings = new Dictionary<string, dynamic>();
            //hiding background controls for focus

            ListScroll.Focusable = false;
            SkillsList.Focusable = false;
            SortBy.Focusable = false;
            SortOrder.Focusable = false;
            ThumbSizeSlider.Focusable = false;
            ShowAllFilenames.Focusable = false;
            ThumbScroll.Focusable = false;
        }

        private void SettingsCancelButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsPage.Visibility = Visibility.Hidden;
            SettingsBackground.Visibility = Visibility.Hidden;
            settingsPageOpen = false;

            ListScroll.Focusable = true;
            SkillsList.Focusable = true;
            SortBy.Focusable = true;
            SortOrder.Focusable = true;
            ThumbSizeSlider.Focusable = true;
            ShowAllFilenames.Focusable = true;
            ThumbScroll.Focusable = true;

            if (currentPicIndex != -1)
            {
                ThumbScroll.Focus();
            }
        }

        private void SettingsSaveButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsApplyButton_Click(null, null);
            SettingsCancelButton_Click(null, null);
        }

        private void SettingsResetButton_Click(object sender, RoutedEventArgs e) //resets values that have not been applied
        {
            changedSettings = new Dictionary<string, dynamic>();
            LoadSettings();
        }

        private void SettingsDefaultButton_Click(object sender, RoutedEventArgs e)
        {
            dialogActivation = true;
            var confirmResult = System.Windows.MessageBox.Show("Are you sure you want to erase all your settings, and restore the defaults?", "Confirm reset", MessageBoxButton.YesNo); //Window activation event runs here.
            //Debug.Print("SettingsDefaultButton_Click Dialog closed");
            dialogActivation = false;
            
            if (confirmResult == MessageBoxResult.Yes)
            {
                File.Delete(resourceDir + "settings.ini");
                File.Copy(resourceDir + "defaultsettings.ini", resourceDir + "settings.ini");
                ReadSettings();
                changedSettings = new Dictionary<string, dynamic>();

                LoadSettings(); //values we set here are now registered in changedSettings.

                foreach (KeyValuePair<string, dynamic> kvp in settings) { changedSettings[kvp.Key] = kvp.Value; }

                Debug.Print("SettingsDefaultButton_Click count " + changedSettings.Count.ToString());
                SettingsApplyButton_Click(null, null); //settings that are set in the program will not be visible (without restart of the program), like thumbnail sort order.
                
                //settings not set on settings page
                SortBy.Text = settings["SortBy"];
                SortOrder.Text = settings["SortOrder"];
                ShowAllFilenames.IsChecked = settings["ShowFileNames"];
                //list's selection change event does not fire
                BorderRect.Visibility = Visibility.Hidden;
                currentPicIndex = -1;
                selectedPicIndexes.Clear();
                DrawMultiSelection();
            }
        }

        private void SettingsApplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (changedSettings.ContainsKey("FileNameSeparator")) //replace filename separator in filenames.
            {
                string[] folders = new string[] { "Thumbnails", "Indexes", "Comments" };
                foreach (string folder in folders)
                {
                    string[] files = Directory.GetFiles(rootDir + @"\" + folder);
                    foreach (string origFile in files)
                    {
                        string newFile = origFile.Replace(settings["FileNameSeparator"], changedSettings["FileNameSeparator"]);
                        if (origFile != newFile) //files related to root files do not contain separator.
                        {
                            if (File.Exists(newFile))
                            {
                                File.Delete(newFile);
                            }
                            File.Move(origFile, newFile);
                        }
                    }
                }

                //changing thumbnails' image source.
                displayedThumbs.Clear();
                for (int i = 0; i < Thumbs.Children.Count; i++)
                {
                    Image im = (Image)((Border)Thumbs.Children[i]).Child;
                    string oldSource = ((BitmapImage)im.Source).UriSource.LocalPath;
                    if (oldSource.IndexOf(rootDir + @"Thumbnails\") != -1) //if it is a video, not a picture
                    {
                        string newSource = oldSource.Replace(settings["FileNameSeparator"], changedSettings["FileNameSeparator"]);
                        BitmapImage imageBitmap = new BitmapImage();
                        imageBitmap.BeginInit();
                        imageBitmap.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                        imageBitmap.CacheOption = BitmapCacheOption.OnLoad;//makes it possible to delete the image, otherwise it will be locked. If I set it to OnLoad however, the image will not refresh when the thumbnail image file refreshes.
                        imageBitmap.UriSource = new Uri(newSource, UriKind.Absolute);
                        imageBitmap.EndInit();
                        im.Source = imageBitmap;
                        displayedThumbs.Add(newSource);
                    }
                    else
                    {
                        displayedThumbs.Add(oldSource);
                    }

                }
            }
            //if we set changedSettings = settings, Error: Collection was modified; enumeration operation may not execute
            //instead, we can use foreach (KeyValuePair<string, dynamic> kvp in settings) { changedSettings[kvp.Key]=kvp.Value; }
            foreach (KeyValuePair<string, dynamic> kvp in changedSettings)
            {
                settings[kvp.Key] = kvp.Value;
            }

            //Applying layout settings, even if they are not changed.
            Debug.Print("Settingsapply screen size " + SystemParameters.WorkArea.Height + " " + SystemParameters.WorkArea.Width);

            //window can only be centered on startup, now we do it manually.

            changedByProgramWindow = true;
            //similar to SetWindowPosSize(), but we do centering here too
            this.Width = settings["NormalScreenWidth"];
            this.Height = settings["NormalScreenHeight"];
            if (!settings["WindowStartupLocationCenterScreen"]) //not centered
            {
                this.Left = settings["NormalScreenLeft"];
                this.Top = settings["NormalScreenTop"];
            }
            else
            {
                this.Left = (windowWidth - this.Width) / 2;
                this.Top = (windowHeight - this.Height) / 2;
            }

            if (settings["StartFullScreen"])
            {
                if (this.WindowStyle != WindowStyle.None)
                {
                    EnterFullScreen(false);
                }
            }
            else
            {
                if (this.WindowStyle == WindowStyle.None)
                {
                    ExitFullScreen(true);
                }
                if (settings["StartMaximized"])
                {
                    this.WindowState = WindowState.Maximized;
                }
                else //normal window
                {
                    this.WindowState = WindowState.Normal;
                }
            }
            changedByProgramWindow = false;

            changedByProgramInit = true;
            MainGrid.ColumnDefinitions[0].Width = new GridLength(settings["SkillsListWidth"]);
            changedByProgramInit = false;

            if (changedSettings.ContainsKey("SkillsPath")) //if the root folder was changed
            {
                if (!Directory.Exists(settings["SkillsPath"]))
                {
                    //clear thumbnails, and set start page underneath settings.
                    //Msgbox("The selected directory does not exist.");
                    ClearThumbs();
                    changedByProgramList = true;
                    SkillsList.ItemsSource = null; //when changing root directory, the current selection is removed, and fires the change event, but the selecteditem is null.
                    changedByProgramList = false;
                    SkillsListSource = new List<string>(); //so generate all thumbnails doesn't return an error.
                    settings["SelectedSkill"] = "";
                    DefaultPage.Visibility = Visibility.Visible;
                }
                else
                {
                    DefaultPage.Visibility = Visibility.Collapsed;
                    ClearThumbs();
                    if (settings["SelectedSkill"] != ".")
                    {
                        SaveSetting("SelectedSkill", ".");
                    }
                    LoadDirList(); //the list's selectionchange event will not fire, because the default dir is the first item, ., and we set the same.
                    StartUpdateThumbs();
                }
            }

            if (changedSettings.ContainsKey("ThumbW") || changedSettings.ContainsKey("ThumbH")) //resize thumbnails
            {
                //must update the bound thumbW and thumbH
                thumbW = settings["ThumbW"];
                thumbH = settings["ThumbH"];

                ThumbSizeLabel.Text = thumbW + " x " + thumbH;

                //update pictures
                for (int i = 0; i < Thumbs.Children.Count; i++)
                {
                    Image im = (Image)((Border)Thumbs.Children[i]).Child;
                    im.Width = thumbW;
                    im.Height = thumbH;
                }

                Thumbs.UpdateLayout();  //Thumbs_SizeChanged is called here, but availWidth doesn't change yet, because ThumbScroll hasn't updated its scrollableheight value yet. 
                ThumbScroll.UpdateLayout();

                double newScrollHeight = ThumbScroll.ScrollableHeight;

                if (newScrollHeight == 0) //if the content shrinked, so the scrollbar disappeared.
                {
                    availWidth = ThumbScroll.ActualWidth;
                }
                else //if the content grew, so the scrollbar appeared.
                {
                    availWidth = ThumbScroll.ActualWidth - 17;
                }

                //updating slider value
                changedByProgramThumbs = true;
                ThumbSizeSlider.Value = (int)(availWidth / (thumbW + 1)); //the scrollbar visibility could have changed depending on how many pictures were loaded. Important for positioning filename label correctly.
                changedByProgramThumbs = false;

                //update FileNameGridAllCanvas, FileNameGrid's width is set by Binding.
                for (int i = 0; i < FileNameGridAllCanvas.Children.Count; i++)
                {
                    ((Grid)FileNameGridAllCanvas.Children[i]).Width = thumbW + 1;
                    ((Grid)FileNameGridAllCanvas.Children[i]).Height = thumbH + 1;
                }
            }

            SaveSettings();
            changedSettings = new Dictionary<string, dynamic>();
            SettingsApplyButton.IsEnabled = false;
            SettingsResetButton.IsEnabled = false;
        }
        
        private void SettingsIsModified()
        {
            if (changedSettings.Count != 0)
            {
                SettingsApplyButton.IsEnabled = true;
                SettingsResetButton.IsEnabled = true;
            }
            else
            {
                SettingsApplyButton.IsEnabled = false;
                SettingsResetButton.IsEnabled = false;
            }
        }

        private void LoadSettings()
        {
            changedByProgramSettings = true;
            SettingsApplyButton.IsEnabled = false;
            SettingsResetButton.IsEnabled = false;
            foreach (KeyValuePair<string, dynamic> kvp in settings)
            {
                //Debug.Print("LoadSettings " + kvp.Key);
                if (kvp.Key != "SelectedSkill" && kvp.Key != "SortBy" && kvp.Key != "SortOrder" && kvp.Key != "ShowFileNames" && kvp.Key != "ShowExtractStatus" && kvp.Key != "SliderIsLocked"
                    && kvp.Key != "CommentsLocked"  && kvp.Key != "SpeedRatio" && kvp.Key != "VideoVolume" && kvp.Key != "FrameRatioSlider")
                {
                    //Debug.Print(kvp.Key);
                    if (kvp.Value is string)
                    {
                        System.Windows.Controls.TextBox control = (System.Windows.Controls.TextBox)this.FindName("Setting" + kvp.Key);
                        control.Text = kvp.Value;
                    }
                    else if (kvp.Value is int)
                    {
                        System.Windows.Controls.TextBox control = (System.Windows.Controls.TextBox)this.FindName("Setting" + kvp.Key);
                        control.Text = ((int)kvp.Value).ToString(CultureInfo.InvariantCulture);
                    }
                    else //bool
                    {
                        if (this.FindName("Setting" + kvp.Key) is System.Windows.Controls.CheckBox)
                        {
                            System.Windows.Controls.CheckBox control = (System.Windows.Controls.CheckBox)this.FindName("Setting" + kvp.Key);
                            control.IsChecked = kvp.Value;
                        }
                        else
                        {
                            System.Windows.Controls.RadioButton control = (System.Windows.Controls.RadioButton)this.FindName("Setting" + kvp.Key);
                            control.IsChecked = kvp.Value;
                        }
                    }
                }
            }

            StartFullScreen_Set();
            changedByProgramSettings = false;

            //Shortcut keys
            //ShortCutTable.ItemsSource = shortCuts;
            }

        private void RegisterSettingChange(object sender, EventArgs e) //some fields containing numbers handle the change themselves
        {
            if (changedByProgramSettings) return;

            string settingName = ((System.Windows.Controls.Control)sender).Name.Replace("Setting", "");
            if (sender is System.Windows.Controls.CheckBox)
            {
                changedSettings[settingName] = ((System.Windows.Controls.CheckBox)sender).IsChecked;

                if (changedSettings[settingName] == settings[settingName])
                {
                    changedSettings.Remove(settingName);
                }
            }
            else if (sender is System.Windows.Controls.RadioButton)
            {
                if (settingName == "BackgroundBlack")
                {
                    changedSettings["BackgroundBlack"] = true;
                    changedSettings["BackgroundGray"] = false;
                    changedSettings["BackgroundWhite"] = false;
                }
                else if (settingName == "BackgroundGray")
                {
                    changedSettings["BackgroundBlack"] = false;
                    changedSettings["BackgroundGray"] = true;
                    changedSettings["BackgroundWhite"] = false;
                }
                else
                {
                    changedSettings["BackgroundBlack"] = false;
                    changedSettings["BackgroundGray"] = false;
                    changedSettings["BackgroundWhite"] = true;
                }

                if (changedSettings["BackgroundBlack"] == settings["BackgroundBlack"])
                {
                    changedSettings.Remove("BackgroundBlack");
                }
                if (changedSettings["BackgroundGray"] == settings["BackgroundGray"])
                {
                    changedSettings.Remove("BackgroundGray");
                }
                if (changedSettings["BackgroundWhite"] == settings["BackgroundWhite"])
                {
                    changedSettings.Remove("BackgroundWhite");
                }
            }
            else if (sender is System.Windows.Controls.TextBox)
            {
                if (settings[settingName] is int)
                {
                    changedSettings[settingName] = int.Parse(((System.Windows.Controls.TextBox)sender).Text);
                }
                else //string
                {
                    changedSettings[settingName] = ((System.Windows.Controls.TextBox)sender).Text;
                }

                if (changedSettings[settingName] == settings[settingName])
                {
                    changedSettings.Remove(settingName);
                }
            }
            
            SettingsIsModified();
            //Debug.Print("RegisterSettingChange, changedsettings count: " + changedSettings.Count);
        }

        private void StartFullScreen_Set() //takes into account all 3 checkboxes to determine which fields should be disabled.
        {
            if (changedByProgramSettings) return;

            Debug.Print("StartFullScreen_Set");
            if ((bool)SettingStartFullScreen.IsChecked)
            {
                SettingStartMaximized.IsEnabled = false;
                SettingNormalScreenWidth.IsEnabled = false;
                SettingNormalScreenHeight.IsEnabled = false;
                SettingWindowStartupLocationCenterScreen.IsEnabled = false;
                SettingNormalScreenLeft.IsEnabled = false;
                SettingNormalScreenTop.IsEnabled = false;
            }
            else
            {
                SettingStartMaximized.IsEnabled = true;
                if ((bool)SettingStartMaximized.IsChecked)
                {
                    SettingNormalScreenWidth.IsEnabled = false;
                    SettingNormalScreenHeight.IsEnabled = false;
                    SettingWindowStartupLocationCenterScreen.IsEnabled = false;
                    SettingNormalScreenLeft.IsEnabled = false;
                    SettingNormalScreenTop.IsEnabled = false;
                }
                else
                {
                    SettingNormalScreenWidth.IsEnabled = true;
                    SettingNormalScreenHeight.IsEnabled = true;
                    SettingWindowStartupLocationCenterScreen.IsEnabled = true;

                    if ((bool)SettingWindowStartupLocationCenterScreen.IsChecked)
                    {
                        SettingNormalScreenLeft.IsEnabled = false;
                        SettingNormalScreenTop.IsEnabled = false;
                    }
                    else
                    {
                        SettingNormalScreenLeft.IsEnabled = true;
                        SettingNormalScreenTop.IsEnabled = true;
                    }
                }
            }
        }

        private void SettingWindow_Checked(object sender, RoutedEventArgs e)
        {
            StartFullScreen_Set();
            RegisterSettingChange(sender, e);
        }

        private void SettingNumericField_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (changedByProgramSettings) return;
            Debug.Print("SettingNumericField_TextChanged");
            NumericField obj = (NumericField)sender;
            string settingName = obj.Name.Replace("Setting", "");
            string text = obj.Text;
            int num;
            bool result = int.TryParse(text, out num);
            if (result)
            {
                num = (num < obj.ValueMin) ? obj.ValueMin : num;
                num = (num > obj.ValueMax) ? obj.ValueMax : num;
                changedSettings[settingName] = num;
            }

            if (changedSettings.ContainsKey(settingName) && changedSettings[settingName] == settings[settingName])
            {
                changedSettings.Remove(settingName);
            }
            SettingsIsModified();
        }

        private void SettingNumericField_LostFocus(object sender, RoutedEventArgs e) //use the last successful value, or from settings
        {
            Debug.Print("SettingNumericField_LostFocus");
            NumericField obj = (NumericField)sender;
            string settingName = obj.Name.Replace("Setting", "");
            int num = changedSettings.ContainsKey(settingName) ? changedSettings[settingName] : settings[settingName];
            obj.Text = num.ToString(CultureInfo.InvariantCulture);
        }

        private void SettingThumbW_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (changedByProgramSettings) return;

            NumericField obj = (NumericField)sender;
            string settingName = obj.Name.Replace("Setting", "");
            string text = obj.Text;
            int num;
            bool result = int.TryParse(text, out num);
            if (result)
            {
                num = (num < obj.ValueMin) ? obj.ValueMin : num;
                num = (num > obj.ValueMax) ? obj.ValueMax : num;
                changedSettings[settingName] = num;
                changedSettings["ThumbH"] = (int)Math.Round((double)num * 9 / 16);
                changedByProgramSettings = true;
                SettingThumbH.Text = changedSettings["ThumbH"].ToString(CultureInfo.InvariantCulture);
                changedByProgramSettings = false;
            }

            if (changedSettings.ContainsKey(settingName) && changedSettings[settingName] == settings[settingName] && changedSettings["ThumbH"] == settings["ThumbH"])
            {
                changedSettings.Remove(settingName);
                changedSettings.Remove("ThumbH");
            }
            SettingsIsModified();
        }

        private void SettingThumbH_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (changedByProgramSettings) return;

            NumericField obj = (NumericField)sender;
            string settingName = obj.Name.Replace("Setting", "");
            string text = obj.Text;
            int num;
            bool result = int.TryParse(text, out num);
            if (result)
            {
                num = (num < obj.ValueMin) ? obj.ValueMin : num;
                num = (num > obj.ValueMax) ? obj.ValueMax : num;
                changedSettings[settingName] = num;
                changedSettings["ThumbW"] = (int)Math.Round((double)num * 16 / 9);
                changedByProgramSettings = true;
                SettingThumbW.Text = changedSettings["ThumbW"].ToString(CultureInfo.InvariantCulture);
                changedByProgramSettings = false;
            }

            if (changedSettings.ContainsKey(settingName) && changedSettings[settingName] == settings[settingName] && changedSettings["ThumbW"] == settings["ThumbW"])
            {
                changedSettings.Remove(settingName);
                changedSettings.Remove("ThumbW");
            }
            SettingsIsModified();
        }

        private void SettingSelectSkillsPath_Click(object sender, RoutedEventArgs e)
        {
            //Similar to ChooseStartDir_Click();
            FolderBrowserDialog obj = new FolderBrowserDialog();
            obj.Description = "Select the directory which contains your subfolders.";
            obj.ShowDialog();
            if (obj.SelectedPath != "")
            {
                SettingSkillsPath.Text = obj.SelectedPath + @"\"; //text change event will be called now.
            }
        }

        private void SettingSkillsPath_LostFocus(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TextBox obj = (System.Windows.Controls.TextBox)sender;
            if (obj.Text.Length > 0 && obj.Text.ToCharArray()[obj.Text.Length - 1] != '\\')
            {
                obj.Text += @"\"; //text change event will update the changedSettings
            }
        }

        private void SettingFilteredField_TextChanged(object sender, TextChangedEventArgs e)
        {
            //excluded characters: / \ ? % * : | " < >
            if (changedByProgramSettings) return;

            System.Windows.Controls.TextBox obj = (System.Windows.Controls.TextBox)sender;
            string settingName = obj.Name.Replace("Setting", "");
            string text = obj.Text;
            text = RemoveIllegalChars(text);
            if (text.Length != 0)
            {
                changedSettings[settingName] = text;
            }

            if (changedSettings.ContainsKey(settingName) && changedSettings[settingName] == settings[settingName])
            {
                changedSettings.Remove(settingName);
            }
            SettingsIsModified();
        }

        private void SettingFilteredField_LostFocus(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TextBox obj = (System.Windows.Controls.TextBox)sender;
            string settingName = obj.Name.Replace("Setting", "");
            obj.Text = changedSettings.ContainsKey(settingName) ? changedSettings[settingName] : settings[settingName];
        }

        #endregion

        #region List menu

        private string skillsListItem;
        private int skillsListIndex;

        private void SkillsList_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) //to prevent Ctrl+Click from unselecting
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                e.Handled = true;
            }
        }

        private void SkillsList_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e) //to prevent selection on right-click. It is for the context menu. // We implement selection now.
        {
            //e.Handled = true;
        }

        private void SkillsList_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (!Directory.Exists(settings["SkillsPath"]))
            {
                e.Handled = true;
            }
            //e.Handled = true;
            skillsListItem = (string)SkillsList.SelectedItem;
            skillsListIndex = SkillsList.SelectedIndex;
            if (skillsListIndex == 0) //root
            {
                ListRename.Visibility = Visibility.Collapsed;
                ListDelete.Visibility = Visibility.Collapsed;
            }
            else
            {
                ListRename.Visibility = Visibility.Visible;
                ListDelete.Visibility = Visibility.Visible;
            }
            Debug.Print("SkillsList_ContextMenuOpening "+ skillsListItem + " " + skillsListIndex + " " + ListScroll.ContentVerticalOffset);
            //though menu opens, we cannot select menuitems, while thumbnails are laoding.
            Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle);
            //e.Handled = true;
        }

        private void ListNew_Click(object sender, RoutedEventArgs e)
        {          
            ListNewFieldWindow.Visibility = Visibility.Visible;
            ListNewField.Text = "";
            ListNewField.Focus();
            
            /*Point relativePoint = skillsListItem.TransformToAncestor(SkillsList).Transform(new Point(0, 0));
            Debug.Print(relativePoint.X + " " + relativePoint.Y);
            relativePoint = skillsListItem.TransformToAncestor(MainGrid).Transform(new Point(0, 0));
            Debug.Print(relativePoint.X + " " + relativePoint.Y);*/
        }

        private void ListRename_Click(object sender, RoutedEventArgs e) //click on the menu item
        {
            double top = ListScroll.ContentVerticalOffset == 0 ? skillsListIndex * 20 + 2 : skillsListIndex * 20 + 2 - ListScroll.ContentVerticalOffset;
            //double right = ListScroll.ScrollableHeight == 0 ? 0 : 18;
            thumbsMouseEnabledList = false;
            ListRenameField.Margin = new Thickness(0, top, 0, 0);
            ListRenameField.Visibility = Visibility.Visible;
            ListRenameField.Text = skillsListItem;
            ListRenameField.Focus();
            ListRenameField.CaretIndex = ListRenameField.Text.Length;           
            
            //implement also mouse click to escape field.

            //Debug.Print("ListRename_Click menuitem PointFromScreen " + skillsListItem.PointFromScreen(new Point(0, 0)).X + " " + skillsListItem.PointFromScreen(new Point(0, 0)).Y);
            //Debug.Print("ListRename_Click menuitem PointToScreen " + skillsListItem.PointToScreen(new Point(0, 0)).X + " " + skillsListItem.PointToScreen(new Point(0, 0)).Y);
            //Debug.Print("ListRename_Click menuitem PointToScreen " + skillsListItem.PointToScreen(new Point(0, 0)).X + " " + skillsListItem.PointToScreen(new Point(0, 0)).Y);
        }

        private void ListScroll_ScrollChanged(object sender, ScrollChangedEventArgs e) //moves textfield as we scroll the listbox
        {
            if (ListRenameField.Visibility == Visibility.Visible) {
                double top = skillsListIndex * 20 + 2 - ListScroll.ContentVerticalOffset;
                double right = 18;
                ListRenameField.Margin = new Thickness(0, top, right, 0);
            }  
        }

        private void ListDelete_Click(object sender, RoutedEventArgs e)
        {
            dialogActivation = true;
            var confirmResult = System.Windows.MessageBox.Show("Do you really want to delete the \"" + skillsListItem + "\" directory?", "Confirm delete", MessageBoxButton.YesNo);
            dialogActivation = false;

            if (confirmResult == MessageBoxResult.Yes)
            {
                Directory.Delete(settings["SkillsPath"] + skillsListItem, true);

                SkillsListSource.RemoveAt(skillsListIndex); //no re-sorting needed
                changedByProgramList = true;
                SkillsList.ItemsSource = null;
                SkillsList.ItemsSource = SkillsListSource;
                //SkillsList.Focus does not make a difference here.
                changedByProgramList = false;
                //now we are updating the thumbnails    
                SkillsList.SelectedIndex = skillsListIndex < SkillsListSource.Count ? skillsListIndex : 0; //select next item in the list, unless we deleted the last one.  
                FocusListItem();
            }            
        }

        private void ListRenameField_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    string newName = RemoveIllegalChars(ListRenameField.Text);
                    if (skillsListItem == newName)
                    {
                        //no action
                    }
                    else if (skillsListItem.ToLower() == newName.ToLower()) //only case changed
                    {
                        RenameDir(skillsListItem, newName, true);
                    }
                    else //rename folder in file system.
                    {
                        if (Directory.Exists(settings["SkillsPath"] + newName))
                        {
                            dialogActivation = true;
                            var confirmResult = System.Windows.MessageBox.Show("This directory already exists. Do you want to overwrite it?", "Confirm overwrite", MessageBoxButton.YesNo);
                            dialogActivation = false;

                            if (confirmResult == MessageBoxResult.Yes)
                            {
                                Directory.Delete(settings["SkillsPath"] + newName, true);
                                SkillsListSource.Remove(newName);
                                RenameDir(skillsListItem, newName, false);
                            }
                        }
                        else
                        {
                            RenameDir(skillsListItem, newName, false);
                        }
                    }
                    ListRenameField.Visibility = Visibility.Hidden;     
                    thumbsMouseEnabledList = true;
                }
                else if (e.Key == Key.Escape)
                {
                    ListRenameField.Visibility = Visibility.Hidden;
                    thumbsMouseEnabledList = true;
                }
            }
            catch (Exception ex) //Access to the path 'C:\Acrobatic Tumbling\_Newnew' is denied, while updating thumbnails.
            {
                Msgbox(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void ListNewField_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try {
                if (e.Key == Key.Enter)
                {
                    ListNewFieldWindow.Visibility = Visibility.Hidden;
                    string newName = RemoveIllegalChars(ListNewField.Text);
                    //create folder, but before that we check if it already exists.
                    if (Directory.Exists(settings["SkillsPath"] + newName))
                    {
                        dialogActivation = true;
                        var confirmResult = System.Windows.MessageBox.Show("This directory already exists. Do you want to overwrite it?", "Confirm overwrite", MessageBoxButton.YesNo);
                        dialogActivation = false;

                        if (confirmResult == MessageBoxResult.Yes)
                        {
                            Directory.Delete(settings["SkillsPath"] + newName, true);

                            //the new dir might only differ in case from an existing one.
                            string removeDir="";
                            foreach (string dir in SkillsListSource)
                            {
                                if (dir.ToLower() == newName.ToLower())
                                {
                                    removeDir = dir;
                                    break;
                                }
                            }
                            SkillsListSource.Remove(removeDir);

                            if (((string)settings["SelectedSkill"]).ToLower() == newName.ToLower()) //if the directory is selected, which is the same as the new directory
                            {
                                ClearThumbs();
                            }
                            NewDir(newName);
                        }
                    }
                    else
                    {
                        NewDir(newName);
                    }
                }
                else if (e.Key == Key.Escape)
                {
                    ListNewFieldWindow.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex) //Access to the path 'C:\Acrobatic Tumbling\_Newnew' is denied, while updating thumbnails.
            {
                Msgbox(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void NewDir(string newName)
        {
            Directory.CreateDirectory(settings["SkillsPath"] + newName);
            SkillsListSource.Add(newName);
            Debug.Print("NewDir adding " + newName);
            Debug.Print("NewDird adding " + newName);
            SkillsListSource.Sort();
            changedByProgramList = true;
            object tempSelectedItem = SkillsList.SelectedItem;
            SkillsList.ItemsSource = null;
            SkillsList.ItemsSource = SkillsListSource;
            SkillsList.Focus();

            SkillsList.UpdateLayout(); // Without this, when creating dir above the currently selected item, selection does not remain, it changes to the item above.            
            Dispatcher.Invoke(new Action(() => { }), DispatcherPriority.ContextIdle); //ensures, FocusListItem does not cause the problem above.

            SkillsList.SelectedItem = tempSelectedItem;
            Debug.Print("NewDir selectedItem " + SkillsList.SelectedItem);
            changedByProgramList = false;

            FocusListItem(); //list will not scroll now to make the new dir visible, if it is out of range. List only scrolls as long as current directory is in range.
            //var listBoxItem = (ListBoxItem)SkillsList.ItemContainerGenerator.ContainerFromItem(SkillsList.SelectedItem);
            //listBoxItem.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            //FocusManager.SetFocusedElement(this,ThumbScroll);

            //does not enable full scrolling
            //Keyboard.ClearFocus();
            //Keyboard.Focus(this);

            //list still doesn't scroll fully
            MainGrid.Focusable = true;
            MainGrid.Focus();
            MainGrid.Focusable = false;

            int newIndex = SkillsListSource.IndexOf(newName);
            int vissibleItemCount = (int)Math.Floor(ListScroll.ActualHeight / 20);
            int firstVisibleIndex = (int)Math.Ceiling(ListScroll.VerticalOffset / 20); // 33 => 2
            int lastVisibleIndex = (int)Math.Floor((ListScroll.VerticalOffset + ListScroll.ActualHeight) / 20) - 1;
            lastVisibleIndex = lastVisibleIndex <= SkillsListSource.Count-1 ? lastVisibleIndex : SkillsListSource.Count-1;

            Debug.Print("NewDir2: " + SkillsListSource.Count + " " + newIndex + " " + vissibleItemCount + " " + firstVisibleIndex + " " + lastVisibleIndex);

            if (newIndex >= firstVisibleIndex && newIndex <= lastVisibleIndex)
            {
                //if the new directory is in visible position: no scroll
            }
            else //outside of visible range, try to center it.
            {
                double vertOffset = newIndex * 20 - (ListScroll.ActualHeight - 20) / 2;
                Debug.Print("NewDir3 " + vertOffset + " " + ListScroll.ScrollableHeight);
                if (vertOffset < 0) vertOffset = 0; //not necessary
                if (vertOffset > ListScroll.ScrollableHeight) vertOffset = ListScroll.ScrollableHeight; //not necessary
                ListScroll.ScrollToVerticalOffset(vertOffset);
            }
            //selected item does not change to the new directory. So we can pull files to it from the current one.
        }

        private void RenameDir(string oldName, string newName, bool caseChange)
        {
            Debug.Print("RenameDir " + oldName + " " + newName);
            if (caseChange) //we have to rename dir to a temporary one.
            {
                String timeStamp = DateTime.Now.Ticks.ToString();
                Debug.Print("RenameDir, Timestamp: " + timeStamp);
                Directory .Move(settings["SkillsPath"] + oldName, settings["SkillsPath"] + oldName + timeStamp);
                Directory.Move(settings["SkillsPath"] + oldName + timeStamp, settings["SkillsPath"] + newName);
            }
            else
            {
                Directory.Move(settings["SkillsPath"] + oldName, settings["SkillsPath"] + newName);
            }            
            SkillsListSource.Remove(oldName);
            SkillsListSource.Add(newName);
            SkillsListSource.Sort();
            changedByProgramList = true;
            SkillsList.ItemsSource = null;
            SkillsList.ItemsSource = SkillsListSource;
            SkillsList.SelectedItem = newName;
            changedByProgramList = false;
            FocusListItem();
            SaveSetting("SelectedSkill", newName);

            //renaming video thumbnails
            string[] folders = new string[] { "Thumbnails", "Indexes", "Comments" };
            foreach (string folder in folders)
            {
                IEnumerable<string> files = Directory.EnumerateFiles(rootDir + folder + @"\", oldName + settings["FileNameSeparator"] + "*.jpg");
                foreach (string file in files)
                {
                    string newFile = file.Replace(oldName + settings["FileNameSeparator"], newName + settings["FileNameSeparator"]);
                    if (caseChange)
                    {
                        String timeStamp = DateTime.Now.Ticks.ToString();
                        File.Move(file, file + timeStamp);
                        if (File.Exists(newFile)) //true only if the user copied it there, or remained from another root setting.
                        {
                            File.Delete(newFile);
                        }
                        File.Move(file + timeStamp, newFile);
                    }
                    else
                    {
                        if (File.Exists(newFile)) //true only if the user copied it there, or remained from another root setting.
                        {
                            File.Delete(newFile);
                        }
                        File.Move(file, newFile);
                    }
                }
            }
            
            var stw = Stopwatch.StartNew();
            //changing thumbnails' image source.
            displayedThumbs.Clear();
            for (int i = 0; i < Thumbs.Children.Count; i++) //43 pics 2096, 1543, 1305, 1253 ms
            {
                Image im = (Image)((Border)Thumbs.Children[i]).Child;
                string oldSource = ((BitmapImage)im.Source).UriSource.LocalPath;
                string newSource;
                if (oldSource.IndexOf(rootDir + @"Thumbnails\") != -1) //video
                {
                    newSource = oldSource.Replace(rootDir + @"Thumbnails\" + oldName + settings["FileNameSeparator"], rootDir + @"Thumbnails\" + newName + settings["FileNameSeparator"]);
                }
                else //picture
                {
                    newSource = oldSource.Replace(settings["SkillsPath"] + oldName, settings["SkillsPath"] + newName);
                }

                Debug.Print("changing thumbnail oldSource " + oldSource + " newSource " + newSource);

                BitmapImage imageBitmap = new BitmapImage();
                imageBitmap.BeginInit();
                imageBitmap.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                imageBitmap.CacheOption = BitmapCacheOption.OnLoad;//makes it possible to delete the image, otherwise it will be locked. If I set it to OnLoad however, the image will not refresh when the thumbnail image file refreshes.
                Debug.Print("Renamedir, generating new thumbs " + newSource);
                imageBitmap.UriSource = new Uri(newSource, UriKind.Absolute);
                imageBitmap.EndInit();
                im.Source = imageBitmap;

                displayedThumbs.Add(newSource);
            }
            Debug.Print("changed " + Thumbs.Children.Count + " pics in " + stw.ElapsedMilliseconds);
            stw.Stop();
            foreach (string src in displayedThumbs)
            {
                Debug.Print("displayedThumbs: " + src);
            }
        }

        private string RemoveIllegalChars(string s)
        {
            return s.Trim().Replace("/", "").Replace(@"\", "").Replace("?", "").Replace("%", "").Replace("*", "").Replace(":", "").Replace("|", "").
                        Replace("\"", "").Replace("<", "").Replace(">", "");
        }

        #endregion

        #region Drag and drop

        private DispatcherTimer dragListTimer; //restores list selection, when the mouse is not over the listbox
        //MainWindow1_DragLeave (and DragEnter) is called many times, when the mouse is still over the window.
        private DispatcherTimer scrollTimer;
        private bool listScrollTopEntered;
        private bool listScrollBottomEntered;


        private void MainWindow1_DragEnter(object sender, System.Windows.DragEventArgs e)
        //gets called every time selection changes in list item. We only need the first incidence.
        //When entering window from left side, list selection has already changed.
        //Desired behavior: the element that has the focus will get it back when drag is ended.
        {
            Debug.Print("MainWindow1_DragEnter, activating");
            this.Activate();

            //private Stopwatch dragstw;
            /*if (dragstw == null)
            {
                dragstw = Stopwatch.StartNew();
            }*/
        }
        
        private void MainWindow1_DragLeave(object sender, System.Windows.DragEventArgs e) //called many times during a drag.
        //We will set and reset cancelThumbLosingFocus each time DragEnter and DragLeave happens, the important thing is that it is set during DragOver,
        //and that it is reset when we actually leave the window.
        {
            Debug.Print("MainWindow1_DragLeave focused element: " + FocusManager.GetFocusedElement(this));
            // from internal drag: focused element is ThumbScroll of ListBoxItem (when we have scrolled the list during dragging).
            // from external drag: focused element is ListBoxItem 
        }

        private void SkillsList_DragOver(object sender, System.Windows.DragEventArgs e) //changes list selection
        {
            //Debug.Print("SkillsList_DragOver, SkillsList.X " + e.GetPosition(SkillsList).X + " SkillsList.Y " + e.GetPosition(SkillsList).Y + " ListScroll.X " + e.GetPosition(ListScroll).X + " ListScroll.Y " + e.GetPosition(ListScroll).Y + " this.X " + e.GetPosition(this).X + " this.Y " + e.GetPosition(this).Y);

            double index = ((int)e.GetPosition(SkillsList).Y - 2) / 20;
            changedByProgramList = true;
            SkillsList.SelectedIndex = (int)Math.Floor(index);
            changedByProgramList = false;
            //not putting focus on list item here. So there is no need to restore it, when the mouse exits the list area.

            //Debug.Print("SkillsList_DragOver Y " + e.GetPosition(ListScroll).Y + " " + ListScroll.ActualHeight);
            //mouse dragged to bottom
            if (e.GetPosition(ListScroll).Y > ListScroll.ActualHeight - 10 && ListScroll.ContentVerticalOffset < ListScroll.ScrollableHeight) //haven't reached the bottom
            {
                if (!listScrollBottomEntered)
                {
                    listScrollBottomEntered = true;
                    scrollTimer = new DispatcherTimer();
                    scrollTimer.Interval = TimeSpan.FromMilliseconds(20);
                    scrollTimer.Tick += ScrollTimerBottom_Tick;
                    scrollTimer.Start();
                }
            }
            else if (e.GetPosition(ListScroll).Y < 10 && ListScroll.ContentVerticalOffset > 0)
            {
                if (!listScrollTopEntered)
                {
                    listScrollTopEntered = true;
                    scrollTimer = new DispatcherTimer();
                    scrollTimer.Interval = TimeSpan.FromMilliseconds(20);
                    scrollTimer.Tick += ScrollTimerTop_Tick;
                    scrollTimer.Start();
                }
            }
            else
            {                
                if (scrollTimer != null)
                {
                    listScrollBottomEntered = false;
                    listScrollTopEntered = false;
                    if (scrollTimer.IsEnabled)
                    {
                        scrollTimer.Stop();
                    }
                    scrollTimer = null;
                }
            }
            //not putting focus, but simulating mouseover. Not working.
            /*System.Windows.Input.MouseEventArgs args = new System.Windows.Input.MouseEventArgs(Mouse.PrimaryDevice, 0)
            {
                RoutedEvent = MouseMoveEvent
            };
            SkillsList.RaiseEvent(args);*/
            //ListBoxItem item = SkillsList.ItemContainerGenerator.ContainerFromIndex(skillsListIndex) as ListBoxItem; item.Focus(); //just puts focus on the selected item
        }

        private void ScrollTimerBottom_Tick(object sender, EventArgs e)
        {
            if (ListScroll.ContentVerticalOffset < ListScroll.ScrollableHeight)
            {
                ListScroll.ScrollToVerticalOffset(ListScroll.ContentVerticalOffset + 10);
            }
            else
            {
                scrollTimer.Stop();
            }
        }

        private void ScrollTimerTop_Tick(object sender, EventArgs e)
        {
            if (ListScroll.ContentVerticalOffset > 0)
            {
                ListScroll.ScrollToVerticalOffset(ListScroll.ContentVerticalOffset - 10);
            }
            else
            {
                scrollTimer.Stop();
            }
        }

        private void MainWindow1_DragOver(object sender, System.Windows.DragEventArgs e)
        //runs periodically even if mouse is not moving. Ca. 20 times per second, irregularly.
        //runs at internal (SkillsList area) and external (full window) drag too.
        //dragleave cannot be used for determining mouse position for restoring list selection, gives incorrect values, or doesn't give the negative value for left side exit.
        {
            int subtr = ListScroll.ScrollableHeight == 0 ? 0 : 18;
            //Debug.Print("MainWindow1_DragOver e.GetPosition(ListScroll).X " + e.GetPosition(ListScroll).X + " settings[SkillsListWidth] - subtr " + ((int)settings["SkillsListWidth"] - subtr));            

            //Debug.Print("MainWindow1_DragOver SkillsList.X " + e.GetPosition(SkillsList).X + " SkillsList.Y " + e.GetPosition(SkillsList).Y + " ListScroll.X " + e.GetPosition(ListScroll).X + " ListScroll.Y " + e.GetPosition(ListScroll).Y + " this.X " + e.GetPosition(this).X + " this.Y " + e.GetPosition(this).Y);
            
            
            if (e.GetPosition(ListScroll).X > settings["SkillsListWidth"] - subtr) //list right side exit for external file drop.
                                                                                   //For internal drag, MainWindow1_DragOver is not called, when the mouse is not over the list.
            {
                if (dragListTimer != null)
                {
                    dragListTimer.Stop();
                    dragListTimer = null;
                }

                if (scrollTimer != null)
                {
                    listScrollBottomEntered = false;
                    listScrollTopEntered = false;
                    if (scrollTimer.IsEnabled)
                    {
                        scrollTimer.Stop();
                    }
                    scrollTimer = null;
                }

                changedByProgramList = true;
                SkillsList.SelectedItem = settings["SelectedSkill"]; //restore selection
                changedByProgramList = false;

                Debug.Print("MainWindow1_DragOver focusing list item");

                //focusing list item is not necessary, it hasn't changed, when the mouse was moving over the list.                              
            }
            else //mouse is within the list area.
            {
                if (dragListTimer != null)
                {
                    dragListTimer.Stop();
                    dragListTimer = null;
                }
                dragListTimer = new DispatcherTimer();
                dragListTimer.Interval = TimeSpan.FromMilliseconds(200);
                dragListTimer.Tick += DragListTimer_Tick;
                dragListTimer.Start();
            }
        }

        private void DragListTimer_Tick(object sender, EventArgs e)
        {
            Debug.Print("DragListTimer_Tick");
            dragListTimer.Stop();
            dragListTimer = null;
             
            if (!dialogActivation) //reset list selection and stop list scrolling
            {
                changedByProgramList = true;
                SkillsList.SelectedItem = settings["SelectedSkill"]; //restore selection
                changedByProgramList = false;

                //focusing list item is not necessary, it hasn't changed, when the mouse was moving over the list.                 

                if (scrollTimer != null)
                {
                    listScrollBottomEntered = false;
                    listScrollTopEntered = false;
                    if (scrollTimer.IsEnabled)
                    {
                        scrollTimer.Stop();
                    }
                    scrollTimer = null;
                }
            }
        }

        private void MainWindow1_Drop(object sender, System.Windows.DragEventArgs e) //dropping file anywhere, or into SkillsList, where the selection changes (unnotified)
        {
            Debug.Print("MainWindow1_Drop");
            if (!Directory.Exists(settings["SkillsPath"]))
            {
                dialogActivation = true;
                System.Windows.MessageBox.Show("No start directory is set.");
                dialogActivation = false;
                return;
            }
            if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop))
            {
                Debug.Print("MainWindow1_Drop FileDrop");
                string[] files = (string[])e.Data.GetData(System.Windows.DataFormats.FileDrop);
                Debug.Print(files.Length + files[0]);
                bool isCopy = Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl) ? true : false;

                bool operationHappened;
                bool dialogNeeded = true;
                bool continueProcess;

                foreach (string origFile in files)
                {
                    string newFile = (string)SkillsList.SelectedItem == "." ? settings["SkillsPath"] + System.IO.Path.GetFileName(origFile) :
                        settings["SkillsPath"] + SkillsList.SelectedItem + @"\" + System.IO.Path.GetFileName(origFile);
                    Debug.Print("MainWindow1_Drop origFile: " + origFile + ", newFile: " + newFile);

                    if (settings["SkillsPath"] == "" || origFile.IndexOf(settings["SkillsPath"]) == -1) //external file
                    {
                        bool[] result = CopyMoveFileStart(origFile, newFile, isCopy, false, dialogNeeded);

                        dialogNeeded = result[1]; //operationHappened is not used here.
                        continueProcess = result[2];

                        if (!continueProcess) break;
                    }
                    else //internal file, external or internal operation
                    {
                        //file can be either in the selected category (need to remove thumb), or in another.
                        string origSkill = origFile.Replace(settings["SkillsPath"], "").Replace(System.IO.Path.GetFileName(origFile), "");
                        origSkill = origSkill == "" ? "." : origSkill.Replace(@"\", "");
                        Debug.Print("MainWindow1_Drop internal file isCopy " + isCopy + " origSkill " + origSkill + " SkillsList.SelectedItem " + SkillsList.SelectedItem);
                        if (origSkill != (string)SkillsList.SelectedItem) //not copying / moving into same dir
                        {
                            bool[] result = CopyMoveFileStart(origFile, newFile, isCopy, true, dialogNeeded);

                            operationHappened = result[0];
                            dialogNeeded = result[1];
                            continueProcess = result[2];

                            if (!continueProcess) break; //last file was not moved
                            if (operationHappened)
                            {
                                //if the directory we moved the file from is shown in the thumbnail list
                                if (!isCopy && origSkill == settings["SelectedSkill"])
                                {
                                    RemoveThumb(OrigToThumb(origFile), false);
                                }
                            }                            
                        }
                    }                    
                }

                if ((string)SkillsList.SelectedItem == settings["SelectedSkill"])
                {
                    StartUpdateThumbs();
                }

                changedByProgramList = true;
                SkillsList.SelectedItem = settings["SelectedSkill"]; //restore selection
                changedByProgramList = false;
                
                //no need to focus list item, focus didn't change.               
            }
        }

        private bool[] CopyMoveFileStart(string origFile, string newFile, bool isCopy, bool internalFile, bool dialogNeeded)
        //returns operationHappened, dialogNeeded, continueProcess
        {
            if (File.Exists(newFile)) //target file exists.
            {
                if (dialogNeeded)
                {
                    dialogActivation = true;

                    //for visual comparison
                    //System.Windows.MessageBox.Show(newFile + " already exists. Do you want to overwrite it?", "Confirm overwrite", MessageBoxButton.YesNo);

                    //to restore focus after confirmation dialog.
                    IInputElement focusedElement = FocusManager.GetFocusedElement(this);
                    Window2 dialog = new Window2();
                    dialog.Message.Text = newFile + " already exists. Do you want to overwrite it?";
                    if ((bool)dialog.ShowDialog())
                    {
                        focusedElement.Focus();
                        dialogActivation = false;
                        File.Delete(newFile);
                        CopyMoveFile(origFile, newFile, isCopy, internalFile);
                        if (dialog.overWriteAll)
                        {
                            return new bool[] { true, false, true };
                        }
                        return new bool[] { true, true, true };
                    }
                    else //no file operation. //in the caller function, thumb should not be removed.
                    {
                        focusedElement.Focus();
                        dialogActivation = false;
                        if (dialog.abort)
                        {
                            return new bool[] { false, false, false };
                        }
                        return new bool[] { false, true, true };
                    }                    
                }
                else
                {
                    File.Delete(newFile);
                    CopyMoveFile(origFile, newFile, isCopy, internalFile);
                    return new bool[] { true, false, true };
                }
            }
            else
            {
                CopyMoveFile(origFile, newFile, isCopy, internalFile);
                return new bool[] { true, dialogNeeded, true };
            }            
        }

        private void CopyMoveFile(string origFile, string newFile, bool isCopy, bool internalFile)
        //internalOperation removes thumbnail. internalFile copies / moves associated files.
        {
            //Debug.Print("CopyMoveFile" + e.AllowedEffects);
            try
            {
                if (System.IO.Path.GetExtension(origFile).ToLower() == ".jpg" || System.IO.Path.GetExtension(origFile).ToLower() == ".png") //picture
                {
                    if (isCopy)
                    {
                        File.Copy(origFile, newFile);
                    }
                    else
                    {
                        File.Move(origFile, newFile);
                    }
                }
                else //video
                {
                    if (isCopy)
                    {
                        File.Copy(origFile, newFile);

                        if (internalFile)
                        {
                            string thumb_orig = OrigToThumb(origFile);
                            string thumb_new = OrigToThumb(newFile);

                            if (File.Exists(thumb_new))
                            {
                                File.Delete(thumb_new);
                            }
                            File.Copy(thumb_orig, thumb_new);

                            string index_orig = OrigToIndex(origFile);
                            string index_new = OrigToIndex(newFile);

                            if (File.Exists(index_orig))
                            {
                                if (File.Exists(index_new))
                                {
                                    File.Delete(index_new);
                                }
                                File.Copy(index_orig, index_new);
                            }

                            string comment_orig = OrigToComment(origFile);
                            string comment_new = OrigToComment(newFile);

                            if (File.Exists(comment_orig))
                            {
                                if (File.Exists(comment_new))
                                {
                                    File.Delete(comment_new);
                                }
                                File.Copy(comment_orig, comment_new);
                            }
                        }
                    }
                    else //move
                    {
                        File.Move(origFile, newFile);

                        if (internalFile)
                        {
                            string thumb_orig = OrigToThumb(origFile);
                            string thumb_new = OrigToThumb(newFile);

                            if (File.Exists(thumb_new))
                            {
                                File.Delete(thumb_new);
                            }
                            File.Move(thumb_orig, thumb_new);

                            string index_orig = OrigToIndex(origFile);
                            string index_new = OrigToIndex(newFile);

                            if (File.Exists(index_orig))
                            {
                                if (File.Exists(index_new))
                                {
                                    File.Delete(index_new);
                                }
                                File.Move(index_orig, index_new);
                            }

                            string comment_orig = OrigToComment(origFile);
                            string comment_new = OrigToComment(newFile);

                            if (File.Exists(comment_orig))
                            {
                                if (File.Exists(comment_new))
                                {
                                    File.Delete(comment_new);
                                }
                                File.Move(comment_orig, comment_new);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Msgbox(ex.Message + "\n" + ex.StackTrace);
            }
        }

        #endregion

        #region Actions menu

        private int allItemsCount = 0;
        private int currentItemCount;
        private bool deleteSelectedPics;

        private void ActionsOpen_Click(object sender, MouseButtonEventArgs e) //without preview, if we release the mouse above the slider, it will handle the event, so we don't get here. 
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                ActionsMenu.PlacementTarget = (Image)sender;
                ActionsOpen_ContextMenuOpening(null, null);
                ActionsMenu.IsOpen = true;
            }
        }

        private void ActionsOpen_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (selectedPicIndexes.Count == 0)
            {
                UnselectAll.IsEnabled = false;
                DeleteSelected.IsEnabled = false;
                ExtractSelected.IsEnabled = false;
            }
            else
            {
                UnselectAll.IsEnabled = true;
                DeleteSelected.IsEnabled = true;
                ExtractSelected.IsEnabled = true;
            }

            if (selectedPicIndexes.Count == FileNameGridAllCanvas.Children.Count)
            {
                SelectAll.IsEnabled = false;
            }
            else
            {
                SelectAll.IsEnabled = true;
            }

            if (settings["ShowExtractStatus"])
            {
                ShowHideExtractStatus.Header = "Hide extract status";
            }
            else
            {
                ShowHideExtractStatus.Header = "Show extract status";
            }

        }

        private void SelectAll_Click(object sender, RoutedEventArgs e) //currentPicIndex does not change. It might exist now or not.
        {
            selectedPicIndexes.Clear();
            for (int i=0; i < FileNameGridAllCanvas.Children.Count; i++)
            {
                selectedPicIndexes.Add(i);
            }
            DrawMultiSelection();
            // ThumbScroll.Focusable = true;
            ThumbScroll.Focus();
            // ThumbScroll.Focusable = false;
        }

        private void UnselectAll_Click(object sender, RoutedEventArgs e)
        {
            BorderRect.Visibility = Visibility.Hidden;
            BorderRect.Stroke = Brushes.Lime;
            currentPicIndex = -1;
            selectedPicIndexes.Clear();
            DrawMultiSelection();
        }

        private void DeleteSelected_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPicIndexes.Count == 0)
            {
                dialogActivation = true;
                Msgbox("No files are selected.");
                dialogActivation = false;
                return;
            }
            else if (selectedPicIndexes.Count == 1 && currentPicIndex == selectedPicIndexes[0]) //only one is selected, the selected item is at cursor position (cursor is not red)
            {
                Context_Delete(null, null, true);
                return;
            }
            dialogActivation = true;
            string msg = (selectedPicIndexes.Count == 1) ? "file?" : selectedPicIndexes.Count + " files?";
            var confirmResult = (settings["DeletionConfirmation"]) ? System.Windows.MessageBox.Show("Are you sure you want to delete the selected " + msg, "Confirm deletion", MessageBoxButton.YesNo) : MessageBoxResult.Yes;
            dialogActivation = false;

            if (confirmResult == MessageBoxResult.Yes)
            {
                selectedPicIndexes.Sort();
                //Lists are passed by reference, arrays are passed by value.
                int[] tempSelectedPicIndexes = selectedPicIndexes.ToArray(); //RemoveThumb shrinks the array of selected indexes. Using the original array, only half of the items would get deleted.
                deleteSelectedPics = true;
                int counter = 0;
                Debug.Print("DeleteSelected_Click before cycle, joined array " + String.Join(";",tempSelectedPicIndexes));
                foreach (int index in tempSelectedPicIndexes)
                {
                    Debug.Print("DeleteSelected_Click before delete, index " + index + " counter " + counter + " selectedPicIndexes " + String.Join(";", selectedPicIndexes));
                    currentPicIndex = index - counter; //indexes shift with each deletion.
                    Context_Delete(null, null, false);
                    Debug.Print("DeleteSelected_Click after delete, index " + index + " counter " + counter+ " selectedPicIndexes " + String.Join(";", selectedPicIndexes));
                    counter++;
                }
                Debug.Print("DeleteSelected_Click after cycle, joined array " + String.Join(";", tempSelectedPicIndexes));
                deleteSelectedPics = false;
                BorderRect.Visibility = Visibility.Hidden;
                currentPicIndex = -1; //currentPicIndex gets reset in any case.                
            }
        }

        private void GenerateAllThumbs_Click(object sender, RoutedEventArgs e) //Refreshing category will abort this process. Extracting frames will not proceed.
        {
            try
            {
                if (threadThumb != null && threadThumb.IsAlive || threadExt != null && threadExt.IsAlive) //thumb generation or frame extraction running.
                {
                    dialogActivation = true;
                    Msgbox("Wait until the current operation is finished, or restart the program.");
                    dialogActivation = false;
                }
                else
                {
                    threadThumb = new System.Threading.Thread(new System.Threading.ThreadStart(() => GenerateAllThumbs()));
                    threadThumb.Start();
                }                
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message + " " + ex.StackTrace);
            }            
        }        

        private void DeleteUnusedThumbs_Click(object sender, RoutedEventArgs e) //affects only videos
        {
            DeleteUnused("Thumbnails");
        }

        private void ShowHideExtractStatus_Click(object sender, RoutedEventArgs e)
        {
            if (settings["ShowExtractStatus"])
            {
                SaveSetting("ShowExtractStatus", false);
                for (int i = 0; i < FileNameGridAllCanvas.Children.Count; i++)
                {
                    ((Grid)FileNameGridAllCanvas.Children[i]).Children[2].Visibility = Visibility.Hidden;
                }
            }
            else
            {
                SaveSetting("ShowExtractStatus", true);
                for (int i = 0; i < FileNameGridAllCanvas.Children.Count; i++)
                {
                    Image im = (Image)((Border)Thumbs.Children[i]).Child;
                    BitmapImage bit = (BitmapImage)im.Source;
                    if (File.Exists(OrigToIndex(ThumbToOrig(bit.UriSource.LocalPath))))
                    {
                        ((Grid)FileNameGridAllCanvas.Children[i]).Children[2].Visibility = Visibility.Visible;
                    }
                }
            }
        }

        private void GenerateSelectedIndexes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (threadThumb != null && threadThumb.IsAlive || threadExt != null && threadExt.IsAlive) //thumb generation or frame extraction running.
                {
                    dialogActivation = true;
                    Msgbox("Wait until the current operation is finished, or restart the program.");
                    dialogActivation = false;
                }
                else
                {
                    threadExt = new System.Threading.Thread(new System.Threading.ThreadStart(() => GenerateSelectedIndexes(settings["SelectedSkill"])));
                    threadExt.Start();
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message + " " + ex.StackTrace);
            }
        }

        private void GenerateAllIndexes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (threadThumb != null && threadThumb.IsAlive || threadExt != null && threadExt.IsAlive) //thumb generation or frame extraction running.
                {
                    dialogActivation = true;
                    Msgbox("Wait until the current operation is finished, or restart the program.");
                    dialogActivation = false;
                }
                else
                {
                    threadExt = new System.Threading.Thread(new System.Threading.ThreadStart(() => GenerateAllIndexes()));
                    threadExt.Start();
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message + " " + ex.StackTrace);
            }
        }        

        private void DeleteUnusedIndexes_Click(object sender, RoutedEventArgs e)
        {
            DeleteUnused("Indexes");
        }

        private void DeleteUnusedComments_Click(object sender, RoutedEventArgs e)
        {
            DeleteUnused("Comments");
        }

        private void GenerateAllThumbs()
        {
            this.Dispatcher.Invoke(() =>
            {
                StatusText.Text = "Creating thumbnails...";
                StatusText.Visibility = Visibility.Visible;
            });
            foreach (string dirName in SkillsListSource)
            {
                string dirPath = (dirName == ".") ? settings["SkillsPath"] : settings["SkillsPath"] + dirName + @"\";
                string[] files = Directory.GetFiles(dirPath);
                //Debug.Print(dirPath + " " + files.Length);
                foreach (string origFile in files)
                {
                    string thumb = OrigToThumb(origFile);
                    //Debug.Print(origFile + " " + thumb);                    
                    if (!File.Exists(thumb)) //video thumbnail is not yet created
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            StatusText.Text = "Creating thumbnail: " + dirName + @"\" + System.IO.Path.GetFileName(origFile);
                        });
                        string[] arr = GetMediaInfo(origFile, "Video;%Duration%");
                        double middle = int.Parse(arr[0]) / 2;
                        GetStillImage(origFile, middle, thumb);
                    }
                }
            }
            this.Dispatcher.Invoke(() =>
            {
                StatusText.Visibility = Visibility.Hidden;
            });
        }

        private void GenerateSelectedIndexes(string dirName)
        {
            this.Dispatcher.Invoke(() =>
            {
                StatusText.Text = "Extracting frames...";
                StatusText.Visibility = Visibility.Visible;
            });

            allItemsCount = 0;
            string dirPath = (dirName == ".") ? settings["SkillsPath"] : settings["SkillsPath"] + dirName + @"\";
            List<string> files = new List<string>();
            this.Dispatcher.Invoke(() =>
            {
                files = GetFilesFromSelection();
            });
            foreach (string origFile in files)
            {
                if (System.IO.Path.GetExtension(origFile).ToLower() == ".mp4")
                {
                    string index = OrigToIndex(origFile);
                    if (!File.Exists(index)) //video thumbnail is not yet created
                    {
                        allItemsCount++;
                    }
                }
            }
            currentItemCount = 0;

            GenerateSelectedIndexesProcess(files);

            allItemsCount = 0; //reset value

            this.Dispatcher.Invoke(() =>
            {
                StatusText.Visibility = Visibility.Hidden; //needed, if the number of items was 0, otherwise the frame extraction process makes the label invisible.
            });
        }

        private void GenerateAllIndexes()
        {
            this.Dispatcher.Invoke(() =>
            {
                StatusText.Text = "Extracting frames...";
                StatusText.Visibility = Visibility.Visible;
            });

            //counting total number
            allItemsCount = 0;
            foreach (string dirName in SkillsListSource)
            {
                string dirPath = (dirName == ".") ? settings["SkillsPath"] : settings["SkillsPath"] + dirName + @"\";
                string[] files = Directory.GetFiles(dirPath);
                foreach (string origFile in files)
                {
                    if (System.IO.Path.GetExtension(origFile).ToLower() == ".mp4")
                    {
                        string index = OrigToIndex(origFile);
                        if (!File.Exists(index)) //video thumbnail is not yet created
                        {
                            allItemsCount++;
                        }
                    }
                }
            }
            currentItemCount = 0;

            string[] processSkillsListSource = SkillsListSource.ToArray(); //using SkillsListSource would result in error (Collection was modified) when we create a new folder.

            foreach (string dirName in processSkillsListSource)
            {
                GenerateAllIndexesInFolderProcess(dirName);
            }
            
            allItemsCount = 0; //reset value

            this.Dispatcher.Invoke(() =>
            {
                StatusText.Visibility = Visibility.Hidden;
            });
        }

        private void GenerateAllIndexesInFolderProcess(string dirName)
        {
            string dirPath = (dirName == ".") ? settings["SkillsPath"] : settings["SkillsPath"] + dirName + @"\";
            List<string> files = Directory.GetFiles(dirPath).ToList<string>();
            files.Sort();
            //Debug.Print("GenerateAllIndexesInFolder dirPath: " + dirPath + " files.Length: " + files.Length);
            foreach (string origFile in files)
            {
                if (System.IO.Path.GetExtension(origFile).ToLower() == ".mp4")
                {
                    string index = OrigToIndex(origFile);
                    //Debug.Print("GenerateAllIndexesInFolder origFile: " + origFile + " index: " + index);
                    if (!File.Exists(index)) //video thumbnail is not yet created
                    {
                        currentItemCount++;
                        this.Dispatcher.Invoke(() => //video is certainly not fullscreen, statustext is used.
                        {
                            StatusText.Text = "Extracting frames " + currentItemCount + "/" + allItemsCount + ": " + dirName + @"\" + System.IO.Path.GetFileName(origFile);
                        });
                        extVideoSource = origFile;
                        string[] arr = GetMediaInfo(origFile, "Video;%Duration%");
                        extVideoDuration = int.Parse(arr[0]);
                        ExtractVideoFrames(origFile);
                    }
                }
            }
        }

        private void GenerateSelectedIndexesProcess(List<string> files)
        {
            //sort order is according to selection
            foreach (string origFile in files)
            {
                if (System.IO.Path.GetExtension(origFile).ToLower() == ".mp4")
                {
                    string index = OrigToIndex(origFile);
                    //Debug.Print("GenerateSelectedIndexesProcess origFile: " + origFile + " index: " + index);
                    if (!File.Exists(index)) //video thumbnail is not yet created
                    {
                        currentItemCount++;
                        this.Dispatcher.Invoke(() => //video is certainly not fullscreen, statustext is used.
                        {
                            StatusText.Text = "Extracting frames " + currentItemCount + "/" + allItemsCount + ": " + origFile.Replace(settings["SkillsPath"],"");
                        });
                        extVideoSource = origFile;
                        if (File.Exists(origFile)) //checking in case video was deleted while being in the extract queue
                        {
                            string[] arr = GetMediaInfo(origFile, "Video;%Duration%");
                            extVideoDuration = int.Parse(arr[0]);
                            ExtractVideoFrames(origFile);
                        }
                    }
                }
            }
        }

        private void DeleteUnused(string type)
        {
            try
            {
                string dir = rootDir + type + @"\";
                string[] files = Directory.GetFiles(dir);
                int i = 0;
                foreach (string file in files)
                {
                    string thumbNameWoExt = System.IO.Path.GetFileNameWithoutExtension(file);
                    string orig = settings["SkillsPath"] + thumbNameWoExt.Replace(settings["FileNameSeparator"], @"\") + ".mp4";

                    if (!File.Exists(orig) || orig.IndexOf(settings["SkillsPath"] + @".\") != -1)
                    {
                        File.Delete(file);
                        i++;
                        Debug.Print(i + " " + orig);
                    }
                }
                string msg = i == 0 ? "No " : i.ToString() + " ";
                msg += i <= 1 ? "file was " : "files were ";
                msg += "deleted.";
                dialogActivation = true;
                Msgbox(msg);
                dialogActivation = false;
            }
            catch (Exception ex) //thumbnail open in another picture viewer.
            {
                Msgbox(ex.Message);
            }
        }

        #endregion
    }
}
