using ElasticSearch.Core.Common.Helpers;
using ElasticSearch.Data.Context;
using ElasticSearch.Data.Entities.Entities;
using Nest;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.DataTransfer
{
    public class Program
    {
        static void Main(string[] args)
        {
            //appconfig'den veri okumaya yarıyor. Appconfig içinde eklenen keylerde değişiklik yapıldığında tekrar projede herhangi bir kod satırını değiştirmeden burdan value okunabilir. ConfigurationManager sınıfının AppSettings metodundan girilen key değeri ile value döndürülebilir.
            string indexName = string.Format("{0}_{1}", ConfigurationManager.AppSettings["ElasticSearchIndexName"], DateTime.Now.ToString("yyyyMMddHHss"));

            string aliasName = ConfigurationManager.AppSettings["ElasticSearchIndexName"];

            var elasticClient = new ElasticClient(ElasticHelper.Instance.GetConnectionSettings());

            var elasticContext = new ElasticContext(elasticClient);

            CreateIndex(elasticContext, indexName, aliasName);

            Console.ReadKey();
        }
        private static void CreateIndex(ElasticContext elasticContext, string indexName, string aliasName)
        {
            var response = elasticContext.CreateIndex<Product>(indexName, aliasName);

            Console.WriteLine(response.StatusMessage);
        }
    }
}
