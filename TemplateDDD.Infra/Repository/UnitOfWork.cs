using TemplateDDD.Domain.Interfaces;
using TemplateDDD.Infra.Context;

namespace TemplateDDD.Infra.Repository
{
    public class UnitOfWork : IUnitOfWork
	{
        private readonly MyContext _context;
        public UnitOfWork(MyContext context)
		{
            _context = context;
		}

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}

