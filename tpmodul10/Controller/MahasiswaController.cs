using Microsoft.AspNetCore.Mvc;
using tpmodul10.Model;


namespace tpmodul10.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>
        {
            new Mahasiswa {Nama = "M. Hafizh Al Kautsar", NIM = "103022300069"},
            new Mahasiswa {Nama = "Bintang Anugrah Pratama", NIM = "103022300058"},
            new Mahasiswa {Nama = "Albert Febrian", NIM = "103022300003"},
            new Mahasiswa {Nama = "Hizkia Nicander Budiyanto", NIM = "103022300127"},
            new Mahasiswa {Nama = "Syarif", NIM = "103022300094"},
        };

        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetMahasiswa()
        {
            return Ok(daftarMahasiswa);
        }

        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetMahasiswaByIndex(int index)
        {
            if(index < 0 || index >= daftarMahasiswa.Count)
            {
                return NotFound("Mahasiswa tidak ditemukan");
            }
            return Ok(daftarMahasiswa[index]);
        }

        [HttpPost]
        public ActionResult<Mahasiswa> PostMahasiswa(Mahasiswa mahasiswa)
        {
            daftarMahasiswa.Add(mahasiswa);
            return CreatedAtAction(nameof(GetMahasiswaByIndex), new { index = daftarMahasiswa.Count - 1 }, mahasiswa);
        }

        [HttpDelete]
        public IActionResult DeleteMahasiswa(int index)
        {
            if (index < 0 || index >= daftarMahasiswa.Count)
            {
                return NotFound("Mahasiswa tidak ditemukan untuk dihapus");
            }

            daftarMahasiswa.RemoveAt(index);
            return NoContent();
        }
    }
}

