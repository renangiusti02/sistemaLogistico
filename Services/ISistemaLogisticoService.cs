using SistemaLogistico.Models;


namespace SistemaLogistico.Services {
   public interface iNavioService {

      List<Navio> ListaNavios();
      List<Container> ListaContainers();
      bool alterarNavio(int id, Navio navio);
      List<Navio> adicionarNavio(Navio navio);
      (List<Navio>, List<Container>, List<int>, List<int>, List<int>) adicionarContainerFila(Container container);
      bool alterarContainer(int id, Container container);
      bool Confisco(int id);
      List<Navio> Carregamento();
      List<Container> Descarregamento(int id);
      List<int> Fila();
      
   }
   
}