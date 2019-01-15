using InnerMetrixWeb.Areas.Admin.Models;
using Innermetrix.Services;
using InnerMetrixWeb.Models;
using InnerMetrixWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Web;
using Z.EntityFramework.Extensions;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace InnerMetrixWeb.Services
{
    public class TokenService
    {
        private InnermetrixDBEntities _db = new InnermetrixDBEntities();

        public TokenService()
        {

        }

        public string GetValidToken(long GuestID)
        {
            return GetValidToken(GuestID, "en");
        }

        public string GetValidToken(long GuestID, string lang)
        {
            //var token = new ObjectParameter("ReturnToken", typeof(string));

            using (var db = new InnermetrixDBEntities())
            {
                DateTime cutOffDateTime = DateTime.Now.Subtract(TimeSpan.FromHours(1));
                var data = db.Tokens.Where(
                        r =>
                            (r.IsUsed ?? false) == false
                            && ((r.IsLocked ?? false) == false || ((r.IsLocked ?? false) == true && r.DateLocked > cutOffDateTime))
                            && (r.IsArchived ?? false == false
                        ))
                        .First();

                data.GuestId = GuestID;
                data.IsLocked = true;
                data.DateLocked = DateTime.Now;
                data.Lang = lang;

                db.SaveChanges();
                return data.Token1.ToString();
            }
        }

        public Token GetTokenByTokenCode(string token)
        {
            return _db.Tokens.First(r => r.Token1.Equals(token));
        }

        public void SetTokenAsUsed(string token) => _db.UpdateTokenAsUsed(token);

        public void UpdateTokensPath(string path, string token)
        {
            _db.UpdateTokenWithScoresPath(token, path);

            ////Uncomment for Email functionality
            //var remainingTokensPercentage = GetRemainingTokensByPercentage();
            //using (var db = new InnermetrixDBEntities())
            //{
            //    if (remainingTokensPercentage <= 30)
            //    {
            //        string thresholdLevel = "[First Level]";

            //        var data = db.Configs.FirstOrDefault();

            //        if (remainingTokensPercentage <= 30 && remainingTokensPercentage > 20)
            //        {
            //            thresholdLevel = "[First Level]";

            //            data.IsOnLevelOneThresholdBit = true;
            //            data.LevelOneThresholdEmailDate = DateTime.Now;
            //        }
            //        else if (remainingTokensPercentage <= 20 && remainingTokensPercentage > 10)
            //        {
            //            thresholdLevel = "[Second Level]";

            //            data.IsOnLevelTwoThresholdBit = true;
            //            data.LevelTwoThresholdEmailDate = DateTime.Now;
            //        }
            //        else if (remainingTokensPercentage <= 10)
            //        {
            //            thresholdLevel = "[Third Level]";

            //            data.IsOnLevelThreeThresholdBit = true;
            //            data.LevelThreeThresholdEmailDate = DateTime.Now;
            //        }

            //        db.SaveChanges();

            //        string recepients = data.Recepients;
            //        string subject = thresholdLevel + " Alorica Assessment: Low Token Count Reminder";
            //        string body = "Hi All,<br /><br />There are only " + GetRemainingTokens() + " tokens remaining.<br /><br />Regards,<br />Alorica Assessment";

            //        EmailService.SendTokenReminder(subject, body, recepients);
            //    }
            //}

        }

        public IEnumerable<AssessmentInfo> GetAssessmentList()
        {
            List<AssessmentInfo> assessmentInfoList = new List<AssessmentInfo>();

            var data = _db.Tokens
                .Where(r => r.IsUsed.Value && r.DateUsed.HasValue)
                .Select(x => new { x.Guest.FirstName, x.Guest.LastName, x.Guest.EmailAddress, x.Guest.OracleId, x.Token1, x.ScoresUrl, x.DateUsed })
                .OrderByDescending(r => r.DateUsed.Value)
                .ToList();

            foreach (var item in data)
            {
                AssessmentInfo assessment = new AssessmentInfo(item.FirstName, item.LastName, item.EmailAddress, item.OracleId, item.Token1, item.ScoresUrl, item.DateUsed.Value.ToString());
                assessmentInfoList.Add(assessment);
            }

            return assessmentInfoList;
        }

        public int GetRemainingTokens()
        {
            return _db.Tokens.Where(r => (r.IsUsed ?? false) == false).Count();
        }

        public int GetTotalTokens()
        {
            return _db.Tokens.Where(r => (!r.IsArchived ?? false) == false).Count();
        }

        public decimal GetRemainingTokensByPercentage()
        {
            decimal remainingTokensFloat = Convert.ToDecimal(GetRemainingTokens());
            decimal totalTokensFloat = Convert.ToDecimal(GetTotalTokens());

            return (remainingTokensFloat / totalTokensFloat) * 100;
        }


        public UploadTokens UploadTokens2(HttpPostedFileBase file)
        {
            //Token tokensVM = new TokensVM();
            var transactions = _db.Database.BeginTransaction();
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["conUploading"].ConnectionString;
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("GuestId");
                dt.Columns.Add("Token");
                dt.Columns.Add("IsUsed");
                dt.Columns.Add("TokenStatus");
                dt.Columns.Add("DateLocked");
                dt.Columns.Add("DateUsed");
                dt.Columns.Add("IsLocked");
                dt.Columns.Add("ScoresUrl");
                dt.Columns.Add("Lang");
                dt.Columns.Add("IsArchived");
                StreamReader reader = new StreamReader(file.InputStream);
                string line;
                int counter = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] split = line.Split('\t');
                    if (split[0] != "")
                    {
                        DataRow dr = dt.NewRow();
                        dr["GuestId"] = DBNull.Value;
                        dr["Token"] = split[0].ToString();
                        dr["IsUsed"] = DBNull.Value;
                        dr["TokenStatus"] = DBNull.Value;
                        dr["DateLocked"] = DBNull.Value;
                        dr["DateUsed"] = DBNull.Value;
                        dr["IsLocked"] = DBNull.Value;
                        dr["ScoresUrl"] = DBNull.Value;
                        dr["Lang"] = DBNull.Value;
                        dr["IsArchived"] = DBNull.Value;
                        dt.Rows.Add(dr);
                    }
                }

                using (SqlConnection connection
                    = new SqlConnection(cs))
                {
                    // make sure to enable triggers
                    // more on triggers in next post
                    SqlBulkCopy bulkCopy =
                        new SqlBulkCopy
                        (
                        connection,
                        SqlBulkCopyOptions.TableLock |
                        SqlBulkCopyOptions.FireTriggers |
                        SqlBulkCopyOptions.UseInternalTransaction,
                        null
                        );

                    // set the destination table name
                    bulkCopy.DestinationTableName = "Tokens";
                    bulkCopy.BatchSize = 10000;
                    connection.Open();

                    // write the data in the "dataTable"
                    bulkCopy.WriteToServer(dt);
                    connection.Close();
                }
                // reset
                //dt.Clear();               
                transactions.Commit();
                UploadTokens uploadTokens = new UploadTokens("", true, counter);
                return uploadTokens;
            }
            catch (Exception ex)
            {
                transactions.Rollback();
                throw ex;
            }
            finally
            {
                _db.Dispose();
            }
        }


        public UploadTokens UploadTokens(HttpPostedFileBase file)
        {
            List<Token> batchToken = new List<Token>();            
            //Token tokensVM = new TokensVM();
            var transactions = _db.Database.BeginTransaction();
            try
            {
                StreamReader reader = new StreamReader(file.InputStream);
                string line;
                int counter = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] split = line.Split('\t');
                    if (split[0] != "")
                    {
                        var token = new Token
                        {
                            Token1 = split[0]
                        };
                        batchToken.Add(token);
                    }
                }
                _db.Configuration.AutoDetectChangesEnabled = false;
                _db.Configuration.ValidateOnSaveEnabled = false;
                _db.BulkInsert(batchToken, x => x.BatchSize = 100);
                
                //_db.Tokens.AddRange(batchToken);
                _db.SaveChanges();
                transactions.Commit();
                UploadTokensVM uploadTokens = new UploadTokensVM("", true, counter);
                return uploadTokens;
            }
            catch (Exception ex)
            {
                transactions.Rollback();
                throw ex;
            }
            finally
            {
                _db.Dispose();
            }
        }

    }
}