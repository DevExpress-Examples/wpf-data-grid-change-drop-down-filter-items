using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using DevExpress.Data.Filtering;
using DevExpress.Xpf.Grid;

namespace DXGrid_CustomizingFilterDropdown {

    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
            this.DataContext = new MyViewModel();

        }

        private void TableView_ShowFilterPopup(object sender, FilterPopupEventArgs e) {
            if (e.Column.FieldName != "RegistrationDate") return;
            List<object> filterItems = new List<object>();
            filterItems.Add(new CustomComboBoxItem()
            {
                DisplayValue = "(All)",
                EditValue = new CustomComboBoxItem()
            });
            filterItems.Add(new CustomComboBoxItem()
            {
                DisplayValue = "Registered in 2008",
                EditValue = CriteriaOperator.Parse(string.Format(
                "[RegistrationDate] >= #{0}# AND [RegistrationDate] < #{1}#",
                new DateTime(2008, 1, 1), new DateTime(2009, 1, 1)))
            });
            filterItems.Add(new CustomComboBoxItem()
            {
                DisplayValue = "Registered in 2009",
                EditValue = CriteriaOperator.Parse(string.Format(
                "[RegistrationDate] >= #{0}# AND [RegistrationDate] < #{1}#",
                new DateTime(2009, 1, 1), new DateTime(2010, 1, 1)))
            });
            e.ComboBoxEdit.ItemsSource = filterItems;            
        }
    }

    public class MyViewModel {
        public MyViewModel() {
            AccountList = CreateAccounts();
        }

        public List<Account> AccountList { get; set; }

    
        private List<Account> CreateAccounts() {
            List<Account> list = new List<Account>();
            list.Add(new Account() {
                UserName = "Nick White",
                RegistrationDate = DateTime.Today
            });
            list.Add(new Account() {
                UserName = "Jack Rodman",
                RegistrationDate = new DateTime(2009, 5, 10)
            });
            list.Add(new Account() {
                UserName = "Sandra Sherry",
                RegistrationDate = new DateTime(2008, 12, 22)
            });
            list.Add(new Account() {
                UserName = "Sabrina Vilk",
                RegistrationDate = DateTime.Today
            });
            list.Add(new Account() {
                UserName = "Mike Pearson",
                RegistrationDate = new DateTime(2008, 10, 18)
            });
            return list;
        }
    }
    public class Account {
        public string UserName { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
