﻿using H8GXCF_HFT_2022231.Models;
using H8GXCF_HFT_2022231.Repository.Data;
using H8GXCF_HFT_2022231.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H8GXCF_HFT_2022231.Repository.Repositories
{
    public class InstructorRepository : Repository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(GymRegisterDbContext ctx) : base(ctx)
        {
        }
    }
}