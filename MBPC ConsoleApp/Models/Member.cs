using MBPC_ConsoleApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBPC_ConsoleApp.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public Member MemberId { get; set; } // Hans wat is dit in relatie tot het hier benoemde Id?
        public string Email { get; set; }
        public DateTime Birdthdate { get; set; }
        public DateTime Memberdate { get; set; }

        public Member()
        {

        }
        public Member(int _id, string _lastname)
        {
            Id = _id;
            Lastname = _lastname;
        }

        public Member(string _firstname, string _lastname, string _address, string _city, string _zipcode, string _country)
        {
            Firstname = _firstname;
            Lastname = _lastname;
            Address = _address;
            City = _city;
            Zipcode = _zipcode;
            Country = _country;
        }

        public List<Member> GetMembers()
        {
            iDAL sQLDal = DALSingleton.GetInstance();
            return sQLDal.ReadMembers();
        }

        public List<Member> GetMembersWithLot()
        {
            iDAL sQLDal = DALSingleton.GetInstance();
            return sQLDal.ReadMembersWithLot();
        }

        public int GetMemeberId(Member m)
        {
            return m.Id;
        }

        public void CreateMember(Member m)
        {
            iDAL sQLDal = DALSingleton.GetInstance();
            sQLDal.CreateMember(m);
        }
    }
}
