Public Class MS_AccessConnection
    Private Shared _Instance As MS_AccessConnection
    Private _Connections As New Hashtable
    Public Sub Reset(ByVal connectionString As String)
        Dim connection As OleDb.OleDbConnection = Nothing
        Try
            connection = CType(_Connections(connectionString), OleDb.OleDbConnection)
            connection.Dispose()
            connection = Nothing
        Catch ex As Exception
            'Do Nothing
        End Try
    End Sub
    Public Sub ResetAll()
        For Each Item As Object In _Connections
            Dim connection As OleDb.OleDbConnection = Nothing

            Try
                connection = CType(Item, OleDb.OleDbConnection)
                connection.Dispose()
                connection = Nothing
            Catch ex As Exception
                'Do Nothing
            End Try
        Next

    End Sub
    Public Function GetConnection(ByVal connectionString As String) As OleDb.OleDbConnection
        Dim connection As OleDb.OleDbConnection = Nothing
        Dim bNeedAdd As Boolean = False
        Try
            connection = CType(_Connections(connectionString), OleDb.OleDbConnection)
        Catch ex As Exception
            'Do Nothing
        End Try

        If connection Is Nothing Then
            bNeedAdd = True
        End If

        If connection Is Nothing OrElse connection.State = ConnectionState.Broken OrElse connection.State = ConnectionState.Closed Then
            Try
                connection.Dispose()
                connection = Nothing
            Catch ex As Exception
                'Do Nothing
            End Try

            connection = New OleDb.OleDbConnection
        End If

        'Always return an open connection
        If connection.State = ConnectionState.Closed Then
            DataSourceExists(connectionString)
            connection.ConnectionString = connectionString
            connection.Open()
        End If

        If bNeedAdd Then
            _Connections.Add(connectionString, connection)
        End If

        Return connection
    End Function
    Private Sub DataSourceExists(ByVal ConnectionString As String)
        Dim Builder As New OleDb.OleDbConnectionStringBuilder With {.ConnectionString = ConnectionString}
        If Not IO.File.Exists(Builder.DataSource) Then
            Throw New Exception(
                "Failed to locate '" & Builder.DataSource & "'." & Environment.NewLine &
                "Please check your configuration file connection string.")
        End If
    End Sub
    'Singleton Instance Provider
    Public Shared Function GetInstance() As MS_AccessConnection

        If _Instance Is Nothing Then
            _Instance = New MS_AccessConnection
        End If

        Return _Instance

    End Function
    'Protected means you can only call from inside this class
    'Protecting the constructor Force Singleton construction via GetInstance()
    Protected Sub New()
    End Sub
End Class
