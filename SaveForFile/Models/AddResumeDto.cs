using System.Text.Json.Serialization;

namespace SaveForFile.Models;

public class AddResumeDto
{
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("lastName")]
    public string LastName { get; set; } = string.Empty;

    [JsonPropertyName("age")]
    public int Age { get; set; }

    [JsonPropertyName("phone")]
    public string Phone { get; set; } = string.Empty;

    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    [JsonPropertyName("experience")]
    public byte Experience { get; set; }

    [JsonPropertyName("location")]
    public string Location { get; set; } = string.Empty;

    [JsonPropertyName("summary")]
    public string Summary { get; set; } = string.Empty;

    [JsonPropertyName("links")]
    public string[]? Links { get; set; }

    [JsonPropertyName("education")]
    public string[]? Education { get; set; }

    [JsonPropertyName("skills")]
    public string[] Skills { get; set; } = null!;

    [JsonPropertyName("languages")]
    public string[] Languages { get; set; } = null!;
}
