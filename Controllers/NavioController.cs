using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using SistemaLogistico.Models;
using SistemaLogistico.Services;

namespace SistemaLogistico.Controllers;

[ApiController]
[Route("[controller]")]

public class NavioController : ControllerBase {

   private readonly iNavioService _navioController;

   public NavioController(iNavioService navioController) {

      _navioController = navioController;

   }


   // Retorna a lista de navios
   [HttpGet("ListaNavios")]
   public ActionResult<List<Navio>> ListaNavios() {

      return Ok(_navioController.ListaNavios());

   }

   // Retorna a lista de containers
   [HttpGet("ListaContainers")]
   public ActionResult<List<Container>> ListaContainers() {

      return Ok(_navioController.ListaContainers());

   }

   // cadastroNavio
   [HttpPost("cadastroNavio")]
   public ActionResult<List<Navio>> adicionarNavio(Navio navio) {

      try {

         if (navio != null) {

            return Ok(_navioController.adicionarNavio(navio));

         }

         return StatusCode(400, "Navio não informado no corpo da requisição");

      }

      catch (System.Exception) {

         return Problem("Falha ao inserir navio na fila de embarque.");

      }

   }

   // alterarNavio
   [HttpPut("alterarNavio/{id}")]
   public ActionResult<bool> alterarNavio(int id, Navio navio) {

      try {

         if (navio == null) {

            return StatusCode(400, "Navio ou id não informado no corpo da requisição");

         }

         return Ok(_navioController.alterarNavio(id, navio));

      }

      catch (System.Exception) {

         return Problem("Falha ao alterar navio.");

      }

   }

   // filaEmbarque
   [HttpPost("filaEmbarque")]
   public ActionResult<(List<Navio>, List<Container>, List<int>, List<int>, List<int>)> adicionarContainerFila(Container container) {
      
      try {

         if (container == null || container is null) {

            return StatusCode(400, "Container não informado no corpo da requisição");

         }

         else if (container.Carga <= 0) {

            return StatusCode(204, "Valores inválidos!");

         }

         else if (container.Ponto == null) {

            return StatusCode(204, "Valores inválidos!");

         }

         else {

            return Ok(_navioController.adicionarContainerFila(container));

         }

      }

      catch (System.Exception) {

         return Problem("Falha ao inserir container na fila de embarque.");

      }

   }

   // alfandega
   [HttpPut("alfandega/{id}")]
   public ActionResult<bool> alterarContainer(int id, Container container) {

      try {

         if ((id == null) || (container == null)) {

            return StatusCode(400, "container ou id não informado no corpo da requisição");

         }

         return Ok(_navioController.alterarContainer(id, container));

      }

      catch (System.Exception) {

         return Problem("Falha ao alterar container.");

      }

   }

   // confisco
   [HttpDelete("confisco/{id}")]
   public ActionResult<bool> Confisco(int id) {

      try {

         return Ok(_navioController.Confisco(id));
      
      }
      
      catch (System.Exception) {

         return Problem("Falha ao confiscar container.");
      
      }
   
   }

   // carregamento
   [HttpGet("carregamento")]
   public ActionResult<List<Navio>> Carregamento() {

      try {

         return Ok(_navioController.Carregamento());
      
      }
      
      catch (System.Exception) {

         return Problem("Falha ao efetuar carregamento.");
      
      }
   
   }

   // descarregamento
   [HttpGet("descarregamento/{id}")]
   public ActionResult<List<Container>> Descarregamento(int id) {
      
      try {

         return Ok(_navioController.Descarregamento(id));
      
      }
      
      catch (System.Exception) {
         
         return Problem("Falha ao efetuar descarregamento.");
      
      }

   }

   // Retorna a fila de containers
   [HttpGet("Fila")]
   public ActionResult<List<int>> Fila() {
      try {
         
         return Ok(_navioController.Fila());
      
      }
      
      catch (System.Exception) {
         
         return Problem("Falha ao retorna a fila de containers.");
      
      }
   
   }

}