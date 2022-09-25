using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoCihan.Configuration;
using RepoCihan.Model;

namespace RepoCihan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonelController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Personel> personeller = await _unitOfWork.Personel.GetirHepsi();
            return Ok(personeller);    /* Ok Jsondan geliyor Json okeyi */
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonel(Guid id)
        {
            IEnumerable<Personel> personeller = await _unitOfWork.Personel.GetirHepsi();
            return Ok(personeller);
        }


        [HttpPost]
        public async Task<IActionResult> CreatePersonel(Personel personel)
        {
            if (ModelState.IsValid)
            {
                personel.Id = Guid.NewGuid();

                await _unitOfWork.Personel.Ekle(personel);
                await _unitOfWork.CompleteAsync();

                return CreatedAtAction("GetEmployee", new { personel.Id }, personel);
            }
            return new JsonResult("Hata Oluştu") { StatusCode = 500 };   // modele uygun değilse hata döndür.

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonel(Guid id)
        {
            Personel personel = await _unitOfWork.Personel.GetirById(id);

            if (personel == null)
                return BadRequest();

            await _unitOfWork.Personel.Sil(id);
            await _unitOfWork.CompleteAsync();

            return Ok(personel);
        }

    }
}
