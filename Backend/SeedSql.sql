-- Inserir categorias
INSERT INTO Categorias (Nome) 
VALUES 
('A��o'), 
('Drama'), 
('Com�dia'), 
('Anima��o'), 
('Fic��o Cient�fica');

-- Inserir 50 filmes na tabela Filmes
INSERT INTO Filmes (Titulo, Genero, Sinopse, Duracao) 
VALUES
('A Origem', 'Fic��o Cient�fica', 'Um ladr�o invade sonhos para roubar segredos.', 148),
('O Poderoso Chef�o', 'Drama', 'A saga de uma fam�lia mafiosa nos EUA.', 175),
('Parasita', 'Suspense', 'Fam�lia pobre infiltra-se na casa de uma fam�lia rica.', 132),
('Cidade de Deus', 'Crime', 'Hist�ria de gangues em uma favela carioca.', 130),
('Titanic', 'Romance', 'Amor e trag�dia no maior navio do mundo.', 195),
('Tropa de Elite', 'A��o', 'Um capit�o enfrenta o tr�fico no Rio de Janeiro.', 115),
('Os Vingadores', 'A��o', 'Her�is se unem para salvar o mundo.', 143),
('O Senhor dos An�is: O Retorno do Rei', 'Fantasia', 'A batalha final contra Sauron.', 201),
('Pulp Fiction: Tempo de Viol�ncia', 'Crime', 'Hist�rias interligadas de viol�ncia e reden��o.', 154),
('A Viagem de Chihiro', 'Anima��o', 'Garota entra em um mundo m�gico e precisa resgatar seus pais.', 125),
('Avatar', 'Fic��o Cient�fica', 'Humanos exploram um planeta habitado por alien�genas.', 162),
('Corra!', 'Suspense', 'Jovem negro descobre segredos perturbadores na fam�lia da namorada.', 104),
('Coringa', 'Drama', 'A origem sombria de um dos vil�es mais ic�nicos do cinema.', 122),
('Forrest Gump: O Contador de Hist�rias', 'Drama', 'Um homem simples vive momentos marcantes da hist�ria.', 142),
('Viva: A Vida � uma Festa', 'Anima��o', 'Garoto embarca em uma jornada pelo mundo dos mortos.', 105),
('A Bela e a Fera', 'Fantasia', 'Jovem descobre o verdadeiro amor em um castelo encantado.', 129),
('Matrix', 'Fic��o Cient�fica', 'A luta contra uma realidade simulada criada por m�quinas.', 136),
('Pantera Negra', 'A��o', 'Rei africano protege seu reino e seu povo.', 134),
('Divertida Mente', 'Anima��o', 'As emo��es de uma garota adolescente ganham vida.', 95),
('Gladiador', 'Drama', 'Um general romano busca vingan�a ap�s ser tra�do.', 155),
('A Lista de Schindler', 'Hist�rico', 'Homem salva judeus durante o Holocausto.', 195),
('Vingadores: Ultimato', 'A��o', 'Her�is tentam reverter o dano causado por Thanos.', 181),
('Doze Homens e Uma Senten�a', 'Drama', 'J�ri decide o destino de um jovem acusado de assassinato.', 96),
('O Resgate do Soldado Ryan', 'Guerra', 'Miss�o para resgatar o �nico sobrevivente de uma fam�lia.', 169),
('Interestelar', 'Fic��o Cient�fica', 'Explora��o espacial para salvar a humanidade.', 169),
('O Rei Le�o', 'Anima��o', 'Jovem le�o retorna para reivindicar seu trono.', 88),
('Shrek', 'Com�dia', 'Ogro embarca em uma jornada para salvar uma princesa.', 90),
('Bastardos Ingl�rios', 'Guerra', 'Grupo de soldados ca�a nazistas durante a Segunda Guerra.', 153),
('Homem-Aranha: Sem Volta para Casa', 'A��o', 'Peter Parker lida com as consequ�ncias de revelar sua identidade.', 148),
('Frozen: Uma Aventura Congelante', 'Anima��o', 'Princesa com poderes m�gicos congela seu reino.', 102),
('Os Incr�veis', 'Anima��o', 'Fam�lia de super-her�is tenta viver uma vida normal.', 115),
('Homem de Ferro', 'A��o', 'Bilion�rio cria armadura para combater o crime.', 126),
('Toy Story', 'Anima��o', 'Brinquedos ganham vida quando os humanos n�o est�o por perto.', 81),
('Um Sonho de Liberdade', 'Drama', 'Amizade entre dois homens em uma pris�o.', 142),
('O Exorcista', 'Terror', 'Garota possu�da � submetida a um exorcismo.', 122),
('Se Beber, N�o Case!', 'Com�dia', 'Despedida de solteiro d� errado em Las Vegas.', 100),
('De Volta para o Futuro', 'Fic��o Cient�fica', 'Jovem viaja no tempo em um DeLorean.', 116),
('Whiplash: Em Busca da Perfei��o', 'Drama', 'Baterista tenta impressionar seu professor exigente.', 107),
('Jogos Vorazes', 'A��o', 'Jovem luta por sua vida em um torneio mortal.', 142),
('O Grande Truque', 'Drama', 'Dois m�gicos rivais em busca da melhor ilus�o.', 130),
('Clube da Luta', 'Drama', 'Homem cria um clube secreto para lutas.', 139),
('Kung Fu Panda', 'Anima��o', 'Panda improv�vel torna-se um her�i lend�rio.', 92),
('O Iluminado', 'Terror', 'Homem perde a sanidade em um hotel isolado.', 146),
('Velozes e Furiosos', 'A��o', 'Corridas de rua e a��o explosiva.', 107),
('Moana: Um Mar de Aventuras', 'Anima��o', 'Garota embarca em uma jornada para salvar sua ilha.', 107),
('Deadpool', 'Com�dia', 'Anti-her�i sarc�stico busca vingan�a.', 108),
('Capit�o Am�rica: O Primeiro Vingador', 'A��o', 'Homem comum se torna um super-soldado.', 124),
('Enrolados', 'Anima��o', 'Princesa com cabelo m�gico descobre o mundo.', 100);


-- Atualizar tabela Filmes para incluir CategoriaId como chave estrangeira
ALTER TABLE Filmes ADD CategoriaId INT NOT NULL DEFAULT 1;
ALTER TABLE Filmes ADD CONSTRAINT FK_Filmes_Categorias FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id);

-- Associar filmes �s categorias
UPDATE Filmes SET CategoriaId = 1 WHERE Genero = 'A��o';
UPDATE Filmes SET CategoriaId = 2 WHERE Genero = 'Drama';
UPDATE Filmes SET CategoriaId = 3 WHERE Genero = 'Com�dia';
UPDATE Filmes SET CategoriaId = 4 WHERE Genero = 'Anima��o';
UPDATE Filmes SET CategoriaId = 5 WHERE Genero = 'Fic��o Cient�fica';