using H8GXCF_HFT_2022231.Logic.Interfaces;
using H8GXCF_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace H8GXCF_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        IMemberLogic logic;
        public MemberController(IMemberLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public IEnumerable<Member> ReadAll()
        {
            return logic.ReadAll();
        }
        [HttpGet("{id}")]
        public Member Read(int id)
        {
            return logic.Read(id);
        }
        [HttpPost]
        public void Create([FromBody] Member value)
        {
            logic.Create(value);
        }
        [HttpPut]
        public void Update([FromBody] Member value)
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
