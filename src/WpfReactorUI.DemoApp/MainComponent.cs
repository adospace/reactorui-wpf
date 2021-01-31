using System;
using System.Linq;
using System.Windows.Media;

namespace WpfReactorUI.DemoApp
{
    public class MainComponentState : IState
    { 
        public Type CurrentPage { get; set; }
    }

    internal class MainComponent : RxComponent<MainComponentState>
    {
        private static readonly Type[] _pages = new[]
        {
            typeof(Pages.CounterPage),
            typeof(Pages.ItemsPage),
            typeof(Pages.DataGridPage)
        };

        protected override void OnMounted()
        {
            State.CurrentPage = _pages[0];

            base.OnMounted();
        }

        public override VisualNode Render()
        {
            return new RxWindow()
            {
                new RxDockPanel()
                { 
                    Menu(),
                    PageList().DockLeft(),
                    new RxFrame()
                    { 
                        ((VisualNode)Activator.CreateInstance(State.CurrentPage))
                    }
                }
                .LastChildFill(true)
            }
            .Title("ReactorUI for WPF");
        }

        private RxListBox PageList()
        {
            return new RxListBox()
                .ItemsSource(_pages)
                .OnRenderItem((Type _) => new RxTextBlock().Text(_.Name))
                .OnSelectionChanged((s, e) =>
                {
                    SetState(s => s.CurrentPage = e.AddedItems.Cast<Type>().FirstOrDefault());
                })
                .Width(150);
        }

        private VisualNode Menu()
        {
            return new RxMenu();
        }
    }
}