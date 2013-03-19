﻿/*  Generated by CodeGen written by Concord Mfg.
 *  Transform file used: BEServiceReference (v0.1.0.0).xslt
 *  Date generated: 3/28/2012 12:46:19 PM
 *  CodeGen version: 0.1.0.0  */

using System;
using System.Runtime.Serialization;


namespace ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityLocationCriteriaSvc
{
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
	[System.Runtime.Serialization.DataContractAttribute(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.DataContracts/2007/01")]
	[System.SerializableAttribute()]
	public partial class FacilityLocationCriteria : object, System.Runtime.Serialization.IExtensibleDataObject
	{
		[System.NonSerializedAttribute()]
		private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
		
		private Guid _facilityGuid = Guid.Empty;
		private Guid _cityStateZipGuid = Guid.Empty;
		
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
		public Guid FacilityGuid
		{
			get { return _facilityGuid; }
			set { _facilityGuid = value; }
		}
	
		[System.Runtime.Serialization.DataMemberAttribute(IsRequired = true, Order = 1)]
		public Guid CityStateZipGuid
		{
			get { return _cityStateZipGuid; }
			set { _cityStateZipGuid = value; }
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
	[System.ServiceModel.ServiceContractAttribute(Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01", ConfigurationName = "ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityLocationCriteriaSvc.IFacilityLocationCriteria")]
	public interface IFacilityLocationCriteria
	{
		[System.ServiceModel.OperationContractAttribute(Action = "GetAllFacilityLocationCriteria",
			ReplyAction = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IFacilityLocationCriteria/GetAllFacilityLocationCriteriaResponse")]
		[System.ServiceModel.FaultContractAttribute(typeof(ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityLocationCriteriaSvc.DefaultFaultContract),
			Action = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IFacilityLocationCriteria/GetAllFacilityLocationCriteriaDefaultFaultContract",
			Name = "DefaultFaultContract", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.DataContracts/2007/01")]
		ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityLocationCriteriaSvc.FacilityLocationCriteria[] GetAllFacilityLocationCriteria();

		[System.ServiceModel.OperationContractAttribute(Action = "InsertFacilityLocationCriteria",
			ReplyAction = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IFacilityLocationCriteria/InsertFacilityLocationCriteriaResponse")]
		[System.ServiceModel.FaultContractAttribute(typeof(ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityLocationCriteriaSvc.DefaultFaultContract),
			Action = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IFacilityLocationCriteria/InsertFacilityLocationCriteriaDefaultFaultContract",
			Name = "DefaultFaultContract", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.DataContracts/2007/01")]
		void InsertFacilityLocationCriteria(ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityLocationCriteriaSvc.FacilityLocationCriteria facilityLocationCriteria);

		[System.ServiceModel.OperationContractAttribute(Action = "DeleteFacilityLocationCriteria",
			ReplyAction = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IFacilityLocationCriteria/DeleteFacilityLocationCriteriaResponse")]
		[System.ServiceModel.FaultContractAttribute(typeof(ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityLocationCriteriaSvc.DefaultFaultContract),
			Action = "http://ConcordMfg.PremierSeniorSolutions.WebService.ServiceContracts/2007/01/IFacilityLocationCriteria/DeleteFacilityLocationCriteriaDefaultFaultContract",
			Name = "DefaultFaultContract", Namespace = "http://ConcordMfg.PremierSeniorSolutions.WebService.DataContracts/2007/01")]
		void DeleteFacilityLocationCriteria(ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityLocationCriteriaSvc.FacilityLocationCriteria facilityLocationCriteria);

	}

	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
	public interface IFacilityLocationCriteriaChannel : ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityLocationCriteriaSvc.IFacilityLocationCriteria, System.ServiceModel.IClientChannel
	{
	}

	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
	public partial class FacilityLocationCriteriaClient : System.ServiceModel.ClientBase<ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityLocationCriteriaSvc.IFacilityLocationCriteria>, ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityLocationCriteriaSvc.IFacilityLocationCriteria
	{
		public FacilityLocationCriteriaClient()
		{
		}

		public FacilityLocationCriteriaClient(string endpointConfigurationName)
			: base(endpointConfigurationName)
		{
		}

		public FacilityLocationCriteriaClient(string endpointConfigurationName, string remoteAddress)
			: base(endpointConfigurationName, remoteAddress)
		{
		}

		public FacilityLocationCriteriaClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress)
			: base(endpointConfigurationName, remoteAddress)
		{
		}

		public FacilityLocationCriteriaClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress)
			: base(binding, remoteAddress)
		{
		}

		public ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityLocationCriteriaSvc.FacilityLocationCriteria[] GetAllFacilityLocationCriteria()
		{
			return base.Channel.GetAllFacilityLocationCriteria();
		}

		public void InsertFacilityLocationCriteria(ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityLocationCriteriaSvc.FacilityLocationCriteria facilityLocationCriteria)
		{
			base.Channel.InsertFacilityLocationCriteria(facilityLocationCriteria);
		}

		public void DeleteFacilityLocationCriteria(ConcordMfg.PremierSeniorSolutions.WebService.Client.FacilityLocationCriteriaSvc.FacilityLocationCriteria facilityLocationCriteria)
		{
			base.Channel.DeleteFacilityLocationCriteria(facilityLocationCriteria);
		}

	}
}
	