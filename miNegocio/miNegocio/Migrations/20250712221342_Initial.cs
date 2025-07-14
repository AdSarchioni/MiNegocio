using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiNegocio.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    direccionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    calleDireccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    codigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usuarioId = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direcciones", x => x.direccionId);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    productoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    precio = table.Column<double>(type: "float", nullable: false),
                    stock = table.Column<double>(type: "float", nullable: false),
                    id_categoria = table.Column<int>(type: "int", nullable: false),
                    imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.productoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    usuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dni = table.Column<int>(type: "int", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estado_usuario = table.Column<int>(type: "int", nullable: false),
                    rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.usuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    pedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuarioId = table.Column<int>(type: "int", nullable: false),
                    direccionId = table.Column<int>(type: "int", nullable: false),
                    fechaPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    total = table.Column<double>(type: "float", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.pedidoId);
                    table.ForeignKey(
                        name: "FK_Pedidos_Direcciones_direccionId",
                        column: x => x.direccionId,
                        principalTable: "Direcciones",
                        principalColumn: "direccionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detallespedido",
                columns: table => new
                {
                    detalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    productoId = table.Column<int>(type: "int", nullable: false),
                    pedidoId = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<double>(type: "float", nullable: false),
                    precioUnitario = table.Column<double>(type: "float", nullable: false),
                    total = table.Column<double>(type: "float", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detallespedido", x => x.detalleId);
                    table.ForeignKey(
                        name: "FK_Detallespedido_Pedidos_pedidoId",
                        column: x => x.pedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "pedidoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detallespedido_Productos_productoId",
                        column: x => x.productoId,
                        principalTable: "Productos",
                        principalColumn: "productoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detallespedido_pedidoId",
                table: "Detallespedido",
                column: "pedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Detallespedido_productoId",
                table: "Detallespedido",
                column: "productoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_direccionId",
                table: "Pedidos",
                column: "direccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_usuarioId",
                table: "Pedidos",
                column: "usuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detallespedido");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Direcciones");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
