Module Module1

    Sub Main()
        Dim oCat As Array = PerformanceCounterCategory.GetCategories(".")
        Dim pcc As PerformanceCounterCategory
        Dim inst As Array, ctr As Array, pctr As PerformanceCounter
        Dim cCat As String, cInst As String, cCounter As String

        Try
            For Each pcc In oCat
                cCat = pcc.CategoryName
                Console.WriteLine(cCat)
                inst = (pcc.GetInstanceNames)
                If inst.Length = 0 Then
                    ctr = pcc.GetCounters()
                    For Each pctr In ctr
                        cCounter = pctr.CounterName
                        Console.WriteLine("    " + cCounter)
                    Next
                Else
                    For Each cInst In inst
                        Console.WriteLine("  " + cInst)
                        ctr = pcc.GetCounters(cInst)
                        For Each pctr In ctr
                            cCounter = pctr.CounterName
                            Console.WriteLine("    " + cCounter)
                        Next
                        If cCat = "Thread" Or cCat = "Processo" Or cCat = "Process" Then Exit For
                    Next
                End If
                Console.WriteLine()
            Next
            REM
        Catch e As Exception
            Console.WriteLine(e.Message)
            End
        End Try
    End Sub

End Module
