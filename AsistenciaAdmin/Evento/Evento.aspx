<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Evento.aspx.cs" Inherits="AsistenciaAdmin.Evento.Evento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Evento</title>
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
                            <a class="nav-link" href="../Catedratico/Catedratico.aspx">Catedratico</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="../Curso/CursoMostrar.aspx">Curso</a>
                        </li>
                        <li class="nav-item active">
                            <a class="nav-link" href="Evento.aspx">Evento</a>
                        </li>
                    </ul>

                    <input id="txtBuscar" class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search" onkeyup="Search_Gridview(this)" />
                </div>
            </nav>

            <section class="content-header">
                <br />
                <br />
                <h3 align="center" style="margin-top: 5px">REGISTRO DE EVENTOS</h3>
            </section>
            <br />
            <br />

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridEvento" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowDeleting="EliminarEvento" OnSelectedIndexChanged="ActualizarEvento" EmptyDataText="Datos no disponibles" OnRowCommand="GridEvento_RowCommand">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="IdEvento" HeaderText="ID" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Año" HeaderText="Año" />
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


        <!-----------------------------------------MODAL CURSO--------------------------------------->

        <div id="modal_Ingreso" class="modal fade" role="dialog" data-backdrop="static" data-keyboard="false">
            <div class="modal-dialog" role="document">

                <div class="modal-content">
                    <div class="modal-header" style="background-color: #5F96D5; text-align: center; color: white">
                        <h4 class="modal-title" id="exampleModalLabe">Ingreso de Evento</h4>
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
                                                <div class="form-label-group">
                                                    <label for="nombre">Nombre Evento: </label>
                                                    <asp:TextBox ID="txtIdEvento" runat="server" Text="" class="form-control" Height="30px" required="required" Visible="False"></asp:TextBox>
                                                    <asp:TextBox ID="txtEvento" runat="server" Text="" class="form-control" required="required"></asp:TextBox>
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

    </form>

    <script>

        function abrirModal() {
            $('#modal_Ingreso').modal('show');
        }

        function cerrarModal() {
            $('#modal_Ingreso').modal('hide');
        }

        function abrirModal2() {
            $('#modal_Asigancion').modal('show');
        }

        function cerrarModal2() {
            $('#modal_Asigancion').modal('hide');
        }
        

        function Search_Gridview(strKey) {
                var strData = strKey.value.toLowerCase().split(" ");
                var tblData = document.getElementById('<%=GridEvento.ClientID%>');
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
