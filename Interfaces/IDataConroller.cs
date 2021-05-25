using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsReviewsAngular.Interfaces
{
    public interface IDataConroller
    {
        public IEnumerable<IData> GetAll();
        public IData Get(int id);
        public IActionResult Post(IData data);
        public IActionResult Put(IData data);
        public IActionResult Delete(int id);
    }
}
