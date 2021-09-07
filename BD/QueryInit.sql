INSERT INTO instituicao (id_instituicao, nome_instituicao) VALUES (166, 'ETEC Juscelino Kubistchek de Oliveira');

INSERT INTO usuario (senha, nivel_acesso, status_usuario) VALUES (MD5('12345678'), 'A', 'D');

INSERT INTO professor (rm_professor, nome, sobrenome, cpf, sexo, data_cadastro, img_professor, id_usuario_professor, sede) VALUES (542426, 'Lucas', 'Souza', '12345678910', 'M', CURDATE(), 0101, 1, 166);

INSERT INTO endereco_professor (cep, logradouro, numero, bairro, cidade, complemento, rm_professor_endereco) VALUES ('12345678', 'Rua Teste', 11, 'Bairro Teste', 'Diadema', NULL, 542426);

INSERT INTO contato_professor (telefone, celular, email, rm_professor_contato) VALUES ('1198635789', '11963278966', 'teste@gmail.com', 542426);

INSERT INTO instituicao_usuario (situacao, id_usuario, id_instituicao) VALUES ('D', 1, 166);

#rm - 542426
#senha - 12345678