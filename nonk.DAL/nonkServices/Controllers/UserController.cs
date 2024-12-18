using Microsoft.AspNetCore.Mvc;
using nonk.DAL.Models;
using nonkDBFirst.DAL;
using System.Text.Json.Serialization;


namespace nonkServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        nonkRepository repository;

            public UserController(nonkRepository repository)
            {
                this.repository = repository;
            }

        [HttpGet]
        public JsonResult GetAllUsers()
        {
            List<User> user = new List<User>();
            try
            {
                user = repository.GetAllUsers();
            }
            catch (Exception)
            {
                user = null;
            }
            return Json(user);
        }

    }
}
