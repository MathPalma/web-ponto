create database webponto; 

use webponto;

create table Colaborador
(
ID INT PRIMARY KEY AUTO_INCREMENT,
Usuario VARCHAR(50),
Senha VARCHAR(50),
Nome VARCHAR(100),
Email VARCHAR(200),
Telefone INT,
Administrador TINYINT,
RefreshToken VARCHAR(500),
RefreshTokenTempoExpiracao DATETIME
);
