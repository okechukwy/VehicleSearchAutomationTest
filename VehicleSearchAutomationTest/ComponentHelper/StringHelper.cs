namespace VehicleSearchAutomationTest.ComponentHelper
{
    public class StringHelper
    {
        public string GetCarRegistrationInElement(string text)
        {
            string carRegistration = text;
            string separator = "|";

            string [] result = text.Split(separator);

            foreach (string s in result)
            {
                if (s == carRegistration)
                    return s;
            }
            return carRegistration; 

        }

    }
}
