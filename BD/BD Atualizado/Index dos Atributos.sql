#Aluno

CREATE INDEX id_nome_aluno ON aluno(nome, sobrenome);

#Professor

CREATE INDEX id_nome_professor ON professor(nome, sobrenome);

#Funcionário

CREATE INDEX id_nome_funcionario ON funcionario(nome, sobrenome);

#Livro

CREATE INDEX id_titulo_livro ON livro(titulo);
CREATE INDEX id_isbn_livro ON livro(isbn);

#Alocação

CREATE INDEX id_data_devolucao_alocacao ON locacao(data_devolucao);

#Usuário

CREATE INDEX id_senha_usuario ON usuario(senha);
CREATE INDEX id_status_usuario ON usuario(status_usuario);

#Instituição

CREATE INDEX id_nome_instituicao ON instituicao(nome_instituicao);

#Instituicao_usuario

CREATE INDEX id_situacao ON instituicao_usuario(situacao);

#Curso

CREATE INDEX id_nome_curso ON curso(nome_curso);

#Editora

CREATE INDEX id_nome_editora ON editora(nome_editora);

#Autor

CREATE INDEX id_nome_autor ON autor(nome_autor);

#Verificações

SHOW INDEX FROM aluno;
SHOW INDEX FROM professor;
SHOW INDEX FROM funcionario;
SHOW INDEX FROM livro;
SHOW INDEX FROM locacao;
SHOW INDEX FROM usuario;
SHOW INDEX FROM instituicao;
SHOW INDEX FROM instituicao_usuario;
SHOW INDEX FROM curso;
SHOW INDEX FROM editora;
SHOW INDEX FROM autor;