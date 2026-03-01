using Absolute_Cinema_Backend.Models;

namespace Absolute_Cinema_Backend.MockDatabase
{
    public static class MockDatabase
    {
        // =========================
        // THEATRES
        // =========================
        public static List<Theatre> Theatres = new()
        {
            new Theatre { Id = 1, Title = "Amirani", LogoUrl = "amirani.png", City = "Tbilisi", Address = "Rustaveli Ave 1" },
            new Theatre { Id = 2, Title = "Cavea City Mall", LogoUrl = "cavea.png", City = "Tbilisi", Address = "Saburtalo City Mall" },
            new Theatre { Id = 3, Title = "IMAX Tbilisi", LogoUrl = "imax.png", City = "Tbilisi", Address = "Kazbegi Ave 12" }
        };

        // =========================
        // RATINGS
        // =========================
        public static List<Rating> Ratings = new()
        {
            new Rating { Id = 1, Code = "G", Title = "General Audiences", MinAge = 0 },
            new Rating { Id = 2, Code = "PG", Title = "Parental Guidance", MinAge = 10 },
            new Rating { Id = 3, Code = "PG-13", Title = "Parents Strongly Cautioned", MinAge = 13 },
            new Rating { Id = 4, Code = "R", Title = "Restricted", MinAge = 17 }
        };

        // =========================
        // LANGUAGES
        // =========================
        public static List<Language> Languages = new()
        {
            new Language { Id = 1, Code = "en", Title = "English" },
            new Language { Id = 2, Code = "ka", Title = "Georgian" },
            new Language { Id = 3, Code = "ru", Title = "Russian" }
        };

        // =========================
        // SUBTITLES (subtitle language)
        // =========================
        public static List<Subtitle> Subtitles = new()
        {
            new Subtitle { Id = 1, LanguageId = 2 }, // Georgian subtitles
            new Subtitle { Id = 2, LanguageId = 1 }, // English subtitles
            new Subtitle { Id = 3, LanguageId = 3 }  // Russian subtitles
        };

        // =========================
        // RESOLUTIONS
        // =========================
        public static List<Resolution> Resolutions = new()
        {
            new Resolution { Id = 1, Title = "2D" },
            new Resolution { Id = 2, Title = "3D" },
            new Resolution { Id = 3, Title = "IMAX" }
        };

        // =========================
        // SESSION TYPES
        // =========================
        public static List<SessionType> SessionTypes = new()
        {
            new SessionType { Id = 1, Title = "Morning" },
            new SessionType { Id = 2, Title = "Day" },
            new SessionType { Id = 3, Title = "Evening" },
            new SessionType { Id = 4, Title = "Night" }
        };

        // =========================
        // GENRES
        // =========================
        public static List<Genre> Genres = new()
        {
            new Genre { Id = 1, Title = "Action" },
            new Genre { Id = 2, Title = "Sci-Fi" },
            new Genre { Id = 3, Title = "Drama" },
            new Genre { Id = 4, Title = "Comedy" },
            new Genre { Id = 5, Title = "Adventure" }
        };

        // =========================
        // ACTORS
        // =========================
        public static List<Actor> Actors = new()
        {
            new Actor { Id = 1, FullName = "Sam Worthington" },
            new Actor { Id = 2, FullName = "Zoe Saldana" },
            new Actor { Id = 3, FullName = "Sigourney Weaver" },
            new Actor { Id = 4, FullName = "Cillian Murphy" },
            new Actor { Id = 5, FullName = "Emily Blunt" },
            new Actor { Id = 6, FullName = "Margot Robbie" }
        };

        // =========================
        // MOVIES
        // =========================
        public static List<Movie> Movies = new()
        {
            new Movie
            {
                Id = 1,
                Title = "Avatar: Fire and Ash",
                Description = "Jake and Neytiri face a new threat on Pandora.",
                ReleaseDate = new DateOnly(2025, 12, 19),
                DurationMinutes = 192,
                PosterUrl = "avatar.jpg",
                Director = "James Cameron",
                RatingId = 3
            },
            new Movie
            {
                Id = 2,
                Title = "Oppenheimer",
                Description = "The story of J. Robert Oppenheimer and the atomic bomb.",
                ReleaseDate = new DateOnly(2023, 7, 21),
                DurationMinutes = 180,
                PosterUrl = "oppenheimer.jpg",
                Director = "Christopher Nolan",
                RatingId = 4
            },
            new Movie
            {
                Id = 3,
                Title = "Barbie",
                Description = "Barbie begins to question her world and travels to the real world.",
                ReleaseDate = new DateOnly(2023, 7, 21),
                DurationMinutes = 114,
                PosterUrl = "barbie.jpg",
                Director = "Greta Gerwig",
                RatingId = 2
            }
        };


        // =========================
        // HALLS
        // =========================
        public static List<Hall> Halls = new()
        {
            new Hall { Id = 1, Title = "Hall 1", RowsCount = 10, ColsCount = 12, TheatreId = 1 },
            new Hall { Id = 2, Title = "Hall 2", RowsCount = 8, ColsCount = 10, TheatreId = 1 },

            new Hall { Id = 3, Title = "Cavea Hall", RowsCount = 12, ColsCount = 14, TheatreId = 2 },

            new Hall { Id = 4, Title = "IMAX Hall", RowsCount = 14, ColsCount = 16, TheatreId = 3 }
        };

        // =========================
        // HALL ZONES
        // =========================
        public static List<HallZone> HallZones = new()
        {
            // Hall 1
            new HallZone { Id = 1, Title = "Front", HallId = 1 },
            new HallZone { Id = 2, Title = "Middle", HallId = 1 },
            new HallZone { Id = 3, Title = "Back", HallId = 1 },

            // Hall 2
            new HallZone { Id = 4, Title = "Front", HallId = 2 },
            new HallZone { Id = 5, Title = "Back", HallId = 2 },

            // Cavea Hall
            new HallZone { Id = 6, Title = "Standard", HallId = 3 },
            new HallZone { Id = 7, Title = "VIP", HallId = 3 },

            // IMAX Hall
            new HallZone { Id = 8, Title = "Front", HallId = 4 },
            new HallZone { Id = 9, Title = "Middle", HallId = 4 },
            new HallZone { Id = 10, Title = "Back", HallId = 4 }
        };

        // =========================
        // SEATS (small subset for testing)
        // =========================
        public static List<Seat> Seats = new()
        {
            // Hall 1, Front zone (zone 1)
            new Seat { Id = 1, HallZoneId = 1, SRowNumber = 1, SeatNumber = 1 },
            new Seat { Id = 2, HallZoneId = 1, SRowNumber = 1, SeatNumber = 2 },

            // Hall 1, Middle zone (zone 2)
            new Seat { Id = 3, HallZoneId = 2, SRowNumber = 5, SeatNumber = 6 },
            new Seat { Id = 4, HallZoneId = 2, SRowNumber = 5, SeatNumber = 7 },

            // Hall 1, Back zone (zone 3)
            new Seat { Id = 5, HallZoneId = 3, SRowNumber = 10, SeatNumber = 11 },
            new Seat { Id = 6, HallZoneId = 3, SRowNumber = 10, SeatNumber = 12 },

            // IMAX Hall, Middle zone (zone 9)
            new Seat { Id = 7, HallZoneId = 9, SRowNumber = 7, SeatNumber = 8 },
            new Seat { Id = 8, HallZoneId = 9, SRowNumber = 7, SeatNumber = 9 },

            // IMAX Hall, Back zone (zone 10)
            new Seat { Id = 9, HallZoneId = 10, SRowNumber = 14, SeatNumber = 15 },
            new Seat { Id = 10, HallZoneId = 10, SRowNumber = 14, SeatNumber = 16 }
        };

        // =========================
        // SHOWTIMES
        // =========================
        public static List<Showtime> Showtimes = new()
        {
            new Showtime
            {
                Id = 1,
                StartDateTime = new DateTime(2026, 2, 14, 21, 0, 0),
                MinPrice = 12.00m,
                Status = "upcoming",
                MovieId = 1,
                HallId = 1,
                ResolutionId = 2,
                SessionTypeId = 3,
                LanguageId = 1,
                SubtitleId = 1
            },
            new Showtime
            {
                Id = 2,
                StartDateTime = new DateTime(2026, 2, 15, 13, 15, 0),
                MinPrice = 18.00m,
                Status = "upcoming",
                MovieId = 1,
                HallId = 4,
                ResolutionId = 3,
                SessionTypeId = 2,
                LanguageId = 1,
                SubtitleId = 1
            },
            new Showtime
            {
                Id = 3,
                StartDateTime = new DateTime(2026, 2, 16, 19, 30, 0),
                MinPrice = 10.00m,
                Status = "upcoming",
                MovieId = 2,
                HallId = 3,
                ResolutionId = 1,
                SessionTypeId = 3,
                LanguageId = 1,
                SubtitleId = 1
            }
        };

        // =========================
        // HALL ZONE PRICES
        // =========================
        public static List<HallZonePrice> HallZonePrices = new()
        {
            // Showtime 1 (Hall 1)
            new HallZonePrice { ShowtimeId = 1, HallZoneId = 1, Price = 12.00m },
            new HallZonePrice { ShowtimeId = 1, HallZoneId = 2, Price = 15.00m },
            new HallZonePrice { ShowtimeId = 1, HallZoneId = 3, Price = 18.00m },

            // Showtime 2 (IMAX Hall)
            new HallZonePrice { ShowtimeId = 2, HallZoneId = 8, Price = 18.00m },
            new HallZonePrice { ShowtimeId = 2, HallZoneId = 9, Price = 22.00m },
            new HallZonePrice { ShowtimeId = 2, HallZoneId = 10, Price = 26.00m },

            // Showtime 3 (Cavea Hall)
            new HallZonePrice { ShowtimeId = 3, HallZoneId = 6, Price = 10.00m },
            new HallZonePrice { ShowtimeId = 3, HallZoneId = 7, Price = 16.00m }
        };

        // =========================
        // USERS
        // =========================
        public static List<User> Users = new()
        {
            new User { Id = 1 },
            new User { Id = 2 }
        };

        // =========================
        // SEAT SELECTION SESSIONS
        // =========================
        public static List<SeatSelectionSession> SeatSelectionSessions = new()
        {
            new SeatSelectionSession
            {
                Id = 1,
                ReservedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddMinutes(10),
                ShowtimeId = 1,
                UserId = 1
            }
        };

        // =========================
        // SEAT RESERVATIONS
        // =========================
        public static List<SeatReservation> SeatReservations = new()
        {
            new SeatReservation
            {
                Id = 1,
                Status = "reserved",
                Price = 15.00m,
                SeatId = 3,
                ShowtimeId = 1,
                SeatSelectionSessionId = 1
            }
        };

        // =========================
        // TICKETS
        // =========================
        public static List<Ticket> Tickets = new()
        {
            new Ticket
            {
                Id = 1,
                Status = "paid",
                CreatedAt = DateTime.UtcNow,
                PriceAtPurchase = 15.00m,
                SeatReservationId = 1,
                ShowtimeId = 1,
                UserId = 1
            }
        };
    }
}
