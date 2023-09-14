namespace Web
{
    public interface IHomeViewModelService
    {
        Task<HomeViewModel> GetHomeViewModelAsync();
    }
}
