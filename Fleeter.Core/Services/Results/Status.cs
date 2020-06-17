using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fleeter.Core.Services.Results
{
    public enum Status
    {
        Ok,
        Created,
        Updated,
        Deleted,
        NotFound,
        BadRequest,
        InvalidCredentials,
        Unauthorized,
        Conflict,
        InternalServerError,
        Cascade
    }
}
