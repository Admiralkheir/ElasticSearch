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
        //setlenemez.(readonly)(static constructor da hariç)
        //lazy nesne kullanılcağı zaman yaratılır.
        //Lazy sınıfı generic bir sınıftır. Constructor'ın bir overload'u olan Func<T>'e bir method verildiğinde bu nesne'nin value değerine erişilmeye çalışılırken bu metod da tetiklenecektir. 
        //iki farklı propertysi bulunur. IsValueCreated ve Value olmak üzere.
        private static readonly Lazy<ElasticHelper> _instance = new Lazy<ElasticHelper>(()=> new ElasticHelper());
        public ElasticHelper()
        {
            
        }
        //yani ElasticHelper.Instance dediğimizde get selector'ünde value değeri oluşturulmaya çalışıldığı için burda constructor'ın içindeki metod değeri tetiklenip nesne oluşturulcaktır.
        public static ElasticHelper Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        //ElasticSearch client objesi yaratabilmek için ConnectionSettings tipinde bir instance'a ihtiyaç vardır.

        public ConnectionSettings GetConnectionSettings()
        {
            var connectionSettings = new ConnectionSettings(new Uri(ConfigurationManager.AppSettings["ElasticSearchURI"]));
            return connectionSettings;
        }
    }
}
