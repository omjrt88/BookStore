using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreDesk.Utils
{
    public static class Common
    {
        public static string ApiUrl = "CONFIGURATION_API_URL";

        public static Dictionary<string, int> Reviews =
            new Dictionary<string, int>(){
                {"Excellent", 5},
                {"Great", 4},
                {"Average", 3},
                {"Unsatisfactory", 2},
                {"Bad", 1}
            };
    }
}
