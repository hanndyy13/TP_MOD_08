using System.Xml.Serialization;
using tpmodul8_103022300064;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = CovidConfig.LoadConfig();

        config.ubahSatuan();

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}: ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam: ");
        int hariDemam = Convert.ToInt32(Console.ReadLine());

        bool suhuValid = false;

        if (config.satuan_suhu.ToLower() == "celcius")
        {
            if (suhu >= 36.5 && suhu <= 37.5)
            {
                suhuValid = true;
            }
        }
        else if (config.satuan_suhu.ToLower() == "fahrenheit")
        {
            if (suhu >= 97.7 && suhu <= 99.5)
            {
                suhuValid = true;
            }
        }
        else
        {
            Console.WriteLine("Satuan suhu tidak valid");
        }

        if (suhuValid)
        {
            if (hariDemam <= config.batas_hari_demam && hariDemam > 0)
            {
                Console.WriteLine(config.pesan_diterima);
            }
            else
            {
                Console.WriteLine(config.pesan_ditolak);
            }
        }
        else
        {
            Console.WriteLine("Suhu tubuh Anda di luar batas normal.");
        }

        Console.WriteLine("\nTekan sembarang tombol untuk keluar...");
        Console.ReadKey();
    }
}
