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
                                                    try
                                                    {
                                                        pr.insert(id_tamu, namat, no_tlfon, jalanA, kabupA, provinsiA, jenisk, konek);
                                                        konek.Close();
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("\n Anda tidak memiliki " + "akses untuk menambah data");
                                                    }
                                                }
                                                break;
                                            case '3':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Hapus Data Tamu \n");
                                                    Console.WriteLine("Masukkan ID Tamu :");
                                                    string id_tamu = Console.ReadLine();
                                                    try
                                                    {
                                                        pr.delete(id_tamu, konek);
                                                        konek.Close();
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("\n Anda tidak memiliki " + "akses untuk menambah data");
                                                    }
                                                }
                                                break;
                                            case '4':
                                                {

                                                }
                                                break;
                                            case '5':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Cari Data Tamu \n");
                                                    Console.WriteLine("Masukkan ID Tamu :");
                                                    string id_tamu = Console.ReadLine();
                                                    try
                                                    {
                                                        pr.cari(id_tamu, konek);
                                                        konek.Close();
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("\n Anda tidak memiliki " + "akses untuk menambah data");
                                                    }
                                                }
                                                break;
                                            case '6':
                                                {
                                                    konek.Close();
                                                    return;
                                                }
                                            default:
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("\n Invalid Option");
                                                }
                                                break;
                       
                                        }

                                    }
                                    catch
                                    {
                                        Console.WriteLine("\n Check the value entered! ");
                                    }
                                }
                            }
                        default:
                            {
                                Console.WriteLine("\n Invalid Option");
                            }
                            break;
                        
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Tidak Dapat mengakses database menggunakan user tersebut \n");
                    Console.ResetColor();
                }
            }
        }
        public void baca(SqlConnection conek)
        {
            SqlCommand cmd = new SqlCommand("Select*From dbo.Tamu", conek);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                for(int i = 0; i < rdr.FieldCount; i++)
                {
                    Console.WriteLine(rdr.GetValue(i));
                }
                Console.WriteLine();
            }
        }
        public void insert(string idT,string nmT, string noT, string jlT, string kabT, string provT, char jkT,SqlConnection conek)
        {
            string str = "";
            str = "insert into dbo.Tamu (id_tamu, nama_tamu, no_tlfon, jalan_t, kabupaten_t, provinsi_t, jenisK)" + "values(@id_tamu, @namat, @ no_tlfon, @jalanA, @kabupA, @provinsiA, @jenisk)";
            SqlCommand cmd = new SqlCommand(str, conek);
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("id_tamu", idT));
            cmd.Parameters.Add(new SqlParameter("namat", nmT));
            cmd.Parameters.Add(new SqlParameter("no_tlfon", noT));
            cmd.Parameters.Add(new SqlParameter("jalanA", jlT));
            cmd.Parameters.Add(new SqlParameter("kabupA", kabT));
            cmd.Parameters.Add(new SqlParameter("provinsiA", provT));
            cmd.Parameters.Add(new SqlParameter("jenisk", jkT));
            cmd.ExecuteNonQuery();

            Console.WriteLine("Data berhasil ditambahkan");
        }
        public void delete(string idT, SqlConnection conek)
        {
            string st = "";
            st = "delete from dbo.Tamu where id_tamu " + " = " + idT + "";
            SqlCommand cmd = new SqlCommand(st, conek);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data sudah dihapus");

        }

    }
}
