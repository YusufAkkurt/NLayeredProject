namespace WebAPI.Dtos
{
    public class ErrorDto
    {
        public int Status { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
