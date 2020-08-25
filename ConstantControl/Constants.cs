using System;

namespace ConstantControl
{
    public class Constants
    {

        public enum Dispatch_State
        {
            Creado = 1,
            Despachado = 2,
            Recibido = 3,
            Finalizado = 4,
            Incompleto = 5
            
        }

        public enum Sale_State
        {
            Inicial = 1,
            Reservado = 2,
            Finalizado = 3,
            Devuelto = 4
           

        }
        public enum Stock_State
        {
            Habilitado = 1,
            Deshabilitado = 2
          


        }

    }
}
