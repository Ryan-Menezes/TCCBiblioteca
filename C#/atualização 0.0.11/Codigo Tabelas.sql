create database bdBibliotecaEtec
default character set utf8
default collate utf8_general_ci;

use bdBibliotecaEtec;

create table professor(
rm_professor int(5) primary key not null,
nome varchar(20) not null,
sobrenome varchar(40) not null,
cpf char(11) unique not null,
sexo enum('M', 'F'),
data_cadastro date not null,
img_professor mediumblob) default charset = utf8;

create table endereco_professor(
id_endereco_professor int(5) not null auto_increment primary key,
cep char(8) not null,
logradouro varchar(100) not null,
numero int not null,
bairro varchar(50) not null,
cidade varchar(50) not null,
complemento mediumtext
) default charset = utf8;


create table contato_professor(
id_contato_professor int(5) not null auto_increment primary key,
telefone char(10),
celular char(11) not null,
email varchar(100) not null) default charset = utf8;

create table aluno(
rm_aluno int(5) not null primary key,
nome varchar(20) not null,
sobrenome varchar(40) not null,
cpf char(11) unique not null,
sexo enum('M','F'),
data_cadastro date not null,
img_aluno mediumblob) default charset = utf8;


create table endereco_aluno(
id_endereco int(5) not null auto_increment primary key,
cep char(8) not null,
logradouro varchar(100) not null,
numero int not null,
bairro varchar(50) not null,
cidade varchar(50) not null,
complemento mediumtext) default charset = utf8;


create table contato_aluno(
id_contato int(5) not null auto_increment primary key,
telefone char(10),
celular char(11) not null,
email varchar(100) not null) default charset = utf8;

create table funcionario(
cpf char(11) not null primary key,
nome varchar(20) not null,
sobrenome varchar(40) not null,
sexo enum('M','F'),
data_cadastro date not null,
img_funcionario mediumblob) default charset = utf8;

create table endereco_funcionario(
id_endereco_funcionario int(5) not null auto_increment primary key,
cep char(8) not null,
logradouro varchar(100) not null,
numero int not null,
bairro varchar(50) not null,
cidade varchar(50) not null,
complemento mediumtext
) default charset = utf8;

create table contato_funcionario(
id_contato int(5) not null auto_increment primary key,
telefone char(10),
celular char(11) not null,
email varchar(100) not null) default charset = utf8;


create table curso(
id_curso int(3) primary key auto_increment not null,
nome_curso varchar(40) not null,
modulo_serie char(1) not null,
periodo enum('M','T','N') not null,
turma char(2) not null,
tipo varchar(4) not null) default charset = utf8;


create table curso_usuario(
id_curso_usuario int(3) primary key auto_increment not null) default charset = utf8;


create table genero(
id_genero int(3) primary key auto_increment not null,
nome_genero varchar(40) not null) default charset = utf8;

create table genero_livro(
genero_id_genero int primary key auto_increment not null) default charset = utf8;


create table instituicao(
id_instituicao int(3) primary key not null,
nome_instituicao varchar(255) not null) default charset = utf8;

create table instituicao_usuario(
id_instituicao_usuario int(3) primary key not null,
situacao enum('D', 'I')) default charset = utf8;


create table autor(
id_autor int(3) primary key auto_increment not null,
nome_autor varchar(100) not null,
nacionalidade varchar(40) not null) default charset = utf8;

create table autor_livro(
autor_id_autor int primary key auto_increment not null) default charset = utf8;

create table colaboradores(
cod_colaborador int primary key auto_increment not null,
nomes varchar(255) not null) default charset = utf8;


create table livro(
cod_livro int not null primary key auto_increment,
tombo varchar(10) unique,
titulo varchar(100) not null,
ano_publicacao date not null,
volume int,
edicao int,
insercao date not null,
isbn varchar(14),
idioma varchar(30) not null,
img_livro mediumblob not null,
pdf_livro varchar(100))default charset = utf8;


create table editora(
id_editora int not null primary key auto_increment,
nome_editora varchar(100) not null,
cnpj char(14))default charset = utf8;

create table editora_livro(
editora_id_editora int primary key auto_increment not null
)default charset = utf8;


create table exemplares(
id_exemplares int not null primary key auto_increment,
quantidade int not null)default charset = utf8;


create table lista(
id_lista int not null primary key auto_increment)default charset = utf8;


create table avaliacao(
id_avaliacao int not null primary key auto_increment,
mensagem longtext,
avaliacao_estrelas int not null,
data_ava date not null)default charset = utf8;


create table locacao(
id_locacao int not null primary key auto_increment,
data_locacao date not null,
data_devolucao date not null
)default charset = utf8;


create table usuario(
id_usuario int not null primary key auto_increment,
senha varchar(100) not null,
nivel_acesso enum('A','U') not null,
status_usuario enum('B','D') not null
)default charset = utf8;


create table avisos(
id_aviso int not null primary key auto_increment,
titulo varchar(50) not null,
mensagem longtext not null,
situacao enum('V', 'N') not null,
data_envio date not null
)default charset = utf8;