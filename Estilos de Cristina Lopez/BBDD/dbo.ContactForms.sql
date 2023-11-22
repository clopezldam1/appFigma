CREATE TABLE ContactForms
(
	FechaEmision DATETIME not null default CURRENT_TIMESTAMP,
	NomApe varchar NOT NULL,
	Email varchar not null,
	Username varchar not null,
	Telefono int not null,
	Departamento varchar not null default 'Nation',
	Asunto varchar not null,
	Mensaje varchar,
	SendCopy varchar(2) not null CHECK(SendCopy IN ('SI','NO')),
	ReplyBack varchar(2) not null CHECK(ReplyBack IN ('SI','NO')),
	PRIMARY KEY (FechaEmision, Departamento),
	CONSTRAINT FK_contact_user FOREIGN KEY (Username) REFERENCES Usuarios(Username) ON DELETE CASCADE ON UPDATE CASCADE
);
