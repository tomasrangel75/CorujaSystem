using CorujaSystem.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorujaSystem.Models
{
	
		public interface IModelFactory
		{
            RegisterViewModel Create(ApplicationUser AppUser);
			ApplicationUser Create(RegisterViewModel RegVm);

            ApplicationUser CreateEdt(EditViewModel EditVm);
            EditViewModel CreateEdt(ApplicationUser AppUser);
        
    }

}



