﻿/*  Generated by CodeGen written by Concord Mfg
 *  Transform file used: BEViewModelCollection (v0.1.0.0).xslt
 *  Date generated: 3/28/2012 12:46:37 PM
 *  CodeGen version: 0.1.0.0  */

using System;
using System.Collections.ObjectModel;

namespace ConcordMfg.PremierSeniorSolutions.Client.ViewModels
{
	public class FacilityLocationCriteriaViewModelCollection : NotifyPropertyChangedBase
		{
		public FacilityLocationCriteriaViewModelCollection()
		{
			this.LoadAllFacilityLocationCriterias();
		}

		public void LoadAllFacilityLocationCriterias()
		{
			Data.Repository respository = new Data.Repository();

			try
			{
				ObservableCollection<FacilityLocationCriteria> facilityLocationCriterias = respository.GetAllFacilityLocationCriterias();
			}
			catch (Exception ex)
			{
				throw ex;
			}

			try
			{
				this.FacilityLocationCriterias = facilityLocationCriterias.ToViewModels();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void AddFacilityLocationCriteria(FacilityLocationCriteriaViewModel facilityLocationCriteria)
		{
			_facilityLocationCriteriaVMs.Add(facilityLocationCriteria);
		}

		public void RemoveFacilityLocationCriteria(FacilityLocationCriteriaViewModel facilityLocationCriteria)
		{
			_facilityLocationCriteriaVMs.Remove(facilityLocationCriteria);
		}

		public ObservableCollection<FacilityLocationCriteriaViewModel> FacilityLocationCriterias
		{
			get { return _facilityLocationCriteriaVMs; }
			private set
			{
				_facilityLocationCriteriaVMs = value;
				RaisePropertyChanged("FacilityLocationCriterias");
			}
		}

		private ObservableCollection<FacilityLocationCriteriaViewModel> _facilityLocationCriteriaVMs = new ObservableCollection<FacilityLocationCriteriaViewModel>();
	}
}