use DcodeTech;

create table MVCUsers(
ID int primary key identity,
Name varchar(50),
UserName varchar(50) unique,
Email varchar(50),
PhoneNumber varchar(50));

select * from MVCUsers;

create table UsrRole(
ID int primary key identity,
RoleName varchar(50),
ActiveStatus bit default 1);

alter table MVCUsers add RoleID int foreign key(RoleID) references UsrRole(ID);

alter table MVCUsers alter column Password varchar(225);

alter table MVCUsers add ActiveStatus bit default 1;

insert into UsrRole(RoleName) values('User');

select * from UsrRole;

update MVCUsers set RoleID=1 where ID=2;

select usr.ID, usr.UserName, usr.password, rl.RoleName from MVCUsers usr inner join UsrRole rl on usr.RoleID=rl.ID;
