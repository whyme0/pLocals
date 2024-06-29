namespace pLocals.Tools
{
    public class PasswordManager
    {
        private Random rnd = new Random();
        public string GeneratePassword(int length, bool withUppercase = true, bool withSpecialChars = true)
        {
            string initialCharsInString = "qwertyuiopasdfghjklzxcvbnm123456789";
            string uppercase = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string specials = "~`!@#$%^&*()_+№?-=";

            if (withUppercase)
                initialCharsInString += uppercase;
            if (withSpecialChars)
                initialCharsInString += specials;

            char[] initialChars = initialCharsInString.ToCharArray();
            char[] outputChars = new char[length];
            for (int i = 0; i < length; i++)
            {
                int randomlyGeneratedNumber = rnd.Next(initialChars.Length);
                outputChars[i] = initialChars[randomlyGeneratedNumber];
            }
            return new string(outputChars);
        }
    }
}
