namespace Code.Repositories
{
    public interface IGenericRepositories<tModel> where tModel : class
    {
        void Add(tModel model);

        tModel? GetById(byte modelId);
        void Remove(byte modelId);
    }
}