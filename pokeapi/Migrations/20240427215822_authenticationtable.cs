using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pokeapi.Migrations
{
    public partial class authenticationtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categorypokemon_categories_categoryid",
                table: "categorypokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_categorypokemon_pokemons_pokemonsid",
                table: "categorypokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_ownerpokemon_owners_ownerid",
                table: "ownerpokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_ownerpokemon_pokemons_pokemonsid",
                table: "ownerpokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_owners_country_countryid",
                table: "owners");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_pokemons_pokemonid",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_reviewers_reviewerid",
                table: "reviews");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "reviews",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "text",
                table: "reviews",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "reviewerid",
                table: "reviews",
                newName: "ReviewerId");

            migrationBuilder.RenameColumn(
                name: "pokemonid",
                table: "reviews",
                newName: "pokemonId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "reviews",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_reviewerid",
                table: "reviews",
                newName: "IX_reviews_ReviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_pokemonid",
                table: "reviews",
                newName: "IX_reviews_pokemonId");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "reviewers",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "reviewers",
                newName: "Firstname");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "reviewers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "pokemons",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "birthdate",
                table: "pokemons",
                newName: "Birthdate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "pokemons",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "owners",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "gym",
                table: "owners",
                newName: "Gym");

            migrationBuilder.RenameColumn(
                name: "countryid",
                table: "owners",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "owners",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_owners_countryid",
                table: "owners",
                newName: "IX_owners_CountryId");

            migrationBuilder.RenameColumn(
                name: "pokemonsid",
                table: "ownerpokemon",
                newName: "pokemonsId");

            migrationBuilder.RenameColumn(
                name: "ownerid",
                table: "ownerpokemon",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_ownerpokemon_pokemonsid",
                table: "ownerpokemon",
                newName: "IX_ownerpokemon_pokemonsId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "country",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "country",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "pokemonsid",
                table: "categorypokemon",
                newName: "pokemonsId");

            migrationBuilder.RenameColumn(
                name: "categoryid",
                table: "categorypokemon",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_categorypokemon_pokemonsid",
                table: "categorypokemon",
                newName: "IX_categorypokemon_pokemonsId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "categories",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_categorypokemon_categories_categoryId",
                table: "categorypokemon",
                column: "categoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_categorypokemon_pokemons_pokemonsId",
                table: "categorypokemon",
                column: "pokemonsId",
                principalTable: "pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ownerpokemon_owners_OwnerId",
                table: "ownerpokemon",
                column: "OwnerId",
                principalTable: "owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ownerpokemon_pokemons_pokemonsId",
                table: "ownerpokemon",
                column: "pokemonsId",
                principalTable: "pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_owners_country_CountryId",
                table: "owners",
                column: "CountryId",
                principalTable: "country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_pokemons_pokemonId",
                table: "reviews",
                column: "pokemonId",
                principalTable: "pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_reviewers_ReviewerId",
                table: "reviews",
                column: "ReviewerId",
                principalTable: "reviewers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categorypokemon_categories_categoryId",
                table: "categorypokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_categorypokemon_pokemons_pokemonsId",
                table: "categorypokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_ownerpokemon_owners_OwnerId",
                table: "ownerpokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_ownerpokemon_pokemons_pokemonsId",
                table: "ownerpokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_owners_country_CountryId",
                table: "owners");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_pokemons_pokemonId",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_reviewers_ReviewerId",
                table: "reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "pokemonId",
                table: "reviews",
                newName: "pokemonid");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "reviews",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "reviews",
                newName: "text");

            migrationBuilder.RenameColumn(
                name: "ReviewerId",
                table: "reviews",
                newName: "reviewerid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "reviews",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_ReviewerId",
                table: "reviews",
                newName: "IX_reviews_reviewerid");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_pokemonId",
                table: "reviews",
                newName: "IX_reviews_pokemonid");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "reviewers",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "reviewers",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "reviewers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "pokemons",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Birthdate",
                table: "pokemons",
                newName: "birthdate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "pokemons",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "owners",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Gym",
                table: "owners",
                newName: "gym");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "owners",
                newName: "countryid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "owners",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_owners_CountryId",
                table: "owners",
                newName: "IX_owners_countryid");

            migrationBuilder.RenameColumn(
                name: "pokemonsId",
                table: "ownerpokemon",
                newName: "pokemonsid");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "ownerpokemon",
                newName: "ownerid");

            migrationBuilder.RenameIndex(
                name: "IX_ownerpokemon_pokemonsId",
                table: "ownerpokemon",
                newName: "IX_ownerpokemon_pokemonsid");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "country",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "country",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "pokemonsId",
                table: "categorypokemon",
                newName: "pokemonsid");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "categorypokemon",
                newName: "categoryid");

            migrationBuilder.RenameIndex(
                name: "IX_categorypokemon_pokemonsId",
                table: "categorypokemon",
                newName: "IX_categorypokemon_pokemonsid");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "categories",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "categories",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_categorypokemon_categories_categoryid",
                table: "categorypokemon",
                column: "categoryid",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_categorypokemon_pokemons_pokemonsid",
                table: "categorypokemon",
                column: "pokemonsid",
                principalTable: "pokemons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ownerpokemon_owners_ownerid",
                table: "ownerpokemon",
                column: "ownerid",
                principalTable: "owners",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ownerpokemon_pokemons_pokemonsid",
                table: "ownerpokemon",
                column: "pokemonsid",
                principalTable: "pokemons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_owners_country_countryid",
                table: "owners",
                column: "countryid",
                principalTable: "country",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_pokemons_pokemonid",
                table: "reviews",
                column: "pokemonid",
                principalTable: "pokemons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_reviewers_reviewerid",
                table: "reviews",
                column: "reviewerid",
                principalTable: "reviewers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
