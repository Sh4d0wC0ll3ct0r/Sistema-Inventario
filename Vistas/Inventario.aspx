<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inventario.aspx.cs" Inherits="Sistema_Inventario.Vistas.Inventario" %>
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
            <center>
                <asp:Image ID="img" runat="server" ImageUrl="~/Images/banner-inventario1.png" AlternateText="Imagen no Disponible" ImageAlign="TextTop" />
            </center>
        </section>
    </section>

</asp:Content>
