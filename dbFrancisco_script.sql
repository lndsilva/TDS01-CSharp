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

select codAtr from tbatribuicoes where nome ='Realizar passe';

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
data datetime,
hora datetime,
status bit,
foto longblob,
primary key(codVol),
foreign key(codAtr)references tbAtribuicoes(codAtr));

create table tbFotos(
codFotos int not null auto_increment,
nome varchar(100),
campo_imagem longblob,
primary key(codFotos));


insert into tbVoluntarios(nome,email,telCel,endereco,numero
	,cep,bairro,
	cidade,estado,
	codAtr,data,hora,status)
values('Amarildo Fernadez','amarildo.fernadez@gmail.com',
'(11)97852-8577','Rua Maria Fernadez','574',
'04750-000','Santo Amaro','Sao Paulo',
'SP',4,'2025/06/06','09:24:00',1);

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


-- select * from tbvoluntarios where codVol = codVol;
-- select * from tbvoluntarios where nome like '%nome%';

select * from tbVoluntarios where nome = 'Amarildo Fernadez';

