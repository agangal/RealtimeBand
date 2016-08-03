using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Composition;
using Windows.UI.Xaml.Hosting;

namespace BarControl
{
    public static class UIElementExtension
    {
        public static ContainerVisual GetVisual(this UIElement element)

        {

            var hostVisual = ElementCompositionPreview.GetElementVisual(element);

            var root = hostVisual.Compositor.CreateContainerVisual();

            ElementCompositionPreview.SetElementChildVisual(element, root);

            return root;

        }
    }
}
