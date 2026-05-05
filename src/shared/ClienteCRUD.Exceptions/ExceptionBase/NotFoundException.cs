namespace ClienteCRUD.Exceptions.ExceptionBase
{
    public class NotFoundException : ClienteCrudException
    {
        public NotFoundException(string message) : base(message) { }
    }
}
