using SchulungMvc.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchulungQotd.Service
{
    public class QotdService : IQotdService
    {
        public Task<QuoteOfTheDayViewModel?> GetQuoteOfTheDayAsync()
        {
            //TODO: Zufallsspruch holen und zurückgeben
            
        }
    }
}
