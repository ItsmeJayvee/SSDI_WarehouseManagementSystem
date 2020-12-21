using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.Server.Data;
using WarehouseManagementSystem.Server.Helpers;
using WarehouseManagementSystem.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using System.IO;
using System;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;

namespace SonicWarehouseManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadsController : ControllerBase
    {
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _environment;
        public UploadsController(AppDBContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: api/Uploads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Uploads>>> GetUpload()
        {
            return await _context.Upload.ToListAsync();
        }

        [HttpGet("getcardcode/{cardcode}")]
        public async Task<ActionResult<IEnumerable<Uploads>>> GetUpload(string cardcode)
        {
            return await _context.Upload.Where(x => x.Card_Code == cardcode).ToListAsync();
        }

        [HttpGet("getrequirements/{cardcode}")]
        public async Task<ActionResult<IEnumerable<Uploads>>> GetRequirement(string cardcode)
        {
            var upload = _context.Upload.Where(x => x.Card_Code == cardcode).ToList();

            if (upload == null)
            {
                return NotFound();
            }

            return Ok(upload);
        }

        // GET: api/Uploads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Uploads>> GetUploadID(int id)
        {
            var upload = await _context.Upload.FindAsync(id);

            if (upload == null)
            {
                return NotFound();
            }

            return upload;
        }

        // PUT: api/BusinessPartners/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> PutUploads(int id, Uploads uploads)
        {
            if (id != uploads.Id)
            {
                return BadRequest();
            }

            _context.Entry(uploads).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UploadsExists(id))
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

        // POST: api/Uploads
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        public class FileUpload
        {
            public IFormFile files { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> PostBPUpload([FromForm] FileUpload image)
        {
            if (image.files.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Uploads\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Uploads\\");
                    }
                    string filename = image.files.FileName;
                    string extension = Path.GetExtension(filename);
                    long filesize = image.files.Length;
                    string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".bmp" };

                    if (image == null || filesize == 0)
                        return BadRequest("Upload a File");

                    if (!allowedExtensions.Contains(extension))
                        return BadRequest("File is not a valid image");

                    long allowSize = 10000000;
                    if (filesize > allowSize)
                        return BadRequest("File is too large");

                    string path = Path.Combine(_environment.WebRootPath + "\\Uploads\\", filename);
                    using (FileStream filestream = System.IO.File.Create(path))
                    {
                        await image.files.CopyToAsync(filestream);
                        filestream.Flush();
                        return Ok("\\Uploads\\" + filename);
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.ToString());
                }
            }
            else
            {
                return BadRequest("UnSuccessful");
            }

        }

        [HttpPost("postUpload")]
        public async Task<ActionResult<Uploads>> PostUploads(Uploads uploads)
        {
            _context.Upload.Add(uploads);
            await _context.SaveChangesAsync();

            return Ok();
        }
        // DELETE: api/Uploads/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Uploads>> DeleteUploads(int id)
        {
            var uploads = await _context.Upload.FindAsync(id);
            if (uploads == null)
            {
                return NotFound();
            }

            _context.Upload.Remove(uploads);
            await _context.SaveChangesAsync();

            return uploads;
        }
        // DELETE: api/Uploads/5
        [HttpDelete("deletedata/{filename}")]
        public async Task<ActionResult<Uploads>> DeleteUploads(string filename)
        {
            var uploads = await _context.Upload.Where(x => x.Document == filename).FirstOrDefaultAsync();
            if (uploads == null)
            {
                return NotFound();
            }

            _context.Upload.Remove(uploads);
            await _context.SaveChangesAsync();

            return uploads;
        }

        [HttpDelete("deleteUpload/{filename}")]
        public async Task<ActionResult<Uploads>> DeleteFiles(string filename)
        {
            try
            {
                string path = Path.Combine(_environment.WebRootPath + "\\Uploads\\", filename);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    return Ok("Deleted Successfully");
                }
                else
                {
                    return BadRequest("File not found");
                }
            }
            catch (IOException)
            {
                return BadRequest("IO Exception = File not found");
            }
            catch (Exception)
            {
                return BadRequest("There was an error while deleting a file.");
            }

        }

        private bool UploadsExists(int id)
        {
            return _context.Upload.Any(e => e.Id == id);
        }
    }
}