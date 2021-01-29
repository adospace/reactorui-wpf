using System;
using System.Windows.Media;

namespace WpfReactorUI.DemoApp
{
    internal class MainComponent : RxComponent
    {
        public override VisualNode Render()
        {
            return new RxWindow()
            {
                new RxDockPanel()
                { 
                    Menu(),
                    PageList().DockLeft(),
                    new RxFrame()
                }

            }
            .Title("ReactorUI for WPF");
        }

        private RxListBox PageList()
        {
            return new RxListBox()

                .OnSelectionChanged((s, e) =>
                {

                });
        }

        private VisualNode Menu()
        {
            throw new NotImplementedException();
        }
    }
}