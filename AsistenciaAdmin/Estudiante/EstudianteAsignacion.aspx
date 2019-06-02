<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EstudianteAsignacion.aspx.cs" Inherits="AsistenciaAdmin.Estudiante.EstudianteAsignacion" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Asignaciones Estudiante</title>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <link href="http://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
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
                            <li class="nav-item dropdown">
                                <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Prueba
                                </a>
                                <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                                    <a class="dropdown-item" href="#">Action</a>
                                    <a class="dropdown-item" href="#">Another action</a>
                                    <div class="dropdown-divider"></div>
                                    <a class="dropdown-item" href="#">Something else here</a>
                                </div>
                            </li>
                        </ul>
                        <input class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search">
                    </div>
                </nav>
            </div>

            <section class="content-header">
                <br />
                <br />
                <h3 align="center" style="margin-top: 5px">ASIGNACIONES</h3>
            </section>
            <br />

            <section>
                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-primary">
                            <div class="box-body" style="position: relative">
                                <div class="row">
                                    <div class="col-md-1" style="text-align: center">
                                        <asp:Label ID="Label12" runat="server" Text="ID"></asp:Label>

                                    </div>
                                    <div class="col-md-1">
                                        <asp:TextBox ID="txtIDE" runat="server" Text="" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-md-1" style="text-align: center">
                                        <asp:Label ID="Label15" runat="server" Text="Estudiante:"></asp:Label>

                                    </div>
                                    <div class="col-md-9">
                                        <asp:TextBox ID="txtNombres" runat="server" Text="" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                <ContentTemplate>
                    <asp:HiddenField ID="hdfFoto" runat="server" />
                    <asp:HiddenField ID="hdfPersonId" runat="server" />
                    <!--INICIA CICLO 1-->
                    <div class="row">
                        <div class="col-md-6">
                            <br />
                            <br />
                            <div style="padding: 15px;">
                                <p>
                                    <button class="btn btn-primary" type="button"  data-target="#collapseExample1" aria-expanded="false" aria-controls="collapseExample">
                                        Primer Ciclo
                                    </button>
                                </p>
                                <div id="collapseExample1">
                                    <div class="card card-body" style="border: 1px solid #ccc!important; padding: 16px; border-radius: 16px;">
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridCiclo1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Font-Size="Small" EmptyDataText="Datos no disponibles">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="idAsignacionCatedratico" HeaderText="ID" />
                                                    <asp:BoundField DataField="Nombre" HeaderText="Curso" />
                                                    <asp:BoundField DataField="personGroupId" HeaderText="PGID" />
                                                    <asp:BoundField />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkRow" runat="server" OnCheckedChanged="CheckBox_ChangedCiclo1" AutoPostBack="true" />
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

                                        </div>
                                    </div>
                                    <br />
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <br />
                            <br />
                            <br />
                            <div style="padding: 5px;">
                                <p>
                                    <asp:Label Text="Asignacion Ciclo I" runat="server"></asp:Label>
                                </p>
                                <div class="card card-body" style="border: 1px solid #ccc!important; padding: 16px; border-radius: 16px;">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div class="table-responsive">

                                                <asp:GridView ID="GridAsignaciones" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Font-Size="Small">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField DataField="ID" HeaderText="ID" />
                                                        <asp:BoundField DataField="Curso" HeaderText="Curso" />
                                                        <asp:BoundField DataField="personGroupId" HeaderText="PGID" />
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

                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- FIN -->

                    <!--INICIA CICLO 2-->
                    <div class="row">
                        <div class="col-md-6">
                            <div style="padding: 50px;">
                                <p>
                                    <button class="btn btn-primary" type="button" data-target="#collapseExample2" aria-expanded="false" aria-controls="collapseExample">
                                        Segundo Ciclo</button>
                                </p>
                                <div id="collapseExample2">
                                    <div class="card card-body" style="border: 1px solid #ccc!important; padding: 16px; border-radius: 16px;">
                                        <div class="table-responsive">

                                            <asp:GridView ID="GridCiclo2" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Font-Size="Small" EmptyDataText="Datos no disponibles">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="idAsignacionCatedratico" HeaderText="ID" />
                                                    <asp:BoundField DataField="Nombre" HeaderText="Curso" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkRow2" runat="server" OnCheckedChanged="CheckBox_ChangedCiclo2" AutoPostBack="true" />
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

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <br />
                            <br />
                            <div style="padding: 15px;">
                                <p>
                                    <asp:Label Text="Asignacion Ciclo II" runat="server"></asp:Label>
                                </p>
                                <div class="card card-body" style="border: 1px solid #ccc!important; padding: 16px; border-radius: 16px;">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div class="table-responsive">

                                                <asp:GridView ID="GridAsignaciones2" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField DataField="ID" HeaderText="ID" />
                                                        <asp:BoundField DataField="Curso" HeaderText="Curso" />
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

                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- FIN -->

                    <!--INICIA CICLO 3-->
                    <div class="row">
                        <div class="col-md-6">
                            <div style="padding: 50px;">
                                <p>
                                    <button class="btn btn-primary" type="button" data-target="#collapseExample3" aria-expanded="false" aria-controls="collapseExample">
                                        Tercer Ciclo</button>
                                </p>
                                <div id="collapseExample3">
                                    <div class="card card-body" style="border: 1px solid #ccc!important; padding: 16px; border-radius: 16px;">
                                        <div class="table-responsive">

                                            <asp:GridView ID="GridCurso3" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Font-Size="Small" EmptyDataText="Datos no disponibles">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="idAsignacionCatedratico" HeaderText="ID" />
                                                    <asp:BoundField DataField="Nombre" HeaderText="Curso" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkRow3" runat="server" OnCheckedChanged="CheckBox_ChangedCiclo3" AutoPostBack="true" />
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

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <br />
                            <br />
                            <div style="padding: 15px;">
                                <p>
                                    <asp:Label Text="Asignacion Ciclo III" runat="server"></asp:Label>
                                </p>
                                <div class="card card-body" style="border: 1px solid #ccc!important; padding: 16px; border-radius: 16px;">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <div class="table-responsive">

                                                <asp:GridView ID="GridAsignaciones3" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField DataField="ID" HeaderText="ID" />
                                                        <asp:BoundField DataField="Curso" HeaderText="Curso" />
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

                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- FIN -->

                    <!--INICIA CICLO 4-->
                    <div class="row">
                        <div class="col-md-6">
                            <div style="padding: 50px;">
                                <p>
                                    <button class="btn btn-primary" type="button" data-target="#collapseExample4" aria-expanded="false" aria-controls="collapseExample">
                                        Cuarto Ciclo</button>
                                </p>
                                <div id="collapseExample4">
                                    <div class="card card-body" style="border: 1px solid #ccc!important; padding: 16px; border-radius: 16px;">
                                        <div class="table-responsive">

                                            <asp:GridView ID="GridCiclo4" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Font-Size="Small" EmptyDataText="Datos no disponibles">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="idAsignacionCatedratico" HeaderText="ID" />
                                                    <asp:BoundField DataField="Nombre" HeaderText="Curso" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkRow4" runat="server" OnCheckedChanged="CheckBox_ChangedCiclo4" AutoPostBack="true" />
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

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <br />
                            <br />
                            <div style="padding: 15px;">
                                <p>
                                    <asp:Label Text="Asignacion Ciclo IV" runat="server"></asp:Label>
                                </p>
                                <div class="card card-body" style="border: 1px solid #ccc!important; padding: 16px; border-radius: 16px;">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <div class="table-responsive">

                                                <asp:GridView ID="GridAsignaciones4" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField DataField="ID" HeaderText="ID" />
                                                        <asp:BoundField DataField="Curso" HeaderText="Curso" />
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

                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- FIN -->

                    <!--INICIA CILO 5-->
                    <div class="row">
                        <div class="col-md-6">
                            <div style="padding: 50px;">
                                <p>
                                    <button class="btn btn-primary" type="button" data-target="#collapseExample5" aria-expanded="false" aria-controls="collapseExample">
                                        Quinto Ciclo</button>
                                </p>
                                <div id="collapseExample5">
                                    <div class="card card-body" style="border: 1px solid #ccc!important; padding: 16px; border-radius: 16px;">
                                        <div class="table-responsive">

                                            <asp:GridView ID="GridCiclo5" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" Font-Size="Small" EmptyDataText="Datos no disponibles">
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="idAsignacionCatedratico" HeaderText="ID" />
                                                    <asp:BoundField DataField="Nombre" HeaderText="Curso" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkRow5" runat="server" OnCheckedChanged="CheckBox_ChangedCiclo5" AutoPostBack="true" />
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

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <br />
                            <br />
                            <div style="padding: 15px;">
                                <p>
                                    <asp:Label Text="Asignacion Ciclo V" runat="server"></asp:Label>
                                </p>
                                <div class="card card-body" style="border: 1px solid #ccc!important; padding: 16px; border-radius: 16px;">
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <div class="table-responsive">

                                                <asp:GridView ID="GridAsignaciones5" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField DataField="ID" HeaderText="ID" />
                                                        <asp:BoundField DataField="Curso" HeaderText="Curso" />
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

                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- FIN -->
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <br />

            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-4"></div>
                <div class="col-md-4">
                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                        <ContentTemplate>
                            <asp:LinkButton ID="btnAgregar1" runat="server" Text="Ingresar Asignacion" class="btn btn-success" OnClick="btnAgregar1_Click"></asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
