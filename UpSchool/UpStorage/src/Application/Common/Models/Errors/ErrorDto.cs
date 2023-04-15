namespace Application.Common.Models.Errors
{
    public class ErrorDto
    {
        public string PropertyName { get; set; }
        public List<string> ErrorMesssages { get; set; }

        public ErrorDto(string propertName, List<string> errorMessages)
        {
            PropertyName = propertName;
            ErrorMesssages = errorMessages;
        }
    }
}
