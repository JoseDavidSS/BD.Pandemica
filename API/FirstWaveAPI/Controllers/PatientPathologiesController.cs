﻿using API.Source.Entities;
using API.Source.Server_Connections;
using API.Source.Server_Connections.Specific_Selects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class PatientPathologiesController : ApiController
    {
        GeneralInsert insert = new GeneralInsert();
        GeneralSelect select = new GeneralSelect();
        SpecificSelect specificSelect = new SpecificSelect();
        SpecificDelete delete = new SpecificDelete();
        SpecificUpdate update = new SpecificUpdate();
            
        DatabaseDataHolder connection = new DatabaseDataHolder();

        /// <summary>
        /// Function in charge recolecting all the patient pathologies in the database
        /// </summary>
        /// <returns>
        /// List with all the patient pathologies found
        /// </returns>
        [Route("api/PatientPathologies")]
        [HttpGet]
        public IEnumerable<PatientPathologies> Get()
        {
            connection.openConnection();
            PatientPathologies[] allrecords;
            allrecords = select.makePatientPathologiesSelect().ToArray();
            connection.closeConnection();
            return allrecords;
        }

        /// <summary>
        /// Function in charge of recolecting all the patient pathologies of a patient
        /// </summary>
        /// <param name="id">
        /// Ssn of the patient
        /// </param>
        /// <returns>
        /// List wit all the pathologies found
        /// </returns>
        [Route("api/PatientPathologies/{id}")]
        [HttpGet]
        public IEnumerable<SpecialPatientPathologies> GetSpecialPatientMedication(string id)
        {
            connection.openConnection();
            SpecialPatientPathologies[] allrecords;
            allrecords = select.makeSpecialPatientPathologiesSelect(id).ToArray();
            connection.closeConnection();
            return allrecords;
        }

        /// <summary>
        /// Function in charge of recolecting all the patient pathologies of a patient
        /// </summary>
        /// <param name="id">
        /// Ssn of the patient
        /// </param>
        /// <returns>
        /// List wit all the pathologies found
        /// </returns>
        [Route("api/PatientPathologies/Patient/{id}")]
        [HttpGet]
        public IEnumerable<PatientPathologies> GetPatientPathologiesFromPatient(string id)
        {
            connection.openConnection();
            PatientPathologies[] allrecords;
            allrecords = specificSelect.makeSpecificPatientPathologiesSelectByPatient(id).ToArray();
            connection.closeConnection();
            return allrecords;
        }

        /// <summary>
        /// Function in charge of recolecting all the patient pathologies
        /// </summary>
        /// <param name="id">
        /// Id of the pathology
        /// </param>
        /// <returns>
        /// List with all the patient pathologies found
        /// </returns>
        [Route("api/PatientPathologies/Pathologies/{id:int}")]
        [HttpGet]
        public IEnumerable<PatientPathologies> GetPatientPathologiesFromPathology(int id)
        {
            connection.openConnection();
            PatientPathologies[] allrecords;
            allrecords = specificSelect.makeSpecificPatientPathologiesSelectByPathology(id.ToString()).ToArray();
            connection.closeConnection();
            return allrecords;
        }

        /// <summary>
        /// Function in charge of inserting a patient pathology
        /// </summary>
        /// <param name="patientPathologies">
        /// Patient pathology to be added
        /// </param>
        [Route("api/PatientPathologies")]
        [HttpPost]
        public void Post(SpecialPatientPathologiesWithPatientSsn patientPathologies)
        {
            connection.openConnection();
            insert.makePatientPathologiesInsert(patientPathologies.patientSsn, patientPathologies.name);
            connection.closeConnection();
            Debug.WriteLine("Inserted");
        }

        /// <summary>
        /// Funtion in charge updating a patient pathology
        /// </summary>
        /// <param name="id">
        /// Ssn of the patient
        /// </param>
        /// <param name="name">
        /// Previous pathology name
        /// </param>
        /// <param name="patientPathologies">
        /// Patient pathology with the new name
        /// </param>
        [Route("api/PatientPathologies/{id}/{name}")]
        [HttpPut]
        public void PutPatientPathologies(string id, string name, SpecialPatientPathologiesWithPatientSsn patientPathologies)
        {
            connection.openConnection();
            update.makeSpecificPatientPathologiesUpdate(id, patientPathologies.name, name);
            connection.closeConnection();
            Debug.WriteLine("Updated from Pathologies");
        }

        /// <summary>
        /// Function in charge of deleting a patient pathology from the database
        /// </summary>
        /// <param name="id">
        /// Ssn of the patient
        /// </param>
        /// <param name="name">
        /// Name of the pathology
        /// </param>
        [Route("api/PatientPathologies/{id}/{name}")]
        [HttpDelete]
        public void DeletePatientPathologies(string id, string name)
        {
            connection.openConnection();
            delete.makeSpecificPatientPathologiesDelete(id, name);
            connection.closeConnection();
            Debug.WriteLine("Deleted from Pathologies");
        }
    }
}
