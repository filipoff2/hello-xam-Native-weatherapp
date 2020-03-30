namespace WeatherApp.UITests.Pages
{

    interface ICitySelectPage: IPage
    {
        void EnterCityName(string cityName);
        void PressSearch();
        void LookForText(string text);
        void CheckCityName(string value);
    }
}
