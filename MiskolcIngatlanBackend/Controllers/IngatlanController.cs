using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MiskolcIngatlanBackend.Models;

namespace MiskolcIngatlanBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngatlanController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            using (var context = new MiskolcingatlanContext())
            {
                try
                {
                    List<Ingatlan> result = context.Ingatlans.ToList();
                    return Ok(result);
                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            using (var context = new MiskolcingatlanContext())
            {
                try
                {
                    Ingatlan torlendo = new Ingatlan()
                    {
                        Id = id
                    };
                    context.Ingatlans.Remove(torlendo);
                    context.SaveChanges();
                    return Ok("Sikeres törlés.");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                    throw;
                }
            }
        }

        [HttpPost]
        public IActionResult Post(Ingatlan ujIngatlan)
        {
            using (var context = new MiskolcingatlanContext())
            {
                try
                {
                    context.Ingatlans.Add(ujIngatlan);
                    context.SaveChanges();
                    return Ok("Sikeres mentés.");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut]
        public IActionResult Put(Ingatlan modositottIngatlan)
        {
            using (var context = new MiskolcingatlanContext())
            {
                try
                {
                    if (context.Ingatlans.Contains(modositottIngatlan))
                    {
                        context.Ingatlans.Update(modositottIngatlan);
                        context.SaveChanges();
                        return Ok("Sikeres módosítás.");
                    }
                    else
                    {
                        return NotFound("Nincs ilyen ingatlan.");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

    }
}
