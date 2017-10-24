using Microsoft.Win32;
using Stopwatch2_0.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Threading;

namespace Stopwatch2_0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Stopwatch stopwatch = new Stopwatch();
        private DispatcherTimer timer = new DispatcherTimer();
        private string txtDisplayFormat = @"hh\:mm\:ss\.ff";
        private bool startStopInSplitTimes;
        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 40);

            this.Width = Settings.Default.MainWindowWidth;
            this.Height = Settings.Default.MainWindowHeight;
            this.Top = Settings.Default.MainWindowTop;
            this.Left = Settings.Default.MainWindowLeft;

            txtDisplay.Foreground = new SolidColorBrush(Settings.Default.DisplayForegroundColor);
            grdDisplay.Background = new SolidColorBrush(Settings.Default.DisplayBackgroundColor);

            this.startStopInSplitTimes = Settings.Default.StartStopInSplitTimes;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            txtDisplay.Text = stopwatch.Elapsed.ToString();
        }

        private void mFileExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Start();
            timer.Start();
            btnStart.IsEnabled = !stopwatch.IsRunning;
            btnStop.IsEnabled = stopwatch.IsRunning;

            if (this.startStopInSplitTimes)
            {
                lstSplitTimes.Items.Add(stopwatch.Elapsed.ToString(txtDisplayFormat));
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            lstSplitTimes.Items.Add(stopwatch.Elapsed.ToString(txtDisplayFormat));
            txtSplitTimesCount.Text = "Split times count: " + lstSplitTimes.Items.Count;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Stop();
            txtDisplay.Text = stopwatch.Elapsed.ToString();
            timer.Stop();
            btnStart.IsEnabled = !stopwatch.IsRunning;
            btnStop.IsEnabled = stopwatch.IsRunning;

            if (this.startStopInSplitTimes)
            {
                lstSplitTimes.Items.Add(stopwatch.Elapsed.ToString(txtDisplayFormat));
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Reset();
            txtDisplay.Text = stopwatch.Elapsed.ToString();
            timer.Stop();
            lstSplitTimes.Items.Clear();
            txtSplitTimesCount.Text = "Split times count: " + lstSplitTimes.Items.Count;
            btnStart.IsEnabled = !stopwatch.IsRunning;
            btnStop.IsEnabled = stopwatch.IsRunning;
        }

        private void mHelpAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutDialog aboutDialog = new AboutDialog();
            aboutDialog.Owner = this;
            aboutDialog.ShowDialog();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Settings.Default.MainWindowLeft = this.Left;
            Settings.Default.MainWindowTop = this.Top;
            Settings.Default.MainWindowHeight = this.Height;
            Settings.Default.MainWindowWidth = this.Width;

            SolidColorBrush colorBrush = (SolidColorBrush)txtDisplay.Foreground;
            Settings.Default.DisplayForegroundColor = colorBrush.Color;
            colorBrush = (SolidColorBrush)grdDisplay.Background;
            Settings.Default.DisplayBackgroundColor = colorBrush.Color;

            Settings.Default.StartStopInSplitTimes = this.startStopInSplitTimes;

            Settings.Default.Save();
            base.OnClosing(e);
        }

        private void mToolsOptions_Click(object sender, RoutedEventArgs e)
        {
            OptionsDialog optionsDialog = new OptionsDialog();

            SolidColorBrush colorBrush = (SolidColorBrush)txtDisplay.Foreground;
            optionsDialog.DisplayForegroundColor = colorBrush.Color;
            colorBrush = (SolidColorBrush)grdDisplay.Background;
            optionsDialog.DisplayBackgroundColor = colorBrush.Color;

            optionsDialog.StartStopInSplitTimes = this.startStopInSplitTimes;

            bool? dialogResult = optionsDialog.ShowDialog();
            if (dialogResult ?? false)
            {
                this.startStopInSplitTimes = optionsDialog.StartStopInSplitTimes;

                txtDisplay.Foreground = new SolidColorBrush(optionsDialog.DisplayForegroundColor ?? Colors.Black);
                grdDisplay.Background = new SolidColorBrush(optionsDialog.DisplayBackgroundColor ?? Colors.White);
            }
        }

        private void mFileSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            bool? dialogResult = sfd.ShowDialog();

            if (dialogResult ?? false)
            {
                StringBuilder sb = new StringBuilder();

                foreach (string splitTime in lstSplitTimes.Items)
                {
                    sb.AppendLine(splitTime);
                }

                File.WriteAllText(sfd.FileName, sb.ToString());
            }
        }
    }
}
