using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Курсовая_работа2.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnToAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "calldoctorwithoutauth",
                columns: table => new
                {
                    username = table.Column<string>(type: "character varying", nullable: false),
                    usersurname = table.Column<string>(type: "character varying", nullable: false),
                    userpatronymicname = table.Column<string>(type: "character varying", nullable: false),
                    userphone = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    useremail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    datebirth = table.Column<DateOnly>(type: "date", nullable: false),
                    gender = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    snils = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    useraddress = table.Column<string>(type: "character varying", nullable: false),
                    callreason = table.Column<string>(type: "character varying", nullable: false),
                    apponmentdate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    specialty = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    availabletime = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("doctors_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    username = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    usersurname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    userpatronymicname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    snils = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    phonenumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    userpassword = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    gender = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    birthdate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    doctorid = table.Column<int>(type: "integer", nullable: false),
                    appointmenttime = table.Column<DateOnly>(type: "date", nullable: false),
                    appointmenthour = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    appointmentstatus = table.Column<string>(type: "character varying", nullable: true),
                    AppointmentCancelButtonVisibility = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("appointments_pkey", x => x.id);
                    table.ForeignKey(
                        name: "appointments_doctorid_fkey",
                        column: x => x.doctorid,
                        principalTable: "doctors",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "appointments_userid_fkey",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "medicalrecords",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    doctorid = table.Column<int>(type: "integer", nullable: false),
                    appointmentid = table.Column<int>(type: "integer", nullable: false),
                    diagnosis = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("medicalrecords_pkey", x => x.id);
                    table.ForeignKey(
                        name: "medicalrecords_appointmentid_fkey",
                        column: x => x.appointmentid,
                        principalTable: "appointments",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "medicalrecords_doctorid_fkey",
                        column: x => x.doctorid,
                        principalTable: "doctors",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "medicalrecords_userid_fkey",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_appointments_doctorid",
                table: "appointments",
                column: "doctorid");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_userid",
                table: "appointments",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_medicalrecords_appointmentid",
                table: "medicalrecords",
                column: "appointmentid");

            migrationBuilder.CreateIndex(
                name: "IX_medicalrecords_doctorid",
                table: "medicalrecords",
                column: "doctorid");

            migrationBuilder.CreateIndex(
                name: "IX_medicalrecords_userid",
                table: "medicalrecords",
                column: "userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "calldoctorwithoutauth");

            migrationBuilder.DropTable(
                name: "medicalrecords");

            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
