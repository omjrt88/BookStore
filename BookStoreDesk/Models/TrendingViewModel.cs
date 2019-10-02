using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreDesk.Models
{
    public class TrendingViewModel
    {
        public List<BookViewModel> TrendingBooks { get; set; }

        public List<BookViewModel> NewestBooks { get; set; }
    }
}
