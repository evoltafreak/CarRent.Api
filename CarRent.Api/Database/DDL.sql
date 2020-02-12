DROP DATABASE IF EXISTS CARRENT;

-- Create CARRENT Schema
CREATE SCHEMA IF NOT EXISTS CARRENT DEFAULT CHARACTER SET utf8;
USE CARRENT;

-- Place
CREATE TABLE IF NOT EXISTS CARRENT.Place (
  idPlace INT NOT NULL AUTO_INCREMENT,
  zipCode VARCHAR(5) NOT NULL,
  place VARCHAR(200) NOT NULL,
  canton VARCHAR(200) NOT NULL,
  cantonAbb VARCHAR(2) NOT NULL,
  PRIMARY KEY (idPlace)
);

-- CarType
CREATE TABLE IF NOT EXISTS CARRENT.CarType (
  idCarType INT NOT NULL AUTO_INCREMENT,
  carType VARCHAR(200) NOT NULL,
  PRIMARY KEY (idCarType)
);

-- CarMake
CREATE TABLE IF NOT EXISTS CARRENT.CarMake (
  idCarMake INT NOT NULL AUTO_INCREMENT,
  carMake VARCHAR(200) NOT NULL,
  PRIMARY KEY (idCarMake)
);

-- CarClass
CREATE TABLE IF NOT EXISTS CARRENT.CarClass (
  idCarClass INT NOT NULL AUTO_INCREMENT,
  carClass VARCHAR(200) NOT NULL,
  fee DECIMAL NOT NULL,
  PRIMARY KEY (idCarClass)
);

-- Car
CREATE TABLE IF NOT EXISTS CARRENT.Car (
  idCar INT NOT NULL AUTO_INCREMENT,
  fidCarMake INT NOT NULL,
  carName VARCHAR(200) NOT NULL,
  carNr VARCHAR(200) NOT NULL,
  fidCarType INT NOT NULL,
  fidCarClass INT NOT NULL,
  PRIMARY KEY (idCar),
  CONSTRAINT fk_Car_CarMake
    FOREIGN KEY (fidCarMake)
    REFERENCES CARRENT.CarMake (idCarMake),
  CONSTRAINT fk_Car_CarType
    FOREIGN KEY (fidCarType)
    REFERENCES CARRENT.CarType (idCarType),
  CONSTRAINT fk_Car_CarClass
    FOREIGN KEY (fidCarClass)
    REFERENCES CARRENT.CarClass (idCarClass)
);

-- Customer
CREATE TABLE IF NOT EXISTS CARRENT.Customer (
  idCustomer INT NOT NULL AUTO_INCREMENT,
  firstname VARCHAR(200) NOT NULL,
  lastname VARCHAR(200) NOT NULL,
  address VARCHAR(200) NOT NULL,
  addressNr VARCHAR(10),
  fidPlace INT NOT NULL,
  PRIMARY KEY (idCustomer),
  CONSTRAINT fk_Customer_Place
    FOREIGN KEY (fidPlace)
    REFERENCES CARRENT.Place (idPlace)
);

-- Customer_Car
CREATE TABLE IF NOT EXISTS CARRENT.Customer_Car (
  fidCustomer INT NOT NULL,
  fidCar INT NOT NULL,
  CONSTRAINT fk_CustomerCar_Customer
    FOREIGN KEY (fidCustomer)
    REFERENCES CARRENT.Customer (idCustomer),
  CONSTRAINT fk_CustomerCar_Car
    FOREIGN KEY (fidCar)
    REFERENCES CARRENT.Car (idCar)
);

-- Reservation
CREATE TABLE IF NOT EXISTS CARRENT.Reservation (
  idReservation INT NOT NULL AUTO_INCREMENT,
  days INT NOT NULL,
  price DECIMAL NOT NULL,
  reservationNr VARCHAR(200) NOT NULL,
  pickUpDate TIMESTAMP,
  isLease CHAR(2) NOT NULL,
  fidCustomer INT NOT NULL,
  fidCar INT NOT NULL,
  PRIMARY KEY (idReservation),
  CONSTRAINT fk_Reservation_Customer
    FOREIGN KEY (fidCustomer)
    REFERENCES CARRENT.Customer (idCustomer),
  CONSTRAINT fk_Reservation_Car
    FOREIGN KEY (fidCar)
    REFERENCES CARRENT.Car (idCar)
);

