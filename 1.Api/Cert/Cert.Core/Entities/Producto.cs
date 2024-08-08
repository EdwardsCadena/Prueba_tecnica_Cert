using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cert.Core.Entities;

public  class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public int Cantidad { get; set; }
    [Timestamp]
    public byte[]? RowVersion { get; set; }
}

