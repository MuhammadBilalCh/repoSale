namespace DataAccess.Utill
{
	public sealed class LineaSyncStatus
	{
		public const string New = "N";
		public const string Active = "A";
		public const string Imported = "I";
		public const string Canceled = "C";
	}
    public sealed class YesOrNo
    {
        public const string Yes = "Si";
        public const string No = "No";
        public const string None = "";
    }

    public enum PageSourceType
    {
        None,
        Anos = 1000,
        PalabraClave = 2000,
        IndicadorRelate = 3000,
        IndicadorSimbologia = 4000
    }
    public enum ContentType
    {
        DataGrid = 1,
        DataForm = 2,
        SearchForm = 3,
        CustomPage = 4
    }

    public enum DataEditingMode
    {
        Inline = 1,
        Popup = 2,
        EditForm = 3,
        CustomPage = 4,
        NoEditing = 5
    }
    public enum ExceptionType
    {
        /// <summary>
        /// An uncategorized exception.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Data is invalid (string or number overflow, or datatype conversion, or (MySql) foreign key constraint)
        /// </summary>
        InvalidData,
        /// <summary>
        /// String is too long for column.
        /// </summary>
        StringTooLong,
        /// <summary>
        /// Number is invalid for column definition
        /// </summary>
        InvalidNumber,
        /// <summary>
        /// Null value not allowed in non-null column.
        /// </summary>
        Null,
        /// <summary>
        /// Duplicate value violates unique (or primary key) constraint
        /// </summary>
        UniqueConstraint,
        /// <summary>
        /// Value violates foreign key constraint
        /// </summary>
        ForeignKey,
        /// <summary>
        /// A locking error occurred
        /// </summary>
        LockFailed,
        /// <summary>
        /// Too many rows were found in sub-query.
        /// </summary>
        TooManyRows,
        /// <summary>
        /// No data was found in sub-query.
        /// </summary>
        NoDataFound,
        /// <summary>
        /// Cannot access the database.
        /// </summary>
        DatabaseNotAccessible,
        /// <summary>
        /// A custom (RAISERROR) error occurred.
        /// </summary>
        CustomException
    }

    //public static class Constants
    //{
    //    public const string AppBaseUrl = "AppBaseURL";
    //    public const string AyudaMapaUploadPath = "AyudaMapaUploadPath";
    //    public const string GaleriaMapaUploadPath = "GaleriaMapaUploadPath";
    //    public const string MapaBaseUploadPath = "MapaBaseUploadPath";
    //    public const string RoleUploadPath = "RoleUploadPath";
    //    public const string SbstaccionUploadPath = "SbstaccionUploadPath";
    //    public const string PredioChecklistUploadPath = "PredioChecklistUploadPath";
    //    public const string TempUploadPath = "TempUploadPath";
    //    public const string ConstratistaTab1DeleteMsg = "ConstratistaTab1DelMsg";
    //    public const string ConstratistaTab2DeleteMsg = "ConstratistaTab2DelMsg";
    //    public const string AtributoDeleteMsg = "AtributoDelMsg";
    //    public const string PredioExcelUploadPath = "PredioExcelUploadPath";
    //    public const string VideoUploadPath = "VideoUploadPath";
    //}

    public enum SortDirection
    {
        Ascending,
        Descending
    }
}
