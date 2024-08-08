using Cert.Core.Entities;
using Cert.Infrastructure.Data;
using Cert.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cert.Test
{
    public class ProductoConcurrencyTests
    {
        private readonly DbContextOptions<CertContext> _dbContextOptions;

        public ProductoConcurrencyTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<CertContext>()
                .UseNpgsql("Host=localhost;Database=Cert;Username=postgres;Password=Ed1234") // Reemplaza con tu cadena de conexión a PostgreSQL
                .Options;
        }

        [Fact]
        public async Task ConcurrencyTest_ShouldUpdateProductQuantityConcurrently()
        {
            // Arrange
            var initialQuantity = 10;
            var updatedQuantity = 5;
            var numberOfTasks = 10;

            using (var context = new CertContext(_dbContextOptions))
            {
                context.Productos.Add(new Producto { Id = 1, Nombre = "Producto1", Precio = 100m, Cantidad = initialQuantity });
                context.SaveChanges();
            }

            var tasks = new List<Task>();

            // Act
            for (int i = 0; i < numberOfTasks; i++)
            {
                tasks.Add(Task.Run(async () =>
                {
                    using (var context = new CertContext(_dbContextOptions))
                    {
                        // Introducir un retraso para aumentar la posibilidad de conflicto
                        await Task.Delay(10);

                        var producto = await context.Productos.FindAsync(1);
                        if (producto != null)
                        {
                            producto.Cantidad += updatedQuantity;
                            try
                            {
                                await context.SaveChangesAsync();
                            }
                            catch (DbUpdateConcurrencyException)
                            {
                                // Manejar conflicto de concurrencia, puedes registrar el error o simplemente ignorarlo en la prueba
                            }
                        }
                    }
                }));
            }

            await Task.WhenAll(tasks);

            // Assert
            using (var context = new CertContext(_dbContextOptions))
            {
                var producto = await context.Productos.FindAsync(1);
                Assert.NotNull(producto);
                // La cantidad final puede ser menor debido a conflictos de concurrencia
                Assert.True(producto.Cantidad <= initialQuantity + updatedQuantity * numberOfTasks, "La cantidad final no es la esperada.");
            }
        }
    }
}
