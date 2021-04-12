using Microsoft.EntityFrameworkCore.Migrations;

namespace CFF_CRM.Migrations
{
    public partial class AddedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "Name" },
                values: new object[,]
                {
                    { 5, "Postage paid envelopes" },
                    { 6, "Deposit tickets" },
                    { 7, "Planning guides" },
                    { 8, "Funding your funeral in advance brochure" },
                    { 9, "Monthly monitors" },
                    { 10, "Service and merchandise forms" },
                    { 11, "Investment election form" },
                    { 12, "Other" }
                });

            migrationBuilder.InsertData(
                table: "PhoneTypes",
                columns: new[] { "PhoneTypeId", "Name" },
                values: new object[,]
                {
                    { 4, "Other" },
                    { 3, "Work" },
                    { 1, "Home" },
                    { 2, "Mobile" }
                });

            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "PriorityId", "Name" },
                values: new object[,]
                {
                    { 1, "High" },
                    { 2, "Medium" },
                    { 3, "Low" }
                });

            migrationBuilder.InsertData(
                table: "Related",
                columns: new[] { "RelatedId", "Name" },
                values: new object[,]
                {
                    { 5, "Other" },
                    { 4, "In-house" },
                    { 3, "Lead" },
                    { 2, "Potential customer" },
                    { 1, "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusId", "Color", "Name" },
                values: new object[,]
                {
                    { 1, "#0d47a1", "New" },
                    { 2, "#1a237e", "In-Process" },
                    { 3, "#10A037", "Completed" },
                    { 4, "#ED9E1E", "On Hold" },
                    { 5, "#DE1313", "Cancelled" }
                });

            migrationBuilder.InsertData(
                table: "SupplyRequestOrigins",
                columns: new[] { "SupplyRequestOriginId", "Name" },
                values: new object[,]
                {
                    { 6, "Other" },
                    { 5, "Reginal Manager" },
                    { 4, "Mail" },
                    { 2, "Fax" },
                    { 1, "Phone" },
                    { 3, "Email" }
                });

            migrationBuilder.InsertData(
                table: "SupplyRequestTypes",
                columns: new[] { "SupplyRequestTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Vendor" },
                    { 2, "Client" }
                });

            migrationBuilder.InsertData(
                table: "TaskTypes",
                columns: new[] { "TaskTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Reminder call" },
                    { 2, "Follow-up" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PhoneTypes",
                keyColumn: "PhoneTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PhoneTypes",
                keyColumn: "PhoneTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PhoneTypes",
                keyColumn: "PhoneTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PhoneTypes",
                keyColumn: "PhoneTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "PriorityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "PriorityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "PriorityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Related",
                keyColumn: "RelatedId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Related",
                keyColumn: "RelatedId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Related",
                keyColumn: "RelatedId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Related",
                keyColumn: "RelatedId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Related",
                keyColumn: "RelatedId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "StatusId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SupplyRequestOrigins",
                keyColumn: "SupplyRequestOriginId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SupplyRequestOrigins",
                keyColumn: "SupplyRequestOriginId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SupplyRequestOrigins",
                keyColumn: "SupplyRequestOriginId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SupplyRequestOrigins",
                keyColumn: "SupplyRequestOriginId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SupplyRequestOrigins",
                keyColumn: "SupplyRequestOriginId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SupplyRequestOrigins",
                keyColumn: "SupplyRequestOriginId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SupplyRequestTypes",
                keyColumn: "SupplyRequestTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SupplyRequestTypes",
                keyColumn: "SupplyRequestTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskTypes",
                keyColumn: "TaskTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TaskTypes",
                keyColumn: "TaskTypeId",
                keyValue: 2);
        }
    }
}
