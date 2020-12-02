namespace BelleChao.Data.Models
{
    public class ResponseModel
    {
        public int StatusCode { get; set; }
        public string Description { get; set; }
        public object Data { get; set; }
    }
}
