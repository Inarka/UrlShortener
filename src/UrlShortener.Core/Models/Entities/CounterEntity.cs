using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Core.Models.Entities
{
    public class CounterEntity
    {
        public Guid DefaultValue { get; set; }
        public int CurrentValue { get; set; }
    }
}
