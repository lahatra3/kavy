-- Active: 1681538436500@@127.0.0.1@1433
CREATE DATABASE KAVY;

USE KAVY;

CREATE TABLE clients(
    id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    nom VARCHAR(255),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT NULL
);

CREATE TABLE listes(
    id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    nom VARCHAR(100),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT NULL
);

CREATE TABLE abonnements(
    id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    client_id INT NOT NULL,
    liste_id INT NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT NULL,
    CONSTRAINT fk_client_id_abonnements FOREIGN KEY(client_id)
        REFERENCES clients(id),
    CONSTRAINT fk_liste_id_abonnements FOREIGN KEY(liste_id)
        REFERENCES listes(id)
);

CREATE TABLE archives(
    id INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    titre VARCHAR(255),
    description TEXT,
    liste_id INT NOT NULL,
    CONSTRAINT fk_liste_id_archives FOREIGN KEY(liste_id)
        REFERENCES listes(id)
);