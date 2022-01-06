using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Article04
{
    public class CustomerDAL : DBConnection
    {
        public List<CustomerBEL> ReadCustomer()
        {
            return Customers.ToList();
/*            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from customer", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<CustomerBEL> lstCus = new List<CustomerBEL>();
            while (reader.Read())
            {
                CustomerBEL cus = new CustomerBEL();
                cus.Id = int.Parse(reader["id"].ToString());
                cus.Name = reader["name"].ToString();
                lstCus.Add(cus);
            }
            conn.Close();
            return lstCus;*/
        }
        public void DeleteCustomer(CustomerBEL cus)
        {
            this.Customers.Remove(cus);
            this.SaveChanges();
/*            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from customer where id =@id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.Id));
            cmd.ExecuteNonQuery();
            conn.Close();*/
        }
        public void AddCustomer(CustomerBEL cus)
        {
            this.Customers.Add(cus);
            this.SaveChanges();
            /*            SqlConnection conn = CreateConnection();
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("insert into customer values(@id,@name)", conn);
                        cmd.Parameters.Add(new SqlParameter("@id", cus.Id));
                        cmd.Parameters.Add(new SqlParameter("@name", cus.Name));
                        cmd.ExecuteNonQuery();
                        conn.Close();*/
        }
        public void EditCustomer(CustomerBEL cus)
        {
            this.Entry(cus).State = System.Data.Entity.EntityState.Modified;
            this.SaveChanges();
/*            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("update customer set Name =@name where id=@id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", cus.Id));
            cmd.Parameters.Add(new SqlParameter("@name", cus.Name));
            cmd.ExecuteNonQuery();
            conn.Close();*/
        }
    }
}
