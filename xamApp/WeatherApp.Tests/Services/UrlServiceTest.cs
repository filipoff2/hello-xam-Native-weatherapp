using NUnit.Framework;
using WeatherApp.Services;
using System.Threading.Tasks;
using System.Net.Http;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace WeatherApp.Tests
{
   [TestFixture]
    public class UrlServiceTests
    {
        public UrlServiceTests()
        {
        }

        public static IEnumerable TestCases()
        {
            List<string[]> list = TestHelper.GetCsvFile("places.csv");
            foreach (var pair in list)
            {
                yield return new TestCaseData(pair[0]);
            }
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public async Task DoesUrlContainsSpaceFromFile(string cityname)
        {
            IUrlService urlService = new UrlService();
            var url = urlService.GetCityUrl(true, cityname);
            Assert.IsFalse(url.Contains(" "));
        }

        [Test]
        [TestCase("Rzeszow")]
        public async Task TestGetCityUrl(string name)
        {
            IUrlService urlService = new UrlService();
            var url = urlService.GetCityUrl(true, name);
            Assert.IsTrue(url.Contains(name));
        }
    }
}
