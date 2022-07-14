-- Projet Final
-----------------------------------
-- Criando tabela USUARIOS (CRUD)
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
       user_experience VARCHAR2(30)
);

-- Criando sequência USUARIOS
CREATE SEQUENCE auto_increment_users
MINVALUE 1
START WITH 1
INCREMENT BY 1;

-- Criando trigger para incremento do código USUARIOS
CREATE OR REPLACE TRIGGER increment_id_user
BEFORE INSERT ON usuarios
FOR EACH ROW
BEGIN
  :new.id_user := auto_increment_users.NEXTVAL;
END;

-----------------------------------
-- Criando tabela CURSOS (CRUD)
CREATE TABLE courses (
       id_course NUMBER CONSTRAINT pk_id_course PRIMARY KEY,
       course_name VARCHAR2(30) NOT NULL,
       course_subtitle VARCHAR2(30) NOT NULL, 
       course_people_amt NUMBER,
       course_rating NUMBER,
       course_language VARCHAR2(30) NOT NULL,
       course_creatin_date DATE NOT NULL,
       course_description VARCHAR2(150) NOT NULL,
       course_requirements VARCHAR2(100) NOT NULL,
       course_time NUMBER NOT NULL,
       course_link VARCHAR2(150) NOT NULL,
       course_audience VARCHAR2(100) NOT NULL,
       course_learnings VARCHAR2(160),
       course_knowledge_level VARCHAR2(20) NOT NULL,
       course_message VARCHAR2(60),
       id_user NUMBER, -- tabela usuarios
       id_categorie NUMBER, -- tabela categorie
       id_course_price NUMBER -- tabela price courses
);

-- Criando sequência CURSOS
CREATE SEQUENCE auto_increment_courses
MINVALUE 1
START WITH 1
INCREMENT BY 1;

-- Criando trigger para incremento do código CURSOS
CREATE OR REPLACE TRIGGER increment_id_course
BEFORE INSERT ON courses
FOR EACH ROW
BEGIN
  :new.id_course := auto_increment_courses.NEXTVAL;
END;

-- Adicionar uma chave estrangeira CURSOS
ALTER TABLE courses
ADD CONSTRAINT fk_id_usersc 
FOREIGN KEY (id_user) REFERENCES usuarios(id_user);

-----------------------------------
-- Criando tabela USUARIOS e CURSOS (CREATE, READ, DELETE)
CREATE TABLE user_courses (
       id_user_course NUMBER CONSTRAINT pk_id_user_course PRIMARY KEY,
       id_user NUMBER, -- tabela usuarios
       id_course NUMBER -- tabela courses
);

-- Criando sequência USUARIOS e CURSOS
CREATE SEQUENCE auto_increment_user_courses
MINVALUE 1
START WITH 1
INCREMENT BY 1;

-- Criando trigger para incremento do código USUARIOS e CURSOS
CREATE OR REPLACE TRIGGER increment_id_user_course
BEFORE INSERT ON user_courses
FOR EACH ROW
BEGIN
  :new.id_user_course := auto_increment_user_courses.NEXTVAL;
END;

-- Adicionar duas chaves estrangeira USUARIOS e CURSOS
ALTER TABLE user_courses
ADD CONSTRAINT fk_id_user 
FOREIGN KEY (id_user) REFERENCES usuarios(id_user);

ALTER TABLE user_courses
ADD CONSTRAINT fk_id_course 
FOREIGN KEY (id_course) REFERENCES courses(id_course);

-----------------------------------
-- Criando tabela PREÇO CURSOS (CRUD)
CREATE TABLE price_courses (
       id_course_price NUMBER CONSTRAINT pk_id_course_price PRIMARY KEY,
       price_course_value NUMBER NOT NULL,
       price_course_coin VARCHAR2(3) NOT NULL,
       price_discount NUMBER
);

-- Criando sequência PREÇO CURSOS
CREATE SEQUENCE auto_increment_price_courses
MINVALUE 1
START WITH 1
INCREMENT BY 1;

-- Criando trigger para incremento do código PREÇO CURSOS
CREATE OR REPLACE TRIGGER increment_id_price_course
BEFORE INSERT ON price_courses
FOR EACH ROW
BEGIN
  :new.id_course_price := auto_increment_price_courses.NEXTVAL;
END;

-- Adicionar uma chave estrangeira CURSOS
ALTER TABLE courses
ADD CONSTRAINT fk_id_course_price 
FOREIGN KEY (id_course_price) REFERENCES price_courses(id_course_price);

-----------------------------------
-- Criando tabela CATEGORIAS (CRUD)
CREATE TABLE categories (
       id_categorie NUMBER CONSTRAINT pk_id_categorie PRIMARY KEY,
       categorie_name VARCHAR(30) NOT NULL
);

-- Criando sequência CATEGORIAS
CREATE SEQUENCE auto_increment_categories
MINVALUE 1
START WITH 1
INCREMENT BY 1;

-- Criando trigger para incremento do código CATEGORIAS
CREATE OR REPLACE TRIGGER increment_id_categorie
BEFORE INSERT ON categories
FOR EACH ROW
BEGIN
  :new.id_categorie := auto_increment_categories.NEXTVAL;
END;

-- Adicionar uma chave estrangeira CURSOS
ALTER TABLE courses
ADD CONSTRAINT fk_id_categorie 
FOREIGN KEY (id_categorie) REFERENCES categories(id_categorie);

-----------------------------------
-- Criando tabela INTERESSES (CRUD)
CREATE TABLE interests (
       id_interests NUMBER CONSTRAINT pk_id_interests PRIMARY KEY,
       id_user NUMBER -- tabela usuarios
);

-- Criando sequência INTERESSES
CREATE SEQUENCE auto_increment_interests
MINVALUE 1
START WITH 1
INCREMENT BY 1;

-- Criando trigger para incremento do código INTERESSES
CREATE OR REPLACE TRIGGER increment_id_interests
BEFORE INSERT ON interests
FOR EACH ROW
BEGIN
  :new.id_interests := auto_increment_interests.NEXTVAL;
END;

-- Adicionar uma chave estrangeira INTERESSES
ALTER TABLE interests
ADD CONSTRAINT fk_id_users 
FOREIGN KEY (id_user) REFERENCES usuarios(id_user);

-----------------------------------
-- Criando tabela AULAS (CRUD)
CREATE TABLE classes (
       id_class NUMBER CONSTRAINT pk_id_class PRIMARY KEY,
       class_title VARCHAR2(30),
       class_video VARCHAR2(150),
       class_complete NUMBER
);

-- Criando sequência AULAS
CREATE SEQUENCE auto_increment_classes
MINVALUE 1
START WITH 1
INCREMENT BY 1;

-- Criando trigger para incremento do código AULAS
CREATE OR REPLACE TRIGGER increment_id_class
BEFORE INSERT ON classes
FOR EACH ROW
BEGIN
  :new.id_class := auto_increment_classes.NEXTVAL;
END;

-----------------------------------
-- Criando tabela AVALIAÇÔES (CRUD)
CREATE TABLE ratings (
       id_rating NUMBER CONSTRAINT pk_id_rating PRIMARY KEY,
       rating_text VARCHAR2(150),
       id_user NUMBER, -- tabela usuarios
       id_course NUMBER -- tabela courses
);

-- Criando sequência AVALIAÇÔES
CREATE SEQUENCE auto_increment_ratings
MINVALUE 1
START WITH 1
INCREMENT BY 1;

-- Criando trigger para incremento do código AVALIAÇÔES
CREATE OR REPLACE TRIGGER increment_id_rating
BEFORE INSERT ON ratings
FOR EACH ROW
BEGIN
  :new.id_rating := auto_increment_ratings.NEXTVAL;
END;

-- Adicionar duas chaves estrangeira AVALIAÇÔES
ALTER TABLE ratings
ADD CONSTRAINT fk_id_usersi 
FOREIGN KEY (id_user) REFERENCES usuarios(id_user); 

ALTER TABLE ratings
ADD CONSTRAINT fk_id_courses
FOREIGN KEY (id_course) REFERENCES courses(id_course); 

-- PROCEDURES
-- Procedure para validar e não remover categoria caso tenha algum curso
CREATE OR REPLACE PROCEDURE validate_removal (id_categ NUMBER, returns VARCHAR2)
AS
    qtd_courses NUMBER;
BEGIN
  SELECT COUNT(*) INTO qtd_courses FROM courses WHERE id_categorie = id_categ;
    
   -- Condicional
   IF qtd_courses = 0 THEN
   DELETE FROM categories WHERE id_categorie = id_categ;
   returns := 'A categoria foi removida com sucesso!';
      ELSE
       returns := 'Não é possível remover a categoria, pois há cursos vinculados a ela.'; 
   END IF;   
END;

