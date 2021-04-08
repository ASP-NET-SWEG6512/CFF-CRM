using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CFF_CRM.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Archived = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NoteId);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                });

            migrationBuilder.CreateTable(
                name: "PermissionGroupPolicies",
                columns: table => new
                {
                    PermissionGroupPolicyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Page = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionGroupPolicies", x => x.PermissionGroupPolicyId);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    PermissionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermissionId);
                });

            migrationBuilder.CreateTable(
                name: "PhonePriorities",
                columns: table => new
                {
                    PhonePriorityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhonePriorities", x => x.PhonePriorityId);
                });

            migrationBuilder.CreateTable(
                name: "PhoneTypes",
                columns: table => new
                {
                    PhoneTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneTypes", x => x.PhoneTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Priorities",
                columns: table => new
                {
                    PriorityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priorities", x => x.PriorityId);
                });

            migrationBuilder.CreateTable(
                name: "Related",
                columns: table => new
                {
                    RelatedId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Related", x => x.RelatedId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "SupplyRequestOrigins",
                columns: table => new
                {
                    SupplyRequestOriginId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyRequestOrigins", x => x.SupplyRequestOriginId);
                });

            migrationBuilder.CreateTable(
                name: "SupplyRequestTypes",
                columns: table => new
                {
                    SupplyRequestTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyRequestTypes", x => x.SupplyRequestTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    TaskTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.TaskTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PermissionId = table.Column<int>(nullable: false),
                    SaltKey = table.Column<string>(nullable: true),
                    Timeout = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PasswordResets",
                columns: table => new
                {
                    PasswordResetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ResetToken = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: false)
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
                name: "PhoneNumbers",
                columns: table => new
                {
                    PhoneNumberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    PhoneTypeId = table.Column<int>(nullable: false),
                    PhonePriorityId = table.Column<int>(nullable: false),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.PhoneNumberId);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_PhonePriorities_PhonePriorityId",
                        column: x => x.PhonePriorityId,
                        principalTable: "PhonePriorities",
                        principalColumn: "PhonePriorityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_PhoneTypes_PhoneTypeId",
                        column: x => x.PhoneTypeId,
                        principalTable: "PhoneTypes",
                        principalColumn: "PhoneTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplyRequests",
                columns: table => new
                {
                    SupplyRequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    OrderItemId = table.Column<int>(nullable: false),
                    SupplyRequestOriginId = table.Column<int>(nullable: false),
                    SupplyRequestTypeId = table.Column<int>(nullable: false),
                    ClientName = table.Column<string>(nullable: true),
                    OwnerName = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
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
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Owner = table.Column<string>(nullable: true),
                    RelatedId = table.Column<int>(nullable: false),
                    RelatedName = table.Column<string>(nullable: true),
                    TaskTypeId = table.Column<int>(nullable: false),
                    PriorityId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_Priorities_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priorities",
                        principalColumn: "PriorityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Related_RelatedId",
                        column: x => x.RelatedId,
                        principalTable: "Related",
                        principalColumn: "RelatedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskTypes_TaskTypeId",
                        column: x => x.TaskTypeId,
                        principalTable: "TaskTypes",
                        principalColumn: "TaskTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplyRequestNotes",
                columns: table => new
                {
                    SupplyRequestNoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplyRequestId = table.Column<int>(nullable: false),
                    NoteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyRequestNotes", x => x.SupplyRequestNoteId);
                    table.ForeignKey(
                        name: "FK_SupplyRequestNotes_SupplyRequests_SupplyRequestId",
                        column: x => x.SupplyRequestId,
                        principalTable: "SupplyRequests",
                        principalColumn: "SupplyRequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    AttachmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(nullable: false),
                    Link = table.Column<string>(nullable: true),
                    UploadDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.AttachmentId);
                    table.ForeignKey(
                        name: "FK_Attachments_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplyRequestUpdates",
                columns: table => new
                {
                    SupplyRequestUpdateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false)
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
                name: "TaskNotes",
                columns: table => new
                {
                    TaskNoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(nullable: false),
                    NoteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskNotes", x => x.TaskNoteId);
                    table.ForeignKey(
                        name: "FK_TaskNotes_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskUpdates",
                columns: table => new
                {
                    TaskUpdateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<int>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false)
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
                    { 1, "Preneed agreement" },
                    { 2, "Account update/Claim form" },
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
                name: "IX_Attachments_TaskId",
                table: "Attachments",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordResets_UserId",
                table: "PasswordResets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_PhonePriorityId",
                table: "PhoneNumbers",
                column: "PhonePriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_PhoneTypeId",
                table: "PhoneNumbers",
                column: "PhoneTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_UserId",
                table: "PhoneNumbers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyRequestNotes_SupplyRequestId",
                table: "SupplyRequestNotes",
                column: "SupplyRequestId");

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
                name: "IX_TaskNotes_TaskId",
                table: "TaskNotes",
                column: "TaskId");

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
                name: "IX_TaskUpdates_TaskId",
                table: "TaskUpdates",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PermissionId",
                table: "Users",
                column: "PermissionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "PasswordResets");

            migrationBuilder.DropTable(
                name: "PermissionGroupPolicies");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "SupplyRequestNotes");

            migrationBuilder.DropTable(
                name: "SupplyRequestUpdates");

            migrationBuilder.DropTable(
                name: "TaskNotes");

            migrationBuilder.DropTable(
                name: "TaskUpdates");

            migrationBuilder.DropTable(
                name: "PhonePriorities");

            migrationBuilder.DropTable(
                name: "PhoneTypes");

            migrationBuilder.DropTable(
                name: "SupplyRequests");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "SupplyRequestOrigins");

            migrationBuilder.DropTable(
                name: "SupplyRequestTypes");

            migrationBuilder.DropTable(
                name: "Priorities");

            migrationBuilder.DropTable(
                name: "Related");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "TaskTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Permissions");
        }
    }
}
