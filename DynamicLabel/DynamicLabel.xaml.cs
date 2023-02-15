using System.Windows;
using System.Windows.Controls;

namespace DoubleVision
{
	public partial class DynamicLabel : UserControl
	{
		public static readonly DependencyProperty TextProperty =
			DependencyProperty.Register("Text", typeof(string), typeof(DynamicLabel), new PropertyMetadata(string.Empty));

		public DynamicLabel()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Enter text to be displayed.
		/// </summary>
		public object Text
		{
			get => (string)GetValue(TextProperty);
			set => SetValue(TextProperty, value);
		}

		private void TextBlock_OnSizeChanged(object sender, SizeChangedEventArgs e)
		{
			if (IsTextBlockTrimmed())
				this.TextBlock.ToolTip = this.TextBlock.Text;
		}

		private bool IsTextBlockTrimmed()
		{
			var width = this.TextBlock.ActualWidth;
			if (this.TextBlock.TextTrimming == TextTrimming.None) return false;
			if (this.TextBlock.TextWrapping != TextWrapping.NoWrap) return false;
			this.TextBlock.Measure(new Size(double.MaxValue, double.MaxValue));
			var totalWidth = this.TextBlock.DesiredSize.Width;
			return width < totalWidth;
		}
	}
}
