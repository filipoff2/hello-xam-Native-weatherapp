namespace WeatherApp.UITests.Pages
{
    interface ICityDetailsPage : IPage
    {
        void CheckCityName(string name);
        void CheckCellsExist();

        void CheckIsFavorite(bool shouldBe);
        void ToggleFavoriteButton();
    }
}
