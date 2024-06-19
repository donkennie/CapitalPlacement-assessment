using Capital_placement_assessment.DTOs;

namespace Capital_placement_assessment.Extensions
{
    public static class Validator
    {
        public static void CannotBeNullOrEmpty(params dynamic[] objs)
        {
            foreach (dynamic data in objs)
            {
                if (data == null || string.IsNullOrEmpty(Convert.ToString(data)))
                {
                    throw new InputError("One or more input is missing or empty");
                }
            }
        }
    }
}
