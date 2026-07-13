using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Infrastructure.Persistence.Interfaces
{
    public interface IDatabaseContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
