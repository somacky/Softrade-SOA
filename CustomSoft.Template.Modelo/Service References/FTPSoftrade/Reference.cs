﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.34209
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CustomSoft.Template.Modelo.FTPSoftrade {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RequestBase", Namespace="http://schemas.datacontract.org/2004/07/FTPSoftrade.Template.Modelo.Servicio.Base" +
        "")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(CustomSoft.Template.Modelo.FTPSoftrade.ResponseBase))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(CustomSoft.Template.Modelo.FTPSoftrade.OperacionResponseBaseOfArchivoVa2qu1_SJ))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(CustomSoft.Template.Modelo.FTPSoftrade.RecibeArchivoResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(CustomSoft.Template.Modelo.FTPSoftrade.OperacionRequestBaseOfArchivoVa2qu1_SJ))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(CustomSoft.Template.Modelo.FTPSoftrade.RecibeArchivoRequest))]
    public partial class RequestBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsuarioEjecucionField;
        
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
        public string UsuarioEjecucion {
            get {
                return this.UsuarioEjecucionField;
            }
            set {
                if ((object.ReferenceEquals(this.UsuarioEjecucionField, value) != true)) {
                    this.UsuarioEjecucionField = value;
                    this.RaisePropertyChanged("UsuarioEjecucion");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseBase", Namespace="http://schemas.datacontract.org/2004/07/FTPSoftrade.Template.Modelo.Servicio.Base" +
        "")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(CustomSoft.Template.Modelo.FTPSoftrade.OperacionResponseBaseOfArchivoVa2qu1_SJ))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(CustomSoft.Template.Modelo.FTPSoftrade.RecibeArchivoResponse))]
    public partial class ResponseBase : CustomSoft.Template.Modelo.FTPSoftrade.RequestBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool EjecucionValidaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MensajeErrorField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool EjecucionValida {
            get {
                return this.EjecucionValidaField;
            }
            set {
                if ((this.EjecucionValidaField.Equals(value) != true)) {
                    this.EjecucionValidaField = value;
                    this.RaisePropertyChanged("EjecucionValida");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MensajeError {
            get {
                return this.MensajeErrorField;
            }
            set {
                if ((object.ReferenceEquals(this.MensajeErrorField, value) != true)) {
                    this.MensajeErrorField = value;
                    this.RaisePropertyChanged("MensajeError");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OperacionResponseBaseOfArchivoVa2qu1_SJ", Namespace="http://schemas.datacontract.org/2004/07/FTPSoftrade.Template.Modelo.Servicio.Base" +
        "")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(CustomSoft.Template.Modelo.FTPSoftrade.RecibeArchivoResponse))]
    public partial class OperacionResponseBaseOfArchivoVa2qu1_SJ : CustomSoft.Template.Modelo.FTPSoftrade.ResponseBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private CustomSoft.Template.Modelo.FTPSoftrade.Archivo ItemField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CustomSoft.Template.Modelo.FTPSoftrade.Archivo Item {
            get {
                return this.ItemField;
            }
            set {
                if ((object.ReferenceEquals(this.ItemField, value) != true)) {
                    this.ItemField = value;
                    this.RaisePropertyChanged("Item");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RecibeArchivoResponse", Namespace="http://schemas.datacontract.org/2004/07/FTPSoftrade.Template.Modelo.Servicio.Resp" +
        "onse")]
    [System.SerializableAttribute()]
    public partial class RecibeArchivoResponse : CustomSoft.Template.Modelo.FTPSoftrade.OperacionResponseBaseOfArchivoVa2qu1_SJ {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OperacionRequestBaseOfArchivoVa2qu1_SJ", Namespace="http://schemas.datacontract.org/2004/07/FTPSoftrade.Template.Modelo.Servicio.Base" +
        "")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(CustomSoft.Template.Modelo.FTPSoftrade.RecibeArchivoRequest))]
    public partial class OperacionRequestBaseOfArchivoVa2qu1_SJ : CustomSoft.Template.Modelo.FTPSoftrade.RequestBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private CustomSoft.Template.Modelo.FTPSoftrade.Archivo ItemField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CustomSoft.Template.Modelo.FTPSoftrade.Archivo Item {
            get {
                return this.ItemField;
            }
            set {
                if ((object.ReferenceEquals(this.ItemField, value) != true)) {
                    this.ItemField = value;
                    this.RaisePropertyChanged("Item");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RecibeArchivoRequest", Namespace="http://schemas.datacontract.org/2004/07/FTPSoftrade.Template.Modelo.Servicio.Requ" +
        "est")]
    [System.SerializableAttribute()]
    public partial class RecibeArchivoRequest : CustomSoft.Template.Modelo.FTPSoftrade.OperacionRequestBaseOfArchivoVa2qu1_SJ {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private CustomSoft.Template.Modelo.FTPSoftrade.TipoOperacionArchivo OperacionField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CustomSoft.Template.Modelo.FTPSoftrade.TipoOperacionArchivo Operacion {
            get {
                return this.OperacionField;
            }
            set {
                if ((this.OperacionField.Equals(value) != true)) {
                    this.OperacionField = value;
                    this.RaisePropertyChanged("Operacion");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Archivo", Namespace="http://schemas.datacontract.org/2004/07/FTPSoftrade.Template.Modelo.Dominio.Entid" +
        "ades")]
    [System.SerializableAttribute()]
    public partial class Archivo : CustomSoft.Template.Modelo.FTPSoftrade.ArchivoBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ExtensionArchivoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaSubidaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdClienteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdEmpresaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdTipoDocumentoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float LongitudArchivoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PatenteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PathDestinoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private CustomSoft.Template.Modelo.FTPSoftrade.TipoArchivo TipoArchivoFiltroField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private CustomSoft.Template.Modelo.FTPSoftrade.TipoCerKey TipoDeCerKeyField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ExtensionArchivo {
            get {
                return this.ExtensionArchivoField;
            }
            set {
                if ((object.ReferenceEquals(this.ExtensionArchivoField, value) != true)) {
                    this.ExtensionArchivoField = value;
                    this.RaisePropertyChanged("ExtensionArchivo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FechaSubida {
            get {
                return this.FechaSubidaField;
            }
            set {
                if ((this.FechaSubidaField.Equals(value) != true)) {
                    this.FechaSubidaField = value;
                    this.RaisePropertyChanged("FechaSubida");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdCliente {
            get {
                return this.IdClienteField;
            }
            set {
                if ((this.IdClienteField.Equals(value) != true)) {
                    this.IdClienteField = value;
                    this.RaisePropertyChanged("IdCliente");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdEmpresa {
            get {
                return this.IdEmpresaField;
            }
            set {
                if ((this.IdEmpresaField.Equals(value) != true)) {
                    this.IdEmpresaField = value;
                    this.RaisePropertyChanged("IdEmpresa");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdTipoDocumento {
            get {
                return this.IdTipoDocumentoField;
            }
            set {
                if ((this.IdTipoDocumentoField.Equals(value) != true)) {
                    this.IdTipoDocumentoField = value;
                    this.RaisePropertyChanged("IdTipoDocumento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float LongitudArchivo {
            get {
                return this.LongitudArchivoField;
            }
            set {
                if ((this.LongitudArchivoField.Equals(value) != true)) {
                    this.LongitudArchivoField = value;
                    this.RaisePropertyChanged("LongitudArchivo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Patente {
            get {
                return this.PatenteField;
            }
            set {
                if ((object.ReferenceEquals(this.PatenteField, value) != true)) {
                    this.PatenteField = value;
                    this.RaisePropertyChanged("Patente");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PathDestino {
            get {
                return this.PathDestinoField;
            }
            set {
                if ((object.ReferenceEquals(this.PathDestinoField, value) != true)) {
                    this.PathDestinoField = value;
                    this.RaisePropertyChanged("PathDestino");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CustomSoft.Template.Modelo.FTPSoftrade.TipoArchivo TipoArchivoFiltro {
            get {
                return this.TipoArchivoFiltroField;
            }
            set {
                if ((this.TipoArchivoFiltroField.Equals(value) != true)) {
                    this.TipoArchivoFiltroField = value;
                    this.RaisePropertyChanged("TipoArchivoFiltro");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public CustomSoft.Template.Modelo.FTPSoftrade.TipoCerKey TipoDeCerKey {
            get {
                return this.TipoDeCerKeyField;
            }
            set {
                if ((this.TipoDeCerKeyField.Equals(value) != true)) {
                    this.TipoDeCerKeyField = value;
                    this.RaisePropertyChanged("TipoDeCerKey");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TipoOperacionArchivo", Namespace="http://schemas.datacontract.org/2004/07/FTPSoftrade.Template.Modelo.Compartido")]
    public enum TipoOperacionArchivo : byte {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Insertar = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Extraer = 1,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ArchivoBase", Namespace="http://schemas.datacontract.org/2004/07/FTPSoftrade.Template.Modelo.Dominio.Base")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(CustomSoft.Template.Modelo.FTPSoftrade.Archivo))]
    public partial class ArchivoBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte[] ArchivoBytesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdArchivoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreArchivoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NuevoNombreArchivoField;
        
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
        public byte[] ArchivoBytes {
            get {
                return this.ArchivoBytesField;
            }
            set {
                if ((object.ReferenceEquals(this.ArchivoBytesField, value) != true)) {
                    this.ArchivoBytesField = value;
                    this.RaisePropertyChanged("ArchivoBytes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdArchivo {
            get {
                return this.IdArchivoField;
            }
            set {
                if ((this.IdArchivoField.Equals(value) != true)) {
                    this.IdArchivoField = value;
                    this.RaisePropertyChanged("IdArchivo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NombreArchivo {
            get {
                return this.NombreArchivoField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreArchivoField, value) != true)) {
                    this.NombreArchivoField = value;
                    this.RaisePropertyChanged("NombreArchivo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NuevoNombreArchivo {
            get {
                return this.NuevoNombreArchivoField;
            }
            set {
                if ((object.ReferenceEquals(this.NuevoNombreArchivoField, value) != true)) {
                    this.NuevoNombreArchivoField = value;
                    this.RaisePropertyChanged("NuevoNombreArchivo");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="TipoArchivo", Namespace="http://schemas.datacontract.org/2004/07/FTPSoftrade.Template.Modelo.Compartido")]
    public enum TipoArchivo : byte {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ArchivoM = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        PDF = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        XML = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        CerKey = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Otros = 4,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TipoCerKey", Namespace="http://schemas.datacontract.org/2004/07/FTPSoftrade.Template.Modelo.Compartido")]
    public enum TipoCerKey : byte {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Cliente = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Patente = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FTPSoftrade.IFTPSeguridadService")]
    public interface IFTPSeguridadService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFTPSeguridadService/OperacionArchivo", ReplyAction="http://tempuri.org/IFTPSeguridadService/OperacionArchivoResponse")]
        CustomSoft.Template.Modelo.FTPSoftrade.RecibeArchivoResponse OperacionArchivo(CustomSoft.Template.Modelo.FTPSoftrade.RecibeArchivoRequest archivo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFTPSeguridadService/OperacionArchivo", ReplyAction="http://tempuri.org/IFTPSeguridadService/OperacionArchivoResponse")]
        System.Threading.Tasks.Task<CustomSoft.Template.Modelo.FTPSoftrade.RecibeArchivoResponse> OperacionArchivoAsync(CustomSoft.Template.Modelo.FTPSoftrade.RecibeArchivoRequest archivo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFTPSeguridadService/FTServerCode", ReplyAction="http://tempuri.org/IFTPSeguridadService/FTServerCodeResponse")]
        void FTServerCode();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFTPSeguridadService/FTServerCode", ReplyAction="http://tempuri.org/IFTPSeguridadService/FTServerCodeResponse")]
        System.Threading.Tasks.Task FTServerCodeAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFTPSeguridadServiceChannel : CustomSoft.Template.Modelo.FTPSoftrade.IFTPSeguridadService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FTPSeguridadServiceClient : System.ServiceModel.ClientBase<CustomSoft.Template.Modelo.FTPSoftrade.IFTPSeguridadService>, CustomSoft.Template.Modelo.FTPSoftrade.IFTPSeguridadService {
        
        public FTPSeguridadServiceClient() {
        }
        
        public FTPSeguridadServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FTPSeguridadServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FTPSeguridadServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FTPSeguridadServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public CustomSoft.Template.Modelo.FTPSoftrade.RecibeArchivoResponse OperacionArchivo(CustomSoft.Template.Modelo.FTPSoftrade.RecibeArchivoRequest archivo) {
            return base.Channel.OperacionArchivo(archivo);
        }
        
        public System.Threading.Tasks.Task<CustomSoft.Template.Modelo.FTPSoftrade.RecibeArchivoResponse> OperacionArchivoAsync(CustomSoft.Template.Modelo.FTPSoftrade.RecibeArchivoRequest archivo) {
            return base.Channel.OperacionArchivoAsync(archivo);
        }
        
        public void FTServerCode() {
            base.Channel.FTServerCode();
        }
        
        public System.Threading.Tasks.Task FTServerCodeAsync() {
            return base.Channel.FTServerCodeAsync();
        }
    }
}
