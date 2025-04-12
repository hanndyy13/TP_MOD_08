using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace tpmodul8_103022300064
{
    public class CovidConfig
    {
        public string? satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public string? pesan_ditolak { get; set; }
        public string? pesan_diterima { get; set; }

        public const string fileConfig = "D:\\My Code\\GUI C#\\tpmodul8_103022300064\\tpmodul8_103022300064\\covid_config.json";

        public static CovidConfig LoadConfig()
        {
            if (File.Exists(fileConfig))
            {
                string jsonString = File.ReadAllText(fileConfig);
                CovidConfig? config = JsonSerializer.Deserialize<CovidConfig>(jsonString);

                if (config != null)
                    return config;
            }

            CovidConfig defaultConfig = new CovidConfig
            {
                satuan_suhu = "celcius",
                batas_hari_demam = 14,
                pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini"
            };

            string defaultJson = JsonSerializer.Serialize(defaultConfig, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileConfig, defaultJson);

            return defaultConfig;
        }

        public void ubahSatuan()
        {
            if (satuan_suhu != null && satuan_suhu.ToLower() == "celcius")
            {
                satuan_suhu = "fahrenheit";
            }
            else
            {
                satuan_suhu = "celcius";
            }

            string updatedJson = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileConfig, updatedJson);
        }
    }
}
