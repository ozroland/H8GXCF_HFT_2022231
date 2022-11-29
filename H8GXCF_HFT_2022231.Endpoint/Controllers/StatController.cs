using H8GXCF_HFT_2022231.Logic.Interfaces;
using H8GXCF_HFT_2022231.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using H8GXCF_HFT_2022231.Logic;

namespace H8GXCF_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IMemberLogic logic;

        public StatController(IMemberLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public Dictionary<string, int> MaleFemaleCount()
        {
            return logic.MaleFemaleCount();
        }
        [HttpGet]
        public Dictionary<string, int> InstructorClientCount()
        {
            return logic.InstructorClientCount();
        }
        [HttpGet]
        public Dictionary<string, int> MemberTypeCount()
        {
            return logic.MemberTypeCount();
        }
        [HttpGet]
        public Dictionary<string, double> AverageFeeByGender()
        {
            return logic.AverageFeeByGender();
        }
        [HttpGet]
        public Dictionary<int, double> ActiveMembersAverageAgeAndCount()
        {
            return logic.ActiveMembersAverageAgeAndCount();
        }
    }
}
