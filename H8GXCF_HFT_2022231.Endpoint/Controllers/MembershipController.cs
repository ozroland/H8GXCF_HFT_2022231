using H8GXCF_HFT_2022231.Logic.Interfaces;
using H8GXCF_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace H8GXCF_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MembershipController : ControllerBase
    {
        ILogic<Membership> logic;
        public MembershipController(ILogic<Membership> logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public IEnumerable<Membership> ReadAll()
        {
            return logic.ReadAll();
        }
        [HttpGet("{id}")]
        public Membership Read(int id)
        {
            return logic.Read(id);
        }
        [HttpPost]
        public void Create([FromBody] Membership value)
        {
            logic.Create(value);
        }
        [HttpPut]
        public void Update([FromBody] Membership value)
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
