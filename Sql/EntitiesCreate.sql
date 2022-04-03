drop table ScenarioComponents;
drop table ScenarioSteps;
drop table Scenarios;
drop table UserDetails;
drop table Users;



create table Users (
	Id int identity(1,1) primary key,
	UserTitle VARCHAR(128) not null,
	CreatedAt DateTime not null,
	CountryCode VARCHAR(3) not null,
	AccessLevel int not null
);
create table UserDetails (
	Id int identity(1,1) primary key,
	UserId int not null
	foreign key (UserId) references Users(Id),
	Login VARCHAR(128) not null,
	Password VARBINARY(32) not null,
	Email VARCHAR(64) not null,
	ForgotPassword bit not null,
	LastUpdate DateTime not null
);

create table Scenarios (
	Id int identity(1,1) primary key,
	ScenarioGuid UNIQUEIDENTIFIER default NEWID(),
	CreatedAt DateTime not null,
	AuthorId int not null
	FOREIGN KEY (AuthorId) references [dbo].Users(Id)
);
create table ScenarioSteps (
	Id int identity(1,1) primary key,
	[Order] int not null,
	Action VARCHAR(MAX) not null,
	ScenarioId int not null
	FOREIGN KEY (Id) references [dbo].Scenarios(Id)
);
create table ScenarioComponents (
	Id int identity(1,1) primary key,
	Name VARCHAR(128) not null,
	Query VARCHAR(2048) not null,
	ScenarioId int not null
	FOREIGN KEY (ScenarioId) references [dbo].Scenarios(Id),
	Symbol VARCHAR(32) not null
);
