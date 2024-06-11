using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SaveForFile.Interface;
using SaveForFile.Models;

namespace SaveForFile.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilesController(IFileService service) : ControllerBase
{
    private readonly IFileService _service = service;

    [HttpPost("upload")]
    public async Task<IActionResult> UploadFileAsync(IFormFile file)
        => Ok(await _service.SaveFileAsync(file));
    
    [HttpPost("save")]
    public async Task<IActionResult> SaveFileAsync([FromBody]AddResumeDto dto)
    {
        var json = JsonConvert.SerializeObject(dto);
        var fileName = $"{dto.FirstName}-{dto.LastName}";

        using (MemoryStream ms = new MemoryStream())
        {
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, ms);
            document.Open();
            document.Add(new Paragraph(json));
            document.Close();
            writer.Close();
            byte[] byteArray = ms.ToArray();
            var result = File(byteArray, "application/pdf", fileName);
            return result;
        }
    }
}