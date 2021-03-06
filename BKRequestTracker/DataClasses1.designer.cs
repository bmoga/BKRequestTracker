﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BKRequestTracker
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Northwind")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Inserttbl_request_catagory_001(tbl_request_catagory_001 instance);
    partial void Updatetbl_request_catagory_001(tbl_request_catagory_001 instance);
    partial void Deletetbl_request_catagory_001(tbl_request_catagory_001 instance);
    partial void Inserttbl_instructions_001(tbl_instructions_001 instance);
    partial void Updatetbl_instructions_001(tbl_instructions_001 instance);
    partial void Deletetbl_instructions_001(tbl_instructions_001 instance);
    partial void Inserttbl_request_001(tbl_request_001 instance);
    partial void Updatetbl_request_001(tbl_request_001 instance);
    partial void Deletetbl_request_001(tbl_request_001 instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::BKRequestTracker.Properties.Settings.Default.NorthwindConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<tbl_request_catagory_001> tbl_request_catagory_001s
		{
			get
			{
				return this.GetTable<tbl_request_catagory_001>();
			}
		}
		
		public System.Data.Linq.Table<tbl_instructions_001> tbl_instructions_001s
		{
			get
			{
				return this.GetTable<tbl_instructions_001>();
			}
		}
		
		public System.Data.Linq.Table<tbl_request_001> tbl_request_001s
		{
			get
			{
				return this.GetTable<tbl_request_001>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbl_request_catagory_001")]
	public partial class tbl_request_catagory_001 : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _catagory_id;
		
		private string _catagory_description;
		
		private EntitySet<tbl_request_001> _tbl_request_001s;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Oncatagory_idChanging(int value);
    partial void Oncatagory_idChanged();
    partial void Oncatagory_descriptionChanging(string value);
    partial void Oncatagory_descriptionChanged();
    #endregion
		
		public tbl_request_catagory_001()
		{
			this._tbl_request_001s = new EntitySet<tbl_request_001>(new Action<tbl_request_001>(this.attach_tbl_request_001s), new Action<tbl_request_001>(this.detach_tbl_request_001s));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_catagory_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int catagory_id
		{
			get
			{
				return this._catagory_id;
			}
			set
			{
				if ((this._catagory_id != value))
				{
					this.Oncatagory_idChanging(value);
					this.SendPropertyChanging();
					this._catagory_id = value;
					this.SendPropertyChanged("catagory_id");
					this.Oncatagory_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_catagory_description", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string catagory_description
		{
			get
			{
				return this._catagory_description;
			}
			set
			{
				if ((this._catagory_description != value))
				{
					this.Oncatagory_descriptionChanging(value);
					this.SendPropertyChanging();
					this._catagory_description = value;
					this.SendPropertyChanged("catagory_description");
					this.Oncatagory_descriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tbl_request_catagory_001_tbl_request_001", Storage="_tbl_request_001s", ThisKey="catagory_id", OtherKey="request_catagory")]
		public EntitySet<tbl_request_001> tbl_request_001s
		{
			get
			{
				return this._tbl_request_001s;
			}
			set
			{
				this._tbl_request_001s.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_tbl_request_001s(tbl_request_001 entity)
		{
			this.SendPropertyChanging();
			entity.tbl_request_catagory_001 = this;
		}
		
		private void detach_tbl_request_001s(tbl_request_001 entity)
		{
			this.SendPropertyChanging();
			entity.tbl_request_catagory_001 = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbl_instructions_001")]
	public partial class tbl_instructions_001 : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _instruction_id;
		
		private string _column_name;
		
		private string _instruction_description;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Oninstruction_idChanging(int value);
    partial void Oninstruction_idChanged();
    partial void Oncolumn_nameChanging(string value);
    partial void Oncolumn_nameChanged();
    partial void Oninstruction_descriptionChanging(string value);
    partial void Oninstruction_descriptionChanged();
    #endregion
		
		public tbl_instructions_001()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_instruction_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int instruction_id
		{
			get
			{
				return this._instruction_id;
			}
			set
			{
				if ((this._instruction_id != value))
				{
					this.Oninstruction_idChanging(value);
					this.SendPropertyChanging();
					this._instruction_id = value;
					this.SendPropertyChanged("instruction_id");
					this.Oninstruction_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_column_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string column_name
		{
			get
			{
				return this._column_name;
			}
			set
			{
				if ((this._column_name != value))
				{
					this.Oncolumn_nameChanging(value);
					this.SendPropertyChanging();
					this._column_name = value;
					this.SendPropertyChanged("column_name");
					this.Oncolumn_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_instruction_description", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string instruction_description
		{
			get
			{
				return this._instruction_description;
			}
			set
			{
				if ((this._instruction_description != value))
				{
					this.Oninstruction_descriptionChanging(value);
					this.SendPropertyChanging();
					this._instruction_description = value;
					this.SendPropertyChanged("instruction_description");
					this.Oninstruction_descriptionChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tbl_request_001")]
	public partial class tbl_request_001 : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _request_id;
		
		private System.DateTime _request_date;
		
		private string _request_user;
		
		private string _request_description;
		
		private int _request_catagory;
		
		private System.DateTime _date_needed_by;
		
		private EntityRef<tbl_request_catagory_001> _tbl_request_catagory_001;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onrequest_idChanging(int value);
    partial void Onrequest_idChanged();
    partial void Onrequest_dateChanging(System.DateTime value);
    partial void Onrequest_dateChanged();
    partial void Onrequest_userChanging(string value);
    partial void Onrequest_userChanged();
    partial void Onrequest_descriptionChanging(string value);
    partial void Onrequest_descriptionChanged();
    partial void Onrequest_catagoryChanging(int value);
    partial void Onrequest_catagoryChanged();
    partial void Ondate_needed_byChanging(System.DateTime value);
    partial void Ondate_needed_byChanged();
    #endregion
		
		public tbl_request_001()
		{
			this._tbl_request_catagory_001 = default(EntityRef<tbl_request_catagory_001>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_request_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int request_id
		{
			get
			{
				return this._request_id;
			}
			set
			{
				if ((this._request_id != value))
				{
					this.Onrequest_idChanging(value);
					this.SendPropertyChanging();
					this._request_id = value;
					this.SendPropertyChanged("request_id");
					this.Onrequest_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_request_date", DbType="DateTime NOT NULL")]
		public System.DateTime request_date
		{
			get
			{
				return this._request_date;
			}
			set
			{
				if ((this._request_date != value))
				{
					this.Onrequest_dateChanging(value);
					this.SendPropertyChanging();
					this._request_date = value;
					this.SendPropertyChanged("request_date");
					this.Onrequest_dateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_request_user", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
		public string request_user
		{
			get
			{
				return this._request_user;
			}
			set
			{
				if ((this._request_user != value))
				{
					this.Onrequest_userChanging(value);
					this.SendPropertyChanging();
					this._request_user = value;
					this.SendPropertyChanged("request_user");
					this.Onrequest_userChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_request_description", DbType="VarChar(1000) NOT NULL", CanBeNull=false)]
		public string request_description
		{
			get
			{
				return this._request_description;
			}
			set
			{
				if ((this._request_description != value))
				{
					this.Onrequest_descriptionChanging(value);
					this.SendPropertyChanging();
					this._request_description = value;
					this.SendPropertyChanged("request_description");
					this.Onrequest_descriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_request_catagory", DbType="Int NOT NULL")]
		public int request_catagory
		{
			get
			{
				return this._request_catagory;
			}
			set
			{
				if ((this._request_catagory != value))
				{
					if (this._tbl_request_catagory_001.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onrequest_catagoryChanging(value);
					this.SendPropertyChanging();
					this._request_catagory = value;
					this.SendPropertyChanged("request_catagory");
					this.Onrequest_catagoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date_needed_by", DbType="DateTime NOT NULL")]
		public System.DateTime date_needed_by
		{
			get
			{
				return this._date_needed_by;
			}
			set
			{
				if ((this._date_needed_by != value))
				{
					this.Ondate_needed_byChanging(value);
					this.SendPropertyChanging();
					this._date_needed_by = value;
					this.SendPropertyChanged("date_needed_by");
					this.Ondate_needed_byChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tbl_request_catagory_001_tbl_request_001", Storage="_tbl_request_catagory_001", ThisKey="request_catagory", OtherKey="catagory_id", IsForeignKey=true)]
		public tbl_request_catagory_001 tbl_request_catagory_001
		{
			get
			{
				return this._tbl_request_catagory_001.Entity;
			}
			set
			{
				tbl_request_catagory_001 previousValue = this._tbl_request_catagory_001.Entity;
				if (((previousValue != value) 
							|| (this._tbl_request_catagory_001.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tbl_request_catagory_001.Entity = null;
						previousValue.tbl_request_001s.Remove(this);
					}
					this._tbl_request_catagory_001.Entity = value;
					if ((value != null))
					{
						value.tbl_request_001s.Add(this);
						this._request_catagory = value.catagory_id;
					}
					else
					{
						this._request_catagory = default(int);
					}
					this.SendPropertyChanged("tbl_request_catagory_001");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
