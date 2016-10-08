create table Materiales(
	IdMaterial int identity(1,1) primary key,
	Descripcion varchar(30),
	Precio int
)

create table Solicitudes(
	IdSolicitud int identity(1,1) primary key,
	Fecha varchar(30),
	Razon varchar(30),
	Total int
)

create table SolicitudesDetalle(
	Id int identity(1,1) primary key,
	IdSolicitud int references Solicitudes (IdSolicitud),
	IdMaterial int references Materiales (IdMaterial),
	Cantidad int,
	Precio int
)
