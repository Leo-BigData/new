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
 System.Xml.Serialization.XmlRootAttribute("dsLUP_BUSINESS_INFO"),  _
 System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")>  _
Partial Public Class dsLUP_BUSINESS_INFO
    Inherits System.Data.DataSet
    
    Private tableBUSINESS_INFO As BUSINESS_INFODataTable
    
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
            If (Not (ds.Tables("BUSINESS_INFO")) Is Nothing) Then
                MyBase.Tables.Add(New BUSINESS_INFODataTable(ds.Tables("BUSINESS_INFO")))
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
    Public ReadOnly Property BUSINESS_INFO() As BUSINESS_INFODataTable
        Get
            Return Me.tableBUSINESS_INFO
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
        Dim cln As dsLUP_BUSINESS_INFO = CType(MyBase.Clone,dsLUP_BUSINESS_INFO)
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
            If (Not (ds.Tables("BUSINESS_INFO")) Is Nothing) Then
                MyBase.Tables.Add(New BUSINESS_INFODataTable(ds.Tables("BUSINESS_INFO")))
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
        Me.tableBUSINESS_INFO = CType(MyBase.Tables("BUSINESS_INFO"),BUSINESS_INFODataTable)
        If (initTable = true) Then
            If (Not (Me.tableBUSINESS_INFO) Is Nothing) Then
                Me.tableBUSINESS_INFO.InitVars
            End If
        End If
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Sub InitClass()
        Me.DataSetName = "dsLUP_BUSINESS_INFO"
        Me.Prefix = ""
        Me.Namespace = "http://tempuri.org/dsLUP_BUSINESS_INFO.xsd"
        Me.EnforceConstraints = true
        Me.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        Me.tableBUSINESS_INFO = New BUSINESS_INFODataTable
        MyBase.Tables.Add(Me.tableBUSINESS_INFO)
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Function ShouldSerializeBUSINESS_INFO() As Boolean
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
        Dim ds As dsLUP_BUSINESS_INFO = New dsLUP_BUSINESS_INFO
        Dim type As System.Xml.Schema.XmlSchemaComplexType = New System.Xml.Schema.XmlSchemaComplexType
        Dim sequence As System.Xml.Schema.XmlSchemaSequence = New System.Xml.Schema.XmlSchemaSequence
        xs.Add(ds.GetSchemaSerializable)
        Dim any As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny
        any.Namespace = ds.Namespace
        sequence.Items.Add(any)
        type.Particle = sequence
        Return type
    End Function
    
    Public Delegate Sub BUSINESS_INFORowChangeEventHandler(ByVal sender As Object, ByVal e As BUSINESS_INFORowChangeEvent)
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"),  _
     System.Serializable(),  _
     System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")>  _
    Partial Public Class BUSINESS_INFODataTable
        Inherits System.Data.DataTable
        Implements System.Collections.IEnumerable
        
        Private columnnID As System.Data.DataColumn
        
        Private columnsBUSINESS_NAME As System.Data.DataColumn
        
        Private columnsADDRESS As System.Data.DataColumn
        
        Private columnsCITY As System.Data.DataColumn
        
        Private columnsPHONE As System.Data.DataColumn
        
        Private columnsCELL_NO As System.Data.DataColumn
        
        Private columnsFAX As System.Data.DataColumn
        
        Private columnsWEB_ADDRESS As System.Data.DataColumn
        
        Private columnsE_MAIL As System.Data.DataColumn
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub New()
            MyBase.New
            Me.TableName = "BUSINESS_INFO"
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
        Public ReadOnly Property sBUSINESS_NAMEColumn() As System.Data.DataColumn
            Get
                Return Me.columnsBUSINESS_NAME
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sADDRESSColumn() As System.Data.DataColumn
            Get
                Return Me.columnsADDRESS
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sCITYColumn() As System.Data.DataColumn
            Get
                Return Me.columnsCITY
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sPHONEColumn() As System.Data.DataColumn
            Get
                Return Me.columnsPHONE
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sCELL_NOColumn() As System.Data.DataColumn
            Get
                Return Me.columnsCELL_NO
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sFAXColumn() As System.Data.DataColumn
            Get
                Return Me.columnsFAX
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sWEB_ADDRESSColumn() As System.Data.DataColumn
            Get
                Return Me.columnsWEB_ADDRESS
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sE_MAILColumn() As System.Data.DataColumn
            Get
                Return Me.columnsE_MAIL
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
        Public Default ReadOnly Property Item(ByVal index As Integer) As BUSINESS_INFORow
            Get
                Return CType(Me.Rows(index),BUSINESS_INFORow)
            End Get
        End Property
        
        Public Event BUSINESS_INFORowChanging As BUSINESS_INFORowChangeEventHandler
        
        Public Event BUSINESS_INFORowChanged As BUSINESS_INFORowChangeEventHandler
        
        Public Event BUSINESS_INFORowDeleting As BUSINESS_INFORowChangeEventHandler
        
        Public Event BUSINESS_INFORowDeleted As BUSINESS_INFORowChangeEventHandler
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overloads Sub AddBUSINESS_INFORow(ByVal row As BUSINESS_INFORow)
            Me.Rows.Add(row)
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overloads Function AddBUSINESS_INFORow(ByVal nID As Decimal, ByVal sBUSINESS_NAME As String, ByVal sADDRESS As String, ByVal sCITY As String, ByVal sPHONE As String, ByVal sCELL_NO As String, ByVal sFAX As String, ByVal sWEB_ADDRESS As String, ByVal sE_MAIL As String) As BUSINESS_INFORow
            Dim rowBUSINESS_INFORow As BUSINESS_INFORow = CType(Me.NewRow,BUSINESS_INFORow)
            rowBUSINESS_INFORow.ItemArray = New Object() {nID, sBUSINESS_NAME, sADDRESS, sCITY, sPHONE, sCELL_NO, sFAX, sWEB_ADDRESS, sE_MAIL}
            Me.Rows.Add(rowBUSINESS_INFORow)
            Return rowBUSINESS_INFORow
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function FindBynID(ByVal nID As Decimal) As BUSINESS_INFORow
            Return CType(Me.Rows.Find(New Object() {nID}),BUSINESS_INFORow)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overridable Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Me.Rows.GetEnumerator
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overrides Function Clone() As System.Data.DataTable
            Dim cln As BUSINESS_INFODataTable = CType(MyBase.Clone,BUSINESS_INFODataTable)
            cln.InitVars
            Return cln
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Function CreateInstance() As System.Data.DataTable
            Return New BUSINESS_INFODataTable
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Friend Sub InitVars()
            Me.columnnID = MyBase.Columns("nID")
            Me.columnsBUSINESS_NAME = MyBase.Columns("sBUSINESS_NAME")
            Me.columnsADDRESS = MyBase.Columns("sADDRESS")
            Me.columnsCITY = MyBase.Columns("sCITY")
            Me.columnsPHONE = MyBase.Columns("sPHONE")
            Me.columnsCELL_NO = MyBase.Columns("sCELL_NO")
            Me.columnsFAX = MyBase.Columns("sFAX")
            Me.columnsWEB_ADDRESS = MyBase.Columns("sWEB_ADDRESS")
            Me.columnsE_MAIL = MyBase.Columns("sE_MAIL")
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Private Sub InitClass()
            Me.columnnID = New System.Data.DataColumn("nID", GetType(Decimal), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnnID)
            Me.columnsBUSINESS_NAME = New System.Data.DataColumn("sBUSINESS_NAME", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsBUSINESS_NAME)
            Me.columnsADDRESS = New System.Data.DataColumn("sADDRESS", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsADDRESS)
            Me.columnsCITY = New System.Data.DataColumn("sCITY", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsCITY)
            Me.columnsPHONE = New System.Data.DataColumn("sPHONE", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsPHONE)
            Me.columnsCELL_NO = New System.Data.DataColumn("sCELL_NO", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsCELL_NO)
            Me.columnsFAX = New System.Data.DataColumn("sFAX", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsFAX)
            Me.columnsWEB_ADDRESS = New System.Data.DataColumn("sWEB_ADDRESS", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsWEB_ADDRESS)
            Me.columnsE_MAIL = New System.Data.DataColumn("sE_MAIL", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsE_MAIL)
            Me.Constraints.Add(New System.Data.UniqueConstraint("Constraint1", New System.Data.DataColumn() {Me.columnnID}, true))
            Me.columnnID.AllowDBNull = false
            Me.columnnID.Unique = true
            Me.columnsBUSINESS_NAME.MaxLength = 50
            Me.columnsADDRESS.MaxLength = 150
            Me.columnsCITY.MaxLength = 50
            Me.columnsPHONE.MaxLength = 50
            Me.columnsCELL_NO.MaxLength = 50
            Me.columnsFAX.MaxLength = 50
            Me.columnsWEB_ADDRESS.MaxLength = 50
            Me.columnsE_MAIL.MaxLength = 50
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function NewBUSINESS_INFORow() As BUSINESS_INFORow
            Return CType(Me.NewRow,BUSINESS_INFORow)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Function NewRowFromBuilder(ByVal builder As System.Data.DataRowBuilder) As System.Data.DataRow
            Return New BUSINESS_INFORow(builder)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Function GetRowType() As System.Type
            Return GetType(BUSINESS_INFORow)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowChanged(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowChanged(e)
            If (Not (Me.BUSINESS_INFORowChangedEvent) Is Nothing) Then
                RaiseEvent BUSINESS_INFORowChanged(Me, New BUSINESS_INFORowChangeEvent(CType(e.Row,BUSINESS_INFORow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowChanging(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowChanging(e)
            If (Not (Me.BUSINESS_INFORowChangingEvent) Is Nothing) Then
                RaiseEvent BUSINESS_INFORowChanging(Me, New BUSINESS_INFORowChangeEvent(CType(e.Row,BUSINESS_INFORow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowDeleted(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowDeleted(e)
            If (Not (Me.BUSINESS_INFORowDeletedEvent) Is Nothing) Then
                RaiseEvent BUSINESS_INFORowDeleted(Me, New BUSINESS_INFORowChangeEvent(CType(e.Row,BUSINESS_INFORow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowDeleting(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowDeleting(e)
            If (Not (Me.BUSINESS_INFORowDeletingEvent) Is Nothing) Then
                RaiseEvent BUSINESS_INFORowDeleting(Me, New BUSINESS_INFORowChangeEvent(CType(e.Row,BUSINESS_INFORow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub RemoveBUSINESS_INFORow(ByVal row As BUSINESS_INFORow)
            Me.Rows.Remove(row)
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Shared Function GetTypedTableSchema(ByVal xs As System.Xml.Schema.XmlSchemaSet) As System.Xml.Schema.XmlSchemaComplexType
            Dim type As System.Xml.Schema.XmlSchemaComplexType = New System.Xml.Schema.XmlSchemaComplexType
            Dim sequence As System.Xml.Schema.XmlSchemaSequence = New System.Xml.Schema.XmlSchemaSequence
            Dim ds As dsLUP_BUSINESS_INFO = New dsLUP_BUSINESS_INFO
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
            attribute2.FixedValue = "BUSINESS_INFODataTable"
            type.Attributes.Add(attribute2)
            type.Particle = sequence
            Return type
        End Function
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")>  _
    Partial Public Class BUSINESS_INFORow
        Inherits System.Data.DataRow
        
        Private tableBUSINESS_INFO As BUSINESS_INFODataTable
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Friend Sub New(ByVal rb As System.Data.DataRowBuilder)
            MyBase.New(rb)
            Me.tableBUSINESS_INFO = CType(Me.Table,BUSINESS_INFODataTable)
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property nID() As Decimal
            Get
                Return CType(Me(Me.tableBUSINESS_INFO.nIDColumn),Decimal)
            End Get
            Set
                Me(Me.tableBUSINESS_INFO.nIDColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sBUSINESS_NAME() As String
            Get
                Try 
                    Return CType(Me(Me.tableBUSINESS_INFO.sBUSINESS_NAMEColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'sBUSINESS_NAME' in table 'BUSINESS_INFO' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableBUSINESS_INFO.sBUSINESS_NAMEColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sADDRESS() As String
            Get
                Try 
                    Return CType(Me(Me.tableBUSINESS_INFO.sADDRESSColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'sADDRESS' in table 'BUSINESS_INFO' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableBUSINESS_INFO.sADDRESSColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sCITY() As String
            Get
                Try 
                    Return CType(Me(Me.tableBUSINESS_INFO.sCITYColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'sCITY' in table 'BUSINESS_INFO' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableBUSINESS_INFO.sCITYColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sPHONE() As String
            Get
                Try 
                    Return CType(Me(Me.tableBUSINESS_INFO.sPHONEColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'sPHONE' in table 'BUSINESS_INFO' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableBUSINESS_INFO.sPHONEColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sCELL_NO() As String
            Get
                Try 
                    Return CType(Me(Me.tableBUSINESS_INFO.sCELL_NOColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'sCELL_NO' in table 'BUSINESS_INFO' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableBUSINESS_INFO.sCELL_NOColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sFAX() As String
            Get
                Try 
                    Return CType(Me(Me.tableBUSINESS_INFO.sFAXColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'sFAX' in table 'BUSINESS_INFO' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableBUSINESS_INFO.sFAXColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sWEB_ADDRESS() As String
            Get
                Try 
                    Return CType(Me(Me.tableBUSINESS_INFO.sWEB_ADDRESSColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'sWEB_ADDRESS' in table 'BUSINESS_INFO' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableBUSINESS_INFO.sWEB_ADDRESSColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sE_MAIL() As String
            Get
                Try 
                    Return CType(Me(Me.tableBUSINESS_INFO.sE_MAILColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'sE_MAIL' in table 'BUSINESS_INFO' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableBUSINESS_INFO.sE_MAILColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IssBUSINESS_NAMENull() As Boolean
            Return Me.IsNull(Me.tableBUSINESS_INFO.sBUSINESS_NAMEColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetsBUSINESS_NAMENull()
            Me(Me.tableBUSINESS_INFO.sBUSINESS_NAMEColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IssADDRESSNull() As Boolean
            Return Me.IsNull(Me.tableBUSINESS_INFO.sADDRESSColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetsADDRESSNull()
            Me(Me.tableBUSINESS_INFO.sADDRESSColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IssCITYNull() As Boolean
            Return Me.IsNull(Me.tableBUSINESS_INFO.sCITYColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetsCITYNull()
            Me(Me.tableBUSINESS_INFO.sCITYColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IssPHONENull() As Boolean
            Return Me.IsNull(Me.tableBUSINESS_INFO.sPHONEColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetsPHONENull()
            Me(Me.tableBUSINESS_INFO.sPHONEColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IssCELL_NONull() As Boolean
            Return Me.IsNull(Me.tableBUSINESS_INFO.sCELL_NOColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetsCELL_NONull()
            Me(Me.tableBUSINESS_INFO.sCELL_NOColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IssFAXNull() As Boolean
            Return Me.IsNull(Me.tableBUSINESS_INFO.sFAXColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetsFAXNull()
            Me(Me.tableBUSINESS_INFO.sFAXColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IssWEB_ADDRESSNull() As Boolean
            Return Me.IsNull(Me.tableBUSINESS_INFO.sWEB_ADDRESSColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetsWEB_ADDRESSNull()
            Me(Me.tableBUSINESS_INFO.sWEB_ADDRESSColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IssE_MAILNull() As Boolean
            Return Me.IsNull(Me.tableBUSINESS_INFO.sE_MAILColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetsE_MAILNull()
            Me(Me.tableBUSINESS_INFO.sE_MAILColumn) = System.Convert.DBNull
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")>  _
    Public Class BUSINESS_INFORowChangeEvent
        Inherits System.EventArgs
        
        Private eventRow As BUSINESS_INFORow
        
        Private eventAction As System.Data.DataRowAction
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub New(ByVal row As BUSINESS_INFORow, ByVal action As System.Data.DataRowAction)
            MyBase.New
            Me.eventRow = row
            Me.eventAction = action
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property Row() As BUSINESS_INFORow
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
