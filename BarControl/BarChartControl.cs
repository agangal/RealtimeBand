using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace BarControl
{
    [TemplatePart(Name = ContainerPartName, Type = typeof(Grid))]
    public sealed class BarChartControl : Control
    {
        private Compositor _compositor;
        private ContainerVisual _root;
        private const string ContainerPartName = "PART_Container";
        private SpriteVisual _needle;

        public BarChartControl()
        {
            this.DefaultStyleKey = typeof(BarChartControl);
        }

        public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(double), typeof(BarChartControl), new PropertyMetadata(0.0));
        public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(double), typeof(BarChartControl), new PropertyMetadata(4000.0));
        public static readonly DependencyProperty ScaleWidthProperty = DependencyProperty.Register("ScaleWidth", typeof(double), typeof(BarChartControl), new PropertyMetadata(26.0));
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(BarChartControl), new PropertyMetadata(0.0, OnValueChanged));
        public static readonly DependencyProperty RightBrushProperty = DependencyProperty.Register("RightBrush", typeof(Brush), typeof(BarChartControl), new PropertyMetadata(new SolidColorBrush(Colors.Orange)));
        public static readonly DependencyProperty LeftBrushProperty = DependencyProperty.Register("TrailBrush", typeof(Brush), typeof(BarChartControl), new PropertyMetadata(new SolidColorBrush(Colors.Orange)));

        /// <summary>
        /// Gets or sets the minimum value of the control
        /// </summary>
        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        /// <summary>
        /// Gets or sets the Maximum value of the control
        /// </summary>
        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        /// <summary>
        /// Gets or sets the ScaleWidth property
        /// </summary>
        public double ScaleWidth
        {
            get { return (double)GetValue(ScaleWidthProperty); }
            set { SetValue(ScaleWidthProperty, value); }
        }

        /// <summary>
        /// Gets or sets the Value property
        /// </summary>
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public Brush RightBrush
        {
            get { return (SolidColorBrush)GetValue(RightBrushProperty); }
            set { SetValue(RightBrushProperty, value); }
        }

        public Brush LeftBrush
        {
            get { return (SolidColorBrush)GetValue(LeftBrushProperty); }
            set { SetValue(LeftBrushProperty, value); }
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            OnValueChanged(d);
        }

        protected override void OnApplyTemplate()
        {
            var container = this.GetTemplateChild(ContainerPartName) as Path;
            _root = container.GetVisual();
            _compositor = _root.Compositor;
            SpriteVisual bar;
            bar = _compositor.CreateSpriteVisual();
            bar.Size = new System.Numerics.Vector2(100, 50);
            bar.Brush = _compositor.CreateColorBrush(Color.FromArgb(130, 245, 43, 1));
            _root.Children.InsertAtTop(bar);
            base.OnApplyTemplate();
        }

        private static void OnValueChanged(DependencyObject d)
        {
            BarChartControl c = (BarChartControl)d;
            if(!Double.IsNaN(c.Value))
            {

            }
        }
    }
}
