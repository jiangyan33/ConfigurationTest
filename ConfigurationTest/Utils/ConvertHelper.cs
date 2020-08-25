using System.Collections.Generic;
using System.Collections.Specialized;

namespace ConfigurationTest.Utils
{
    public class ConvertHelper
    {
        /// <summary>
        /// 将NameValueCollection类型转换IEnumerable<KeyValuePair<string, string>>类型
        /// </summary>
        /// <param name="nameValueCollection"></param>
        /// <returns></returns>
        public static IEnumerable<KeyValuePair<string, string>> ConvertCollectionToKeyValuePair(NameValueCollection nameValueCollection)
        {
            var list = new List<KeyValuePair<string, string>>();
            var keys = nameValueCollection.AllKeys;
            foreach (var key in keys)
            {
                list.Add(new KeyValuePair<string, string>(key, nameValueCollection[key]));
            }
            return list;
        }
    }
}