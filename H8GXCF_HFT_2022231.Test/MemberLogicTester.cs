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
            Gym fakeGym = new Gym()
            {
                Id = 1,
                Name = "Arnold",
                Location = "Budapest"
            };
            Membership membership = new Membership()
            {
                Id=1,
                Name = "Diák",
                Category = Category.Student,
                HowLong = 13
            };
            var Members = new List<Member>()
            {
                new Member()
                {
                    Id = 1,
                    Name = "Roland",
                    Age = 19,
                    Sex = Sex.Male,
                    Gym = fakeGym,
                    MembershipID = membership.Id
                },
                new Member()
                {
                    Id = 2,
                    Name = "Lili",
                    Age = 22,
                    Sex = Sex.Female,
                    Gym = fakeGym,
                }
            }.AsQueryable();

            mockMemberRepository = new Mock<IMemberRepository>();
            mockMemberRepository.Setup(r => r.ReadAll()).Returns(Members);

            memberLogic = new MemberLogic(mockMemberRepository.Object);
        }
        [Test]
        public void CountMan()
        {
            var result = memberLogic.CountMan();

            Assert.That(result, Is.EqualTo(1));
        }
    }
}
