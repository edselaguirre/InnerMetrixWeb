﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InnerMetrixWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class InnermetrixDBEntities : DbContext
    {
        public InnermetrixDBEntities()
            : base("name=InnermetrixDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<CategoryScore> CategoryScores { get; set; }
        public virtual DbSet<DimensionalBalanceScore> DimensionalBalanceScores { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<ReliabilityScore> ReliabilityScores { get; set; }
        public virtual DbSet<Score> Scores { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }
        public virtual DbSet<ValuationScore> ValuationScores { get; set; }
        public virtual DbSet<GetGuestAttributeScore> GetGuestAttributeScores { get; set; }
        public virtual DbSet<GetGuestDimensionalBalanceScore> GetGuestDimensionalBalanceScores { get; set; }
        public virtual DbSet<GetGuestValuationScore> GetGuestValuationScores { get; set; }
        public virtual DbSet<Config> Configs { get; set; }
    
        public virtual int BindGuestSessionWithToken(Nullable<long> guestID, ObjectParameter returnToken)
        {
            var guestIDParameter = guestID.HasValue ?
                new ObjectParameter("GuestID", guestID) :
                new ObjectParameter("GuestID", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("BindGuestSessionWithToken", guestIDParameter, returnToken);
        }
    
        public virtual ObjectResult<GetGuestInfoScore_Result> GetGuestInfoScore(string oracleId)
        {
            var oracleIdParameter = oracleId != null ?
                new ObjectParameter("OracleId", oracleId) :
                new ObjectParameter("OracleId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetGuestInfoScore_Result>("GetGuestInfoScore", oracleIdParameter);
        }
    
        public virtual int SaveCategoryScores(Nullable<decimal> gettingResults, Nullable<decimal> interpersonalSkills, Nullable<decimal> makingDesicions, Nullable<decimal> workEthic, string token)
        {
            var gettingResultsParameter = gettingResults.HasValue ?
                new ObjectParameter("GettingResults", gettingResults) :
                new ObjectParameter("GettingResults", typeof(decimal));
    
            var interpersonalSkillsParameter = interpersonalSkills.HasValue ?
                new ObjectParameter("InterpersonalSkills", interpersonalSkills) :
                new ObjectParameter("InterpersonalSkills", typeof(decimal));
    
            var makingDesicionsParameter = makingDesicions.HasValue ?
                new ObjectParameter("MakingDesicions", makingDesicions) :
                new ObjectParameter("MakingDesicions", typeof(decimal));
    
            var workEthicParameter = workEthic.HasValue ?
                new ObjectParameter("WorkEthic", workEthic) :
                new ObjectParameter("WorkEthic", typeof(decimal));
    
            var tokenParameter = token != null ?
                new ObjectParameter("Token", token) :
                new ObjectParameter("Token", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SaveCategoryScores", gettingResultsParameter, interpersonalSkillsParameter, makingDesicionsParameter, workEthicParameter, tokenParameter);
        }
    
        public virtual int SaveDimensionalBalanceScores(string name, Nullable<decimal> score, string sign, string token)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var scoreParameter = score.HasValue ?
                new ObjectParameter("Score", score) :
                new ObjectParameter("Score", typeof(decimal));
    
            var signParameter = sign != null ?
                new ObjectParameter("Sign", sign) :
                new ObjectParameter("Sign", typeof(string));
    
            var tokenParameter = token != null ?
                new ObjectParameter("Token", token) :
                new ObjectParameter("Token", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SaveDimensionalBalanceScores", nameParameter, scoreParameter, signParameter, tokenParameter);
        }
    
        public virtual int SaveGuestData(string firstName, string lastName, string oracleID, string emailAddress)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var oracleIDParameter = oracleID != null ?
                new ObjectParameter("OracleID", oracleID) :
                new ObjectParameter("OracleID", typeof(string));
    
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("EmailAddress", emailAddress) :
                new ObjectParameter("EmailAddress", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SaveGuestData", firstNameParameter, lastNameParameter, oracleIDParameter, emailAddressParameter);
        }
    
        public virtual int SaveGuestScore(string token, Nullable<long> attributeID, string score)
        {
            var tokenParameter = token != null ?
                new ObjectParameter("Token", token) :
                new ObjectParameter("Token", typeof(string));
    
            var attributeIDParameter = attributeID.HasValue ?
                new ObjectParameter("AttributeID", attributeID) :
                new ObjectParameter("AttributeID", typeof(long));
    
            var scoreParameter = score != null ?
                new ObjectParameter("Score", score) :
                new ObjectParameter("Score", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SaveGuestScore", tokenParameter, attributeIDParameter, scoreParameter);
        }
    
        public virtual int SaveReliabilityScores(Nullable<decimal> score, string token)
        {
            var scoreParameter = score.HasValue ?
                new ObjectParameter("Score", score) :
                new ObjectParameter("Score", typeof(decimal));
    
            var tokenParameter = token != null ?
                new ObjectParameter("Token", token) :
                new ObjectParameter("Token", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SaveReliabilityScores", scoreParameter, tokenParameter);
        }
    
        public virtual int SaveValuationScores(string name, Nullable<decimal> over, Nullable<decimal> under, string token)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var overParameter = over.HasValue ?
                new ObjectParameter("over", over) :
                new ObjectParameter("over", typeof(decimal));
    
            var underParameter = under.HasValue ?
                new ObjectParameter("under", under) :
                new ObjectParameter("under", typeof(decimal));
    
            var tokenParameter = token != null ?
                new ObjectParameter("Token", token) :
                new ObjectParameter("Token", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SaveValuationScores", nameParameter, overParameter, underParameter, tokenParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int UpdateTokenAsUsed(string usedToken)
        {
            var usedTokenParameter = usedToken != null ?
                new ObjectParameter("UsedToken", usedToken) :
                new ObjectParameter("UsedToken", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateTokenAsUsed", usedTokenParameter);
        }
    
        public virtual int UpdateTokenWithScoresPath(string usedToken, string scoresPath)
        {
            var usedTokenParameter = usedToken != null ?
                new ObjectParameter("UsedToken", usedToken) :
                new ObjectParameter("UsedToken", typeof(string));
    
            var scoresPathParameter = scoresPath != null ?
                new ObjectParameter("ScoresPath", scoresPath) :
                new ObjectParameter("ScoresPath", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateTokenWithScoresPath", usedTokenParameter, scoresPathParameter);
        }
    }
}