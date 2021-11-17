﻿using SOHome.UnoApp.Views;

using System;
using System.Collections.Generic;
using System.Linq;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace SOHome.UnoApp.Services
{
    public class NavigationServiceEx
    {
        public event NavigatedEventHandler Navigated;

        public event NavigationFailedEventHandler NavigationFailed;

        private readonly Dictionary<string, Type> _pages = new Dictionary<string, Type>();

        private Frame _frame;
        private object _lastParamUsed;       

        public Frame Frame
        {
            get
            {
                if (_frame == null)
                {
                    _frame = Window.Current.Content as Frame;
                    RegisterFrameEvents();
                }

                return _frame;
            }

            set
            {
                UnregisterFrameEvents();
                _frame = value;
                RegisterFrameEvents();
            }
        }

        public bool CanGoBack => Frame.CanGoBack;

        public bool CanGoForward => Frame.CanGoForward;

        public bool GoBack()
        {
            if (CanGoBack)
            {
                Frame.GoBack();
                return true;
            }

            return false;
        }

        public void GoForward() => Frame.GoForward();

        /// <summary>
        /// 네비게이션
        /// </summary>
        /// <param name="pageKey"></param>
        /// <param name="parameter"></param>
        /// <param name="infoOverride"></param>
        /// <returns></returns>
        public bool Navigate(string pageKey, object parameter = null, NavigationTransitionInfo infoOverride = null)
        {
            Type page;
            lock (_pages)
            {
                if (!_pages.TryGetValue(pageKey, out page))
                {
                    throw new ArgumentException(string.Format("ExceptionNavigationServiceExPageNotFound", pageKey), nameof(pageKey));
                }
            }

            if (Frame.Content?.GetType() != page || (parameter != null && !parameter.Equals(_lastParamUsed)))
            {
                var navigationResult = Frame.Navigate(page, parameter, infoOverride);
                if (navigationResult)
                {
                    _lastParamUsed = parameter;
                }

                return navigationResult;
            }
            else
            {
                return false;
            }
        }

        public bool Navigate(Page pageType, object parameter = null, NavigationTransitionInfo infoOverride = null)
        {
            var pageKey = pageType.GetType().Name;
            Type page;
            lock (_pages)
            {
                if (!_pages.TryGetValue(pageKey, out page))
                {
                    throw new ArgumentException(string.Format("ExceptionNavigationServiceExPageNotFound", pageKey), nameof(pageKey));
                }
            }

            if (Frame.Content?.GetType() != page || (parameter != null && !parameter.Equals(_lastParamUsed)))
            {
                var navigationResult = Frame.Navigate(page, parameter, infoOverride);
                if (navigationResult)
                {
                    _lastParamUsed = parameter;
                }

                return navigationResult;
            }
            else
            {
                return false;
            }
        }

        public bool Navigate(Type pageType, object parameter = null, NavigationTransitionInfo infoOverride = null)
        {
            var pageKey = pageType.Name;
            Type page;
            lock (_pages)
            {
                if (!_pages.TryGetValue(pageKey, out page))
                {
                    throw new ArgumentException(string.Format("ExceptionNavigationServiceExPageNotFound", pageKey), nameof(pageKey));
                }
            }

            if (Frame.Content?.GetType() != page || (parameter != null && !parameter.Equals(_lastParamUsed)))
            {
                var navigationResult = Frame.Navigate(page, parameter, infoOverride);
                if (navigationResult)
                {
                    _lastParamUsed = parameter;
                }

                return navigationResult;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 뷰모델과 뷰 연결
        /// </summary>
        /// <param name="key"></param>
        /// <param name="pageType"></param>
        public void Configure(string key, Type pageType)
        {
            lock (_pages)
            {
                if (_pages.ContainsKey(key))
                {
                    throw new ArgumentException(string.Format("ExceptionNavigationServiceExKeyIsInNavigationService", key));
                }

                if (_pages.Any(p => p.Value == pageType))
                {
                    throw new ArgumentException(string.Format("ExceptionNavigationServiceExTypeAlreadyConfigured", _pages.First(p => p.Value == pageType).Key));
                }

                _pages.Add(key, pageType);
            }
        }

        public void Configure(Type pageType)
        {
            var key = pageType.Name;
            lock (_pages)
            {
                if (_pages.ContainsKey(key))
                {
                    throw new ArgumentException(string.Format("ExceptionNavigationServiceExKeyIsInNavigationService", key));
                }

                if (_pages.Any(p => p.Value == pageType))
                {
                    throw new ArgumentException(string.Format("ExceptionNavigationServiceExTypeAlreadyConfigured", _pages.First(p => p.Value == pageType).Key));
                }

                _pages.Add(key, pageType);
            }
        }

        /// <summary>
        /// 뷰의 등록된 이름 반환
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public string GetNameOfRegisteredPage(Type page)
        {
            lock (_pages)
            {
                if (_pages.ContainsValue(page))
                {
                    return _pages.FirstOrDefault(p => p.Value == page).Key;
                }
                else
                {
                    throw new ArgumentException(string.Format("ExceptionNavigationServiceExPageUnknown", page.Name));
                }
            }
        }

        private void RegisterFrameEvents()
        {
            if (_frame != null)
            {
                _frame.Navigated += Frame_Navigated;
                _frame.NavigationFailed += Frame_NavigationFailed;
            }
        }

        private void UnregisterFrameEvents()
        {
            if (_frame != null)
            {
                _frame.Navigated -= Frame_Navigated;
                _frame.NavigationFailed -= Frame_NavigationFailed;
            }
        }

        private void Frame_NavigationFailed(object sender, NavigationFailedEventArgs e) => NavigationFailed?.Invoke(sender, e);

        private void Frame_Navigated(object sender, NavigationEventArgs e) => Navigated?.Invoke(sender, e);
    }
}
