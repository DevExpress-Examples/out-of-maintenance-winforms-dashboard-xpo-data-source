Imports System
Imports DevExpress.Xpo
Imports DevExpress.Xpo.Metadata
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Reflection
Namespace DashboardXpoExample.nwind

	Partial Public Class Customers
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Public Overrides Sub AfterConstruction()
			MyBase.AfterConstruction()
		End Sub
	End Class

End Namespace
