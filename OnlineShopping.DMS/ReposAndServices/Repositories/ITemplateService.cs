namespace OnlineShopping.DMS.ReposAndServices.Repositories
{
    public interface ITemplateService
    {

        Task<string> RenderAsync<TViewModel>(string templateFileName, TViewModel viewModel);

    }
}
