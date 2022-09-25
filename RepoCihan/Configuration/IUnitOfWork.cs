using RepoCihan.Services;

namespace RepoCihan.Configuration
{
    public interface IUnitOfWork
    {
        IPersonelRepository Personel { get; }    // özellik get ,set var
        // Personelin sadece isimleri , içi boş , nasıllar yok atamalar yok
        Task CompleteAsync();                    // method parantezler var
        // hepsini birden güncelliyor
        // blockchain mantığı , eğer bir hata olursa bir tanesinde , rolback işlemleri hemen geri alıyor.

        void Dispose();                          // method parantezler var
        // anlık ramde kullanılmayan özellikleri siler
    }
}
