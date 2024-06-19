using System.Text.Json;

namespace Capital_placement_assessment.DTOs
{
    public class AppException
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    public class InputError : ApplicationException
    {
        public InputError(string message = "Invalid input.") : base(message) { }
    }
}
