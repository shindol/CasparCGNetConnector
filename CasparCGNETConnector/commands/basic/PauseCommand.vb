﻿Public Class PauseCommand
    Inherits AbstractCommand

    Public Sub New()
        MyBase.New("PAUSE", "Pauses the given channel or layer")
        InitParameter()
    End Sub

    Public Sub New(ByVal channel As Integer, Optional ByVal layer As Integer = -1)
        MyBase.New("PAUSE", "Pauses the given channel or layer")
        InitParameter()
        Init(channel, layer)
    End Sub


    Private Sub Init(ByVal channel As Integer, ByVal layer As Integer)
        If channel > 0 Then DirectCast(getParameter("channel"), CommandParameter(Of Integer)).setValue(channel)
        If layer > -1 Then DirectCast(getParameter("layer"), CommandParameter(Of Integer)).setValue(layer)
    End Sub

    Private Sub InitParameter()
        '' Add all paramters here:
        addParameter(New CommandParameter(Of Integer)("channel", "The channel", 1, False))
        addParameter(New CommandParameter(Of Integer)("layer", "The layer", 0, True))
    End Sub

    Public Overrides Function getCommandString() As String
        Dim cmd As String = "PAUSE " & getDestination(getParameter("channel"), getParameter("layer"))

        Return escape(cmd)
    End Function

    Public Overrides Function getRequiredVersion() As Integer()
        Return {1}
    End Function

    Public Overrides Function getMaxAllowedVersion() As Integer()
        Return {Integer.MaxValue}
    End Function
End Class