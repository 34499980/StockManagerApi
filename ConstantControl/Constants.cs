﻿using System;
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


        //ERRORS
        public static string ErrSameDestinationAndOrigin = "errSameDestinationAndOrigin";
        public static string ErrStockHasCHange = "errStockHasCHange";
        public static string ErrCheckDispatchItems = "errCheckDispatchItems";
        public static string ErrStockNotFound = "errStockNotFound";
        public static string ErrProductWithoutStock = "errProductWithoutStock";
        public static string ErrOfficeAllReadyExist = "errOfficeAllReadyExist";
        public static string ErrUserOrPass = "errUserOrPass";
    }
}
