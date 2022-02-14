using Site.Domain.Repositories.Abstract;

namespace Site.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IServiceItemsRepository serviceItems { get; set; }
        public DataManager(ITextFieldsRepository textFieldsRepository,IServiceItemsRepository serviceItemsRepository)
        {
            TextFields = textFieldsRepository;
            serviceItems = serviceItemsRepository;
        }
    }
}
