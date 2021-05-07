Imports Microsoft.Toolkit.Uwp.Helpers
Imports Microsoft.Toolkit.Uwp.UI.Controls
Imports Stadia_Tiles.Configuracion
Imports Windows.ApplicationModel.Core
Imports Windows.UI
Imports Windows.UI.Core
Imports Windows.UI.Xaml.Media.Animation

Module Stadia

    Public anchoColumna As Integer = 180
    Dim dominioImagenes As String = "https://cdn.cloudflare.steamstatic.com"

    Public Async Sub Generar()

        Dim helper As New LocalObjectStorageHelper

        Dim recursos As New Resources.ResourceLoader()

        Dim frame As Frame = Window.Current.Content
        Dim pagina As Page = frame.Content

        Dim gridProgreso As Grid = pagina.FindName("gridProgreso")
        Interfaz.Pestañas.Visibilidad(gridProgreso, Nothing, Nothing)

        Dim pbProgreso As ProgressBar = pagina.FindName("pbProgreso")
        pbProgreso.Value = 0

        Dim tbProgreso As TextBlock = pagina.FindName("tbProgreso")
        tbProgreso.Text = String.Empty

        Cache.Estado(False)
        LimpiezaArchivos.Estado(False)

        Dim gv As AdaptiveGridView = pagina.FindName("gvTiles")
        gv.DesiredWidth = anchoColumna
        gv.Items.Clear()

        Dim listaJuegos As New List(Of Tile)

        If Await helper.FileExistsAsync("juegos") = True Then
            listaJuegos = Await helper.ReadFileAsync(Of List(Of Tile))("juegos")
        End If

        If listaJuegos Is Nothing Then
            listaJuegos = New List(Of Tile)
        End If

        Dim listaBBDD As List(Of StadiaBBDDEntrada) = StadiaBBDD.Listado

        Dim i As Integer = 0
        For Each juegoBBDD In listaBBDD
            Dim añadir As Boolean = True

            For Each juegoGuardado In listaJuegos
                If juegoGuardado.IDStadia = juegoBBDD.IDStadia Then
                    añadir = False
                End If
            Next

            If añadir = True Then
                If Not juegoBBDD.IDSteam = Nothing Then
                    Dim imagenPequeña As String = Await Cache.DescargarImagen(Nothing, juegoBBDD.IDStadia, "pequeña")

                    Dim imagenMediana As String = Await Cache.DescargarImagen(Nothing, juegoBBDD.IDStadia, "mediana")

                    If imagenMediana = String.Empty Then
                        Try
                            imagenMediana = Await Cache.DescargarImagen(dominioImagenes + "/steam/apps/" + juegoBBDD.IDSteam + "/logo.png", juegoBBDD.IDSteam, "mediana")
                        Catch ex As Exception

                        End Try
                    End If

                    Dim imagenAncha As String = String.Empty

                    Try
                        imagenAncha = Await Cache.DescargarImagen(dominioImagenes + "/steam/apps/" + juegoBBDD.IDSteam + "/header.jpg", juegoBBDD.IDSteam, "ancha")
                    Catch ex As Exception

                    End Try

                    Dim imagenGrande As String = Await Cache.DescargarImagen(Nothing, juegoBBDD.IDStadia, "grande")

                    If imagenGrande = Nothing Then
                        Try
                            imagenGrande = Await Cache.DescargarImagen(dominioImagenes + "/steam/apps/" + juegoBBDD.IDSteam + "/library_600x900.jpg", juegoBBDD.IDSteam, "grande")
                        Catch ex As Exception

                        End Try

                        If imagenGrande = String.Empty Then
                            Try
                                imagenGrande = Await Cache.DescargarImagen(dominioImagenes + "/steam/apps/" + juegoBBDD.IDSteam + "/capsule_616x353.jpg", juegoBBDD.IDSteam, "grande")
                            Catch ex As Exception

                            End Try
                        End If
                    End If

                    Dim enlace As String = "https://stadia.google.com/player/" + juegoBBDD.IDStadia

                    Dim juego As New Tile(juegoBBDD.Titulo, juegoBBDD.IDStadia, juegoBBDD.IDSteam, enlace, imagenPequeña, imagenMediana, imagenAncha, imagenGrande)
                    listaJuegos.Add(juego)
                Else
                    Dim imagenPequeña As String = Await Cache.DescargarImagen(Nothing, juegoBBDD.IDStadia, "pequeña")
                    Dim imagenMediana As String = Await Cache.DescargarImagen(Nothing, juegoBBDD.IDStadia, "mediana")
                    Dim imagenAncha As String = Await Cache.DescargarImagen(Nothing, juegoBBDD.IDStadia, "ancha")
                    Dim imagenGrande As String = Await Cache.DescargarImagen(Nothing, juegoBBDD.IDStadia, "grande")

                    Dim enlace As String = "https://stadia.google.com/player/" + juegoBBDD.IDStadia

                    Dim juego As New Tile(juegoBBDD.Titulo, juegoBBDD.IDStadia, juegoBBDD.IDSteam, enlace, imagenPequeña, imagenMediana, imagenAncha, imagenGrande)
                    listaJuegos.Add(juego)
                End If
            End If

            pbProgreso.Value = CInt((100 / listaBBDD.Count) * i)
            tbProgreso.Text = i.ToString + "/" + listaBBDD.Count.ToString
            i += 1
        Next

        Await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.High,
                                                                      Async Sub()
                                                                          Try
                                                                              Await helper.SaveFileAsync(Of List(Of Tile))("juegos", listaJuegos)
                                                                          Catch ex As Exception

                                                                          End Try
                                                                      End Sub)

        Dim gridJuegos As Grid = pagina.FindName("gridJuegos")
        Interfaz.Pestañas.Visibilidad(gridJuegos, recursos.GetString("Games"), Nothing)

        If Not listaJuegos Is Nothing Then
            If listaJuegos.Count > 0 Then
                listaJuegos.Sort(Function(x, y) x.Titulo.CompareTo(y.Titulo))

                gv.Items.Clear()

                For Each juego In listaJuegos
                    BotonEstilo(juego, gv)
                Next
            End If
        End If

        Cache.Estado(True)
        LimpiezaArchivos.Estado(True)

    End Sub

    Public Sub BotonEstilo(juego As Tile, gv As GridView)

        Dim panel As New DropShadowPanel With {
            .Margin = New Thickness(10, 10, 10, 10),
            .ShadowOpacity = 0.9,
            .BlurRadius = 10,
            .MaxWidth = anchoColumna + 20,
            .HorizontalAlignment = HorizontalAlignment.Center,
            .VerticalAlignment = VerticalAlignment.Center
        }

        Dim boton As New Button

        Dim imagen As New ImageEx With {
            .Source = juego.ImagenGrande,
            .IsCacheEnabled = True,
            .Stretch = Stretch.UniformToFill,
            .Padding = New Thickness(0, 0, 0, 0),
            .HorizontalAlignment = HorizontalAlignment.Center,
            .VerticalAlignment = VerticalAlignment.Center,
            .EnableLazyLoading = True
        }

        If imagen.Source = Nothing Then
            imagen.Source = juego.ImagenAncha
        End If

        boton.Tag = juego
        boton.Content = imagen
        boton.Padding = New Thickness(0, 0, 0, 0)
        boton.Background = New SolidColorBrush(Colors.Transparent)

        panel.Content = boton

        Dim tbToolTip As TextBlock = New TextBlock With {
            .Text = juego.Titulo,
            .FontSize = 16,
            .TextWrapping = TextWrapping.Wrap
        }

        ToolTipService.SetToolTip(boton, tbToolTip)
        ToolTipService.SetPlacement(boton, PlacementMode.Mouse)

        AddHandler boton.Click, AddressOf BotonTile_Click
        AddHandler boton.PointerEntered, AddressOf Interfaz.Entra_Boton_Imagen
        AddHandler boton.PointerExited, AddressOf Interfaz.Sale_Boton_Imagen

        gv.Items.Add(panel)

    End Sub

    Private Sub BotonTile_Click(sender As Object, e As RoutedEventArgs)

        Trial.Detectar()
        Interfaz.AñadirTile.ResetearValores()

        Dim frame As Frame = Window.Current.Content
        Dim pagina As Page = frame.Content

        Dim botonJuego As Button = e.OriginalSource
        Dim juego As Tile = botonJuego.Tag

        Dim botonAñadirTile As Button = pagina.FindName("botonAñadirTile")
        botonAñadirTile.Tag = juego

        Dim imagenJuegoSeleccionado As ImageEx = pagina.FindName("imagenJuegoSeleccionado")
        imagenJuegoSeleccionado.Source = juego.ImagenAncha

        Dim tbJuegoSeleccionado As TextBlock = pagina.FindName("tbJuegoSeleccionado")
        tbJuegoSeleccionado.Text = juego.Titulo

        Dim gridAñadirTile As Grid = pagina.FindName("gridAñadirTile")
        Interfaz.Pestañas.Visibilidad(gridAñadirTile, juego.Titulo, Nothing)

        '---------------------------------------------

        ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("animacionJuego", botonJuego)
        Dim animacion As ConnectedAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("animacionJuego")

        If Not animacion Is Nothing Then
            animacion.Configuration = New BasicConnectedAnimationConfiguration
            animacion.TryStart(gridAñadirTile)
        End If

        '---------------------------------------------

        Dim tbImagenTituloTextoTileAncha As TextBox = pagina.FindName("tbImagenTituloTextoTileAncha")
        tbImagenTituloTextoTileAncha.Text = juego.Titulo
        tbImagenTituloTextoTileAncha.Tag = juego.Titulo

        Dim tbImagenTituloTextoTileGrande As TextBox = pagina.FindName("tbImagenTituloTextoTileGrande")
        tbImagenTituloTextoTileGrande.Text = juego.Titulo
        tbImagenTituloTextoTileGrande.Tag = juego.Titulo

        '---------------------------------------------

        Dim imagenPequeña As ImageEx = pagina.FindName("imagenTilePequeña")
        imagenPequeña.Source = Nothing

        Dim imagenMediana As ImageEx = pagina.FindName("imagenTileMediana")
        imagenMediana.Source = Nothing

        Dim imagenAncha As ImageEx = pagina.FindName("imagenTileAncha")
        imagenAncha.Source = Nothing

        Dim imagenGrande As ImageEx = pagina.FindName("imagenTileGrande")
        imagenGrande.Source = Nothing

        If Not juego.ImagenPequeña = Nothing Then
            imagenPequeña.Source = juego.ImagenPequeña
            imagenPequeña.Tag = juego.ImagenPequeña
        End If

        If Not juego.ImagenAncha = Nothing Then
            If Not juego.ImagenMediana = Nothing Then
                imagenMediana.Source = juego.ImagenMediana
                imagenMediana.Tag = juego.ImagenMediana
            Else
                imagenMediana.Source = juego.ImagenAncha
                imagenMediana.Tag = juego.ImagenAncha
            End If

            imagenAncha.Source = juego.ImagenAncha
            imagenAncha.Tag = juego.ImagenAncha
        End If

        If Not juego.ImagenGrande = Nothing Then
            imagenGrande.Source = juego.ImagenGrande
            imagenGrande.Tag = juego.ImagenGrande
        End If

    End Sub

End Module
