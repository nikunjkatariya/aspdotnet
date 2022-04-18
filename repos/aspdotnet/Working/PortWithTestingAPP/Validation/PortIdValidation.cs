using Xunit;

namespace PortWithTestingAPP.Validation
{
    public class PortIdValidation
    {
        public bool Ok(int length,int id)
        {
            if(length == id)
                return true;
            return false;
        }
    }
}
