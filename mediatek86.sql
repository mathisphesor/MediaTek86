DROP DATABASE IF EXISTS mediatek86;
CREATE DATABASE mediatek86 CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE mediatek86;

CREATE TABLE service (
    idservice INT AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(50)
);

CREATE TABLE motif (
    idmotif INT AUTO_INCREMENT PRIMARY KEY,
    libelle VARCHAR(128)
);

CREATE TABLE personnel (
    idpersonnel INT AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(50),
    prenom VARCHAR(50),
    tel VARCHAR(15),
    mail VARCHAR(128),
    idservice INT NOT NULL,
    FOREIGN KEY (idservice) REFERENCES service(idservice)
);

CREATE TABLE absence (
    idpersonnel INT NOT NULL,
    datedebut DATETIME NOT NULL,
    datefin DATETIME,
    idmotif INT NOT NULL,
    PRIMARY KEY (idpersonnel, datedebut),
    FOREIGN KEY (idpersonnel) REFERENCES personnel(idpersonnel),
    FOREIGN KEY (idmotif) REFERENCES motif(idmotif)
);

CREATE TABLE responsable (
    login VARCHAR(64),
    pwd VARCHAR(64)
);

INSERT INTO service(nom) VALUES
('administratif'),
('médiation culturelle'),
('prêt');

INSERT INTO motif(libelle) VALUES
('vacances'),
('maladie'),
('motif familial'),
('congé parental');

INSERT INTO responsable(login, pwd)
VALUES ('admin', SHA2('admin123', 256));

CREATE USER IF NOT EXISTS 'gestionnaire'@'localhost'
IDENTIFIED BY 'MotDePasse123!';

GRANT ALL PRIVILEGES ON mediatek86.*
TO 'gestionnaire'@'localhost';

FLUSH PRIVILEGES;
