using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Acrylics
{
    ///<summary>
    ///
    /// This MarkupExtension returns VisualBrush, contained with AcrylicPanel.
    /// 
    ///</summary>

    public class AcrylicBrushExtension : MarkupExtension
    {
        public string TargetName { get; set; }

        public Color TintColor { get; set; } = Colors.White;

        public double TintOpacity { get; set; } = 0.0;

        public double NoiseOpacity { get; set; } = 0.03;


        public AcrylicBrushExtension() { }

        public AcrylicBrushExtension(string target)
        {
            this.TargetName = target;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var pvt = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            var target = pvt.TargetObject as FrameworkElement;

            var acrylicPanel = new AcrylicPanel()
            {
                TintColor = this.TintColor,
                TintOpacity = this.TintOpacity,
                NoiseOpacity = this.NoiseOpacity,
            };
            BindingOperations.SetBinding(acrylicPanel, AcrylicPanel.TargetProperty, new Binding() { ElementName = this.TargetName });
            BindingOperations.SetBinding(acrylicPanel, AcrylicPanel.SourceProperty, new Binding() { Source = target });
            BindingOperations.SetBinding(acrylicPanel, AcrylicPanel.WidthProperty, new Binding("ActualWidth") { Source = target });
            BindingOperations.SetBinding(acrylicPanel, AcrylicPanel.HeightProperty, new Binding("ActualHeight") { Source = target });

            var brush = new VisualBrush(acrylicPanel)
            {
                Stretch = Stretch.None,
                AlignmentX = AlignmentX.Left,
                AlignmentY = AlignmentY.Top,
                ViewboxUnits = BrushMappingMode.Absolute,
            };

            return brush;
        }
    }
}
