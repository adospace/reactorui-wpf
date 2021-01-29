using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfReactorUI.DemoApp
{
    public class WindowState : IState
    {
        public bool IsWindowOpen { get; set; } = true;
    }

    public class WindowTestComponent : RxComponent<WindowState>
    {
        public override VisualNode Render()
        {
            return new RxWindowHost()
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
                .If(State.IsWindowOpen)
            }
            .ShowAsDialog(true);
        }
    }
}
