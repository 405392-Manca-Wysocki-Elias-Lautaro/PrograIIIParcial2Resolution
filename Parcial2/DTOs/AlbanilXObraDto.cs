using Parcial2.Models;

namespace Parcial2.DTOs;

public class AlbanilXObraDto
{
    public Guid Id { get; set; }
    public Guid AlbanilId { get; set; }
    public Guid ObraId { get; set; }
    public DateTime? FechaAlta { get; set; }
    public String TareaARealizar { get; set; }
}