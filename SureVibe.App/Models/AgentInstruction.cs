using System.Text.Json.Serialization;

namespace SureVibe.App.Models;

public sealed class AgentInstruction
{
    [JsonPropertyOrder(0)]
    public string Goal { get; set; } = string.Empty;

    [JsonPropertyOrder(1)]
    public string Scope { get; set; } = string.Empty;

    [JsonPropertyOrder(2)]
    public string RepoLayout { get; set; } = string.Empty;

    [JsonPropertyOrder(3)]
    public string Constraints { get; set; } = string.Empty;

    [JsonPropertyOrder(4)]
    public string[] Tasks { get; set; } = [];

    [JsonPropertyOrder(5)]
    public string[] AcceptanceTests { get; set; } = [];

    [JsonPropertyOrder(6)]
    public string[] EvidenceRequired { get; set; } = [];

    [JsonPropertyOrder(7)]
    public string[] Forbidden { get; set; } = [];
}
