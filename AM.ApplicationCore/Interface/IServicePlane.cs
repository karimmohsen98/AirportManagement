using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interface
{
    public interface IServicePlane
    {
        public void Add(Plane plane);
        public void Remove(Plane plane);
        public IList<Plane> GetAll();

    }
}
