﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dynamia.BillingSystem.Integrations.SAPFinancialRulesService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://publicar.com/MSE/Financial/SI_ReglasSAPFI_Out", ConfigurationName="SAPFinancialRulesService.svc_SI_ReglasSAPFI_Out")]
    public interface svc_SI_ReglasSAPFI_Out {
        
        // CODEGEN: Generating message contract since the operation OP_ReglasSAPFI_Out is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="OP_ReglasSAPFI_Out", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.OP_ReglasSAPFI_OutResponse OP_ReglasSAPFI_Out(Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.OP_ReglasSAPFI_OutRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="OP_ReglasSAPFI_Out", ReplyAction="*")]
        System.Threading.Tasks.Task<Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.OP_ReglasSAPFI_OutResponse> OP_ReglasSAPFI_OutAsync(Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.OP_ReglasSAPFI_OutRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:sap-com:document:sap:rfc:functions")]
    public partial class ZSD_VAL_FI_WEBSERVICE : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string i_CANAL_FACField;
        
        private string i_ID_USUARIOField;
        
        private string i_MONEDAField;
        
        private string i_ORG_VENTASField;
        
        private ZSD_COD_FALLA2[] eT_FALLASField;
        
        private ZSD_FEC_CUOTA[] eT_FEC_CANTField;
        
        private ZSD_CUOTAS3[] iT_CUOTASField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string I_CANAL_FAC {
            get {
                return this.i_CANAL_FACField;
            }
            set {
                this.i_CANAL_FACField = value;
                this.RaisePropertyChanged("I_CANAL_FAC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string I_ID_USUARIO {
            get {
                return this.i_ID_USUARIOField;
            }
            set {
                this.i_ID_USUARIOField = value;
                this.RaisePropertyChanged("I_ID_USUARIO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string I_MONEDA {
            get {
                return this.i_MONEDAField;
            }
            set {
                this.i_MONEDAField = value;
                this.RaisePropertyChanged("I_MONEDA");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string I_ORG_VENTAS {
            get {
                return this.i_ORG_VENTASField;
            }
            set {
                this.i_ORG_VENTASField = value;
                this.RaisePropertyChanged("I_ORG_VENTAS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public ZSD_COD_FALLA2[] ET_FALLAS {
            get {
                return this.eT_FALLASField;
            }
            set {
                this.eT_FALLASField = value;
                this.RaisePropertyChanged("ET_FALLAS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public ZSD_FEC_CUOTA[] ET_FEC_CANT {
            get {
                return this.eT_FEC_CANTField;
            }
            set {
                this.eT_FEC_CANTField = value;
                this.RaisePropertyChanged("ET_FEC_CANT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public ZSD_CUOTAS3[] IT_CUOTAS {
            get {
                return this.iT_CUOTASField;
            }
            set {
                this.iT_CUOTASField = value;
                this.RaisePropertyChanged("IT_CUOTAS");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:sap-com:document:sap:rfc:functions")]
    public partial class ZSD_COD_FALLA2 : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string mATNRField;
        
        private string zCODFField;
        
        private string zDESCField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string MATNR {
            get {
                return this.mATNRField;
            }
            set {
                this.mATNRField = value;
                this.RaisePropertyChanged("MATNR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string ZCODF {
            get {
                return this.zCODFField;
            }
            set {
                this.zCODFField = value;
                this.RaisePropertyChanged("ZCODF");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string ZDESC {
            get {
                return this.zDESCField;
            }
            set {
                this.zDESCField = value;
                this.RaisePropertyChanged("ZDESC");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://pub_crm_externo/canales")]
    public partial class DT_Fec_Cant : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string mATNRField;
        
        private string fECVLField;
        
        private string mENGEField;
        
        private string mAKTXField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string MATNR {
            get {
                return this.mATNRField;
            }
            set {
                this.mATNRField = value;
                this.RaisePropertyChanged("MATNR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string FECVL {
            get {
                return this.fECVLField;
            }
            set {
                this.fECVLField = value;
                this.RaisePropertyChanged("FECVL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="integer", Order=2)]
        public string MENGE {
            get {
                return this.mENGEField;
            }
            set {
                this.mENGEField = value;
                this.RaisePropertyChanged("MENGE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string MAKTX {
            get {
                return this.mAKTXField;
            }
            set {
                this.mAKTXField = value;
                this.RaisePropertyChanged("MAKTX");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://pub_crm_externo/canales")]
    public partial class DT_Fallas : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string mATNRField;
        
        private string zCODFField;
        
        private string zDESCField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string MATNR {
            get {
                return this.mATNRField;
            }
            set {
                this.mATNRField = value;
                this.RaisePropertyChanged("MATNR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string ZCODF {
            get {
                return this.zCODFField;
            }
            set {
                this.zCODFField = value;
                this.RaisePropertyChanged("ZCODF");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string ZDESC {
            get {
                return this.zDESCField;
            }
            set {
                this.zDESCField = value;
                this.RaisePropertyChanged("ZDESC");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://pub_crm_externo/canales")]
    public partial class DT_ReglasSAPFI_Response : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool e_ESTATUSField;
        
        private bool e_ESTATUSFieldSpecified;
        
        private DT_Fallas[] eT_FALLASField;
        
        private DT_Fec_Cant[] eT_FEC_CANTField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public bool E_ESTATUS {
            get {
                return this.e_ESTATUSField;
            }
            set {
                this.e_ESTATUSField = value;
                this.RaisePropertyChanged("E_ESTATUS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool E_ESTATUSSpecified {
            get {
                return this.e_ESTATUSFieldSpecified;
            }
            set {
                this.e_ESTATUSFieldSpecified = value;
                this.RaisePropertyChanged("E_ESTATUSSpecified");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public DT_Fallas[] ET_FALLAS {
            get {
                return this.eT_FALLASField;
            }
            set {
                this.eT_FALLASField = value;
                this.RaisePropertyChanged("ET_FALLAS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public DT_Fec_Cant[] ET_FEC_CANT {
            get {
                return this.eT_FEC_CANTField;
            }
            set {
                this.eT_FEC_CANTField = value;
                this.RaisePropertyChanged("ET_FEC_CANT");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:sap-com:document:sap:rfc:functions")]
    public partial class ZSD_CUOTAS3 : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string mATNRField;
        
        private string z_ID_CUOTField;
        
        private string zFECCTField;
        
        private decimal zVALCTField;
        
        private bool zVALCTFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string MATNR {
            get {
                return this.mATNRField;
            }
            set {
                this.mATNRField = value;
                this.RaisePropertyChanged("MATNR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string Z_ID_CUOT {
            get {
                return this.z_ID_CUOTField;
            }
            set {
                this.z_ID_CUOTField = value;
                this.RaisePropertyChanged("Z_ID_CUOT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string ZFECCT {
            get {
                return this.zFECCTField;
            }
            set {
                this.zFECCTField = value;
                this.RaisePropertyChanged("ZFECCT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public decimal ZVALCT {
            get {
                return this.zVALCTField;
            }
            set {
                this.zVALCTField = value;
                this.RaisePropertyChanged("ZVALCT");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ZVALCTSpecified {
            get {
                return this.zVALCTFieldSpecified;
            }
            set {
                this.zVALCTFieldSpecified = value;
                this.RaisePropertyChanged("ZVALCTSpecified");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:sap-com:document:sap:rfc:functions")]
    public partial class ZSD_FEC_CUOTA : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string mATNRField;
        
        private string fECVLField;
        
        private string mENGEField;
        
        private string mAKTXField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string MATNR {
            get {
                return this.mATNRField;
            }
            set {
                this.mATNRField = value;
                this.RaisePropertyChanged("MATNR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string FECVL {
            get {
                return this.fECVLField;
            }
            set {
                this.fECVLField = value;
                this.RaisePropertyChanged("FECVL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="integer", Order=2)]
        public string MENGE {
            get {
                return this.mENGEField;
            }
            set {
                this.mENGEField = value;
                this.RaisePropertyChanged("MENGE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string MAKTX {
            get {
                return this.mAKTXField;
            }
            set {
                this.mAKTXField = value;
                this.RaisePropertyChanged("MAKTX");
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class OP_ReglasSAPFI_OutRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="urn:sap-com:document:sap:rfc:functions", Order=0)]
        public Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.ZSD_VAL_FI_WEBSERVICE ZSD_VAL_FI_WEBSERVICE;
        
        public OP_ReglasSAPFI_OutRequest() {
        }
        
        public OP_ReglasSAPFI_OutRequest(Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.ZSD_VAL_FI_WEBSERVICE ZSD_VAL_FI_WEBSERVICE) {
            this.ZSD_VAL_FI_WEBSERVICE = ZSD_VAL_FI_WEBSERVICE;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class OP_ReglasSAPFI_OutResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://pub_crm_externo/canales", Order=0)]
        public Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.DT_ReglasSAPFI_Response MT_ReglasSAPFI_Response;
        
        public OP_ReglasSAPFI_OutResponse() {
        }
        
        public OP_ReglasSAPFI_OutResponse(Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.DT_ReglasSAPFI_Response MT_ReglasSAPFI_Response) {
            this.MT_ReglasSAPFI_Response = MT_ReglasSAPFI_Response;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface svc_SI_ReglasSAPFI_OutChannel : Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.svc_SI_ReglasSAPFI_Out, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class svc_SI_ReglasSAPFI_OutClient : System.ServiceModel.ClientBase<Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.svc_SI_ReglasSAPFI_Out>, Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.svc_SI_ReglasSAPFI_Out {
        
        public svc_SI_ReglasSAPFI_OutClient() {
        }
        
        public svc_SI_ReglasSAPFI_OutClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public svc_SI_ReglasSAPFI_OutClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public svc_SI_ReglasSAPFI_OutClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public svc_SI_ReglasSAPFI_OutClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.OP_ReglasSAPFI_OutResponse Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.svc_SI_ReglasSAPFI_Out.OP_ReglasSAPFI_Out(Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.OP_ReglasSAPFI_OutRequest request) {
            return base.Channel.OP_ReglasSAPFI_Out(request);
        }
        
        public Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.DT_ReglasSAPFI_Response OP_ReglasSAPFI_Out(Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.ZSD_VAL_FI_WEBSERVICE ZSD_VAL_FI_WEBSERVICE) {
            Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.OP_ReglasSAPFI_OutRequest inValue = new Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.OP_ReglasSAPFI_OutRequest();
            inValue.ZSD_VAL_FI_WEBSERVICE = ZSD_VAL_FI_WEBSERVICE;
            Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.OP_ReglasSAPFI_OutResponse retVal = ((Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.svc_SI_ReglasSAPFI_Out)(this)).OP_ReglasSAPFI_Out(inValue);
            return retVal.MT_ReglasSAPFI_Response;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.OP_ReglasSAPFI_OutResponse> Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.svc_SI_ReglasSAPFI_Out.OP_ReglasSAPFI_OutAsync(Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.OP_ReglasSAPFI_OutRequest request) {
            return base.Channel.OP_ReglasSAPFI_OutAsync(request);
        }
        
        public System.Threading.Tasks.Task<Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.OP_ReglasSAPFI_OutResponse> OP_ReglasSAPFI_OutAsync(Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.ZSD_VAL_FI_WEBSERVICE ZSD_VAL_FI_WEBSERVICE) {
            Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.OP_ReglasSAPFI_OutRequest inValue = new Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.OP_ReglasSAPFI_OutRequest();
            inValue.ZSD_VAL_FI_WEBSERVICE = ZSD_VAL_FI_WEBSERVICE;
            return ((Dynamia.BillingSystem.Integrations.SAPFinancialRulesService.svc_SI_ReglasSAPFI_Out)(this)).OP_ReglasSAPFI_OutAsync(inValue);
        }
    }
}
