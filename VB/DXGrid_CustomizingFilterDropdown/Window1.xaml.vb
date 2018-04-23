Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports DevExpress.Data.Filtering
Imports DevExpress.Wpf.Grid


Namespace DXGrid_CustomizingFilterDropdown

    Partial Public Class Window1
        Inherits Window
        Public Sub New()
            InitializeComponent()
            grid.DataSource = New AccountList().GetData()
        End Sub

        Private Sub TableView_ShowFilterPopup(ByVal sender As Object, _
        ByVal e As FilterPopupEventArgs)
            If e.Column.FieldName <> "RegistrationDate" Then
                Return
            End If
            Dim filterItems As New List(Of Object)()
            filterItems.Add(New CustomComboBoxItem() With {.DisplayValue = "(All)", _
                .EditValue = String.Empty})

            filterItems.Add(New CustomComboBoxItem() With {.DisplayValue = "Registered in 2008", _
                .EditValue = CriteriaOperator.Parse(String.Format( _
                    "[RegistrationDate] >= #{0}# AND [RegistrationDate] < #{1}#", _
                    New DateTime(2008, 1, 1), New DateTime(2009, 1, 1)))})

            filterItems.Add(New CustomComboBoxItem() With {.DisplayValue = "Registered in 2009", _
                 .EditValue = CriteriaOperator.Parse(String.Format( _
                    "[RegistrationDate] >= #{0}# AND [RegistrationDate] < #{1}#", _
                     New DateTime(2009, 1, 1), New DateTime(2010, 1, 1)))})

            e.ComboBoxEdit.ItemsSource = filterItems
        End Sub
    End Class

    Public Class AccountList
        Public Function GetData() As List(Of Account)
            Return CreateAccounts()
        End Function
        Private Function CreateAccounts() As List(Of Account)
            Dim list As New List(Of Account)()
            list.Add(New Account() With {.UserName = "Nick White", _
                                         .RegistrationDate = DateTime.Today})
            list.Add(New Account() With {.UserName = "Jack Rodman", _
                                         .RegistrationDate = New DateTime(2009, 5, 10)})
            list.Add(New Account() With {.UserName = "Sandra Sherry", _
                                         .RegistrationDate = New DateTime(2008, 12, 22)})
            list.Add(New Account() With {.UserName = "Sabrina Vilk", _
                                         .RegistrationDate = DateTime.Today})
            list.Add(New Account() With {.UserName = "Mike Pearson", _
                                         .RegistrationDate = New DateTime(2008, 10, 18)})
            Return list
        End Function
    End Class

    Public Class Account
        Private privateUserName As String
        Public Property UserName() As String
            Get
                Return privateUserName
            End Get
            Set(ByVal value As String)
                privateUserName = value
            End Set
        End Property
        Private privateRegistrationDate As DateTime
        Public Property RegistrationDate() As DateTime
            Get
                Return privateRegistrationDate
            End Get
            Set(ByVal value As DateTime)
                privateRegistrationDate = value
            End Set
        End Property
    End Class

End Namespace
