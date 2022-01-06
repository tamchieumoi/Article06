using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Entity;

namespace Article04
{
    public class DBConnection:DbContext
    {
        public DBConnection() : base("name= SaleDB")
        {
        }
        public System.Data.Entity.DbSet<CustomerBEL> Customers { get; set; }
    }
}
