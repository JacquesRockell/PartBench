﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PartBench
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;

            // Set XAML element as a draggable region.
            Window.Current.SetTitleBar(AppTitleBar);
     
            //Changes Title bar colors
            ApplicationView view = ApplicationView.GetForCurrentView();
            ApplicationViewTitleBar titleBar = view.TitleBar;
            titleBar.ForegroundColor = Windows.UI.Color.FromArgb(255, 0, 0, 255);
            titleBar.ButtonBackgroundColor = Windows.UI.Color.FromArgb(0, 0, 0, 0);
            titleBar.ButtonHoverBackgroundColor = Windows.UI.Color.FromArgb(20, 255, 255, 255);
            titleBar.ButtonPressedBackgroundColor = Windows.UI.Color.FromArgb(50, 255, 255, 255);
            titleBar.ButtonInactiveBackgroundColor = Windows.UI.Color.FromArgb(0, 255, 255, 255);

            sel();
        }
        
        public async void sel()
        {
            await Task.Delay(10);
            NavItemHome.IsSelected = true;
        }

        #region Page Specific Nav
        private void btnVeiwBuildGuides_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BuildGuidePage));
        }

        private void btnBugetAmdGuide_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FirstBuild));
        }

        private void btnHighEndIntelGuide_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ThirdBuild));
        }

        private void btnVeiwBuilds_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BuildsPage));
        }

        private void btnBeginBuilding_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BuildEditorPage));
        }
        #endregion

        #region Nav Items
        private void NavView_BackRequested(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewBackRequestedEventArgs args)
        {
            if (this.Frame.CanGoBack == true)
            {
                this.Frame.GoBack();
            }
        }
        private void NavItemHome_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void NavItemFAQPage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FAQPage));
        }

        private void NavItemBuilds_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BuildsPage));
        }

        private void NavItemBuildGuidePage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BuildGuidePage));
        }
        
        private void NavItemForumsPage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ForumsPage));
        }

        private void NavItemPricePerformance_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PricePerformancePage));
        }

        private void NavItemBenchmark_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BenchmarkPage));
        }
        #endregion

        #region Resize Content area on pane state
        private void NavView_PaneClosing(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewPaneClosingEventArgs args)
        {
            Thickness margin = ContentContainer.Margin;
            margin.Left = 90;
            ContentContainer.Margin = margin;
        }

        private void NavView_PaneOpening(Microsoft.UI.Xaml.Controls.NavigationView sender, object args)
        {
            Thickness margin = ContentContainer.Margin;
            margin.Left = 350;
            ContentContainer.Margin = margin;
        }
        #endregion     
    }
}
