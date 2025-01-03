using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend_Crypto.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cryptos",
                columns: table => new
                {
                    IdCrypto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Symbole = table.Column<string>(type: "text", nullable: false),
                    Nom = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cryptos", x => x.IdCrypto);
                });

            migrationBuilder.CreateTable(
                name: "Portefeuilles",
                columns: table => new
                {
                    IdPortefeuille = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUser = table.Column<int>(type: "integer", nullable: false),
                    Fond = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portefeuilles", x => x.IdPortefeuille);
                });

            migrationBuilder.CreateTable(
                name: "Historiques",
                columns: table => new
                {
                    IdHistorique = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrixCrypto = table.Column<double>(type: "double precision", nullable: false),
                    DateChange = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    idCrypto = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historiques", x => x.IdHistorique);
                    table.ForeignKey(
                        name: "FK_Historiques_Cryptos_idCrypto",
                        column: x => x.idCrypto,
                        principalTable: "Cryptos",
                        principalColumn: "IdCrypto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    IdPorteFeuille = table.Column<int>(type: "integer", nullable: false),
                    IdCrypto = table.Column<int>(type: "integer", nullable: false),
                    Stock = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => new { x.IdPorteFeuille, x.IdCrypto });
                    table.ForeignKey(
                        name: "FK_Stocks_Cryptos_IdCrypto",
                        column: x => x.IdCrypto,
                        principalTable: "Cryptos",
                        principalColumn: "IdCrypto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Portefeuilles_IdPorteFeuille",
                        column: x => x.IdPorteFeuille,
                        principalTable: "Portefeuilles",
                        principalColumn: "IdPortefeuille",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transac",
                columns: table => new
                {
                    IdTransaction = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    DateTransaction = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    IdPortefeuille = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transac", x => x.IdTransaction);
                    table.ForeignKey(
                        name: "FK_Transac_Portefeuilles_IdPortefeuille",
                        column: x => x.IdPortefeuille,
                        principalTable: "Portefeuilles",
                        principalColumn: "IdPortefeuille",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordres",
                columns: table => new
                {
                    IdOrdre = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrixUnitaire = table.Column<double>(type: "double precision", nullable: false),
                    AmountCrypto = table.Column<double>(type: "double precision", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    IdTransaction = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordres", x => x.IdOrdre);
                    table.ForeignKey(
                        name: "FK_Ordres_Transac_IdTransaction",
                        column: x => x.IdTransaction,
                        principalTable: "Transac",
                        principalColumn: "IdTransaction",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    IdToken = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Token = table.Column<string>(type: "TEXT", nullable: false),
                    DateExpiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsUsed = table.Column<bool>(type: "boolean", nullable: false),
                    IdTransaction = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.IdToken);
                    table.ForeignKey(
                        name: "FK_Tokens_Transac_IdTransaction",
                        column: x => x.IdTransaction,
                        principalTable: "Transac",
                        principalColumn: "IdTransaction",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cryptos_Nom",
                table: "Cryptos",
                column: "Nom",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cryptos_Symbole",
                table: "Cryptos",
                column: "Symbole",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Historiques_idCrypto",
                table: "Historiques",
                column: "idCrypto");

            migrationBuilder.CreateIndex(
                name: "IX_Ordres_IdTransaction",
                table: "Ordres",
                column: "IdTransaction",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Portefeuilles_IdUser",
                table: "Portefeuilles",
                column: "IdUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_IdCrypto",
                table: "Stocks",
                column: "IdCrypto");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_IdTransaction",
                table: "Tokens",
                column: "IdTransaction");

            migrationBuilder.CreateIndex(
                name: "IX_Transac_IdPortefeuille",
                table: "Transac",
                column: "IdPortefeuille");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historiques");

            migrationBuilder.DropTable(
                name: "Ordres");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "Cryptos");

            migrationBuilder.DropTable(
                name: "Transac");

            migrationBuilder.DropTable(
                name: "Portefeuilles");
        }
    }
}
