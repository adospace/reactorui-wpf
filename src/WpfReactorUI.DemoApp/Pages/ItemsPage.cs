using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace WpfReactorUI.DemoApp.Pages
{
    public class ItemPageEntry
    {
        public ItemPageEntry(string name)
        {
            Name = name;
        }
        public string Name { get; }
    }

    public class ItemsPageState : IState
    {
        public ItemPageEntry[] Items { get; set; }
        public ItemPageEntry SelectedItem { get; set; }
    }

    public class ItemsPage : RxComponent<ItemsPageState>
    {
        protected override void OnMounted()
        {
            SetState(s => s.Items = new[] { new ItemPageEntry("Item1"), new ItemPageEntry("Item2"), new ItemPageEntry("Item3"), new ItemPageEntry("Item5") });
            base.OnMounted();
        }

        public override VisualNode Render() =>
            new RxPage()
            {
                new RxListBox()
                    .ItemsSource(State.Items)
                    .SelectedItem(State.SelectedItem)
                    .OnSelectionChanged<RxListBox, ItemPageEntry>(item => SetState(s => s.SelectedItem = item))
                    .OnRenderItem<RxListBox, ItemPageEntry>(_ => new RxTextBlock().Text(_.Name).Foreground(Brushes.Black))
                    .FontSize(24)
                    .VCenter()
                    .HCenter()
            }
            .Title("Counter Page");
    }
}
