# DoubleVision
For now, the project contains a dynamic label (DynamicLabel) which ends a label with dots and assigns a ToolTip if there is not enough space to render the content.

#### Dynamic Label

![grafik](https://user-images.githubusercontent.com/26251441/222701679-38ea4786-3d3b-4d8f-aaea-49076faaa545.png)

```C#
<Window x:Class="WindowedPlayGround.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d"
        xmlns:doubleVision="clr-namespace:DoubleVision;assembly=DoubleVision"
        Title="MainWindow" Height="450" Width="800">
	<Grid>
		<StackPanel VerticalAlignment="Center" HorizontalAlignment="Center">
			<doubleVision:DynamicLabel 
				Text="Fooooooo Bar Baz" 
				FontFamily="Calibri" 
				FontSize="12" Width="90" 
				Height="25" 
				ToolTip="Persisting tooltip..."/>
			<doubleVision:DynamicLabel 
				Text="Foo Bar Baz" 
				FontFamily="Calibri" 
				FontSize="12" 
				Width="90" 
				Height="25"/>
			<doubleVision:DynamicLabel 
				Text="{Binding Path=PassedText}" 
				FontFamily="Calibri" 
				FontSize="12" 
				Width="90" 
				Height="25" />
			<doubleVision:DynamicLabel 
				Text="Foo Baaaaaaar Baz" 
				FontFamily="Calibri" 
				FontSize="12" 
				Width="90" 
				Height="25" />
		</StackPanel>
	</Grid>
</Window>

```
