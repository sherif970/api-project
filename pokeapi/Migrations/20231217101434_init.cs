using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pokeapi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pokemons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pokemons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "reviewers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviewers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "owners",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gym = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    countryid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owners", x => x.id);
                    table.ForeignKey(
                        name: "FK_owners_country_countryid",
                        column: x => x.countryid,
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "categorypokemon",
                columns: table => new
                {
                    categoryid = table.Column<int>(type: "int", nullable: false),
                    pokemonsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorypokemon", x => new { x.categoryid, x.pokemonsid });
                    table.ForeignKey(
                        name: "FK_categorypokemon_categories_categoryid",
                        column: x => x.categoryid,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categorypokemon_pokemons_pokemonsid",
                        column: x => x.pokemonsid,
                        principalTable: "pokemons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reviewerid = table.Column<int>(type: "int", nullable: false),
                    pokemonid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.id);
                    table.ForeignKey(
                        name: "FK_reviews_pokemons_pokemonid",
                        column: x => x.pokemonid,
                        principalTable: "pokemons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reviews_reviewers_reviewerid",
                        column: x => x.reviewerid,
                        principalTable: "reviewers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ownerpokemon",
                columns: table => new
                {
                    ownerid = table.Column<int>(type: "int", nullable: false),
                    pokemonsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ownerpokemon", x => new { x.ownerid, x.pokemonsid });
                    table.ForeignKey(
                        name: "FK_ownerpokemon_owners_ownerid",
                        column: x => x.ownerid,
                        principalTable: "owners",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ownerpokemon_pokemons_pokemonsid",
                        column: x => x.pokemonsid,
                        principalTable: "pokemons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categorypokemon_pokemonsid",
                table: "categorypokemon",
                column: "pokemonsid");

            migrationBuilder.CreateIndex(
                name: "IX_ownerpokemon_pokemonsid",
                table: "ownerpokemon",
                column: "pokemonsid");

            migrationBuilder.CreateIndex(
                name: "IX_owners_countryid",
                table: "owners",
                column: "countryid");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_pokemonid",
                table: "reviews",
                column: "pokemonid");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_reviewerid",
                table: "reviews",
                column: "reviewerid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categorypokemon");

            migrationBuilder.DropTable(
                name: "ownerpokemon");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "owners");

            migrationBuilder.DropTable(
                name: "pokemons");

            migrationBuilder.DropTable(
                name: "reviewers");

            migrationBuilder.DropTable(
                name: "country");
        }
    }
}
