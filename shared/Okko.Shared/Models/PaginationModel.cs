using System;
using System.Collections.Generic;
using System.Text;

namespace Okko.Shared.Models
{
    public class PaginationModel
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 10;
    }
}
