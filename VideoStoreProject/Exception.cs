using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStoreProject
{
   public class NullExceptionMovie : Exception
    {
    }

    public class DuplicateException:Exception
    {
        
    }

    public class NullExceptionCustomerNotRegistered : Exception
    {
        
    }
    public class CanNotRetMorThenThreeException : Exception
    {

    }
    public class CanNotRetSamMovieException : Exception
    {

    }
    public class DueDatesMovieException : Exception
    {

    }
}
