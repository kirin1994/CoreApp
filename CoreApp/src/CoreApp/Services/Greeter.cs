using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Services
{
    public interface IGreeter {
        string GetGreeting();
    }

    public class Greeter : IGreeter
    {
        private string _greeting;

        public Greeter(IConfiguration configuration) { //IConfiguration which I created and where I store my configuration
            _greeting = configuration["Greeting"];
        }
        public string GetGreeting() {
            return _greeting;
        }
    }
}
