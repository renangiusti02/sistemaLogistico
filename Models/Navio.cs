namespace SistemaLogistico.Models;

public class Navio {

   public Navio() {
      ListaPontos = new List<string>();
      ListaContainers = new List<Container>();
   }

   public Navio (double carga, List<string> pontos) {

      Id = id + 1;
      CargaMaxima = carga;
      ListaPontos = pontos;
      ListaContainers = new List<Container>();
      id += 1;

   }

   static int id = 0;
   public int Id {get; set;}
   public double CargaMaxima {get; set;}
   public List<string> ListaPontos {get; set;}
   public List<Container> ListaContainers {get; set;}

}