using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EryfitFileSystemNavigatorUI
{
    public static class Controls
    {
        //public static void MakeButton(string content, int minHeight, int maxHeight, int minWidth, int maxWidth, HorizontalAlignment horizontalAlign, VerticalAlignment verticalAlign, StackPanel parentStackPanel)
        //{
        //    Button button = new Button();
        //    button.Content = content;
        //    button.MinHeight = minHeight;
        //    button.MaxHeight = maxHeight;
        //    button.MinWidth = minWidth;
        //    button.MaxWidth = maxWidth;
        //    button.HorizontalAlignment = horizontalAlign;
        //    button.VerticalAlignment = verticalAlign;

        //    MainWindow mainWindow = new MainWindow();

        //    button.Click += mainWindow.DriveButton_Click;

        //    parentStackPanel.Children.Add(button);
        //}
        public static void MakeButton(string content, int minHeight, int maxHeight, int minWidth, int maxWidth, int topMargin, int rightMargin, int bottomMargin, int leftMargin, HorizontalAlignment horizontalAlign, VerticalAlignment verticalAlign, StackPanel parentStackPanel)
        {
            Thickness thickness = new Thickness();
            thickness.Top = topMargin;
            thickness.Right = rightMargin;
            thickness.Bottom = bottomMargin;
            thickness.Left = leftMargin;

            Button button = new Button();

            button.Content = content;
            button.MinHeight = minHeight;
            button.MaxHeight = maxHeight;
            button.MinWidth = minWidth;
            button.MaxWidth = maxWidth;
            button.VerticalAlignment = verticalAlign;
            button.HorizontalAlignment = horizontalAlign;

            parentStackPanel.Children.Add(button);
        }
        public static void MakeTextBlock(int topMargin, int rightMargin, int bottomMargin, int leftMargin, StackPanel parentStackPanel, string text, string name)
        {
            Thickness thickness = new Thickness();
            thickness.Top = topMargin;
            thickness.Right = rightMargin;
            thickness.Bottom = bottomMargin;
            thickness.Left = leftMargin;

            TextBlock textBlock = new TextBlock();
            textBlock.Margin = thickness;
            textBlock.Text = text;
            textBlock.Name = name;

            parentStackPanel.Children.Add(textBlock);
        }
    }
}
