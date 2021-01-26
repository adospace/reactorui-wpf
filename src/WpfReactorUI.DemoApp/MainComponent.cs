using System.Windows.Media;

namespace WpfReactorUI.DemoApp
{
    internal class MainComponent : RxComponent
    {
        public override VisualNode Render()
        {
            return new RxWindow()
            {
                //new RxTextBlock()
                //    .Text("ReactorUI + WFP!")
                //    .VCenter()
                //    .HCenter()
                //    .FontSize(32)
                //    .Foreground(Brushes.Black)
                new DataGridComponent()
            }
            .Title("ReactorUI for WPF");
        }
    }
}