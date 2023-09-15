namespace Web
{
    public interface IHomeViewModelService
    {
        Task<HomeViewModel> GetHomeViewModelAsync(int? categoryId, int? brandId, int pageId);
    }
}
