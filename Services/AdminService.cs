using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InnerMetrixWeb.Areas.Admin.Models;
using InnerMetrixWeb.Models;
using InnerMetrixWeb.ViewModels;

namespace InnerMetrixWeb.Services
{
    public class AdminService
    {
        private InnermetrixDBEntities _db = new InnermetrixDBEntities();

        internal IEnumerable<GetGuestInfoScore_Result> GetGuestInfoScore(string OracleId)
        {
            IEnumerable<GetGuestInfoScore_Result> data = _db.GetGuestInfoScore(OracleId);
            return data;
        }

        internal IEnumerable<GetGuestDimensionalBalanceScore> GetDimensionalBalanceScores(string token)
        {
            IEnumerable<GetGuestDimensionalBalanceScore> data = _db.GetGuestDimensionalBalanceScores.Where(t => t.Token.Equals(token));
            return data;
        }

        internal IEnumerable<GetGuestAttributeScore> GetGuestAttributeScore(string token)
        {
            IEnumerable<GetGuestAttributeScore> data = _db.GetGuestAttributeScores.Where(t => t.Token.Equals(token));
            return data;
        }

        internal IEnumerable<GetGuestValuationScore> GetGuestValuationScore(string token)
        {
            IEnumerable<GetGuestValuationScore> data = _db.GetGuestValuationScores.Where(t => t.Token.Equals(token));
            return data;
        }

        public AdminScoresModel GetConsolidatedScores(string token)
        {
            AdminScoresModel adminScoresModel = new AdminScoresModel();

            adminScoresModel.token = token;
            adminScoresModel.dimensionalBalanceScores = GetDimensionalBalanceScores(token).ToList();
            adminScoresModel.valuationScores = GetGuestValuationScore(token).ToList();
            adminScoresModel.attributeScores = GetGuestAttributeScore(token).ToList();

            return adminScoresModel;

        }

       
        

    }
}