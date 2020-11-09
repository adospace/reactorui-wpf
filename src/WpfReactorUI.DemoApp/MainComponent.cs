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
                    .FontSize(24)
            }
            .Title("ReactorUI for WPF");
        }
    }
}