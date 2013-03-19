﻿/*  Generated by CodeGen written by Concord Mfg.
 *  Transform file used: BEServiceReference (v0.1.0.0).xslt
 *  Date generated: 3/28/2012 12:46:19 PM
 *  CodeGen version: 0.1.0.0  */

using System;
using System.Runtime.Serialization;


namespace ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityAuditSvc
{
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
	[System.Runtime.Serialization.DataContractAttribute(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.DataContracts/2007/01")]
	[System.SerializableAttribute()]
	public partial class FacilityAudit : object, System.Runtime.Serialization.IExtensibleDataObject
	{
		[System.NonSerializedAttribute()]
		private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
		
		private Guid _facilityAuditGuid = Guid.Empty;
		private Guid _facilityGuid = Guid.Empty;
		private int _facilityID = 0;
		private string _facilityName = null;
		private string _exerpt = null;
		private string _description = null;
		private string _address = null;
		private Guid _cityStateZipGuid = Guid.Empty;
		private string _phoneNumber = null;
		private string _email = null;
		private string _website = null;
		private Guid _clientGuid = Guid.Empty;
		private Guid _listingTypeGuid = Guid.Empty;
		private string _publicPhotoFileUri = null;
		private DateTime _dateModified = default(DateTime);
		
		public System.Runtime.Serialization.ExtensionDataObject ExtensionData
		{
			get
			{
				return this.extensionDataField;
			}
			set
			{
				this.extensionDataField = value;
			}
		}
		
		[System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 0)]
		public Guid FacilityAuditGuid
		{
			get { return _facilityAuditGuid; }
			set { _facilityAuditGuid = value; }
		}
	
		[System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 1)]
		public Guid FacilityGuid
		{
			get { return _facilityGuid; }
			set { _facilityGuid = value; }
		}
	
		[System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 2)]
		public int FacilityID
		{
			get { return _facilityID; }
			set { _facilityID = value; }
		}
	
		[System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 3)]
		public string FacilityName
		{
			get { return _facilityName; }
			set { _facilityName = value; }
		}
	
		[System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 4)]
		public string Exerpt
		{
			get { return _exerpt; }
			set { _exerpt = value; }
		}
	
		[System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 5)]
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}
	
		[System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 6)]
		public string Address
		{
			get { return _address; }
			set { _address = value; }
		}
	
		[System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 7)]
		public Guid CityStateZipGuid
		{
			get { return _cityStateZipGuid; }
			set { _cityStateZipGuid = value; }
		}
	
		[System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 8)]
		public string PhoneNumber
		{
			get { return _phoneNumber; }
			set { _phoneNumber = value; }
		}
	
		[System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 9)]
		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}
	
		[System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 10)]
		public string Website
		{
			get { return _website; }
			set { _website = value; }
		}
	
		[System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 11)]
		public Guid ClientGuid
		{
			get { return _clientGuid; }
			set { _clientGuid = value; }
		}
	
		[System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 12)]
		public Guid ListingTypeGuid
		{
			get { return _listingTypeGuid; }
			set { _listingTypeGuid = value; }
		}
	
		[System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 13)]
		public string PublicPhotoFileUri
		{
			get { return _publicPhotoFileUri; }
			set { _publicPhotoFileUri = value; }
		}
	
		[System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 14)]
		public DateTime DateModified
		{
			get { return _dateModified; }
			set { _dateModified = value; }
		}
	
	}
	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
	[System.Runtime.Serialization.DataContractAttribute(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts/2007/01")]
	[System.SerializableAttribute()]
	public partial class FacilityAuditFault : object, System.Runtime.Serialization.IExtensibleDataObject
	{
		[System.NonSerializedAttribute()]
		private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
		private string _errorMessage;
		
		private Guid _facilityAuditGuid = Guid.Empty;
		public System.Runtime.Serialization.ExtensionDataObject ExtensionData
		{
			get
			{
				return this.extensionDataField;
			}
			set
			{
				this.extensionDataField = value;
			}
		}
		
		[System.Runtime.Serialization.DataMemberAttribute(IsRequired = true)]
		public string ErrorMessage
		{
			get
			{
				return this._errorMessage;
			}
			set
			{
				this._errorMessage = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute(IsRequired = true)]
		public Guid FacilityAuditGuid
		{
			get { return _facilityAuditGuid; }
			set { _facilityAuditGuid = value; }
		}
	
	}
	

	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
	[System.Runtime.Serialization.DataContractAttribute(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.DataContracts/2007/01")]
	[System.SerializableAttribute()]
	public partial class DefaultFaultContract : object, System.Runtime.Serialization.IExtensibleDataObject
	{
		[System.NonSerializedAttribute()]
		private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

		private int ErrorIdField;

		private string ErrorMessageField;

		private System.Guid CorrelationIdField;

		public System.Runtime.Serialization.ExtensionDataObject ExtensionData
		{
			get
			{
				return this.extensionDataField;
			}
			set
			{
				this.extensionDataField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute(IsRequired = true)]
		public int ErrorId
		{
			get
			{
				return this.ErrorIdField;
			}
			set
			{
				this.ErrorIdField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute(IsRequired = true)]
		public string ErrorMessage
		{
			get
			{
				return this.ErrorMessageField;
			}
			set
			{
				this.ErrorMessageField = value;
			}
		}

		[System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 2)]
		public System.Guid CorrelationId
		{
			get
			{
				return this.CorrelationIdField;
			}
			set
			{
				this.CorrelationIdField = value;
			}
		}
	}
	


	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
	[System.ServiceModel.ServiceContractAttribute(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01", ConfigurationName = "ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityAuditSvc.IFacilityAudit")]
	public interface IFacilityAudit
	{
		[System.ServiceModel.OperationContractAttribute(Action = "GetFacilityAuditByFacilityAuditGuid",
			ReplyAction = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IFacilityAudit/GetFacilityAuditByFacilityAuditGuidResponse")]
		[System.ServiceModel.FaultContractAttribute(typeof(ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityAuditSvc.FacilityAuditFault),
			Action = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IFacilityAudit/GetFacilityAuditByFacilityAuditGuidFacilityAuditFault",
			Name = "FacilityAuditFault", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts/2007/01")]
		ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityAuditSvc.FacilityAudit GetFacilityAuditByFacilityAuditGuid(Guid facilityAuditGuid);

		[System.ServiceModel.OperationContractAttribute(Action = "GetAllFacilityAudit",
			ReplyAction = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IFacilityAudit/GetAllFacilityAuditResponse")]
		[System.ServiceModel.FaultContractAttribute(typeof(ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityAuditSvc.DefaultFaultContract),
			Action = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IFacilityAudit/GetAllFacilityAuditDefaultFaultContract",
			Name = "DefaultFaultContract", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.DataContracts/2007/01")]
		ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityAuditSvc.FacilityAudit[] GetAllFacilityAudit();

		[System.ServiceModel.OperationContractAttribute(Action = "InsertFacilityAudit",
			ReplyAction = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IFacilityAudit/InsertFacilityAuditResponse")]
		[System.ServiceModel.FaultContractAttribute(typeof(ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityAuditSvc.DefaultFaultContract),
			Action = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IFacilityAudit/InsertFacilityAuditDefaultFaultContract",
			Name = "DefaultFaultContract", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.DataContracts/2007/01")]
		void InsertFacilityAudit(ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityAuditSvc.FacilityAudit facilityAudit);

		[System.ServiceModel.OperationContractAttribute(Action = "DeleteFacilityAudit",
			ReplyAction = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IFacilityAudit/DeleteFacilityAuditResponse")]
		[System.ServiceModel.FaultContractAttribute(typeof(ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityAuditSvc.DefaultFaultContract),
			Action = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IFacilityAudit/DeleteFacilityAuditDefaultFaultContract",
			Name = "DefaultFaultContract", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.DataContracts/2007/01")]
		void DeleteFacilityAudit(ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityAuditSvc.FacilityAudit facilityAudit);

		[System.ServiceModel.OperationContractAttribute(Action = "UpdateFacilityAudit",
			ReplyAction = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IFacilityAudit/UpdateFacilityAuditResponse")]
		[System.ServiceModel.FaultContractAttribute(typeof(ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityAuditSvc.DefaultFaultContract),
			Action = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IFacilityAudit/UpdateFacilityAuditDefaultFaultContract",
			Name = "DefaultFaultContract", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.DataContracts/2007/01")]
		void UpdateFacilityAudit(ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityAuditSvc.FacilityAudit facilityAudit);

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
	public interface IFacilityAuditChannel : ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityAuditSvc.IFacilityAudit, System.ServiceModel.IClientChannel
	{
	}

	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
	public partial class FacilityAuditClient : System.ServiceModel.ClientBase<ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityAuditSvc.IFacilityAudit>, ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityAuditSvc.IFacilityAudit
	{
		public FacilityAuditClient()
		{
		}

		public FacilityAuditClient(string endpointConfigurationName)
			: base(endpointConfigurationName)
		{
		}

		public FacilityAuditClient(string endpointConfigurationName, string remoteAddress)
			: base(endpointConfigurationName, remoteAddress)
		{
		}

		public FacilityAuditClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress)
			: base(endpointConfigurationName, remoteAddress)
		{
		}

		public FacilityAuditClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress)
			: base(binding, remoteAddress)
		{
		}

		public ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityAuditSvc.FacilityAudit GetFacilityAuditByFacilityAuditGuid(Guid facilityAuditGuid)
		{
			return base.Channel.GetFacilityAuditByFacilityAuditGuid(facilityAuditGuid);
		}

		public ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityAuditSvc.FacilityAudit[] GetAllFacilityAudit()
		{
			return base.Channel.GetAllFacilityAudit();
		}

		public void InsertFacilityAudit(ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityAuditSvc.FacilityAudit facilityAudit)
		{
			base.Channel.InsertFacilityAudit(facilityAudit);
		}

		public void DeleteFacilityAudit(ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityAuditSvc.FacilityAudit facilityAudit)
		{
			base.Channel.DeleteFacilityAudit(facilityAudit);
		}

		public void UpdateFacilityAudit(ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityAuditSvc.FacilityAudit facilityAudit)
		{
			base.Channel.UpdateFacilityAudit(facilityAudit);
		}

	}
}
	