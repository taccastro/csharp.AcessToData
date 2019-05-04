using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Cap06Lab01.Models
{
    [DataContract]
    public class ClienteAvulso
    {
        [DataMember(Order = 0)]
        public string Nome { get; set; }
        [DataMember(Order = 1)]
        public string Telefone { get; set; }
        [DataMember(Order = 2)]
        public string Email { get; set; }
        [DataMember(Order = 3)]
        public string Cidade { get; set; }
    }
}