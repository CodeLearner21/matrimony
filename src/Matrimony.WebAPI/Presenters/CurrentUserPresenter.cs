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
    public class CurrentUserPresenter : IOutputPort<CurrentUserResponse>
    {
        public JsonContentResult ContentResult { get; }

        public CurrentUserPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        void IOutputPort<CurrentUserResponse>.Handle(CurrentUserResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
