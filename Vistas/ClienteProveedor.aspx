<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ClienteProveedor.aspx.cs" Inherits="Sistema_Inventario.Vistas.ClienteProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">

    <section id="contenedor">
        <section id="ListaMenu">
            <nav id="menu">
                <ul>
                    <li><a href="Inventario.aspx" id="enlaces">Inventario</a></li>
                    <li><a href="CategoriasProductos.aspx" id="enlaces" >Categoría Producto</a></li>
                    <li><a href="CompraProductos.aspx" id="enlaces">Compra de Producto</a></li>
                    <li><a href="ComprasRealizada.aspx" id="enlaces">Compras Realizadas</a></li>
                    <li><a href="VentaProducto.aspx" id="enlaces">Venta de Producto</a></li>
                    <li><a href="VentaRealizada.aspx" id="enlaces">Venta Realizada</a></li>
                    <li><a href="Bodega.aspx" id="enlaces">Bodega/Productos</a></li>
                    <li><a href="ClienteProveedor.aspx" id="enlaces">Cliente/Proveedor</a></li>
                </ul>

            </nav>
        </section>
        <section id="Contenido">
            <form id="form1" runat="server">
                <div class="Formularios">
                        <h4> Cliente/Proveedor</h4>  
                        <asp:TextBox ID="TextBox_Id" runat="server" Visible="false"></asp:TextBox>
                        <asp:Label ID="Label_Cliente" runat="server" Text="Cliente"></asp:Label>
                        <asp:Label ID="Label_Proveedor" runat="server" Text="Proveedor"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox_Nombre" runat="server" CssClass="CampoTexto" onkeypress="return soloLetras(event);"></asp:TextBox>
                        <br />
                       
                        <asp:Label ID="Label2" runat="server" Text="Dirección"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox_Direccion" runat="server" CssClass="CampoTexto" onkeypress="return soloLetras(event);"></asp:TextBox>
                        <br />

                        <asp:Label ID="Label3" runat="server" Text="Telefono"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox_Telefono" runat="server" CssClass="CampoTexto" onkeypress="return soloNumeros(event);"></asp:TextBox>
                        <br />

                        
                        <asp:Label ID="Label_Categoria" runat="server" Text="Email"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox_Email" runat="server" CssClass="CampoTexto"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="Fecha"></asp:Label>
                        <br />
                        <asp:TextBox ID="TextBox_Fecha" runat="server" CssClass="CampoTexto" ReadOnly="true"></asp:TextBox>
                        <br />
                        <br />
                      
                    
                    <asp:Button ID="Button_Guardar" runat="server" Text="Guardar" BorderStyle="None" CssClass="Button" OnClick="Button_Guardar_Click" />
                    <asp:Button ID="Button_Actualizar" runat="server" Text="Actualizar" BorderStyle="None" CssClass="Button" OnClick="Button_Actualizar_Click"/>
                    <asp:Button ID="Button_Cancelar" runat="server" Text="Cancelar" BorderStyle="None" CssClass="Button" OnClick="Button_Cancelar_Click" />
                     <br />
                     <br />
                </div>
                <div class="Formularios">
                        <br />
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" BorderColor="White" BorderStyle="Solid" BorderWidth="2px" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="6" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:CommandField ButtonType="Image" HeaderText="Editar" ShowSelectButton="True" SelectImageUrl="~/Images/Sign_up_Icon_256.png" />
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Eliminar_Icon.png" HeaderText="Eliminar" ShowDeleteButton="True" />
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerSettings Mode="NumericFirstLast" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                        
                        <asp:Image ID="Image1" runat="server" Height="34px" ImageUrl="~/Images/Vista_Elements_Icons.png" Width="39px" />
                        <asp:TextBox ID="TextBox_Buscar" runat="server" AutoCompleteType="Search" AutoPostBack="True" CssClass="CampoTexto" Width="101px" OnTextChanged="TextBox_Buscar_TextChanged"></asp:TextBox>
                        <asp:RadioButton ID="RadioButton_Cliente" runat="server" Checked="True" GroupName="Tipo" Text="Cliente" />
                        <asp:RadioButton ID="RadioButton_Proveedor" runat="server" GroupName="Tipo" Text="Proveedor" />
                        <asp:Button ID="Button_Tipo" runat="server" BorderStyle="None" CssClass="Button" Height="26px" Text="Tipo" Width="54px" OnClick="Button_Tipo_Click" />
                        <asp:Label ID="Label_Mensaje" runat="server" ForeColor="#FF3300"></asp:Label>
                        <br />
                </div>
            </form>
        </section>
    </section>

</asp:Content>
