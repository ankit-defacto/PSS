using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConcordMfg.PremierSeniorSolutions.WebService.DataAccess
{
    public interface iClientCardInfoGateway
    {
        ClientCardInfo Insert(ClientCardInfo entity);
        void Update(ClientCardInfo entity);
        ClientCardInfo GetByClientGuid(Guid clientGuid);
    }
}
