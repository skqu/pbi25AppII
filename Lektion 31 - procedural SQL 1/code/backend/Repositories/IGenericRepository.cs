using Microsoft.EntityFrameworkCore;

namespace Solution.Repositories
{
    interface IGenericRepostirory<tModel> where tModel : class
    {
        void CreateEntry(tModel model);
        List<tModel>? GetEntries();
        void UpdateEntry(tModel newModel);
        void DeleteEntry(tModel model);



    }

}