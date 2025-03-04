using System.Text.Json;
using backend.src.Modules.SolveReview.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.src.Modules.SolveReview.Infrastructure.Persistence
{
    public class SolveReviewDbContext : DbContext  
    {
        public SolveReviewDbContext(DbContextOptions<SolveReviewDbContext> options)
            : base(options)
        {
        }

        public DbSet<Solve> Solves { get; set; }
        public DbSet<ParameterWeights> ParameterWeights { get; set; }
        public DbSet<TagWeights> TagWeights { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring solve entity
            modelBuilder.Entity<Solve>(entity => {
                
                // primary key 
                entity.HasKey(s => s.Id);

                // property is required and parsed in json format
                entity.Property(s => s.ProblemTags)
                      .HasColumnType("jsonb")
                      .HasConversion(
                        // for converting System.string[] to JSON and vice-versa
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                        v => JsonSerializer.Deserialize<string[]>(v, (JsonSerializerOptions)null)
                      ).IsRequired();

                // foreign key 
                entity.Property(s => s.UserId)
                      .IsRequired();
                
                // creating index query optimization while filtering and sorting
                entity.HasIndex(s => s.UserId);
                entity.HasIndex(s => s.LastRevision);
                entity.HasIndex(s => s.Priority);


            });

            // configuring ParameterWeights entity
            modelBuilder.Entity<ParameterWeights>(entity =>
                {
                    // primary key
                    entity.HasKey(pw => pw.Id);

                    // Unique constraint on UserId to ensure one set of weights per user (or null for global)
                    entity.HasIndex(pw => pw.UserId)
                        .IsUnique();

                    entity.Property(pw => pw.UserId)
                        .IsRequired(false); // Nullable for global weights


                    entity.HasData(
                    new ParameterWeights
                    {
                        Id = new Guid("00000000-0000-0000-0000-000000000001"),
                        UserId = null, // Global weights
                        ThinkingTimeWeight = 0.2f,
                        LearningTimeWeight = 0.2f,
                        IsCodeCopiedWeight = 0.8f,
                        CodingTimeWeight = 0.15f,
                        SubmissionAttemptsWeight = 0.1f,
                        RevisionCountWeight = 0.05f,
                        LastRevisionWeight = 0.15f
                    }
                    );

                });


            // Configuring TagWeights entity
            modelBuilder.Entity<TagWeights>(entity =>
            {
                // primary key
                entity.HasKey( tw => tw.TagId);

                entity.Property(tw => tw.UserId)
                      .IsRequired(false); // Nullable for global tag weights

                entity.HasIndex(tw => tw.UserId);

                // Seed example global tag weights (optional)
                entity.HasData(
                    // Core Algorithmic Tags
                    new TagWeights { TagId = 1, UserId = null, TagName = "dynamic-programming", TagWeight = 0.7f },
                    new TagWeights { TagId = 2, UserId = null, TagName = "greedy", TagWeight = 0.6f },
                    new TagWeights { TagId = 3, UserId = null, TagName = "graph-theory", TagWeight = 0.65f },
                    new TagWeights { TagId = 4, UserId = null, TagName = "tree", TagWeight = 0.55f },
                    new TagWeights { TagId = 5, UserId = null, TagName = "binary-search", TagWeight = 0.5f },
                    new TagWeights { TagId = 6, UserId = null, TagName = "sorting", TagWeight = 0.45f },
                    new TagWeights { TagId = 7, UserId = null, TagName = "recursion-backtracking", TagWeight = 0.6f },
                    new TagWeights { TagId = 8, UserId = null, TagName = "divide-and-conquer", TagWeight = 0.55f },
                    new TagWeights { TagId = 9, UserId = null, TagName = "brute-force", TagWeight = 0.4f },

                    // Mathematical Tags
                    new TagWeights { TagId = 10, UserId = null, TagName = "number-theory", TagWeight = 0.6f },
                    new TagWeights { TagId = 11, UserId = null, TagName = "combinatorics", TagWeight = 0.55f },
                    new TagWeights { TagId = 12, UserId = null, TagName = "probability", TagWeight = 0.5f },
                    new TagWeights { TagId = 13, UserId = null, TagName = "game-theory", TagWeight = 0.6f },
                    new TagWeights { TagId = 14, UserId = null, TagName = "geometry", TagWeight = 0.55f },

                    // Data Structures Tags
                    new TagWeights { TagId = 15, UserId = null, TagName = "hash-table", TagWeight = 0.5f },
                    new TagWeights { TagId = 16, UserId = null, TagName = "heap-priority-queue", TagWeight = 0.55f },
                    new TagWeights { TagId = 17, UserId = null, TagName = "stack-queue", TagWeight = 0.45f },
                    new TagWeights { TagId = 18, UserId = null, TagName = "linked-list", TagWeight = 0.4f },
                    new TagWeights { TagId = 19, UserId = null, TagName = "trie-prefix-tree", TagWeight = 0.6f },
                    new TagWeights { TagId = 20, UserId = null, TagName = "segment-tree", TagWeight = 0.65f },
                    new TagWeights { TagId = 21, UserId = null, TagName = "fenwick-tree-bit", TagWeight = 0.6f },
                    new TagWeights { TagId = 22, UserId = null, TagName = "disjoint-set-union", TagWeight = 0.55f },

                    // Graph-Specific Tags
                    new TagWeights { TagId = 23, UserId = null, TagName = "graph-traversal-dfs-bfs", TagWeight = 0.55f },
                    new TagWeights { TagId = 24, UserId = null, TagName = "shortest-path-dijkstra-bellman-ford-floyd-warshall", TagWeight = 0.65f },
                    new TagWeights { TagId = 25, UserId = null, TagName = "minimum-spanning-tree-prims-kruskals", TagWeight = 0.6f },
                    new TagWeights { TagId = 26, UserId = null, TagName = "topological-sorting", TagWeight = 0.55f },
                    new TagWeights { TagId = 27, UserId = null, TagName = "strongly-connected-components-scc-tarjans-kosarajus", TagWeight = 0.65f },
                    new TagWeights { TagId = 28, UserId = null, TagName = "flow-algorithms-ford-fulkerson-dinics-edmonds-karp", TagWeight = 0.7f },

                    // String Processing Tags
                    new TagWeights { TagId = 29, UserId = null, TagName = "string-matching-kmp-rabin-karp-z-algorithm-aho-corasick", TagWeight = 0.6f },
                    new TagWeights { TagId = 30, UserId = null, TagName = "suffix-array-suffix-tree", TagWeight = 0.65f },
                    new TagWeights { TagId = 31, UserId = null, TagName = "rolling-hashing", TagWeight = 0.55f },

                    // Miscellaneous Tags
                    new TagWeights { TagId = 32, UserId = null, TagName = "bit-manipulation", TagWeight = 0.5f },
                    new TagWeights { TagId = 33, UserId = null, TagName = "modular-arithmetic", TagWeight = 0.5f },
                    new TagWeights { TagId = 34, UserId = null, TagName = "two-pointers", TagWeight = 0.45f },
                    new TagWeights { TagId = 35, UserId = null, TagName = "sliding-window", TagWeight = 0.5f },
                    new TagWeights { TagId = 36, UserId = null, TagName = "meet-in-the-middle", TagWeight = 0.55f },
                    new TagWeights { TagId = 37, UserId = null, TagName = "trie-optimization", TagWeight = 0.6f },

                    // Problem-Specific Tags
                    new TagWeights { TagId = 38, UserId = null, TagName = "implementation", TagWeight = 0.4f },
                    new TagWeights { TagId = 39, UserId = null, TagName = "constructive-algorithm", TagWeight = 0.5f },
                    new TagWeights { TagId = 40, UserId = null, TagName = "interactive-problem", TagWeight = 0.55f }
                );
            });



            
            
        }
    }
}