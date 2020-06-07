using System;
using System.Collections.Generic;
using System.Text;
using Projekat.Model;

namespace Projekat.Repository.Common
{
    public interface IStudijskiProgramRepository
    {
        List<StudijskiProgram> SelectStudijskiProgramRepository();

        void InsertStudijskiProgramRepository(StudijskiProgram studijski_program1);

        void UpdateStudijskiProgramRepository(StudijskiProgram studijski_program1);

        void DeleteStudijskiProgramRepository(int id);
    }
}
