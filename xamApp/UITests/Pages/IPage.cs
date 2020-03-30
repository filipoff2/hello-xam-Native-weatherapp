namespace WeatherApp.UITests.Pages
{
    interface IPage
    {
        void CheckIsCurrent();
        string Name { get; }
    }
}
