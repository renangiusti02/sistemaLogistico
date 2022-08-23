namespace SistemaLogistico.Models;

public class Container {
   
   public Container() {

   }

   public Container (string ponto, double carga) {

      Id = id + 1;
      Ponto = ponto;
      Carga = carga;
      id += 1;

   }

   static int id = 0;
   public int Id {get; set;}
   public string? Ponto {get; set;}
   public double Carga {get; set;}

}
