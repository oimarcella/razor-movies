-- Inserir categorias
INSERT INTO Categorias (Nome) 
VALUES 
('Ação'), 
('Drama'), 
('Comédia'), 
('Animação'), 
('Ficção Científica');

-- Inserir 50 filmes na tabela Filmes
INSERT INTO Filmes (Titulo, Genero, Sinopse, Duracao) 
VALUES
('A Origem', 'Ficção Científica', 'Um ladrão invade sonhos para roubar segredos.', 148),
('O Poderoso Chefão', 'Drama', 'A saga de uma família mafiosa nos EUA.', 175),
('Parasita', 'Suspense', 'Família pobre infiltra-se na casa de uma família rica.', 132),
('Cidade de Deus', 'Crime', 'História de gangues em uma favela carioca.', 130),
('Titanic', 'Romance', 'Amor e tragédia no maior navio do mundo.', 195),
('Tropa de Elite', 'Ação', 'Um capitão enfrenta o tráfico no Rio de Janeiro.', 115),
('Os Vingadores', 'Ação', 'Heróis se unem para salvar o mundo.', 143),
('O Senhor dos Anéis: O Retorno do Rei', 'Fantasia', 'A batalha final contra Sauron.', 201),
('Pulp Fiction: Tempo de Violência', 'Crime', 'Histórias interligadas de violência e redenção.', 154),
('A Viagem de Chihiro', 'Animação', 'Garota entra em um mundo mágico e precisa resgatar seus pais.', 125),
('Avatar', 'Ficção Científica', 'Humanos exploram um planeta habitado por alienígenas.', 162),
('Corra!', 'Suspense', 'Jovem negro descobre segredos perturbadores na família da namorada.', 104),
('Coringa', 'Drama', 'A origem sombria de um dos vilões mais icônicos do cinema.', 122),
('Forrest Gump: O Contador de Histórias', 'Drama', 'Um homem simples vive momentos marcantes da história.', 142),
('Viva: A Vida é uma Festa', 'Animação', 'Garoto embarca em uma jornada pelo mundo dos mortos.', 105),
('A Bela e a Fera', 'Fantasia', 'Jovem descobre o verdadeiro amor em um castelo encantado.', 129),
('Matrix', 'Ficção Científica', 'A luta contra uma realidade simulada criada por máquinas.', 136),
('Pantera Negra', 'Ação', 'Rei africano protege seu reino e seu povo.', 134),
('Divertida Mente', 'Animação', 'As emoções de uma garota adolescente ganham vida.', 95),
('Gladiador', 'Drama', 'Um general romano busca vingança após ser traído.', 155),
('A Lista de Schindler', 'Histórico', 'Homem salva judeus durante o Holocausto.', 195),
('Vingadores: Ultimato', 'Ação', 'Heróis tentam reverter o dano causado por Thanos.', 181),
('Doze Homens e Uma Sentença', 'Drama', 'Júri decide o destino de um jovem acusado de assassinato.', 96),
('O Resgate do Soldado Ryan', 'Guerra', 'Missão para resgatar o único sobrevivente de uma família.', 169),
('Interestelar', 'Ficção Científica', 'Exploração espacial para salvar a humanidade.', 169),
('O Rei Leão', 'Animação', 'Jovem leão retorna para reivindicar seu trono.', 88),
('Shrek', 'Comédia', 'Ogro embarca em uma jornada para salvar uma princesa.', 90),
('Bastardos Inglórios', 'Guerra', 'Grupo de soldados caça nazistas durante a Segunda Guerra.', 153),
('Homem-Aranha: Sem Volta para Casa', 'Ação', 'Peter Parker lida com as consequências de revelar sua identidade.', 148),
('Frozen: Uma Aventura Congelante', 'Animação', 'Princesa com poderes mágicos congela seu reino.', 102),
('Os Incríveis', 'Animação', 'Família de super-heróis tenta viver uma vida normal.', 115),
('Homem de Ferro', 'Ação', 'Bilionário cria armadura para combater o crime.', 126),
('Toy Story', 'Animação', 'Brinquedos ganham vida quando os humanos não estão por perto.', 81),
('Um Sonho de Liberdade', 'Drama', 'Amizade entre dois homens em uma prisão.', 142),
('O Exorcista', 'Terror', 'Garota possuída é submetida a um exorcismo.', 122),
('Se Beber, Não Case!', 'Comédia', 'Despedida de solteiro dá errado em Las Vegas.', 100),
('De Volta para o Futuro', 'Ficção Científica', 'Jovem viaja no tempo em um DeLorean.', 116),
('Whiplash: Em Busca da Perfeição', 'Drama', 'Baterista tenta impressionar seu professor exigente.', 107),
('Jogos Vorazes', 'Ação', 'Jovem luta por sua vida em um torneio mortal.', 142),
('O Grande Truque', 'Drama', 'Dois mágicos rivais em busca da melhor ilusão.', 130),
('Clube da Luta', 'Drama', 'Homem cria um clube secreto para lutas.', 139),
('Kung Fu Panda', 'Animação', 'Panda improvável torna-se um herói lendário.', 92),
('O Iluminado', 'Terror', 'Homem perde a sanidade em um hotel isolado.', 146),
('Velozes e Furiosos', 'Ação', 'Corridas de rua e ação explosiva.', 107),
('Moana: Um Mar de Aventuras', 'Animação', 'Garota embarca em uma jornada para salvar sua ilha.', 107),
('Deadpool', 'Comédia', 'Anti-herói sarcástico busca vingança.', 108),
('Capitão América: O Primeiro Vingador', 'Ação', 'Homem comum se torna um super-soldado.', 124),
('Enrolados', 'Animação', 'Princesa com cabelo mágico descobre o mundo.', 100);


-- Atualizar tabela Filmes para incluir CategoriaId como chave estrangeira
ALTER TABLE Filmes ADD CategoriaId INT NOT NULL DEFAULT 1;
ALTER TABLE Filmes ADD CONSTRAINT FK_Filmes_Categorias FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id);

-- Associar filmes às categorias
UPDATE Filmes SET CategoriaId = 1 WHERE Genero = 'Ação';
UPDATE Filmes SET CategoriaId = 2 WHERE Genero = 'Drama';
UPDATE Filmes SET CategoriaId = 3 WHERE Genero = 'Comédia';
UPDATE Filmes SET CategoriaId = 4 WHERE Genero = 'Animação';
UPDATE Filmes SET CategoriaId = 5 WHERE Genero = 'Ficção Científica';