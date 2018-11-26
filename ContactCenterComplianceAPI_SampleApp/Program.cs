using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactCenterCompliance;
using ContactCenterComplianceAPI_SampleApp.Helper;

namespace ContactCenterComplianceAPI_SampleApp
{
    class Program
    {        
        static CCCApi client = new CCCApi("--- API Key ---");
        
        static List<string> shortPhoneNumberList = new List<string>() {
                                                "6234928976",
                                                "9545031806",
                                                "2675466417"
                                             };
        static List<PhoneReference> shortPhoneReferenceList = new List<PhoneReference>() {
                                                new PhoneReference
                                                {
                                                    PhoneNo = "6234928976",
                                                    ReferenceId = "UniqueID1"
                                                },
                                                new PhoneReference
                                                {
                                                    PhoneNo = "2675466417",
                                                    ReferenceId = "UniqueID2"
                                                }
                                            };
        static List<Ebr> ebrList = new List<Ebr>() {
                                        new Ebr{
                                            PhoneNo = "7272046008",
                                            DateOfLastContact = DateTime.Parse("2011-06-14"),
                                            Type = EbrType.Sale
                                        },
                                        new Ebr{
                                            PhoneNo = "8773404100",
                                            DateOfLastContact = DateTime.Parse("2011-07-02"),
                                            Type = EbrType.Inquiry
                                        }
                                    };

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Contact Center Compliance API - Sample App");

            RunScrub();
            RunScrubWithReference();
            RunEBR();
            RunIDNC();
            RunProjectDetails();
            RunSFTPUpload();
            RunReassignedID();
            RunResOrBusiness();
            RunIDPremium();
            RunLitigatorScrub();

            Console.WriteLine("Completed");
            Console.ReadKey();
        }

        static void RunLitigatorScrub()
        {
            Console.WriteLine("----- Running Litigator Scrub -----");

            //Scrub Phone Nos if litigator or not            
            DisplayHelper.DisplayLitigatorScrubResponseList(client.LitigatorScrub(shortPhoneNumberList));
        }        

        static void RunScrub()
        {
            Console.WriteLine("----- Running Scrub -----");

            //Scrub Phone Nos without project id and campaign            
            DisplayHelper.DisplayScrubResponseList(client.Scrub(shortPhoneNumberList));

            //Scrub Phone Nos with project id only            
            DisplayHelper.DisplayScrubResponseList(client.Scrub(shortPhoneNumberList, "ProjectID"));

            //Scrub Phone Nos with project id and campaign id            
            DisplayHelper.DisplayScrubResponseList(client.Scrub(shortPhoneNumberList, "ProjectID", "CampaignID"));
        }

        static void RunScrubWithReference()
        {
            Console.WriteLine("----- Running Scrub With Reference -----");

            //Scrub Phone Nos(Reference ID) without project id and campaign            
            DisplayHelper.DisplayScrubResponseList(client.Scrub(shortPhoneReferenceList), true);

            //Scrub Phone Nos(Reference ID) with project id only            
            DisplayHelper.DisplayScrubResponseList(client.Scrub(shortPhoneReferenceList, "ProjectID"), true);

            //Scrub Phone Nos(Reference ID) with project id and campaign id            
            DisplayHelper.DisplayScrubResponseList(client.Scrub(shortPhoneReferenceList, "ProjectID", "CampaignID"), true);
        }

        static void RunEBR()
        {
            Console.WriteLine("----- Running EBR -----");

            //Adding EBR List without project id            
            client.AddEBR(ebrList);

            //Adding EBR List with project id            
            client.AddEBR(ebrList, "ProjectID");

            //Scrubbing Phone Nos and adding EBR List with project id and campaign id      
            var scrubResponseList = client.ScrubPlusAddEBR(shortPhoneNumberList, ebrList, "ProjectID", "CampaignID");
            DisplayHelper.DisplayScrubResponseList(scrubResponseList);

            //Scrubbing Phone Nos(Reference ID) and adding EBR List with project id and campaign id          
            var scrubReferenceResponseList = client.ScrubPlusAddEBR(shortPhoneReferenceList, ebrList, "ProjectID", "CampaignID");
            DisplayHelper.DisplayScrubResponseList(scrubReferenceResponseList, true);
        }

        static void RunIDNC()
        {
            Console.WriteLine("----- Running IDNC -----");

            //Adding IDNC with phone number list and project id            
            client.AddIDNC(shortPhoneNumberList, "ProjectID");

            //Removing IDNC with phone number list and project id            
            client.RemoveIDNC(shortPhoneNumberList, "ProjectID");

            //Getting IDNC count using a project id            
            IDNCDetail idncDetail = client.GetIDNCCount("ProjectID");
            DisplayHelper.DisplayIDNCDetail(idncDetail);

            //Getting IDNC status using phone number list and project id            
            List<IDNCStatus> idncStatusList = client.GetIDNCStatus(shortPhoneNumberList, "ProjectID");
            DisplayHelper.DisplayIDNCStatus(idncStatusList);
        }

        static void RunProjectDetails()
        {
            Console.WriteLine("----- Running Project -----");

            //Creating a project using project id and project name            
            DisplayHelper.DisplayProjectDetails(client.CreateProject("ProjectID", "ProjectName"));

            //Deactivate a project using project id            
            DisplayHelper.DisplayProjectDetails(client.DeactivateProject("ProjectID"));

            //Enumerating projects using a project id            
            DisplayHelper.DisplayProjectDetails(client.EnumerateProjects("ProjectID"));
        }

        static void RunSFTPUpload()
        {
            Console.WriteLine("----- Running SFTP Upload -----");

            //Notify if SFTP Uplaod is complete            
            client.NotifyOfSFTPComplete();
        }

        static void RunReassignedID()
        {
            Console.WriteLine("----- Running Identity Verification -----");

            Reassigned reassigned = new Reassigned
            {
                PhoneNumber = "2012001362",
                FirstName = "FirstName",
                LastName = "LastName",
                Address1 = "Address1",
                Address2 = "",
                City = "New Jersey",
                State = "NJ",
                PostalCode = "007302",
                ConsentDate = DateTime.Now,
                ReferenceId = "ReferenceId"
            };

            ReassignedIDResponse reassignedIDResponse = client.ReassignedID(reassigned);

            Console.WriteLine("Phone={0}, ReferenceId={1}, VerificationCode={2}, PhoneType={3}, MatchType={4}, MatchLevel={5}",
                reassignedIDResponse.Phone, reassignedIDResponse.ReferenceId, reassignedIDResponse.VerificationCode,
                reassignedIDResponse.PhoneType, reassignedIDResponse.MatchType, reassignedIDResponse.MatchLevel);
        }

        static void RunResOrBusiness()
        {
            Console.WriteLine("----- Running Residential or Business Phone Number Identification -----");

            ResOrBusinessResponse resOrBusinessResponse = client.ResOrBusiness("7072842774");

            Console.WriteLine("Phone={0}, ResOrBusiness={1}", resOrBusinessResponse.Phone, resOrBusinessResponse.ResOrBusiness);
        }

        static void RunIDPremium()
        {
            Console.WriteLine("----- Running ID Premium -----");

            IDPremiumResponse idPremiumResponse = client.IDPremium("7072842774");

            Console.WriteLine("Phone={0}, PhoneType={1}, OCN={2}, TelcoName={3}, ODate={4}", idPremiumResponse.Phone, idPremiumResponse.PhoneType,
                idPremiumResponse.OCN, idPremiumResponse.TelcoName, idPremiumResponse.ODate);
        }
    }
}
