Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Documents
Imports DevExpress.Data.Filtering
Imports DevExpress.Xpf.Grid

Namespace DXGrid_CustomizingFilterDropdown

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
			Me.DataContext = New MyViewModel()

		End Sub

		Private Sub TableView_ShowFilterPopup(ByVal sender As Object, ByVal e As FilterPopupEventArgs)
			If e.Column.FieldName <> "RegistrationDate" Then
				Return
			End If
			Dim filterItems As New List(Of Object)()
			filterItems.Add(New CustomComboBoxItem() With {
				.DisplayValue = "(All)",
				.EditValue = New CustomComboBoxItem()
			})
			filterItems.Add(New CustomComboBoxItem() With {
				.DisplayValue = "Registered in 2008",
				.EditValue = CriteriaOperator.Parse(String.Format("[RegistrationDate] >= #{0}# AND [RegistrationDate] < #{1}#", New DateTime(2008, 1, 1), New DateTime(2009, 1, 1)))
			})
			filterItems.Add(New CustomComboBoxItem() With {
				.DisplayValue = "Registered in 2009",
				.EditValue = CriteriaOperator.Parse(String.Format("[RegistrationDate] >= #{0}# AND [RegistrationDate] < #{1}#", New DateTime(2009, 1, 1), New DateTime(2010, 1, 1)))
			})
			e.ComboBoxEdit.ItemsSource = filterItems
		End Sub
	End Class

	Public Class MyViewModel
		Public Sub New()
			AccountList = CreateAccounts()
		End Sub

		Public Property AccountList() As List(Of Account)


		Private Function CreateAccounts() As List(Of Account)
			Dim list As New List(Of Account)()
			list.Add(New Account() With {
				.UserName = "Nick White",
				.RegistrationDate = DateTime.Today
			})
			list.Add(New Account() With {
				.UserName = "Jack Rodman",
				.RegistrationDate = New DateTime(2009, 5, 10)
			})
			list.Add(New Account() With {
				.UserName = "Sandra Sherry",
				.RegistrationDate = New DateTime(2008, 12, 22)
			})
			list.Add(New Account() With {
				.UserName = "Sabrina Vilk",
				.RegistrationDate = DateTime.Today
			})
			list.Add(New Account() With {
				.UserName = "Mike Pearson",
				.RegistrationDate = New DateTime(2008, 10, 18)
			})
			Return list
		End Function
	End Class
	Public Class Account
		Public Property UserName() As String
		Public Property RegistrationDate() As DateTime
	End Class
End Namespace
