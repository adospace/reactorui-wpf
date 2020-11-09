using System.Windows.Media;

namespace WpfReactorUI.DemoApp
{
    internal class MainComponent : RxComponent
    {
        public override VisualNode Render()
        {
            return new RxWindow()
            {
                new RxTextBlock()
                    .Text("ReactorUI + WFP!")
                    .VCenter()
                    .HCenter()
                    .FontSize(32)
                    .Foreground(Brushes.Black)
            }
            .Title("ReactorUI for WPF");
        }
    }
}