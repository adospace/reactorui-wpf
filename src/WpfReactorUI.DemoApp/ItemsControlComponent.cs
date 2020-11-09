using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace WpfReactorUI.DemoApp
{
    public class Item
    {
        public Item(string name)
        {
            Name = name;
        }
        public string Name { get; }
    }

    public class ItemsControlComponentState : IState
    {
        public Item[] Items { get; set; }
        public Item SelectedItem { get; set; }
    }

    public class ItemsControlComponent : RxComponent<ItemsControlComponentState>
    {
        protected override void OnMounted()
        {
            SetState(s => s.Items = new[] { new Item("Item1"), new Item("Item2"), new Item("Item3"), new Item("Item5") });
            base.OnMounted();
        }

        public override VisualNode Render() =>
            new RxWindow()
            {
                new RxListBox()
                    .ItemsSource(State.Items)
                    .SelectedItem(State.SelectedItem)
                    .OnSelectionChanged<RxListBox, Item>(item => SetState(s => s.SelectedItem = item))
                    .OnRenderItem<RxListBox, Item>(_ => new RxTextBlock().Text(_.Name).Foreground(Brushes.Black))
                    .FontSize(24)
                    .VCenter()
                    .HCenter()
            };
    }
}
