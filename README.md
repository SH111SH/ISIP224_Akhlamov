/* ==========================================
   1. СОЗДАНИЕ БАЗЫ ДАННЫХ
   ========================================== */

IF DB_ID(N'Cinema') IS NULL
BEGIN
    CREATE DATABASE Cinema;
END
GO

USE Cinema;
GO

/* ==========================================
   2. СОЗДАНИЕ ТАБЛИЦ
   ========================================== */

-- Кинотеатры
IF OBJECT_ID(N'dbo.Cinema', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Cinema
    (
        CinemaID INT IDENTITY(1,1) NOT NULL,
        Name NVARCHAR(50) NULL,
        Rate INT NULL,

        CONSTRAINT PK_Cinema PRIMARY KEY (CinemaID),
        CONSTRAINT CK_Cinema_Rate CHECK (Rate >= 1 AND Rate <= 5)
    );
END
GO

-- Жанры
IF OBJECT_ID(N'dbo.Genre', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Genre
    (
        GenreID INT IDENTITY(1,1) NOT NULL,
        Name NVARCHAR(50) NULL,

        CONSTRAINT PK_Genre PRIMARY KEY (GenreID)
    );
END
GO

-- Фильмы
IF OBJECT_ID(N'dbo.Film', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Film
    (
        FilmID INT IDENTITY(1,1) NOT NULL,
        GenreID INT NULL,
        Name NVARCHAR(150) NULL,
        Rate INT NULL,
        [Release] DATE NULL,
        [Description] NVARCHAR(300) NULL,
        AgeRating NVARCHAR(5) NULL,
        Icon NVARCHAR(150) NULL,

        CONSTRAINT PK_Film PRIMARY KEY (FilmID),

        CONSTRAINT CK_Film_Rate CHECK (Rate >= 1 AND Rate <= 5),

        CONSTRAINT FK_Film_Genre
            FOREIGN KEY (GenreID)
            REFERENCES dbo.Genre(GenreID)
    );
END
GO

-- Сеансы
IF OBJECT_ID(N'dbo.Performance', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Performance
    (
        PerformanceID INT NOT NULL,
        FilmID INT NULL,
        [Date] DATETIME NULL,
        [Time] TIME(7) NULL,
        CinemaID INT NULL,

        CONSTRAINT PK_Performance PRIMARY KEY (PerformanceID),

        CONSTRAINT FK_Performance_Film
            FOREIGN KEY (FilmID)
            REFERENCES dbo.Film(FilmID),

        CONSTRAINT FK_Performance_Cinema
            FOREIGN KEY (CinemaID)
            REFERENCES dbo.Cinema(CinemaID)
    );
END
GO

-- Места
IF OBJECT_ID(N'dbo.Seat', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Seat
    (
        SeatID INT IDENTITY(1,1) NOT NULL,
        CinemaID INT NULL,
        [Row] INT NULL,
        Place INT NULL,
        Busy BIT NULL,

        CONSTRAINT PK_Seat PRIMARY KEY (SeatID),

        CONSTRAINT FK_Seat_Cinema
            FOREIGN KEY (CinemaID)
            REFERENCES dbo.Cinema(CinemaID)
    );
END
GO

-- Пользователи (оставляем пустой)
IF OBJECT_ID(N'dbo.[User]', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.[User]
    (
        USerID INT IDENTITY(1,1) NOT NULL,
        Login NVARCHAR(100) NULL,
        [Password] NVARCHAR(150) NULL,

        CONSTRAINT PK_User PRIMARY KEY (USerID)
    );
END
GO

-- Билеты (оставляем пустой)
IF OBJECT_ID(N'dbo.Ticket', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Ticket
    (
        TicketID INT IDENTITY(1,1) NOT NULL,
        PerformanceID INT NULL,
        SeatID INT NULL,
        Cost MONEY NULL,
        UserID INT NULL,

        CONSTRAINT PK_Ticket PRIMARY KEY (TicketID),

        CONSTRAINT FK_Ticket_Performance
            FOREIGN KEY (PerformanceID)
            REFERENCES dbo.Performance(PerformanceID),

        CONSTRAINT FK_Ticket_Seat
            FOREIGN KEY (SeatID)
            REFERENCES dbo.Seat(SeatID),

        CONSTRAINT FK_Ticket_User
            FOREIGN KEY (UserID)
            REFERENCES dbo.[User](USerID)
    );
END
GO

/* ==========================================
   3. ЗАПОЛНЕНИЕ ЖАНРОВ
   ========================================== */

INSERT INTO dbo.Genre (Name)
SELECT v.Name
FROM (VALUES
    (N'Боевик'),
    (N'Комедия'),
    (N'Фантастика'),
    (N'Ужасы'),
    (N'Драма'),
    (N'Приключения'),
    (N'Триллер'),
    (N'Мультфильм'),
    (N'Мелодрама'),
    (N'Детектив')
) AS v(Name)
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.Genre g
    WHERE g.Name = v.Name
);
GO

/* ==========================================
   4. ЗАПОЛНЕНИЕ КИНОТЕАТРОВ
   ========================================== */

INSERT INTO dbo.Cinema (Name, Rate)
SELECT v.Name, v.Rate
FROM (VALUES
    (N'Синема Парк', 5),
    (N'Каро Фильм', 4),
    (N'Мир кино', 5),
    (N'Октябрь', 4),
    (N'Премьер', 3)
) AS v(Name, Rate)
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.Cinema c
    WHERE c.Name = v.Name
);
GO

/* ==========================================
   5. ЗАПОЛНЕНИЕ ФИЛЬМОВ
   ========================================== */

INSERT INTO dbo.Film
(
    GenreID,
    Name,
    Rate,
    [Release],
    [Description],
    AgeRating,
    Icon
)
SELECT
    g.GenreID,
    v.Name,
    v.Rate,
    v.ReleaseDate,
    v.FilmDescription,
    v.AgeRating,
    v.Icon
FROM (VALUES
    (N'Боевик', N'Джон Уик', 5, '20141024',
     N'Бывший наёмный убийца возвращается к опасной жизни.', N'18+', N'john_wick.jpg'),

    (N'Комедия', N'Мальчишник в Вегасе', 4, '20090605',
     N'Друзья пытаются вспомнить события безумной ночи.', N'18+', N'hangover.jpg'),

    (N'Фантастика', N'Интерстеллар', 5, '20141107',
     N'Путешествие исследователей через космос в поисках нового дома.', N'12+', N'interstellar.jpg'),

    (N'Ужасы', N'Оно', 4, '20170907',
     N'Компания детей сталкивается с загадочным существом.', N'18+', N'it.jpg'),

    (N'Драма', N'Зелёная миля', 5, '19991206',
     N'История надзирателя и необычного заключённого.', N'16+', N'green_mile.jpg'),

    (N'Приключения', N'Пираты Карибского моря', 5, '20030709',
     N'Приключения капитана Джека Воробья.', N'12+', N'pirates.jpg'),

    (N'Триллер', N'Остров проклятых', 5, '20100213',
     N'Расследование исчезновения пациентки психиатрической клиники.', N'18+', N'shutters_island.jpg'),

    (N'Мультфильм', N'Шрек', 5, '20010422',
     N'Приключения зелёного огра и его друзей.', N'0+', N'shrek.jpg'),

    (N'Мелодрама', N'Титаник', 5, '19971219',
     N'История любви на борту знаменитого лайнера.', N'12+', N'titanic.jpg'),

    (N'Детектив', N'Достать ножи', 4, '20191127',
     N'Детектив расследует загадочную смерть писателя.', N'16+', N'knives_out.jpg'),

    (N'Боевик', N'Безумный Макс: Дорога ярости', 5, '20150514',
     N'Борьба за выживание в постапокалиптическом мире.', N'18+', N'mad_max.jpg'),

    (N'Фантастика', N'Матрица', 5, '19990331',
     N'Программист узнаёт правду о реальности.', N'16+', N'matrix.jpg'),

    (N'Комедия', N'Один дома', 5, '19901110',
     N'Мальчик защищает дом от двух грабителей.', N'6+', N'home_alone.jpg'),

    (N'Драма', N'Побег из Шоушенка', 5, '19940923',
     N'История дружбы и надежды в тюрьме.', N'16+', N'shawshank.jpg'),

    (N'Мультфильм', N'Тайна Коко', 5, '20171020',
     N'Мальчик отправляется в мир мёртвых.', N'6+', N'coco.jpg')

) AS v(GenreName, Name, Rate, ReleaseDate, FilmDescription, AgeRating, Icon)

INNER JOIN dbo.Genre g ON g.Name = v.GenreName

WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.Film f
    WHERE f.Name = v.Name
);
GO

/* ==========================================
   6. ЗАПОЛНЕНИЕ МЕСТ
   По 20 мест в каждом кинотеатре
   ========================================== */

INSERT INTO dbo.Seat
(
    CinemaID,
    [Row],
    Place,
    Busy
)
SELECT
    c.CinemaID,
    r.RowNumber,
    p.PlaceNumber,
    0
FROM dbo.Cinema c

CROSS JOIN (VALUES
    (1), (2), (3), (4)
) AS r(RowNumber)

CROSS JOIN (VALUES
    (1), (2), (3), (4), (5)
) AS p(PlaceNumber)

WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.Seat s
    WHERE s.CinemaID = c.CinemaID
      AND s.[Row] = r.RowNumber
      AND s.Place = p.PlaceNumber
);
GO

/* ==========================================
   7. ЗАПОЛНЕНИЕ СЕАНСОВ
   ========================================== */

INSERT INTO dbo.Performance
(
    PerformanceID,
    FilmID,
    [Date],
    [Time],
    CinemaID
)

SELECT
    v.PerformanceID,
    f.FilmID,
    v.PerformanceDate,
    v.PerformanceTime,
    c.CinemaID

FROM (VALUES

    (1, N'Джон Уик', N'Синема Парк', '20261126', '10:00'),
    (2, N'Мальчишник в Вегасе', N'Синема Парк', '20261126', '13:00'),
    (3, N'Интерстеллар', N'Синема Парк', '20261126', '16:00'),
    (4, N'Оно', N'Синема Парк', '20261126', '19:00'),

    (5, N'Зелёная миля', N'Каро Фильм', '20261126', '10:30'),
    (6, N'Пираты Карибского моря', N'Каро Фильм', '20261126', '13:30'),
    (7, N'Остров проклятых', N'Каро Фильм', '20261126', '17:00'),
    (8, N'Шрек', N'Каро Фильм', '20261126', '20:00'),

    (9, N'Титаник', N'Мир кино', '20261127', '11:00'),
    (10, N'Достать ножи', N'Мир кино', '20261127', '14:00'),
    (11, N'Безумный Макс: Дорога ярости', N'Мир кино', '20261127', '17:00'),
    (12, N'Матрица', N'Мир кино', '20261127', '20:00'),

    (13, N'Один дома', N'Октябрь', '20261128', '10:00'),
    (14, N'Побег из Шоушенка', N'Октябрь', '20261128', '14:00'),
    (15, N'Тайна Коко', N'Октябрь', '20261128', '18:00'),

    (16, N'Джон Уик', N'Премьер', '20261128', '20:30'),
    (17, N'Интерстеллар', N'Премьер', '20261129', '12:00'),
    (18, N'Пираты Карибского моря', N'Премьер', '20261129', '15:00'),

    (19, N'Шрек', N'Синема Парк', '20261129', '18:00'),
    (20, N'Достать ножи', N'Каро Фильм', '20261129', '21:00')

) AS v(PerformanceID, FilmName, CinemaName, PerformanceDate, PerformanceTime)

INNER JOIN dbo.Film f ON f.Name = v.FilmName
INNER JOIN dbo.Cinema c ON c.Name = v.CinemaName

WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.Performance p
    WHERE p.PerformanceID = v.PerformanceID
);
GO

/* ==========================================
   8. ПРОВЕРКА РЕЗУЛЬТАТА
   ========================================== */

SELECT N'Cinema' AS TableName, COUNT(*) AS Total FROM dbo.Cinema
UNION ALL
SELECT N'Genre', COUNT(*) FROM dbo.Genre
UNION ALL
SELECT N'Film', COUNT(*) FROM dbo.Film
UNION ALL
SELECT N'Performance', COUNT(*) FROM dbo.Performance
UNION ALL
SELECT N'Seat', COUNT(*) FROM dbo.Seat
UNION ALL
SELECT N'Ticket', COUNT(*) FROM dbo.Ticket
UNION ALL
SELECT N'User', COUNT(*) FROM dbo.[User];
GO
