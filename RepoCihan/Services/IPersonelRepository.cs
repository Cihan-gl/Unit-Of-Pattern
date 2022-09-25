using RepoCihan.Model;

namespace RepoCihan.Services
{
    // bu kısmı yazılımcı yapıyor yönetici değil
    public interface IPersonelRepository : IGenericRepository<Personel>
    {
        // hem atadan gelenler hem bana ait olanlar
        Task<int> KaçPersonelVar();
       

    }
}
