using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE = ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities;
using DA = ConcordMfg.PremierSeniorSolutions.WebService.DataAccess;
using ConcordMfg.PremierSeniorSolutions.WebService.EntityConversions;

namespace ConcordMfg.PremierSeniorSolutions.WebService.BusinessLogic
{
	public class AccountLogic
	{
		public BE.AccountViewModel GetByEmail(string email)
		{
			DA.ClientGateway clientGateway = new DA.ClientGateway();
			DA.Client client = clientGateway.GetByEmail(email);

			// Validation of client.
			if (null == client)
				return null;
			if (Guid.Empty == client.CityStateZipGuid)
				return null;
			if (Guid.Empty == client.PaymentInfoGuid)
				return null;

			DA.CityStateZipGateway cityGateway = new DA.CityStateZipGateway();
			DA.CityStateZip cityStateZip = cityGateway.GetByPK(client.CityStateZipGuid);

			// Validation of city state zip.
			if (null == cityStateZip)
				return null;

			DA.PaymentInfoGateway paymentGateway = new DA.PaymentInfoGateway();
			DA.PaymentInfo paymentInfo = paymentGateway.GetByPK(client.PaymentInfoGuid);

			// Validation of paymentInfo.
			if (null == paymentInfo)
				return null;

			BE.AccountViewModel account = EntityConversion.BuildAccountViewModel(client, cityStateZip, paymentInfo);
			return account;
		}

		public BE.AccountViewModel GetByPK(Guid accountGuid)
		{
			DA.ClientGateway clientGateway = new DA.ClientGateway();
			DA.Client client = clientGateway.GetByPK(accountGuid);

			// Validation of client.
			if (null == client)
				return null;
			if (Guid.Empty == client.CityStateZipGuid)
				return null;
			if (Guid.Empty == client.PaymentInfoGuid)
				return null;

			DA.CityStateZipGateway cityGateway = new DA.CityStateZipGateway();
			DA.CityStateZip cityStateZip = cityGateway.GetByPK(client.CityStateZipGuid);

			// Validation of city state zip.
			if (null == cityStateZip)
				return null;

			DA.PaymentInfoGateway paymentGateway = new DA.PaymentInfoGateway();
			DA.PaymentInfo paymentInfo = paymentGateway.GetByPK(client.PaymentInfoGuid);

			// Validation of paymentInfo.
			if (null == paymentInfo)
				return null;

			BE.AccountViewModel account = EntityConversion.BuildAccountViewModel(client, cityStateZip, paymentInfo);
			return account;
		}

        public IQueryable<BE.AccountViewModel> GetAll()
        {
            DA.ClientGateway clientGateway = new DA.ClientGateway();
            List<DA.Client> clients = clientGateway.GetClientList();
            List<BE.AccountViewModel> accountList = new List<BE.AccountViewModel>();
            foreach (var client in clients)
            {
                //Validation of client.
                if (null == client)
                    return null;
                if (Guid.Empty == client.CityStateZipGuid)
                    return null;
                if (Guid.Empty == client.PaymentInfoGuid)
                    return null;

                DA.CityStateZipGateway cityGateway = new DA.CityStateZipGateway();
                DA.CityStateZip cityStateZip = cityGateway.GetByPK(client.CityStateZipGuid);

                // Validation of city state zip.
                if (null == cityStateZip)
                    return null;

                DA.PaymentInfoGateway paymentGateway = new DA.PaymentInfoGateway();
                DA.PaymentInfo paymentInfo = paymentGateway.GetByPK(client.PaymentInfoGuid);

                // Validation of paymentInfo.
                if (null == paymentInfo)
                    return null;

                //Full Account of Client
                BE.AccountViewModel account = EntityConversion.BuildAccountViewModel(client, cityStateZip, paymentInfo);
                accountList.Add(account);
            }

            return accountList.AsQueryable();
        }
	}
}
