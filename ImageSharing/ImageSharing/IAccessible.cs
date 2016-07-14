using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSharing.Models.EntityInfo;

namespace ImageSharing
{
    interface IAccessible
    {
        T GetEntity<T>(int id);
        List<T> GetEntities<T>();
        void AddEntity<T>(T entity);
        void RemoveEntity<T>(T entity);
    }
}
