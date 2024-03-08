namespace TemplateDDD.Domain.Interfaces
{
    public interface IUnitOfWork
	{
		Task Commit();
	}
}

