Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Documents
Imports DevExpress.Data.Filtering
Imports DevExpress.Xpf.Grid

Namespace DXGrid_CustomizingFilterDropdown

    Public Partial Class Window1
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            Me.grid.ItemsSource = New AccountList().GetData()
        End Sub

        Private Sub TableView_ShowFilterPopup(ByVal sender As Object, ByVal e As FilterPopupEventArgs)
            If Not Equals(e.Column.FieldName, "RegistrationDate") Then Return
            Dim filterItems As List(Of Object) = New List(Of Object)()
            filterItems.Add(New CustomComboBoxItem() With {.DisplayValue = "(All)", .EditValue = New CustomComboBoxItem()})
            filterItems.Add(New CustomComboBoxItem() With {.DisplayValue = "Registered in 2008", .EditValue = CriteriaOperator.Parse(String.Format("[RegistrationDate] >= #{0}# AND [RegistrationDate] < #{1}#", New DateTime(2008, 1, 1), New DateTime(2009, 1, 1)))})
            filterItems.Add(New CustomComboBoxItem() With {.DisplayValue = "Registered in 2009", .EditValue = CriteriaOperator.Parse(String.Format("[RegistrationDate] >= #{0}# AND [RegistrationDate] < #{1}#", New DateTime(2009, 1, 1), New DateTime(2010, 1, 1)))})
            e.ComboBoxEdit.ItemsSource = filterItems
        End Sub
    End Class

    Public Class AccountList

        Public Function GetData() As List(Of Account)
            Return CreateAccounts()
        End Function

        Private Function CreateAccounts() As List(Of Account)
            Dim list As List(Of Account) = New List(Of Account)()
            list.Add(New Account() With {.UserName = "Nick White", .RegistrationDate = Date.Today})
            list.Add(New Account() With {.UserName = "Jack Rodman", .RegistrationDate = New DateTime(2009, 5, 10)})
            list.Add(New Account() With {.UserName = "Sandra Sherry", .RegistrationDate = New DateTime(2008, 12, 22)})
            list.Add(New Account() With {.UserName = "Sabrina Vilk", .RegistrationDate = Date.Today})
            list.Add(New Account() With {.UserName = "Mike Pearson", .RegistrationDate = New DateTime(2008, 10, 18)})
            Return list
        End Function
    End Class

    Public Class Account

        Public Property UserName As String

        Public Property RegistrationDate As Date
    End Class
End Namespace
