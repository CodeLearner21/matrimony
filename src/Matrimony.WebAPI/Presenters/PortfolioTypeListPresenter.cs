using Matrimony.Core.Dtos.UseCaseResponses;
using Matrimony.Core.Interfaces;
using Matrimony.WebAPI.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Matrimony.WebAPI.Presenters
{
    public class PortfolioTypeListPresenter : IOutputPort<GetAllPortfolioTypesResponse>
    {
        public JsonContentResult ContentResult { get; }

        public PortfolioTypeListPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        public void Handle(GetAllPortfolioTypesResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
