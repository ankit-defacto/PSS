﻿/*  Generated by CodeGen written by Concord Mfg.
 *  Transform file used: BEDataAccess (v0.1.0.0).xslt
 *  Date generated: 3/28/2012 12:46:17 PM
 *  CodeGen version: 0.1.0.0  */

using System;
using System.ComponentModel;
using ConcordMfg.PremierSeniorSolutions.Client.Tools;
using SP = ConcordMfg.PremierSeniorSolutions.WebService.Client;

namespace ConcordMfg.PremierSeniorSolutions.Client.ViewModels
{
	/// <summary>
	/// Access the data for the Client class.
	/// </summary>
	// [DataObject]
	public partial class DataAccess
	{
		#region Fields
		private static SP.ClientSvc.ClientClient _clientClient =
			new SP.ClientSvc.ClientClient();
		#endregion


		#region Methods
		/// <summary>
		/// Retrieves Client from the web service.
		/// </summary>
		/// <returns>A list of all client.</returns>
		[DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
		public static ClientCollection GetClients()
		{
			// Call the service for data.
			SP.ClientSvc.Client[] clients = _clientClient.GetAllClient();
			// Convert the service proxy object to a View Model object.
			ClientCollection result = new ClientCollection(clients.ToViewModels());
			return result;
		}

		/// <summary>
		/// Retrieves Client from the web service.
		/// </summary>
		/// <returns>A list of all client.</returns>
		[DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
		public static ClientCollection GetClientsWithUndefined()
		{
			// Call the service for data.
			SP.ClientSvc.Client[] clients = _clientClient.GetAllClientWithUndefined();
			// Convert the service proxy object to a View Model object.
			ClientCollection result = new ClientCollection(clients.ToViewModels());
			return result;
		}

		/// <summary>
		/// Retrieves a Client from the web service.
		/// </summary>
		/// <param name="clientGuidStr">The identifier of the Client to retrieve.</param>
		/// <returns>A Client.</returns>
		[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
		public static Client GetClient(string clientGuidStr)
		{
			// Convert the string into a guid.
			Guid clientGuid = new Guid(clientGuidStr);
			// Call the sister method.
			return GetClient(clientGuid);
		}

		/// <summary>
		/// Retrieves a Client from the web service.
		/// </summary>
		/// <param name="clientGuid">The identifier of the Client to retrieve.</param>
		/// <returns>A Client.</returns>
		[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
		public static Client GetClient(Guid clientGuid)
		{
			// Call the service for data.
			SP.ClientSvc.Client client = _clientClient.GetClientByClientGuid(clientGuid);
			// Convert and return the service proxy object to a view model object.
			return client.ToViewModel();
		}

		/// <summary>
		/// Inserts Client through the web service.
		/// </summary>
		/// <param name="client">Client to insert.</param>
		/// <returns>1, if the insert was successful; otherwise, 0.</returns>
		[DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
		public static int InsertClient(ClientViewModel client)
		{
			if (null == client)
			{
				throw new Exception("Cannot insert Client. The client object was null. Cannot be empty.");
			}

			try
			{
				// Convert the view model object to a service proxy object.
				SP.ClientSvc.Client request = client.ToModel();

				// Call the service insert method.
				_clientClient.InsertClient(request);

				return 1;
			}
			catch (System.ServiceModel.FaultException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		[DataObjectMethod(DataObjectMethodType.Insert)]
		public static int InsertClient(int clientID, string clientName, string phoneNumber, string email, string address, Guid cityStateZipGuid, Guid paymentInfoGuid, string federatedID, string federatedKey, string federatedIDProvider, string username, string hashedPassword)
		{
			try 
			{
				// Create the service proxy object and populate it.
				SP.ClientSvc.Client request = new SP.ClientSvc.Client();

				request.ClientGuid = Guid.Empty;
				request.ClientID = clientID;
				request.ClientName = clientName;
				request.PhoneNumber = phoneNumber;
				request.Email = email;
				request.Address = address;
				request.CityStateZipGuid = cityStateZipGuid;
				request.PaymentInfoGuid = paymentInfoGuid;
				request.FederatedID = federatedID;
				request.FederatedKey = federatedKey;
				request.FederatedIDProvider = federatedIDProvider;
				request.Username = username;
				request.HashedPassword = hashedPassword;

				// Call the service insert method.
				_clientClient.InsertClient(request);

				return 1;
			}
			catch (System.ServiceModel.FaultException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Updates Client through the web service.
		/// </summary>
		/// <param name="client">Client to update.</param>
		/// <returns>1, if the update was successful; otherwise, 0.</returns>
		[DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
		public static int UpdateClient(ClientViewModel client)
		{
			try
			{
				// Convert the view model object to a service proxy object.
				SP.ClientSvc.Client request = client.ToModel();

				// Call the service update method.
				_clientClient.UpdateClient(request);

				return 1;
			}
			catch (System.ServiceModel.FaultException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Deletes Client through the web service.
		/// </summary>
		/// <param name="client">Client to delete.</param>
		/// <returns>1, if the delete was successful; otherwise, 0.</returns>
		[DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
		public static int DeleteClient(ClientViewModel client)
		{
			try
			{
				// Convert the view model object to a service proxy object.
				SP.ClientSvc.Client request = client.ToModel();

				// Call the service delete method.
				_clientClient.DeleteClient(request);

				return 1;
			}
			catch (System.ServiceModel.FaultException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		#endregion


		#region CityStateZipClient Methods
		/// <summary>
		/// Retrieves Client collection for a CityStateZip from the web service.
		/// </summary>
		/// <param name="cityStateZipGuid">City State Zip Guid</param>
		/// <returns>Client collection for a cityStateZip.</returns>
		[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
		public static ClientCollection GetClientsForCityStateZipByCityStateZipGuid(Guid cityStateZipGuid)
		{
			SP.ClientSvc.Client[] clients = _clientClient.GetClientsForCityStateZipByCityStateZipGuid(cityStateZipGuid);
			ClientCollection result = new ClientCollection();
			foreach (SP.ClientSvc.Client client
				in clients)
			{
				ClientViewModel viewModel = new ClientViewModel(client.ClientGuid, client.ClientID, client.ClientName, client.PhoneNumber, client.Email, client.Address, client.CityStateZipGuid, client.PaymentInfoGuid, client.FederatedID, client.FederatedKey, client.FederatedIDProvider, client.Username, client.HashedPassword);
				result.Add(viewModel);
			}
			return result;

		}
		#endregion


		#region PaymentInfoClient Methods
		/// <summary>
		/// Retrieves Client collection for a PaymentInfo from the web service.
		/// </summary>
		/// <param name="paymentInfoGuid">Payment Info Guid</param>
		/// <returns>Client collection for a paymentInfo.</returns>
		[DataObjectMethodAttribute(DataObjectMethodType.Select, false)]
		public static ClientCollection GetClientsForPaymentInfoByPaymentInfoGuid(Guid paymentInfoGuid)
		{
			SP.ClientSvc.Client[] clients = _clientClient.GetClientsForPaymentInfoByPaymentInfoGuid(paymentInfoGuid);
			ClientCollection result = new ClientCollection();
			foreach (SP.ClientSvc.Client client
				in clients)
			{
				ClientViewModel viewModel = new ClientViewModel(client.ClientGuid, client.ClientID, client.ClientName, client.PhoneNumber, client.Email, client.Address, client.CityStateZipGuid, client.PaymentInfoGuid, client.FederatedID, client.FederatedKey, client.FederatedIDProvider, client.Username, client.HashedPassword);
				result.Add(viewModel);
			}
			return result;

		}
		#endregion

	}
}