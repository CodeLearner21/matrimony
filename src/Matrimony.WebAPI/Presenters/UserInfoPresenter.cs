using Matrimony.Core.Interfaces;
using Matrimony.Core.UseCases;
using Matrimony.WebAPI.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Matrimony.WebAPI.Presenters
{
    public class UserInfoPresenter : IOutputPort<CurrentUserUseCase>
    {
        public JsonContentResult ContentResult { get; }

        public UserInfoPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(CurrentUserUseCase response)
        {

            //ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            //ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
