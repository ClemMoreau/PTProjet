﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StructuralData
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
	
	
	public partial class LibraryCatalogDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Définitions de méthodes d'extensibilité
    partial void OnCreated();
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertCatalog(Catalog instance);
    partial void UpdateCatalog(Catalog instance);
    partial void DeleteCatalog(Catalog instance);
    partial void InsertEvent(Event instance);
    partial void UpdateEvent(Event instance);
    partial void DeleteEvent(Event instance);
    #endregion
		
		public LibraryCatalogDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}

		public LibraryCatalogDataContext() :
			base(global::StructuralData.Properties.Settings.Default.StructuralDataConnectionString, mappingSource)
        {
			OnCreated();
        }

		public LibraryCatalogDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LibraryCatalogDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LibraryCatalogDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<User> User
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<Catalog> Catalog
		{
			get
			{
				return this.GetTable<Catalog>();
			}
		}
		
		public System.Data.Linq.Table<Event> Event
		{
			get
			{
				return this.GetTable<Event>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _idUser;
		
		private string _FirstName;
		
		private string _LastName;
		
		private EntitySet<Event> _Event;
		
    #region Définitions de méthodes d'extensibilité
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidUserChanging(int value);
    partial void OnidUserChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    #endregion
		
		public User()
		{
			this._Event = new EntitySet<Event>(new Action<Event>(this.attach_Event), new Action<Event>(this.detach_Event));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idUser", IsPrimaryKey=true)]
		public int idUser
		{
			get
			{
				return this._idUser;
			}
			set
			{
				if ((this._idUser != value))
				{
					this.OnidUserChanging(value);
					this.SendPropertyChanging();
					this._idUser = value;
					this.SendPropertyChanged("idUser");
					this.OnidUserChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", CanBeNull=false)]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", CanBeNull=false)]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Event", Storage="_Event", ThisKey="idUser", OtherKey="idUser")]
		public EntitySet<Event> Event
		{
			get
			{
				return this._Event;
			}
			set
			{
				this._Event.Assign(value);
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
		
		private void attach_Event(Event entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_Event(Event entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="")]
	public partial class Catalog : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _idCatalog;
		
		private string _Author;
		
		private int _NbAvailable;
		
		private string _Title;
		
		private EntitySet<Event> _Event;
		
    #region Définitions de méthodes d'extensibilité
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidCatalogChanging(int value);
    partial void OnidCatalogChanged();
    partial void OnAuthorChanging(string value);
    partial void OnAuthorChanged();
    partial void OnNbAvailableChanging(int value);
    partial void OnNbAvailableChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    #endregion
		
		public Catalog()
		{
			this._Event = new EntitySet<Event>(new Action<Event>(this.attach_Event), new Action<Event>(this.detach_Event));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idCatalog", IsPrimaryKey=true)]
		public int idCatalog
		{
			get
			{
				return this._idCatalog;
			}
			set
			{
				if ((this._idCatalog != value))
				{
					this.OnidCatalogChanging(value);
					this.SendPropertyChanging();
					this._idCatalog = value;
					this.SendPropertyChanged("idCatalog");
					this.OnidCatalogChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Author", CanBeNull=false)]
		public string Author
		{
			get
			{
				return this._Author;
			}
			set
			{
				if ((this._Author != value))
				{
					this.OnAuthorChanging(value);
					this.SendPropertyChanging();
					this._Author = value;
					this.SendPropertyChanged("Author");
					this.OnAuthorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NbAvailable")]
		public int NbAvailable
		{
			get
			{
				return this._NbAvailable;
			}
			set
			{
				if ((this._NbAvailable != value))
				{
					this.OnNbAvailableChanging(value);
					this.SendPropertyChanging();
					this._NbAvailable = value;
					this.SendPropertyChanged("NbAvailable");
					this.OnNbAvailableChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", CanBeNull=false)]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Catalog_Event", Storage="_Event", ThisKey="idCatalog", OtherKey="idCatalog")]
		public EntitySet<Event> Event
		{
			get
			{
				return this._Event;
			}
			set
			{
				this._Event.Assign(value);
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
		
		private void attach_Event(Event entity)
		{
			this.SendPropertyChanging();
			entity.Catalog = this;
		}
		
		private void detach_Event(Event entity)
		{
			this.SendPropertyChanging();
			entity.Catalog = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="")]
	public partial class Event : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _idEvent;
		
		private int _idUser;
		
		private int _idCatalog;
		
		private string _EventType;
		
		private EntityRef<Catalog> _Catalog;
		
		private EntityRef<User> _User;
		
    #region Définitions de méthodes d'extensibilité
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidEventChanging(int value);
    partial void OnidEventChanged();
    partial void OnidUserChanging(int value);
    partial void OnidUserChanged();
    partial void OnidCatalogChanging(int value);
    partial void OnidCatalogChanged();
    partial void OnEventTypeChanging(string value);
    partial void OnEventTypeChanged();
    #endregion
		
		public Event()
		{
			this._Catalog = default(EntityRef<Catalog>);
			this._User = default(EntityRef<User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idEvent", IsPrimaryKey=true)]
		public int idEvent
		{
			get
			{
				return this._idEvent;
			}
			set
			{
				if ((this._idEvent != value))
				{
					this.OnidEventChanging(value);
					this.SendPropertyChanging();
					this._idEvent = value;
					this.SendPropertyChanged("idEvent");
					this.OnidEventChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idUser")]
		public int idUser
		{
			get
			{
				return this._idUser;
			}
			set
			{
				if ((this._idUser != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidUserChanging(value);
					this.SendPropertyChanging();
					this._idUser = value;
					this.SendPropertyChanged("idUser");
					this.OnidUserChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idCatalog")]
		public int idCatalog
		{
			get
			{
				return this._idCatalog;
			}
			set
			{
				if ((this._idCatalog != value))
				{
					if (this._Catalog.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidCatalogChanging(value);
					this.SendPropertyChanging();
					this._idCatalog = value;
					this.SendPropertyChanged("idCatalog");
					this.OnidCatalogChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EventType", CanBeNull=false)]
		public string EventType
		{
			get
			{
				return this._EventType;
			}
			set
			{
				if ((this._EventType != value))
				{
					this.OnEventTypeChanging(value);
					this.SendPropertyChanging();
					this._EventType = value;
					this.SendPropertyChanged("EventType");
					this.OnEventTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Catalog_Event", Storage="_Catalog", ThisKey="idCatalog", OtherKey="idCatalog", IsForeignKey=true)]
		public Catalog Catalog
		{
			get
			{
				return this._Catalog.Entity;
			}
			set
			{
				Catalog previousValue = this._Catalog.Entity;
				if (((previousValue != value) 
							|| (this._Catalog.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Catalog.Entity = null;
						previousValue.Event.Remove(this);
					}
					this._Catalog.Entity = value;
					if ((value != null))
					{
						value.Event.Add(this);
						this._idCatalog = value.idCatalog;
					}
					else
					{
						this._idCatalog = default(int);
					}
					this.SendPropertyChanged("Catalog");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Event", Storage="_User", ThisKey="idUser", OtherKey="idUser", IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.Event.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.Event.Add(this);
						this._idUser = value.idUser;
					}
					else
					{
						this._idUser = default(int);
					}
					this.SendPropertyChanged("User");
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