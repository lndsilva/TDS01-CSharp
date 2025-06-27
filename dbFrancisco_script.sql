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
	codAtr,data,hora,status,foto)
values('Amarildo Fernadez','amarildo.fernadez@gmail.com',
'(11)97852-8577','Rua Maria Fernadez','574',
'04750-000','Santo Amaro','Sao Paulo',
'SP',4,'2025/06/06','09:24:00',1,foto);

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


-- inner join

select * from tbVoluntarios as vol
inner join tbAtribuicoes as atr
on vol.codAtr = atr.codAtr where
vol.nome = 'Eduardo Fonseca';


-- update tbVoluntarios set complemento = 'casa';


delete from tbVoluntarios where codVol = @codVol;

update tbVoluntarios set 
	nome=@nome,email=@email,telCel=@telCel,
	endereco=@endereco,numero=@numero,cep=@cep,
	complemento=@complemento,
	bairro=@bairro,cidade=@cidade,estado=@estado,
	codAtr=@codAtr,data=@data,
	hora=@hora,status=@status,foto=@foto
where codVol=@codVol;

create table tbUnidades(
codUnid int not null auto_increment,
descricao varchar(50),
unidade char(2),
primary key(codUnid));

insert into tbUnidades (descricao,unidade)values(@descricao,@unidade);

update set tbUnidades descricao=@descricao, unidade=@unidade where codUnid=@codUnid;

select * from tbunidades order by unidade;

select * from tbUnidades where codUnid = @codUnid;

create table tbProdutos(
codBarras int not null,
descricao varchar(100) not null unique,
quantidade int,
lote varchar(10) not null unique,
dataEntr datetime,
horaEntr datetime,
validade datetime,
codUnid int not null,
primary key(codBarras),
foreign key(codUnid)references tbUnidades(codUnid));

insert into tbProdutos(codBarras,descricao,quantidade,lote,dataEntr,horaEntr,validade,codUnid)values(@codBarras,@descricao,@quantidade,@lote,@dataEntr,@horaEntr,@validade,@codUnid);


update tbProdutos set codBarras = @codBarras,descricao=@descricao,quantidade=@quantidade,lote=@lote,dataEntr=@dataEntr,horaEntr=@horaEntr,validade=@validade,codUnid=@codUnid where codBarras = @codBarras;

