﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.235
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 4.0.50826.0
// 
namespace MVVMSample.PersonDataService {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PersonData", Namespace="http://schemas.datacontract.org/2004/07/Index.Web")]
    public partial class PersonData : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string AddressField;
        
        private int AgeField;
        
        private string FirstNameField;
        
        private string LastNameField;
        
        private int PersonIDField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Age {
            get {
                return this.AgeField;
            }
            set {
                if ((this.AgeField.Equals(value) != true)) {
                    this.AgeField = value;
                    this.RaisePropertyChanged("Age");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PersonID {
            get {
                return this.PersonIDField;
            }
            set {
                if ((this.PersonIDField.Equals(value) != true)) {
                    this.PersonIDField = value;
                    this.RaisePropertyChanged("PersonID");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="", ConfigurationName="PersonDataService.PersonDataService")]
    public interface PersonDataService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="urn:PersonDataService/FindPerson", ReplyAction="urn:PersonDataService/FindPersonResponse")]
        System.IAsyncResult BeginFindPerson(int personID, System.AsyncCallback callback, object asyncState);
        
        MVVMSample.PersonDataService.PersonData EndFindPerson(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface PersonDataServiceChannel : MVVMSample.PersonDataService.PersonDataService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FindPersonCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public FindPersonCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public MVVMSample.PersonDataService.PersonData Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((MVVMSample.PersonDataService.PersonData)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PersonDataServiceClient : System.ServiceModel.ClientBase<MVVMSample.PersonDataService.PersonDataService>, MVVMSample.PersonDataService.PersonDataService {
        
        private BeginOperationDelegate onBeginFindPersonDelegate;
        
        private EndOperationDelegate onEndFindPersonDelegate;
        
        private System.Threading.SendOrPostCallback onFindPersonCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public PersonDataServiceClient() {
        }
        
        public PersonDataServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PersonDataServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PersonDataServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PersonDataServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<FindPersonCompletedEventArgs> FindPersonCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult MVVMSample.PersonDataService.PersonDataService.BeginFindPerson(int personID, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginFindPerson(personID, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        MVVMSample.PersonDataService.PersonData MVVMSample.PersonDataService.PersonDataService.EndFindPerson(System.IAsyncResult result) {
            return base.Channel.EndFindPerson(result);
        }
        
        private System.IAsyncResult OnBeginFindPerson(object[] inValues, System.AsyncCallback callback, object asyncState) {
            int personID = ((int)(inValues[0]));
            return ((MVVMSample.PersonDataService.PersonDataService)(this)).BeginFindPerson(personID, callback, asyncState);
        }
        
        private object[] OnEndFindPerson(System.IAsyncResult result) {
            MVVMSample.PersonDataService.PersonData retVal = ((MVVMSample.PersonDataService.PersonDataService)(this)).EndFindPerson(result);
            return new object[] {
                    retVal};
        }
        
        private void OnFindPersonCompleted(object state) {
            if ((this.FindPersonCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.FindPersonCompleted(this, new FindPersonCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void FindPersonAsync(int personID) {
            this.FindPersonAsync(personID, null);
        }
        
        public void FindPersonAsync(int personID, object userState) {
            if ((this.onBeginFindPersonDelegate == null)) {
                this.onBeginFindPersonDelegate = new BeginOperationDelegate(this.OnBeginFindPerson);
            }
            if ((this.onEndFindPersonDelegate == null)) {
                this.onEndFindPersonDelegate = new EndOperationDelegate(this.OnEndFindPerson);
            }
            if ((this.onFindPersonCompletedDelegate == null)) {
                this.onFindPersonCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnFindPersonCompleted);
            }
            base.InvokeAsync(this.onBeginFindPersonDelegate, new object[] {
                        personID}, this.onEndFindPersonDelegate, this.onFindPersonCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override MVVMSample.PersonDataService.PersonDataService CreateChannel() {
            return new PersonDataServiceClientChannel(this);
        }
        
        private class PersonDataServiceClientChannel : ChannelBase<MVVMSample.PersonDataService.PersonDataService>, MVVMSample.PersonDataService.PersonDataService {
            
            public PersonDataServiceClientChannel(System.ServiceModel.ClientBase<MVVMSample.PersonDataService.PersonDataService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginFindPerson(int personID, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = personID;
                System.IAsyncResult _result = base.BeginInvoke("FindPerson", _args, callback, asyncState);
                return _result;
            }
            
            public MVVMSample.PersonDataService.PersonData EndFindPerson(System.IAsyncResult result) {
                object[] _args = new object[0];
                MVVMSample.PersonDataService.PersonData _result = ((MVVMSample.PersonDataService.PersonData)(base.EndInvoke("FindPerson", _args, result)));
                return _result;
            }
        }
    }
}