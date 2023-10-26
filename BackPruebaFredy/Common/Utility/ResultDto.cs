namespace Common.Utility
{
    public class ResultDto<T>
    {
        public ResponseDto ResponseDto { get; set; }

        public List<T> BusinessDto { get; set; }
    }
}
