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
 System.Xml.Serialization.XmlRootAttribute("dsLUP_SUPPLIER_OPEN_BAL"),  _
 System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")>  _
Partial Public Class dsLUP_SUPPLIER_OPEN_BAL
    Inherits System.Data.DataSet
    
    Private tableV_SUPPLIER_OPEN_BAL As V_SUPPLIER_OPEN_BALDataTable
    
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
            If (Not (ds.Tables("V_SUPPLIER_OPEN_BAL")) Is Nothing) Then
                MyBase.Tables.Add(New V_SUPPLIER_OPEN_BALDataTable(ds.Tables("V_SUPPLIER_OPEN_BAL")))
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
    Public ReadOnly Property V_SUPPLIER_OPEN_BAL() As V_SUPPLIER_OPEN_BALDataTable
        Get
            Return Me.tableV_SUPPLIER_OPEN_BAL
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
        Dim cln As dsLUP_SUPPLIER_OPEN_BAL = CType(MyBase.Clone,dsLUP_SUPPLIER_OPEN_BAL)
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
            If (Not (ds.Tables("V_SUPPLIER_OPEN_BAL")) Is Nothing) Then
                MyBase.Tables.Add(New V_SUPPLIER_OPEN_BALDataTable(ds.Tables("V_SUPPLIER_OPEN_BAL")))
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
        Me.tableV_SUPPLIER_OPEN_BAL = CType(MyBase.Tables("V_SUPPLIER_OPEN_BAL"),V_SUPPLIER_OPEN_BALDataTable)
        If (initTable = true) Then
            If (Not (Me.tableV_SUPPLIER_OPEN_BAL) Is Nothing) Then
                Me.tableV_SUPPLIER_OPEN_BAL.InitVars
            End If
        End If
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Sub InitClass()
        Me.DataSetName = "dsLUP_SUPPLIER_OPEN_BAL"
        Me.Prefix = ""
        Me.Namespace = "http://tempuri.org/dsLUP_SUPPLIER_OPEN_BAL.xsd"
        Me.EnforceConstraints = true
        Me.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        Me.tableV_SUPPLIER_OPEN_BAL = New V_SUPPLIER_OPEN_BALDataTable
        MyBase.Tables.Add(Me.tableV_SUPPLIER_OPEN_BAL)
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Function ShouldSerializeV_SUPPLIER_OPEN_BAL() As Boolean
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
        Dim ds As dsLUP_SUPPLIER_OPEN_BAL = New dsLUP_SUPPLIER_OPEN_BAL
        Dim type As System.Xml.Schema.XmlSchemaComplexType = New System.Xml.Schema.XmlSchemaComplexType
        Dim sequence As System.Xml.Schema.XmlSchemaSequence = New System.Xml.Schema.XmlSchemaSequence
        xs.Add(ds.GetSchemaSerializable)
        Dim any As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny
        any.Namespace = ds.Namespace
        sequence.Items.Add(any)
        type.Particle = sequence
        Return type
    End Function
    
    Public Delegate Sub V_SUPPLIER_OPEN_BALRowChangeEventHandler(ByVal sender As Object, ByVal e As V_SUPPLIER_OPEN_BALRowChangeEvent)
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"),  _
     System.Serializable(),  _
     System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")>  _
    Partial Public Class V_SUPPLIER_OPEN_BALDataTable
        Inherits System.Data.DataTable
        Implements System.Collections.IEnumerable
        
        Private columnID As System.Data.DataColumn
        
        Private columnSUPPLIER_NAME As System.Data.DataColumn
        
        Private columnGROUP_NAME As System.Data.DataColumn
        
        Private columnOPEN_BAL As System.Data.DataColumn
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub New()
            MyBase.New
            Me.TableName = "V_SUPPLIER_OPEN_BAL"
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
        Public ReadOnly Property IDColumn() As System.Data.DataColumn
            Get
                Return Me.columnID
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property SUPPLIER_NAMEColumn() As System.Data.DataColumn
            Get
                Return Me.columnSUPPLIER_NAME
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property GROUP_NAMEColumn() As System.Data.DataColumn
            Get
                Return Me.columnGROUP_NAME
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property OPEN_BALColumn() As System.Data.DataColumn
            Get
                Return Me.columnOPEN_BAL
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
        Public Default ReadOnly Property Item(ByVal index As Integer) As V_SUPPLIER_OPEN_BALRow
            Get
                Return CType(Me.Rows(index),V_SUPPLIER_OPEN_BALRow)
            End Get
        End Property
        
        Public Event V_SUPPLIER_OPEN_BALRowChanging As V_SUPPLIER_OPEN_BALRowChangeEventHandler
        
        Public Event V_SUPPLIER_OPEN_BALRowChanged As V_SUPPLIER_OPEN_BALRowChangeEventHandler
        
        Public Event V_SUPPLIER_OPEN_BALRowDeleting As V_SUPPLIER_OPEN_BALRowChangeEventHandler
        
        Public Event V_SUPPLIER_OPEN_BALRowDeleted As V_SUPPLIER_OPEN_BALRowChangeEventHandler
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overloads Sub AddV_SUPPLIER_OPEN_BALRow(ByVal row As V_SUPPLIER_OPEN_BALRow)
            Me.Rows.Add(row)
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overloads Function AddV_SUPPLIER_OPEN_BALRow(ByVal SUPPLIER_NAME As String, ByVal GROUP_NAME As String, ByVal OPEN_BAL As Decimal) As V_SUPPLIER_OPEN_BALRow
            Dim rowV_SUPPLIER_OPEN_BALRow As V_SUPPLIER_OPEN_BALRow = CType(Me.NewRow,V_SUPPLIER_OPEN_BALRow)
            rowV_SUPPLIER_OPEN_BALRow.ItemArray = New Object() {Nothing, SUPPLIER_NAME, GROUP_NAME, OPEN_BAL}
            Me.Rows.Add(rowV_SUPPLIER_OPEN_BALRow)
            Return rowV_SUPPLIER_OPEN_BALRow
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function FindByID(ByVal ID As Decimal) As V_SUPPLIER_OPEN_BALRow
            Return CType(Me.Rows.Find(New Object() {ID}),V_SUPPLIER_OPEN_BALRow)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overridable Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Me.Rows.GetEnumerator
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overrides Function Clone() As System.Data.DataTable
            Dim cln As V_SUPPLIER_OPEN_BALDataTable = CType(MyBase.Clone,V_SUPPLIER_OPEN_BALDataTable)
            cln.InitVars
            Return cln
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Function CreateInstance() As System.Data.DataTable
            Return New V_SUPPLIER_OPEN_BALDataTable
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Friend Sub InitVars()
            Me.columnID = MyBase.Columns("ID")
            Me.columnSUPPLIER_NAME = MyBase.Columns("SUPPLIER_NAME")
            Me.columnGROUP_NAME = MyBase.Columns("GROUP_NAME")
            Me.columnOPEN_BAL = MyBase.Columns("OPEN_BAL")
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Private Sub InitClass()
            Me.columnID = New System.Data.DataColumn("ID", GetType(Decimal), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnID)
            Me.columnSUPPLIER_NAME = New System.Data.DataColumn("SUPPLIER_NAME", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnSUPPLIER_NAME)
            Me.columnGROUP_NAME = New System.Data.DataColumn("GROUP_NAME", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnGROUP_NAME)
            Me.columnOPEN_BAL = New System.Data.DataColumn("OPEN_BAL", GetType(Decimal), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnOPEN_BAL)
            Me.Constraints.Add(New System.Data.UniqueConstraint("Constraint1", New System.Data.DataColumn() {Me.columnID}, true))
            Me.columnID.AutoIncrement = true
            Me.columnID.AllowDBNull = false
            Me.columnID.ReadOnly = true
            Me.columnID.Unique = true
            Me.columnSUPPLIER_NAME.AllowDBNull = false
            Me.columnSUPPLIER_NAME.MaxLength = 50
            Me.columnGROUP_NAME.MaxLength = 50
            Me.columnOPEN_BAL.ReadOnly = true
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function NewV_SUPPLIER_OPEN_BALRow() As V_SUPPLIER_OPEN_BALRow
            Return CType(Me.NewRow,V_SUPPLIER_OPEN_BALRow)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Function NewRowFromBuilder(ByVal builder As System.Data.DataRowBuilder) As System.Data.DataRow
            Return New V_SUPPLIER_OPEN_BALRow(builder)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Function GetRowType() As System.Type
            Return GetType(V_SUPPLIER_OPEN_BALRow)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowChanged(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowChanged(e)
            If (Not (Me.V_SUPPLIER_OPEN_BALRowChangedEvent) Is Nothing) Then
                RaiseEvent V_SUPPLIER_OPEN_BALRowChanged(Me, New V_SUPPLIER_OPEN_BALRowChangeEvent(CType(e.Row,V_SUPPLIER_OPEN_BALRow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowChanging(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowChanging(e)
            If (Not (Me.V_SUPPLIER_OPEN_BALRowChangingEvent) Is Nothing) Then
                RaiseEvent V_SUPPLIER_OPEN_BALRowChanging(Me, New V_SUPPLIER_OPEN_BALRowChangeEvent(CType(e.Row,V_SUPPLIER_OPEN_BALRow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowDeleted(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowDeleted(e)
            If (Not (Me.V_SUPPLIER_OPEN_BALRowDeletedEvent) Is Nothing) Then
                RaiseEvent V_SUPPLIER_OPEN_BALRowDeleted(Me, New V_SUPPLIER_OPEN_BALRowChangeEvent(CType(e.Row,V_SUPPLIER_OPEN_BALRow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowDeleting(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowDeleting(e)
            If (Not (Me.V_SUPPLIER_OPEN_BALRowDeletingEvent) Is Nothing) Then
                RaiseEvent V_SUPPLIER_OPEN_BALRowDeleting(Me, New V_SUPPLIER_OPEN_BALRowChangeEvent(CType(e.Row,V_SUPPLIER_OPEN_BALRow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub RemoveV_SUPPLIER_OPEN_BALRow(ByVal row As V_SUPPLIER_OPEN_BALRow)
            Me.Rows.Remove(row)
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Shared Function GetTypedTableSchema(ByVal xs As System.Xml.Schema.XmlSchemaSet) As System.Xml.Schema.XmlSchemaComplexType
            Dim type As System.Xml.Schema.XmlSchemaComplexType = New System.Xml.Schema.XmlSchemaComplexType
            Dim sequence As System.Xml.Schema.XmlSchemaSequence = New System.Xml.Schema.XmlSchemaSequence
            Dim ds As dsLUP_SUPPLIER_OPEN_BAL = New dsLUP_SUPPLIER_OPEN_BAL
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
            attribute2.FixedValue = "V_SUPPLIER_OPEN_BALDataTable"
            type.Attributes.Add(attribute2)
            type.Particle = sequence
            Return type
        End Function
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")>  _
    Partial Public Class V_SUPPLIER_OPEN_BALRow
        Inherits System.Data.DataRow
        
        Private tableV_SUPPLIER_OPEN_BAL As V_SUPPLIER_OPEN_BALDataTable
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Friend Sub New(ByVal rb As System.Data.DataRowBuilder)
            MyBase.New(rb)
            Me.tableV_SUPPLIER_OPEN_BAL = CType(Me.Table,V_SUPPLIER_OPEN_BALDataTable)
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property ID() As Decimal
            Get
                Return CType(Me(Me.tableV_SUPPLIER_OPEN_BAL.IDColumn),Decimal)
            End Get
            Set
                Me(Me.tableV_SUPPLIER_OPEN_BAL.IDColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property SUPPLIER_NAME() As String
            Get
                Return CType(Me(Me.tableV_SUPPLIER_OPEN_BAL.SUPPLIER_NAMEColumn),String)
            End Get
            Set
                Me(Me.tableV_SUPPLIER_OPEN_BAL.SUPPLIER_NAMEColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property GROUP_NAME() As String
            Get
                Try 
                    Return CType(Me(Me.tableV_SUPPLIER_OPEN_BAL.GROUP_NAMEColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'GROUP_NAME' in table 'V_SUPPLIER_OPEN_BAL' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableV_SUPPLIER_OPEN_BAL.GROUP_NAMEColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property OPEN_BAL() As Decimal
            Get
                Try 
                    Return CType(Me(Me.tableV_SUPPLIER_OPEN_BAL.OPEN_BALColumn),Decimal)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'OPEN_BAL' in table 'V_SUPPLIER_OPEN_BAL' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableV_SUPPLIER_OPEN_BAL.OPEN_BALColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IsGROUP_NAMENull() As Boolean
            Return Me.IsNull(Me.tableV_SUPPLIER_OPEN_BAL.GROUP_NAMEColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetGROUP_NAMENull()
            Me(Me.tableV_SUPPLIER_OPEN_BAL.GROUP_NAMEColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IsOPEN_BALNull() As Boolean
            Return Me.IsNull(Me.tableV_SUPPLIER_OPEN_BAL.OPEN_BALColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetOPEN_BALNull()
            Me(Me.tableV_SUPPLIER_OPEN_BAL.OPEN_BALColumn) = System.Convert.DBNull
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")>  _
    Public Class V_SUPPLIER_OPEN_BALRowChangeEvent
        Inherits System.EventArgs
        
        Private eventRow As V_SUPPLIER_OPEN_BALRow
        
        Private eventAction As System.Data.DataRowAction
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub New(ByVal row As V_SUPPLIER_OPEN_BALRow, ByVal action As System.Data.DataRowAction)
            MyBase.New
            Me.eventRow = row
            Me.eventAction = action
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property Row() As V_SUPPLIER_OPEN_BALRow
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
