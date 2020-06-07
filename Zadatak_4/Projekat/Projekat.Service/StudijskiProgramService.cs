using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Projekat.Model;

namespace Projekat.Service
{
    public class StudijskiProgramService
    {
        public List<StudijskiProgram> studiji = new List<StudijskiProgram>();
        Projekat.Repository.StudijskiProgramRepository studijski_program_repository = new Projekat.Repository.StudijskiProgramRepository();
        public StudijskiProgramService() { }
        public List<StudijskiProgram> SelectStudijskiProgramService()
        {
            studiji = studijski_program_repository.SelectStudijskiProgramRepository();
            return studiji;
        }

        public void InsertStudijskiProgramService(StudijskiProgram studij1)
        {
            studijski_program_repository.InsertStudijskiProgramRepository(studij1);
        }

        public void UpdateStudijskiProgramService(StudijskiProgram studij1)
        {
            studijski_program_repository.UpdateStudijskiProgramRepository(studij1);
        }

        public void DeleteStudijskiProgramService(int id)
        {
            studijski_program_repository.DeleteStudijskiProgramRepository(id);
        }
    }
}
