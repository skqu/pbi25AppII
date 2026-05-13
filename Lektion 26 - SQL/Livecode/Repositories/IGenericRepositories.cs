namespace Livecode.Repositories
{
    public interface IGenericRepositories<tModel> where tModel : class
    {
        void Add(tModel model);
        tModel Get(byte modelId);
    }
}