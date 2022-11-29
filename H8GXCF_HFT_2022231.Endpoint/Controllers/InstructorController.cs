using H8GXCF_HFT_2022231.Logic.Interfaces;
using H8GXCF_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace H8GXCF_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        IInstructorLogic logic;
        public InstructorController(IInstructorLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public IEnumerable<Instructor> ReadAll()
        {
            return logic.ReadAll();
        }
        [HttpGet("{id}")]
        public Instructor Read(int id)
        {
            return logic.Read(id);
        }
        [HttpPost]
        public void Create([FromBody] Instructor value)
        {
            logic.Create(value);
        }
        [HttpPut]
        public void Update([FromBody] Instructor value)
        {
            logic.Update(value);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
