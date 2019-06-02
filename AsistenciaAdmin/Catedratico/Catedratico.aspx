<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Catedratico.aspx.cs" Inherits="AsistenciaAdmin.Catedratico.Catedratico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Catedratico</title>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <link href="http://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body style="padding: 20px;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
                <a class="navbar-brand" href="#"></a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item">
                            <a class="nav-link" href="../Estudiante/EstudianteIngreso.aspx">Estudiantes <span class="sr-only">(current)</span></a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active" href="Catedratico.aspx">Catedratico</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="../Curso/CursoMostrar.aspx">Curso</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="../Evento/Evento.aspx">Evento</a>
                        </li>
                    </ul>

                    <input id="txtBuscar" class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search" onkeyup="Search_Gridview(this)" />
                    <button type="button" class="btn btn-success" data-toggle="modal" data-target="#modal_Ingreso">Nuevo</button>
                </div>
            </nav>

            <section class="content-header">
                <br />
                <br />
                <h3 align="center" style="margin-top: 5px">REGISTRO DE CATEDRATICOS</h3>
            </section>
            <br />
            <br />

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridCatedratico" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowDeleting="EliminarCatedratico" OnSelectedIndexChanged="ActualizarCatedratico" OnRowCommand="GridCatedratico_RowCommand" EmptyDataText="Datos no disponibles">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>

                            <asp:CommandField DeleteText="Eliminar" ShowDeleteButton="True" HeaderStyle-Width="2%">
                                <ControlStyle CssClass="btn btn-xs btn-danger" />
                                <ItemStyle CssClass="text-center" ForeColor="White" />
                            </asp:CommandField>

                            <asp:CommandField SelectText="Modificar" ShowSelectButton="True" HeaderStyle-Width="2%">
                                <ControlStyle CssClass="btn btn-xs btn-info" />
                                <ItemStyle CssClass="text-center" ForeColor="White" />
                            </asp:CommandField>

                            <asp:BoundField DataField="IdCatedratico" HeaderText="ID" />
                            <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
                            <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                            <asp:BoundField DataField="Password" HeaderText="Password" />
                            <asp:ButtonField ButtonType="Button" Text="Asignaciones" ControlStyle-CssClass="btn btn-primary" CommandName="Asignaciones" HeaderStyle-Width="2%" />
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
        </div>


        <!-----------------------------------------MODAL INGRESO--------------------------------------->

        <div id="modal_Ingreso" class="modal fade" role="dialog" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog modal-lg" role="document">

                <div class="modal-content">
                    <div class="modal-header" style="background-color: #5F96D5; text-align: center; color: white">
                        <h4 class="modal-title" id="exampleModalLabe">Ingreso de Curso</h4>
                        <button class="close" type="button" data-dismiss="modal" aria-label="Close" style="margin-top: -25px">
                            <span aria-hidden="true" style="color: red">X</span>

                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="box box-primary">
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-12">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <div class="row">
                                                    <div class="col-6">
                                                        <div class="form-label-group">
                                                            <label for="nombres">Nombres: </label>
                                                            <asp:TextBox ID="txtIdCatedratico" runat="server" Text="" class="form-control" Height="30px" required="required" Visible="False"></asp:TextBox>
                                                            <asp:TextBox ID="txtNombres" runat="server" Text="" class="form-control" Height="30px" required="required"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-6">
                                                        <div class="form-label-group">
                                                            <label for="apellidos">Apellidos: </label>
                                                            <asp:TextBox ID="txtApellidos" runat="server" Text="" class="form-control" Height="30px" required="required"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-12">
                                                        <div class="form-label-group">
                                                            <label for="email">Email: </label>
                                                            <asp:TextBox ID="txtEmail" runat="server" Text="" TextMode="Email" class="form-control" Height="30px" required="required" Visible="true"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-6">
                                                        <div class="form-label-group">
                                                            <label for="usuario">Usuario: </label>
                                                            <asp:TextBox ID="txtUsuario" runat="server" Text="" class="form-control" Height="30px" required="required"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-6">
                                                        <div class="form-label-group">
                                                            <label for="password">Password: </label>
                                                            <asp:TextBox ID="txtPassword" runat="server" Text="" class="form-control" Height="30px" required="required"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="modal-footer">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="btnCancelar" runat="server" class="btn btn-danger" Text="Cancelar" OnClick="btnCancelar_Click"></asp:LinkButton>
                                <asp:LinkButton ID="btnAgregar1" runat="server" Text="Agregar" class="btn btn-success" OnClick="btnAgregar_Click"></asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                </div>
            </div>
        </div>

        <!---------------------------------------TERMINA MODAL ------------------------------->


        <!-----------------------------------------MODAL CURSOS ASIGNADOS--------------------------------------->

        <div id="modal_CursosAsignados" class="modal fade" role="dialog" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog modal-lg" role="document">

                <div class="modal-content">
                    <div class="modal-header" style="background-color: #5F96D5; text-align: center; color: white">
                        <h4 class="modal-title" id="exampleModalLabe2">Cursos Asignados</h4>
                        <button class="close" type="button" data-dismiss="modal" aria-label="Close" style="margin-top: -25px">
                            <span aria-hidden="true" style="color: red">X</span>

                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="box box-primary">
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-12">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <div class="row">
                                                    <div class="col-12">
                                                        <div class="form-label-group">
                                                            <label for="apellidos">Buscar</label>
                                                            <input id="txtBuscar2" class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search" onkeyup="Search_Gridview2(this)" />
                                                            <br />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-12">
                                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="GridAsignacionesCatedratico" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowDeleting="EliminarCatedratico" OnSelectedIndexChanged="ActualizarCatedratico" OnRowCommand="GridCatedratico_RowCommand" EmptyDataText="Datos no disponibles">
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                    <Columns>

                                                                        <asp:BoundField DataField="idAsignacionCatedratico" HeaderText="ID" />
                                                                        <asp:BoundField DataField="idCurso" HeaderText="Codigo Curso" />
                                                                        <asp:BoundField DataField="Nombre" HeaderText="Curso" />
                                                                        <asp:BoundField DataField="Ciclo" HeaderText="Ciclo" />

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
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="modal-footer">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <%--<asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-danger" Text="Cancelar" OnClick="btnCancelar_Click"></asp:LinkButton>--%>
                                <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>

                </div>
            </div>
        </div>

        <!---------------------------------------TERMINA MODAL ------------------------------->
    </form>

    <script>

        function abrirModal() {
            $('#modal_Ingreso').modal('show');
        }

        function cerrarModal() {
            $('#modal_Ingreso').modal('hide');
        }

        function abrirModal2() {
            $('#modal_CursosAsignados').modal('show');
        }


        function Search_Gridview(strKey) {
            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById('<%=GridCatedratico.ClientID%>');
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

        function Search_Gridview2(strKey) {
            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById('<%=GridAsignacionesCatedratico.ClientID%>');
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
