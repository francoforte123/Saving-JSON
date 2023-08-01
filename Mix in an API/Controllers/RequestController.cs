using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mix_in_an_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestRepository requestRepository;
        public RequestController(IRequestRepository requestRepository)
        {
            this.requestRepository = requestRepository;
        }

        [HttpGet(Name = "GetAll")]
        public IEnumerable<Request> GetAll()
        {
            return this.requestRepository.GetAll();
        }
    }
}
