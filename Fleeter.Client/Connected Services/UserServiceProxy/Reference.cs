﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fleeter.Client.UserServiceProxy {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/Fleeter.Core.Models")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstnameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsAdminField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastnameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int VersionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Firstname {
            get {
                return this.FirstnameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstnameField, value) != true)) {
                    this.FirstnameField = value;
                    this.RaisePropertyChanged("Firstname");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsAdmin {
            get {
                return this.IsAdminField;
            }
            set {
                if ((this.IsAdminField.Equals(value) != true)) {
                    this.IsAdminField = value;
                    this.RaisePropertyChanged("IsAdmin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Lastname {
            get {
                return this.LastnameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastnameField, value) != true)) {
                    this.LastnameField = value;
                    this.RaisePropertyChanged("Lastname");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Version {
            get {
                return this.VersionField;
            }
            set {
                if ((this.VersionField.Equals(value) != true)) {
                    this.VersionField = value;
                    this.RaisePropertyChanged("Version");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseResult", Namespace="http://schemas.datacontract.org/2004/07/Fleeter.Core.Services.Results")]
    [System.SerializableAttribute()]
    public partial class BaseResult : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Fleeter.Client.UserServiceProxy.Status StatusField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Fleeter.Client.UserServiceProxy.Status Status {
            get {
                return this.StatusField;
            }
            set {
                if ((this.StatusField.Equals(value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Status", Namespace="http://schemas.datacontract.org/2004/07/Fleeter.Core.Services.Results")]
    public enum Status : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Ok = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Created = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Updated = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Deleted = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        NotFound = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        BadRequest = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        InvalidCredentials = 6,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Unauthorized = 7,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Conflict = 8,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        InternalServerError = 9,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Cascade = 10,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LoginResult", Namespace="http://schemas.datacontract.org/2004/07/Fleeter.Core.Services")]
    [System.SerializableAttribute()]
    public partial class LoginResult : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool SuccessField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Fleeter.Client.UserServiceProxy.User UserField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Success {
            get {
                return this.SuccessField;
            }
            set {
                if ((this.SuccessField.Equals(value) != true)) {
                    this.SuccessField = value;
                    this.RaisePropertyChanged("Success");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Fleeter.Client.UserServiceProxy.User User {
            get {
                return this.UserField;
            }
            set {
                if ((object.ReferenceEquals(this.UserField, value) != true)) {
                    this.UserField = value;
                    this.RaisePropertyChanged("User");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserServiceProxy.IUserService")]
    public interface IUserService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetAll", ReplyAction="http://tempuri.org/IUserService/GetAllResponse")]
        System.Collections.Generic.List<Fleeter.Client.UserServiceProxy.User> GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetAll", ReplyAction="http://tempuri.org/IUserService/GetAllResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<Fleeter.Client.UserServiceProxy.User>> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetById", ReplyAction="http://tempuri.org/IUserService/GetByIdResponse")]
        Fleeter.Client.UserServiceProxy.User GetById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/GetById", ReplyAction="http://tempuri.org/IUserService/GetByIdResponse")]
        System.Threading.Tasks.Task<Fleeter.Client.UserServiceProxy.User> GetByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/CreateOrUpdate", ReplyAction="http://tempuri.org/IUserService/CreateOrUpdateResponse")]
        Fleeter.Client.UserServiceProxy.BaseResult CreateOrUpdate(Fleeter.Client.UserServiceProxy.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/CreateOrUpdate", ReplyAction="http://tempuri.org/IUserService/CreateOrUpdateResponse")]
        System.Threading.Tasks.Task<Fleeter.Client.UserServiceProxy.BaseResult> CreateOrUpdateAsync(Fleeter.Client.UserServiceProxy.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/Delete", ReplyAction="http://tempuri.org/IUserService/DeleteResponse")]
        Fleeter.Client.UserServiceProxy.BaseResult Delete(Fleeter.Client.UserServiceProxy.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/Delete", ReplyAction="http://tempuri.org/IUserService/DeleteResponse")]
        System.Threading.Tasks.Task<Fleeter.Client.UserServiceProxy.BaseResult> DeleteAsync(Fleeter.Client.UserServiceProxy.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/Login", ReplyAction="http://tempuri.org/IUserService/LoginResponse")]
        Fleeter.Client.UserServiceProxy.LoginResult Login(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/Login", ReplyAction="http://tempuri.org/IUserService/LoginResponse")]
        System.Threading.Tasks.Task<Fleeter.Client.UserServiceProxy.LoginResult> LoginAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/ChangePassword", ReplyAction="http://tempuri.org/IUserService/ChangePasswordResponse")]
        Fleeter.Client.UserServiceProxy.BaseResult ChangePassword(Fleeter.Client.UserServiceProxy.User user, string oldPassword, string newPassword);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/ChangePassword", ReplyAction="http://tempuri.org/IUserService/ChangePasswordResponse")]
        System.Threading.Tasks.Task<Fleeter.Client.UserServiceProxy.BaseResult> ChangePasswordAsync(Fleeter.Client.UserServiceProxy.User user, string oldPassword, string newPassword);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServiceChannel : Fleeter.Client.UserServiceProxy.IUserService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServiceClient : System.ServiceModel.ClientBase<Fleeter.Client.UserServiceProxy.IUserService>, Fleeter.Client.UserServiceProxy.IUserService {
        
        public UserServiceClient() {
        }
        
        public UserServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<Fleeter.Client.UserServiceProxy.User> GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<Fleeter.Client.UserServiceProxy.User>> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public Fleeter.Client.UserServiceProxy.User GetById(int id) {
            return base.Channel.GetById(id);
        }
        
        public System.Threading.Tasks.Task<Fleeter.Client.UserServiceProxy.User> GetByIdAsync(int id) {
            return base.Channel.GetByIdAsync(id);
        }
        
        public Fleeter.Client.UserServiceProxy.BaseResult CreateOrUpdate(Fleeter.Client.UserServiceProxy.User user) {
            return base.Channel.CreateOrUpdate(user);
        }
        
        public System.Threading.Tasks.Task<Fleeter.Client.UserServiceProxy.BaseResult> CreateOrUpdateAsync(Fleeter.Client.UserServiceProxy.User user) {
            return base.Channel.CreateOrUpdateAsync(user);
        }
        
        public Fleeter.Client.UserServiceProxy.BaseResult Delete(Fleeter.Client.UserServiceProxy.User user) {
            return base.Channel.Delete(user);
        }
        
        public System.Threading.Tasks.Task<Fleeter.Client.UserServiceProxy.BaseResult> DeleteAsync(Fleeter.Client.UserServiceProxy.User user) {
            return base.Channel.DeleteAsync(user);
        }
        
        public Fleeter.Client.UserServiceProxy.LoginResult Login(string username, string password) {
            return base.Channel.Login(username, password);
        }
        
        public System.Threading.Tasks.Task<Fleeter.Client.UserServiceProxy.LoginResult> LoginAsync(string username, string password) {
            return base.Channel.LoginAsync(username, password);
        }
        
        public Fleeter.Client.UserServiceProxy.BaseResult ChangePassword(Fleeter.Client.UserServiceProxy.User user, string oldPassword, string newPassword) {
            return base.Channel.ChangePassword(user, oldPassword, newPassword);
        }
        
        public System.Threading.Tasks.Task<Fleeter.Client.UserServiceProxy.BaseResult> ChangePasswordAsync(Fleeter.Client.UserServiceProxy.User user, string oldPassword, string newPassword) {
            return base.Channel.ChangePasswordAsync(user, oldPassword, newPassword);
        }
    }
}
