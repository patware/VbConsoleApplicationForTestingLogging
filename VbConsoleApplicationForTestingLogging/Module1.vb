Module Module1

    Public Enum BarEventIds
        Starting = 12
        MessageCritical
        MessageError
        MessageInformation
        MessageResume
        MessageStart
        MessageStop
        MessageSuspend
        MessageTransfer
        MessageVerbose
        MessageWarning
    End Enum

    Sub Main()

        'This needs to be executed as an Admin
        If Not System.Diagnostics.EventLog.SourceExists("VbConsoleApplicationForTestingLogging") Then
            System.Diagnostics.EventLog.CreateEventSource(source:="VbConsoleApplicationForTestingLogging", logName:="MyOwnGroup")
        End If

        'System.Diagnostics.ConsoleTraceListener
        'System.Diagnostics.DefaultTraceListener
        'System.Diagnostics.DelimitedListTraceListener
        'System.Diagnostics.EventLogTraceListener
        'System.Diagnostics.EventSchemaTraceListener
        'System.Diagnostics.TextWriterTraceListener
        'System.Diagnostics.XmlWriterTraceListener

        System.Diagnostics.Trace.TraceError("TraceError message")
        System.Diagnostics.Trace.TraceError("TraceError format {0},{1},{2}", 1, 2, 3)

        System.Diagnostics.Trace.TraceInformation("TraceInformation message")
        System.Diagnostics.Trace.TraceInformation("TraceInformation format {0},{1},{2}", 1, 2, 3)

        System.Diagnostics.Trace.TraceWarning("TraceWarning message")
        System.Diagnostics.Trace.TraceWarning("TraceWarning format {0},{1},{2}", 1, 2, 3)

        System.Diagnostics.Trace.WriteLine("WriteLine", "Category")

        Dim barTs As New System.Diagnostics.TraceSource("Bar")
        barTs.TraceEvent(TraceEventType.Information, BarEventIds.Starting)
        barTs.TraceEvent(TraceEventType.Information, BarEventIds.Starting, "message")
        barTs.TraceEvent(TraceEventType.Information, BarEventIds.Starting, "Bibi {0}ms", DateTime.Now.Millisecond)
        barTs.TraceEvent(TraceEventType.Critical, BarEventIds.MessageCritical, "Critical {0}ms", DateTime.Now.Millisecond)
        barTs.TraceEvent(TraceEventType.Error, BarEventIds.MessageError, "Error {0}ms", DateTime.Now.Millisecond)
        barTs.TraceEvent(TraceEventType.Information, BarEventIds.MessageInformation, "Information {0}ms", DateTime.Now.Millisecond)
        barTs.TraceEvent(TraceEventType.Resume, BarEventIds.MessageResume, "Resume {0}ms", DateTime.Now.Millisecond)
        barTs.TraceEvent(TraceEventType.Start, BarEventIds.MessageStart, "Start {0}ms", DateTime.Now.Millisecond)
        barTs.TraceEvent(TraceEventType.Stop, BarEventIds.MessageStop, "Stop {0}ms", DateTime.Now.Millisecond)
        barTs.TraceEvent(TraceEventType.Suspend, BarEventIds.MessageSuspend, "Suspend {0}ms", DateTime.Now.Millisecond)
        barTs.TraceEvent(TraceEventType.Transfer, BarEventIds.MessageTransfer, "Transfer {0}ms", DateTime.Now.Millisecond)
        barTs.TraceEvent(TraceEventType.Verbose, BarEventIds.MessageVerbose, "Verbose {0}ms", DateTime.Now.Millisecond)
        barTs.TraceEvent(TraceEventType.Warning, BarEventIds.MessageWarning, "Warning {0}ms", DateTime.Now.Millisecond)

        '"Default" Trace Source doesn't exist, only "Default" Trace Listener
        Dim defaultTs As New System.Diagnostics.TraceSource("Default")
        defaultTs.TraceEvent(TraceEventType.Information, 1234, "It's not there...")

    End Sub

End Module
