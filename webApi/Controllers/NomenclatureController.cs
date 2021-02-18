using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebCarsProject.Data;
using WebCarsProject.Services;

namespace WebCarsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class NomenclatureController<T> : ControllerBase
        where T : Nomenclature
    {
        protected INomenclatureService<T> service;

        public NomenclatureController(INomenclatureService<T> service)
        {
            this.service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<T> GetAll()
        {
            return service.GetAll();
        }

        [HttpGet("Select")]
        [AllowAnonymous]
        public IEnumerable<T> GetSelect([FromQuery]string textFilter, [FromQuery]int limit = 10, [FromQuery]int offset = 0)
        {
            return service.GetFiltered(textFilter, limit, offset);
        }


        [HttpGet("{id:int}")]
        public async Task<Nomenclature> GetById(int id)
        {
            return await service.GetByIdAsync(id);
        }

        [HttpPut("{id:int}")]
        public async Task<Nomenclature> Update(int id, T nomenclature)
        {
            return await service.UpdateAsync(id, nomenclature);
        }

        [HttpPost]
        public void Add(T nomenclature)
        {
            service.Add(nomenclature);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            service.Delete(id);
        }
    }
}
