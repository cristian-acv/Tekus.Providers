namespace Tekus.Providers.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) : base($"Entity \"{name}\" ({key})  It was not found")
        {
        }
    }
}
