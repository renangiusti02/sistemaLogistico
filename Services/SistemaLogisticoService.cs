using SistemaLogistico.Controllers;
using SistemaLogistico.Models;

namespace SistemaLogistico.Services {
   public class NavioController : iNavioService {
      private static List<Navio> navios = new List<Navio>();
      private static List<Container> containers = new List<Container>();
      private static List<string> pontos = new List<string>();
      private static List<int> fila = new List<int>();
      private static List<int> fila1 = new List<int>();
      private static List<int> fila2 = new List<int>();
      private static List<int> fila3 = new List<int>();


      private void adicionarNavio(double carga, List<string> pontos) {

         navios.Add(new Navio(carga, pontos));

      }

      private void adicionarContainer(string ponto, double carga) {

         containers.Add(new Container(ponto, carga));

      }

      private Navio getNavioById(int id) {

         foreach (Navio i in navios) {

            if (i.Id == id) {

               return i;

            }

         }

         return null;

      }

      private Container getContainerById(int id) {

         foreach (Container i in containers) {

            if (i.Id == id) {

               return i;

            }

         }

         return null;

      }

      private void adicionarContainerFila(int idContainer) {

         int limite = 3;

         if (fila1.Count < limite) {

            fila1.Add(idContainer);

         }

         else if (fila2.Count < limite) {

            fila2.Add(idContainer);
         
         }

         else if (fila3.Count < limite) {

            fila3.Add(idContainer);

         }
         
      }

      public List<Navio> ListaNavios() {
         
         return (navios);
      
      }

      public List<Container> ListaContainers() {

         return (containers);

      }

      public List<Navio> adicionarNavio(Navio navio) {

         adicionarNavio(navio.CargaMaxima, navio.ListaPontos);
         return (navios);

      }

      public bool alterarNavio(int id, Navio navio) {

         Navio aux = null;
         aux = getNavioById(id);

         if (aux == null) {

            return false;

         }

         if (navio.CargaMaxima > 0) {

            aux.CargaMaxima = navio.CargaMaxima;

         }

         return (true);
      
      }

      public (List<Navio>, List<Container>, List<int>, List<int>, List<int>) adicionarContainerFila(Container container) {

         adicionarContainer(container.Ponto.ToUpper(), container.Carga);
         adicionarContainerFila(containers.Last().Id);
         return (navios, containers, fila1, fila2, fila3);
      
      }


      public bool alterarContainer(int id, Container container) {

         Container aux = null;

         aux = getContainerById(id);

         if (container.Carga > 0) {

            aux.Carga = container.Carga;
         
         }

         if (container.Ponto != null) {

            container.Ponto = container.Ponto.ToUpper();

            if (container.Ponto == "A" || container.Ponto == "B" || container.Ponto == "C" || container.Ponto == "D") {

               aux.Ponto = container.Ponto;

            }

         }

         return (true);
      
      }

      public bool Confisco(int id) {

         Container x = null;
         
         foreach (Container i in containers) {
         
            if (i.Id == id) {

               x = i;

            }

         }

         if (x != null) {

            containers.Remove(x);
            return true;

         }

         return false;
      
      }

      public List<Navio> Carregamento() {

         double cargaTemp = 0;

         foreach (Navio n in navios) {

            double cargaAtual = 0;

            foreach (Container c in n.ListaContainers) {

               cargaAtual += c.Carga;

            }

            if (containers != null && containers.Any()) {

               foreach (Container c in containers) {

                  if (n.ListaPontos.Contains(c.Ponto)) {
                  
                     if (cargaTemp + c.Carga <= n.CargaMaxima && (cargaAtual + c.Carga) < n.CargaMaxima) {

                        n.ListaContainers.Add(c);
                        cargaTemp += c.Carga;
                     
                     }

                  }

               }

               foreach (Container c in n.ListaContainers) {

                  containers.Remove(c);
               
               }
            }

            n.ListaContainers = n.ListaContainers.OrderBy(x => x.Ponto).ToList();
         
         }
         
         return (navios);
      
      }
      
      public List<Container> Descarregamento(int id) {

         Container x = null;
         Navio y = null;

         foreach (Navio n in navios) {

            foreach (Container c in n.ListaContainers) {

               if (c.Id == id) {

                  x = c;
                  y = n;
                  break;
               
               }
               
               else {

                  return null;
               
               }
            
            }
         
         }

         if (x != null && y != null) {

            y.ListaContainers.Remove(x);
            y.ListaContainers = y.ListaContainers.OrderBy(x => x.Ponto).ToList();
            return (containers);

         }

         else {

            return null;

         }

      }

   
      public List<int> Fila() {

         return (fila);

      }

   }

}
