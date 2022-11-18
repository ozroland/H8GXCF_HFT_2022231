using H8GXCF_HFT_2022231.Logic.Services;
using H8GXCF_HFT_2022231.Models;
using H8GXCF_HFT_2022231.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H8GXCF_HFT_2022231.Test
{
    [TestFixture]
    public class MemberLogicTester
    {
        MemberLogic memberLogic;
        Mock<IMemberRepository> mockMemberRepository;
        [SetUp]
        public void Init()
        { 
            var Members = new List<Member>()
            {
                new Member()
                {
                    Id = 1,
                    Name = "Roland",
                    Age = 19,
                    Gender = Gender.Male,

                },
                new Member()
                {
                    Id = 2,
                    Name = "Lili",
                    Age = 22,
                    Gender = Gender.Female,
                },
                new Member()
                {
                    Id = 3,
                    Name = "Pali",
                    Age = 19,
                    Gender = Gender.Male,
                },
            }.AsQueryable();

            mockMemberRepository = new Mock<IMemberRepository>();
            mockMemberRepository.Setup(r => r.ReadAll()).Returns(Members);

            memberLogic = new MemberLogic(mockMemberRepository.Object);
        }
        [Test]
        public void AVGAgeTest()
        {
            var result = memberLogic.AVGAge();
            Assert.That(result, Is.EqualTo(20));
        }
    }
}
