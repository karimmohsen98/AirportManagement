using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interface;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Service
{
    public class ServicePassenger: Service<Passenger>,IServicePassenger
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServicePassenger(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._unitOfWork = unitOfWork;

        }
        public void Add(Passenger passenger)
        {
            _unitOfWork.Repository<Passenger>().Add(passenger);
        }

        public IList<Passenger> GetAll()
        {
            return _unitOfWork.Repository<Passenger>().GetAll().ToList();
        }

        public void Remove(Passenger passenger)
        {
            _unitOfWork.Repository<Passenger>().Delete(passenger);
        }
    }
}

