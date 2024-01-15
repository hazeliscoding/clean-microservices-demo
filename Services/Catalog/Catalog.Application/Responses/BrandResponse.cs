using Catalog.Core.Entities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Catalog.Application.Responses;

public class BrandResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
}