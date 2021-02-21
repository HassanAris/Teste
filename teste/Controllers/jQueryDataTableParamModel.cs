namespace teste.Controllers
{
    public class jQueryDataTableParamModel
    {
        /// <summary>
        /// Request sequence number sent by DataTable,
        /// same value must be returned in response
        /// </summary>       
        public string sEcho { get; set; }

        /// <summary>
        /// Text used for filtering
        /// </summary>
        public string sSearch { get; set; }

        /// <summary>
        /// Number of records that should be shown in table
        /// </summary>
        public int iDisplayLength { get; set; }

        /// <summary>
        /// First record that should be shown(used for paging)
        /// </summary>
        public int iDisplayStart { get; set; }

        /// <summary>
        /// Number of columns in table
        /// </summary>
        public int iColumns { get; set; }

        /// <summary>
        /// Number of columns that are used in sorting
        /// </summary>
        public int iSortingCols { get; set; }

        /// <summary>
        /// Comma separated list of column names
        /// </summary>
        public string sColumns { get; set; }

        /// <summary>
        /// Column being used for sorting
        /// </summary>
        public int iSortCol_0 { get; set; }

        public string sSortDir_0 { get; set; }
    }

    public class KTDataTablesPagination
    {
        public string field { get; set; }
        public int page { get; set; }
        public int pages { get; set; }
        public int perpage { get; set; }
        public string sort { get; set; }
        public int Total { get; set; }

    }

    public class KTDataTablesQuery
    {
        public string generalSearch { get; set; }
        public long[] Processos { get; set; }
        public long[] Subprocessos { get; set; }
        public long[] Cargos { get; set; }
        public long[] SegmentosMercado { get; set; }
    }

    public class KTDataTablesSort
    {
        public string sort { get; set; } = "asc";
        public string field { get; set; } = "nome";
    }


    public class KTDataTablesModel
    {
        public KTDataTablesPagination pagination { get; set; }
        public KTDataTablesQuery query { get; set; }
        public KTDataTablesSort sort { get; set; }
    }
}