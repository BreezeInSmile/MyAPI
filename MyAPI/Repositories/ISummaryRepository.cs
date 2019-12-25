using MyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.Repositories
{
    public interface ISummaryRepository
    {
        public Task<CompanySummary> GetCompanySummary();        
    }
}
