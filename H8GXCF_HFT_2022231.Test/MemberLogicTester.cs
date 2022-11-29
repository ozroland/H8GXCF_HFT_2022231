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
        InstructorLogic instructorLogic;
        MembershipLogic membershipLogic;
        Mock<IRepository<Member>> mockMemberRepository;
        Mock<IRepository<Instructor>> mockInstructorRepository;
        Mock<IRepository<Membership>> mockMembershipRepository;
        [SetUp]
        public void Init()
        {
            var pali = new Instructor()
            {
                Id = 1,
                Name = "Egyed Pál",
                Contact = "+36202634163",
                Address = "1034 Budapest Bécsi út 104-108",
                Email = "egyed.pal@gmail.com",
            };
            var peti = new Instructor()
            {
                Id = 2,
                Name = "Slezák Péter",
                Contact = "+36702321083",
                Address = "1034 Budapest Bécsi út 10",
                Email = "slezak.peter@gmail.com",
            };
            var robi = new Instructor()
            {
                Id = 3,
                Name = "Takács Róbert",
                Contact = "+36303210019",
                Address = "1034 Budapest Bécsi út 10",
                Email = "slezak.peter@gmail.com",
            };

            var roland = new Member()
            {
                Id = 1,
                Name = "Őz Roland",
                Contact = "+36806348231",
                Address = "1034 Budapest Bécsi út 104-108",
                Email = "oz.roland@gmail.com",
                Age = 20,
                Gender = Gender.Male,
            };
            var lipak = new Member()
            {
                Id = 2,
                Name = "Lipák Balázs",
                Contact = "+36901334513",
                Address = "1034 Budapest Görgely Artúr út 98",
                Email = "lipak.balazs@gmail.com",
                Age = 19,
                Gender = Gender.Male,
            };

            var diak = new Membership()
            {
                Id = 1,
                Name = "Diák",
                Active = true,
                JoiningDate = DateTime.Parse("2022.07.20"),
                SignupFee = 15000,
            };
            var teljes = new Membership()
            {
                Id = 2,
                Name = "Teljes",
                Active = false,
                JoiningDate = DateTime.Parse("2021.05.08"),
                EndingDate = DateTime.Parse("2022.09.17"),
                SignupFee = 20000,
            };

            var instructors = new List<Instructor>() {pali,peti,robi }.AsQueryable();
            var members = new List<Member>() { roland,lipak }.AsQueryable();
            var memberships = new List<Membership>() {diak, teljes }.AsQueryable();

            roland.Membership = diak;
            roland.MembershipID = diak.Id;
            roland.Instructor = pali;
            roland.InstructorID = pali.Id;
            lipak.Instructor = pali;
            lipak.InstructorID = pali.Id;
            lipak.Membership = teljes;
            lipak.MembershipID = teljes.Id;
            
            mockInstructorRepository = new Mock<IRepository<Instructor>>();
            mockInstructorRepository.Setup(r => r.ReadAll()).Returns(instructors);

            mockMemberRepository = new Mock<IRepository<Member>>();
            mockMemberRepository.Setup(r => r.ReadAll()).Returns(members);

            mockMembershipRepository = new Mock<IRepository<Membership>>();
            mockMembershipRepository.Setup(r => r.ReadAll()).Returns(memberships);

            instructorLogic = new InstructorLogic(mockInstructorRepository.Object);
            memberLogic = new MemberLogic(mockMemberRepository.Object);
            membershipLogic = new MembershipLogic(mockMembershipRepository.Object);
        }
        [Test]
        public void MaleFemaleCount()
        {
            var result = memberLogic.MaleFemaleCount();
            var expected = new Dictionary<string, int>(){
                {"Male", 2},
            };
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void InstructorClientCount()
        {
            var result = memberLogic.InstructorClientCount();
            var expected = new Dictionary<string, int>(){
                {"Egyed Pál", 2},
            };
            Assert.That(result, Is.EqualTo(expected));
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
        [Test]
        public void AverageFeeByGender()
        {
            var result = memberLogic.AverageFeeByGender();
            var expected = new Dictionary<string, double>(){
                {"Male", 17500.0},
            };
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void ActiveMembersAverageAgeAndCount()
        {
            var result = memberLogic.ActiveMembersAverageAgeAndCount();
            var expected = new Dictionary<int, double>(){
                {1, 20.0},
            };
            Assert.That(result, Is.EqualTo(expected));
        }
        [Test]
        public void CreateCorrectMember()
        {
            var member = new Member() { Name = "Pintér Olivér" };
            memberLogic.Create(member);
            mockMemberRepository.Verify(r => r.Create(member), Times.Once);
        }
        [Test]
        public void CreateWrongMember()
        {
            var member = new Member() { Name = "AS" };
            try
            {
                memberLogic.Create(member);
            }
            catch
            {

            }
            mockMemberRepository.Verify(r => r.Create(member), Times.Never);
        }
        [Test]
        public void CreateCorrectInstructor()
        {
            var instuctor = new Instructor() { Name = "Endrei József" };
            instructorLogic.Create(instuctor);
            mockInstructorRepository.Verify(r => r.Create(instuctor), Times.Once);
        }
        [Test]
        public void AverageMemberAge()
        {
            var result = memberLogic.AverageMemberAge();
            Assert.That(result, Is.EqualTo(19.5));
        }
        [Test]
        public void MemberCount()
        {
            var result = memberLogic.MemberCount();
            Assert.That(result, Is.EqualTo(2));
        }
    }
}