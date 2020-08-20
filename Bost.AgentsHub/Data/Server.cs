using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bost.AgentsHub.Data
{
    public class Server
    {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
        public string IpPort { get; set; }
    }
}
