using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIAutoFac
{
    public class Helper : IHelper
    {
        public void log(string message) {
            Console.WriteLine(message);
        }
    }
}