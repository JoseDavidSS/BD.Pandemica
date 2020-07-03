﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using Newtonsoft.Json.Linq;

namespace API.Source.Server_Connections
{
    public class Tools
    {
        public static SqlConnection connection = DatabaseDataHolder.connect_Database;

        /// <summary>
        /// Function in charge with executing a store procedure
        /// </summary>
        /// <param name="country">
        /// Name of the country
        /// </param>
        /// <returns>
        /// JObject
        /// </returns>
        public JObject spCasesByCountry(string country)
        {
            var objectList = new JObject();
            try
            {
                SqlCommand cmd = new SqlCommand("spCasesByCountry", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("Country", country));
                var sqlReader = cmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    var key = (string)sqlReader[0];
                    var value = sqlReader[1];
                    objectList.Add(new JProperty(key, value));
                }
                Debug.WriteLine(objectList);
                return objectList;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error happened", ex.Message);
                return objectList;
            }
        }

        /// <summary>
        /// Function in charge of connecting to a store procedure
        /// </summary>
        /// <param name="country">
        /// Name of the country
        /// </param>
        /// <returns>
        /// JObject
        /// </returns>
        public JObject spCasesByRegion(string country)
        {
            var regions = new JObject();
            var objectList = new JArray();
            try
            {
                SqlCommand cmd = new SqlCommand("spCasesByRegion", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("Country", country));
                var sqlReader = cmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    var region = new JObject();
                    var state = "state";
                    var stateValue = sqlReader[1];
                    var quantity = "quantity";
                    var quantityValue = sqlReader[2];
                    var regionName = "regionName";
                    var regionNameValue = sqlReader[0];

                    region.Add(new JProperty(regionName, regionNameValue));
                    region.Add(new JProperty(state, stateValue));
                    region.Add(new JProperty(quantity, quantityValue));

                    objectList.Add(region);
                }
                Debug.WriteLine(objectList);
                regions.Add(new JProperty("regions", objectList));
                return regions;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error happened", ex.Message);
                return regions;
            }
        }

        public JObject spAccumulatedCasesByCountry(string country)
        {
            var accumulatedValues = new JObject();
            var objectList = new JArray();
            try
            {
                SqlCommand cmd = new SqlCommand("spAccumulatedCasesByCountry", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("Country", country));
                var sqlReader = cmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    var accumulated = new JObject();
                    var activityDate = "state";
                    var activityDateValue = sqlReader[0];
                    var quantity = "quantity";
                    var quantityValue = sqlReader[1];
                    var accumulatedCases = "regionName";
                    var accumulatedCasesValue = sqlReader[2];

                    accumulated.Add(new JProperty(activityDate, activityDateValue));
                    accumulated.Add(new JProperty(quantity, quantityValue));
                    accumulated.Add(new JProperty(accumulatedCases, accumulatedCasesValue));

                    objectList.Add(accumulated);
                }
                Debug.WriteLine(objectList);
                accumulatedValues.Add(new JProperty("accumulatedValues", objectList));
                return accumulatedValues;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error happened", ex.Message);
                return accumulatedValues;
            }
        }

        /// <summary>
        /// Function in charge of sending an email
        /// </summary>
        /// <param name="email">
        /// Email that will receive the message
        /// </param>
        public void Email(string email)
        {
            try
            {
                var fromAddress = new MailAddress("pandemicadb@gmail.com", "Schlafenhase Team");
                var toAddress = new MailAddress(email, "To User");
                const string fromPassword = "pandemicadb2020";
                const string subject = "WARNING - Possible COVID-19 USER";
                const string body = "Hi from Schlafenhase Team, recently you made contact with someone with COVID-19, it may be possible that you are infected, please go and request a COVID-19 test as soon as posible.";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
            catch (Exception ex) 
            {
                Debug.WriteLine("An error happened", ex.Message);
            }
        }

        public JObject spActiveDailyCases(string country)
        {
            var ActiveDailyCases = new JObject();
            var objectList = new JArray();
            try
            {
                SqlCommand cmd = new SqlCommand("spActiveDailyCases", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("Country", country));
                var sqlReader = cmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    var accumulated = new JObject();
                    var activityDate = "date";
                    var activityDateValue = sqlReader[0];
                    var activeQuantity = "activeQuantity";
                    var activeQuantityValue = sqlReader[1];

                    accumulated.Add(new JProperty(activityDate, activityDateValue));
                    accumulated.Add(new JProperty(activeQuantity, activeQuantityValue));

                    objectList.Add(accumulated);
                }
                Debug.WriteLine(objectList);
                ActiveDailyCases.Add(new JProperty("ActiveDailyCases", objectList));
                return ActiveDailyCases;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error happened", ex.Message);
                return ActiveDailyCases;
            }
        }

        public JObject spRecoveredDailyCases(string country)
        {
            var RecoveredDailyCases = new JObject();
            var objectList = new JArray();
            try
            {
                SqlCommand cmd = new SqlCommand("spRecoveredDailyCases", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("Country", country));
                var sqlReader = cmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    var accumulated = new JObject();
                    var activityDate = "date";
                    var activityDateValue = sqlReader[0];
                    var recoveredQuantity = "recoveredQuantity";
                    var recoveredQuantityValue = sqlReader[1];

                    accumulated.Add(new JProperty(activityDate, activityDateValue));
                    accumulated.Add(new JProperty(recoveredQuantity, recoveredQuantityValue));

                    objectList.Add(accumulated);
                }
                Debug.WriteLine(objectList);
                RecoveredDailyCases.Add(new JProperty("RecoveredDailyCases", objectList));
                return RecoveredDailyCases;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error happened", ex.Message);
                return RecoveredDailyCases;
            }
        }

        public JObject spDeathsDailyCases(string country)
        {
            var DeathsDailyCases = new JObject();
            var objectList = new JArray();
            try
            {
                SqlCommand cmd = new SqlCommand("spDeathsDailyCases", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("Country", country));
                var sqlReader = cmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    var accumulated = new JObject();
                    var activityDate = "date";
                    var activityDateValue = sqlReader[0];
                    var deathQuantity = "deathQuantity";
                    var deathQuantityValue = sqlReader[1];

                    accumulated.Add(new JProperty(activityDate, activityDateValue));
                    accumulated.Add(new JProperty(deathQuantity, deathQuantityValue));

                    objectList.Add(accumulated);
                }
                Debug.WriteLine(objectList);
                DeathsDailyCases.Add(new JProperty("DeathsDailyCases", objectList));
                return DeathsDailyCases;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An error happened", ex.Message);
                return DeathsDailyCases;
            }
        }
    }
}