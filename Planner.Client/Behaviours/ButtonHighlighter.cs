using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace Planner.Client.Behaviours
{
    internal class ButtonHighlighter : Behavior<Button>
    {
        private static Button _previousButton;

        public static readonly DependencyProperty SelectedBackgroundProperty =
            DependencyProperty.Register("SelectedBackground", typeof(Brush), typeof(ButtonHighlighter));

        public Brush SelectedBackground
        {
            get => (Brush)GetValue(SelectedBackgroundProperty);
            set => SetValue(SelectedBackgroundProperty, value);
        }

        public static readonly DependencyProperty SelectedForegroundProperty =
            DependencyProperty.Register("SelectedForeground", typeof(Brush), typeof(ButtonHighlighter));

        public Brush SelectedForeground
        {
            get => (Brush)GetValue(SelectedForegroundProperty);
            set => SetValue(SelectedForegroundProperty, value);
        }

        public static readonly DependencyProperty IsDefaultProperty =
            DependencyProperty.Register("IsDefault", typeof(bool), typeof(ButtonHighlighter),
                new PropertyMetadata(false, OnIsDefaultChanged));

        public bool IsDefault
        {
            get => (bool)GetValue(IsDefaultProperty);
            set => SetValue(IsDefaultProperty, value);
        }

        private static void OnIsDefaultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ButtonHighlighter behavior && (bool)e.NewValue && behavior.AssociatedObject != null)
            {
                // Apply highlight safely when the default button is marked
                behavior.ApplyHighlight();
            }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Click += OnButtonClick;
            AssociatedObject.Loaded += OnButtonLoaded;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Click -= OnButtonClick;
            AssociatedObject.Loaded -= OnButtonLoaded;
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            ApplyHighlight();
        }

        private void OnButtonLoaded(object sender, RoutedEventArgs e)
        {
            // Apply default highlight after the button is fully loaded
            if (IsDefault)
            {
                ApplyHighlight();
            }
        }

        private void ApplyHighlight()
        {
            if (_previousButton != null && _previousButton != AssociatedObject)
            {
                // Reset the previous button's colors to default
                _previousButton.ClearValue(Control.BackgroundProperty);
                _previousButton.ClearValue(Control.ForegroundProperty);
            }

            // Apply new colors to the current button
            AssociatedObject.Background = SelectedBackground;
            AssociatedObject.Foreground = SelectedForeground;

            _previousButton = AssociatedObject;
        }
    }
}