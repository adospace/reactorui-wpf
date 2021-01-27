namespace WpfReactorUI
{
    public interface INavigation
    {
        void Navigate<TPAGE>() where TPAGE : VisualNode, new();
        void GoBack();
    }
}