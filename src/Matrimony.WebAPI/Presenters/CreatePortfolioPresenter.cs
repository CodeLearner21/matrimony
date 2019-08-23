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
    public class CreatePortfolioPresenter : IOutputPort<CreatePortfolioResponse>
    {
        public JsonContentResult ContentResult { get; }

        public CreatePortfolioPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(CreatePortfolioResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
