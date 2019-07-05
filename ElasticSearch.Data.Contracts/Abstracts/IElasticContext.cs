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
        //elastic üzerinde bir adet index yaratmak için oluşturulan bir mesaj imzası
        IndexResponseDTO CreateIndex<T>(string indexName, string aliasName) where T : class;
    }
}

