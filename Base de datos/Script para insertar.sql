-- Insertar roles
INSERT INTO rol (id_rol, tipo_de_usuario) VALUES (1, 'administrador');
INSERT INTO rol (id_rol, tipo_de_usuario) VALUES (2, 'profesor');
INSERT INTO rol (id_rol, tipo_de_usuario) VALUES (3, 'estudiante');

-- Insertar usuarios
INSERT INTO usuario (nombre_usuario, pass, id_rol) VALUES ('admin', 'admin', 1);
INSERT INTO usuario (nombre_usuario, pass, id_rol) VALUES ('JUan Alvarenga', 'password', 2);
INSERT INTO usuario (nombre_usuario, pass, id_rol) VALUES ('Pedro Cárcamo', 'password', 3);

-- Insertar profesores
INSERT INTO profesor (nombre, apellido, titulo, id_usuario) VALUES ('Juan', 'Pérez', 'Matemáticas', 2);

-- Insertar materias
INSERT INTO materia (nombre, descripcion, aula, escuela, abreviatura, id_profesor)
VALUES ('Matemáticas', 'Curso de matemáticas básicas', 'Aula 101', 'Facultad de Ciencias', 'MATH', 1);

-- Insertar estudiantes
INSERT INTO estudiante (id_estudiante, nombre, apellido, fecha_de_nacimiento, género, dirección, teléfono, correo_electrónico, id_usuario) VALUES ('AG241867', 'Ana', 'García', '2002-05-20', 'F', 'Calle Falsa 123', '555-5555', 'ana.garcia@example.com', 3);

-- Insertar matrículas
INSERT INTO matricula (id_estudiante, id_materia, estado) VALUES ('AG241867', 1, 'confirmada');

-- Insertar horarios
INSERT INTO horario (id_materia, día_de_la_semana, hora__inicial, hora_final) VALUES (1, 'Lunes', '10:00:00', '12:00:00');

-- Insertar notas
INSERT INTO nota (id_estudiante, id_materia, nota) VALUES ('AG241867', 1, 8.5);
