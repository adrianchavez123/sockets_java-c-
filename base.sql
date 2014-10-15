create database sockets;

use database sockets;

create table servidor(
	id int not null auto_increment,
	mensaje varchar(140) not null,
	fecha datetime not null,
	primary key (id)
) engine = innodb;


create table cliente(
	id int not null auto_increment,
	mensaje varchar(140) not null,
	fecha datetime not null,
	primary key (id)
) engine = innodb;
