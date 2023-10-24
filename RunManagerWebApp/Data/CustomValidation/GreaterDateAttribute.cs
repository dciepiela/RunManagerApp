using System.ComponentModel.DataAnnotations;

namespace RunManagerWebApp.Data.CustomValidation
{
    public class GreaterDateAttribute:ValidationAttribute
    {
        public GreaterDateAttribute() : base("{0} Data powinna być większa od obecnej. Proszę popraw.")
        {

        }

        public override bool IsValid(object value)
        {
            DateTime currentDate = Convert.ToDateTime(value);
            if (currentDate <= DateTime.Now)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
