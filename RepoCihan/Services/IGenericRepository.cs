using System.Linq.Expressions;

namespace RepoCihan.Services
{
    // interfacelerin bir amacı var isim stabilizitesi
    // içi boş, tek başına hiçbir anlamı olmaz 
    // newlenmez

     // <> diamond operatörü, T entity
    public interface IGenericRepository<T> where T : class
    {
        //bu interfaceden miras alacak varlıklar bir class olmalı
        //evrensel bir interface yapıyoruz   


        // Task olmazsa bu işlemi hemen yapmaya çalışır , sıra oluşturur.
        // Async önünü açıyor. İşlemcinin çekirdeklerinin önünü geçir.


        // yetenek öğretiyoruz
        // bunlar methodlardır

        // Projede ortak olan methodlardır.

        Task<IEnumerable<T>> GetirHepsi();        /* Bütün hepsini verir. IEnumerable tek taraflı Listen farkı güvenlik açığı olmasın diye */
        Task<T> GetirById(Guid id);
        Task<bool> Ekle(T entity);
        Task<bool> Sil(Guid id);
        Task<bool> Güncelle(T entity);
        Task<IEnumerable<T>> GetirFiltreli(Expression<Func<T, bool>> predicate);

        // GetirFiltreli içeride önceden bir parametre alamaz 
        // predicate = önceden tahmin edilemez
        // Expression = < > , contains, not contains gibi 
        // çok geniş kapsamlı





    }
}
