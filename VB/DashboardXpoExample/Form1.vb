Imports DevExpress.DashboardCommon
Imports DevExpress.Xpo
Imports DevExpress.XtraEditors
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace DashboardXpoExample
	Partial Public Class Form1
		Inherits XtraForm

		Public Sub New()
			InitializeComponent()
			dashboardDesigner1.CreateRibbon()
			InitializeDashboard()
			dashboardDesigner1.ReloadData()
		End Sub

		Public Sub InitializeDashboard()
			Dim dashboard As New Dashboard()
			Dim xpoDataSource As DashboardXpoDataSource = CreateXpoDataSource()

			dashboard.DataSources.Add(xpoDataSource)

			Dim pivot As New PivotDashboardItem()
			pivot.DataSource = xpoDataSource
			pivot.Rows.Add(New Dimension("ContactTitle"))
			pivot.Columns.Add(New Dimension("Country"))
			pivot.Values.Add(New Measure("CustomerID", SummaryType.Count))

			Dim chart As New ChartDashboardItem()
			chart.DataSource = xpoDataSource
			chart.Arguments.Add(New Dimension("Country"))
			chart.Panes.Add(New ChartPane())
			Dim theSeries As New SimpleSeries(SimpleSeriesType.Bar)
			theSeries.Value = New Measure("CustomerID", SummaryType.Count)
			chart.Panes(0).Series.Add(theSeries)

			dashboard.Items.AddRange(pivot, chart)
			dashboard.RebuildLayout()
			dashboard.LayoutRoot.Orientation = DashboardLayoutGroupOrientation.Vertical
			dashboardDesigner1.Dashboard = dashboard
		End Sub

		Public Shared Function CreateXpoDataSource() As DashboardXpoDataSource
			Dim dataSource As New DashboardXpoDataSource() With {.ConnectionStringName = "northwind"}
			dataSource.SetEntityType(GetType(nwind.Customers))
			Return dataSource
		End Function
	End Class
End Namespace
