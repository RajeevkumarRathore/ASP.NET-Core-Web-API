﻿using DTO.Request.CallHistory;

namespace DTO.Request.User
{
    public class GetUserRequestDto
    {
        public int StartRow { get; set; }
        public int EndRow { get; set; }
        public dynamic FilterModel { get; set; }
        public string OrderBy { set; get; }
        public string SearchText { set; get; }
        public List<SortModel> SortModel { set; get; }
        public GetUserRequestDto()
        {
            SortModel = new List<SortModel>();
        }
    }
}
