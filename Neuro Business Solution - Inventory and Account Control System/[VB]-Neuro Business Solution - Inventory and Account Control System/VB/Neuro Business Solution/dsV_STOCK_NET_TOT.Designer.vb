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
 System.Xml.Serialization.XmlRootAttribute("dsV_STOCK_NET_TOT"),  _
 System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")>  _
Partial Public Class dsV_STOCK_NET_TOT
    Inherits System.Data.DataSet
    
    Private tableV_STOCK_NET_TOTAL As V_STOCK_NET_TOTALDataTable
    
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
            If (Not (ds.Tables("V_STOCK_NET_TOTAL")) Is Nothing) Then
                MyBase.Tables.Add(New V_STOCK_NET_TOTALDataTable(ds.Tables("V_STOCK_NET_TOTAL")))
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
    Public ReadOnly Property V_STOCK_NET_TOTAL() As V_STOCK_NET_TOTALDataTable
        Get
            Return Me.tableV_STOCK_NET_TOTAL
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
        Dim cln As dsV_STOCK_NET_TOT = CType(MyBase.Clone,dsV_STOCK_NET_TOT)
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
            If (Not (ds.Tables("V_STOCK_NET_TOTAL")) Is Nothing) Then
                MyBase.Tables.Add(New V_STOCK_NET_TOTALDataTable(ds.Tables("V_STOCK_NET_TOTAL")))
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
        Me.tableV_STOCK_NET_TOTAL = CType(MyBase.Tables("V_STOCK_NET_TOTAL"),V_STOCK_NET_TOTALDataTable)
        If (initTable = true) Then
            If (Not (Me.tableV_STOCK_NET_TOTAL) Is Nothing) Then
                Me.tableV_STOCK_NET_TOTAL.InitVars
            End If
        End If
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Sub InitClass()
        Me.DataSetName = "dsV_STOCK_NET_TOT"
        Me.Prefix = ""
        Me.Namespace = "http://tempuri.org/dsV_STOCK_NET_TOT.xsd"
        Me.EnforceConstraints = true
        Me.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        Me.tableV_STOCK_NET_TOTAL = New V_STOCK_NET_TOTALDataTable
        MyBase.Tables.Add(Me.tableV_STOCK_NET_TOTAL)
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Function ShouldSerializeV_STOCK_NET_TOTAL() As Boolean
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
        Dim ds As dsV_STOCK_NET_TOT = New dsV_STOCK_NET_TOT
        Dim type As System.Xml.Schema.XmlSchemaComplexType = New System.Xml.Schema.XmlSchemaComplexType
        Dim sequence As System.Xml.Schema.XmlSchemaSequence = New System.Xml.Schema.XmlSchemaSequence
        xs.Add(ds.GetSchemaSerializable)
        Dim any As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny
        any.Namespace = ds.Namespace
        sequence.Items.Add(any)
        type.Particle = sequence
        Return type
    End Function
    
    Public Delegate Sub V_STOCK_NET_TOTALRowChangeEventHandler(ByVal sender As Object, ByVal e As V_STOCK_NET_TOTALRowChangeEvent)
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"),  _
     System.Serializable(),  _
     System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")>  _
    Partial Public Class V_STOCK_NET_TOTALDataTable
        Inherits System.Data.DataTable
        Implements System.Collections.IEnumerable
        
        Private columnCODE As System.Data.DataColumn
        
        Private columnBATCH As System.Data.DataColumn
        
        Private columnNET_TOTAL As System.Data.DataColumn
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub New()
            MyBase.New
            Me.TableName = "V_STOCK_NET_TOTAL"
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
        Public ReadOnly Property CODEColumn() As System.Data.DataColumn
            Get
                Return Me.columnCODE
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property BATCHColumn() As System.Data.DataColumn
            Get
                Return Me.columnBATCH
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property NET_TOTALColumn() As System.Data.DataColumn
            Get
                Return Me.columnNET_TOTAL
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
        Public Default ReadOnly Property Item(ByVal index As Integer) As V_STOCK_NET_TOTALRow
            Get
                Return CType(Me.Rows(index),V_STOCK_NET_TOTALRow)
            End Get
        End Property
        
        Public Event V_STOCK_NET_TOTALRowChanging As V_STOCK_NET_TOTALRowChangeEventHandler
        
        Public Event V_STOCK_NET_TOTALRowChanged As V_STOCK_NET_TOTALRowChangeEventHandler
        
        Public Event V_STOCK_NET_TOTALRowDeleting As V_STOCK_NET_TOTALRowChangeEventHandler
        
        Public Event V_STOCK_NET_TOTALRowDeleted As V_STOCK_NET_TOTALRowChangeEventHandler
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overloads Sub AddV_STOCK_NET_TOTALRow(ByVal row As V_STOCK_NET_TOTALRow)
            Me.Rows.Add(row)
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overloads Function AddV_STOCK_NET_TOTALRow(ByVal CODE As Decimal, ByVal BATCH As String, ByVal NET_TOTAL As Decimal) As V_STOCK_NET_TOTALRow
            Dim rowV_STOCK_NET_TOTALRow As V_STOCK_NET_TOTALRow = CType(Me.NewRow,V_STOCK_NET_TOTALRow)
            rowV_STOCK_NET_TOTALRow.ItemArray = New Object() {CODE, BATCH, NET_TOTAL}
            Me.Rows.Add(rowV_STOCK_NET_TOTALRow)
            Return rowV_STOCK_NET_TOTALRow
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overridable Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Me.Rows.GetEnumerator
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overrides Function Clone() As System.Data.DataTable
            Dim cln As V_STOCK_NET_TOTALDataTable = CType(MyBase.Clone,V_STOCK_NET_TOTALDataTable)
            cln.InitVars
            Return cln
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Function CreateInstance() As System.Data.DataTable
            Return New V_STOCK_NET_TOTALDataTable
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Friend Sub InitVars()
            Me.columnCODE = MyBase.Columns("CODE")
            Me.columnBATCH = MyBase.Columns("BATCH")
            Me.columnNET_TOTAL = MyBase.Columns("NET_TOTAL")
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Private Sub InitClass()
            Me.columnCODE = New System.Data.DataColumn("CODE", GetType(Decimal), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnCODE)
            Me.columnBATCH = New System.Data.DataColumn("BATCH", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnBATCH)
            Me.columnNET_TOTAL = New System.Data.DataColumn("NET_TOTAL", GetType(Decimal), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnNET_TOTAL)
            Me.columnCODE.AllowDBNull = false
            Me.columnBATCH.MaxLength = 50
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function NewV_STOCK_NET_TOTALRow() As V_STOCK_NET_TOTALRow
            Return CType(Me.NewRow,V_STOCK_NET_TOTALRow)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Function NewRowFromBuilder(ByVal builder As System.Data.DataRowBuilder) As System.Data.DataRow
            Return New V_STOCK_NET_TOTALRow(builder)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Function GetRowType() As System.Type
            Return GetType(V_STOCK_NET_TOTALRow)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowChanged(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowChanged(e)
            If (Not (Me.V_STOCK_NET_TOTALRowChangedEvent) Is Nothing) Then
                RaiseEvent V_STOCK_NET_TOTALRowChanged(Me, New V_STOCK_NET_TOTALRowChangeEvent(CType(e.Row,V_STOCK_NET_TOTALRow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowChanging(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowChanging(e)
            If (Not (Me.V_STOCK_NET_TOTALRowChangingEvent) Is Nothing) Then
                RaiseEvent V_STOCK_NET_TOTALRowChanging(Me, New V_STOCK_NET_TOTALRowChangeEvent(CType(e.Row,V_STOCK_NET_TOTALRow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowDeleted(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowDeleted(e)
            If (Not (Me.V_STOCK_NET_TOTALRowDeletedEvent) Is Nothing) Then
                RaiseEvent V_STOCK_NET_TOTALRowDeleted(Me, New V_STOCK_NET_TOTALRowChangeEvent(CType(e.Row,V_STOCK_NET_TOTALRow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowDeleting(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowDeleting(e)
            If (Not (Me.V_STOCK_NET_TOTALRowDeletingEvent) Is Nothing) Then
                RaiseEvent V_STOCK_NET_TOTALRowDeleting(Me, New V_STOCK_NET_TOTALRowChangeEvent(CType(e.Row,V_STOCK_NET_TOTALRow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub RemoveV_STOCK_NET_TOTALRow(ByVal row As V_STOCK_NET_TOTALRow)
            Me.Rows.Remove(row)
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Shared Function GetTypedTableSchema(ByVal xs As System.Xml.Schema.XmlSchemaSet) As System.Xml.Schema.XmlSchemaComplexType
            Dim type As System.Xml.Schema.XmlSchemaComplexType = New System.Xml.Schema.XmlSchemaComplexType
            Dim sequence As System.Xml.Schema.XmlSchemaSequence = New System.Xml.Schema.XmlSchemaSequence
            Dim ds As dsV_STOCK_NET_TOT = New dsV_STOCK_NET_TOT
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
            attribute2.FixedValue = "V_STOCK_NET_TOTALDataTable"
            type.Attributes.Add(attribute2)
            type.Particle = sequence
            Return type
        End Function
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")>  _
    Partial Public Class V_STOCK_NET_TOTALRow
        Inherits System.Data.DataRow
        
        Private tableV_STOCK_NET_TOTAL As V_STOCK_NET_TOTALDataTable
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Friend Sub New(ByVal rb As System.Data.DataRowBuilder)
            MyBase.New(rb)
            Me.tableV_STOCK_NET_TOTAL = CType(Me.Table,V_STOCK_NET_TOTALDataTable)
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property CODE() As Decimal
            Get
                Return CType(Me(Me.tableV_STOCK_NET_TOTAL.CODEColumn),Decimal)
            End Get
            Set
                Me(Me.tableV_STOCK_NET_TOTAL.CODEColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property BATCH() As String
            Get
                Try 
                    Return CType(Me(Me.tableV_STOCK_NET_TOTAL.BATCHColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'BATCH' in table 'V_STOCK_NET_TOTAL' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableV_STOCK_NET_TOTAL.BATCHColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property NET_TOTAL() As Decimal
            Get
                Try 
                    Return CType(Me(Me.tableV_STOCK_NET_TOTAL.NET_TOTALColumn),Decimal)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'NET_TOTAL' in table 'V_STOCK_NET_TOTAL' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableV_STOCK_NET_TOTAL.NET_TOTALColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IsBATCHNull() As Boolean
            Return Me.IsNull(Me.tableV_STOCK_NET_TOTAL.BATCHColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetBATCHNull()
            Me(Me.tableV_STOCK_NET_TOTAL.BATCHColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IsNET_TOTALNull() As Boolean
            Return Me.IsNull(Me.tableV_STOCK_NET_TOTAL.NET_TOTALColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetNET_TOTALNull()
            Me(Me.tableV_STOCK_NET_TOTAL.NET_TOTALColumn) = System.Convert.DBNull
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")>  _
    Public Class V_STOCK_NET_TOTALRowChangeEvent
        Inherits System.EventArgs
        
        Private eventRow As V_STOCK_NET_TOTALRow
        
        Private eventAction As System.Data.DataRowAction
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub New(ByVal row As V_STOCK_NET_TOTALRow, ByVal action As System.Data.DataRowAction)
            MyBase.New
            Me.eventRow = row
            Me.eventAction = action
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property Row() As V_STOCK_NET_TOTALRow
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
