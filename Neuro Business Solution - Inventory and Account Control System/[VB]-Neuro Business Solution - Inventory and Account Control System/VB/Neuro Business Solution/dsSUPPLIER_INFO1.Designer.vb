'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.42
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System


<System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"),  _
 Serializable(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.ComponentModel.ToolboxItem(true),  _
 System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema"),  _
 System.Xml.Serialization.XmlRootAttribute("dsSUPPLIER_INFO1"),  _
 System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")>  _
Partial Public Class dsSUPPLIER_INFO1
    Inherits System.Data.DataSet
    
    Private tableSUPPLIER_INFO As SUPPLIER_INFODataTable
    
    Private _schemaSerializationMode As System.Data.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Public Sub New()
        MyBase.New
        Me.BeginInit
        Me.InitClass
        Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler MyBase.Tables.CollectionChanged, schemaChangedHandler
        AddHandler MyBase.Relations.CollectionChanged, schemaChangedHandler
        Me.EndInit
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Protected Sub New(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext)
        MyBase.New(info, context, false)
        If (Me.IsBinarySerialized(info, context) = true) Then
            Me.InitVars(false)
            Dim schemaChangedHandler1 As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
            AddHandler Me.Tables.CollectionChanged, schemaChangedHandler1
            AddHandler Me.Relations.CollectionChanged, schemaChangedHandler1
            Return
        End If
        Dim strSchema As String = CType(info.GetValue("XmlSchema", GetType(String)),String)
        If (Me.DetermineSchemaSerializationMode(info, context) = System.Data.SchemaSerializationMode.IncludeSchema) Then
            Dim ds As System.Data.DataSet = New System.Data.DataSet
            ds.ReadXmlSchema(New System.Xml.XmlTextReader(New System.IO.StringReader(strSchema)))
            If (Not (ds.Tables("SUPPLIER_INFO")) Is Nothing) Then
                MyBase.Tables.Add(New SUPPLIER_INFODataTable(ds.Tables("SUPPLIER_INFO")))
            End If
            Me.DataSetName = ds.DataSetName
            Me.Prefix = ds.Prefix
            Me.Namespace = ds.Namespace
            Me.Locale = ds.Locale
            Me.CaseSensitive = ds.CaseSensitive
            Me.EnforceConstraints = ds.EnforceConstraints
            Me.Merge(ds, false, System.Data.MissingSchemaAction.Add)
            Me.InitVars
        Else
            Me.ReadXmlSchema(New System.Xml.XmlTextReader(New System.IO.StringReader(strSchema)))
        End If
        Me.GetSerializationData(info, context)
        Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler MyBase.Tables.CollectionChanged, schemaChangedHandler
        AddHandler Me.Relations.CollectionChanged, schemaChangedHandler
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.ComponentModel.Browsable(false),  _
     System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)>  _
    Public ReadOnly Property SUPPLIER_INFO() As SUPPLIER_INFODataTable
        Get
            Return Me.tableSUPPLIER_INFO
        End Get
    End Property
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.ComponentModel.BrowsableAttribute(true),  _
     System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)>  _
    Public Overrides Property SchemaSerializationMode() As System.Data.SchemaSerializationMode
        Get
            Return Me._schemaSerializationMode
        End Get
        Set
            Me._schemaSerializationMode = value
        End Set
    End Property
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public Shadows ReadOnly Property Tables() As System.Data.DataTableCollection
        Get
            Return MyBase.Tables
        End Get
    End Property
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)>  _
    Public Shadows ReadOnly Property Relations() As System.Data.DataRelationCollection
        Get
            Return MyBase.Relations
        End Get
    End Property
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Protected Overrides Sub InitializeDerivedDataSet()
        Me.BeginInit
        Me.InitClass
        Me.EndInit
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Public Overrides Function Clone() As System.Data.DataSet
        Dim cln As dsSUPPLIER_INFO1 = CType(MyBase.Clone,dsSUPPLIER_INFO1)
        cln.InitVars
        cln.SchemaSerializationMode = Me.SchemaSerializationMode
        Return cln
    End Function
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Protected Overrides Function ShouldSerializeTables() As Boolean
        Return false
    End Function
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Protected Overrides Function ShouldSerializeRelations() As Boolean
        Return false
    End Function
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Protected Overrides Sub ReadXmlSerializable(ByVal reader As System.Xml.XmlReader)
        If (Me.DetermineSchemaSerializationMode(reader) = System.Data.SchemaSerializationMode.IncludeSchema) Then
            Me.Reset
            Dim ds As System.Data.DataSet = New System.Data.DataSet
            ds.ReadXml(reader)
            If (Not (ds.Tables("SUPPLIER_INFO")) Is Nothing) Then
                MyBase.Tables.Add(New SUPPLIER_INFODataTable(ds.Tables("SUPPLIER_INFO")))
            End If
            Me.DataSetName = ds.DataSetName
            Me.Prefix = ds.Prefix
            Me.Namespace = ds.Namespace
            Me.Locale = ds.Locale
            Me.CaseSensitive = ds.CaseSensitive
            Me.EnforceConstraints = ds.EnforceConstraints
            Me.Merge(ds, false, System.Data.MissingSchemaAction.Add)
            Me.InitVars
        Else
            Me.ReadXml(reader)
            Me.InitVars
        End If
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Protected Overrides Function GetSchemaSerializable() As System.Xml.Schema.XmlSchema
        Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream
        Me.WriteXmlSchema(New System.Xml.XmlTextWriter(stream, Nothing))
        stream.Position = 0
        Return System.Xml.Schema.XmlSchema.Read(New System.Xml.XmlTextReader(stream), Nothing)
    End Function
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Friend Overloads Sub InitVars()
        Me.InitVars(true)
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Friend Overloads Sub InitVars(ByVal initTable As Boolean)
        Me.tableSUPPLIER_INFO = CType(MyBase.Tables("SUPPLIER_INFO"),SUPPLIER_INFODataTable)
        If (initTable = true) Then
            If (Not (Me.tableSUPPLIER_INFO) Is Nothing) Then
                Me.tableSUPPLIER_INFO.InitVars
            End If
        End If
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Sub InitClass()
        Me.DataSetName = "dsSUPPLIER_INFO1"
        Me.Prefix = ""
        Me.Namespace = "http://tempuri.org/dsSUPPLIER_INFO1.xsd"
        Me.EnforceConstraints = true
        Me.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        Me.tableSUPPLIER_INFO = New SUPPLIER_INFODataTable
        MyBase.Tables.Add(Me.tableSUPPLIER_INFO)
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Function ShouldSerializeSUPPLIER_INFO() As Boolean
        Return false
    End Function
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Sub SchemaChanged(ByVal sender As Object, ByVal e As System.ComponentModel.CollectionChangeEventArgs)
        If (e.Action = System.ComponentModel.CollectionChangeAction.Remove) Then
            Me.InitVars
        End If
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Public Shared Function GetTypedDataSetSchema(ByVal xs As System.Xml.Schema.XmlSchemaSet) As System.Xml.Schema.XmlSchemaComplexType
        Dim ds As dsSUPPLIER_INFO1 = New dsSUPPLIER_INFO1
        Dim type As System.Xml.Schema.XmlSchemaComplexType = New System.Xml.Schema.XmlSchemaComplexType
        Dim sequence As System.Xml.Schema.XmlSchemaSequence = New System.Xml.Schema.XmlSchemaSequence
        xs.Add(ds.GetSchemaSerializable)
        Dim any As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny
        any.Namespace = ds.Namespace
        sequence.Items.Add(any)
        type.Particle = sequence
        Return type
    End Function
    
    Public Delegate Sub SUPPLIER_INFORowChangeEventHandler(ByVal sender As Object, ByVal e As SUPPLIER_INFORowChangeEvent)
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"),  _
     System.Serializable(),  _
     System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")>  _
    Partial Public Class SUPPLIER_INFODataTable
        Inherits System.Data.DataTable
        Implements System.Collections.IEnumerable
        
        Private columnnID As System.Data.DataColumn
        
        Private columnsCONTACT_PERSON As System.Data.DataColumn
        
        Private columnsDESIGNATION As System.Data.DataColumn
        
        Private columnsSUPPLIER_NAME As System.Data.DataColumn
        
        Private columnsADDRESS As System.Data.DataColumn
        
        Private columnsSUPPLIER_PH As System.Data.DataColumn
        
        Private columnsPERSON_PH As System.Data.DataColumn
        
        Private columnsCELL_NO As System.Data.DataColumn
        
        Private columnsFAX_NO As System.Data.DataColumn
        
        Private columnsE_MAIL As System.Data.DataColumn
        
        Private columnsWEB_ADD As System.Data.DataColumn
        
        Private columnSTATUS As System.Data.DataColumn
        
        Private columnnOPEN_BAL As System.Data.DataColumn
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub New()
            MyBase.New
            Me.TableName = "SUPPLIER_INFO"
            Me.BeginInit
            Me.InitClass
            Me.EndInit
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Friend Sub New(ByVal table As System.Data.DataTable)
            MyBase.New
            Me.TableName = table.TableName
            If (table.CaseSensitive <> table.DataSet.CaseSensitive) Then
                Me.CaseSensitive = table.CaseSensitive
            End If
            If (table.Locale.ToString <> table.DataSet.Locale.ToString) Then
                Me.Locale = table.Locale
            End If
            If (table.Namespace <> table.DataSet.Namespace) Then
                Me.Namespace = table.Namespace
            End If
            Me.Prefix = table.Prefix
            Me.MinimumCapacity = table.MinimumCapacity
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Sub New(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext)
            MyBase.New(info, context)
            Me.InitVars
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property nIDColumn() As System.Data.DataColumn
            Get
                Return Me.columnnID
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sCONTACT_PERSONColumn() As System.Data.DataColumn
            Get
                Return Me.columnsCONTACT_PERSON
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sDESIGNATIONColumn() As System.Data.DataColumn
            Get
                Return Me.columnsDESIGNATION
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sSUPPLIER_NAMEColumn() As System.Data.DataColumn
            Get
                Return Me.columnsSUPPLIER_NAME
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sADDRESSColumn() As System.Data.DataColumn
            Get
                Return Me.columnsADDRESS
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sSUPPLIER_PHColumn() As System.Data.DataColumn
            Get
                Return Me.columnsSUPPLIER_PH
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sPERSON_PHColumn() As System.Data.DataColumn
            Get
                Return Me.columnsPERSON_PH
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sCELL_NOColumn() As System.Data.DataColumn
            Get
                Return Me.columnsCELL_NO
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sFAX_NOColumn() As System.Data.DataColumn
            Get
                Return Me.columnsFAX_NO
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sE_MAILColumn() As System.Data.DataColumn
            Get
                Return Me.columnsE_MAIL
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sWEB_ADDColumn() As System.Data.DataColumn
            Get
                Return Me.columnsWEB_ADD
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property STATUSColumn() As System.Data.DataColumn
            Get
                Return Me.columnSTATUS
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property nOPEN_BALColumn() As System.Data.DataColumn
            Get
                Return Me.columnnOPEN_BAL
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         System.ComponentModel.Browsable(false)>  _
        Public ReadOnly Property Count() As Integer
            Get
                Return Me.Rows.Count
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Default ReadOnly Property Item(ByVal index As Integer) As SUPPLIER_INFORow
            Get
                Return CType(Me.Rows(index),SUPPLIER_INFORow)
            End Get
        End Property
        
        Public Event SUPPLIER_INFORowChanging As SUPPLIER_INFORowChangeEventHandler
        
        Public Event SUPPLIER_INFORowChanged As SUPPLIER_INFORowChangeEventHandler
        
        Public Event SUPPLIER_INFORowDeleting As SUPPLIER_INFORowChangeEventHandler
        
        Public Event SUPPLIER_INFORowDeleted As SUPPLIER_INFORowChangeEventHandler
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overloads Sub AddSUPPLIER_INFORow(ByVal row As SUPPLIER_INFORow)
            Me.Rows.Add(row)
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overloads Function AddSUPPLIER_INFORow(ByVal nID As Decimal, ByVal sCONTACT_PERSON As String, ByVal sDESIGNATION As String, ByVal sSUPPLIER_NAME As String, ByVal sADDRESS As String, ByVal sSUPPLIER_PH As String, ByVal sPERSON_PH As String, ByVal sCELL_NO As String, ByVal sFAX_NO As String, ByVal sE_MAIL As String, ByVal sWEB_ADD As String, ByVal STATUS As String, ByVal nOPEN_BAL As Decimal) As SUPPLIER_INFORow
            Dim rowSUPPLIER_INFORow As SUPPLIER_INFORow = CType(Me.NewRow,SUPPLIER_INFORow)
            rowSUPPLIER_INFORow.ItemArray = New Object() {nID, sCONTACT_PERSON, sDESIGNATION, sSUPPLIER_NAME, sADDRESS, sSUPPLIER_PH, sPERSON_PH, sCELL_NO, sFAX_NO, sE_MAIL, sWEB_ADD, STATUS, nOPEN_BAL}
            Me.Rows.Add(rowSUPPLIER_INFORow)
            Return rowSUPPLIER_INFORow
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function FindBynID(ByVal nID As Decimal) As SUPPLIER_INFORow
            Return CType(Me.Rows.Find(New Object() {nID}),SUPPLIER_INFORow)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overridable Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Me.Rows.GetEnumerator
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overrides Function Clone() As System.Data.DataTable
            Dim cln As SUPPLIER_INFODataTable = CType(MyBase.Clone,SUPPLIER_INFODataTable)
            cln.InitVars
            Return cln
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Function CreateInstance() As System.Data.DataTable
            Return New SUPPLIER_INFODataTable
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Friend Sub InitVars()
            Me.columnnID = MyBase.Columns("nID")
            Me.columnsCONTACT_PERSON = MyBase.Columns("sCONTACT_PERSON")
            Me.columnsDESIGNATION = MyBase.Columns("sDESIGNATION")
            Me.columnsSUPPLIER_NAME = MyBase.Columns("sSUPPLIER_NAME")
            Me.columnsADDRESS = MyBase.Columns("sADDRESS")
            Me.columnsSUPPLIER_PH = MyBase.Columns("sSUPPLIER_PH")
            Me.columnsPERSON_PH = MyBase.Columns("sPERSON_PH")
            Me.columnsCELL_NO = MyBase.Columns("sCELL_NO")
            Me.columnsFAX_NO = MyBase.Columns("sFAX_NO")
            Me.columnsE_MAIL = MyBase.Columns("sE_MAIL")
            Me.columnsWEB_ADD = MyBase.Columns("sWEB_ADD")
            Me.columnSTATUS = MyBase.Columns("STATUS")
            Me.columnnOPEN_BAL = MyBase.Columns("nOPEN_BAL")
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Private Sub InitClass()
            Me.columnnID = New System.Data.DataColumn("nID", GetType(Decimal), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnnID)
            Me.columnsCONTACT_PERSON = New System.Data.DataColumn("sCONTACT_PERSON", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsCONTACT_PERSON)
            Me.columnsDESIGNATION = New System.Data.DataColumn("sDESIGNATION", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsDESIGNATION)
            Me.columnsSUPPLIER_NAME = New System.Data.DataColumn("sSUPPLIER_NAME", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsSUPPLIER_NAME)
            Me.columnsADDRESS = New System.Data.DataColumn("sADDRESS", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsADDRESS)
            Me.columnsSUPPLIER_PH = New System.Data.DataColumn("sSUPPLIER_PH", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsSUPPLIER_PH)
            Me.columnsPERSON_PH = New System.Data.DataColumn("sPERSON_PH", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsPERSON_PH)
            Me.columnsCELL_NO = New System.Data.DataColumn("sCELL_NO", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsCELL_NO)
            Me.columnsFAX_NO = New System.Data.DataColumn("sFAX_NO", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsFAX_NO)
            Me.columnsE_MAIL = New System.Data.DataColumn("sE_MAIL", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsE_MAIL)
            Me.columnsWEB_ADD = New System.Data.DataColumn("sWEB_ADD", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsWEB_ADD)
            Me.columnSTATUS = New System.Data.DataColumn("STATUS", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnSTATUS)
            Me.columnnOPEN_BAL = New System.Data.DataColumn("nOPEN_BAL", GetType(Decimal), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnnOPEN_BAL)
            Me.Constraints.Add(New System.Data.UniqueConstraint("Constraint1", New System.Data.DataColumn() {Me.columnnID}, true))
            Me.columnnID.AllowDBNull = false
            Me.columnnID.Unique = true
            Me.columnsCONTACT_PERSON.AllowDBNull = false
            Me.columnsCONTACT_PERSON.MaxLength = 50
            Me.columnsDESIGNATION.MaxLength = 50
            Me.columnsSUPPLIER_NAME.AllowDBNull = false
            Me.columnsSUPPLIER_NAME.MaxLength = 50
            Me.columnsADDRESS.MaxLength = 200
            Me.columnsSUPPLIER_PH.MaxLength = 50
            Me.columnsPERSON_PH.MaxLength = 50
            Me.columnsCELL_NO.MaxLength = 50
            Me.columnsFAX_NO.MaxLength = 50
            Me.columnsE_MAIL.MaxLength = 50
            Me.columnsWEB_ADD.MaxLength = 50
            Me.columnSTATUS.ReadOnly = true
            Me.columnSTATUS.MaxLength = 3
            Me.columnnOPEN_BAL.AllowDBNull = false
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function NewSUPPLIER_INFORow() As SUPPLIER_INFORow
            Return CType(Me.NewRow,SUPPLIER_INFORow)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Function NewRowFromBuilder(ByVal builder As System.Data.DataRowBuilder) As System.Data.DataRow
            Return New SUPPLIER_INFORow(builder)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Function GetRowType() As System.Type
            Return GetType(SUPPLIER_INFORow)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowChanged(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowChanged(e)
            If (Not (Me.SUPPLIER_INFORowChangedEvent) Is Nothing) Then
                RaiseEvent SUPPLIER_INFORowChanged(Me, New SUPPLIER_INFORowChangeEvent(CType(e.Row,SUPPLIER_INFORow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowChanging(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowChanging(e)
            If (Not (Me.SUPPLIER_INFORowChangingEvent) Is Nothing) Then
                RaiseEvent SUPPLIER_INFORowChanging(Me, New SUPPLIER_INFORowChangeEvent(CType(e.Row,SUPPLIER_INFORow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowDeleted(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowDeleted(e)
            If (Not (Me.SUPPLIER_INFORowDeletedEvent) Is Nothing) Then
                RaiseEvent SUPPLIER_INFORowDeleted(Me, New SUPPLIER_INFORowChangeEvent(CType(e.Row,SUPPLIER_INFORow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowDeleting(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowDeleting(e)
            If (Not (Me.SUPPLIER_INFORowDeletingEvent) Is Nothing) Then
                RaiseEvent SUPPLIER_INFORowDeleting(Me, New SUPPLIER_INFORowChangeEvent(CType(e.Row,SUPPLIER_INFORow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub RemoveSUPPLIER_INFORow(ByVal row As SUPPLIER_INFORow)
            Me.Rows.Remove(row)
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Shared Function GetTypedTableSchema(ByVal xs As System.Xml.Schema.XmlSchemaSet) As System.Xml.Schema.XmlSchemaComplexType
            Dim type As System.Xml.Schema.XmlSchemaComplexType = New System.Xml.Schema.XmlSchemaComplexType
            Dim sequence As System.Xml.Schema.XmlSchemaSequence = New System.Xml.Schema.XmlSchemaSequence
            Dim ds As dsSUPPLIER_INFO1 = New dsSUPPLIER_INFO1
            xs.Add(ds.GetSchemaSerializable)
            Dim any1 As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny
            any1.Namespace = "http://www.w3.org/2001/XMLSchema"
            any1.MinOccurs = New Decimal(0)
            any1.MaxOccurs = Decimal.MaxValue
            any1.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax
            sequence.Items.Add(any1)
            Dim any2 As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny
            any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1"
            any2.MinOccurs = New Decimal(1)
            any2.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax
            sequence.Items.Add(any2)
            Dim attribute1 As System.Xml.Schema.XmlSchemaAttribute = New System.Xml.Schema.XmlSchemaAttribute
            attribute1.Name = "namespace"
            attribute1.FixedValue = ds.Namespace
            type.Attributes.Add(attribute1)
            Dim attribute2 As System.Xml.Schema.XmlSchemaAttribute = New System.Xml.Schema.XmlSchemaAttribute
            attribute2.Name = "tableTypeName"
            attribute2.FixedValue = "SUPPLIER_INFODataTable"
            type.Attributes.Add(attribute2)
            type.Particle = sequence
            Return type
        End Function
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")>  _
    Partial Public Class SUPPLIER_INFORow
        Inherits System.Data.DataRow
        
        Private tableSUPPLIER_INFO As SUPPLIER_INFODataTable
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Friend Sub New(ByVal rb As System.Data.DataRowBuilder)
            MyBase.New(rb)
            Me.tableSUPPLIER_INFO = CType(Me.Table,SUPPLIER_INFODataTable)
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property nID() As Decimal
            Get
                Return CType(Me(Me.tableSUPPLIER_INFO.nIDColumn),Decimal)
            End Get
            Set
                Me(Me.tableSUPPLIER_INFO.nIDColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sCONTACT_PERSON() As String
            Get
                Return CType(Me(Me.tableSUPPLIER_INFO.sCONTACT_PERSONColumn),String)
            End Get
            Set
                Me(Me.tableSUPPLIER_INFO.sCONTACT_PERSONColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sDESIGNATION() As String
            Get
                Try 
                    Return CType(Me(Me.tableSUPPLIER_INFO.sDESIGNATIONColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'sDESIGNATION' in table 'SUPPLIER_INFO' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableSUPPLIER_INFO.sDESIGNATIONColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sSUPPLIER_NAME() As String
            Get
                Return CType(Me(Me.tableSUPPLIER_INFO.sSUPPLIER_NAMEColumn),String)
            End Get
            Set
                Me(Me.tableSUPPLIER_INFO.sSUPPLIER_NAMEColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sADDRESS() As String
            Get
                Try 
                    Return CType(Me(Me.tableSUPPLIER_INFO.sADDRESSColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'sADDRESS' in table 'SUPPLIER_INFO' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableSUPPLIER_INFO.sADDRESSColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sSUPPLIER_PH() As String
            Get
                Try 
                    Return CType(Me(Me.tableSUPPLIER_INFO.sSUPPLIER_PHColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'sSUPPLIER_PH' in table 'SUPPLIER_INFO' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableSUPPLIER_INFO.sSUPPLIER_PHColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sPERSON_PH() As String
            Get
                Try 
                    Return CType(Me(Me.tableSUPPLIER_INFO.sPERSON_PHColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'sPERSON_PH' in table 'SUPPLIER_INFO' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableSUPPLIER_INFO.sPERSON_PHColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sCELL_NO() As String
            Get
                Try 
                    Return CType(Me(Me.tableSUPPLIER_INFO.sCELL_NOColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'sCELL_NO' in table 'SUPPLIER_INFO' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableSUPPLIER_INFO.sCELL_NOColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sFAX_NO() As String
            Get
                Try 
                    Return CType(Me(Me.tableSUPPLIER_INFO.sFAX_NOColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'sFAX_NO' in table 'SUPPLIER_INFO' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableSUPPLIER_INFO.sFAX_NOColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sE_MAIL() As String
            Get
                Try 
                    Return CType(Me(Me.tableSUPPLIER_INFO.sE_MAILColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'sE_MAIL' in table 'SUPPLIER_INFO' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableSUPPLIER_INFO.sE_MAILColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sWEB_ADD() As String
            Get
                Try 
                    Return CType(Me(Me.tableSUPPLIER_INFO.sWEB_ADDColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'sWEB_ADD' in table 'SUPPLIER_INFO' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableSUPPLIER_INFO.sWEB_ADDColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property STATUS() As String
            Get
                Try 
                    Return CType(Me(Me.tableSUPPLIER_INFO.STATUSColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'STATUS' in table 'SUPPLIER_INFO' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableSUPPLIER_INFO.STATUSColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property nOPEN_BAL() As Decimal
            Get
                Return CType(Me(Me.tableSUPPLIER_INFO.nOPEN_BALColumn),Decimal)
            End Get
            Set
                Me(Me.tableSUPPLIER_INFO.nOPEN_BALColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IssDESIGNATIONNull() As Boolean
            Return Me.IsNull(Me.tableSUPPLIER_INFO.sDESIGNATIONColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetsDESIGNATIONNull()
            Me(Me.tableSUPPLIER_INFO.sDESIGNATIONColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IssADDRESSNull() As Boolean
            Return Me.IsNull(Me.tableSUPPLIER_INFO.sADDRESSColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetsADDRESSNull()
            Me(Me.tableSUPPLIER_INFO.sADDRESSColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IssSUPPLIER_PHNull() As Boolean
            Return Me.IsNull(Me.tableSUPPLIER_INFO.sSUPPLIER_PHColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetsSUPPLIER_PHNull()
            Me(Me.tableSUPPLIER_INFO.sSUPPLIER_PHColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IssPERSON_PHNull() As Boolean
            Return Me.IsNull(Me.tableSUPPLIER_INFO.sPERSON_PHColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetsPERSON_PHNull()
            Me(Me.tableSUPPLIER_INFO.sPERSON_PHColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IssCELL_NONull() As Boolean
            Return Me.IsNull(Me.tableSUPPLIER_INFO.sCELL_NOColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetsCELL_NONull()
            Me(Me.tableSUPPLIER_INFO.sCELL_NOColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IssFAX_NONull() As Boolean
            Return Me.IsNull(Me.tableSUPPLIER_INFO.sFAX_NOColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetsFAX_NONull()
            Me(Me.tableSUPPLIER_INFO.sFAX_NOColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IssE_MAILNull() As Boolean
            Return Me.IsNull(Me.tableSUPPLIER_INFO.sE_MAILColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetsE_MAILNull()
            Me(Me.tableSUPPLIER_INFO.sE_MAILColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IssWEB_ADDNull() As Boolean
            Return Me.IsNull(Me.tableSUPPLIER_INFO.sWEB_ADDColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetsWEB_ADDNull()
            Me(Me.tableSUPPLIER_INFO.sWEB_ADDColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IsSTATUSNull() As Boolean
            Return Me.IsNull(Me.tableSUPPLIER_INFO.STATUSColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetSTATUSNull()
            Me(Me.tableSUPPLIER_INFO.STATUSColumn) = System.Convert.DBNull
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")>  _
    Public Class SUPPLIER_INFORowChangeEvent
        Inherits System.EventArgs
        
        Private eventRow As SUPPLIER_INFORow
        
        Private eventAction As System.Data.DataRowAction
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub New(ByVal row As SUPPLIER_INFORow, ByVal action As System.Data.DataRowAction)
            MyBase.New
            Me.eventRow = row
            Me.eventAction = action
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property Row() As SUPPLIER_INFORow
            Get
                Return Me.eventRow
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property Action() As System.Data.DataRowAction
            Get
                Return Me.eventAction
            End Get
        End Property
    End Class
End Class
