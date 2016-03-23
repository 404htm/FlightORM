//------------------------------------------------------------------------------
// <copyright file="ContextWindowControl.xaml.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace FlightORM.VS
{
	using System.Diagnostics.CodeAnalysis;
	using System.Windows;
	using System.Windows.Controls;
	using FlightORM.UI;

	/// <summary>
	/// Interaction logic for ContextWindowControl.
	/// </summary>
	public partial class ContextWindowControl : UserControl
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ContextWindowControl"/> class.
		/// </summary>
		public ContextWindowControl()
		{
			this.InitializeComponent();
			var tmp = new FlightORM.UI.MainWindow(); //Fix Vs reference stupidity, FML
		}

		/// <summary>
		/// Handles click on the button by displaying a message box.
		/// </summary>
		/// <param name="sender">The event sender.</param>
		/// <param name="e">The event args.</param>
		[SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
		[SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
		private void button1_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show(
				string.Format(System.Globalization.CultureInfo.CurrentUICulture, "Invoked '{0}'", this.ToString()),
				"ContextWindow");
		}
	}
}