CREATE TABLE Propietarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellidos VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20) NULL,
    Email VARCHAR(150) NULL,
    Estado VARCHAR(20) NOT NULL DEFAULT 'Activo'
);

CREATE TABLE Mascotas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PropietarioId INT NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Especie VARCHAR(50) NOT NULL,
    Raza VARCHAR(50) NULL,
    FechaNacimiento DATE NOT NULL,
    Estado VARCHAR(20) NOT NULL DEFAULT 'Activo',
    CONSTRAINT FK_Mascotas_Propietarios FOREIGN KEY (PropietarioId) 
        REFERENCES Propietarios(Id) ON DELETE CASCADE
);

CREATE TABLE Veterinarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellidos VARCHAR(100) NOT NULL,
    Especialidad VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20) NULL,
    Estado VARCHAR(20) NOT NULL DEFAULT 'Activo'
);

CREATE TABLE Citas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    MascotaId INT NOT NULL,
    VeterinarioId INT NOT NULL,
    FechaHora DATETIME NOT NULL,
    Motivo VARCHAR(250) NOT NULL,
    EstadoCita VARCHAR(20) NOT NULL DEFAULT 'Pendiente',
    Diagnostico VARCHAR(500) NULL,
    CONSTRAINT FK_Citas_Mascotas FOREIGN KEY (MascotaId) 
        REFERENCES Mascotas(Id) ON DELETE CASCADE,
    CONSTRAINT FK_Citas_Veterinarios FOREIGN KEY (VeterinarioId) 
        REFERENCES Veterinarios(Id)
);

INSERT INTO Propietarios (Nombre, Apellidos, Telefono, Email, Estado) 
VALUES 
('Carlos', 'Mendoza Ramos', '70123456', 'carlos.mendoza@gmail.com', 'Activo'),
('Lucia', 'Fernandez Soto', '78945612', 'lucia.fernandez@hotmail.com', 'Activo');

INSERT INTO Mascotas (PropietarioId, Nombre, Especie, Raza, FechaNacimiento, Estado) 
VALUES 
(1, 'Max', 'Perro', 'Golden Retriever', '2022-05-10', 'Activo'),
(2, 'Luna', 'Gato', 'Siames', '2024-01-15', 'Activo');

INSERT INTO Veterinarios (Nombre, Apellidos, Especialidad, Telefono, Estado) 
VALUES 
('Roberto', 'Gomez Pardo', 'Cirugia', '71239874', 'Activo'),
('Mariana', 'Vargas Silva', 'Medicina General', '76543210', 'Activo');

INSERT INTO Citas (MascotaId, VeterinarioId, FechaHora, Motivo, EstadoCita, Diagnostico) 
VALUES 
(1, 1, '2026-09-15 10:00:00', 'Revision general', 'Pendiente', 'En evaluacion'),
(2, 2, '2026-09-10 15:30:00', 'Vacunacion', 'Completada', 'Vacuna aplicada sin complicaciones');
