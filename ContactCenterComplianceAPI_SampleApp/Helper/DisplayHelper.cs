using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterCompliance;

namespace ContactCenterComplianceAPI_SampleApp.Helper
{
    public static class DisplayHelper
    {
        public static void DisplayLitigatorScrubResponseList(List<LitigatorResponse> litigatorResponseList)
        {
            foreach (var litigatorResponse in litigatorResponseList)
            {
                if (litigatorResponse != null)
                {
                    Console.WriteLine("Phone: {0}", litigatorResponse.Phone);
                    Console.WriteLine("IsLitigator: {0}", litigatorResponse.IsLitigator);

                    Console.WriteLine("-----------------------");
                }
            }
        }

        public static void DisplayScrubResponseList(List<ScrubResponse> scrubResponseList, bool hasReferenceId = false)
        {
            foreach (var scrubResponse in scrubResponseList)
            {
                if (scrubResponse != null)
                {
                    Console.WriteLine("PhoneNo: {0}", scrubResponse.PhoneNumber);
                    Console.WriteLine("ResultCode: {0}", scrubResponse.ResultCode);

                    if (hasReferenceId)
                    {
                        Console.WriteLine("Reference ID: {0}", scrubResponse.ReferenceId);
                    }

                    Console.WriteLine("RegionAbbrev: {0}", scrubResponse.RegionAbbrev);
                    Console.WriteLine("Country: {0}", scrubResponse.Country);
                    Console.WriteLine("CarrierInfo: {0} : {1} : {2}", scrubResponse.CarrierInfo.OCNCode, scrubResponse.CarrierInfo.TypeOfService, scrubResponse.CarrierInfo.CarrierName);
                    Console.WriteLine("NewReassignedAreaCode: {0}", scrubResponse.NewReassignedAreaCode);
                    Console.WriteLine("TzCode: {0}", scrubResponse.TzCode);
                    Console.WriteLine("CallingWindow: {0}-{1} | {2}-{3} | {4}-{5}",
                        scrubResponse.CallingWindow.Weekday.StartWindow, scrubResponse.CallingWindow.Weekday.EndWindow,
                        scrubResponse.CallingWindow.Saturday.StartWindow, scrubResponse.CallingWindow.Saturday.EndWindow,
                        scrubResponse.CallingWindow.Sunday.StartWindow, scrubResponse.CallingWindow.Sunday.EndWindow);
                    Console.WriteLine("UTCOffset: {0}", scrubResponse.UTCOffset);
                    Console.WriteLine("DoNotCallToday: {0}", scrubResponse.DoNotCallToday);
                    Console.WriteLine("CallingTimeRestrictions: {0}", scrubResponse.CallingTimeRestrictions);
                    Console.WriteLine("LineType: {0}", scrubResponse.LineType);
                    Console.WriteLine("IsWirelessOrVoip: {0}", scrubResponse.IsWirelessOrVoip);
                    Console.WriteLine("EbrType: {0}", scrubResponse.EbrType);
                    Console.WriteLine("IsLitigator: {0}", scrubResponse.IsLitigator);
                    Console.WriteLine("IsFederalDNC: {0}", scrubResponse.IsFederalDNC);
                    Console.WriteLine("FederalDNCDate: {0}", scrubResponse.FederalDNCDate);
                    Console.WriteLine("IsStateDNC: {0}", scrubResponse.IsStateDNC);
                    Console.WriteLine("StateDNCDate: {0}", scrubResponse.StateDNCDate);
                    Console.WriteLine("IsTPSDNC: {0}", scrubResponse.IsTPSDNC);
                    Console.WriteLine("CurrentTime: {0}", scrubResponse.CurrenTime);

                    Console.WriteLine("-----------------------");
                }
            }
        }

        public static void DisplayProjectDetails(Project project)
        {
            Console.WriteLine("PROJECT DETAILS:");
            Console.WriteLine("Project Id: {0}", project.ProjectId);
            Console.WriteLine("Name: {0}", project.Name);
            Console.WriteLine("Status: {0}", project.Status);
            Console.WriteLine("Parent Account Id: {0}", project.ParentAccountId);
            Console.WriteLine("Parent Account Name: {0}", project.ParentAccountName);

            if (project.Campaigns.Count > 0)
            {
                Console.WriteLine("CAMPAIGN DETAILS:");
                foreach (var campaign in project.Campaigns)
                {
                    Console.WriteLine("Id: {0}, Name: {1}, Status: {2}", campaign.Id, campaign.Name, campaign.Status);
                }
            }
        }

        public static void DisplayIDNCDetail(IDNCDetail idncDetail)
        {
            Console.WriteLine("IDNC DETAILS:");
            Console.WriteLine("DistinctPhoneNumbers: {0}", idncDetail.DistinctPhoneNumbers);
            Console.WriteLine("MostRecentChange: {0}", idncDetail.MostRecentChange);
        }

        public static void DisplayIDNCStatus(List<IDNCStatus> idncStatusList)
        {
            Console.WriteLine("IDNC STATUS LIST DETAILS:");
            foreach (var idncStatus in idncStatusList)
            {
                Console.WriteLine("PhoneNumber: {0}", idncStatus.PhoneNumber);
                Console.WriteLine("DateInserted: {0}", idncStatus.DateInserted);
                Console.WriteLine("LastModified: {0}", idncStatus.LastModified);
            }
        }

        public static void DisplayIDNC(IDNCStatus idncStatus)
        {
            Console.WriteLine("PhoneNumber: {0}", idncStatus.PhoneNumber);
            Console.WriteLine("DateInserted: {0}", idncStatus.DateInserted);
            Console.WriteLine("LastModified: {0}", idncStatus.LastModified);
        }
    }
}
