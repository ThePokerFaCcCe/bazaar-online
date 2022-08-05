namespace BazaarOnline.Application.DTOs.PaginationDTO
{
    public class PaginationResultDTO<T> where T : class
    {
        public int Count { get; set; } = 0;
        public List<T> Content { get; set; } = new List<T>();

    }
}
