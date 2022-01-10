using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APKUWPHelper.Helpers
{
   public class CacheData
    {
        private static object obj = new object();
        private static CacheData cacheData;

        public static CacheData Ins
        {
            get {
                lock (obj)
                {
                    if (cacheData == null)
                        cacheData = new CacheData();
                }
                return cacheData; }
        }
    }
}
