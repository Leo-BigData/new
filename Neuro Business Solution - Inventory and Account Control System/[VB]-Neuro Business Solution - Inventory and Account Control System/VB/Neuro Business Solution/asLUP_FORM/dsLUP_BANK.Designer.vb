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
 System.Xml.Serialization.XmlRootAttribute("dsLUP_BANK"),  _
 System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")>  _
Partial Public Class dsLUP_BANK
    Inherits System.Data.DataSet
    
    Private tableLUP_BANK As LUP_BANKDataTable
    
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
            If (Not (ds.Tables("LUP_BANK")) Is Nothing) Then
                MyBase.Tables.Add(New LUP_BANKDataTable(ds.Tables("LUP_BANK")))
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
    Public ReadOnly Property LUP_BANK() As LUP_BANKDataTable
        Get
            Return Me.tableLUP_BANK
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
        Dim cln As dsLUP_BANK = CType(MyBase.Clone,dsLUP_BANK)
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
            If (Not (ds.Tables("LUP_BANK")) Is Nothing) Then
                MyBase.Tables.Add(New LUP_BANKDataTable(ds.Tables("LUP_BANK")))
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
        Me.tableLUP_BANK = CType(MyBase.Tables("LUP_BANK"),LUP_BANKDataTable)
        If (initTable = true) Then
            If (Not (Me.tableLUP_BANK) Is Nothing) Then
                Me.tableLUP_BANK.InitVars
            End If
        End If
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Sub InitClass()
        Me.DataSetName = "dsLUP_BANK"
        Me.Prefix = ""
        Me.Namespace = "http://www.tempuri.org/dsLUP_BANK.xsd"
        Me.EnforceConstraints = true
        Me.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        Me.tableLUP_BANK = New LUP_BANKDataTable
        MyBase.Tables.Add(Me.tableLUP_BANK)
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Private Function ShouldSerializeLUP_BANK() As Boolean
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
        Dim ds As dsLUP_BANK = New dsLUP_BANK
        Dim type As System.Xml.Schema.XmlSchemaComplexType = New System.Xml.Schema.XmlSchemaComplexType
        Dim sequence As System.Xml.Schema.XmlSchemaSequence = New System.Xml.Schema.XmlSchemaSequence
        xs.Add(ds.GetSchemaSerializable)
        Dim any As System.Xml.Schema.XmlSchemaAny = New System.Xml.Schema.XmlSchemaAny
        any.Namespace = ds.Namespace
        sequence.Items.Add(any)
        type.Particle = sequence
        Return type
    End Function
    
    Public Delegate Sub LUP_BANKRowChangeEventHandler(ByVal sender As Object, ByVal e As LUP_BANKRowChangeEvent)
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"),  _
     System.Serializable(),  _
     System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")>  _
    Partial Public Class LUP_BANKDataTable
        Inherits System.Data.DataTable
        Implements System.Collections.IEnumerable
        
        Private columnsACCOUNT_NO As System.Data.DataColumn
        
        Private columnsBANK_NAME As System.Data.DataColumn
        
        Private columnsBRANCH_NAME As System.Data.DataColumn
        
        Private columnsBRANCH_code As System.Data.DataColumn
        
        Private columnsADDRESS As System.Data.DataColumn
        
        Private columnsCONTACT1 As System.Data.DataColumn
        
        Private columnsCONTACT2 As System.Data.DataColumn
        
        Private columnsMANAGER_NAME As System.Data.DataColumn
        
        Private columnsMANAGER_PH As System.Data.DataColumn
        
        Private columnsMANAGER_CELL As System.Data.DataColumn
        
        Private columnsSTATUS As System.Data.DataColumn
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub New()
            MyBase.New
            Me.TableName = "LUP_BANK"
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
        Public ReadOnly Property sACCOUNT_NOColumn() As System.Data.DataColumn
            Get
                Return Me.columnsACCOUNT_NO
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sBANK_NAMEColumn() As System.Data.DataColumn
            Get
                Return Me.columnsBANK_NAME
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sBRANCH_NAMEColumn() As System.Data.DataColumn
            Get
                Return Me.columnsBRANCH_NAME
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sBRANCH_codeColumn() As System.Data.DataColumn
            Get
                Return Me.columnsBRANCH_code
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sADDRESSColumn() As System.Data.DataColumn
            Get
                Return Me.columnsADDRESS
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sCONTACT1Column() As System.Data.DataColumn
            Get
                Return Me.columnsCONTACT1
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sCONTACT2Column() As System.Data.DataColumn
            Get
                Return Me.columnsCONTACT2
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sMANAGER_NAMEColumn() As System.Data.DataColumn
            Get
                Return Me.columnsMANAGER_NAME
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sMANAGER_PHColumn() As System.Data.DataColumn
            Get
                Return Me.columnsMANAGER_PH
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sMANAGER_CELLColumn() As System.Data.DataColumn
            Get
                Return Me.columnsMANAGER_CELL
            End Get
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property sSTATUSColumn() As System.Data.DataColumn
            Get
                Return Me.columnsSTATUS
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
        Public Default ReadOnly Property Item(ByVal index As Integer) As LUP_BANKRow
            Get
                Return CType(Me.Rows(index),LUP_BANKRow)
            End Get
        End Property
        
        Public Event LUP_BANKRowChanging As LUP_BANKRowChangeEventHandler
        
        Public Event LUP_BANKRowChanged As LUP_BANKRowChangeEventHandler
        
        Public Event LUP_BANKRowDeleting As LUP_BANKRowChangeEventHandler
        
        Public Event LUP_BANKRowDeleted As LUP_BANKRowChangeEventHandler
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overloads Sub AddLUP_BANKRow(ByVal row As LUP_BANKRow)
            Me.Rows.Add(row)
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overloads Function AddLUP_BANKRow(ByVal sACCOUNT_NO As String, ByVal sBANK_NAME As String, ByVal sBRANCH_NAME As String, ByVal sBRANCH_code As String, ByVal sADDRESS As String, ByVal sCONTACT1 As String, ByVal sCONTACT2 As String, ByVal sMANAGER_NAME As String, ByVal sMANAGER_PH As String, ByVal sMANAGER_CELL As String, ByVal sSTATUS As Boolean) As LUP_BANKRow
            Dim rowLUP_BANKRow As LUP_BANKRow = CType(Me.NewRow,LUP_BANKRow)
            rowLUP_BANKRow.ItemArray = New Object() {sACCOUNT_NO, sBANK_NAME, sBRANCH_NAME, sBRANCH_code, sADDRESS, sCONTACT1, sCONTACT2, sMANAGER_NAME, sMANAGER_PH, sMANAGER_CELL, sSTATUS}
            Me.Rows.Add(rowLUP_BANKRow)
            Return rowLUP_BANKRow
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function FindBysACCOUNT_NO(ByVal sACCOUNT_NO As String) As LUP_BANKRow
            Return CType(Me.Rows.Find(New Object() {sACCOUNT_NO}),LUP_BANKRow)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overridable Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Me.Rows.GetEnumerator
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Overrides Function Clone() As System.Data.DataTable
            Dim cln As LUP_BANKDataTable = CType(MyBase.Clone,LUP_BANKDataTable)
            cln.InitVars
            Return cln
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Function CreateInstance() As System.Data.DataTable
            Return New LUP_BANKDataTable
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Friend Sub InitVars()
            Me.columnsACCOUNT_NO = MyBase.Columns("sACCOUNT_NO")
            Me.columnsBANK_NAME = MyBase.Columns("sBANK_NAME")
            Me.columnsBRANCH_NAME = MyBase.Columns("sBRANCH_NAME")
            Me.columnsBRANCH_code = MyBase.Columns("sBRANCH_code")
            Me.columnsADDRESS = MyBase.Columns("sADDRESS")
            Me.columnsCONTACT1 = MyBase.Columns("sCONTACT1")
            Me.columnsCONTACT2 = MyBase.Columns("sCONTACT2")
            Me.columnsMANAGER_NAME = MyBase.Columns("sMANAGER_NAME")
            Me.columnsMANAGER_PH = MyBase.Columns("sMANAGER_PH")
            Me.columnsMANAGER_CELL = MyBase.Columns("sMANAGER_CELL")
            Me.columnsSTATUS = MyBase.Columns("sSTATUS")
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Private Sub InitClass()
            Me.columnsACCOUNT_NO = New System.Data.DataColumn("sACCOUNT_NO", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsACCOUNT_NO)
            Me.columnsBANK_NAME = New System.Data.DataColumn("sBANK_NAME", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsBANK_NAME)
            Me.columnsBRANCH_NAME = New System.Data.DataColumn("sBRANCH_NAME", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsBRANCH_NAME)
            Me.columnsBRANCH_code = New System.Data.DataColumn("sBRANCH_code", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsBRANCH_code)
            Me.columnsADDRESS = New System.Data.DataColumn("sADDRESS", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsADDRESS)
            Me.columnsCONTACT1 = New System.Data.DataColumn("sCONTACT1", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsCONTACT1)
            Me.columnsCONTACT2 = New System.Data.DataColumn("sCONTACT2", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsCONTACT2)
            Me.columnsMANAGER_NAME = New System.Data.DataColumn("sMANAGER_NAME", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsMANAGER_NAME)
            Me.columnsMANAGER_PH = New System.Data.DataColumn("sMANAGER_PH", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsMANAGER_PH)
            Me.columnsMANAGER_CELL = New System.Data.DataColumn("sMANAGER_CELL", GetType(String), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsMANAGER_CELL)
            Me.columnsSTATUS = New System.Data.DataColumn("sSTATUS", GetType(Boolean), Nothing, System.Data.MappingType.Element)
            MyBase.Columns.Add(Me.columnsSTATUS)
            Me.Constraints.Add(New System.Data.UniqueConstraint("Constraint1", New System.Data.DataColumn() {Me.columnsACCOUNT_NO}, true))
            Me.columnsACCOUNT_NO.AllowDBNull = false
            Me.columnsACCOUNT_NO.Unique = true
            Me.columnsBANK_NAME.AllowDBNull = false
            Me.columnsBRANCH_NAME.AllowDBNull = false
            Me.columnsBRANCH_code.AllowDBNull = false
            Me.columnsADDRESS.AllowDBNull = false
            Me.columnsSTATUS.AllowDBNull = false
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function NewLUP_BANKRow() As LUP_BANKRow
            Return CType(Me.NewRow,LUP_BANKRow)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Function NewRowFromBuilder(ByVal builder As System.Data.DataRowBuilder) As System.Data.DataRow
            Return New LUP_BANKRow(builder)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Function GetRowType() As System.Type
            Return GetType(LUP_BANKRow)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowChanged(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowChanged(e)
            If (Not (Me.LUP_BANKRowChangedEvent) Is Nothing) Then
                RaiseEvent LUP_BANKRowChanged(Me, New LUP_BANKRowChangeEvent(CType(e.Row,LUP_BANKRow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowChanging(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowChanging(e)
            If (Not (Me.LUP_BANKRowChangingEvent) Is Nothing) Then
                RaiseEvent LUP_BANKRowChanging(Me, New LUP_BANKRowChangeEvent(CType(e.Row,LUP_BANKRow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowDeleted(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowDeleted(e)
            If (Not (Me.LUP_BANKRowDeletedEvent) Is Nothing) Then
                RaiseEvent LUP_BANKRowDeleted(Me, New LUP_BANKRowChangeEvent(CType(e.Row,LUP_BANKRow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Protected Overrides Sub OnRowDeleting(ByVal e As System.Data.DataRowChangeEventArgs)
            MyBase.OnRowDeleting(e)
            If (Not (Me.LUP_BANKRowDeletingEvent) Is Nothing) Then
                RaiseEvent LUP_BANKRowDeleting(Me, New LUP_BANKRowChangeEvent(CType(e.Row,LUP_BANKRow), e.Action))
            End If
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub RemoveLUP_BANKRow(ByVal row As LUP_BANKRow)
            Me.Rows.Remove(row)
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Shared Function GetTypedTableSchema(ByVal xs As System.Xml.Schema.XmlSchemaSet) As System.Xml.Schema.XmlSchemaComplexType
            Dim type As System.Xml.Schema.XmlSchemaComplexType = New System.Xml.Schema.XmlSchemaComplexType
            Dim sequence As System.Xml.Schema.XmlSchemaSequence = New System.Xml.Schema.XmlSchemaSequence
            Dim ds As dsLUP_BANK = New dsLUP_BANK
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
            attribute2.FixedValue = "LUP_BANKDataTable"
            type.Attributes.Add(attribute2)
            type.Particle = sequence
            Return type
        End Function
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")>  _
    Partial Public Class LUP_BANKRow
        Inherits System.Data.DataRow
        
        Private tableLUP_BANK As LUP_BANKDataTable
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Friend Sub New(ByVal rb As System.Data.DataRowBuilder)
            MyBase.New(rb)
            Me.tableLUP_BANK = CType(Me.Table,LUP_BANKDataTable)
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sACCOUNT_NO() As String
            Get
                Return CType(Me(Me.tableLUP_BANK.sACCOUNT_NOColumn),String)
            End Get
            Set
                Me(Me.tableLUP_BANK.sACCOUNT_NOColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sBANK_NAME() As String
            Get
                Return CType(Me(Me.tableLUP_BANK.sBANK_NAMEColumn),String)
            End Get
            Set
                Me(Me.tableLUP_BANK.sBANK_NAMEColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sBRANCH_NAME() As String
            Get
                Return CType(Me(Me.tableLUP_BANK.sBRANCH_NAMEColumn),String)
            End Get
            Set
                Me(Me.tableLUP_BANK.sBRANCH_NAMEColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sBRANCH_code() As String
            Get
                Return CType(Me(Me.tableLUP_BANK.sBRANCH_codeColumn),String)
            End Get
            Set
                Me(Me.tableLUP_BANK.sBRANCH_codeColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sADDRESS() As String
            Get
                Return CType(Me(Me.tableLUP_BANK.sADDRESSColumn),String)
            End Get
            Set
                Me(Me.tableLUP_BANK.sADDRESSColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sCONTACT1() As String
            Get
                Try 
                    Return CType(Me(Me.tableLUP_BANK.sCONTACT1Column),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'sCONTACT1' in table 'LUP_BANK' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableLUP_BANK.sCONTACT1Column) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sCONTACT2() As String
            Get
                Try 
                    Return CType(Me(Me.tableLUP_BANK.sCONTACT2Column),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'sCONTACT2' in table 'LUP_BANK' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableLUP_BANK.sCONTACT2Column) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sMANAGER_NAME() As String
            Get
                Try 
                    Return CType(Me(Me.tableLUP_BANK.sMANAGER_NAMEColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'sMANAGER_NAME' in table 'LUP_BANK' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableLUP_BANK.sMANAGER_NAMEColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sMANAGER_PH() As String
            Get
                Try 
                    Return CType(Me(Me.tableLUP_BANK.sMANAGER_PHColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'sMANAGER_PH' in table 'LUP_BANK' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableLUP_BANK.sMANAGER_PHColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sMANAGER_CELL() As String
            Get
                Try 
                    Return CType(Me(Me.tableLUP_BANK.sMANAGER_CELLColumn),String)
                Catch e As System.InvalidCastException
                    Throw New System.Data.StrongTypingException("The value for column 'sMANAGER_CELL' in table 'LUP_BANK' is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableLUP_BANK.sMANAGER_CELLColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property sSTATUS() As Boolean
            Get
                Return CType(Me(Me.tableLUP_BANK.sSTATUSColumn),Boolean)
            End Get
            Set
                Me(Me.tableLUP_BANK.sSTATUSColumn) = value
            End Set
        End Property
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IssCONTACT1Null() As Boolean
            Return Me.IsNull(Me.tableLUP_BANK.sCONTACT1Column)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetsCONTACT1Null()
            Me(Me.tableLUP_BANK.sCONTACT1Column) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IssCONTACT2Null() As Boolean
            Return Me.IsNull(Me.tableLUP_BANK.sCONTACT2Column)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetsCONTACT2Null()
            Me(Me.tableLUP_BANK.sCONTACT2Column) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IssMANAGER_NAMENull() As Boolean
            Return Me.IsNull(Me.tableLUP_BANK.sMANAGER_NAMEColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetsMANAGER_NAMENull()
            Me(Me.tableLUP_BANK.sMANAGER_NAMEColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IssMANAGER_PHNull() As Boolean
            Return Me.IsNull(Me.tableLUP_BANK.sMANAGER_PHColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetsMANAGER_PHNull()
            Me(Me.tableLUP_BANK.sMANAGER_PHColumn) = System.Convert.DBNull
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Function IssMANAGER_CELLNull() As Boolean
            Return Me.IsNull(Me.tableLUP_BANK.sMANAGER_CELLColumn)
        End Function
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub SetsMANAGER_CELLNull()
            Me(Me.tableLUP_BANK.sMANAGER_CELLColumn) = System.Convert.DBNull
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")>  _
    Public Class LUP_BANKRowChangeEvent
        Inherits System.EventArgs
        
        Private eventRow As LUP_BANKRow
        
        Private eventAction As System.Data.DataRowAction
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Sub New(ByVal row As LUP_BANKRow, ByVal action As System.Data.DataRowAction)
            MyBase.New
            Me.eventRow = row
            Me.eventAction = action
        End Sub
        
        <System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public ReadOnly Property Row() As LUP_BANKRow
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
