namespace ChoiceGame
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }
        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);
            const int newWidth = 1000;
            const int newHeight = 800;
            window.Width = newWidth;
            window.Height = newHeight;
            window.MaximumHeight = newHeight;
            window.MaximumWidth = newWidth;
            window.MinimumHeight = newHeight;
            window.MinimumWidth = newWidth;
            return window;
        }
    }
}
