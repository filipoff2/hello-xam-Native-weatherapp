using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Services.Interfaces
{
    public interface IHttpClient
    {
        Task<T> DoGetRequest<T>(string path);
    }
}
