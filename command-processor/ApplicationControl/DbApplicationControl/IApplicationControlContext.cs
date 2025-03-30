using BaseRepositoryWithUnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ApplicationControl.DbApplicationControl;

public interface IApplicationControlContext : IContext
{
     DbSet<ApplicationControl> ApplicationControls { get; set; }
}
