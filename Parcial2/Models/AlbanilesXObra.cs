using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial2.Models;

public partial class AlbanilesXObra
{
    public Guid Id { get; set; }
    
    public string TareaArealizar { get; set; } = null!;
    
    public DateTime? FechaAlta { get; set; }
    
    public Guid IdAlbanil { get; set; }
    public Guid IdAlbanilNavigationId { get; set; }
    public virtual Albanile IdAlbanilNavigation { get; set; } = null!;
    
    public Guid IdObra { get; set; }
    public Guid IdObraNavigationId { get; set; }
    public virtual Obra IdObraNavigation { get; set; } = null!;
}
