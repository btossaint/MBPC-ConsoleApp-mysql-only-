using MBPC_ConsoleApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBPC_ConsoleApp.DAL
{
    public class MySQLDAL : iDAL
    {
        readonly string connectionString = "Server=localhost;Database=mbpc;User=<user>;Password=<pw>;";

        public Member ReadMember(int id)
        {
            return ReadMembers().Find(ls => ls.Id == id);
        }

        public List<Member> ReadMembers()
        {
            List<Member> Members;
            Members = new List<Member>();

            using (MySqlConnection connection = new MySqlConnection())
            {
                using (MySqlCommand command = new MySqlCommand())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "select id, lastname from member";

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var MemberDB = new Member(Int32.Parse(reader["id"].ToString()),
                                reader["lastname"].ToString());
                            Members.Add(MemberDB);
                        }
                    }
                }
            }
            return Members;
        }

        public List<Member> ReadMembersWithLot()
        {
            List<Member> Members;
            Members = new List<Member>();

            using (MySqlConnection connection = new MySqlConnection())
            {
                using (MySqlCommand command = new MySqlCommand())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "select distinct member.id, lastname from member, lot where vendorId = member.id order by lastname";

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var MemberDB = new Member(Int32.Parse(reader["id"].ToString()),
                                reader["lastname"].ToString());
                            Members.Add(MemberDB);
                        }
                    }
                }
            }
            return Members;
        }

        public List<Lot> ReadLotMember(string _id)
        {
            List<Lot> Lots;
            Lots = new List<Lot>();

            using (MySqlConnection connection = new MySqlConnection())
            {
                using (MySqlCommand command = new MySqlCommand())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "select id, memberReferenece, description from Lot where vendorId = @mid";
                    command.Parameters.AddWithValue("mid", _id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var LotDB = new Lot(Int32.Parse(reader["id"].ToString()),
                                reader["memberReferenece"].ToString(),
                                reader["description"].ToString());
                            Lots.Add(LotDB);
                        }
                    }
                }
            }
            return Lots;
        }

        public List<Lot> ReadLots()
        {
            List<Lot> Lots;
            Lots = new List<Lot>();

            using (MySqlConnection connection = new MySqlConnection())
            {
                using (MySqlCommand command = new MySqlCommand())
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "select id, memberReferenece, description from Lot";

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var LotDB = new Lot(Int32.Parse(reader["id"].ToString()),
                               reader["memberReferenece"].ToString(),
                               reader["description"].ToString());
                            Lots.Add(LotDB);
                        }
                    }
                }
            }
            return Lots;
        }

        public void CreateMember(Member member)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string sql = "INSERT INTO Member(firstName,lastName,address,city, zipcode, country, memberid) " +
                             "VALUES (@fname,@lname,@addr, @city, @zCode, @country, @memid)";
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@fname", member.Firstname);
                    command.Parameters.AddWithValue("@lname", member.Lastname);
                    command.Parameters.AddWithValue("@addr", member.Address);
                    command.Parameters.AddWithValue("@city", member.City);
                    command.Parameters.AddWithValue("@zCode", member.Zipcode);
                    command.Parameters.AddWithValue("@country", member.Country);
                    command.Parameters.AddWithValue("@memid", 0);
                    command.ExecuteNonQuery();

                    int addId = Convert.ToInt32(command.LastInsertedId);
                    member.Id = addId;
                }
            }
        }
    }
}
