using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Absolute_Cinema_Backend.Models;

public partial class AbsoluteCinemaDbContext : DbContext
{
    public AbsoluteCinemaDbContext()
    {
    }

    public AbsoluteCinemaDbContext(DbContextOptions<AbsoluteCinemaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Hall> Halls { get; set; }

    public virtual DbSet<HallZone> HallZones { get; set; }

    public virtual DbSet<HallZonePrice> HallZonePrices { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Resolution> Resolutions { get; set; }

    public virtual DbSet<Seat> Seats { get; set; }

    public virtual DbSet<SeatReservation> SeatReservations { get; set; }

    public virtual DbSet<SeatSelectionSession> SeatSelectionSessions { get; set; }

    public virtual DbSet<SessionType> SessionTypes { get; set; }

    public virtual DbSet<Showtime> Showtimes { get; set; }

    public virtual DbSet<Subtitle> Subtitles { get; set; }

    public virtual DbSet<Theatre> Theatres { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("actor_pkey");

            entity.ToTable("actor");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.FullName).HasColumnName("full_name");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("genre_pkey");

            entity.ToTable("genre");

            entity.HasIndex(e => e.Title, "genre_title_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        modelBuilder.Entity<Hall>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hall_pkey");

            entity.ToTable("hall");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ColsCount).HasColumnName("cols_count");
            entity.Property(e => e.RowsCount).HasColumnName("rows_count");
            entity.Property(e => e.TheatreId).HasColumnName("theatre_id");
            entity.Property(e => e.Title).HasColumnName("title");

            entity.HasOne(d => d.Theatre).WithMany(p => p.Halls)
                .HasForeignKey(d => d.TheatreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hall_theatre_id_fkey");
        });

        modelBuilder.Entity<HallZone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("hall_zone_pkey");

            entity.ToTable("hall_zone");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.HallId).HasColumnName("hall_id");
            entity.Property(e => e.Title).HasColumnName("title");

            entity.HasOne(d => d.Hall).WithMany(p => p.HallZones)
                .HasForeignKey(d => d.HallId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hall_zone_hall_id_fkey");
        });

        modelBuilder.Entity<HallZonePrice>(entity =>
        {
            entity.HasKey(e => new { e.ShowtimeId, e.HallZoneId }).HasName("hall_zone_price_pkey");

            entity.ToTable("hall_zone_price");

            entity.Property(e => e.ShowtimeId).HasColumnName("showtime_id");
            entity.Property(e => e.HallZoneId).HasColumnName("hall_zone_id");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");

            entity.HasOne(d => d.HallZone).WithMany(p => p.HallZonePrices)
                .HasForeignKey(d => d.HallZoneId)
                .HasConstraintName("hall_zone_price_hall_zone_id_fkey");

            entity.HasOne(d => d.Showtime).WithMany(p => p.HallZonePrices)
                .HasForeignKey(d => d.ShowtimeId)
                .HasConstraintName("hall_zone_price_showtime_id_fkey");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("languages_pkey");

            entity.ToTable("languages");

            entity.HasIndex(e => e.Code, "languages_code_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("movie_pkey");

            entity.ToTable("movie");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Director).HasColumnName("director");
            entity.Property(e => e.DurationMinutes).HasColumnName("duration_minutes");
            entity.Property(e => e.PosterUrl).HasColumnName("poster_url");
            entity.Property(e => e.RatingId).HasColumnName("rating_id");
            entity.Property(e => e.ReleaseDate).HasColumnName("release_date");
            entity.Property(e => e.Title).HasColumnName("title");

            entity.HasOne(d => d.Rating).WithMany(p => p.Movies)
                .HasForeignKey(d => d.RatingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("movie_rating_id_fkey");

            entity.HasMany(d => d.Actors).WithMany(p => p.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieActor",
                    r => r.HasOne<Actor>().WithMany()
                        .HasForeignKey("ActorId")
                        .HasConstraintName("movie_actor_actor_id_fkey"),
                    l => l.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .HasConstraintName("movie_actor_movie_id_fkey"),
                    j =>
                    {
                        j.HasKey("MovieId", "ActorId").HasName("movie_actor_pkey");
                        j.ToTable("movie_actor");
                        j.IndexerProperty<int>("MovieId").HasColumnName("movie_id");
                        j.IndexerProperty<int>("ActorId").HasColumnName("actor_id");
                    });

            entity.HasMany(d => d.Genres).WithMany(p => p.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "MovieGenre",
                    r => r.HasOne<Genre>().WithMany()
                        .HasForeignKey("GenreId")
                        .HasConstraintName("movie_genre_genre_id_fkey"),
                    l => l.HasOne<Movie>().WithMany()
                        .HasForeignKey("MovieId")
                        .HasConstraintName("movie_genre_movie_id_fkey"),
                    j =>
                    {
                        j.HasKey("MovieId", "GenreId").HasName("movie_genre_pkey");
                        j.ToTable("movie_genre");
                        j.IndexerProperty<int>("MovieId").HasColumnName("movie_id");
                        j.IndexerProperty<int>("GenreId").HasColumnName("genre_id");
                    });
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rating_pkey");

            entity.ToTable("rating");

            entity.HasIndex(e => e.Code, "rating_code_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.MinAge).HasColumnName("min_age");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        modelBuilder.Entity<Resolution>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("resolution_pkey");

            entity.ToTable("resolution");

            entity.HasIndex(e => e.Title, "resolution_title_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        modelBuilder.Entity<Seat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("seat_pkey");

            entity.ToTable("seat");

            entity.HasIndex(e => new { e.HallZoneId, e.SRowNumber, e.SeatNumber }, "uq_seat").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.HallZoneId).HasColumnName("hall_zone_id");
            entity.Property(e => e.SRowNumber).HasColumnName("s_row_number");
            entity.Property(e => e.SeatNumber).HasColumnName("seat_number");

            entity.HasOne(d => d.HallZone).WithMany(p => p.Seats)
                .HasForeignKey(d => d.HallZoneId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("seat_hall_zone_id_fkey");
        });

        modelBuilder.Entity<SeatReservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("seat_reservation_pkey");

            entity.ToTable("seat_reservation");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.SeatId).HasColumnName("seat_id");
            entity.Property(e => e.SeatSelectionSessionId).HasColumnName("seat_selection_session_id");
            entity.Property(e => e.ShowtimeId).HasColumnName("showtime_id");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Seat).WithMany(p => p.SeatReservations)
                .HasForeignKey(d => d.SeatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("seat_reservation_seat_id_fkey");

            entity.HasOne(d => d.SeatSelectionSession).WithMany(p => p.SeatReservations)
                .HasForeignKey(d => d.SeatSelectionSessionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("seat_reservation_seat_selection_session_id_fkey");

            entity.HasOne(d => d.Showtime).WithMany(p => p.SeatReservations)
                .HasForeignKey(d => d.ShowtimeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("seat_reservation_showtime_id_fkey");
        });

        modelBuilder.Entity<SeatSelectionSession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("seat_selection_session_pkey");

            entity.ToTable("seat_selection_session");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ExpiresAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("expires_at");
            entity.Property(e => e.ReservedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("reserved_at");
            entity.Property(e => e.ShowtimeId).HasColumnName("showtime_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Showtime).WithMany(p => p.SeatSelectionSessions)
                .HasForeignKey(d => d.ShowtimeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("seat_selection_session_showtime_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.SeatSelectionSessions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("seat_selection_session_user_id_fkey");
        });

        modelBuilder.Entity<SessionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("session_type_pkey");

            entity.ToTable("session_type");

            entity.HasIndex(e => e.Title, "session_type_title_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        modelBuilder.Entity<Showtime>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("showtime_pkey");

            entity.ToTable("showtime");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.HallId).HasColumnName("hall_id");
            entity.Property(e => e.LanguageId).HasColumnName("language_id");
            entity.Property(e => e.MinPrice)
                .HasPrecision(10, 2)
                .HasColumnName("min_price");
            entity.Property(e => e.MovieId).HasColumnName("movie_id");
            entity.Property(e => e.ResolutionId).HasColumnName("resolution_id");
            entity.Property(e => e.SessionTypeId).HasColumnName("session_type_id");
            entity.Property(e => e.StartDateTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_date_time");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.SubtitleId).HasColumnName("subtitle_id");

            entity.HasOne(d => d.Hall).WithMany(p => p.Showtimes)
                .HasForeignKey(d => d.HallId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("showtime_hall_id_fkey");

            entity.HasOne(d => d.Language).WithMany(p => p.Showtimes)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("showtime_language_id_fkey");

            entity.HasOne(d => d.Movie).WithMany(p => p.Showtimes)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("showtime_movie_id_fkey");

            entity.HasOne(d => d.Resolution).WithMany(p => p.Showtimes)
                .HasForeignKey(d => d.ResolutionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("showtime_resolution_id_fkey");

            entity.HasOne(d => d.SessionType).WithMany(p => p.Showtimes)
                .HasForeignKey(d => d.SessionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("showtime_session_type_id_fkey");

            entity.HasOne(d => d.Subtitle).WithMany(p => p.Showtimes)
                .HasForeignKey(d => d.SubtitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("showtime_subtitle_id_fkey");
        });

        modelBuilder.Entity<Subtitle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("subtitle_pkey");

            entity.ToTable("subtitle");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.LanguageId).HasColumnName("language_id");

            entity.HasOne(d => d.Language).WithMany(p => p.Subtitles)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("subtitle_language_id_fkey");
        });

        modelBuilder.Entity<Theatre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("theatre_pkey");

            entity.ToTable("theatre");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.City).HasColumnName("city");
            entity.Property(e => e.LogoUrl).HasColumnName("logo_url");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ticket_pkey");

            entity.ToTable("ticket");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.PriceAtPurchase)
                .HasPrecision(10, 2)
                .HasColumnName("price_at_purchase");
            entity.Property(e => e.SeatReservationId).HasColumnName("seat_reservation_id");
            entity.Property(e => e.ShowtimeId).HasColumnName("showtime_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.SeatReservation).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.SeatReservationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ticket_seat_reservation_id_fkey");

            entity.HasOne(d => d.Showtime).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ShowtimeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ticket_showtime_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ticket_user_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
