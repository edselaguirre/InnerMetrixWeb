using InnerMetrixWeb.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Configuration;

namespace InnerMetrixWeb.Services
{
    public class RawScoresResponseService
    {
        private InnermetrixDBEntities _db = new InnermetrixDBEntities();


        public void SaveURL(string url, string token)
        {           
                TokenService tokenService = new TokenService();
                tokenService.UpdateTokensPath(url, token);            
        }

        public void SaveRawScores(RawScores rawscores, Attributes attributes, string code, JObject jObject)
        {

            using (var transactions = _db.Database.BeginTransaction())
            {
                try
                {
                    var root = rawscores.results;

                    //attributes//////////////////////////////////////////////
                    foreach (var item in attributes.AttributeScores)
                        _db.SaveGuestScore(code, Convert.ToInt32(item.Key), item.Value.Replace(",", "."));

                    //categories///////////////////////////////////////////            
                    _db.SaveCategoryScores((decimal)root.categories.GettingResultsScores,
                                            (decimal)root.categories.InterpersonalSkills,
                                            (decimal)root.categories.MakingDecision,
                                            (decimal)root.categories.WorkEthic,
                                            code);
                    //reliability//////////////////////////////////////////
                    foreach (var item in root.reliability)
                        _db.SaveReliabilityScores((decimal)item,
                                                    code);

                    //dimensional balance   ///////////////////////////////////////////////////////////////////       
                    //empathy
                    _db.SaveDimensionalBalanceScores("Empathy",
                                                     (decimal)root.dimensionalBalance.Empathy.score,
                                                      root.dimensionalBalance.Empathy.sign,
                                                      code);
                    //practicalthinking
                    _db.SaveDimensionalBalanceScores("PracticalThinking",
                                                     (decimal)root.dimensionalBalance.PracticalThinking.score,
                                                      root.dimensionalBalance.PracticalThinking.sign,
                                                      code);
                    //system judgement
                    _db.SaveDimensionalBalanceScores("SystemsJudgement",
                                                     (decimal)root.dimensionalBalance.SystemsJudgement.score,
                                                      root.dimensionalBalance.SystemsJudgement.sign,
                                                      code);
                    //selfesteem
                    _db.SaveDimensionalBalanceScores("SelfEsteem",
                                                     (decimal)root.dimensionalBalance.SelfEsteem.score,
                                                      root.dimensionalBalance.SelfEsteem.sign,
                                                      code);
                    //role awareness
                    _db.SaveDimensionalBalanceScores("RoleAwareness",
                                                     (decimal)root.dimensionalBalance.RoleAwareness.score,
                                                      root.dimensionalBalance.RoleAwareness.sign,
                                                      code);
                    //self directions
                    _db.SaveDimensionalBalanceScores("SelfDirection",
                                                     (decimal)root.dimensionalBalance.SelfDirection.score,
                                                      root.dimensionalBalance.SelfDirection.sign,
                                                      code);

                    //valuations///////////////////////////////////////////////////////////////////
                    //empathy
                    _db.SaveValuationScores("Empathy",
                                                     (decimal)root.valuations.Empathy.over,
                                                      (decimal)root.valuations.Empathy.under,
                                                      code);
                    //practicalthinking
                    _db.SaveValuationScores("PracticalThinking",
                                                     (decimal)root.valuations.PracticalThinking.over,
                                                      (decimal)root.valuations.PracticalThinking.under,
                                                      code);
                    //system judgement
                    _db.SaveValuationScores("SystemsJudgement",
                                                     (decimal)root.valuations.SystemsJudgement.over,
                                                      (decimal)root.valuations.SystemsJudgement.under,
                                                      code);
                    //selfesteem
                    _db.SaveValuationScores("SelfEsteem",
                                                     (decimal)root.valuations.SelfEsteem.over,
                                                      (decimal)root.valuations.SelfEsteem.under,
                                                      code);
                    //role awareness
                    _db.SaveValuationScores("RoleAwareness",
                                                     (decimal)root.valuations.RoleAwareness.over,
                                                      (decimal)root.valuations.RoleAwareness.under,
                                                      code);
                    //self directions
                    _db.SaveValuationScores("SelfDirection",
                                                     (decimal)root.valuations.SelfDirection.over,
                                                      (decimal)root.valuations.SelfDirection.under,
                                                      code);
                    _db.SaveChanges();
                    transactions.Commit();
                }
                catch (Exception)
                {
                    transactions.Rollback();
                    throw;
                }
            }
        }
    }
}