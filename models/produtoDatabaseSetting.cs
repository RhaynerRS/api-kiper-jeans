namespace ApiMongoDb.models
{
    public class produtoDatabaseSetting
    {
        public string? ConnectionString { get; set; } = null;
        public string? DatabaseName { get; set; } = null;
        public string? ProdutoCollectionName { get; set; } = null;
    }
}
