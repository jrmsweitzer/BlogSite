using Angular2ASPNET.Attributes;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using Services.Impl;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Angular2ASPNET.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        private BlogService _blogService;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BlogController()
        {
            _blogService = new BlogService();
        }

        /// <summary>
        /// Overloaded Constructor
        /// </summary>
        /// <param name="service"></param>
        public BlogController(BlogService service)
        {
            _blogService = service;
        }
        

        // GET: api/blogs
        [NoCache]
        [HttpGet]
        public List<Models.Blog> Get()
        {
            return _blogService.GetBlogs();
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
