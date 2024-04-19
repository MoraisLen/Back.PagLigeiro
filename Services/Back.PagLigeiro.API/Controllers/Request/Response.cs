using Back.FlashFood.Application.DTOs.Util;

namespace Back.PagLigeiro.Api.Controllers.Request
{
    public class SimpleResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public Meta? Meta { get; set; }

        public SimpleResponse()
        { }

        public SimpleResponse(bool success, T data, int Page, int TotalPage, int TotalItem)
        {
            Success = success;
            Data = data;
            Meta = new Meta
            {
                Page = Page,
                TotalPage = TotalPage,
                TotalItem = TotalItem
            };
        }

        public SimpleResponse(bool success, T data)
        {
            Success = success;
            Data = data;
        }

        public SimpleResponse(bool data)
        {
            Success = data;
        }

        public SimpleResponse(T data)
        {
            Success = data != null;
            Data = data;
        }

        public SimpleResponse(PaginationResult<T> pagination)
        {
            Success = true;
            Data = pagination.Data;
            Meta = new Meta
            {
                Page = pagination.Page,
                TotalItem = pagination.TotalItem,
                TotalPage = pagination.TotalPage
            };
        }

    }

    public class Meta
    {
        public int TotalItem { get; set; }
        public int TotalPage { get; set; }
        public int Page { get; set; }
    }
}
