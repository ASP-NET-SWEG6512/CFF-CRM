using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CFF_CRM.Migrations
{
    public partial class UpdateAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RelatedId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RelatedName",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskTypeId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PasswordResets",
                columns: table => new
                {
                    PasswordResetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ResetToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordResets", x => x.PasswordResetId);
                    table.ForeignKey(
                        name: "FK_PasswordResets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionGroupPolicies",
                columns: table => new
                {
                    PermissionGroupPolicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Page = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionGroupPolicies", x => x.PermissionGroupPolicyId);
                });

            migrationBuilder.CreateTable(
                name: "SupplyRequests",
                columns: table => new
                {
                    SupplyRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderItemId = table.Column<int>(type: "int", nullable: false),
                    SupplyRequestOriginId = table.Column<int>(type: "int", nullable: false),
                    SupplyRequestTypeId = table.Column<int>(type: "int", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyRequests", x => x.SupplyRequestId);
                    table.ForeignKey(
                        name: "FK_SupplyRequests_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "OrderItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplyRequests_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplyRequests_SupplyRequestOrigins_SupplyRequestOriginId",
                        column: x => x.SupplyRequestOriginId,
                        principalTable: "SupplyRequestOrigins",
                        principalColumn: "SupplyRequestOriginId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplyRequests_SupplyRequestTypes_SupplyRequestTypeId",
                        column: x => x.SupplyRequestTypeId,
                        principalTable: "SupplyRequestTypes",
                        principalColumn: "SupplyRequestTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplyRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplyRequestUpdates",
                columns: table => new
                {
                    SupplyRequestUpdateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyRequestUpdates", x => x.SupplyRequestUpdateId);
                    table.ForeignKey(
                        name: "FK_SupplyRequestUpdates_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskUpdates",
                columns: table => new
                {
                    TaskUpdateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskUpdates", x => x.TaskUpdateId);
                    table.ForeignKey(
                        name: "FK_TaskUpdates_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "Name" },
                values: new object[,]
                {
                    { 3, "Itemizations form" },
                    { 4, "Return envelopes" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "PermissionId", "Name" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "User" },
                    { 3, "Visitor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_PriorityId",
                table: "Tasks",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_RelatedId",
                table: "Tasks",
                column: "RelatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StatusId",
                table: "Tasks",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskTypeId",
                table: "Tasks",
                column: "TaskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskNotes_TaskId",
                table: "TaskNotes",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyRequestNotes_SupplyRequestId",
                table: "SupplyRequestNotes",
                column: "SupplyRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_TaskId",
                table: "Attachments",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordResets_UserId",
                table: "PasswordResets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyRequests_OrderItemId",
                table: "SupplyRequests",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyRequests_StatusId",
                table: "SupplyRequests",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyRequests_SupplyRequestOriginId",
                table: "SupplyRequests",
                column: "SupplyRequestOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyRequests_SupplyRequestTypeId",
                table: "SupplyRequests",
                column: "SupplyRequestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyRequests_UserId",
                table: "SupplyRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyRequestUpdates_TaskId",
                table: "SupplyRequestUpdates",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskUpdates_TaskId",
                table: "TaskUpdates",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Tasks_TaskId",
                table: "Attachments",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplyRequestNotes_SupplyRequests_SupplyRequestId",
                table: "SupplyRequestNotes",
                column: "SupplyRequestId",
                principalTable: "SupplyRequests",
                principalColumn: "SupplyRequestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskNotes_Tasks_TaskId",
                table: "TaskNotes",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Priorities_PriorityId",
                table: "Tasks",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "PriorityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Related_RelatedId",
                table: "Tasks",
                column: "RelatedId",
                principalTable: "Related",
                principalColumn: "RelatedId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Status_StatusId",
                table: "Tasks",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskTypes_TaskTypeId",
                table: "Tasks",
                column: "TaskTypeId",
                principalTable: "TaskTypes",
                principalColumn: "TaskTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Tasks_TaskId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplyRequestNotes_SupplyRequests_SupplyRequestId",
                table: "SupplyRequestNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskNotes_Tasks_TaskId",
                table: "TaskNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Priorities_PriorityId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Related_RelatedId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Status_StatusId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskTypes_TaskTypeId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_UserId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "PasswordResets");

            migrationBuilder.DropTable(
                name: "PermissionGroupPolicies");

            migrationBuilder.DropTable(
                name: "SupplyRequests");

            migrationBuilder.DropTable(
                name: "SupplyRequestUpdates");

            migrationBuilder.DropTable(
                name: "TaskUpdates");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_PriorityId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_RelatedId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_StatusId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TaskTypeId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_TaskNotes_TaskId",
                table: "TaskNotes");

            migrationBuilder.DropIndex(
                name: "IX_SupplyRequestNotes_SupplyRequestId",
                table: "SupplyRequestNotes");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_TaskId",
                table: "Attachments");

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "PermissionId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "RelatedId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "RelatedName",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskTypeId",
                table: "Tasks");
        }
    }
}
