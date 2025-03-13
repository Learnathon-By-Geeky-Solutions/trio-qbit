using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.src.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParameterWeights",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    ThinkingTimeWeight = table.Column<float>(type: "real", nullable: false),
                    LearningTimeWeight = table.Column<float>(type: "real", nullable: false),
                    IsCodeCopiedWeight = table.Column<float>(type: "real", nullable: false),
                    CodingTimeWeight = table.Column<float>(type: "real", nullable: false),
                    SubmissionAttemptsWeight = table.Column<float>(type: "real", nullable: false),
                    RevisionCountWeight = table.Column<float>(type: "real", nullable: false),
                    LastRevisionWeight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterWeights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProblemUrl = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ThinkingTime = table.Column<int>(type: "integer", nullable: false),
                    LearningTime = table.Column<int>(type: "integer", nullable: false),
                    IsCodeCopied = table.Column<bool>(type: "boolean", nullable: false),
                    CodingTime = table.Column<int>(type: "integer", nullable: false),
                    ProblemTags = table.Column<string>(type: "jsonb", nullable: false),
                    TagImpact = table.Column<float>(type: "real", nullable: true),
                    SubmissionAttempts = table.Column<int>(type: "integer", nullable: false),
                    RevisionCount = table.Column<int>(type: "integer", nullable: false),
                    LastRevision = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Priority = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagWeights",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TagName = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    TagWeight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagWeights", x => x.TagId);
                });

            migrationBuilder.InsertData(
                table: "ParameterWeights",
                columns: new[] { "Id", "CodingTimeWeight", "IsCodeCopiedWeight", "LastRevisionWeight", "LearningTimeWeight", "RevisionCountWeight", "SubmissionAttemptsWeight", "ThinkingTimeWeight", "UserId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), 0.15f, 0.8f, 0.15f, 0.2f, 0.05f, 0.1f, 0.2f, null });

            migrationBuilder.InsertData(
                table: "TagWeights",
                columns: new[] { "TagId", "TagName", "TagWeight", "UserId" },
                values: new object[,]
                {
                    { 1, "dynamic-programming", 0.7f, null },
                    { 2, "greedy", 0.6f, null },
                    { 3, "graph-theory", 0.65f, null },
                    { 4, "tree", 0.55f, null },
                    { 5, "binary-search", 0.5f, null },
                    { 6, "sorting", 0.45f, null },
                    { 7, "recursion-backtracking", 0.6f, null },
                    { 8, "divide-and-conquer", 0.55f, null },
                    { 9, "brute-force", 0.4f, null },
                    { 10, "number-theory", 0.6f, null },
                    { 11, "combinatorics", 0.55f, null },
                    { 12, "probability", 0.5f, null },
                    { 13, "game-theory", 0.6f, null },
                    { 14, "geometry", 0.55f, null },
                    { 15, "hash-table", 0.5f, null },
                    { 16, "heap-priority-queue", 0.55f, null },
                    { 17, "stack-queue", 0.45f, null },
                    { 18, "linked-list", 0.4f, null },
                    { 19, "trie-prefix-tree", 0.6f, null },
                    { 20, "segment-tree", 0.65f, null },
                    { 21, "fenwick-tree-bit", 0.6f, null },
                    { 22, "disjoint-set-union", 0.55f, null },
                    { 23, "graph-traversal-dfs-bfs", 0.55f, null },
                    { 24, "shortest-path-dijkstra-bellman-ford-floyd-warshall", 0.65f, null },
                    { 25, "minimum-spanning-tree-prims-kruskals", 0.6f, null },
                    { 26, "topological-sorting", 0.55f, null },
                    { 27, "strongly-connected-components-scc-tarjans-kosarajus", 0.65f, null },
                    { 28, "flow-algorithms-ford-fulkerson-dinics-edmonds-karp", 0.7f, null },
                    { 29, "string-matching-kmp-rabin-karp-z-algorithm-aho-corasick", 0.6f, null },
                    { 30, "suffix-array-suffix-tree", 0.65f, null },
                    { 31, "rolling-hashing", 0.55f, null },
                    { 32, "bit-manipulation", 0.5f, null },
                    { 33, "modular-arithmetic", 0.5f, null },
                    { 34, "two-pointers", 0.45f, null },
                    { 35, "sliding-window", 0.5f, null },
                    { 36, "meet-in-the-middle", 0.55f, null },
                    { 37, "trie-optimization", 0.6f, null },
                    { 38, "implementation", 0.4f, null },
                    { 39, "constructive-algorithm", 0.5f, null },
                    { 40, "interactive-problem", 0.55f, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParameterWeights_UserId",
                table: "ParameterWeights",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Solves_LastRevision",
                table: "Solves",
                column: "LastRevision");

            migrationBuilder.CreateIndex(
                name: "IX_Solves_Priority",
                table: "Solves",
                column: "Priority");

            migrationBuilder.CreateIndex(
                name: "IX_Solves_UserId",
                table: "Solves",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TagWeights_UserId",
                table: "TagWeights",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParameterWeights");

            migrationBuilder.DropTable(
                name: "Solves");

            migrationBuilder.DropTable(
                name: "TagWeights");
        }
    }
}
