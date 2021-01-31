using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace WpfReactorUI.DemoApp.Pages
{
    public class LoginComponentState : IState
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class LoginPage : RxComponent<LoginComponentState>
    {
        public override VisualNode Render()
            => new RxPage()
            {
                new RxStackPanel()
                {
                    new RxTextBox()
                        .Text(()=> State.Username)
                        .OnTextChanged(text => SetState(s => s.Username = text)),
                    new RxTextBox()
                        .Text(()=> State.Password)
                        .OnTextChanged(text => SetState(s => s.Password = text)),
                    new RxButton()
                        .OnClick(OnLogin)
                        .IsEnabled(!string.IsNullOrWhiteSpace(State.Username) && !string.IsNullOrWhiteSpace(State.Password))
                }
            }
            .Title("Login Page");

        private void OnLogin()
        {
            //login with State.Username and State.Password
            MessageBox.Show($"Logged in with username={State.Username} and password={State.Password}");
        }
    }
}
