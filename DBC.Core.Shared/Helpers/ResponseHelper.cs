﻿using DBC.Core.Shared.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBC.Core.Shared.Helpers
{
    public static class ResponseHelper
    {
        public static ResponseModel<T> CreateResponse<T>(int code, string message, string status, T data)
        {

            ResponseModel<T> response = new ResponseModel<T>();
            response.code = code;
            response.message = message;
            response.status = status;
            response.data = data;
            return response;

        }
        //public static ResponseModel<T> HandleException<T>(Exception ex)
        //{
        //    int code = 400;
        //    var w32ex = ex as Win32Exception;
        //    if (w32ex == null)
        //    {
        //        w32ex = ex.InnerException as Win32Exception;
        //    }
        //    if (w32ex != null)
        //    {
        //        code = w32ex.ErrorCode;
        //        // do stuff
        //    }
        //    ResponseModel<T> response = new ResponseModel<T>();
        //    response.code = code;
        //    response.message = ex.Message;
        //    response.status = API_STATUS.Failure.ToString();
        //    return response;

        //}
    }
}
