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
        private readonly BlobContainerClient _blobContainerClient;
        public string ContainerName { get; set; } = string.Empty;

        public IndexModel(ILogger<IndexModel> logger, BlobContainerClient blobContainerClient)
        {
            _logger = logger;
            _blobContainerClient = blobContainerClient;
        }

        public void OnGet()
        {
            try
            {
                if (_blobContainerClient != null)
                {
                    var containers = _blobContainerClient.GetBlobs().ToList();
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