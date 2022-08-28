using System;
using System.Collections.Generic;
using System.Text;

namespace Quadrion.ERP.BuildingBlocks.Application.ApiResponse
{
    public class Response<T>
    {
        public Response()
        {
        }

        public Response(T data, string message = "", bool succeeded = true)
        {
            Succeeded = succeeded;
            Message = message;
            Errors = null;
            Data = data;
        }

        public T Data { get; set; }

        public bool Succeeded { get; set; }

        public string[] Errors { get; set; }

        public string Message { get; set; }
    }
}