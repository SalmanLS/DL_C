using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL_SS2_C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program pr = new Program(); 
            while (true)
            {
                try
                {
                    Console.WriteLine("Koneksi ke Database \n");
                    Console.WriteLine("Masukkan User ID: ");
                    string user = Console.ReadLine();
                    Console.WriteLine("Masukkan Password: ");
                    string pass = Console.ReadLine();
                    Console.WriteLine("Masukkan Database Tujuan: ");
                    string db = Console.ReadLine();
                    Console.Write("Ketik Y untuk koneksi ke Database!");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case 'Y':
                            {
                                SqlConnection konek = null;
                                string strkonek = "Data source = LUTHFI\\MCH35; " +
                                    "initial catalog = {0};"+
                                    "User ID = {1}; Password = {2}";
                                konek = new SqlConnection(string.Format(strkonek, db, user, pass));
                                konek.Open();
                                Console.Clear();
                            }
                            break;
                    }
                }
            }
        }
    }
}
