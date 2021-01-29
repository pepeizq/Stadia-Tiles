﻿Public Class Tile

    Public Titulo As String
    Public IDStadia As String
    Public IDSteam As String
    Public Enlace As String

    Public ImagenPequeña As String
    Public ImagenMediana As String
    Public ImagenAncha As String
    Public ImagenGrande As String

    Public Sub New(titulo As String, idStadia As String, idSteam As String, enlace As String,
                   imagenPequeña As String, imagenMediana As String, imagenAncha As String, imagenGrande As String)
        Me.Titulo = titulo
        Me.IDStadia = idStadia
        Me.IDSteam = idSteam
        Me.Enlace = enlace

        Me.ImagenPequeña = imagenPequeña
        Me.ImagenMediana = imagenMediana
        Me.ImagenAncha = imagenAncha
        Me.ImagenGrande = imagenGrande
    End Sub
End Class