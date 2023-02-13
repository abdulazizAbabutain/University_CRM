namespace University_CRM.Domain.Exceptioon
{
    public class CollageNotFoundException : Exception
    {
        public CollageNotFoundException(string massge)
            : base(massge) 
        {
        }
    }
}
