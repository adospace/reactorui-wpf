# ReactorUI for WPF (aka reactoru-wpf)
UI framework built on top of WPF heavily inspired to ReactJS and Flutter

[![Build status](https://ci.appveyor.com/api/projects/status/yn1n2vth5tam1bv1?svg=true)](https://ci.appveyor.com/project/adospace/reactorui-wpf)
[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/WpfReactorUI)](https://www.nuget.org/packages/WpfReactorUI)

ReactorUI for WPF is a .NET UI library written on top of WPF that let you write Windows applications using a MVU approach much similar to Flutter or ReactJS.

One key feature of ReactorUI is the Hot-Reload module: you'll be able to modify the application source code and UI without restarting the app.

Traditionally, WPF/UWP/WinUI/Avalonia/Xamarin/Uno frameworks encourage a MVVM approach in writing applications: 

There is a view (usually written in XAML):
```xaml
<Window xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:d="http://xamarin.com/schemas/2014/forms/design"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
             mc:Ignorable="d"
             x:Class="App.MainWindow">
    <StackLayout
        VerticalOptions="Center"
        HorizontalOptions="Center">
        <TextBox Placeholder="Username" Text="{Binding Username}" />
        <TextBox Placeholder="Password" Text="{Binding Password}" />
        <Button Text="Login" Command="{Binding LoginCommand}" />
    </StackLayout>
</Window>
```
that is linked/bound to ViewModel (written in C#/VB.NET/F# etc):

```cs
public class MainWindowViewModel : BindableObject
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
public class MainPageState : IState
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class MainPage : RxComponent<MainPageState>
{
    public override VisualNode Render()
    {
        return new RxContentPage()
        {
            new RxStackLayout()
            {
                new RxTextBox()
                    .Placeholder("Username")
                    .OnTextChanged((s,e)=> SetState(_ => _.Username = e.NewTextValue)),
                new RxTextBox()
                    .Placeholder("Password")
                    .OnTextChanged((s,e)=> SetState(_ => _.Password = e.NewTextValue)),
                new RxButton("Login")
                    .IsEnabled(!string.IsNullOrWhiteSpace(State.Username) && !string.IsNullOrWhiteSpace(State.Password))
                    .OnClick(OnLogin)
            }
            .VCenter()
            .HCenter()
        };
    }

    private void OnLogin()
    {
        //use State.Username and State.Password to login...
    }
}
```

One big advantage of the ReactorUI approach is that its state live externally to the component making possible the its hot reload.
