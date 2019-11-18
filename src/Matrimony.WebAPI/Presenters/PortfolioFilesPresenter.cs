using Matrimony.Core.Dtos.UseCaseResponses;
using Matrimony.Core.Interfaces;
using Matrimony.WebAPI.Serialization;
using System.Net;

namespace Matrimony.WebAPI.Presenters
{
    public class PortfolioFilesPresenter : IOutputPort<GetFilesByPortfolioIdResponse>
    {
        public JsonContentResult ContentResult { get; }

        public PortfolioFilesPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        void IOutputPort<GetFilesByPortfolioIdResponse>.Handle(GetFilesByPortfolioIdResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }

}
