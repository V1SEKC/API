namespace API.Validators.Base
{
    public class BaseValidator : IBaseValidator
    {
        public void ValidateId(int id)
        {
            if (id <= 0) 
            {
                throw new BadHttpRequestException("Невозможный id");
            }
        }
    }
}
