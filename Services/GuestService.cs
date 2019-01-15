using System;
using System.Linq;
using System.Web;
using System.Configuration;
using InnerMetrixWeb.Models;
using RestSharp;
//using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace InnerMetrixWeb.Services
{
    public class GuestService
    {
        //UserPrincipal userPrincipal;

        private InnermetrixDBEntities _db = new InnermetrixDBEntities();
        public GuestService()
        {

        }
        //This is for a test merge
        public Guest GetUserInfo(Guest guest)
        {
            if (guest.OracleId != null)
            {
                return ProcessInternalGuests(guest);
            }
            else
            {
                return ProcessCandidateGuests(guest);
            }
        }
        private Guest ProcessInternalGuests(Guest paramGuest)
        {
            try
            {
                PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, ConfigurationManager.AppSettings["Domain"]);
                if (principalContext.ValidateCredentials(paramGuest.uid, paramGuest.password))
                {
                    Guest guestExist = _db.Guests.Where(w => w.OracleId.Equals(paramGuest.OracleId)).FirstOrDefault();   //.Select(s => s.OracleId.Equals(OracleId)).Count();
                    if (guestExist == null)
                    {
                        paramGuest.DateAdded = DateTime.Now;
                        paramGuest.DateModified = DateTime.Now;
                        paramGuest.CreatedBy = HttpContext.Current.User.Identity.Name.ToString();
                        paramGuest.ModifiedBy = HttpContext.Current.User.Identity.Name.ToString();

                        _db.Guests.Add(paramGuest);
                        _db.SaveChanges();

                        return paramGuest;
                    }
                    else
                    {
                        return guestExist;
                    }
                }
                else
                {
                    throw new Exception("Incorrect Password");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private Guest ProcessCandidateGuests(Guest paramGuest)
        {
            try
            {
                Guest guestExist = _db.Guests.Where(
                    w => w.FirstName == paramGuest.FirstName
                    && w.LastName == paramGuest.LastName
                    && w.EmailAddress == paramGuest.EmailAddress
                    && w.OracleId == null)
                    .FirstOrDefault();   //.Select(s => s.OracleId.Equals(OracleId)).Count();

                if (guestExist != null)
                {
                    return guestExist;
                }
                else
                {
                    Guest guest = new Guest();
                    guest.FirstName = paramGuest.FirstName;
                    guest.LastName = paramGuest.LastName;
                    guest.EmailAddress = paramGuest.EmailAddress;
                    guest.DateAdded = DateTime.Now;
                    guest.DateModified = DateTime.Now;
                    guest.CreatedBy = HttpContext.Current.User.Identity.Name.ToString();
                    guest.ModifiedBy = HttpContext.Current.User.Identity.Name.ToString();

                    _db.Guests.Add(guest);
                    _db.SaveChanges();

                    return guest;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string RestResult(string fname, string lname, string email, string gender, string ai_report, string completeURL)
        {
            var client = new RestClient("https://profiles.innermetrix.com/");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("remote/AI/{id}/instrument", Method.POST);
            request.AddParameter("fname", fname);
            request.AddParameter("lname", lname);
            request.AddParameter("email", email);
            request.AddParameter("gender", gender);
            request.AddParameter("ai_report", ai_report);
            request.AddParameter("completeURL", completeURL);
            request.AddUrlSegment("id", "WH_AI3a0084f9aa393560b370"); // replaces matching token in request.Resource

            // easily add HTTP Headers
            request.AddHeader("header", "value");

            // add files to upload (works with compatible verbs)
            //request.AddFile(path);

            // execute the request
            IRestResponse response = client.Execute(request);
            //var content = response.Content;
            return response.Content;
        }
        public string InnerMetrixURLBuilder(Guest guest, string retType)
        {
            return InnerMetrixURLBuilder(guest, retType, "en");
        }

        public string InnerMetrixURLBuilder(Guest guest, string retType, string lang = "en")
        {
            string gender = "m";
            string ai_report = "208";
            var uri = new UriBuilder("https://profiles.innermetrix.com/");

            TokenService tokenService = new TokenService();
            string token = tokenService.GetValidToken(guest.ID, lang);

            uri.Path = string.Format("remote/AI/{0}/instrument", token);

            string apppath = HttpContext.Current.Request.ApplicationPath;
            string urlpath = HttpContext.Current.Request.Url.Authority;
            urlpath = apppath != "/" ? urlpath + apppath : urlpath;
            string completeURL = string.Format("http://{0}/Home/ProcessAssessment/{1}/?code=", urlpath, retType);

            var parameters = HttpUtility.ParseQueryString(string.Empty);
            parameters["fname"] = guest.FirstName;
            parameters["lname"] = guest.LastName;
            parameters["email"] = guest.EmailAddress;
            parameters["gender"] = gender;
            parameters["ai_report"] = ai_report;
            parameters["skipIntro"] = "1";
            parameters["lang"] = lang;
            parameters["completeURL"] = completeURL;

            uri.Query = parameters.ToString();
            return uri.Uri.ToString();
        }
        public Guest GetGuestInfo(string OracleId)
        {
            try
            {
                PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, ConfigurationManager.AppSettings["Domain"]);
                UserPrincipal searchTemplate = new UserPrincipal(principalContext);
                searchTemplate.EmployeeId = OracleId;
                PrincipalSearcher ps = new PrincipalSearcher(searchTemplate);

                UserPrincipal user = (UserPrincipal)ps.FindOne();

                if (user != null)
                {
                    Guest guest = new Guest();
                    guest.uid = user.SamAccountName;
                    guest.OracleId = user.EmployeeId;
                    guest.FirstName = user.GivenName;
                    guest.LastName = user.Surname;
                    guest.EmailAddress = user.EmailAddress;

                    return guest;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}