using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace app1;

public class Transation {
	public string Description {get; set;}
	public double Amount {get; set;}

	public Transation(string desc, double amount) {
		this.Description = desc;
		this.Amount = amount;
	}
};


public class MainPageVM : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;
	public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

		private List<Transation> allTransations = new List<Transation>();
		
		private List<Transation> transations = new List<Transation>();
		public List<Transation> Transations { 
			get { return this.transations; }
			set { this.transations = value;  OnPropertyChanged(); }
		}

		public MainPageVM() {
			Transation t1 = new("Monthly paid",2000);
			Transation t2 = new("WIFI bill",-100);
			Transation t3 = new("WIFI bill",-100);
			this.allTransations.Add(t1);
			this.allTransations.Add(t2);
			this.allTransations.Add(t3);

			this.Transations = this.allTransations;
		}

		public void Search(string keyterm) {
			this.Transations = this.allTransations.Where(x => x.Description.ToLower().StartsWith(keyterm.ToLower())).ToList();
		}
}

public partial class MainPage : ContentPage
{

	private readonly MainPageVM vm;
	public MainPage()
	{
		InitializeComponent();
			this.vm = new MainPageVM();
			this.BindingContext = vm;
	}

	private void OnEntryTextChanged(object sender, TextChangedEventArgs e) {
		this.vm.Search(e.NewTextValue);
	}
}

