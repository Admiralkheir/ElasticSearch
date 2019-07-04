using ElasticSearch.Data.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.Data.Contracts.Abstracts
{
    public interface IElasticContext
    {
        IndexResponseDTO CreateIndex<T>(string indexName, string aliasName) where T : class;
    }
}

