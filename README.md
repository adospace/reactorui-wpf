# ReactorUI for WPF (aka reactorui-wpf)
UI framework built on top of WPF heavily inspired to ReactJS and Flutter

[![Build status](https://ci.appveyor.com/api/projects/status/yn1n2vth5tam1bv1?svg=true)](https://ci.appveyor.com/project/adospace/reactorui-wpf)
[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/WpfReactorUI)](https://www.nuget.org/packages/WpfReactorUI)

ReactorUI for WPF is a .NET UI library written on top of WPF that let you write Windows applications using a MVU approach much similar to Flutter or ReactJS.

One key feature of ReactorUI is the Hot-Reload module: you'll be able to modify the application source code and UI without restarting the app.

Traditionally, WPF/UWP/WinUI/Avalonia/Xamarin/Uno frameworks encourage a MVVM approach in writing applications: 

There is a view (usually written in XAML):
```xaml
<Window x:Class="WpfReactorUI.DemoApp.LoginWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <StackPanel
        VerticalAlignment="Center"
        HorizontalAlignment="Center">
        <TextBox Text="{Binding Username}"/>
        <TextBox Text="{Binding Password}"/>
    </StackPanel>
</Window>
```
that is linked/bound to ViewModel (written in C#/VB.NET/F# etc):

```cs
public class LoginWindowViewModel : BindableObject
{
    private string _username;

    public string Username
    {
        get => _username;
        set
        {
            if (_username != value)
            {
                _username = value;
                OnPropertyChanged();
                LoginCommand.ChangeCanExecute();
            }
        }
    }

    private string _password;

    public string Password
    {
        get => _password;
        set
        {
            if (_password != value)
            {
                _password = value;
                OnPropertyChanged();
                LoginCommand.ChangeCanExecute();
            }
        }
    }

    private Command _loginCommand;

    public Command LoginCommand
    {
        get
        {
            _loginCommand = _loginCommand ?? new Command(OnLogin, () => !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password));
            return _loginCommand;
        }
    }

    private void OnLogin()
    {
        //Username contains username and Password contains password
        //make login..
    }
}
```

ReactorUI uses a MVU approach: you write components instead of controls in a single file mixing UI and back-end code.
Following is the same login screen written in ReactorUI:

```cs
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
```

One big advantage of the ReactorUI approach is that its state live externally to the component making possible hot reloading it.
