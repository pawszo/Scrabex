begin tran

drop table ScenarioSteps;
drop table ScenarioComponents;
drop table UserDetails;
drop table Scenarios;
drop table Users;

create table Users (
	UserId int identity(1,1) primary key,
	UserTitle VARCHAR(128) not null,
	CreatedAt DateTime not null,
	CountryCode VARCHAR(3) not null,
	Confirmed BIT not null
);

create table Scenarios (
	ScenarioId int identity(1,1) primary key,
	ScenarioGuid UNIQUEIDENTIFIER default NEWID(),
	CreatedAt DateTime not null,
	AuthorId int not null
	FOREIGN KEY (AuthorId) references [dbo].Users(UserId)
);

create table ScenarioSteps (
	StepId int identity(1,1) primary key,
	[Order] int not null,
	Action VARCHAR(MAX) not null,
	ScenarioId int not null
	FOREIGN KEY (ScenarioId) references [dbo].Scenarios(ScenarioId)
);

create table UserDetails (
	UserId int identity(1,1) primary key,
	foreign key (UserId) references Users(UserId),
	Login VARCHAR(128) not null,
	Password VARCHAR(128) not null,
	ForgotPassword bit not null,
	LastUpdate DateTime not null
	);

create table ScenarioComponents (
	ComponentId int identity(1,1) primary key,
	Name VARCHAR(128) not null,
	Query VARCHAR(2048) not null,
	ScenarioId int not null
	FOREIGN KEY (ScenarioId) references [dbo].Scenarios(ScenarioId)	
);

commit tran