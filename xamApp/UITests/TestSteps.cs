using System;
using Xamarin.UITest;
using TechTalk.SpecFlow;
using Xamarin.UITest.Queries;
using WeatherApp.UITests.Pages;
using Xamarin.UITest.Configuration;
using System.Linq;

namespace WeatherApp.SpecFlow
{
    [Binding]
    public class TestSteps
    {
        IApp app;

        IPage[] pages;
        ICitySelectPage citySelect;
        ICityDetailsPage cityDetails;

        void Restart(bool clear = true)
        {
            var mode = clear ? AppDataMode.Clear : AppDataMode.DoNotClear;
            var platform = FeatureContext.Current.Get<Platform>();



            if (platform == Platform.Android)
            {
                app = ConfigureApp.Android.StartApp(mode);
                pages = new IPage[]
                {
                    citySelect = new CitySelectPage(app),
                    cityDetails = new CityDetailsPageAndroid(app),
                };
            }
            else 
            {
                app = ConfigureApp.iOS.StartApp(mode);
                //app.Invoke("DisableAnimations");
                pages = new IPage[]
                {
                    citySelect = new CitySelectPage(app),
                    cityDetails = new CityDetailsPage(app),
                };
            }


        }

        [Given(@"I am on the home screen")]
        public void GivenIAmOnHomeScreen()
        {
            Restart();
        }

        [When(@"I relaunch the app")]
        void Relaunch()
        {
            Restart(false);
        }

        [Given(@"I have entered (.*) into the search box")]
        public void GivenIHaveEnteredLondonIntoTheSearchBox(string cityName)
        {
            citySelect.EnterCityName(cityName);
        }

        [When(@"I press search button")]
        public void WhenIPressSearchButton()
        {
            citySelect.PressSearch();
        }

        [Then(@"""(.*)"" message appears")]
        public void ThenMessageAppears(string message)
        {
            citySelect.LookForText(message);
        }

        [Then(@"(.*) screen should appear")]
        public void ThenScreenAppears(string name)
        {
            var targetPage = pages.First(x => String.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase));
            targetPage.CheckIsCurrent();
        }

        [Given(@"I have previously searched for (.*)")]
        public void GivenIHavePreviouslySearchedForValue(string name)
        {
            Restart();
            citySelect.CheckIsCurrent();
            citySelect.EnterCityName(name);
            citySelect.PressSearch();
            cityDetails.CheckIsCurrent();
            app.Back();
        }

        [Then(@"(.*) should be in the search box")]
        public void ThenValueShouldBeInTheSearchBox(string value)
        {
            citySelect.CheckCityName(value);
        }

        [Then(@"Header title should be (.*)")]
        public void ThenHeaderTitleShouldBe(string name)
        {
            cityDetails.CheckCityName(name);
        }

        [Then("Daily forecast should be visible")]
        public void DailyForecastShouldBeVisible()
        {
            cityDetails.CheckCellsExist();
        }

        [Given(@"London is my favorite city")]
        public void GivenLondonIsMyFavoriteCity()
        {
            GivenIAmOnTheCityDetailsScreen();
            cityDetails.ToggleFavoriteButton();
            cityDetails.CheckIsFavorite(true);
        }


        [Given(@"I am on the city details screen")]
        public void GivenIAmOnTheCityDetailsScreen()
        {
            Restart();
            citySelect.EnterCityName("London");
            citySelect.PressSearch();
            cityDetails.CheckCityName("London");
        }

        [Given(@"Favorite button is not selected")]
        public void GivenFavoriteButtonIsNotSelected()
        {
            cityDetails.CheckIsFavorite(false);
        }

        [When(@"I press the favorite button")]
        public void WhenIPressTheFavoriteButton()
        {
            cityDetails.ToggleFavoriteButton();
        }

        [When(@"I go back")]
        public void WhenIGoBack()
        {
            app.Back();
        }

        [Then(@"favorite button should appear selected")]
        public void ThenFavoriteButtonShouldAppearSelected()
        {
            cityDetails.CheckIsFavorite(true);
        }

        [Then(@"search box should be empty")]
        public void ThenSearchBoxShouldBeEmpty()
        {
            citySelect.CheckCityName("");
        } 
    }
}
