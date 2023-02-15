using System.Windows;

namespace WindowedPlayGround
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = this;
		}

		public string PassedText { get; set; } = "Foo Bar Baaaaaaaaaaz";
	}
}
