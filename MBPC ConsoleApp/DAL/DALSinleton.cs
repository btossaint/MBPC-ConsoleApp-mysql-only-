using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBPC_ConsoleApp.DAL
{
    
    /// <summary>
    /// Singleton class for the DAL
    /// More info: https://en.wikipedia.org/wiki/Singleton_pattern
    /// </summary>
    public sealed class DALSingleton
    {
        private static iDAL instance = null;
        private static readonly object padlock = new object();

        // for a display of the databasename on the frontend.
        public static iDAL Instance { get => instance; }

        private DALSingleton()
        {
        }

        public static iDAL GetInstance()
        {
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new MySQLDAL();
                    }
                    return instance;
                }
            }
        }
    }
}
