﻿/*  Generated by CodeGen written by Concord Mfg.
 *  Transform file used: BEServiceReference (v0.1.0.0).xslt
 *  Date generated: 3/28/2012 12:46:19 PM
 *  CodeGen version: 0.1.0.0  */

using System;
using System.Runtime.Serialization;


namespace ConcordMfg.PremierSeniorSolutions.WebService.Client.ListingTypeSvc
{
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
	[System.Runtime.Serialization.DataContractAttribute(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.DataContracts/2007/01")]
	[System.SerializableAttribute()]
	public partial class ListingType : object, System.Runtime.Serialization.IExtensibleDataObject
	{
		[System.NonSerializedAttribute()]
		private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
		
		private Guid _listingTypeGuid = Guid.Empty;
		private string _listingTypeName = null;
		
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
		public Guid ListingTypeGuid
		{
			get { return _listingTypeGuid; }
			set { _listingTypeGuid = value; }
		}
	
		[System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 1)]
		public string ListingTypeName
		{
			get { return _listingTypeName; }
			set { _listingTypeName = value; }
		}
	
	}
	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
	[System.Runtime.Serialization.DataContractAttribute(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts/2007/01")]
	[System.SerializableAttribute()]
	public partial class ListingTypeFault : object, System.Runtime.Serialization.IExtensibleDataObject
	{
		[System.NonSerializedAttribute()]
		private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
		private string _errorMessage;
		
		private Guid _listingTypeGuid = Guid.Empty;
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
		public Guid ListingTypeGuid
		{
			get { return _listingTypeGuid; }
			set { _listingTypeGuid = value; }
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
	[System.ServiceModel.ServiceContractAttribute(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01", ConfigurationName = "ConcordMfg.PremierSeniorSolutions.WebService.Client.ListingTypeSvc.IListingType")]
	public interface IListingType
	{
		[System.ServiceModel.OperationContractAttribute(Action = "GetListingTypeByListingTypeGuid",
			ReplyAction = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IListingType/GetListingTypeByListingTypeGuidResponse")]
		[System.ServiceModel.FaultContractAttribute(typeof(ConcordMfg.PremierSeniorSolutions.WebService.Client.ListingTypeSvc.ListingTypeFault),
			Action = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IListingType/GetListingTypeByListingTypeGuidListingTypeFault",
			Name = "ListingTypeFault", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts/2007/01")]
		ConcordMfg.PremierSeniorSolutions.WebService.Client.ListingTypeSvc.ListingType GetListingTypeByListingTypeGuid(Guid listingTypeGuid);

		[System.ServiceModel.OperationContractAttribute(Action = "GetAllListingType",
			ReplyAction = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IListingType/GetAllListingTypeResponse")]
		[System.ServiceModel.FaultContractAttribute(typeof(ConcordMfg.PremierSeniorSolutions.WebService.Client.ListingTypeSvc.DefaultFaultContract),
			Action = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IListingType/GetAllListingTypeDefaultFaultContract",
			Name = "DefaultFaultContract", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.DataContracts/2007/01")]
		ConcordMfg.PremierSeniorSolutions.WebService.Client.ListingTypeSvc.ListingType[] GetAllListingType();

		[System.ServiceModel.OperationContractAttribute(Action = "InsertListingType",
			ReplyAction = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IListingType/InsertListingTypeResponse")]
		[System.ServiceModel.FaultContractAttribute(typeof(ConcordMfg.PremierSeniorSolutions.WebService.Client.ListingTypeSvc.DefaultFaultContract),
			Action = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IListingType/InsertListingTypeDefaultFaultContract",
			Name = "DefaultFaultContract", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.DataContracts/2007/01")]
		void InsertListingType(ConcordMfg.PremierSeniorSolutions.WebService.Client.ListingTypeSvc.ListingType listingType);

		[System.ServiceModel.OperationContractAttribute(Action = "DeleteListingType",
			ReplyAction = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IListingType/DeleteListingTypeResponse")]
		[System.ServiceModel.FaultContractAttribute(typeof(ConcordMfg.PremierSeniorSolutions.WebService.Client.ListingTypeSvc.DefaultFaultContract),
			Action = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IListingType/DeleteListingTypeDefaultFaultContract",
			Name = "DefaultFaultContract", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.DataContracts/2007/01")]
		void DeleteListingType(ConcordMfg.PremierSeniorSolutions.WebService.Client.ListingTypeSvc.ListingType listingType);

		[System.ServiceModel.OperationContractAttribute(Action = "UpdateListingType",
			ReplyAction = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IListingType/UpdateListingTypeResponse")]
		[System.ServiceModel.FaultContractAttribute(typeof(ConcordMfg.PremierSeniorSolutions.WebService.Client.ListingTypeSvc.DefaultFaultContract),
			Action = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IListingType/UpdateListingTypeDefaultFaultContract",
			Name = "DefaultFaultContract", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.DataContracts/2007/01")]
		void UpdateListingType(ConcordMfg.PremierSeniorSolutions.WebService.Client.ListingTypeSvc.ListingType listingType);

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
	public interface IListingTypeChannel : ConcordMfg.PremierSeniorSolutions.WebService.Client.ListingTypeSvc.IListingType, System.ServiceModel.IClientChannel
	{
	}

	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
	public partial class ListingTypeClient : System.ServiceModel.ClientBase<ConcordMfg.PremierSeniorSolutions.WebService.Client.ListingTypeSvc.IListingType>, ConcordMfg.PremierSeniorSolutions.WebService.Client.ListingTypeSvc.IListingType
	{
		public ListingTypeClient()
		{
		}

		public ListingTypeClient(string endpointConfigurationName)
			: base(endpointConfigurationName)
		{
		}

		public ListingTypeClient(string endpointConfigurationName, string remoteAddress)
			: base(endpointConfigurationName, remoteAddress)
		{
		}

		public ListingTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress)
			: base(endpointConfigurationName, remoteAddress)
		{
		}

		public ListingTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress)
			: base(binding, remoteAddress)
		{
		}

		public ConcordMfg.PremierSeniorSolutions.WebService.Client.ListingTypeSvc.ListingType GetListingTypeByListingTypeGuid(Guid listingTypeGuid)
		{
			return base.Channel.GetListingTypeByListingTypeGuid(listingTypeGuid);
		}

		public ConcordMfg.PremierSeniorSolutions.WebService.Client.ListingTypeSvc.ListingType[] GetAllListingType()
		{
			return base.Channel.GetAllListingType();
		}

		public void InsertListingType(ConcordMfg.PremierSeniorSolutions.WebService.Client.ListingTypeSvc.ListingType listingType)
		{
			base.Channel.InsertListingType(listingType);
		}

		public void DeleteListingType(ConcordMfg.PremierSeniorSolutions.WebService.Client.ListingTypeSvc.ListingType listingType)
		{
			base.Channel.DeleteListingType(listingType);
		}

		public void UpdateListingType(ConcordMfg.PremierSeniorSolutions.WebService.Client.ListingTypeSvc.ListingType listingType)
		{
			base.Channel.UpdateListingType(listingType);
		}

	}
}
	