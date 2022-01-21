using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.IO;
namespace ChipmunkEventListing.Pages
{
    public class UploadModel : PageModel
    {
        private readonly ILogger<UploadModel> _logger;
        private string fullPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "UploadImages";
        public UploadModel(ILogger<UploadModel> logger)
        {
            _logger = logger;
        }
        [BindProperty]

        public FileUpload FileUpload { get; set; }
        public void OnGet()
        {
            ViewData["SuccessMessage"] = "";
        }
        public IActionResult OnPostUpload(FileUpload FileUpload)
        {
            //Creating upload folder
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            var FileToBeUploaded = FileUpload.FormFile;
            var filePath = Path.Combine(fullPath, FileToBeUploaded.FileName);

            using (var stream = System.IO.File.Create(filePath))
            {
                FileToBeUploaded.CopyToAsync(stream);
            }

            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.
            ViewData["SuccessMessage"] = FileToBeUploaded.FileName.ToString() + " files uploaded!!";
            return Page();
        }
    }
    public class FileUpload
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
        public string SuccessMessage { get; set; }
    }

}
