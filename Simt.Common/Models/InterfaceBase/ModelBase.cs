using System.ComponentModel.DataAnnotations;

namespace Simt.Common.Models.InterfaceBase;

public abstract record ModelBase : IModel
{
    [Required(ErrorMessage = "Id is required")]
    public required Guid Id { get; init; }

}