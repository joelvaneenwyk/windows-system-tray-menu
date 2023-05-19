﻿// <copyright file="WPFExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//
// Copyright (c) 2022-2023 Peter Kirmeier

namespace SystemTrayMenu.Utilities
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Threading;
    using Icon = System.Drawing.Icon;

    internal static class WPFExtensions
    {
        internal static void HandleInvoke(this DispatcherObject instance, Action action)
        {
            if (instance!.CheckAccess())
            {
                action();
            }
            else
            {
                instance.Dispatcher.Invoke(action);
            }
        }

        internal static Window GetParentWindow(this ListView listView)
        {
            var parent = VisualTreeHelper.GetParent(listView);

            while (parent is not Window)
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            return (Window)parent;
        }

        internal static T? FindVisualChildOfType<T>(this DependencyObject depObj, int index = 0)
            where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                if (child != null)
                {
                    if (child is T validChild)
                    {
                        if (index-- == 0)
                        {
                            return validChild;
                        }

                        continue;
                    }

                    T? childItem = child.FindVisualChildOfType<T>(index);
                    if (childItem != null)
                    {
                        return childItem;
                    }
                }
            }

            return null;
        }

        internal static Point GetRelativeChildPositionTo(this Visual parent, Visual? child)
        {
            return child == null ? new() : child.TransformToAncestor(parent).Transform(new ());
        }

        // TODO: Find and remove any unnecessary convertions
        internal static BitmapSource ToBitmapSource(this Icon icon)
        {
            return (BitmapSource)new IconToImageSourceConverter().Convert(
                        icon,
                        typeof(BitmapSource),
                        null!,
                        CultureInfo.InvariantCulture);
        }
    }
}
