using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System.Text.Json.Serialization;
using University_CRM.Application.Common.Models;
using University_CRM.Domain.Entities;

namespace University_CRM.Application.Features.Collages.Commands;

public class ParialUpdateCollageCommand : IRequest
{
    [JsonIgnore]
    public int Id { get; set; }
    public JsonPatchDocument<Collage> document { get; set; }
}
