using RepoCihan.Data;
using RepoCihan.Services;

namespace RepoCihan.Configuration
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly RepoCihanDBContext _context;
        private readonly ILogger _logger;

        public IPersonelRepository Personel { get; private set; }   // ramde kendime personel açtık

        public UnitOfWork(RepoCihanDBContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");  

            Personel = new PersonelRepository(context, _logger);   // polymorfizm 
            // Personel = parent
            // PersonelRepository'e döndürüyoruz tipini
            // (context, _logger) bir  daha veriyoruz. çünkü ramde çalıştık harddiskte çalışmadık , ramde ömrü bitince içi boşaldı. 


            // Bir parent , childlarada bürünebiliyor. Interface oldugu için
            // Bu personelle ilgili her şeyi biliyor ve DI'lar açık
        }

        public async Task CompleteAsync()
        {
           await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            // memorideki çöp olanları temizliyor
        }
    }
}
