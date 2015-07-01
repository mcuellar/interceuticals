using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using OTC.Database;

namespace Interceuticals.App_Code
{
    [ScriptService]
    public class InterWebServices : System.Web.Services.WebService
    {
        private OTCDatabase m_db = new OTCDatabase();


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<StatesByCountry> GetStates(int countryId)
        {
            string sql = "";
            this.m_db.Open();


            sql = "EXEC spGetOTCStatesByCountry @CountryId=" + countryId;
            DataTable dt = this.m_db.GetDataset(sql).Tables[0];
            this.m_db.ReleaseConnection();

            var states = new List<State>();

            // Pull states into state object
            foreach (DataRow dr in dt.Select())
            {

                var state = new State()
                {
                    StateId = Convert.ToInt32(dr["OTCStateId"]),
                    CountryId = Convert.ToInt32(dr["OTCCountryId"]),
                    StateAbbreviation = dr["StateAbbreviation"].ToString(),
                    StateName = dr["StateName"].ToString(),
                    CountryAbbreviation = dr["CountryAbbreviation"].ToString()
                };
                states.Add(state);
                
            }

            // Filter into dictionary
            var stateDictionary = states.OrderBy(x => x.StateName).GroupBy(x => x.CountryId).ToDictionary(x => x.Key, y => y.ToList());

            // Format dictionary for serialization
            var statesByCountry = new List<StatesByCountry>();

            foreach (var key in stateDictionary.Keys)
            {
                var scPair = new StatesByCountry()
                {
                    CountryId = key,
                    States = stateDictionary[key]
                };

                statesByCountry.Add(scPair);
            }

            return statesByCountry;

        }

        public class StatesByCountry
        {
            public int CountryId { get; set; }
            public List<State> States { get; set; } 
        }

        public class State
        {
            public int StateId { get; set; }
            public int CountryId { get; set; }
            public String StateAbbreviation { get; set; }
            public String StateName { get; set; }
            public String CountryAbbreviation { get; set; }
        }
    }
}
