<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EstudianteIngreso.aspx.cs" Inherits="AsistenciaAdmin.Estudiante.EstudianteIngreso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Estudiante</title>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <link href="http://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/FaceDetector.js"></script>
    <script src="js/webcam.min.js"></script>
    <script src="js/WebcamManager.js"></script>

</head>
<body style="padding: 20px;">
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <div>
                <nav class="navbar navbar-expand-lg navbar-dark bg-dark" style="background-color: black">
                    <a class="navbar-brand" href="#"></a>
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>

                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul class="navbar-nav mr-auto">
                            <li class="nav-item active">
                                <a class="nav-link" href="EstudianteIngreso.aspx">Estudiantes <span class="sr-only">(current)</span></a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="../Catedratico/Catedratico.aspx">Catedratico</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="../Curso/CursoMostrar.aspx">Curso</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="../Evento/Evento.aspx">Evento</a>
                            </li>
                        </ul>

                        <input id="txtBuscar" class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search" onkeyup="Search_Gridview(this)" />
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <div class="input-group" style="text-align: right">
                                    <asp:LinkButton ID="EstudianteIngresar" runat="server" Text="Nuevo" CssClass="btn btn-success" Width="95px" OnClick="AbrirNuevo"></asp:LinkButton>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </nav>
            </div>

            <section class="content-header">
                <br />
                <br />
                <h3 align="center" style="margin-top: 5px">REGISTRO DE ESTUDIANTES</h3>
            </section>
            <br />
            <br />

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridEstudiante" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowDataBound="OnRowDataBound" AllowPaging="True" OnRowCommand="GridEstudiante_RowCommand" EmptyDataText="Datos no disponibles">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>

                            <asp:ButtonField ButtonType="Button" Text="Asignacion" ControlStyle-CssClass="btn btn-primary" CommandName="Asignacion" HeaderStyle-Width="2%" />
                            <asp:BoundField DataField="idEstudiante" HeaderText="idEstudiante" HeaderStyle-Width="2%" />
                            <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
                            <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />
                            <asp:TemplateField HeaderText="Fotografia">
                                <ItemTemplate>
                                    <asp:Image ID="Fotografia" runat="server" Height="110px" Width="150px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>

            <!-----------------------------------------MODAL ESTUDIANTE--------------------------------------->

            <div id="modal_Ingreso" class="modal fade" role="dialog" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog modal-lg " role="document">
                    <div class="modal-content">
                        <div class="modal-header" style="background-color: #5F96D5; text-align: center; color: white">
                            <h4 class="modal-title" id="exampleModalLabe">Ficha de Registro</h4>
                            <button class="close" type="button" data-dismiss="modal" aria-label="Close" style="margin-top: -25px">
                                <span aria-hidden="true" style="color: red">X</span>

                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="col-md-8">
                                <div class="box box-primary">
                                    <div class="box-body">

                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="form-label-group">

                                                            <!---------------------------------------------- NOMBRES ---------------------------------------------->
                                                            <label for="firstName">Nombres: </label>
                                                            <asp:TextBox ID="txtIdEstudiante" runat="server" Text="" class="form-control" Height="30px" required="required" Visible="False"></asp:TextBox>
                                                            <asp:TextBox ID="txtNombres" runat="server" Text="" class="form-control" Height="30px" required="required"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="form-label-group">
                                                            <!---------------------------------------------- APELLIDOS ---------------------------------------------->
                                                            <label for="lastName">Apellidos:</label>
                                                            <asp:TextBox ID="txtApellidos" runat="server" class="form-control" Height="30px"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>


                                    </div>
                                </div>
                            </div>

                            <!---------------------------------------------- FOTOGRAFIA ---------------------------------------------->
                            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                <ContentTemplate>
                                    <div class="row"></div>
                                    <br />
                                    <br />
                                    <div class="row">
                                        <div class="col-md-2">
                                            <div class="form-label-group">
                                                <label for="lastName">&nbsp;  &nbsp; Fotografía:</label>

                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="box box-primary">
                                                <div class="box-body" style="margin-left: 90px">
                                                    <asp:Image ID="img" runat="server" ImageUrl="~/Estudiante/js/Usuario-Vacio.png" Width="270px" Height="210px" />

                                                    <div id="oculto">
                                                        <video id="video" autoplay style="position: absolute; left: 105px; top: 0px; width: 270px; height: 210px; border: 1px solid white;">
                                                        </video>
                                                        <canvas id="canvas" style="position: absolute; left: 0px; top: 0px"></canvas>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-2" style="text-align: right">
                                            <input type="button" class="btn btn-primary btn-sm" value="Encender Cámara" onclick="take_camera()"><br />
                                            <br />
                                            <input type="button" class="btn btn-primary btn-sm" value="Tomar foto" onclick="take_snapshot()">
                                        </div>

                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-4">
                                            <asp:TextBox ID="TextBox1" runat="server" value=""></asp:TextBox>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>

                        <!---------------------------------------------- BOTONES ---------------------------------------------->
                        <div class="modal-footer">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <%--<asp:Button ID="btnCancelar" runat="server" class="btn btn-danger" Text="Cancelar" data-dismiss="modal"></asp:Button>--%>
                                    <asp:LinkButton ID="btnCancelar2" runat="server" class="btn btn-danger" Text="Cancelar" OnClick="btnCancelar_Click"></asp:LinkButton>
                                    <asp:LinkButton ID="btnAgregar1" runat="server" Text="Agregar" class="btn btn-success" OnClick="btnAgregar_Click"></asp:LinkButton>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                    </div>
                </div>
            </div>
            <!---------------------------------------TERMINA MODAL ------------------------------->

        </div>
    </form>

    <script type="text/javascript">

        function abrirModal() {
            $('#modal_Ingreso').modal('show');
        }
        function cerrarModal() {
            $('#modal_Ingreso').modal('hide');
        }

        function take_camera() {
            var timer = null;
            var camStreamWidth = 640;
            var camStreamHeight = 480;

            var VIEW_WIDTH = 320;
            var VIEW_HEIGHT = 240;

            var video = document.getElementById("video");
            var canvas = document.getElementById("canvas");

            canvas.width = VIEW_WIDTH;
            canvas.height = VIEW_HEIGHT;

            var webcamParams = {
                video: {
                    mandatory: {
                        maxWidth: camStreamWidth,
                        maxHeight: camStreamHeight,
                        minWidth: camStreamWidth,
                        minHeight: camStreamHeight
                    }
                }
            };

            var webcamMgr = new WebCamManager(
                {
                    webcamParams: webcamParams, //Set params for web camera
                    testVideoMode: false,//true:force use example video for test false:use web camera
                    videoTag: video
                }
            );
       
            webcamMgr.startCamera();

            Webcam.set({
                width: 320,
                height: 240,
                image_format: 'jpeg',
                jpeg_quality: 90
            });
            //Webcam.attach('#my_camera');
            Webcam.attach('#canvas');
        }

        //<!-- Code to handle taking the snapshot and displaying it locally -->
        function take_snapshot() {

            // take snapshot and get image data
            Webcam.snap(function (data_uri) {
                // display results in page
                document.getElementById('img').src = data_uri;
                document.getElementById('TextBox1').value = data_uri;
                div = document.getElementById('oculto');
                div.style.display = 'none';
                // alert(data_uri);

            });

        }

        function Search_Gridview(strKey) {
            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById('<%=GridEstudiante.ClientID%>');
            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                        styleDisplay = '';
                    else {
                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }
        }

    </script>

</body>
</html>
