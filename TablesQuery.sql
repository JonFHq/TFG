CREATE TABLE [Generos] (
    [ID] int NOT NULL IDENTITY,
    [Genero] nvarchar(25) NOT NULL,
    CONSTRAINT [PK_Generos] PRIMARY KEY ([ID])
);
CREATE TABLE [Equipos] (
    [ID] int NOT NULL IDENTITY,
    [Equipo] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Equipos] PRIMARY KEY ([ID])
);
CREATE TABLE [Nacionalidades] (
    [ID] int NOT NULL IDENTITY,
    [Pais] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Nacionalidades] PRIMARY KEY ([ID])
);
CREATE TABLE [Personajes] (
    [ID] int NOT NULL IDENTITY,
    [Nombre] nvarchar(50) NOT NULL,
    [Descripcion] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Personajes] PRIMARY KEY ([ID])
);
CREATE TABLE [Peliculas] (
    [ID] int NOT NULL IDENTITY,
    [Titulo] nvarchar(50) NOT NULL,
    [PEGI] int NOT NULL,
    [Estreno] date NOT NULL,
    [PaisID] int NOT NULL,
    [Nota] int NOT NULL,
    [Duracion] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Peliculas] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Peliculas_Nacionalidades_PaisID] FOREIGN KEY ([PaisID]) REFERENCES [Nacionalidades] ([ID]) ON DELETE CASCADE
);
CREATE TABLE [Trabajadores] (
    [ID] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NOT NULL,
    [NacionalidadID] int NOT NULL,
    CONSTRAINT [PK_Trabajadores] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Trabajadores_Nacionalidades_NacionalidadID] FOREIGN KEY ([NacionalidadID]) REFERENCES [Nacionalidades] ([ID]) ON DELETE CASCADE
);
CREATE TABLE [Especialistas] (
    [ID] int NOT NULL IDENTITY,
    [EspecialistaID] int NOT NULL,
    [EquipoID] int NOT NULL,
    CONSTRAINT [PK_Especialistas] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Especialistas_Trabajadores_EspecialistaID] FOREIGN KEY ([EspecialistaID]) REFERENCES [Trabajadores] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Especialistas_Equipos_EquipoID] FOREIGN KEY ([EquipoID]) REFERENCES [Equipos] ([ID]) ON DELETE CASCADE
);
CREATE TABLE [Actores] (
    [ID] int NOT NULL IDENTITY,
    [ActorID] int NOT NULL,
    CONSTRAINT [PK_Actores] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Actores_Trabajadores_ActorID] FOREIGN KEY ([ActorID]) REFERENCES [Trabajadores] ([ID]) ON DELETE CASCADE
);
CREATE TABLE [GenerosPeliculas] (
    [ID] int NOT NULL IDENTITY,
    [GeneroID] int NOT NULL,
    [PeliculaID] int NOT NULL,
    CONSTRAINT [PK_GenerosPeliculas] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_GenerosPeliculas_Generos_GeneroID] FOREIGN KEY ([GeneroID]) REFERENCES [Generos] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_GenerosPeliculas_Peliculas_PeliculaID] FOREIGN KEY ([PeliculaID]) REFERENCES [Peliculas] ([ID]) ON DELETE CASCADE
);
CREATE TABLE [Repartos] (
    [ID] int NOT NULL IDENTITY,
    [PersonajeID] int NOT NULL,
    [PeliculaID] int NOT NULL,
    CONSTRAINT [PK_Repartos] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Repartos_Peliculas_PeliculaID] FOREIGN KEY ([PeliculaID]) REFERENCES [Peliculas] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Repartos_Personajes_PersonajeID] FOREIGN KEY ([PersonajeID]) REFERENCES [Personajes] ([ID]) ON DELETE CASCADE
);
CREATE TABLE [Caracterizaciones] (
    [ID] int NOT NULL IDENTITY,
    [PersonajeID] int NOT NULL,
    [ActorID] int NOT NULL,
    CONSTRAINT [PK_Caracterizaciones] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Caracterizaciones_Actores_ActorID] FOREIGN KEY ([ActorID]) REFERENCES [Actores] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Caracterizaciones_Personajes_PersonajeID] FOREIGN KEY ([PersonajeID]) REFERENCES [Personajes] ([ID]) ON DELETE CASCADE
);
CREATE TABLE [Elencos] (
    [ID] int NOT NULL IDENTITY,
    [PeliculaID] int NOT NULL,
    [EspecialistaID] int NOT NULL,
    CONSTRAINT [PK_Elencos] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Elencos_Especialistas_EspecialistaID] FOREIGN KEY ([EspecialistaID]) REFERENCES [Especialistas] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Elencos_Peliculas_PeliculaID] FOREIGN KEY ([PeliculaID]) REFERENCES [Peliculas] ([ID]) ON DELETE NO ACTION
);