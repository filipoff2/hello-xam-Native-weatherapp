using System;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace WeatherApp.UITests.Pages
{

    public class CityDetailsPage: ICityDetailsPage
    {
        Func<AppQuery, AppQuery> CityName { get; } = c => c.Marked("CityName");
        Func<AppQuery, AppQuery> DayLabels { get; } = c => c.Marked("DayLabel");
        Func<AppQuery, AppQuery> FavoriteButton { get; } = c => c.Marked("FavoriteButton");

        public string Name => "City details";

        IApp _app;

        public CityDetailsPage(IApp app)
        {
            _app = app;
        }

        public void CheckIsCurrent()
        {
            _app.WaitForElement(CityName);
        }

        public void CheckCityName(string name)
        {
            var label = _app.WaitForElement(CityName)[0];
            Assert.AreEqual(name, label.Text);
        }

        public void CheckCellsExist()
        {
            var elements = _app.Query(DayLabels);
            Assert.Greater(elements.Length, 1);
        }

        public void CheckIsFavorite(bool shouldBe)
        {
            var got = (Int64)_app.Query(c => FavoriteButton(c).Invoke("isSelected"))[0];
            var expected = shouldBe ? 1L : 0L;
            Assert.AreEqual(expected, got);
        }

        public void ToggleFavoriteButton()
        {
            _app.Tap(FavoriteButton);
        }
    }
}
