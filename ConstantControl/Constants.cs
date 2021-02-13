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
        public enum RoleEnum
        {
            Administrative = 1,
            Manager = 2,
            Seller = 3,
            Buyer = 4




        }

        public static string ErrSameDestinationAndOrigin = "errSameDestinationAndOrigin";
        public static string ErrStockHasCHange = "errStockHasCHange";
        public static string ErrCheckDispatchItems = "errCheckDispatchItems";
        public static string ErrStockNotFound = "errStockNotFound";
        public static string ErrProductWithoutStock = "errProductWithoutStock";
        public static string ErrOfficeAllReadyExist = "errOfficeAllReadyExist";
    }
}
