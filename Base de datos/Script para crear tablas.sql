#Creación de base de datos
CREATE DATABASE IF NOT EXISTS sistema;

#Usar base de datos creada
USE sistema;

#TABLA ROL
CREATE TABLE rol (
  id_rol INT PRIMARY KEY,
  tipo_de_usuario VARCHAR(255)
);

#TABLA USUARIO
CREATE TABLE usuario (
  id_usuario INT AUTO_INCREMENT PRIMARY KEY,
  nombre_usuario VARCHAR(255),
  pass VARCHAR(255),
  id_rol INT,
  FOREIGN KEY (id_rol) REFERENCES rol(id_rol)
);

#TABLA PROFESOR
CREATE TABLE profesor (
  id_profesor INT AUTO_INCREMENT PRIMARY KEY,
  nombre VARCHAR(255),
  apellido VARCHAR(255),
  titulo VARCHAR(255),
  id_usuario INT,
  FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario)
);

#TABLA MATERIA
CREATE TABLE materia (
  id_materia INT AUTO_INCREMENT PRIMARY KEY,
  nombre VARCHAR(255),
  descripcion VARCHAR(255),
  aula VARCHAR(255),
  escuela VARCHAR(255),
  abreviatura VARCHAR(5),
  id_profesor INT,
  FOREIGN KEY (id_profesor) REFERENCES profesor(id_profesor)
);

CREATE TABLE estudiante (
  id_estudiante VARCHAR(255) PRIMARY KEY,
  nombre VARCHAR(255),
  apellido VARCHAR(255),
  fecha_de_nacimiento DATE,
  género CHAR(1),
  dirección VARCHAR(255),
  teléfono VARCHAR(255),
  correo_electrónico VARCHAR(255),
  id_usuario INT,
  FOREIGN KEY (id_usuario) REFERENCES usuario(id_usuario)
);

#TABLA MATRÍCULA
CREATE TABLE matricula (
  id_matricula INT AUTO_INCREMENT PRIMARY KEY,
  id_estudiante VARCHAR(255),
  id_materia INT,
  estado VARCHAR(255),
  FOREIGN KEY (id_estudiante) REFERENCES estudiante(id_estudiante),
  FOREIGN KEY (id_materia) REFERENCES materia(id_materia)
);

#TABLA HORARIO
CREATE TABLE horario (
  id_horario INT AUTO_INCREMENT PRIMARY KEY,
  id_materia INT,
  día_de_la_semana VARCHAR(255),
  hora__inicial TIME,
  hora_final TIME,
  FOREIGN KEY (id_materia) REFERENCES materia(id_materia)
);

#TABLA NOTA
CREATE TABLE nota (
  id_nota INT AUTO_INCREMENT PRIMARY KEY,
  id_estudiante VARCHAR(255),
  id_materia INT,
  nota DECIMAL(5,2),
  FOREIGN KEY (id_estudiante) REFERENCES estudiante(id_estudiante),
  FOREIGN KEY (id_materia) REFERENCES materia(id_materia)
);
