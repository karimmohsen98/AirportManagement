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
    public class ServicePlane : Service<Plane>, IServicePlane
    {

        //private IGenericRepository<Plane> genericRepository;
        private IUnitOfWork unitOfWork;

        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork) // appeler le constructeur de service generique
        {
            this.unitOfWork = unitOfWork;
        }

          public void Add(Plane plane)
          {
             unitOfWork.Repository<Plane>().Add(plane);
          }

          public IList<Plane> GetAll()
          {
              return unitOfWork.Repository<Plane>().GetAll().ToList();
          }

        public int GetFlightNbre(Plane plane)
        {
            //return plane.Flights.Count(); //1st method
            return GetById(plane.PlaneId).Flights.Count(); //scnd method
                       
        }

        public void Remove(Plane plane)
          {
              unitOfWork.Repository<Plane>().Delete(plane);
          }
      }
    }

