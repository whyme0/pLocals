namespace pLocals.Tools
{
    public class PasswordManager
    {
        public string GeneratePassword(int length, bool withUppercase = false, bool withSpecialChars = false)
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
                int randomlyGeneratedNumber = new Random().Next(initialChars.Length);
                outputChars[i] = initialChars[randomlyGeneratedNumber];
            }
            return new string(outputChars);
        }
    }
}
