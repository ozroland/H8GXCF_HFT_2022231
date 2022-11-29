using H8GXCF_HFT_2022231.Logic.Interfaces;
using H8GXCF_HFT_2022231.Models;
using H8GXCF_HFT_2022231.Repository.Interfaces;
using H8GXCF_HFT_2022231.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H8GXCF_HFT_2022231.Logic.Services
{
    public class InstructorLogic : IInstructorLogic
    {
        IRepository<Instructor> instroctorRepository;
        public InstructorLogic(IRepository<Instructor> instroctorRepository)
        {
            this.instroctorRepository = instroctorRepository;
        }
        public void Create(Instructor item)
        {
            if (item.Name.Length < 3)
            {
                throw new ArgumentException("Instrctor name was too short...");
            }
            instroctorRepository.Create(item);
        }
        public void Delete(int id)
        {
            var instructor = instroctorRepository.Read(id);
            if (instructor == null)
            {
                throw new ArgumentException("Instructor does not exists...");
            }
            instroctorRepository.Delete(id);
        }

        public Instructor Read(int id)
        {
            var instructor = instroctorRepository.Read(id);
            if (instructor == null)
            {
                throw new ArgumentException("Instructor does not exists...");
            }
            return instroctorRepository.Read(id);
        }
        public IQueryable<Instructor> ReadAll()
        {
            return instroctorRepository.ReadAll();
        }
        public void Update(Instructor item)
        {
            if (item == null)
            {
                throw new ArgumentException("Instructor does not exists...");
            }
            instroctorRepository.Update(item);
        }
    }
}