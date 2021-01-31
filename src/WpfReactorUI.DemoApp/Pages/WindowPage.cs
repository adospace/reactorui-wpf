using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfReactorUI.DemoApp.Pages
{
    public class WindowState : IState
    {
        public bool IsWindowOpen { get; set; }
    }

    public class WindowPage : RxComponent<WindowState>
    {
        public override VisualNode Render()
        {
            return new RxPage()
            {
                new RxGrid()
                {
                    new RxButton("Open Window")
                        .OnClick(()=> SetState(s => s.IsWindowOpen = true))
                        .VCenter()
                        .HCenter(),
                    new RxWindowHost()
                    {
                        new RxWindow()
                        {
                            new RxButton()
                                .ContentString("Close")
                                .VCenter()
                                .HCenter()
                                .OnClick(()=>SetState(_=>_.IsWindowOpen = false))
                        }
                        .Height(400)
                        .Width(400)
                        .Title("New Window")
                        .OnClosed(()=> SetState(s => s.IsWindowOpen = false))
                        .If(State.IsWindowOpen)
                    }
                    .ShowAsDialog(true)
                }
            }
            .Title("Window Page");
        }
    }
}
