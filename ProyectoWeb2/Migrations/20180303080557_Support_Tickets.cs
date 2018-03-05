using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProyectoWeb2.Migrations
{
    public partial class Support_Tickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Support_Tickets",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Clienteid = table.Column<int>(nullable: false),
                    Detalle_del_problema = table.Column<string>(nullable: true),
                    Estado_actual = table.Column<string>(nullable: true),
                    Quién_reporta_el_problema = table.Column<string>(nullable: true),
                    Título_Problema = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Support_Tickets", x => x.id);
                    table.ForeignKey(
                        name: "FK_Support_Tickets_Clientes_Clienteid",
                        column: x => x.Clienteid,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Support_Tickets_Clienteid",
                table: "Support_Tickets",
                column: "Clienteid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Support_Tickets");
        }
    }
}
