using Microsoft.AspNetCore.Mvc;

namespace TestMVCController.Controllers
{
    public class PocoController
    {
        public string Test(int id)
        {
            return "PocoController.Test "+id;
        }
    }

    [NonController]
    public class NonPocoController
    {
        public string Test(int id)
        {
            return "PocoController.Test " + id;
        }
    }


    [Controller]
    public class Poco2
    {
        [AcceptVerbs("post")]
        public string Test(int id)
        {
            return "Poco2.Test " + id;
        }
    }

}
