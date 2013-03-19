﻿/*  Generated by CodeGen written by Concord Mfg
 *  Transform file used: BEViewModelCollection (v0.1.0.0).xslt
 *  Date generated: 3/28/2012 12:46:37 PM
 *  CodeGen version: 0.1.0.0  */

using System;
using System.Collections.ObjectModel;

namespace ConcordMfg.PremierSeniorSolutions.Client.ViewModels
{
	public class FacilityPhotoViewModelCollection : NotifyPropertyChangedBase
		{
		public FacilityPhotoViewModelCollection()
		{
			this.LoadAllFacilityPhotos();
		}

		public void LoadAllFacilityPhotos()
		{
			Data.Repository respository = new Data.Repository();

			try
			{
				ObservableCollection<FacilityPhoto> facilityPhotos = respository.GetAllFacilityPhotos();
			}
			catch (Exception ex)
			{
				throw ex;
			}

			try
			{
				this.FacilityPhotos = facilityPhotos.ToViewModels();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void AddFacilityPhoto(FacilityPhotoViewModel facilityPhoto)
		{
			_facilityPhotoVMs.Add(facilityPhoto);
		}

		public void RemoveFacilityPhoto(FacilityPhotoViewModel facilityPhoto)
		{
			_facilityPhotoVMs.Remove(facilityPhoto);
		}

		public ObservableCollection<FacilityPhotoViewModel> FacilityPhotos
		{
			get { return _facilityPhotoVMs; }
			private set
			{
				_facilityPhotoVMs = value;
				RaisePropertyChanged("FacilityPhotos");
			}
		}

		private ObservableCollection<FacilityPhotoViewModel> _facilityPhotoVMs = new ObservableCollection<FacilityPhotoViewModel>();
	}
}