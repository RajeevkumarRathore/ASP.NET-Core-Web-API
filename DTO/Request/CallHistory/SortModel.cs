namespace DTO.Request.CallHistory
{
    public class SortModel
    {
        public string ColId { set; get; }
        public string Sort { set; get; }

        public SortModel() { }

        public SortModel(string colId, string sort)
        {
            ColId = colId;
            Sort = sort;
        }
    }
}
