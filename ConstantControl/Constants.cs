using System;
using System.Collections.Generic;

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
            Incompleto = 5,
            Actualizado = 6
            
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
        public enum Discount_State
        {
            Habilitado = 1,
            Deshabilitado = 0



        }
        public enum Actions
        {
            Dispatch = 1,
            Users = 2,
            Offices = 3,
            Stock = 4,
            Sale = 5,
            Discount = 6



        }
        public enum RoleEnum
        {
            Administrative = 1,
            Manager = 2,
            Seller = 3,
            Buyer = 4




        }
        //BARCODE
        public static string BarcodeFolder = "StockManagmentBarcodeImage";
        //HISTORY        
        public static string HistoryUserCreate = "UserCreate";
        public static string HistoryUserUpdate = "UserUpdate";
        public static string HistoryUserDelete = "UserDelete";
                              
        public static string HistoryDispatchCreate = "DispatchCreate";
        public static string HistoryDispatchUpdate = "DispatchUpdate";
        public static string HistoryDispatchSend = "DispatchSend";
        public static string HistoryDispatchRecive = "DispatchRecive";
        public static string HistoryDispatchFinish = "DispatchFinish";
        public static string HistoryDispatchDelete = "DispatchDelete";

        public static string HistoryOfficeCreate = "OfficeCreate";
        public static string HistoryOfficeUpdate = "OfficeUpdate";
        public static string HistoryOfficeDelete = "OfficeDelete";
                              
        public static string HistoryStockCreate = "StockCreate";
        public static string HistoryStockUpdate = "StockUpdate";
        public static string HistoryStockDelete = "StockDelete";

        public static string HistorySaleCreate = "SaleCreate";
        public static string HistorySaleReturned = "SaleReturned";
        public static string HistoryChangeGenerate = "ChangeGenerate";

        public static string HistoryDiscountCreate = "DiscountCreate";
        public static string HistoryDiscountDisabled = "DiscountDisabled";
        public static string HistoryDiscountUpdated = "DiscountUpdated";

        //ERRORS
        public static string ErrSameDestinationAndOrigin = "errSameDestinationAndOrigin";
        public static string ErrStockHasCHange = "errStockHasCHange";
        public static string ErrCheckDispatchItems = "errCheckDispatchItems";
        public static string ErrStockNotFound = "errStockNotFound";
        public static string ErrProductWithoutStock = "errProductWithoutStock";
        public static string ErrOfficeAllReadyExist = "errOfficeAllReadyExist";
        public static string ErrUserOrPass = "errUserOrPass";
        public static string ErrDiscountExistsDates = "errDiscountExistsDates";
    }
}
