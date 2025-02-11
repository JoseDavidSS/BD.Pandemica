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
    public class ContinentController : ApiController
    {
        GeneralSelect select = new GeneralSelect();
        SpecificSelect specificSelect = new SpecificSelect();

        DatabaseDataHolder connection = new DatabaseDataHolder();

        /// <summary>
        /// Function in charge of recopilating all the continents in the database
        /// </summary>
        /// <returns>
        /// A list with all the continents found
        /// </returns>
        [Route("api/Continent")]
        [HttpGet]
        public IEnumerable<Continent> Get()
        {
            connection.openConnection();
            Continent[] allrecords;
            allrecords = select.makeContinentSelect().ToArray();
            connection.closeConnection();
            return allrecords;
        }

        /// <summary>
        /// Function in charge of searching a continent through a name
        /// </summary>
        /// <param name="name">
        /// Name of the continent
        /// </param>
        /// <returns>
        /// A list with the continent found
        /// </returns>
        [Route("api/Continent/{name}")]
        [HttpGet]
        public IEnumerable<Continent> Get(string name)
        {
            connection.openConnection();
            Continent[] allrecords;
            allrecords = specificSelect.makeSpecificContinentSelectByName(name).ToArray();
            connection.closeConnection();
            return allrecords;
        }
    }
}
