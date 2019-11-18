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
    public class UserPortfolioPresenter : IOutputPort<UserPortfolioResponse>
    {
        public JsonContentResult ContentResult { get; }

        public UserPortfolioPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        void IOutputPort<UserPortfolioResponse>.Handle(UserPortfolioResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
