using Nest;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.Core.Common.Helpers
{
    public class ElasticHelper
    {
        //setlenemez.(readonly)
        //lazy nesne kullanılcağı zaman yaratılır.
        private static readonly Lazy<ElasticHelper> _instance = new Lazy<ElasticHelper>(()=> new ElasticHelper());
        public ElasticHelper()
        {

        }

        public static ElasticHelper Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public ConnectionSettings GetConnectionSettings()
        {
            var connectionSettings = new ConnectionSettings(new Uri(ConfigurationManager.AppSettings["ElasticSearchURI"]));
            return connectionSettings;
        }
    }
}
