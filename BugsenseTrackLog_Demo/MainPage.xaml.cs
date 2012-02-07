using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

using BugSense;
using BugSense.Notifications;
namespace BugsenseTrackLog_Demo
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //throw new NullReferenceException("Test Case For BugSense Log Record Exception!");

            try
            {
                throw new ArrayTypeMismatchException("Array Type Mismatch Error is raised", new Exception("Test Error!"));
            }
            catch (Exception ex)
            {
                //BugSenseHandler.HandleError(se, "This is my first commit Exception.", new NotificationOptions() { Text="first Notification", Title="error Title!" });
                var overridenOptions = BugSenseHandler.DefaultOptions();
                overridenOptions.Text = ex.Message + Environment.NewLine + "Do you want to send the Exception?";
                overridenOptions.Type = enNotificationType.MessageBoxConfirm;
                BugSenseHandler.HandleError(ex, string.Format("User {0}", "User define"), overridenOptions);
            }
        }
    }
}