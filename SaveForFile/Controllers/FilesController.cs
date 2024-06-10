using Microsoft.AspNetCore.Mvc;
using SaveForFile.Interface;

namespace SaveForFile.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilesController(IFileService service) : ControllerBase
{
    private readonly IFileService _service = service;

    [HttpPost("upload")]
    public async Task<IActionResult> UploadFileAsync(IFormFile file)
        => Ok(await _service.SaveFileAsync(file));
}
