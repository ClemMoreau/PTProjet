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

namespace ProjetTask_2.Data
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Programming_Technologies")]
	public partial class DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Définitions de méthodes d'extensibilité
    partial void OnCreated();
    partial void InsertCatalog(Catalog instance);
    partial void UpdateCatalog(Catalog instance);
    partial void DeleteCatalog(Catalog instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertEvent(Event instance);
    partial void UpdateEvent(Event instance);
    partial void DeleteEvent(Event instance);
    partial void InsertState(State instance);
    partial void UpdateState(State instance);
    partial void DeleteState(State instance);
    #endregion
		
		public DataContext() : 
				base(global::ProjetTask_2.Properties.Settings.Default.Programming_TechnologiesConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Catalog> Catalog
		{
			get
			{
				return this.GetTable<Catalog>();
			}
		}
		
		public System.Data.Linq.Table<User> User
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<Event> Event
		{
			get
			{
				return this.GetTable<Event>();
			}
		}
		
		public System.Data.Linq.Table<State> State
		{
			get
			{
				return this.GetTable<State>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.catalog")]
	public partial class Catalog : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _author;
		
		private string _title;
		
		private EntitySet<State> _state;
		
    #region Définitions de méthodes d'extensibilité
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnauthorChanging(string value);
    partial void OnauthorChanged();
    partial void OntitleChanging(string value);
    partial void OntitleChanged();
    #endregion
		
		public Catalog()
		{
			this._state = new EntitySet<State>(new Action<State>(this.attach_state), new Action<State>(this.detach_state));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_author", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string author
		{
			get
			{
				return this._author;
			}
			set
			{
				if ((this._author != value))
				{
					this.OnauthorChanging(value);
					this.SendPropertyChanging();
					this._author = value;
					this.SendPropertyChanged("author");
					this.OnauthorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_title", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string title
		{
			get
			{
				return this._title;
			}
			set
			{
				if ((this._title != value))
				{
					this.OntitleChanging(value);
					this.SendPropertyChanging();
					this._title = value;
					this.SendPropertyChanged("title");
					this.OntitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Catalog_State", Storage="_state", ThisKey="id", OtherKey="book")]
		public EntitySet<State> State
		{
			get
			{
				return this._state;
			}
			set
			{
				this._state.Assign(value);
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
		
		private void attach_state(State entity)
		{
			this.SendPropertyChanging();
			entity.Catalog = this;
		}
		
		private void detach_state(State entity)
		{
			this.SendPropertyChanging();
			entity.Catalog = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.person")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _name;
		
		private string _surname;
		
		private EntitySet<Event> _action;
		
    #region Définitions de méthodes d'extensibilité
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnsurnameChanging(string value);
    partial void OnsurnameChanged();
    #endregion
		
		public User()
		{
			this._action = new EntitySet<Event>(new Action<Event>(this.attach_action), new Action<Event>(this.detach_action));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_surname", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string surname
		{
			get
			{
				return this._surname;
			}
			set
			{
				if ((this._surname != value))
				{
					this.OnsurnameChanging(value);
					this.SendPropertyChanging();
					this._surname = value;
					this.SendPropertyChanged("surname");
					this.OnsurnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Event", Storage="_action", ThisKey="id", OtherKey="personId")]
		public EntitySet<Event> Event
		{
			get
			{
				return this._action;
			}
			set
			{
				this._action.Assign(value);
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
		
		private void attach_action(Event entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_action(Event entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.action")]
	public partial class Event : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _description;
		
		private int _stateId;
		
		private int _personId;
		
		private EntityRef<User> _person;
		
		private EntityRef<State> _state;
		
    #region Définitions de méthodes d'extensibilité
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OndescriptionChanging(string value);
    partial void OndescriptionChanged();
    partial void OnstateIdChanging(int value);
    partial void OnstateIdChanged();
    partial void OnpersonIdChanging(int value);
    partial void OnpersonIdChanged();
    #endregion
		
		public Event()
		{
			this._person = default(EntityRef<User>);
			this._state = default(EntityRef<State>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_description", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this.OndescriptionChanging(value);
					this.SendPropertyChanging();
					this._description = value;
					this.SendPropertyChanged("description");
					this.OndescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_stateId", DbType="Int NOT NULL")]
		public int stateId
		{
			get
			{
				return this._stateId;
			}
			set
			{
				if ((this._stateId != value))
				{
					if (this._state.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnstateIdChanging(value);
					this.SendPropertyChanging();
					this._stateId = value;
					this.SendPropertyChanged("stateId");
					this.OnstateIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_personId", DbType="Int NOT NULL")]
		public int personId
		{
			get
			{
				return this._personId;
			}
			set
			{
				if ((this._personId != value))
				{
					if (this._person.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnpersonIdChanging(value);
					this.SendPropertyChanging();
					this._personId = value;
					this.SendPropertyChanged("personId");
					this.OnpersonIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Event", Storage="_person", ThisKey="personId", OtherKey="id", IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._person.Entity;
			}
			set
			{
				User previousValue = this._person.Entity;
				if (((previousValue != value) 
							|| (this._person.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._person.Entity = null;
						previousValue.Event.Remove(this);
					}
					this._person.Entity = value;
					if ((value != null))
					{
						value.Event.Add(this);
						this._personId = value.id;
					}
					else
					{
						this._personId = default(int);
					}
					this.SendPropertyChanged("User");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="State_Event", Storage="_state", ThisKey="stateId", OtherKey="id", IsForeignKey=true)]
		public State State
		{
			get
			{
				return this._state.Entity;
			}
			set
			{
				State previousValue = this._state.Entity;
				if (((previousValue != value) 
							|| (this._state.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._state.Entity = null;
						previousValue.Event.Remove(this);
					}
					this._state.Entity = value;
					if ((value != null))
					{
						value.Event.Add(this);
						this._stateId = value.id;
					}
					else
					{
						this._stateId = default(int);
					}
					this.SendPropertyChanged("State");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.state")]
	public partial class State : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _book;
		
		private int _available;
		
		private EntitySet<Event> _action;
		
		private EntityRef<Catalog> _catalog;
		
    #region Définitions de méthodes d'extensibilité
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnbookChanging(int value);
    partial void OnbookChanged();
    partial void OnavailableChanging(int value);
    partial void OnavailableChanged();
    #endregion
		
		public State()
		{
			this._action = new EntitySet<Event>(new Action<Event>(this.attach_action), new Action<Event>(this.detach_action));
			this._catalog = default(EntityRef<Catalog>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_book", DbType="Int NOT NULL")]
		public int book
		{
			get
			{
				return this._book;
			}
			set
			{
				if ((this._book != value))
				{
					if (this._catalog.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnbookChanging(value);
					this.SendPropertyChanging();
					this._book = value;
					this.SendPropertyChanged("book");
					this.OnbookChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_available", DbType="Int NOT NULL")]
		public int available
		{
			get
			{
				return this._available;
			}
			set
			{
				if ((this._available != value))
				{
					this.OnavailableChanging(value);
					this.SendPropertyChanging();
					this._available = value;
					this.SendPropertyChanged("available");
					this.OnavailableChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="State_Event", Storage="_action", ThisKey="id", OtherKey="stateId")]
		public EntitySet<Event> Event
		{
			get
			{
				return this._action;
			}
			set
			{
				this._action.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Catalog_State", Storage="_catalog", ThisKey="book", OtherKey="id", IsForeignKey=true)]
		public Catalog Catalog
		{
			get
			{
				return this._catalog.Entity;
			}
			set
			{
				Catalog previousValue = this._catalog.Entity;
				if (((previousValue != value) 
							|| (this._catalog.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._catalog.Entity = null;
						previousValue.State.Remove(this);
					}
					this._catalog.Entity = value;
					if ((value != null))
					{
						value.State.Add(this);
						this._book = value.id;
					}
					else
					{
						this._book = default(int);
					}
					this.SendPropertyChanged("Catalog");
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
		
		private void attach_action(Event entity)
		{
			this.SendPropertyChanging();
			entity.State = this;
		}
		
		private void detach_action(Event entity)
		{
			this.SendPropertyChanging();
			entity.State = null;
		}
	}
}
#pragma warning restore 1591
