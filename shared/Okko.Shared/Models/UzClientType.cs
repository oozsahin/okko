using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Okko.Shared.Models
{
    public class UzClientType : IUzClientType
    {
        public int Id { get; set; }
        public string ClientType { get; set; }
        public string ClientTypeName { get; set; }
    }
}
