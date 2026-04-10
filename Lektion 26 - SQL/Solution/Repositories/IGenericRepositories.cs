namespace Solution.Repositories
{
    public interface IGenericRepositories<tModel> where tModel : class
    {
        void Add(tModel model);
        void Remove(byte modelId);
        tModel? Get(byte modelId);
    }
}