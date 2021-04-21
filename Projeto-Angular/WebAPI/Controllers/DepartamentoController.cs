using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Models;


namespace WebAPI.Controllers{
     [ApiController]
    [Route("[controller]")]

    public class DepartamentoController : ControllerBase{
        private readonly IRepository _repo;

        public DepartamentoController(IRepository repo){
            _repo = repo;
        }
    
     [HttpGet]
        public async Task<IActionResult> Get(){

            try
            {
                var resultado = await _repo.GetAllDepartamentosAsync(true);

                return Ok(resultado);

            }

            catch (Exception ex)
            {
                
                return BadRequest($"Erro:{ex.Message}");
            }


        }
        
        
        [HttpGet("{Departamentoid}")]
        public async Task<IActionResult> GetByDepartamentoid(int Departamentoid){
            
            try
            {
            var resultado = await _repo.GetDepartamentoAsyncById(Departamentoid, true);

                return Ok(resultado);

            }

            catch (Exception ex)
            {
                
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Departamento model){
            
            try
            {
              _repo.Add(model);
            
            if(await _repo.SaveChangesAsync()){

                return Ok(model);
            }

            }

            catch (Exception ex)
            {
                
                return BadRequest($"Erro:{ex.Message}");
            }
            return BadRequest();

        }   
  
        [HttpPut("{Departamentoid}")]
        public async Task<IActionResult> put(int departamentoid, Departamento model){

            try
            {
                var Departamento = await _repo.GetDepartamentoAsyncById(departamentoid, false);
                if(Departamento == null) return NotFound("Usuario Não encontrado");
                
              _repo.Update(model);
            
            if(await _repo.SaveChangesAsync()){

                return Ok(model);
            }

            }

            catch (Exception ex)
            {
                
                return BadRequest($"Erro:{ex.Message}");
            }
            return BadRequest();

        }   

        [HttpDelete("{Departamentoid}")]
        public async Task<IActionResult> delete(int departamentoid){

            try
            {
                var Departamento = await _repo.GetDepartamentoAsyncById(departamentoid, false);

              _repo.Delete(Departamento);
            
            if(await _repo.SaveChangesAsync()){

                return Ok(new {message ="Deletado"});
            }

            }

            catch (Exception ex)
            {
                
                return BadRequest($"Erro:{ex.Message}");
            }
            return BadRequest();

        }   


    }

  
    

}