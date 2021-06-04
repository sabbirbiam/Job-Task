using m2sys.Infrastructute.Services.Interface;
using m2sys.Infrastructute.UnitOfWorks.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace m2sys.Infrastructute.Services
{
    public class LeaveService: ILeaveService
    {
        private readonly IApiUnitOfWork _apiUnitOfWork;

        public LeaveService(IApiUnitOfWork apiOfWork)
        {
            _apiUnitOfWork = apiOfWork;
        }

  

        void ILeaveService.getAll()
        {
            //_apiUnitOfWork.LeaveRepository.
            throw new NotImplementedException();
        }
    }

  
}
