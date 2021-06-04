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
        private readonly ILeaveService _leaveService;

        public LeaveService(IApiUnitOfWork apiOfWork, ILeaveService leaveService)
        {
            _apiUnitOfWork = apiOfWork;
            _leaveService = leaveService;
        }

  

        void ILeaveService.getAll()
        {
            //_apiUnitOfWork.LeaveRepository.
            throw new NotImplementedException();
        }
    }

  
}
