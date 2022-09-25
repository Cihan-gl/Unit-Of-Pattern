using Microsoft.EntityFrameworkCore;
using RepoCihan.Data;
using RepoCihan.Model;

namespace RepoCihan.Services
{
    // bir class birden çok class'dan miras alamaz.
    // 2 class'tan miras gelmez
    // 1 class +  1 interfaceden miras gelir.




    // GenericRepository<Personel>  personelin genel methodları nasıl yapılıyor
    // IPersonelRepository          genel yetenekler ve bize ait olan yeteneklerin isimleri
    public class PersonelRepository : GenericRepository<Personel>, IPersonelRepository
    {

        //kendimize ait yetenekleri yapıyoruz

        public PersonelRepository(RepoCihanDBContext context, ILogger logger) : base(context, logger)  /*:base atadan alınanı kullanacağız */                                                                         //context = context filan asağıda yapmamıza gerek
        {                                                                        //context = context filan asağıda yapmamıza gerek 
            // DI
        }


        public override async Task<IEnumerable<Personel>> GetirHepsi()
        {

            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"{Repo} Hatalar :",typeof(PersonelRepository));
                return new List<Personel>();
            }


        }

        public async Task<int> KaçPersonelVar()
        {
            try
            {
                return await _dbSet.CountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Hatalar :",typeof(PersonelRepository));
                return 0;

            }
        }

      
    }
}
