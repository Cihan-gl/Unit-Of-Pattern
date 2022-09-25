using Microsoft.EntityFrameworkCore;
using RepoCihan.Data;
using System.Linq.Expressions;

namespace RepoCihan.Services
{
    // controller =  son teknoloji , ama büyük maliyetli 
    // repo =  eski yöntem 


    // classların içerisnde o class'ın içinde aynı isimde bir method bulunur. 
    // Bu methoda yapıcı method denir =  Constructor
    // Bu methodun içinde başlangıç atamaları yapılır.

    // amacı bunları nasıl yapıyor
    public class GenericRepository<T> : IGenericRepository<T> where T : class    // sadece classa miras versin
    {
        // DI harddiske giriyo kopyalıyo çıkıyor, kuyruk olmasın diye
        // örneğin bir classı ya da  varlığın özelliklerini kendime ait bir yere atıp, yoluna devam eder

        protected readonly RepoCihanDBContext _context;  // bana açılan bölge ramdeki context        // APIDBContext
        protected readonly DbSet<T> _dbSet;
        protected readonly ILogger _logger;
      

        public GenericRepository(RepoCihanDBContext context, ILogger logger)
        // harddiskte context
        {
            _context = context;  /* context  database*/
            // ramde açılan bana ait context = harddiskteki db context 

            _dbSet = context.Set<T>();  // o entitya denk, veri tabanındaki tablo

           _logger = logger;

            // harddiskteki context'in ömrü 16 dan 28 arası
        }


        public virtual async Task<bool> Ekle(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<T> GetirById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetirFiltreli(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetirHepsi()
        {
           return await _dbSet.ToListAsync();
        }

        public virtual async Task<bool> Güncelle(T entity)
        {
            _dbSet.Update(entity);
            return true;
        }

        public virtual async Task<bool> Sil(Guid id)
        {
            _dbSet.Remove(await _dbSet.FindAsync(id));
            return true;
        }


    }
}
