using MBPC_ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBPC_ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowMembers();
            // onderstaand uitzondering. Is om type SQL Server op te vragen voor de frontend!
            Console.WriteLine($"Database: {DAL.DALSingleton.Instance.GetType().Name}");
            Member m = new Member("Bob", "Tossaint", "Adres1", "Heerlen", "6161FF", "Nederland");
            m.CreateMember(m);
        }

        private static void ShowMembers()
        {
            Member member = new Member();
            foreach (var m in member.GetMembersWithLot())
            {
                Console.WriteLine(m.Lastname);
            } 
        }
    }
}
