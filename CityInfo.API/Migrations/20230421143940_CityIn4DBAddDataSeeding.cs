using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CityInfo.API.Migrations
{
    /// <inheritdoc />
    public partial class CityIn4DBAddDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "The one with that big park", "New York" },
                    { 2, "The one with the cathedral that was never really finished", "Antwerp" },
                    { 3, "The only city inside rift valley", "Nakuru" },
                    { 4, "The city for cargo flight in Kenya and Uganda.", "Eldoret" }
                });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, "The most visited urban park in United States.", "Central Park" },
                    { 2, 1, "The 102-story skyscraper located in mid-town Manhattan.", "Empire State Building" },
                    { 3, 2, "The world's largest museum.", "The Louvre" },
                    { 4, 2, "The wrought iron lattice tower on champ de mars.", "Eiffel Tower" },
                    { 5, 3, "A soda lake, in the Great Rift Valley, about 120 km northwest of Nairobi, Kenya.", "Lake Elmenteita" },
                    { 6, 3, "On the floor of the Great Rift Valley, surrounded by wooded and bushy grassland", "Lake Nakuru National Park" },
                    { 7, 4, "Cargo flight landing zone in Kenya", "Eldoret International Airport" },
                    { 8, 4, "west of the Great Rift Valley (in the East African Rift System.", "Uasin Gishu Plateau." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
