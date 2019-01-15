using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InnerMetrixWeb.Models
{
    public class RawScores
    {
        [JsonProperty(PropertyName = "status")]
        public string status;
        [JsonProperty(PropertyName = "results")]
        public Results results;
    }

    public class Results
    {
        [JsonProperty(PropertyName = "attributes")]
        public Attributes attributes;
        [JsonProperty(PropertyName = "categories")]
        public CategoryScores categories;
        [JsonProperty(PropertyName = "reliability")]
        public float[] reliability;
        [JsonProperty(PropertyName = "dimensional_Balance")]
        public Dimensionals dimensionalBalance;
        [JsonProperty(PropertyName = "valuations")]
        public Valuations valuations;
    }

    public class Attributes
    {
        public List<KeyValuePair<string, string>> AttributeScores;
    }

    public class CategoryScores
    {
        [JsonProperty(PropertyName = "Getting Results")]
        public float GettingResultsScores;
        [JsonProperty(PropertyName = "Interpersonal Skills")]
        public float InterpersonalSkills;
        [JsonProperty(PropertyName = "Making Decisions")]
        public float MakingDecision;
        [JsonProperty(PropertyName = "Work Ethic")]
        public float WorkEthic;
    }

    public class Valuations
    {
        [JsonProperty(PropertyName = "empathy")]
        public ValuationItem Empathy;
        [JsonProperty(PropertyName = "practical_thinking")]
        public ValuationItem PracticalThinking;
        [JsonProperty(PropertyName = "systems_judgment")]
        public ValuationItem SystemsJudgement;
        [JsonProperty(PropertyName = "self_esteem")]
        public ValuationItem SelfEsteem;
        [JsonProperty(PropertyName = "role_awareness")]
        public ValuationItem RoleAwareness;
        [JsonProperty(PropertyName = "self_direction")]
        public ValuationItem SelfDirection;
    }

    public class Dimensionals
    {
        [JsonProperty(PropertyName = "empathy")]
        public DimensionalItem Empathy;
        [JsonProperty(PropertyName = "practical_thinking")]
        public DimensionalItem PracticalThinking;
        [JsonProperty(PropertyName = "systems_judgment")]
        public DimensionalItem SystemsJudgement;
        [JsonProperty(PropertyName = "self_esteem")]
        public DimensionalItem SelfEsteem;
        [JsonProperty(PropertyName = "role_awareness")]
        public DimensionalItem RoleAwareness;
        [JsonProperty(PropertyName = "self_direction")]
        public DimensionalItem SelfDirection;
    }

    public class ValuationItem
    {
        [JsonProperty(PropertyName = "over")]
        public float over;
        [JsonProperty(PropertyName = "under")]
        public float under;
    }

    public class DimensionalItem
    {
        [JsonProperty(PropertyName = "score")]
        public float score;
        [JsonProperty(PropertyName = "sign")]
        public string sign;
    }
}