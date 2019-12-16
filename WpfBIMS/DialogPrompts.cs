using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBIMS
{
    class DialogPrompts
    {
        public static string failedLogin { get; set; }

        public static void LoginFailedDialog()
        {
            string loginMsg = ("Incorrect username or password. Please try again.");
            failedLogin = loginMsg;
        }

        public static string inputData { get; set; }

        public static void DataSuccessfulDialog()
        {
            string inputMsg = ("Information successfully stored!");
            inputData = inputMsg;
        }
    }
}
