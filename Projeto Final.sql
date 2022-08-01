-- Projet Final
-----------------------------------
-- Criando tabela USUARIOS (CRUD)   == TABELA
CREATE TABLE usuarios (
       id_user NUMBER CONSTRAINT pk_id_user PRIMARY KEY,
       user_name VARCHAR2(50) NOT NULL,
       user_email VARCHAR2(60) NOT NULL,
       user_password VARCHAR2(30) NOT NULL,
       user_description VARCHAR2(80),
       user_link VARCHAR2(150),
       user_socialmedia VARCHAR2(150),
       user_profession VARCHAR(30),
       user_hours_week NUMBER,
       user_experience VARCHAR2(30),
       user_role VARCHAR2(30) NOT NULL
);

select * from usuarios;

-- Criando sequencia USUARIOS   == SEQUENCIA
CREATE SEQUENCE auto_increment_users
MINVALUE 1
START WITH 1
INCREMENT BY 1;

-- Criando trigger para incremento do codigo USUARIOS   == TRIGGER
CREATE OR REPLACE TRIGGER increment_id_user
BEFORE INSERT ON usuarios
FOR EACH ROW
BEGIN
  :new.id_user := auto_increment_users.NEXTVAL;
END;

-----------------------------------
-- Criando tabela CURSOS (CRUD)   == TABELA
CREATE TABLE courses (
       id_course NUMBER CONSTRAINT pk_id_course PRIMARY KEY,
       course_name VARCHAR2(30) NOT NULL,
       course_subtitle VARCHAR2(30) NOT NULL, 
       course_people_amt NUMBER,
       course_rating NUMBER,
       course_language VARCHAR2(30) NOT NULL,
       course_creation_date DATE NOT NULL,
       course_description VARCHAR2(150) NOT NULL,
       course_requirements VARCHAR2(100) NOT NULL,
       course_time NUMBER NOT NULL,
       course_link VARCHAR2(150) NOT NULL,
       course_audience VARCHAR2(100) NOT NULL,
       course_learnings VARCHAR2(160),
       course_knowledge_level VARCHAR2(20) NOT NULL,
       course_message VARCHAR2(60),
       id_author NUMBER, -- tabela usuarios
       id_categorie NUMBER, -- tabela categorie
       id_price_course NUMBER -- tabela price courses
);

-- Criando sequencia CURSOS   == SEQUENCIA
CREATE SEQUENCE auto_increment_courses
MINVALUE 1
START WITH 1
INCREMENT BY 1;

-- Criando trigger para incremento do codigo CURSOS   == TRIGGER
CREATE OR REPLACE TRIGGER increment_id_course
BEFORE INSERT ON courses
FOR EACH ROW
BEGIN
  :new.id_course := auto_increment_courses.NEXTVAL;
END;

-- Adicionar uma chave estrangeira CURSOS
ALTER TABLE courses
ADD CONSTRAINT fk_id_author
FOREIGN KEY (id_author) REFERENCES usuarios(id_user);

-----------------------------------
-- Criando tabela USUARIOS e CURSOS (CREATE, READ, DELETE)   == TABELA
CREATE TABLE user_courses (
       id_user_course NUMBER CONSTRAINT pk_id_user_course PRIMARY KEY,
       id_user NUMBER, -- tabela usuarios
       id_course NUMBER -- tabela courses
);

-- Criando sequencia USUARIOS e CURSOS   == SEQUENCIA
CREATE SEQUENCE auto_increment_user_courses
MINVALUE 1
START WITH 1
INCREMENT BY 1;

-- Criando trigger para incremento do codigo USUARIOS e CURSOS   == TRIGGER
CREATE OR REPLACE TRIGGER increment_id_user_course
BEFORE INSERT ON user_courses
FOR EACH ROW
BEGIN
  :new.id_user_course := auto_increment_user_courses.NEXTVAL;
END;

-- Adicionar duas chaves estrangeira USUARIOS e CURSOS
ALTER TABLE user_courses
ADD CONSTRAINT fk_id_user_usercourses
FOREIGN KEY (id_user) REFERENCES usuarios(id_user);

ALTER TABLE user_courses
ADD CONSTRAINT fk_id_course_usercourses
FOREIGN KEY (id_course) REFERENCES courses(id_course);

-----------------------------------
-- Criando tabela PRECO CURSOS (CRUD)   == TABELA
CREATE TABLE price_courses (
       id_price_course NUMBER CONSTRAINT pk_id_price_course PRIMARY KEY,
       price_course_value NUMBER NOT NULL,
       price_course_coin VARCHAR2(3) NOT NULL,
       price_discount NUMBER
);

-- Criando sequencia PRECO CURSOS   == SEQUENCIA
CREATE SEQUENCE auto_increment_price_courses
MINVALUE 1
START WITH 1
INCREMENT BY 1;

-- Criando trigger para incremento do codigo PRECO CURSOS   == TRIGGER
CREATE OR REPLACE TRIGGER increment_id_price_course
BEFORE INSERT ON price_courses
FOR EACH ROW
BEGIN
  :new.id_price_course := auto_increment_price_courses.NEXTVAL;
END;

-- Adicionar uma chave estrangeira CURSOS
ALTER TABLE courses
ADD CONSTRAINT fk_id_price_course
FOREIGN KEY (id_price_course) REFERENCES price_courses(id_price_course);

-----------------------------------
-- Criando tabela CATEGORIAS (CRUD)   == TABELA
CREATE TABLE categories (
       id_categorie NUMBER CONSTRAINT pk_id_categorie PRIMARY KEY,
       categorie_name VARCHAR(30) NOT NULL
);

-- Criando sequencia CATEGORIAS   == SEQUENCIA
CREATE SEQUENCE auto_increment_categories
MINVALUE 1
START WITH 1
INCREMENT BY 1;

-- Criando trigger para incremento do codigo CATEGORIAS   == TRIGGER
CREATE OR REPLACE TRIGGER increment_id_categorie
BEFORE INSERT ON categories
FOR EACH ROW
BEGIN
  :new.id_categorie := auto_increment_categories.NEXTVAL;
END;

-- Adicionar uma chave estrangeira CURSOS
ALTER TABLE courses
ADD CONSTRAINT fk_id_categorie_courses
FOREIGN KEY (id_categorie) REFERENCES categories(id_categorie);

-----------------------------------
-- Criando tabela INTERESSES (CRUD)   == TABELA
CREATE TABLE interests (
       id_interests NUMBER CONSTRAINT pk_id_interests PRIMARY KEY,
       id_user NUMBER, -- tabela usuarios
       id_categorie NUMBER -- tabela categories
);

-- Criando sequencia INTERESSES   == SEQUENCIA
CREATE SEQUENCE auto_increment_interests
MINVALUE 1
START WITH 1
INCREMENT BY 1;

-- Criando trigger para incremento do codigo INTERESSES   == TRIGGER
CREATE OR REPLACE TRIGGER increment_id_interest
BEFORE INSERT ON interests
FOR EACH ROW
BEGIN
  :new.id_interests := auto_increment_interests.NEXTVAL;
END;

-- Adicionar uma chave estrangeira INTERESSES
ALTER TABLE interests
ADD CONSTRAINT fk_id_user_interests
FOREIGN KEY (id_user) REFERENCES usuarios(id_user);

ALTER TABLE interests
ADD CONSTRAINT fk_id_categorie_interests
FOREIGN KEY (id_categorie) REFERENCES categories(id_categorie);

-----------------------------------
-- Criando tabela AULAS (CRUD)   == TABELA
CREATE TABLE classes (
       id_class NUMBER CONSTRAINT pk_id_class PRIMARY KEY,
       class_title VARCHAR2(30),
       class_video VARCHAR2(150),
       class_complete NUMBER,
       id_course NUMBER
);

-- Criando sequencia AULAS   == SEQUENCIA
CREATE SEQUENCE auto_increment_classes
MINVALUE 1
START WITH 1
INCREMENT BY 1;

-- Criando trigger para incremento do codigo AULAS   == TRIGGER
CREATE OR REPLACE TRIGGER increment_id_class
BEFORE INSERT ON classes
FOR EACH ROW
BEGIN
  :new.id_class := auto_increment_classes.NEXTVAL;
END;

-- Adicionar uma chave estrangeira AULAS
ALTER TABLE classes
ADD CONSTRAINT fk_id_course_classes
FOREIGN KEY (id_course) REFERENCES courses(id_course); 

-----------------------------------
-- Criando tabela AVALIACOES (CRUD)   == TABELA
CREATE TABLE ratings (
       id_rating NUMBER CONSTRAINT pk_id_rating PRIMARY KEY,
       rating_text VARCHAR2(150),
       id_user NUMBER, -- tabela usuarios
       id_course NUMBER -- tabela courses
);

-- Criando sequencia AVALIACOES   == SEQUENCIA
CREATE SEQUENCE auto_increment_ratings
MINVALUE 1
START WITH 1
INCREMENT BY 1;

-- Criando trigger para incremento do codigo AVALIACOES   == TRIGGER
CREATE OR REPLACE TRIGGER increment_id_rating
BEFORE INSERT ON ratings
FOR EACH ROW
BEGIN
  :new.id_rating := auto_increment_ratings.NEXTVAL;
END;

-- Adicionar duas chaves estrangeira AVALIACOES
ALTER TABLE ratings
ADD CONSTRAINT fk_id_user_ratings
FOREIGN KEY (id_user) REFERENCES usuarios(id_user); 

ALTER TABLE ratings
ADD CONSTRAINT fk_id_course_ratings
FOREIGN KEY (id_course) REFERENCES courses(id_course); 

-----------------------------------
-- Criando tabela DESEJOS (CRUD)   == TABELA
CREATE TABLE wishes (
       id_wish NUMBER CONSTRAINT pk_id_wish PRIMARY KEY,
       id_user NUMBER, -- tabela usuarios
       id_course NUMBER -- tabela courses
);

-- Criando sequencia DESEJOS   == SEQUENCIA
CREATE SEQUENCE auto_increment_wishes
MINVALUE 1
START WITH 1
INCREMENT BY 1;

-- Criando trigger para incremento do codigo DESEJOS   == TRIGGER
CREATE OR REPLACE TRIGGER increment_id_wish
BEFORE INSERT ON wishes
FOR EACH ROW
BEGIN
  :new.id_wish := auto_increment_wishes.NEXTVAL;
END;

-- Adicionar duas chaves estrangeira DESEJOS
ALTER TABLE wishes
ADD CONSTRAINT fk_id_user_wishes
FOREIGN KEY (id_user) REFERENCES usuarios(id_user); 

ALTER TABLE wishes
ADD CONSTRAINT fk_id_course_wishes
FOREIGN KEY (id_course) REFERENCES courses(id_course); 

-----------------------------------
-- Criando tabela SUBCATEGORIAS (CRUD)   == TABELA
CREATE TABLE subcategories (
       id_subcategorie NUMBER CONSTRAINT pk_id_subcategorie PRIMARY KEY,
       subcategorie_name VARCHAR2(30),
       id_categorie NUMBER -- tabela categories
);

-- Criando sequencia SUBCATEGORIAS   == SEQUENCIA
CREATE SEQUENCE auto_increment_subcategories
MINVALUE 1
START WITH 1
INCREMENT BY 1;

-- Criando trigger para incremento do codigo SUBCATEGORIAS   == TRIGGER
CREATE OR REPLACE TRIGGER increment_id_subcategorie
BEFORE INSERT ON subcategories
FOR EACH ROW
BEGIN
  :new.id_subcategorie := auto_increment_subcategories.NEXTVAL;
END;

-- Adicionar uma chave estrangeira SUBCATEGORIAS
ALTER TABLE subcategories
ADD CONSTRAINT fk_id_categorie_subcategories
FOREIGN KEY (id_categorie) REFERENCES categories(id_categorie);

-----------------------------------
-- Criando tabela SUBTEMAS (CRUD)   == TABELA
CREATE TABLE sub_themes (
       id_sub_theme NUMBER CONSTRAINT pk_id_sub_theme PRIMARY KEY,
       sub_theme_name VARCHAR2(30),
       id_subcategorie NUMBER -- tabela subcategories
);

-- Criando sequencia SUBCATEGORIAS   == SEQUENCIA
CREATE SEQUENCE auto_increment_sub_themes
MINVALUE 1
START WITH 1
INCREMENT BY 1;

-- Criando trigger para incremento do codigo SUBCATEGORIAS   == TRIGGER
CREATE OR REPLACE TRIGGER increment_id_sub_theme
BEFORE INSERT ON sub_themes
FOR EACH ROW
BEGIN
  :new.id_sub_theme := auto_increment_sub_themes.NEXTVAL;
END;

-- Adicionar uma chave estrangeira SUBCATEGORIAS
ALTER TABLE sub_themes
ADD CONSTRAINT fk_id_subcategorie_sub_themes
FOREIGN KEY (id_subcategorie) REFERENCES subcategories(id_subcategorie);

-----------------------------------
-- Criando tabela SECAO CURSO (CRUD)   == TABELA
CREATE TABLE course_sections (
       id_course_sect NUMBER CONSTRAINT pk_id_course_sect PRIMARY KEY,
       course_sect_name VARCHAR2(50) NOT NULL,
       id_course NUMBER -- tabela courses
);

-- Criando sequencia SECAO CURSO   == SEQUENCIA
CREATE SEQUENCE auto_increment_course_sections
MINVALUE 1
START WITH 1
INCREMENT BY 1;

-- Criando trigger para incremento do codigo SECAO CURSO   == TRIGGER
CREATE OR REPLACE TRIGGER increment_id_course_sect
BEFORE INSERT ON course_sections
FOR EACH ROW
BEGIN
  :new.id_course_sect := auto_increment_course_sections.NEXTVAL;
END;

-- Adicionar uma chave estrangeira SECAO CURSO
ALTER TABLE course_sections
ADD CONSTRAINT fk_id_course_course_sections
FOREIGN KEY (id_course) REFERENCES courses(id_course);

-- Criando tabela PAGSEGURO   == TABELA
CREATE TABLE pagseguro (
       pagseguro_name VARCHAR2(50) NOT NULL,
       pagseguro_email VARCHAR2(50) NOT NULL,
       pagseguro_cpf VARCHAR2(11) NOT NULL
);

-- PROCEDURES
-- Procedure para validar e nao remover categoria caso tenha algum curso
CREATE OR REPLACE PROCEDURE validate_removal (id_categ IN NUMBER, returns OUT VARCHAR2)
AS
    qtd_courses NUMBER;
BEGIN
   SELECT COUNT(*) INTO qtd_courses FROM courses WHERE id_categorie = id_categ;
    
   -- Condicional
   IF qtd_courses = 0 THEN
   DELETE FROM categories WHERE id_categorie = id_categ;
   dbms_output.put_line('A categoria foi removida com sucesso!');
      ELSE
       dbms_output.put_line('Nao foi possivel remover a categoria, pois existem cursos vinculados a ela.'); 
   END IF;   
END;

-- Procedure para validar e nao remover cursos caso tenha em algum aluno
CREATE OR REPLACE PROCEDURE validate_course (id_cours IN NUMBER, returns OUT VARCHAR2)
AS
    qtd_student NUMBER;
BEGIN
   SELECT COUNT(*) INTO qtd_student FROM user_courses WHERE id_course = id_cours;
    
   -- Condicional
   IF qtd_student = 0 THEN
   DELETE FROM courses WHERE id_course = id_cours;
   dbms_output.put_line('O curso foi removido com sucesso!');
      ELSE
       dbms_output.put_line('Nao foi possivel remover o curso, pois existem alunos vinculados a ele.'); 
   END IF;   
END;

-- Procedure para validar e nao remover instrutores caso tenha em algum aluno em um de seus cursos
CREATE OR REPLACE PROCEDURE validate_instructor (id_instructor IN NUMBER, id_cours IN NUMBER, returns OUT VARCHAR2)
AS
    qtd_instructor NUMBER;
    qtd_student NUMBER;
BEGIN
   SELECT COUNT(*) INTO qtd_student FROM user_courses WHERE id_course = id_cours;
   SELECT COUNT(*) INTO qtd_instructor FROM courses WHERE id_author = id_instructor;
    
   -- Condicional
   IF qtd_instructor = 0 AND qtd_student = 0 THEN
   DELETE FROM usuarios WHERE id_user = id_instructor;
   dbms_output.put_line('O instrutor foi removido com sucesso!');
      ELSE
       dbms_output.put_line('Nao foi possivel remover o instrutor, pois existem cursos com alunos vinculados a ele.'); 
   END IF;   
END;

-- Comando para formatar data em DD/MM/YYYY
SELECT TO_CHAR(course_creation_date, 'DD/MM/YYYY') AS format_date FROM courses;

-- Comando para selecionar os cursos da categoria
SELECT courses.id_categorie FROM courses INNER JOIN categories ON categories.id_categorie = courses.id_categorie WHERE courses.id_categorie = categories.id_categorie;

-- Comando para criar ligacao com o valor e o curso
SELECT * FROM courses INNER JOIN price_courses ON price_courses.id_price_course = courses.id_price_course WHERE price_courses.id_course = courses.id_course;

-- Comando para criar ligacao dos desejos com cursos
SELECT wishes.id_course FROM wishes INNER JOIN courses ON courses.id_course = wishes.id_course INNER JOIN usuarios ON usuarios.id_user = wishes.id_user WHERE wishes.id_course = courses.id_course;

-- Comando para listar categorias nos interesses
SELECT interests.id_categorie FROM interests INNER JOIN categories ON categories.id_categorie = interests.id_categorie INNER JOIN usuarios ON usuarios.id_user = interests.id_user WHERE interests.id_categorie = categories.id_categorie;

-- Comando para criar ligacao com os comentarios, curso e usuario
SELECT ratings.id_rating FROM ratings INNER JOIN courses ON courses.id_course = ratings.id_course INNER JOIN usuarios ON usuarios.id_user = ratings.id_user WHERE ratings.id_course = courses.id_course;

-- Comando para conectar o curso com a aula
SELECT classes.id_course FROM classes INNER JOIN courses ON courses.id_course = classes.id_course WHERE classes.id_course = courses.id_course;

-- Comando para conectar a subcategoria com a categoria
SELECT subcategories.id_categorie FROM subcategories INNER JOIN categories ON categories.id_categorie = subcategories.id_categorie WHERE subcategories.id_categorie = categories.id_categorie;

-- Comando para conectar o sub tema com a subcategoria
SELECT sub_themes.id_subcategorie FROM sub_themes INNER JOIN subcategories ON subcategories.id_subcategorie = sub_themes.id_subcategorie WHERE sub_themes.id_subcategorie = subcategories.id_subcategorie;

-- Comando para conectar o curso com as seções de curso
SELECT course_sections.id_course FROM course_sections INNER JOIN courses ON courses.id_course = course_sections.id_course WHERE course_sections.id_course = courses.id_course;

-- Comando para retornar dados curso, nome categoria, nome autor e preço curso
SELECT
   courses.*,
   categories.categorie_name,
   usuarios.user_name,
   price_courses.price_course_value,
   price_courses.price_course_coin
FROM courses
INNER JOIN usuarios
ON courses.id_author = usuarios.id_user

INNER JOIN categories
ON courses.id_categorie = categories.id_categorie

INNER JOIN price_courses
ON courses.id_price_course = price_courses.id_price_course;

-- Exclusão
-- Procedures
DROP PROCEDURE validate_removal;    

-- Triggers
DROP TRIGGER increment_id_course_sect;   
DROP TRIGGER increment_id_categorie;   
DROP TRIGGER increment_id_class;   
DROP TRIGGER increment_id_course;   
DROP TRIGGER increment_id_interests;   
DROP TRIGGER increment_id_price_course;   
DROP TRIGGER increment_id_rating;   
DROP TRIGGER increment_id_subcategorie;
DROP TRIGGER increment_id_sub_theme;  
DROP TRIGGER increment_id_user;   
DROP TRIGGER increment_id_user_course;
DROP TRIGGER increment_id_wishe;

-- Sequences
DROP SEQUENCE auto_increment_course_sections;   
DROP SEQUENCE auto_increment_categories;   
DROP SEQUENCE auto_increment_classes;   
DROP SEQUENCE auto_increment_courses;   
DROP SEQUENCE auto_increment_interests;   
DROP SEQUENCE auto_increment_price_courses;   
DROP SEQUENCE auto_increment_ratings;   
DROP SEQUENCE auto_increment_subcategories;
DROP SEQUENCE auto_increment_sub_themes;  
DROP SEQUENCE auto_increment_users;   
DROP SEQUENCE auto_increment_user_courses;
DROP SEQUENCE auto_increment_wishes;

-- VIEWS
/*
DROP VIEW connect_course;
DROP VIEW connect_wishes;
DROP VIEW connect_interests;
DROP VIEW connect_ratings;
DROP VIEW connect_subcategorie;
DROP VIEW connect_sub_theme;
DROP VIEW connect_course_sect;
DROP VIEW connect_classes;
DROP VIEW connect_categorie;
*/

-- Tables
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

select * from courses;
