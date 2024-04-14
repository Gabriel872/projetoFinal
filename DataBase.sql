-- Projet Final
-- ---------------------------------
-- Criando tabela USUARIOS (CRUD)   == TABELA
CREATE TABLE usuarios (
       id_user INT AUTO_INCREMENT PRIMARY KEY,
       user_name VARCHAR(50) NOT NULL,
       user_email VARCHAR(60) NOT NULL,
       user_password VARCHAR(30) NOT NULL,
       user_description VARCHAR(80),
       user_link VARCHAR(150),
       user_socialmedia VARCHAR(150),
       user_profession VARCHAR(30),
       user_hours_week INT,
       user_experience VARCHAR(30),
       user_role VARCHAR(30) NOT NULL
);

-- ---------------------------------
-- Criando tabela CURSOS (CRUD)   == TABELA
CREATE TABLE courses (
       id_course INT AUTO_INCREMENT PRIMARY KEY,
       course_name VARCHAR(30) NOT NULL,
       course_subtitle VARCHAR(30) NOT NULL, 
       course_people_amt INT,
       course_rating INT,
       course_language VARCHAR(30) NOT NULL,
       course_creation_date DATE NOT NULL,
       course_description VARCHAR(150) NOT NULL,
       course_requirements VARCHAR(100) NOT NULL,
       course_time INT NOT NULL,
       course_link VARCHAR(150) NOT NULL,
       course_audience VARCHAR(100) NOT NULL,
       course_learnings VARCHAR(160),
       course_knowledge_level VARCHAR(20) NOT NULL,
       course_message VARCHAR(60),
       id_author INT, -- tabela usuarios
       id_category INT, -- tabela categorie
       id_price_course INT -- tabela price courses
);

-- Adicionar uma chave estrangeira CURSOS
ALTER TABLE courses
ADD CONSTRAINT fk_id_author
FOREIGN KEY (id_author) REFERENCES usuarios(id_user);

-- ---------------------------------
-- Criando tabela USUARIOS e CURSOS (CREATE, READ, DELETE)   == TABELA
CREATE TABLE user_courses (
       id_user_course INT auto_increment primary key,
       id_user int, -- tabela usuarios
       id_course int -- tabela courses
);

-- Adicionar duas chaves estrangeira USUARIOS e CURSOS
ALTER TABLE user_courses
ADD CONSTRAINT fk_id_user_usercourses
FOREIGN KEY (id_user) REFERENCES usuarios(id_user);

ALTER TABLE user_courses
ADD CONSTRAINT fk_id_course_usercourses
FOREIGN KEY (id_course) REFERENCES courses(id_course);

-- ---------------------------------
-- Criando tabela PRECO CURSOS (CRUD)   == TABELA
CREATE TABLE price_courses (
       id_price_course int auto_increment PRIMARY KEY,
       price_course_value int NOT NULL,
       price_course_coin VARCHAR(3) NOT NULL,
       price_discount int
);

-- Adicionar uma chave estrangeira CURSOS
ALTER TABLE courses
ADD CONSTRAINT fk_id_price_course
FOREIGN KEY (id_price_course) REFERENCES price_courses(id_price_course);

-- ---------------------------------
-- Criando tabela CATEGORIAS (CRUD)   == TABELA
CREATE TABLE categories (
       id_category int auto_increment PRIMARY KEY,
       category_name VARCHAR(30) NOT NULL
);

-- Adicionar uma chave estrangeira CURSOS
ALTER TABLE courses
ADD CONSTRAINT fk_id_category_courses
FOREIGN KEY (id_category) REFERENCES categories(id_category);

-- ---------------------------------
-- Criando tabela INTERESSES (CRUD)   == TABELA
CREATE TABLE interests (
       id_interests int auto_increment PRIMARY KEY,
       id_user int, -- tabela usuarios
       id_category int -- tabela categories
);

-- Adicionar uma chave estrangeira INTERESSES
ALTER TABLE interests
ADD CONSTRAINT fk_id_user_interests
FOREIGN KEY (id_user) REFERENCES usuarios(id_user);

ALTER TABLE interests
ADD CONSTRAINT fk_id_category_interests
FOREIGN KEY (id_category) REFERENCES categories(id_category);

-- ---------------------------------
-- Criando tabela AULAS (CRUD)   == TABELA
CREATE TABLE classes (
       id_class int auto_increment PRIMARY KEY,
       class_title VARCHAR(30),
       class_video VARCHAR(150),
       class_complete int,
       id_course int
);

-- Adicionar uma chave estrangeira AULAS
ALTER TABLE classes
ADD CONSTRAINT fk_id_course_classes
FOREIGN KEY (id_course) REFERENCES courses(id_course); 

-- ---------------------------------
-- Criando tabela AVALIACOES (CRUD)   == TABELA
CREATE TABLE ratings (
       id_rating int auto_increment KEY,
       rating_text VARCHAR(150),
       id_user int, -- tabela usuarios
       id_course int -- tabela courses
);

-- Adicionar duas chaves estrangeira AVALIACOES
ALTER TABLE ratings
ADD CONSTRAINT fk_id_user_ratings
FOREIGN KEY (id_user) REFERENCES usuarios(id_user); 

ALTER TABLE ratings
ADD CONSTRAINT fk_id_course_ratings
FOREIGN KEY (id_course) REFERENCES courses(id_course); 

-- ---------------------------------
-- Criando tabela DESEJOS (CRUD)   == TABELA
CREATE TABLE wishes (
       id_wish int auto_increment PRIMARY KEY,
       id_user int, -- tabela usuarios
       id_course int -- tabela courses
);

-- Adicionar duas chaves estrangeira DESEJOS
ALTER TABLE wishes
ADD CONSTRAINT fk_id_user_wishes
FOREIGN KEY (id_user) REFERENCES usuarios(id_user); 

ALTER TABLE wishes
ADD CONSTRAINT fk_id_course_wishes
FOREIGN KEY (id_course) REFERENCES courses(id_course); 

-- ---------------------------------
-- Criando tabela SUBCATEGORIAS (CRUD)   == TABELA
CREATE TABLE subcategories (
       id_subcategory int auto_increment PRIMARY KEY,
       subcategory_name int(30),
       id_category int -- tabela categories
);

-- Adicionar uma chave estrangeira SUBCATEGORIAS
ALTER TABLE subcategories
ADD CONSTRAINT fk_id_category_subcategories
FOREIGN KEY (id_category) REFERENCES categories(id_category);

-- ---------------------------------
-- Criando tabela SUBTEMAS (CRUD)   == TABELA
CREATE TABLE sub_themes (
       id_sub_theme int auto_increment PRIMARY KEY,
       sub_theme_name VARCHAR(30),
       id_subcategory int -- tabela subcategories
);

-- Adicionar uma chave estrangeira SUBCATEGORIAS
ALTER TABLE sub_themes
ADD CONSTRAINT fk_id_subcategory_sub_themes
FOREIGN KEY (id_subcategory) REFERENCES subcategories(id_subcategory);

-- ---------------------------------
-- Criando tabela SECAO CURSO (CRUD)   == TABELA
CREATE TABLE course_sections (
       id_course_sect int auto_increment PRIMARY KEY,
       course_sect_name VARCHAR(50) NOT NULL,
       id_course int -- tabela courses
);

-- Adicionar uma chave estrangeira SECAO CURSO
ALTER TABLE course_sections
ADD CONSTRAINT fk_id_course_course_sections
FOREIGN KEY (id_course) REFERENCES courses(id_course);

-- Criando tabela PAGSEGURO   == TABELA
CREATE TABLE pagseguro (
       pagseguro_name VARCHAR(50) NOT NULL,
       pagseguro_email VARCHAR(50) NOT NULL,
       pagseguro_cpf VARCHAR(11) NOT NULL
);

-- PROCEDURES
-- Procedure para validar e nao remover categoria caso tenha algum curso
DELIMITER //
Create PROCEDURE validate_removal (in id_categ int, out returns VARCHAR(255))
BEGIN
	declare qtd_courses int;
    
	SELECT 
    COUNT(*)
INTO qtd_courses FROM
    courses
WHERE
    id_category = id_categ;
    
   -- Condicional
   IF qtd_courses = 0 THEN
   DELETE FROM categories WHERE id_category = id_categ;
   set returns = 'A categoria foi removida com sucesso!';
      ELSE
       set returns = 'Nao foi possivel remover a categoria, pois existem cursos vinculados a ela.'; 
   END IF;   
END //
DELIMITER ;

DELIMITER //
-- Procedure para validar e nao remover cursos caso tenha em algum aluno
CREATE PROCEDURE validate_course (in id_cours int, out returns VARCHAR(255))
BEGIN
	declare qtd_student int;
   
SELECT 
    COUNT(*)
INTO qtd_student FROM
    user_courses
WHERE
    id_course = id_cours;
    
   -- Condicional
   IF qtd_student = 0 THEN
	DELETE FROM courses WHERE id_course = id_cours;
   set returns = 'O curso foi removido com sucesso!';
      ELSE
       set returns = 'Nao foi possivel remover o curso, pois existem alunos vinculados a ele.'; 
   END IF;   
END //
DELIMITER ;

-- Procedure para validar e nao remover instrutores caso tenha em algum aluno em um de seus cursos
DELIMITER //
CREATE PROCEDURE validate_instructor (in id_instructor int, in id_cours int, out returns VARCHAR(255))
BEGIN
	declare qtd_instructor int;
    declare qtd_student int;
    
SELECT 
    COUNT(*)
INTO qtd_student FROM
    user_courses
WHERE
    id_course = id_cours;
SELECT 
    COUNT(*)
INTO qtd_instructor FROM
    courses
WHERE
    id_author = id_instructor;
    
   -- Condicional
   IF qtd_instructor = 0 AND qtd_student = 0 THEN
   DELETE FROM usuarios WHERE id_user = id_instructor;
   set returns = 'O instrutor foi removido com sucesso!';
      ELSE
       set returns = 'Nao foi possivel remover o instrutor, pois existem cursos com alunos vinculados a ele.'; 
   END IF;   
END //
DELIMITER ;

SELECT 
    *
FROM
    courses
        JOIN
    price_courses ON price_courses.id_price_course = courses.id_price_course
WHERE
    price_courses.id_price_course = courses.id_course;

-- Comando para formatar data em DD/MM/YYYY
SELECT 
    DATE_FORMAT(course_creation_date, '%d/%m/%Y') AS format_date
FROM
    courses;

-- Comando para selecionar os cursos da categoria
SELECT 
    courses.id_category
FROM
    courses
        JOIN
    categories ON categories.id_category = courses.id_category
WHERE
    courses.id_category = categories.id_category;

-- Comando para criar ligacao com o valor e o curso
SELECT 
    *
FROM
    courses
        JOIN
    price_courses ON price_courses.id_price_course = courses.id_price_course
WHERE
    price_courses.id_price_course = courses.id_course;

-- Comando para criar ligacao dos desejos com cursos
SELECT 
    wishes.id_course
FROM
    wishes
        JOIN
    courses ON courses.id_course = wishes.id_course
        JOIN
    usuarios ON usuarios.id_user = wishes.id_user
WHERE
    wishes.id_course = courses.id_course;

-- Comando para listar categorias nos interesses
SELECT 
    interests.id_category
FROM
    interests
        JOIN
    categories ON categories.id_category = interests.id_category
        JOIN
    usuarios ON usuarios.id_user = interests.id_user
WHERE
    interests.id_category = categories.id_category;

-- Comando para criar ligacao com os comentarios, curso e usuario
SELECT 
    ratings.id_rating
FROM
    ratings
        JOIN
    courses ON courses.id_course = ratings.id_course
        JOIN
    usuarios ON usuarios.id_user = ratings.id_user
WHERE
    ratings.id_course = courses.id_course;

-- Comando para conectar o curso com a aula
SELECT 
    classes.id_course
FROM
    classes
        JOIN
    courses ON courses.id_course = classes.id_course
WHERE
    classes.id_course = courses.id_course;

-- Comando para conectar a subcategoria com a categoria
SELECT 
    subcategories.id_category
FROM
    subcategories
        JOIN
    categories ON categories.id_category = subcategories.id_category
WHERE
    subcategories.id_category = categories.id_category;

-- Comando para conectar o sub tema com a subcategoria
SELECT 
    sub_themes.id_subcategory
FROM
    sub_themes
        JOIN
    subcategories ON subcategories.id_subcategory = sub_themes.id_subcategory
WHERE
    sub_themes.id_subcategory = subcategories.id_subcategory;

-- Comando para conectar o curso com as se��es de curso
SELECT 
    course_sections.id_course
FROM
    course_sections
        JOIN
    courses ON courses.id_course = course_sections.id_course
WHERE
    course_sections.id_course = courses.id_course;

-- Comando para retornar dados curso, nome categoria, nome autor e pre�o curso
SELECT 
    courses.*,
    categories.category_name,
    usuarios.user_name,
    price_courses.price_course_value,
    price_courses.price_course_coin,
    price_courses.price_discount
FROM
    courses
        JOIN
    usuarios ON courses.id_author = usuarios.id_user
        JOIN
    categories ON courses.id_category = categories.id_category
        JOIN
    price_courses ON courses.id_price_course = price_courses.id_price_course;



-- Comando para retornar curso conforme termo digitado (nome curso, nome autor, nome categoria 1.0
SELECT 
    courses.course_name
FROM
    courses
        JOIN
    usuarios ON courses.id_author = usuarios.id_user
        JOIN
    categories ON courses.id_category = categories.id_category
WHERE
    courses.course_name LIKE '%a%';

-- Comando para retornar curso conforme termo digitado (nome curso, nome autor, nome categoria 2.0
SELECT 
    courses.id_course
FROM
    courses
        JOIN
    usuarios ON courses.id_author = usuarios.id_user
        JOIN
    categories ON courses.id_category = categories.id_category
WHERE
    courses.course_name LIKE '%Java%';
    
-- Exclus�o
-- Procedures
/*
DROP PROCEDURE validate_removal;    
DROP PROCEDURE validate_course;
DROP PROCEDURE validate_instructor;
*/
-- Tables
/*
DROP TABLE categories;   
DROP TABLE classes;   
DROP TABLE courses;   
DROP TABLE course_sections;   
DROP TABLE interests;   
DROP TABLE price_courses;   
DROP TABLE ratings;   
DROP TABLE subcategories;
DROP TABLE sub_themes;  
DROP TABLE user_courses;   
DROP TABLE usuarios;
DROP TABLE pagseguro;
DROP TABLE wishes;
*/

SELECT 
    courses.*,
    usuarios.user_name,
    price_courses.price_course_value
FROM
    user_courses
        JOIN
    courses ON courses.id_course = user_courses.id_course
        JOIN
    usuarios ON usuarios.id_user = user_courses.id_user
        JOIN
    price_courses ON price_courses.id_price_course = courses.id_price_course
WHERE
    user_courses.id_user = 1;
