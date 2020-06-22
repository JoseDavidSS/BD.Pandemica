﻿using API.Source.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Source.Server_Connections.Specific_Selects
{
    public class SpecificSelect
    {
        public static SqlConnection connection = DatabaseDataHolder.connect_Database;

        public IEnumerable<Contact> makeSpecificContactSelectByPerson(string id)
        {
            var objectList = new List<Contact>();
            string sql = @"SELECT * FROM CONTACT WHERE Person = " + id;
            SqlCommand cmd = new SqlCommand(sql, connection);
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                var contact = new Contact();
                contact.person = (string)sqlReader[0];
                contact.patient = (string)sqlReader[1];
                objectList.Add(contact);
            }
            return objectList;
        }
        public IEnumerable<Contact> makeSpecificContactSelectByPatient(string id)
        {
            var objectList = new List<Contact>();
            string sql = @"SELECT * FROM CONTACT WHERE Patient = " + id;
            SqlCommand cmd = new SqlCommand(sql, connection);
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                var contact = new Contact();
                contact.person = (string)sqlReader[0];
                contact.patient = (string)sqlReader[1];
                objectList.Add(contact);
            }
            return objectList;
        }
        public IEnumerable<Continent> makeSpecificContinentSelectByName(string name)
        {
            var objectList = new List<Continent>();
            string sql = @"SELECT * FROM CONTINENT WHERE Name = " + name;
            SqlCommand cmd = new SqlCommand(sql, connection);
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                var continent = new Continent();
                continent.name = (string)sqlReader[0];
                objectList.Add(continent);
            }
            return objectList;
        }
        public IEnumerable<Country> makeSpecificCountrySelectByName(string name)
        {
            var objectList = new List<Country>();
            string sql = @"SELECT * FROM COUNTRY WHERE Name = " + name;
            SqlCommand cmd = new SqlCommand(sql, connection);
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                var country = new Country();
                country.name = (string)sqlReader[0];
                country.continentName = (string)sqlReader[1];
                country.eMail = (string)sqlReader[2];
                objectList.Add(country);
            }
            return objectList;
        }
        public IEnumerable<Country> makeSpecificCountrySelectByEMail(string email)
        {
            var objectList = new List<Country>();
            string sql = @"SELECT * FROM COUNTRY WHERE EMail = " + email;
            SqlCommand cmd = new SqlCommand(sql, connection);
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                var country = new Country();
                country.name = (string)sqlReader[0];
                country.continentName = (string)sqlReader[1];
                country.eMail = (string)sqlReader[2];
                objectList.Add(country);
            }
            return objectList;
        }
        public IEnumerable<Enforces> makeSpecificEnforcesSelectByCountry(string countryName)
        {
            var objectList = new List<Enforces>();
            string sql = @"SELECT * FROM ENFORCES WHERE Country = " + countryName;
            SqlCommand cmd = new SqlCommand(sql, connection);
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                var enforce = new Enforces();
                enforce.country = (string)sqlReader[0];
                enforce.measurement = (int)sqlReader[1];
                enforce.startDate = (string)sqlReader[2];
                enforce.finalDate = (string)sqlReader[3];
                objectList.Add(enforce);
            }
            return objectList;
        }
        public IEnumerable<Enforces> makeSpecificEnforcesSelectByMeasurement(int id)
        {
            var objectList = new List<Enforces>();
            string sql = @"SELECT * FROM ENFORCES WHERE Measurement = " + id.ToString();
            SqlCommand cmd = new SqlCommand(sql, connection);
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                var enforce = new Enforces();
                enforce.country = (string)sqlReader[0];
                enforce.measurement = (int)sqlReader[1];
                enforce.startDate = (string)sqlReader[2];
                enforce.finalDate = (string)sqlReader[3];
                objectList.Add(enforce);
            }
            return objectList;
        }
        public IEnumerable<Hospital> makeSpecificHospitalSelectById(int id)
        {
            var objectList = new List<Hospital>();
            string sql = @"SELECT * FROM HOSPITAL WHERE Id = " + id.ToString();
            SqlCommand cmd = new SqlCommand(sql, connection);
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                var hospital = new Hospital();
                hospital.id = (int)sqlReader[0];
                hospital.name = (string)sqlReader[1];
                hospital.phone = (int)sqlReader[2];
                hospital.managerName = (string)sqlReader[3];
                hospital.capacity = (int)sqlReader[4];
                hospital.icuCapacity = (int)sqlReader[5];
                hospital.country = (string)sqlReader[6];
                hospital.region = (string)sqlReader[7];
                hospital.eMail = (string)sqlReader[8];
                objectList.Add(hospital);
            }
            return objectList;
        }
        public IEnumerable<Hospital> makeSpecificHospitalSelectByEMail(string email)
        {
            var objectList = new List<Hospital>();
            string sql = @"SELECT * FROM HOSPITAL WHERE EMail = " + email;
            SqlCommand cmd = new SqlCommand(sql, connection);
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                var hospital = new Hospital();
                hospital.id = (int)sqlReader[0];
                hospital.name = (string)sqlReader[1];
                hospital.phone = (int)sqlReader[2];
                hospital.managerName = (string)sqlReader[3];
                hospital.capacity = (int)sqlReader[4];
                hospital.icuCapacity = (int)sqlReader[5];
                hospital.country = (string)sqlReader[6];
                hospital.region = (string)sqlReader[7];
                hospital.eMail = (string)sqlReader[8];
                objectList.Add(hospital);
            }
            return objectList;
        }
        public IEnumerable<Medication> makeSpecificMedicationSelectById(int id)
        {
            var objectList = new List<Medication>();
            string sql = @"SELECT * FROM MEDICATION WHERE Id = " + id.ToString();
            SqlCommand cmd = new SqlCommand(sql, connection);
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                var medication = new Medication();
                medication.id = (int)sqlReader[0];
                medication.name = (string)sqlReader[1];
                medication.pharmacy = (string)sqlReader[2];
                objectList.Add(medication);
            }
            return objectList;
        }
        public IEnumerable<MedicationSupply> makeSpecificMedicationSupplySelectByMedication(int id)
        {
            var objectList = new List<MedicationSupply>();
            string sql = @"SELECT * FROM MEDICATION_SUPPLY WHERE Medication = " + id.ToString();
            SqlCommand cmd = new SqlCommand(sql, connection);
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                var medicationSupply = new MedicationSupply();
                medicationSupply.medication = (int)sqlReader[0];
                medicationSupply.hospital = (int)sqlReader[1];
                medicationSupply.quantity = (int)sqlReader[2];
                objectList.Add(medicationSupply);
            }
            return objectList;
        }
        public IEnumerable<MedicationSupply> makeSpecificMedicationSupplySelectByHospital(int id)
        {
            var objectList = new List<MedicationSupply>();
            string sql = @"SELECT * FROM MEDICATION_SUPPLY WHERE Hospital = " + id.ToString();
            SqlCommand cmd = new SqlCommand(sql, connection);
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                var medicationSupply = new MedicationSupply();
                medicationSupply.medication = (int)sqlReader[0];
                medicationSupply.hospital = (int)sqlReader[1];
                medicationSupply.quantity = (int)sqlReader[2];
                objectList.Add(medicationSupply);
            }
            return objectList;
        }
        public IEnumerable<Pathology> makeSpecificPathologySelectById(int id)
        {
            var objectList = new List<Pathology>();
            string sql = @"SELECT * FROM PATHOLOGY WHERE Id = " + id;
            SqlCommand cmd = new SqlCommand(sql, connection);
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                var pathology = new Pathology();
                pathology.name = (string)sqlReader[0];
                pathology.symptoms = (string)sqlReader[1];
                pathology.description = (string)sqlReader[2];
                pathology.treatment = (string)sqlReader[3];
                pathology.id = (int)sqlReader[4];
                objectList.Add(pathology);
            }
            return objectList;
        }
        public IEnumerable<Patient> makeSpecificPatientSelectById(string id)
        {
            var objectList = new List<Patient>();
            string sql = @"SELECT * FROM PATIENT WHERE Ssn = " + id;
            SqlCommand cmd = new SqlCommand(sql, connection);
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                var patient = new Patient();
                patient.ssn = (string)sqlReader[0];
                patient.firstName = (string)sqlReader[1];
                patient.lastName = (string)sqlReader[2];
                patient.birthDate = (string)sqlReader[3];
                patient.hospitalized = (bool)sqlReader[4];
                patient.icu = (bool)sqlReader[5];
                patient.country = (string)sqlReader[6];
                patient.region = (string)sqlReader[7];
                patient.nationality = (string)sqlReader[8];
                patient.hospital = (int)sqlReader[9];
                objectList.Add(patient);
            }
            return objectList;
        }
        public IEnumerable<PatientMedication> makeSpecificPatientMedicationSelectByPatient(string id)
        {
            var objectList = new List<PatientMedication>();
            string sql = @"SELECT * FROM PATIENT_MEDICATION WHERE Patient = " + id;
            SqlCommand cmd = new SqlCommand(sql, connection);
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                var patientMedication = new PatientMedication();
                patientMedication.patient = (string)sqlReader[0];
                patientMedication.medication = (int)sqlReader[1];
                objectList.Add(patientMedication);
            }
            return objectList;
        }
        public IEnumerable<PatientMedication> makeSpecificPatientMedicationSelectByMedication(int id)
        {
            var objectList = new List<PatientMedication>();
            string sql = @"SELECT * FROM PATIENT_MEDICATION WHERE Medication = " + id.ToString();
            SqlCommand cmd = new SqlCommand(sql, connection);
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                var patientMedication = new PatientMedication();
                patientMedication.patient = (string)sqlReader[0];
                patientMedication.medication = (int)sqlReader[1];
                objectList.Add(patientMedication);
            }
            return objectList;
        }
        public IEnumerable<PatientPathologies> makeSpecificPatientPathologiesSelectByPatient(string id)
        {
            var objectList = new List<PatientPathologies>();
            string sql = @"SELECT * FROM PATIENT_PATHOLOGIES WHERE Patient = " + id;
            SqlCommand cmd = new SqlCommand(sql, connection);
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                var patientPathologie = new PatientPathologies();
                patientPathologie.patient = (string)sqlReader[0];
                patientPathologie.pathology = (int)sqlReader[1];
                objectList.Add(patientPathologie);
            }
            return objectList;
        }
        public IEnumerable<PatientPathologies> makeSpecificPatientPathologiesSelectByPathology(int id)
        {
            var objectList = new List<PatientPathologies>();
            string sql = @"SELECT * FROM PATIENT_PATHOLOGIES WHERE Pathology = " + id.ToString();
            SqlCommand cmd = new SqlCommand(sql, connection);
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                var patientPathologie = new PatientPathologies();
                patientPathologie.patient = (string)sqlReader[0];
                patientPathologie.pathology = (int)sqlReader[1];
                objectList.Add(patientPathologie);
            }
            return objectList;
        }
        public IEnumerable<PatientState> makeSpecificPatientStateSelectByState(int id)
        {
            var objectList = new List<PatientState>();
            string sql = @"SELECT * FROM PATIENT_STATE WHERE State = " + id.ToString();
            SqlCommand cmd = new SqlCommand(sql, connection);
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                var patientState = new PatientState();
                patientState.state = (int)sqlReader[0];
                patientState.patient = (string)sqlReader[1];
                patientState.date = (string)sqlReader[2];
                objectList.Add(patientState);
            }
            return objectList;
        }
        public IEnumerable<PatientState> makeSpecificPatientStateSelectByPatient(string id)
        {
            var objectList = new List<PatientState>();
            string sql = @"SELECT * FROM PATIENT_STATE WHERE Patient = " + id;
            SqlCommand cmd = new SqlCommand(sql, connection);
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                var patientState = new PatientState();
                patientState.state = (int)sqlReader[0];
                patientState.patient = (string)sqlReader[1];
                patientState.date = (string)sqlReader[2];
                objectList.Add(patientState);
            }
            return objectList;
        }
        public IEnumerable<Person> makeSpecificPersonSelectById(string id)
        {
            var objectList = new List<Person>();
            string sql = @"SELECT * FROM PERSON WHERE Ssn = " + id;
            SqlCommand cmd = new SqlCommand(sql, connection);
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                var person = new Person();
                person.ssn = (string)sqlReader[0];
                person.firstName = (string)sqlReader[1];
                person.lastName = (string)sqlReader[2];
                person.birthDate = (string)sqlReader[3];
                person.eMail = (string)sqlReader[4];
                person.address = (string)sqlReader[5];
                objectList.Add(person);
            }
            return objectList;
        }
        public IEnumerable<ProvinceStateRegion> makeSpecificProvinceStateRegionSelectByName(string name)
        {
            var objectList = new List<ProvinceStateRegion>();
            string sql = @"SELECT * FROM PROVINCE_STATE_REGION WHERE Name = " + name;
            SqlCommand cmd = new SqlCommand(sql, connection);
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                var provinceStateRegion = new ProvinceStateRegion();
                provinceStateRegion.name = (string)sqlReader[0];
                provinceStateRegion.country = (string)sqlReader[1];
                objectList.Add(provinceStateRegion);
            }
            return objectList;
        }
        public IEnumerable<ProvinceStateRegion> makeSpecificProvinceStateRegionSelectByCountry(string name)
        {
            var objectList = new List<ProvinceStateRegion>();
            string sql = @"SELECT * FROM PROVINCE_STATE_REGION WHERE Country = " + name;
            SqlCommand cmd = new SqlCommand(sql, connection);
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                var provinceStateRegion = new ProvinceStateRegion();
                provinceStateRegion.name = (string)sqlReader[0];
                provinceStateRegion.country = (string)sqlReader[1];
                objectList.Add(provinceStateRegion);
            }
            return objectList;
        }
        public IEnumerable<SanitaryMeasurements> makeSpecificSanitaryMeasurementsSelectById(int id)
        {
            var objectList = new List<SanitaryMeasurements>();
            string sql = @"SELECT * FROM SANITARY_MEASUREMENTS WHERE Id = " + id.ToString();
            SqlCommand cmd = new SqlCommand(sql, connection);
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                var sanitaryMeasurement = new SanitaryMeasurements();
                sanitaryMeasurement.id = (int)sqlReader[0];
                sanitaryMeasurement.name = (string)sqlReader[1];
                sanitaryMeasurement.description = (string)sqlReader[2];
                objectList.Add(sanitaryMeasurement);
            }
            return objectList;
        }
        public IEnumerable<State> makeSpecificStateSelectByName(int id)
        {
            var objectList = new List<State>();
            string sql = @"SELECT * FROM STATE WHERE Id = " + id.ToString();
            SqlCommand cmd = new SqlCommand(sql, connection);
            var sqlReader = cmd.ExecuteReader();

            while (sqlReader.Read())
            {
                var state = new State();
                state.name = (string)sqlReader[0];
                state.id = (int)sqlReader[1];
                objectList.Add(state);
            }
            return objectList;
        }
    }
}