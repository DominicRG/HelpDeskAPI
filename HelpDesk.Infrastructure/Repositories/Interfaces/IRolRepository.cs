using HelpDesk.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Infrastructure.Repositories.Interfaces
{
    public interface IRolRepository : IRepository<Rol>
    {
        Task<bool> ExistsByNameAsync(string nombre, int? id = null);
    }
}
