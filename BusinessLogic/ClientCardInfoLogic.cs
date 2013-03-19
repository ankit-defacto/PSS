using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BE = ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities;
using DA = ConcordMfg.PremierSeniorSolutions.WebService.DataAccess;
using ConcordMfg.PremierSeniorSolutions.WebService.EntityConversions;
namespace ConcordMfg.PremierSeniorSolutions.WebService.BusinessLogic
{
    public class ClientCardInfoLogic
    {

        #region Public CRUD Methods

        public BE.ClientCardInfo GetByClientGuid(Guid clientGuid)
        {
            DA.ClientCardInfoGateway gateway = new DA.ClientCardInfoGateway();
            var clientCardInfo = gateway.GetByClientGuid(clientGuid);
            if (clientCardInfo == null)
                return null;
            BE.ClientCardInfo result = new BE.ClientCardInfo();
            result = clientCardInfo.ToBusinessEntity();
            return result;
        }

        public BE.ClientCardInfo InsertClientCardInfo(BE.ClientCardInfo entity)
        {
            DA.ClientCardInfoGateway gateway = new DA.ClientCardInfoGateway();
            DA.ClientCardInfo result = gateway.Insert(entity.ToDataEntity());
            return result.ToBusinessEntity();
        }

        public void UpdateClientCardInfo(BE.ClientCardInfo entity)
        {
            DA.ClientCardInfoGateway gateway = new DA.ClientCardInfoGateway();
            gateway.Update(entity.ToDataEntity());
        }

        #endregion

    }
}
