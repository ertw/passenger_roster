using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;
using System.Collections.Generic;

namespace PassengerRoster.Migrations
{
    public partial class SeedDataFromSqlScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(File.ReadAllText(@"Migrations/seedData.sql"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
