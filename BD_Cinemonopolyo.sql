CREATE DATABASE cinemonopolyo;
USE cinemonopolyo;

CREATE TABLE Usuarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    ApellidoPaterno VARCHAR(50) NOT NULL,
    ApellidoMaterno VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL,
    username VARCHAR(100) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    rol ENUM('Cliente', 'Taquillero', 'Administrador') NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);


CREATE TABLE Peliculas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    titulo VARCHAR(255) NOT NULL,
    sinopsis TEXT,
    duracion INT NOT NULL,
    clasificacion ENUM('A', 'B', 'C', 'D') NOT NULL,
    genero VARCHAR(50),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);


CREATE TABLE Salas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    capacidad INT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);


CREATE TABLE Horarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    pelicula_id INT NOT NULL,
    sala_id INT NOT NULL,
    fecha_hora DATETIME NOT NULL,
    FOREIGN KEY (pelicula_id) REFERENCES Peliculas(id),
    FOREIGN KEY (sala_id) REFERENCES Salas(id),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);


CREATE TABLE Boletos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    horario_id INT NOT NULL,
    usuario_id INT NOT NULL,
    asiento VARCHAR(10) NOT NULL,
    precio DECIMAL(10, 2) NOT NULL,
    estado ENUM('Reservado', 'Pagado', 'Cancelado') DEFAULT 'Reservado',
    FOREIGN KEY (horario_id) REFERENCES Horarios(id),
    FOREIGN KEY (usuario_id) REFERENCES Usuarios(id),
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


CREATE TABLE Ventas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    usuario_id INT NOT NULL,
    total DECIMAL(10, 2) NOT NULL,
    metodo_pago ENUM('EFECTIVO', 'TARJETA DE CREDITO') NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (usuario_id) REFERENCES Usuarios(id)
);


CREATE TABLE DetallesVenta (
    id INT AUTO_INCREMENT PRIMARY KEY,
    venta_id INT NOT NULL,
    producto_id INT NOT NULL,
    cantidad INT NOT NULL,
    precio DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (venta_id) REFERENCES Ventas(id),
    FOREIGN KEY (producto_id) REFERENCES Productos(id),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

DELIMITER //
CREATE TRIGGER descontar_boletos
AFTER INSERT ON Boletos
FOR EACH ROW
BEGIN
    IF NEW.estado = 'Pagado' THEN
        UPDATE Salas
        SET capacidad = capacidad - 1
        WHERE id = (SELECT sala_id FROM Horarios WHERE id = NEW.horario_id);
    END IF;
END;
//
DELIMITER ;

DELIMITER //
CREATE TRIGGER descontar_inventario
AFTER INSERT ON DetallesVenta
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
AFTER UPDATE ON Boletos
FOR EACH ROW
BEGIN
    IF NEW.estado = 'Cancelado' THEN
        UPDATE Salas
        SET capacidad = capacidad + 1
        WHERE id = (SELECT sala_id FROM Horarios WHERE id = NEW.horario_id);
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
        SELECT 'Correcto' AS rs, 
               (SELECT rol FROM Usuarios WHERE username = _username AND password = _password) AS rol,
               (SELECT email FROM Usuarios WHERE username = _username AND password = _password) AS email;
    ELSE
        SELECT 'Error' AS rs, 0 AS rol;
    END IF;
END //
DELIMITER ;

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

