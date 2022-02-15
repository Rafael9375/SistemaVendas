--create database DBVENDAS;

use DBVENDAS;

create table tb_Usuario(
	IdUsuario int primary key identity(1,1),
	Nome varchar(255),
	CPF varchar(50),
	RG varchar(50),
	Telefone varchar(50),
	DesLogin varchar(255),
	Senha varchar(255),
);

create table tb_Empresa(
	IdEmpresa int primary key identity(1,1),
	IdUsuarioCadastro int,
	RazaoSocial varchar(max),
	CNPJ varchar(255),
	Endereco varchar(max),
	Telefone varchar(50),
	foreign key (IdUsuarioCadastro) references tb_Usuario(IdUsuario)
);

create table tb_Vendas(
	IdVenda int primary key identity(1,1),
	IdEmpresa int,
	IdUsuarioCadastro int,
	ValorVenda money,
	DataVenda datetime,
	EmitidoNF bit,
	foreign key (IdEmpresa) references tb_Empresa(IdEmpresa),
	foreign key (IdUsuarioCadastro) references tb_Usuario(IdUsuario)
);

create table tb_SegmentoEmpresa(
	IdSegmentoEmpresa int primary key identity(1,1),
	IdEmpresa int,
	DesSegmento varchar(max),
	Ativo bit,
	foreign key (IdEmpresa) references tb_Empresa(IdEmpresa)
);