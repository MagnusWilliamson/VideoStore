using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MovieMaster.Migrations
{
    public partial class Alpha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Contract_ContractId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_ContractId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Movie");

            migrationBuilder.AddColumn<string>(
                name: "MovieId",
                table: "Contract",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Contract");

            migrationBuilder.AddColumn<string>(
                name: "ContractId",
                table: "Movie",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_ContractId",
                table: "Movie",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Contract_ContractId",
                table: "Movie",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "ContractId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
