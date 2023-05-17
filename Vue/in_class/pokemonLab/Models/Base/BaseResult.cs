namespace pokemonLab.Models.Base
{
    public class BaseResult {
        public BaseResult()
        {
            IsSuccess = true;
            Status = APIStatus.Success;
        }

        public bool IsSuccess { get; set; }

        public APIStatus Status { get; set; }

        public object Body { get; set; }

    }

    public enum APIStatus {
        Success = 200,
        Unauthorized = 401,
        NotFound = 404
    }
}