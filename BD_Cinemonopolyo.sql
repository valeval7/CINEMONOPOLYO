CREATE DATABASE cinemonopolyo;
USE cinemonopolyo;

CREATE TABLE IF NOT EXISTS Usuarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50) NULL,
    ApellidoPaterno VARCHAR(50) NULL,
    ApellidoMaterno VARCHAR(50) NULL,
    email VARCHAR(100) NULL,
    username VARCHAR(100) UNIQUE NULL,
    password VARCHAR(255) NULL,
    rol ENUM('Cliente', 'Taquillero', 'Administrador', 'Invitado') NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE Peliculas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    titulo VARCHAR(255) NOT NULL,
    sinopsis TEXT,
    duracion INT NOT NULL,
    clasificacion ENUM('A', 'B', 'C', 'D') NOT NULL,
    genero VARCHAR(50),
    precio DECIMAL(10, 2) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);


CREATE TABLE Salas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    ubicacion VARCHAR(250),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);


CREATE TABLE Horarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    pelicula_id INT NOT NULL,
    sala_id INT NOT NULL,
    fecha_hora DATETIME NOT NULL,
    boletos_existentes INT NOT NULL,
    FOREIGN KEY (pelicula_id) REFERENCES Peliculas(id),
    FOREIGN KEY (sala_id) REFERENCES Salas(id),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);


CREATE TABLE Productos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    precio DECIMAL(10, 2) NOT NULL,
    existencia INT NOT NULL,
    tipo ENUM('Snack', 'Bebida', 'Otro') NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Tabla VentasBoletos
CREATE TABLE VentasBoletos(
    id INT AUTO_INCREMENT PRIMARY KEY,
    horario_id INT NOT NULL,
    cantidad INT NOT NULL,
    asiento VARCHAR(10) NOT NULL,
    metodo_pago ENUM('EFECTIVO', 'TARJETA DE CREDITO') NOT NULL,
    estado ENUM('Reservado', 'Pagado', 'Cancelado') DEFAULT 'Reservado',
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (horario_id) REFERENCES Horarios(id)
);


CREATE TABLE VentasProductos(
    id INT AUTO_INCREMENT PRIMARY KEY,
    producto_id INT NOT NULL,
    cantidad INT NOT NULL,
    metodo_pago ENUM('EFECTIVO', 'TARJETA DE CREDITO') NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (producto_id) REFERENCES Productos(id)
);

CREATE TABLE DetallesVenta (
    id INT AUTO_INCREMENT PRIMARY KEY,
    VentasBoletos_id INT NULL,
    VentasProductos_id INT NULL,
    usuario_id INT NOT NULL,
    Total DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (VentasBoletos_id) REFERENCES VentasBoletos(id),
    FOREIGN KEY (VentasProductos_id) REFERENCES VentasProductos(id),
    FOREIGN KEY (usuario_id) REFERENCES Usuarios(id),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

DELIMITER //
CREATE TRIGGER descontar_boletos
AFTER INSERT ON VentasBoletos
FOR EACH ROW
BEGIN
    IF NEW.estado = 'Pagado' THEN
        UPDATE Horarios
        SET boletos_existentes = boletos_existentes - NEW.cantidad
        WHERE id = NEW.horario_id;
    END IF;
END;
//
DELIMITER ;

DELIMITER //
CREATE TRIGGER descontar_inventario
AFTER INSERT ON VentasProductos
FOR EACH ROW
BEGIN
    UPDATE Productos
    SET existencia = existencia - NEW.cantidad
    WHERE id = NEW.producto_id;
    
    IF (SELECT existencia FROM Productos WHERE id = NEW.producto_id) < 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Error: Inventario insuficiente para el producto.';
    END IF;
END;
//
DELIMITER ;

DELIMITER //
CREATE TRIGGER restaurar_boletos
AFTER UPDATE ON VentasBoletos
FOR EACH ROW
BEGIN
    IF NEW.estado = 'Cancelado' THEN
        UPDATE Horarios
        SET boletos_existentes = boletos_existentes + OLD.cantidad
        WHERE id = OLD.horario_id;
    END IF;
END;
//
DELIMITER ;


DELIMITER //
CREATE PROCEDURE p_ValidarU
(
   IN _username VARCHAR(100), 
   IN _password VARCHAR(255)
)
BEGIN
    DECLARE x INT;
    SELECT COUNT(*) INTO x FROM Usuarios WHERE username = _username AND password = _password;
    
    IF x > 0 THEN
        SELECT 'C0rr3cto' AS rs, 
               (SELECT rol FROM Usuarios WHERE username = _username AND password = _password) AS rol,
               (SELECT id FROM Usuarios WHERE username = _username AND password = _password) AS id;
    ELSE
        SELECT 'Error' AS rs, 0 AS rol;
    END IF;
END //
DELIMITER ;
CALL p_ValidarU('vmg', SHA1('1234'));

DELIMITER //
CREATE PROCEDURE p_InsertarGenerico
(
    IN _Tabla VARCHAR(50), 
    IN _Campos TEXT, 
    IN _Valores TEXT
)
BEGIN
    SET @sql = CONCAT('INSERT INTO ', _Tabla, ' (', _Campos, ') VALUES (', _Valores, ')');
    PREPARE stmt FROM @sql;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
END //
DELIMITER ;
CALL p_InsertarGenerico('Usuarios', 'Nombre, ApellidoPaterno, ApellidoMaterno, email, username, password, rol', "'Valeria', 'Macias', 'Gonzalez', 'valeria@gmail.com', 'vmg', SHA1('1234'), 'Administrador'");

DELIMITER //
CREATE PROCEDURE p_EliminarGenerico
(
    IN _Tabla VARCHAR(50), 
    IN _Condicion TEXT
)
BEGIN
    SET @sql = CONCAT('DELETE FROM ', _Tabla, ' WHERE ', _Condicion);
    PREPARE stmt FROM @sql;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE p_ModificarGenerico
(
    IN _Tabla VARCHAR(50), 
    IN _CamposValores TEXT, 
    IN _Condicion TEXT
)
BEGIN
    SET @sql = CONCAT('UPDATE ', _Tabla, ' SET ', _CamposValores, ' WHERE ', _Condicion);
    PREPARE stmt FROM @sql;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
END //
DELIMITER ;


CALL p_InsertarGenerico(
    'Peliculas', 
    'titulo, sinopsis, duracion, clasificacion, genero, precio', 
    '"Avengers: Endgame", "La batalla final contra Thanos.", 180, "A", "Acción", 150.00'
);

CALL p_InsertarGenerico(
    'Peliculas', 
    'titulo, sinopsis, duracion, clasificacion, genero, precio', 
    '"The Lion King", "La historia de Simba, el joven león.", 120, "B", "Animación", 120.00'
);

CALL p_InsertarGenerico(
    'Peliculas', 
    'titulo, sinopsis, duracion, clasificacion, genero, precio', 
    '"Joker", "La historia de origen del villano Joker.", 140, "C", "Drama", 130.00'
);

-- Insertar registros en la tabla Salas
CALL p_InsertarGenerico(
    'Salas', 
    'nombre', 
    '"Sala 1"'
);

CALL p_InsertarGenerico(
    'Salas', 
    'nombre', 
    '"Sala 2"'
);

CALL p_InsertarGenerico(
    'Salas', 
    'nombre', 
    '"Sala 3"'
);

-- Insertar registros en la tabla Horarios
-- Asumiendo que las IDs generadas para las Peliculas y Salas son 1, 2, 3 respectivamente
CALL p_InsertarGenerico(
    'Horarios', 
    'pelicula_id, sala_id, fecha_hora, boletos_existentes', 
    '1, 1, "2024-11-18 15:00:00", 100'
);

CALL p_InsertarGenerico(
    'Horarios', 
    'pelicula_id, sala_id, fecha_hora, boletos_existentes', 
    '2, 2, "2024-11-18 18:00:00", 100'
);

CALL p_InsertarGenerico(
    'Horarios', 
    'pelicula_id, sala_id, fecha_hora, boletos_existentes', 
    '3, 3, "2024-11-18 21:00:00", 80'
);




DELIMITER //
CREATE PROCEDURE p_CrearUsuarioInvitado()
BEGIN
    DECLARE nuevo_id INT;
    
    -- Insert the guest user
    INSERT INTO Usuarios (rol) VALUES ('Invitado');
    
    -- Get the new user's ID
    SET nuevo_id = LAST_INSERT_ID();
    
    -- Return the new user's information
    SELECT 
        nuevo_id AS id,
        'Invitado' AS rol,
        'C0rr3cto' AS rs;
END //
DELIMITER ;

SELECT * FROM USUARIOS;

