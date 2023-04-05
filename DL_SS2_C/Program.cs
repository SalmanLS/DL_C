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
                                while (true)
                                {
                                    try
                                    {
                                        Console.WriteLine("===MENU===");
                                        Console.WriteLine("1. Melihat Seluruh Data");
                                        Console.WriteLine("2. Tambah Data");
                                        Console.WriteLine("3. Hapus Data");
                                        Console.WriteLine("4. Update Data");
                                        Console.WriteLine("5. Cari Data");
                                        Console.WriteLine("6. Keluar");
                                        Console.Write("\n Enter your choice (1-6)");
                                        char chs = Convert.ToChar(Console.ReadLine());
                                        switch (chs)
                                        {
                                            case '1':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Data Tamu \n");
                                                    Console.WriteLine();
                                                    pr.baca(konek);
                                                    konek.Close();
                                                }
                                                break;
                                            case '2':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Input Data Tamu \n");
                                                    Console.WriteLine("Masukkan ID Tamu :");
                                                    string id_tamu = Console.ReadLine();
                                                    Console.WriteLine("Masukkan nama Tamu :");
                                                    string namat = Console.ReadLine();
                                                    Console.WriteLine("Masukkan No.Telfon :");
                                                    string no_tlfon = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Alamat(Jalan) :");
                                                    string jalanA = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Alamaat(Kabupaten) :");
                                                    string kabupA = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Alamat(Provinsi) :");
                                                    string provinsiA = Console.ReadLine();
                                                    Console.WriteLine("Masukkan Jenis Kelamin :");
                                                    char jenisk = Convert.ToChar(Console.ReadLine()); 
                                               
                                                }
                                                break;
                                        }

                                    }
                                }
                            }
                            break;
                    }
                }
            }
        }
    }
}
