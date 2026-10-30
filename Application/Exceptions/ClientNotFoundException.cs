namespace Application.Exceptions
{
    public class ClientNotFoundException : Exception
    {
        public ClientNotFoundException(long clientId)
            : base($"Клиент с id {clientId} не найден в заказах.") { }
    }
}
