namespace _27_11_23_asp.Controllers
{
    public class ContactService
    {
        public bool IsEmailValide(string email)
        {
            if (email.Contains("@"))
            {
                return true;
            }

            return false;
        }
    }
}
