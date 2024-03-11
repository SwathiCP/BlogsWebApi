using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sample_Project.Models;

namespace Sample_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {

        private readonly BlogDbContext _DbContext;
        public BlogsController(BlogDbContext dbcontext)
        {
            _DbContext = dbcontext;

        }

      

     

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlog()
        {
            var blogss = await _DbContext.Blogs.ToListAsync();
            if (blogss == null || !blogss.Any())
            {
                return NotFound();
            }
            return Ok(blogss);
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<IEnumerable<Blog>>> GetById(int id)
        {
            var blog = _DbContext.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            return Ok(blog);
            

        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Blog>>> CreateBlog(Blog blog)
        {
            _DbContext.Blogs.Add(blog);

            await _DbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = blog.BId }, blog);
        }




        [HttpPut("{id}")]
        public async Task<ActionResult<Blog>> UpdateBlog(int id, Blog blog)
        {
            if (id != blog.BId)
            {
                return BadRequest();
            }

            _DbContext.Entry(blog).State = EntityState.Modified;

            try
            {
                await _DbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_DbContext.Blogs.Any(u => u.BId == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Blog>>> DeleteBlog(int id)
        {
            var del = await _DbContext.Blogs.FindAsync(id);

            if (del == null)
            {
                return NotFound();
            }

            _DbContext.Blogs.Remove(del);
            await _DbContext.SaveChangesAsync();

            return Ok();
        }

    }
}
