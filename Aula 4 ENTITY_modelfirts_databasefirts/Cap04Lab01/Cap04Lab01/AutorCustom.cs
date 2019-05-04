using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cap04Lab01.Models;

namespace Cap04Lab01.Models
{
        public partial class Autor
        {
            public string NomeCompleto
            {
                get { return Nome + " " + SobreNome; }
            }
        }
    }