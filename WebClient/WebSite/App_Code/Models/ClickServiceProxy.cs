﻿/*  Generated by CodeGen written by Concord Mfg.
 *  Transform file used: BEServiceReference (v0.1.0.0).xslt
 *  Date generated: 3/28/2012 12:46:19 PM
 *  CodeGen version: 0.1.0.0  */

using System;
using System.Runtime.Serialization;


namespace ConcordMfg.PremierSeniorSolutions.WebService.Client.ClickSvc
{
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
	[System.Runtime.Serialization.DataContractAttribute(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.DataContracts/2007/01")]
	[System.SerializableAttribute()]
	public partial class Click : object, System.Runtime.Serialization.IExtensibleDataObject
	{
		[System.NonSerializedAttribute()]
		private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
		
		private Guid _clickGuid = Guid.Empty;
		private Guid _facilityGuid = Guid.Empty;
		private Guid _listingTypeGuid = Guid.Empty;
		private DateTime _timeStamp = default(DateTime);
		
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
		public Guid ClickGuid
		{
			get { return _clickGuid; }
			set { _clickGuid = value; }
		}
	
		[System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 1)]
		public Guid FacilityGuid
		{
			get { return _facilityGuid; }
			set { _facilityGuid = value; }
		}
	
		[System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 2)]
		public Guid ListingTypeGuid
		{
			get { return _listingTypeGuid; }
			set { _listingTypeGuid = value; }
		}
	
		[System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 3)]
		public DateTime TimeStamp
		{
			get { return _timeStamp; }
			set { _timeStamp = value; }
		}
	
	}
	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
	[System.Runtime.Serialization.DataContractAttribute(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts/2007/01")]
	[System.SerializableAttribute()]
	public partial class ClickFault : object, System.Runtime.Serialization.IExtensibleDataObject
	{
		[System.NonSerializedAttribute()]
		private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
		private string _errorMessage;
		
		private Guid _clickGuid = Guid.Empty;
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
		public Guid ClickGuid
		{
			get { return _clickGuid; }
			set { _clickGuid = value; }
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
	[System.ServiceModel.ServiceContractAttribute(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01", ConfigurationName = "ConcordMfg.PremierSeniorSolutions.WebService.Client.ClickSvc.IClick")]
	public interface IClick
	{
		[System.ServiceModel.OperationContractAttribute(Action = "GetClickByClickGuid",
			ReplyAction = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IClick/GetClickByClickGuidResponse")]
		[System.ServiceModel.FaultContractAttribute(typeof(ConcordMfg.PremierSeniorSolutions.WebService.Client.ClickSvc.ClickFault),
			Action = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IClick/GetClickByClickGuidClickFault",
			Name = "ClickFault", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.FaultContracts/2007/01")]
		ConcordMfg.PremierSeniorSolutions.WebService.Client.ClickSvc.Click GetClickByClickGuid(Guid clickGuid);

		[System.ServiceModel.OperationContractAttribute(Action = "GetAllClick",
			ReplyAction = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IClick/GetAllClickResponse")]
		[System.ServiceModel.FaultContractAttribute(typeof(ConcordMfg.PremierSeniorSolutions.WebService.Client.ClickSvc.DefaultFaultContract),
			Action = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IClick/GetAllClickDefaultFaultContract",
			Name = "DefaultFaultContract", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.DataContracts/2007/01")]
		ConcordMfg.PremierSeniorSolutions.WebService.Client.ClickSvc.Click[] GetAllClick();

		[System.ServiceModel.OperationContractAttribute(Action = "InsertClick",
			ReplyAction = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IClick/InsertClickResponse")]
		[System.ServiceModel.FaultContractAttribute(typeof(ConcordMfg.PremierSeniorSolutions.WebService.Client.ClickSvc.DefaultFaultContract),
			Action = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IClick/InsertClickDefaultFaultContract",
			Name = "DefaultFaultContract", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.DataContracts/2007/01")]
		void InsertClick(ConcordMfg.PremierSeniorSolutions.WebService.Client.ClickSvc.Click click);

		[System.ServiceModel.OperationContractAttribute(Action = "DeleteClick",
			ReplyAction = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IClick/DeleteClickResponse")]
		[System.ServiceModel.FaultContractAttribute(typeof(ConcordMfg.PremierSeniorSolutions.WebService.Client.ClickSvc.DefaultFaultContract),
			Action = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IClick/DeleteClickDefaultFaultContract",
			Name = "DefaultFaultContract", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.DataContracts/2007/01")]
		void DeleteClick(ConcordMfg.PremierSeniorSolutions.WebService.Client.ClickSvc.Click click);

		[System.ServiceModel.OperationContractAttribute(Action = "UpdateClick",
			ReplyAction = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IClick/UpdateClickResponse")]
		[System.ServiceModel.FaultContractAttribute(typeof(ConcordMfg.PremierSeniorSolutions.WebService.Client.ClickSvc.DefaultFaultContract),
			Action = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IClick/UpdateClickDefaultFaultContract",
			Name = "DefaultFaultContract", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.DataContracts/2007/01")]
		void UpdateClick(ConcordMfg.PremierSeniorSolutions.WebService.Client.ClickSvc.Click click);

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
	public interface IClickChannel : ConcordMfg.PremierSeniorSolutions.WebService.Client.ClickSvc.IClick, System.ServiceModel.IClientChannel
	{
	}

	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
	public partial class ClickClient : System.ServiceModel.ClientBase<ConcordMfg.PremierSeniorSolutions.WebService.Client.ClickSvc.IClick>, ConcordMfg.PremierSeniorSolutions.WebService.Client.ClickSvc.IClick
	{
		public ClickClient()
		{
		}

		public ClickClient(string endpointConfigurationName)
			: base(endpointConfigurationName)
		{
		}

		public ClickClient(string endpointConfigurationName, string remoteAddress)
			: base(endpointConfigurationName, remoteAddress)
		{
		}

		public ClickClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress)
			: base(endpointConfigurationName, remoteAddress)
		{
		}

		public ClickClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress)
			: base(binding, remoteAddress)
		{
		}

		public ConcordMfg.PremierSeniorSolutions.WebService.Client.ClickSvc.Click GetClickByClickGuid(Guid clickGuid)
		{
			return base.Channel.GetClickByClickGuid(clickGuid);
		}

		public ConcordMfg.PremierSeniorSolutions.WebService.Client.ClickSvc.Click[] GetAllClick()
		{
			return base.Channel.GetAllClick();
		}

		public void InsertClick(ConcordMfg.PremierSeniorSolutions.WebService.Client.ClickSvc.Click click)
		{
			base.Channel.InsertClick(click);
		}

		public void DeleteClick(ConcordMfg.PremierSeniorSolutions.WebService.Client.ClickSvc.Click click)
		{
			base.Channel.DeleteClick(click);
		}

		public void UpdateClick(ConcordMfg.PremierSeniorSolutions.WebService.Client.ClickSvc.Click click)
		{
			base.Channel.UpdateClick(click);
		}

	}
}
	