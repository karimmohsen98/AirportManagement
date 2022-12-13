using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interface
{
    public interface IServicePlane : IService<Plane>
    {
        //public void Add(Plane plane);
        //public void Remove(Plane plane);
        // public IList<Plane> GetAll();
        public int GetFlightNbre(Plane plane);



    }
}
