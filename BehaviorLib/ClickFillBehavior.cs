﻿using CustomPanelsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BehaviorLib
{
    public class ClickFillBehavior : Behavior<UIElement>
    {
        private CustomCanvas canvas;

        protected override void OnAttached()
        {
            base.OnAttached();

            // Присоединение обработчиков событий
            this.AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseLeftButtonDown;
            //this.AssociatedObject.MouseMove += AssociatedObject_MouseMove;
            //this.AssociatedObject.MouseLeftButtonUp += AssociatedObject_MouseLeftButtonUp;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            // Удаление обработчиков событий
            this.AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseLeftButtonDown;
            //this.AssociatedObject.MouseMove -= AssociatedObject_MouseMove;
            //this.AssociatedObject.MouseLeftButtonUp -= AssociatedObject_MouseLeftButtonUp;
        }

        // Отслеживание перетаскивания элемента
        //private bool isDragging = false;

        // Запись точной позиции, в которой нажата кнопка
        //private Point mouseOffset;

        private void AssociatedObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Поиск canvas
            if (canvas == null) canvas =
                    VisualTreeHelper.GetParent(this.AssociatedObject) as CustomCanvas;


            Color resultColor = Colors.Black;

            Console.WriteLine(canvas.currentColor);

            switch (canvas.currentColor)
            {
                case "Yellow": { resultColor = Colors.Yellow; break; }
                case "Red": { resultColor = Colors.Red; break; }
                case "Green": { resultColor = Colors.Green; break; }
                default: break;
            }

            Console.WriteLine(new SolidColorBrush(resultColor));

            AssociatedObject.GetType()
                .GetProperty("Fill")
                .SetValue((AssociatedObject), new SolidColorBrush(resultColor));

            
            // Режим перетаскивания
            //isDragging = true;

            // Получение позиции нажатия относительно элемента
            //mouseOffset = e.GetPosition(AssociatedObject);

            // Захват мыши
            //AssociatedObject.CaptureMouse();
        }

        /*private void AssociatedObject_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                // Получение позиции элемента относительно Canvas
                Point point = e.GetPosition(canvas);

                // Move the element.
                AssociatedObject.SetValue(Canvas.TopProperty, point.Y - mouseOffset.Y);
                AssociatedObject.SetValue(Canvas.LeftProperty, point.X - mouseOffset.X);
            }
        }*/

        /*private void AssociatedObject_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isDragging)
            {
                AssociatedObject.ReleaseMouseCapture();
                isDragging = false;
            }
        }*/
    }
}
