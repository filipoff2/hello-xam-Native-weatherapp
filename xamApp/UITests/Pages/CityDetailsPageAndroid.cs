using System;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace WeatherApp.UITests.Pages
{
    public class CityDetailsPageAndroid: ICityDetailsPage
    {
        Func<AppQuery, AppQuery> CityName { get; } = c => c.Marked("CityName");
        Func<AppQuery, AppQuery> DayLabels { get; } = c => c.Marked("DayLabel");
        Func<AppQuery, AppQuery> FavoriteButton { get; } = c => c.Marked("FavoriteButton");

        public string Name => "City details";

        IApp _app;

        public CityDetailsPageAndroid(IApp app)
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
            var got = _app.Query(c => FavoriteButton(c).Invoke("isChecked").Value<bool>())[0];
            var exp = shouldBe;
            Assert.AreEqual(exp, got);
        }

        public void ToggleFavoriteButton()
        {
            _app.Tap(FavoriteButton);
        }
    }
}
