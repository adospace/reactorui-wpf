using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfReactorUI.DemoApp
{
    public class FrameComponent : RxComponent
    {
        public override VisualNode Render()
        {
            return new RxFrame()
            {
                new Page1()
            };
        }
    }

    public class Page1State : IState 
    {
        public string TextBoxContent { get; set; }
    }

    public class Page1 : RxComponent<Page1State>
    {

        public override VisualNode Render()
        {
            return new RxPage()
            {
                new RxStackPanel()
                {
                    new RxTextBlock()
                        .Text("Page1"),
                    new RxTextBox()
                        .Text(State.TextBoxContent)
                        .OnTextChanged(newText => SetState(s => s.TextBoxContent = newText)),
                    new RxButton()
                        .ContentString("Go To Page 2")
                        .OnClick(()=> Navigation.Navigate<Page2>())
                }
                .VCenter()
                .HCenter()
            };
        }
    }

    public class Page2State : IState
    {
        public string TextBoxContent { get; set; }
    }

    public class Page2 : RxComponent<Page2State>
    {
        public override VisualNode Render()
        {
            return new RxPage()
            {
                new RxStackPanel()
                {
                    new RxTextBlock()
                        .Text("Page2"),
                    new RxTextBox()
                        .Text(State.TextBoxContent)
                        .OnTextChanged(newText => SetState(s => s.TextBoxContent = newText)),

                    new RxButton()
                        .ContentString("Go Back")
                        .OnClick(()=> Navigation.GoBack())

                }
                .VCenter()
                .HCenter()                
            };
        }
    }
}
