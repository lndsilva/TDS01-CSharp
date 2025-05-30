-- drop database dbFrancisco;

create database dbFrancisco;

use dbFrancisco;

create table tbUsuarios(
codUsu int not null auto_increment,
nome varchar(50) not null,
senha varchar(12) not null,
primary key(codUsu));

create table tbAtribuicoes(
codAtr int not null auto_increment,
nome varchar(100) not null,
primary key(codAtr));

-- insert into tbAtribuicoes(nome)values(nome);

-- update tbAtribuicoes set nome = nome where codAtr = codAtr;

-- delete from tbAtribuicoes where codAtr = codAtr;

select * from tbAtribuicoes order by nome;

create table tbVoluntarios(
codVol int not null auto_increment,
nome varchar(100) not null,
email varchar(100),
telCel char(15),
endereco varchar(100),
numero char(5),
cep char(9),
bairro varchar(100),
cidade varchar(100),
estado char(2),
codAtr int not null,
data date,
hora time,
status bit,
primary key(codVol),
foreign key(codAtr)references tbAtribuicoes(codAtr));

insert into tbVoluntarios(nome,email,telCel,endereco,numero,cep,bairro,cidade,estado,codAtr,data,hora,status)values(nome,email,telCel,endereco,numero,cep,bairro,cidade,estado,codAtr,data,hora,status);

-- insert into tbUsuarios(nome,senha)
--	values('sfrancisco','123456');

-- select * from tbUsuarios;

-- select nome,senha from tbUsuarios 
-- where nome='admin' and senha='admin';

-- select nome from tbusuarios order by nome asc;


-- update tbUsuarios set nome = 'senac', senha = '123456789123' where codUsu = 1;

-- pesquisa filtrada por codigo

-- select * from tbusuarios where codusu = codusu;

-- pesquisa filtrada por nome

-- select * from tbUsuarios where nome like '%nome%';

-- select * from tbUsuarios where nome = 'sfrancisco';

-- delete from tbUsuarios where codusu = 5;


