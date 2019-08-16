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
    public class PasswordResetPresenter : IOutputPort<PasswordResetResponse>
    {
        public JsonContentResult ContentResult { get; }

        public PasswordResetPresenter()
        {
            ContentResult = new JsonContentResult();
        }
        public void Handle(PasswordResetResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
