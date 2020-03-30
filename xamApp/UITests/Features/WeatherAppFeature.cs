using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace WeatherApp.UITests.Features
{
    [TestFixture(Platform.iOS)]
    [TestFixture(Platform.Android)]
    public partial class WeatherAppFeature
    {
        readonly Platform platform;

        public WeatherAppFeature(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void SetUp()
        {
            FeatureContext.Current.Set(platform);
        }
    }
}
