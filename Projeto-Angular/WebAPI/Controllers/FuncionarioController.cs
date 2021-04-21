using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Data;


namespace WebAPI.Controllers{
     [ApiController]
    [Route("[controller]")]

    public class FuncionarioController : ControllerBase{
        private readonly IRepository _repo;

        public FuncionarioController(IRepository repo){
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get(){

            try
            {
                var resultado = await _repo.GetAllFuncionariosAsync(true);

                return Ok(resultado);

            }

            catch (Exception ex)
            {
                
                return BadRequest($"Erro:{ex.Message}");
            }


        }
        
        
        [HttpGet("{Funcionarioid}")]
        public async Task<IActionResult> GetFuncionarioAsyncById(int FuncionarioId){
            
            try
            {
            var resultado = await _repo.GetFuncionarioAsyncById(FuncionarioId, true);

                return Ok(resultado);

            }

            catch (Exception ex)
            {
                
                return BadRequest($"Erro:{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Funcionario model){
            
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

         [HttpPut("{funcionarioid}")]
        public async Task<IActionResult> put(int funcionarioid, Funcionario model){

            try
            {
                var funcionario = await _repo.GetFuncionarioAsyncById(funcionarioid, false);

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

          [HttpDelete("{Funcionarioid}")]
        public async Task<IActionResult> delete(int Funcionarioid){

            try
            {
                var Funcionario = await _repo.GetFuncionarioAsyncById(Funcionarioid, false);

              _repo.Delete(Funcionario);
            
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