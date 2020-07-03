--Script in charge of creating the tables of the database

CREATE TABLE PATIENT_PATHOLOGIES (
  Patient VARCHAR (15) NOT NULL,
  Pathology INT NOT NULL,
  Id INT IDENTITY (1,1) NOT NULL,
  PRIMARY KEY (Patient, Pathology, Id),
  UNIQUE (Id)
);

CREATE TABLE PROVINCE_STATE_REGION (
  Name VARCHAR (15) NOT NULL,
  Country VARCHAR (30) NOT NULL,
  Id INT IDENTITY (1,1) NOT NULL,
  PRIMARY KEY (Name, Country, Id),
  UNIQUE (Id),
  UNIQUE (Name)
);

CREATE TABLE STATE (
  Name VARCHAR (15) NOT NULL,
  Id INT IDENTITY (1,1) NOT NULL,
  PRIMARY KEY (Id),
  UNIQUE (Name),
  UNIQUE (Id)
);

CREATE TABLE PATIENT_MEDICATION (
  Patient VARCHAR (15) NOT NULL,
  Medication INT NOT NULL,
  Id INT IDENTITY (1,1) NOT NULL,
  PRIMARY KEY (Patient, Medication, Id),
  UNIQUE (Id)
);

CREATE TABLE PERSON (
  Ssn VARCHAR (15) NOT NULL,
  FirstName VARCHAR (15) NOT NULL,
  LastName VARCHAR (15) NOT NULL,
  BirthDate DATE NOT NULL,
  EMail VARCHAR (25) NOT NULL,
  Address TEXT NOT NULL,
  Sex CHAR (1) NOT NULL,
  PRIMARY KEY (Ssn),
  UNIQUE (EMail),
  UNIQUE (Ssn)
);

CREATE TABLE ENFORCES (
  Country VARCHAR (30) NOT NULL,
  Measurement INT NOT NULL,
  StartDate DATE,
  FinalDate DATE,
  Id INT IDENTITY (1,1) NOT NULL,
  PRIMARY KEY (Country, Measurement, Id),
  UNIQUE (Id)
);

CREATE TABLE PATIENT (
  Ssn VARCHAR (15) NOT NULL,
  FirstName VARCHAR (15) NOT NULL,
  LastName VARCHAR (15) NOT NULL,
  BirthDate DATE,
  Hospitalized BIT NOT NULL,
  ICU BIT NOT NULL,
  Country VARCHAR (30) NOT NULL,
  Region VARCHAR (15) NOT NULL,
  Nationality VARCHAR (30) NOT NULL,
  Hospital INT NOT NULL,
  Sex CHAR (1) NOT NULL,
  PRIMARY KEY (Ssn),
  UNIQUE (Ssn)
);

CREATE TABLE PATHOLOGY (
  Name VARCHAR (15) NOT NULL,
  Symptoms TEXT NOT NULL,
  Description TEXT,
  Treatment TEXT NOT NULL,
  Id INT IDENTITY (1,1) NOT NULL,
  PRIMARY KEY (Id),
  UNIQUE (Id),
  UNIQUE (Name)
);

CREATE TABLE PATIENT_STATE (
  State INT NOT NULL,
  Patient VARCHAR (15) NOT NULL,
  Date DATE NOT NULL,
  Id INT IDENTITY (1,1) NOT NULL,
  PRIMARY KEY (State, Patient, Id),
  UNIQUE (Id)
);

CREATE TABLE CONTINENT (
  Name VARCHAR (15) NOT NULL,
  PRIMARY KEY (Name),
  UNIQUE (Name)
);

CREATE TABLE MEDICATION (
  Id INT IDENTITY (1,1) NOT NULL,
  Name VARCHAR (15) NOT NULL,
  Pharmacy VARCHAR (15),
  PRIMARY KEY (Id),
  UNIQUE (Id),
  UNIQUE (Name)
);

CREATE TABLE HOSPITAL (
  Id INT IDENTITY (1,1) NOT NULL,
  Name VARCHAR (15) NOT NULL,
  Phone INT NOT NULL,
  ManagerName VARCHAR (15) NOT NULL,
  Capacity INT,
  ICUCapacity INT,
  Country VARCHAR (30) NOT NULL,
  Region VARCHAR (15),
  EMail VARCHAR (25) NOT NULL,
  PRIMARY KEY (Id),
  UNIQUE (Id),
  UNIQUE (Name),
  UNIQUE (Phone),
  UNIQUE (EMail)
);

CREATE TABLE SANITARY_MEASUREMENTS (
  Id INT IDENTITY (1,1) NOT NULL,
  Name VARCHAR (15) NOT NULL,
  Description TEXT,
  PRIMARY KEY (Id),
  UNIQUE (Id),
  UNIQUE (Name)
);

CREATE TABLE CONTACT (
  Person VARCHAR (15) NOT NULL,
  Patient VARCHAR (15) NOT NULL,
  Id INT IDENTITY (1,1) NOT NULL,
  Date DATE NOT NULL,
  PRIMARY KEY (Person, Patient, Id),
  UNIQUE (Id)
);

CREATE TABLE COUNTRY (
  Name VARCHAR (30) NOT NULL,
  ContinentName VARCHAR (15) NOT NULL,
  EMail VARCHAR (25) NOT NULL,
  PRIMARY KEY (Name),
  UNIQUE (Name),
  UNIQUE (EMail)
);