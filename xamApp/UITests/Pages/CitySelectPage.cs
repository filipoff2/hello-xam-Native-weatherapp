using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using NUnit.Framework;

namespace WeatherApp.UITests.Pages
{
    class CitySelectPage : ICitySelectPage
    {
        IApp _app;
        Func<AppQuery, AppQuery> searchTextField = (arg) => arg.TextField("SearchTextField");
        Func<AppQuery, AppQuery> searchButton = (arg) => arg.Button("SearchButton");

        public string Name => "Home";

        public CitySelectPage(IApp app)
        {
            _app = app;
        }

        public void EnterCityName(string cityName)
        {
            _app.Tap(searchTextField);
            _app.EnterText(cityName);
        }

        public void PressSearch()
        {
            _app.Tap(searchButton);
        }

        public void LookForText(string text)
        {
            var result = _app.WaitForElement(x => x.Text(text));
            Assert.AreEqual(1, result.Length);
        }

        public void CheckIsCurrent()
        {
            _app.WaitForElement(searchButton);
        }

        public void CheckCityName(string value)
        {
            var current = _app.Query(searchTextField)[0].Text;
            Assert.AreEqual(value, current);
        }
    }
}
