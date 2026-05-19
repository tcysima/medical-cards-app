using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedicalCardsWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Specialty = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ScheduledDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false),
                    DoctorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Diagnosis = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Treatment = table.Column<string>(type: "TEXT", nullable: true),
                    RecordDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PatientId = table.Column<int>(type: "INTEGER", nullable: false),
                    DoctorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "FullName", "Phone", "Specialty" },
                values: new object[,]
                {
                    { 1, "Докторов Иван Петрович", "+79001111111", "Терапевт" },
                    { 2, "Медведева Анна Сергеевна", "+79002222222", "Кардиолог" },
                    { 3, "Хирургов Алексей Михайлович", "+79003333333", "Хирург" },
                    { 4, "Невролова Елена Владимировна", "+79004444444", "Невролог" },
                    { 5, "Педиатров Дмитрий Олегович", "+79005555555", "Педиатр" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "DateOfBirth", "Email", "FullName", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(1985, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ivanov@test.ru", "Иванов Иван Петрович", "+79001234567" },
                    { 2, new DateTime(1990, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "petrova@test.ru", "Петрова Анна Сергеевна", "+79001234568" },
                    { 3, new DateTime(1978, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "sidorov@test.ru", "Сидоров Алексей Михайлович", "+79001234569" },
                    { 4, new DateTime(1995, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "kozlova@test.ru", "Козлова Елена Владимировна", "+79001234570" },
                    { 5, new DateTime(1982, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "morozov@test.ru", "Морозов Дмитрий Олегович", "+79001234571" },
                    { 6, new DateTime(1988, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "novikova@test.ru", "Новикова Мария Игоревна", "+79001234572" },
                    { 7, new DateTime(1975, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "volkov@test.ru", "Волков Сергей Андреевич", "+79001234573" },
                    { 8, new DateTime(1992, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "lebedeva@test.ru", "Лебедева Ольга Павловна", "+79001234574" },
                    { 9, new DateTime(1980, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "sokolov@test.ru", "Соколов Николай Викторович", "+79001234575" },
                    { 10, new DateTime(1987, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "pavlova@test.ru", "Павлова Татьяна Дмитриевна", "+79001234576" },
                    { 11, new DateTime(1993, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "semenov@test.ru", "Семенов Андрей Евгеньевич", "+79001234577" },
                    { 12, new DateTime(1979, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "fedorova@test.ru", "Федорова Ирина Николаевна", "+79001234578" },
                    { 13, new DateTime(1986, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "kuznetsov@test.ru", "Кузнецов Михаил Сергеевич", "+79001234579" },
                    { 14, new DateTime(1991, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "popova@test.ru", "Попова Светлана Александровна", "+79001234580" },
                    { 15, new DateTime(1984, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "vasiliev@test.ru", "Васильев Павел Иванович", "+79001234581" },
                    { 16, new DateTime(1996, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "smirnova@test.ru", "Смирнова Анна Петровна", "+79001234582" },
                    { 17, new DateTime(1977, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "konov@test.ru", "Конов Игорь Владимирович", "+79001234583" },
                    { 18, new DateTime(1989, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "mikhailova@test.ru", "Михайлова Екатерина Сергеевна", "+79001234584" },
                    { 19, new DateTime(1983, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "alexandrov@test.ru", "Александров Дмитрий Павлович", "+79001234585" },
                    { 20, new DateTime(1994, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "borisova@test.ru", "Борисова Наталья Игоревна", "+79001234586" },
                    { 21, new DateTime(1981, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "grigoriev@test.ru", "Григорьев Сергей Михайлович", "+79001234587" },
                    { 22, new DateTime(1990, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "egorova@test.ru", "Егорова Ольга Александровна", "+79001234588" },
                    { 23, new DateTime(1976, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "zaytsev@test.ru", "Зайцев Андрей Дмитриевич", "+79001234589" },
                    { 24, new DateTime(1992, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "ivanova.m@test.ru", "Иванова Мария Сергеевна", "+79001234590" },
                    { 25, new DateTime(1985, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "kozlov.p@test.ru", "Козлов Павел Николаевич", "+79001234591" },
                    { 26, new DateTime(1988, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lebedev.i@test.ru", "Лебедев Игорь Владимирович", "+79001234592" },
                    { 27, new DateTime(1993, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "makarova@test.ru", "Макарова Татьяна Петровна", "+79001234593" },
                    { 28, new DateTime(1979, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "nikolaev@test.ru", "Николаев Алексей Сергеевич", "+79001234594" },
                    { 29, new DateTime(1991, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "orlova@test.ru", "Орлова Светлана Дмитриевна", "+79001234595" },
                    { 30, new DateTime(1984, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "romanov@test.ru", "Романов Михаил Павлович", "+79001234596" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "DoctorId", "PatientId", "ScheduledDate", "Status" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2026, 5, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), "Запланирован" },
                    { 2, 2, 2, new DateTime(2026, 5, 16, 11, 30, 0, 0, DateTimeKind.Unspecified), "Запланирован" },
                    { 3, 3, 3, new DateTime(2026, 5, 17, 14, 0, 0, 0, DateTimeKind.Unspecified), "Завершён" },
                    { 4, 4, 4, new DateTime(2026, 5, 18, 9, 0, 0, 0, DateTimeKind.Unspecified), "Запланирован" },
                    { 5, 1, 5, new DateTime(2026, 5, 19, 15, 30, 0, 0, DateTimeKind.Unspecified), "Завершён" }
                });

            migrationBuilder.InsertData(
                table: "MedicalRecords",
                columns: new[] { "Id", "Description", "Diagnosis", "DoctorId", "PatientId", "RecordDate", "Treatment" },
                values: new object[,]
                {
                    { 1, "Острая респираторная вирусная инфекция. Назначено симптоматическое лечение.", "ОРВИ", 1, 1, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, "Артериальная гипертензия 2 степени. Рекомендована диета и медикаментозная терапия.", "Гипертония", 2, 2, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, "Острый аппендицит. Проведена аппендэктомия.", "Аппендицит", 3, 3, new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, "Хроническая мигрень. Назначены профилактические препараты.", "Мигрень", 4, 4, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, "Хронический гастрит. Рекомендована диета стол №5.", "Гастрит", 1, 5, new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, "Острый бронхит у ребенка. Назначены ингаляции.", "Бронхит", 5, 6, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, "Нарушение сердечного ритма. Проведено обследование.", "Аритмия", 2, 7, new DateTime(2025, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 8, "Острый тонзиллит. Назначены антибиотики.", "Ангина", 1, 8, new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 9, "Остеохондроз поясничного отдела. Рекомендована ЛФК.", "Остеохондроз", 4, 9, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 10, "Паховая грыжа. Запланирована операция.", "Грыжа", 3, 10, new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ScheduledDate",
                table: "Appointments",
                column: "ScheduledDate");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Specialty",
                table: "Doctors",
                column: "Specialty");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_Diagnosis",
                table: "MedicalRecords",
                column: "Diagnosis");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_DoctorId",
                table: "MedicalRecords",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_PatientId",
                table: "MedicalRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Email",
                table: "Patients",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Phone",
                table: "Patients",
                column: "Phone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
