using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace WCFtehtava1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetDataFromTable(TestTable tb)
        {
            string msg;
            SqlConnection con1 = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TestDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand("INSERT INTO TestTable(TestId, TestName) VALUES(@TestId,@TestName)",con1);
            cmd.Parameters.AddWithValue("@TestId", tb.TestId);
            cmd.Parameters.AddWithValue("@TestName", tb.TestName);
            con1.Open();
            int result = cmd.ExecuteNonQuery();
            if(result == 1)
            {
                msg = "Success!";
            }
            else
            {
                msg = "You're a failure!";
            }
            con1.Close();
            return msg;
        }
        public TestTable PutData(TestTable tb)
        {
            TestTable tb1 = new TestTable();
            SqlConnection con1 = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TestDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand cmd = new SqlCommand("SELECT * FROM TestTable", con1);
            con1.Open();
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            if(rd != null)
            {
                if (rd.Read())
                {
                    tb1.TestId = (int)rd["TestId"];
                    tb1.TestName = rd["TestName"].ToString();
                }
                else
                {
                    tb1 = null;
                }
            }
            con1.Close();
            return tb1;
        }
        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }
        public int Plussaa(int value1, int value2)
        {
            int value3 = value1 + value2;
            return value3;
        }
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
