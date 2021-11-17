﻿using System;
using System.Collections.Generic;
using System.Linq;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
namespace SOHome.UnoApp.Helpers
{
    public class NavigationSyncHelper
    {
        private NavigationView _navigationView;
        private Frame _frame;
        private NavigationViewItem _lastInvokedMenuItem;
        private Dictionary<string, Type> _pageMap;
        public static NavigationSyncHelper Current { get; private set; }

        public NavigationSyncHelper(NavigationView navigationView, Frame frame, Dictionary<string, Type> pageMap)
        {
            _frame = frame;
            _navigationView = navigationView;
            _pageMap = pageMap;

            _navigationView.ItemInvoked += NavView_ItemInvoked;
            _navigationView.BackRequested += NavView_BackRequested;
            _frame.Navigated += Frame_Navigated;
            Current = this;
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var invokedMenuItem = args.InvokedItemContainer as NavigationViewItem;

            if (invokedMenuItem == null || invokedMenuItem == _lastInvokedMenuItem)
            {
                return;
            }

            var tag = invokedMenuItem.Tag.ToString();
            if (_pageMap.ContainsKey(tag))
            {
                var destinationType = _pageMap[tag];
                if (!_frame.Navigate(destinationType, null, args.RecommendedNavigationTransitionInfo))
                {
                    return;
                }
                _lastInvokedMenuItem = invokedMenuItem;
            }
        }

        private void NavView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (_frame.CanGoBack)
            {
                _frame.GoBack();
            }
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            var currentSelectedItem = _navigationView.MenuItems
                .FirstOrDefault(mi => ((NavigationViewItem)mi).IsSelected) as NavigationViewItem;
            if (currentSelectedItem != null)
            {
                var tag = currentSelectedItem.Tag.ToString();
                var currentSelectedType = _pageMap[currentSelectedItem.Tag.ToString()];
                if (e.SourcePageType != currentSelectedType)
                {
                    SetSelectedItem();
                }
            }
            else
            {
                SetSelectedItem();
            }

            void SetSelectedItem()
            {
                var tagToFind = _pageMap.FirstOrDefault(entry => entry.Value == e.SourcePageType).Key;
                if (_navigationView.MenuItems.FirstOrDefault(mi => ((NavigationViewItem)mi).Tag.Equals(tagToFind)) is NavigationViewItem matchedItem)
                {
                    matchedItem.IsSelected = true;
                    _lastInvokedMenuItem = matchedItem;
                }
            }
        }
    }
}
