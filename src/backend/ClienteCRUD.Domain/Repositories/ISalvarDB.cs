using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteCRUD.Domain.Repositories
{
    public interface ISalvarDB
    {
        public Task Commit();
    }
}
