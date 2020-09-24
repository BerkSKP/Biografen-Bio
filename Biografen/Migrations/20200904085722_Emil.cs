using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biografen.Migrations
{
    public partial class Emil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "administrators",
                columns: table => new
                {
                    administratorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hallChoices = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrators", x => x.administratorId);
                });

            migrationBuilder.CreateTable(
                name: "billings",
                columns: table => new
                {
                    billingsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cardNumber = table.Column<long>(nullable: false),
                    cardName = table.Column<string>(nullable: true),
                    seatChoice = table.Column<int>(nullable: false),
                    movieName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    time = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_billings", x => x.billingsId);
                });

            migrationBuilder.CreateTable(
                name: "cinemaHalls",
                columns: table => new
                {
                    cinemahallId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    seats = table.Column<int>(nullable: false),
                    rows = table.Column<int>(nullable: false),
                    movieName = table.Column<string>(nullable: true),
                    movietime = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cinemaHalls", x => x.cinemahallId);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    customerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(nullable: true),
                    phonenumber = table.Column<int>(nullable: false),
                    userName = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    cardnumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.customerId);
                });

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    genreName = table.Column<string>(nullable: true),
                    genreDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "guests",
                columns: table => new
                {
                    guestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    phoneNumber = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    cardnumber = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guests", x => x.guestId);
                });

            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    movieID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    movieName = table.Column<string>(nullable: true),
                    movietime = table.Column<double>(nullable: false),
                    movieID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.movieID);
                    table.ForeignKey(
                        name: "FK_movies_movies_movieID1",
                        column: x => x.movieID1,
                        principalTable: "movies",
                        principalColumn: "movieID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "shows",
                columns: table => new
                {
                    showId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    movietime = table.Column<int>(nullable: false),
                    hall = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shows", x => x.showId);
                });

            migrationBuilder.CreateTable(
                name: "staffs",
                columns: table => new
                {
                    staffId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salary = table.Column<double>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    userName = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    admin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staffs", x => x.staffId);
                });

            migrationBuilder.CreateTable(
                name: "createUsers",
                columns: table => new
                {
                    createuserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<int>(nullable: false),
                    userinfo = table.Column<int>(nullable: false),
                    customerscustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_createUsers", x => x.createuserId);
                    table.ForeignKey(
                        name: "FK_createUsers_customers_customerscustomerId",
                        column: x => x.customerscustomerId,
                        principalTable: "customers",
                        principalColumn: "customerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_createUsers_customerscustomerId",
                table: "createUsers",
                column: "customerscustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_movies_movieID1",
                table: "movies",
                column: "movieID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administrators");

            migrationBuilder.DropTable(
                name: "billings");

            migrationBuilder.DropTable(
                name: "cinemaHalls");

            migrationBuilder.DropTable(
                name: "createUsers");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "guests");

            migrationBuilder.DropTable(
                name: "movies");

            migrationBuilder.DropTable(
                name: "shows");

            migrationBuilder.DropTable(
                name: "staffs");

            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
