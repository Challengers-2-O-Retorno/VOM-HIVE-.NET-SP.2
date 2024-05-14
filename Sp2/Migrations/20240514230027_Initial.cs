using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sp2.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    id_company = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_company = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    cnpj = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dt_register = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.id_company);
                });

            migrationBuilder.CreateTable(
                name: "Pay_hist",
                columns: table => new
                {
                    id_history = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    value_pay = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    dt_payment = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    dt_due = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    nfe = table.Column<byte[]>(type: "RAW(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pay_hist", x => x.id_history);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id_product = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_product = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    category_product = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id_product);
                });

            migrationBuilder.CreateTable(
                name: "Profile_user",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_user = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    pass_user = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dt_user = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    permission_user = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    status_user = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    id_company = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile_user", x => x.id_user);
                    table.ForeignKey(
                        name: "FK_Profile_user_Company_id_company",
                        column: x => x.id_company,
                        principalTable: "Company",
                        principalColumn: "id_company",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscription_company",
                columns: table => new
                {
                    id_sub = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    value_sub = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    dt_start = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    dt_end = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    id_company = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription_company", x => x.id_sub);
                    table.ForeignKey(
                        name: "FK_Subscription_company_Company_id_company",
                        column: x => x.id_company,
                        principalTable: "Company",
                        principalColumn: "id_company",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    id_campaing = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_campaing = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    target = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dt_register = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    details = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    id_company = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    id_product = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.id_campaing);
                    table.ForeignKey(
                        name: "FK_Campaign_Company_id_company",
                        column: x => x.id_company,
                        principalTable: "Company",
                        principalColumn: "id_company",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Campaign_Product_id_product",
                        column: x => x.id_product,
                        principalTable: "Product",
                        principalColumn: "id_product",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pay_method",
                columns: table => new
                {
                    id_method = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_method = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    id_history = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    id_sub = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pay_method", x => x.id_method);
                    table.ForeignKey(
                        name: "FK_Pay_method_Pay_hist_id_history",
                        column: x => x.id_history,
                        principalTable: "Pay_hist",
                        principalColumn: "id_history",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pay_method_Subscription_company_id_sub",
                        column: x => x.id_sub,
                        principalTable: "Subscription_company",
                        principalColumn: "id_sub",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_id_company",
                table: "Campaign",
                column: "id_company");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_id_product",
                table: "Campaign",
                column: "id_product");

            migrationBuilder.CreateIndex(
                name: "IX_Pay_method_id_history",
                table: "Pay_method",
                column: "id_history");

            migrationBuilder.CreateIndex(
                name: "IX_Pay_method_id_sub",
                table: "Pay_method",
                column: "id_sub");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_user_id_company",
                table: "Profile_user",
                column: "id_company");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_company_id_company",
                table: "Subscription_company",
                column: "id_company");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "Pay_method");

            migrationBuilder.DropTable(
                name: "Profile_user");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Pay_hist");

            migrationBuilder.DropTable(
                name: "Subscription_company");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
