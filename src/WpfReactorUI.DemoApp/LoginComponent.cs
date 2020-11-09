using System;
using System.Collections.Generic;
using System.Text;

namespace WpfReactorUI.DemoApp
{
    public class LoginComponentState : IState
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class LoginComponent : RxComponent<LoginComponentState>
    {
        public override VisualNode Render()
            => new RxStackPanel()
            {
                new RxTextBox()
                    .Text(State.Username)
                    .OnTextChanged(text => SetState(s => s.Username = text)),
                new RxTextBox()
                    .Text(State.Password)
                    .OnTextChanged(text => SetState(s => s.Password = text)),
                new RxButton()
                    .OnClick(OnLogin)
            };

        private void OnLogin()
        {
            //login with State.Username and State.Password
        }
    }
}
