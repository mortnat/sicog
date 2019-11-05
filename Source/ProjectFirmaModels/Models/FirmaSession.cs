﻿using System;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;

namespace ProjectFirmaModels.Models
{
    public partial class FirmaSession : IAuditableEntity
    {
        //protected static readonly ILog Logger = LogManager.GetLogger(typeof(SitkaHttpApplication));

        /// <summary>
        /// Static constructor
        /// </summary>
        /// <returns></returns>
        public static FirmaSession MakeEmptyFirmaSession(Tenant tenant)
        {
            Check.EnsureNotNull(tenant, "Tenant must not be null. Should be current Tenant.");

            // I'd prefer just to write this as a real constructor, but it's already in EF generated code, so we resort to this.
            var newFirmaSession = new FirmaSession();
            newFirmaSession.FirmaSessionGuid = Guid.NewGuid();
            newFirmaSession.CreateDate = DateTime.Now;
            newFirmaSession.TenantID = tenant.TenantID;

            return newFirmaSession;
        }

        /// <summary>
        /// Constructor for a new FirmaSession for a given Person
        /// </summary>
        /// <param name="person"></param>
        public FirmaSession(Person person)
        {
            Check.EnsureNotNull(person, "Do not call this if Person is null");

            FirmaSessionGuid = Guid.NewGuid();
            CreateDate = DateTime.Now;
            Person = person;
            TenantID = person.Tenant.TenantID;
        }

        public string GetAuditDescriptionString()
        {
            return string.Format($"{this.FirmaSessionGuid}");
        }

        public bool IsAnonymousUser()
        {
            return Person == null;
        }

        public bool IsAnonymousOrUnassigned()
        {
            return IsAnonymousUser() || Person.Role == Role.Unassigned;
        }

        public string GetFullNameFirstLast()
        {
            if (this.Person == null)
            {
                return "(Anonymous)";
            }

            return this.Person.GetFullNameFirstLast();
        }

        #region Impersonation

        public void ImpersonateUser(Person personToImpersonate, Uri optionalPreviousPageUri,
            out string impersonationStatusMessage, out string impersonationStatusWarning)
        {
            Check.EnsureNotNull(this.PersonID, "Anonymous users can't impersonate authentic users.");
            Check.EnsureNotNull(personToImpersonate, "You can't impersonate an Anonymous user.");

            impersonationStatusWarning = null;
            string currentImpersonationString = string.Empty;
            // Keep track of who we started as -- unless we are *already* impersonating, 
            // in which case we keep our original identity through each new impersonation.
            if (OriginalPerson == null)
            {
                OriginalPerson = Person;
            }
            else
            {
                // If we are trying to impersonate *ourself*, we instead resume our original session.
                // (there are other checks elsewhere to prevent and warn about this, but this is a last-ditch exit.)
                if (OriginalPerson.PersonID == personToImpersonate.PersonID)
                {
                    ResumeOriginalUser(optionalPreviousPageUri, out impersonationStatusMessage);
                    return;
                }

                currentImpersonationString = $" (currently impersonating {Person.GetFullNameFirstLast()})";
            }

            var lastPageLinkHtml = MakeLastPageLinkHtml(optionalPreviousPageUri);

            // Switch to the new user we want to impersonate
            Person = personToImpersonate;
            impersonationStatusMessage =
                $"Logon {OriginalPerson.GetFullNameFirstLast()}{currentImpersonationString} switching to impersonate Logon {personToImpersonate.GetFullNameFirstLast()}.{lastPageLinkHtml}";
            //_logger.InfoFormat(impersonationStatusMessage);

            if (!personToImpersonate.IsActive)
            {
                impersonationStatusWarning =
                    $"Logon {personToImpersonate.GetFullNameFirstLast()} is inactive. Impersonation will allow you to act as this person, but be aware of potential issues due to the account being inactive.";
            }
        }

        public static string MakeLastPageLinkHtml(Uri optionalPreviousPageUri)
        {
            // Work out what the last page was, if possible, so we can offer the user a link to it 
            // so they can return to what they were doing once they've succeeded in impersonating.
            //
            // We can't just take them to the last page since there is zero guarantee they have rights to be there.
            // So we leave it up to the user, but make it easier for them.
            string lastPageLinkHtml = String.Empty;
            if (optionalPreviousPageUri != null)
            {
                string lastPageUrl = optionalPreviousPageUri.ToString();
                if (GeneralUtility.IsNullOrEmptyOrOnlyWhitespace(lastPageUrl) == false)
                {
                    string lastPageLinkText = " Return to last page";
                    var linkToLastPage = BuildLastUrlLinkFromUrl(lastPageUrl, lastPageLinkText, lastPageLinkText);
                    lastPageLinkHtml = $"<br/><br/>{linkToLastPage}.";
                }
            }

            return lastPageLinkHtml;
        }

        public static string BuildLastUrlLinkFromUrl(string url, string linkText, string titleText)
        {
            return $"<a href=\"{url}\" title=\"{titleText}\">{linkText}</a>";
        }

        public void ResumeOriginalUser(Uri optionalPreviousPageUri, out string impersonationStatusMessage)
        {
            var lastPageLinkHtml = MakeLastPageLinkHtml(optionalPreviousPageUri);

            Check.EnsureNotNull(OriginalPerson,
                "FirmaSession {0} is not impersonating; it is not valid to call ResumeOriginalUser()");
            impersonationStatusMessage =
                $"Logon {OriginalPerson.GetFullNameFirstLast()} resuming their original session; ceasing impersonation of Logon {Person.GetFullNameFirstLast()}.{lastPageLinkHtml}";
            //_logger.InfoFormat(impersonationStatusMessage);
            // Swap back
            Person = OriginalPerson;
            // Clear impersonation data
            OriginalPerson = null;
            OriginalPersonID = null;
        }

        /// <summary>
        /// Is the current FirmaSession impersonating another user? 
        /// </summary>
        /// <returns></returns>
        public bool IsImpersonating()
        {
            // You can also use this extension directly.
            return FirmaSessionExtensions.IsImpersonating(this);
        }

        #endregion Impersonation

        public const string AnonymousDisplayString = "(anonymous)";

        public string UserDisplayName
        {
            get
            {
                return IsAnonymousOrUnassigned()
                    ? AnonymousDisplayString:
                    Person.GetFullNameFirstLast();
            }
        }
    }
}