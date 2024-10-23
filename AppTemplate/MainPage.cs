namespace AppTemplate;

public sealed partial class MainPage : Page
{
    public MainPage() {
        this.DataContext(new MainViewModel(), Render);
    }

    public void Render(MainPage _page, MainViewModel _vm) {
        _page.Background(ThemeResource.Get<Brush>("ApplicationPageBackgroundThemeBrush"));
        _page.Content(new StackPanel {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            }.Children(
                new TextBlock {
                    Margin = new Thickness(12),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextAlignment = Microsoft.UI.Xaml.TextAlignment.Center,
                }.Text("Hello Uno Platform!"),

                new TextBlock {
                    Margin = new Thickness(12),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextAlignment = Microsoft.UI.Xaml.TextAlignment.Center,
                }.Text(() => _vm.Count, (txt) => $"Counter: {txt}"),

                new NumberBox {
                    Margin = new Thickness(12),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    TextAlignment = Microsoft.UI.Xaml.TextAlignment.Center,
                }.Text(x => x.Binding(() => _vm.Step).TwoWay()),

                new Button {
                    Margin = new Thickness(12),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Content = "Increment"
                }.Command(() => _vm.IncrementCommand)
            )
        );
    }

    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private int _step = 1;

        [ObservableProperty]
        private int _count = 0;

        [RelayCommand]
        private void Increment() {
            Count += Step;
        }
    }
}
