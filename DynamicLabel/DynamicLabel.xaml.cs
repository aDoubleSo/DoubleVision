using System;
using System.IO;
using System.Reflection;
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

			var appDomain = AppDomain.CurrentDomain;
			appDomain.AssemblyResolve += AppDomain_AssemblyResolve;
		}

		private static Assembly AppDomain_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			var folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			var assemblyPath = Path.Combine(folderPath, new AssemblyName(args.Name).Name + ".dll");
			if (!File.Exists(assemblyPath)) return null;
			var assembly = Assembly.LoadFrom(assemblyPath);
			return assembly;
		}

		/// <summary>
		/// Enter text to be displayed.
		/// </summary>
		public string Text
		{
			get => (string)GetValue(TextProperty);
			set => SetValue(TextProperty, value);
		}

		private void TextBlock_OnSizeChanged(object sender, SizeChangedEventArgs e)
		{
			if(string.IsNullOrEmpty(this.ToolTip?.ToString()))
				this.TextBlock.ToolTip = IsTextBlockTrimmed() ? this.TextBlock.Text : null;
		}

		private bool IsTextBlockTrimmed()
		{
			if (this.TextBlock.TextTrimming == TextTrimming.None) return false;
			if (this.TextBlock.TextWrapping != TextWrapping.NoWrap) return false;
			this.TextBlock.Measure(new Size(double.MaxValue, double.MaxValue));
			var totalWidth = this.TextBlock.DesiredSize.Width;
			return this.TextBlock.ActualWidth < totalWidth;
		}
	}
}
