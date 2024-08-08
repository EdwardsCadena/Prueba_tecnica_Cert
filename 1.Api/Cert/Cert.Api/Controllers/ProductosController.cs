using AutoMapper;
using Cert.Api.Response;
using Cert.Core.DTOs;
using Cert.Core.Entities;
using Cert.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cert.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepository _repository;
        private readonly IMapper _mapper;

        public ProductosController(IProductoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductoDTOs>>>> GetProductos()
        {
            var productos = await _repository.GetAllAsync();
            var productosDto = _mapper.Map<IEnumerable<ProductoDTOs>>(productos);
            return Ok(new ApiResponse<IEnumerable<ProductoDTOs>>(productosDto));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ProductoDTOs>>> GetProducto(int id)
        {
            var producto = await _repository.GetByIdAsync(id);
            if (producto == null)
            {
                return NotFound(new ApiResponse<ProductoDTOs>(null)); 
            }

            var productoDto = _mapper.Map<ProductoDTOs>(producto);
            return Ok(new ApiResponse<ProductoDTOs>(productoDto));
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<ProductoDTOs>>> PostProducto(ProductoDTOs productDto)
        {
            var producto = _mapper.Map<Producto>(productDto);
            var nuevoProducto = await _repository.AddAsync(producto);
            var nuevoProductoDto = _mapper.Map<ProductoDTOs>(nuevoProducto);
            return CreatedAtAction(nameof(GetProducto), new { id = nuevoProducto.Id }, new ApiResponse<ProductoDTOs>(nuevoProductoDto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest(new ApiResponse<ProductoDTOs>(null)); 
            }

            var producto = _mapper.Map<Producto>(productDto);
            await _repository.UpdateAsync(producto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var result = await _repository.DeleteAsync(id);
            if (!result)
            {
                return NotFound(new ApiResponse<ProductoDTOs>(null)); 
            }

            return NoContent();
        }

        [HttpPatch("{id}/cantidad")]
        public async Task<IActionResult> UpdateCantidad(int id, [FromBody] int cantidad)
        {
            var result = await _repository.UpdateCantidadAsync(id, cantidad);
            if (!result)
            {
                return NotFound(new ApiResponse<ProductoDTOs>(null)); 
            }

            return NoContent();
        }
    }
}
