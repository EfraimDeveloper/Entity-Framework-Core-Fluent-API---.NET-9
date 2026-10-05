using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.Models
{
    public class Client
    {
        public int code { get; set; }
        public string name { get; set; }
        public string Email { get; set; }
        public int Ativo { get; set; }
        public DateTime DateTime { get; set; }
    }
}
