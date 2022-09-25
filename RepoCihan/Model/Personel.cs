using System.ComponentModel.DataAnnotations;

namespace RepoCihan.Model
{
    //Repository Pattern öğreniyoruz
    public class Personel
    {
        public Guid Id { get; set; }            /* evrensel ID demek , Guid büyük bir sayı, bütün tabloda arayabiliriz.  */
        public string AdıveİkinciAdı { get; set; }
        public string Soyadı { get; set; }
        public string Eposta { get; set; }
        public string Telefon { get; set; }

    }
}

