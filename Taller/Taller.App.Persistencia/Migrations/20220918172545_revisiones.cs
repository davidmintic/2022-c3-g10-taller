using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taller.App.Persistencia.Migrations
{
    public partial class revisiones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "telefono",
                table: "Mechanics",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Mechanics",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "nivelEstudio",
                table: "Mechanics",
                newName: "NivelEstudio");

            migrationBuilder.RenameColumn(
                name: "fechaNacimiento",
                table: "Mechanics",
                newName: "FechaNacimiento");

            migrationBuilder.RenameColumn(
                name: "direccion",
                table: "Mechanics",
                newName: "Direccion");

            migrationBuilder.RenameColumn(
                name: "contrasenia",
                table: "Mechanics",
                newName: "Contrasenia");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Mechanics",
                newName: "MecanicoId");

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    VehiculoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    Cilindraje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisOrigen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modelo = table.Column<int>(type: "int", nullable: false),
                    marca = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.VehiculoId);
                });

            migrationBuilder.CreateTable(
                name: "Revisiones",
                columns: table => new
                {
                    RevisionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MecanicoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VehiculoId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revisiones", x => x.RevisionId);
                    table.ForeignKey(
                        name: "FK_Revisiones_Mechanics_MecanicoId",
                        column: x => x.MecanicoId,
                        principalTable: "Mechanics",
                        principalColumn: "MecanicoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Revisiones_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "VehiculoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Revisiones_MecanicoId",
                table: "Revisiones",
                column: "MecanicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Revisiones_VehiculoId",
                table: "Revisiones",
                column: "VehiculoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Revisiones");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Mechanics",
                newName: "telefono");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Mechanics",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "NivelEstudio",
                table: "Mechanics",
                newName: "nivelEstudio");

            migrationBuilder.RenameColumn(
                name: "FechaNacimiento",
                table: "Mechanics",
                newName: "fechaNacimiento");

            migrationBuilder.RenameColumn(
                name: "Direccion",
                table: "Mechanics",
                newName: "direccion");

            migrationBuilder.RenameColumn(
                name: "Contrasenia",
                table: "Mechanics",
                newName: "contrasenia");

            migrationBuilder.RenameColumn(
                name: "MecanicoId",
                table: "Mechanics",
                newName: "id");
        }
    }
}
