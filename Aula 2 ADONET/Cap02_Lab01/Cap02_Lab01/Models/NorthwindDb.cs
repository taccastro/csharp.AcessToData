using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cap02_Lab01.Models
{
    public class NorthwindDb
    {
        public static string Conexao
        {

            get
            {

                return @"Data Source=DESKTOP-TACCAST; Initial Catalog=northwind; Integrated Security=true";


            }





        }


    }
}