using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorreiaNetCRM.Lib.Helpers
{
    public static partial class Helper
    {

        public static class Global
        {

            public static int PageSize
            {
                get { return _pageSize; }
                set
                {
                    _pageSize = value;
                }
            }
            private static int _pageSize = 10;

        }
    }
}