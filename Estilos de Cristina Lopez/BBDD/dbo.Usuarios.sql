CREATE TABLE Usuarios
(
	Nombre varchar not null,
	Apellidos varchar not null,
	FechaNaci date not null,
	Genero varchar not null check (Genero IN('Hombre','Mujer','Otro')),
	Pronombres varchar,
	Telefono int null,
	Username varchar not null, 
	Email varchar(100) not null unique,
	Contrasena varchar not null,
	PRIMARY KEY (Username)
);

