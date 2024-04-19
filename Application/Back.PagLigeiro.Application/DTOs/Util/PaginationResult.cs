using System;

namespace Back.FlashFood.Application.DTOs.Util
{
    public class PaginationResult<T>
    {
        public PaginationResult(T data, int totalItem, int page, int pageSize)
        {
            TotalItem = totalItem;
            TotalPage = totalItem > 0
                ? pageSize > 0 ? (int)Math.Ceiling((double)totalItem / pageSize) : 1
                : 0;
            Page = page;
            Data = data;
        }

        public PaginationResult()
        {
            TotalItem = 0;
            TotalPage = 0;
            Page = 0;
            Data = default;
        }

        public int TotalItem { get; set; }
        public int TotalPage { get; set; }
        public int Page { get; set; }
        public T Data { get; set; }
    }
}
