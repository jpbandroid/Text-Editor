﻿using System;
using System.Linq;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Ivirius_Text_Editor
{
    public sealed class MessageBoxesGrid : Grid
    {
        public MessageBoxesGrid()
        {
            SetBlockBorder();
        }

        public void SetBlockBorder()
        {
            PointerPressed -= BlockBorder_PointerPressed;
            PointerPressed += BlockBorder_PointerPressed;

            bool AnyElementOn = false;

            SetValue(MessageBoxValidation.IsMessageBoxProperty, true);
            foreach (MessageBox box in Children.Cast<MessageBox>())
            {
                if (box.IsOn == true && box.BlockUserInput == true)
                {
                    AnyElementOn = true;
                    break;
                }
            }

            if (AnyElementOn == true)
            {
                Background = new SolidColorBrush(Color.FromArgb(89, 0, 0, 0));
            }
            else
            {
                Background = null;
            }
        }

        private void BlockBorder_PointerPressed(object sender, PointerRoutedEventArgs e)
        {

        }

        public static readonly DependencyProperty IsMessageBoxProperty =
            DependencyProperty.RegisterAttached("IsMessageBox", typeof(bool), typeof(MessageBoxesGrid), new PropertyMetadata(true, OnIsMessageBoxChanged));

        public static bool GetIsMessageBox(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsMessageBoxProperty);
        }

        public static void SetIsMessageBox(DependencyObject obj, bool value)
        {
            obj.SetValue(IsMessageBoxProperty, value);
        }

        private static void OnIsMessageBoxChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MessageBoxesGrid grid && !(bool)e.NewValue)
            {
                throw new ArgumentException("The IsMessageBox property of CustomMessageBoxGrid cannot be set to false.");
            }
        }
    }
}
