using System;
using System.Collections.Generic;
using System.Text;
using Projekat.Model;

namespace Projekat.Service.Common
{
    public interface IStudijskiProgramService
    {
        void SelectStudijskiProgramService();

        void InsertStudijskiProgramService(StudijskiProgram studij1);

        void UpdateStudijskiProgramService(StudijskiProgram studij1);

        void DeleteStudijskiProgramService(int id);
        
    }
}
