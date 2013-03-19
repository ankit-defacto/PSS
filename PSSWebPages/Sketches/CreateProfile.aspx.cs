using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConcordMfg.PremierSeniorSolutions.WebService.BusinessEntities;
using ConcordMfg.PremierSeniorSolutions.WebService.BusinessLogic;

namespace PSSWebPages.Sketches
{
	public partial class CreateProfile : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void submitButton_click(object sender, EventArgs e)
		{
			InsertData();
		}

		private void InsertData()
		{
			CityStateZip cityStateZip = new CityStateZip();
			cityStateZip.City = acctCity.Text;
			cityStateZip.State = acctState.Text;
			cityStateZip.ZipCode = acctZipCode.Text;
			CityStateZipLogic cszLogic = new CityStateZipLogic();
			cityStateZip = cszLogic.InsertCityStateZip(cityStateZip);

			PaymentInfo paymentInfo = new PaymentInfo();
			paymentInfo.AmazonToken = "test";
			PaymentInfoLogic piLogic = new PaymentInfoLogic();
			paymentInfo = piLogic.InsertPaymentInfo(paymentInfo);

			Client client = new Client();
			client.ClientName = acctCompanyName.Text;
			client.PhoneNumber = acctPhoneNumber.Text;
			client.Email = acctEmail.Text;
			client.Address = acctAddress.Text;
			client.CityStateZipGuid = cityStateZip.CityStateZipGuid;
			client.PaymentInfoGuid = paymentInfo.PaymentInfoGuid;
			ClientLogic clientLogic = new ClientLogic();
			client = clientLogic.InsertClient(client);

			Response.Redirect(string.Format("CreateListing.aspx?ClientGuid={0}", client.ClientGuid));
		}
	}
}