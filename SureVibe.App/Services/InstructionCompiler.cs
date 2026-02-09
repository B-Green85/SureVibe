using System;
using System.Linq;
using System.Text.Json;
using SureVibe.App.Models;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace SureVibe.App.Services;

public enum OutputFormat
{
    Json,
    Yaml
}

public static class InstructionCompiler
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.Never
    };

    private static readonly ISerializer YamlSerializer = new SerializerBuilder()
        .WithNamingConvention(CamelCaseNamingConvention.Instance)
        .ConfigureDefaultValuesHandling(DefaultValuesHandling.Preserve)
        .Build();

    public static AgentInstruction Parse(
        string goal,
        string scope,
        string repoLayout,
        string constraints,
        string tasksText,
        string acceptanceTestsText,
        string evidenceRequiredText,
        string forbiddenText)
    {
        return new AgentInstruction
        {
            Goal = Normalize(goal),
            Scope = Normalize(scope),
            RepoLayout = Normalize(repoLayout),
            Constraints = Normalize(constraints),
            Tasks = ParseList(tasksText),
            AcceptanceTests = ParseList(acceptanceTestsText),
            EvidenceRequired = ParseList(evidenceRequiredText),
            Forbidden = ParseList(forbiddenText)
        };
    }

    public static string Compile(AgentInstruction instruction, OutputFormat format)
    {
        return format switch
        {
            OutputFormat.Json => JsonSerializer.Serialize(instruction, JsonOptions),
            OutputFormat.Yaml => YamlSerializer.Serialize(instruction).TrimEnd(),
            _ => throw new ArgumentOutOfRangeException(nameof(format))
        };
    }

    private static string Normalize(string? value)
    {
        return (value ?? string.Empty).Trim();
    }

    private static string[] ParseList(string? text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return [];

        return text
            .Split('\n')
            .Select(line => line.Trim())
            .Where(line => line.Length > 0 && !line.StartsWith('#'))
            .ToArray();
    }
}
