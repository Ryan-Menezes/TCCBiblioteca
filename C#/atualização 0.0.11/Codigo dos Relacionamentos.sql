#relacionamentos de aluno

alter table endereco_aluno add rm_aluno_endereco int not null;
alter table endereco_aluno add foreign key(rm_aluno_endereco) references aluno(rm_aluno)
on delete cascade on update cascade;

alter table contato_aluno add rm_aluno_contato int not null;
alter table contato_aluno add foreign key(rm_aluno_contato) references aluno(rm_aluno)
on delete cascade on update cascade;

#------------------------------------------------------
#relacionamentos de professor

alter table endereco_funcionario add cpf_funcionario_endereco char(11) not null;
alter table endereco_funcionario add foreign key(cpf_funcionario_endereco) references funcionario(cpf)
on delete cascade on update cascade;

alter table contato_professor add rm_professor_contato int not null;
alter table contato_professor add foreign key(rm_professor_contato) references professor(rm_professor)
on delete cascade on update cascade;

#------------------------------------------------------

#relacionamento funcionario

alter table endereco_funcionario add cpf_funcionario_endereco int not null;
alter table endereco_funcionario add foreign key(cpf_funcionario_endereco) references funcionario(cpf)
on delete cascade on update cascade;

alter table contato_funcionario add cpf_funcionario char(11) not null;
alter table contato_funcionario add foreign key(cpf_funcionario) references funcionario(cpf)
on delete cascade on update cascade;

#------------------------------------------------------

#relacionamentos de usuario

alter table aluno add id_usuario_aluno int not null;
alter table aluno add foreign key(id_usuario_aluno) references usuario(id_usuario)
on delete cascade on update cascade;

alter table professor add id_usuario_professor int not null;
alter table professor add foreign key(id_usuario_professor) references usuario(id_usuario)
on delete cascade on update cascade;

alter table funcionario add id_usuario_funcionario int not null;
alter table funcionario add foreign key(id_usuario_funcionario) references usuario(id_usuario)
on delete cascade on update cascade;

alter table avisos add id_usuario_avisos int not null;
alter table avisos add foreign key(id_usuario_avisos) references usuario(id_usuario)
on delete cascade on update cascade;

alter table avisos add id_usuarioRemetente_avisos int not null;
alter table avisos add foreign key(id_usuarioRemetente_avisos) references usuario(id_usuario)
on delete cascade on update cascade;

alter table locacao add id_usuario_locacao int not null;
alter table locacao add foreign key(id_usuario_locacao) references usuario(id_usuario)
on delete cascade on update cascade;

alter table locacao add id_usuarioAdimin_locacao int not null;
alter table locacao add foreign key(id_usuarioAdimin_locacao) references usuario(id_usuario)
on delete cascade on update cascade;

alter table avaliacao add id_usuario_avaliacao int not null;
alter table avaliacao add foreign key(id_usuario_avaliacao) references usuario(id_usuario)
on delete cascade on update cascade;

alter table lista add id_usuario_lista int not null;
alter table lista add foreign key(id_usuario_lista) references usuario(id_usuario)
on delete cascade on update cascade;

alter table curso_usuario add usuario_id_usuario int not null;
alter table curso_usuario add foreign key(usuario_id_usuario) references usuario(id_usuario)
on delete cascade on update cascade;

alter table curso_usuario add curso_id_curso int not null;
alter table curso_usuario add foreign key(curso_id_curso) references curso(id_curso)
on delete cascade on update cascade;

alter table instituicao_usuario add id_usuario int not null;
alter table instituicao_usuario add foreign key(id_usuario) references usuario(id_usuario)
on delete cascade on update cascade;

alter table instituicao_usuario add id_instituicao int not null;
alter table instituicao_usuario add foreign key(id_instituicao) references instituicao(id_instituicao)
on delete cascade on update cascade;

alter table professor add sede int not null;
alter table professor add foreign key(sede) references instituicao(id_instituicao)
on delete cascade on update cascade;

#------------------------------------------------------------------------------
#relacionamento curso

alter table curso add id_instituicao_curso int not null;
alter table curso add foreign key(id_instituicao_curso) references instituicao(id_instituicao)
on delete cascade on update cascade;
#-----------------------------------------------------------------------------
#relacionamentos livro

#(part1)

alter table avaliacao add livro_tombo_avaliacao int not null;
alter table avaliacao add foreign key(livro_tombo_avaliacao) references livro(cod_livro)
on delete cascade on update cascade;

alter table lista add livro_tombo_lista int not null;
alter table lista add foreign key(livro_tombo_lista) references livro(cod_livro)
on delete cascade on update cascade;

alter table exemplares add livro_tombo_exemplares int not null;
alter table exemplares add foreign key(livro_tombo_exemplares) references livro(cod_livro)
on delete cascade on update cascade;

alter table exemplares add id_instituicao int not null;
alter table exemplares add foreign key(id_instituicao) references instituicao(id_instituicao)
on delete cascade on update cascade;

alter table locacao add id_exemplares int not null;
alter table locacao add foreign key(id_exemplares) references exemplares(id_exemplares)
on delete cascade on update cascade;

#(part2)

alter table autor_livro add id_autor_tombo int not null;
alter table autor_livro add foreign key(id_autor_tombo) references autor(id_autor)
on delete cascade on update cascade;

alter table autor_livro add id_livro_tombo int not null;
alter table autor_livro add foreign key(id_livro_tombo) references livro(cod_livro)
on delete cascade on update cascade;

#genero

alter table genero_livro add id_genero_tombo int not null;
alter table genero_livro add foreign key(id_genero_tombo) references genero(id_genero)
on delete cascade on update cascade;

alter table genero_livro add id_livro_tombo int not null;
alter table genero_livro add foreign key(id_livro_tombo) references livro(cod_livro)
on delete cascade on update cascade;

#colaboradores

alter table autor add cod_colaborador int not null;
alter table autor add foreign key(cod_colaborador) references colaboradores(cod_colaborador)
on delete cascade on update cascade;

#editora

alter table editora_livro add id_editora int not null;
alter table editora_livro add foreign key(id_editora) references editora(id_editora)
on delete cascade on update cascade;


alter table editora_livro add cod_livro int not null;
alter table editora_livro add foreign key(cod_livro) references livro(cod_livro)
on delete cascade on update cascade;


#------------------------------

desc professor;
desc contato_professor;
desc endereco_professor;

desc aluno;
desc contato_aluno;
desc endereco_aluno;

desc funcionario;
desc contato_funcionario;
desc endereco_funcionario;

desc usuario;

desc lista;

desc avaliacao;

desc avisos;

desc locacao;

desc curso;

desc curso_usuario;

desc instituicao;
desc instituicao_usuario;

desc exemplares;

desc livro;

desc genero;
desc editora;
desc autor;

desc genero_livro;
desc autor_livro;
desc editora_livro;

desc colaboradores;
