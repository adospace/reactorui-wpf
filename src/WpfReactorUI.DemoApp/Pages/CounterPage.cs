using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfReactorUI.DemoApp.Pages
{
    public class CounterState : IState
    {
        public int Counter { get; set; }
    }

    public class CounterPage : RxComponent<CounterState>
    {
        public override VisualNode Render() 
            => new RxPage()
            {
                new RxStackPanel()
                {
                    new RxTextBlock()
                        .Text(State.Counter.ToString())
                        .HorizontalAlignment(System.Windows.HorizontalAlignment.Center)
                        .Margin(10),
                    new RxButton()
                        .ContentString("Click Here!")
                        .OnClick(()=>SetState(s => s.Counter++))

                }
                .VerticalAlignment(System.Windows.VerticalAlignment.Center)
                .HorizontalAlignment(System.Windows.HorizontalAlignment.Center)
            }
            .Title("Counter Page");
    }
}
