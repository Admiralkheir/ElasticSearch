using ElasticSearch.Data.Contracts.Abstracts;
using ElasticSearch.Data.Contracts.DTO;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.Data.Context
{
    public class ElasticContext : IElasticContext
    {
        private readonly ElasticClient _elasticClient;

        public ElasticContext(ElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }


        public IndexResponseDTO CreateIndex<T>(string indexName, string aliasName) where T : class
        {
            var createIndexResponse = _elasticClient.Indices.Create("myindex", c => c
            .Map<T>(m => m.AutoMap()).Aliases(a => a.Alias(aliasName)));
            



            return new IndexResponseDTO()
            {
                IsValid = createIndexResponse.IsValid,
                StatusMessage = createIndexResponse.DebugInformation,
                Exception = createIndexResponse.OriginalException
            };
        }
    }
}
