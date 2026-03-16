using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.DTOs.ApiResponse
{
    public class ApiResponseDto<T>
    {
        public bool Success { get; set; }
        public int Status { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string>? Errors { get; set; }

        public  object?  paginacion { get; set; }

      public ApiResponseDto()
       {
       
       }
    }
}
