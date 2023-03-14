using Azure.Core;
using Azure.Identity;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly BlobServiceClient _blobServiceClient;
        public string ContainerName { get; set; } = string.Empty;

        public IndexModel(ILogger<IndexModel> logger, BlobServiceClient BlobServiceClient)
        {
            _logger = logger;
            _blobServiceClient = BlobServiceClient;
        }

        public void OnGet()
        {
            try
            {
                if (_blobServiceClient != null)
                {
                    var containers = _blobServiceClient.GetBlobContainers().ToList();
                    if (containers.Any())
                    {
                        ContainerName = containers[0].Name;
                    }
                }
            }
            catch (Exception ex)
            {
                ContainerName = ex.ToString();
            }

        }
    }
}