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
            Instructor pali = new Instructor()
            {
                Id = 1,
                Name = "Egyed Pál",
                Contact = "+36702652863",
                Address = "1034 Budapest Bécsi út 104-108",
                Email = "egyed.pali@gmail.com",
            };
            var Members = new List<Member>()
            {
                new Member(){
                Id = 1,
                Name = "Őz Roland",
                Contact = "+36306018905",
                Address = "1034 Budapest Bécsi út 104-108",
                Email = "ozroland46@gmail.com",
                Age = 20,
                Gender = Gender.Male,
                Membership = new Membership()
                {
                    Id = 1,
                    Name = "Diák",
                    Active = true,
                    JoiningDate = DateTime.Parse("2022.07.20"),
                    SignupFee = 15000,
                },
                MembershipID = 1,
                Instructor = pali,
                InstructorID = pali.Id,
                },
                new Member(){
                Id = 2,
                Name = "Lipák Balázs",
                Contact = "+36501345139",
                Address = "1034 Budapest Görgely Artúr út 98",
                Email = "lipak.bazsi@gmail.com",
                Age = 20,
                Gender = Gender.Male,
                Membership = new Membership()
                {
                    Id = 2,
                    Name = "Teljes",
                    Active = false,
                    JoiningDate = DateTime.Parse("2021.05.08"),
                    EndingDate = DateTime.Parse("2022.09.17"),
                    SignupFee = 20000,
                },
                MembershipID = 2,
                Instructor = pali,
                InstructorID = pali.Id,
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
        [Test]
        public void ActiveMembers()
        {
            var result = memberLogic.ActiveMembers();
            Assert.That(result, Is.EqualTo(new List<string>() {"Őz Roland"}));
        }
        [Test]
        public void MemberTypeCount()
        {
            var result = memberLogic.MemberTypeCount();
            var expected = new Dictionary<string, int>(){
                {"Teljes", 1},
                {"Diák", 1 },
            };
            Assert.That(result, Is.EqualTo(expected));
            
        }
    }
}
