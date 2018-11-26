Package to interface and use the available API endpoints of Contact Center Compliance. 
Usage requires an account with Contact Center Compliance. 

See [www.dnc.com](https://www.dnc.com/) to sign up.

## Getting Started
- First off, you need to import the ContactCenterCompliance API packages from NuGet. Look for "ContactCenterComplianceAPI". After clicking Manage NuGet from your project you can now install the package. 
- On the actual usage, please reference ContactCenterCompliance. Like so, using ContactCenterCompliance;
- You can now instantiate the CCCApi class indicating your API key -> CCCApi client = new CCCApi("--- API Key ---");
- You're all set!. Please follow the following quickstart examples. 

## Scrubbing a Phone Number or Multiple Phone Numbers
- Scrub Phone Nos with Project Code
```c#
CCCApi client = new CCCApi("--- API Key ---");

//sample phone numbers
List<string> shortPhoneNumberList = new List<string>() {
				"6234928976",
				"9545031806",
				"2675466417"
			 };

List<ScrubResponse> scrubResponseList = client.Scrub(shortPhoneNumberList, "ProjectID");
```

## Litigator Only Scrub
```c#
CCCApi client = new CCCApi("--- API Key ---");

//sample phone numbers
List<string> shortPhoneNumberList = new List<string>() {
				"6234928976",
				"9545031806",
				"2675466417"
			 };

List<LitigatorResponse> litigatorResponseList = client.LitigatorScrub(shortPhoneNumberList)
```

## Project Settings
- Creating a project using project id and project name
```c#
CCCApi client = new CCCApi("--- API Key ---");
Project project = client.CreateProject("ProjectID", "ProjectName")
```

- Deactivate a project using project id
```c#
CCCApi client = new CCCApi("--- API Key ---");
Project project = client.DeactivateProject("ProjectID")
```

- Enumerating projects using a project id
```c#
CCCApi client = new CCCApi("--- API Key ---");
Project project = client.EnumerateProjects("ProjectID")
```

## Add to or Delete from Internal DNC List
- Given the following initiated routines:
```c#
CCCApi client = new CCCApi("--- API Key ---");

//sample phone numbers
List<string> shortPhoneNumberList = new List<string>() {
				"6234928976",
				"9545031806",
				"2675466417"
			 };
```

- Adding of IDNC with phone number list and project id
```c#
client.AddIDNC(shortPhoneNumberList, "ProjectID");
```

- Removing IDNC with phone number list and project id
```c#
client.RemoveIDNC(shortPhoneNumberList, "ProjectID");
```

- Getting IDNC count using a project id
```c#
IDNCDetail idncDetail = client.GetIDNCCount("ProjectID");
```

- Getting IDNC status using phone number list and project id
```c#
List<IDNCStatus> idncStatusList = client.GetIDNCStatus(shortPhoneNumberList, "ProjectID");
```

## Add to EBR List
- Given the following initiated routes:
```c#
CCCApi client = new CCCApi("--- API Key ---");

//sample ebr list
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
//sample phone numbers
List<string> shortPhoneNumberList = new List<string>() {
				"6234928976",
				"9545031806",
				"2675466417"
			 };
```

- Adding EBR List with project id
```c#
client.AddEBR(ebrList, "ProjectID");
```

- Scrubbing Phone Nos and adding EBR List with project and campaign id
```c#
List<ScrubResponse> scrubResponseList = client.ScrubPlusAddEBR(shortPhoneNumberList, ebrList, "ProjectID", "CampaignID");
```

## On-demand processing for SFTP Uploads
- Notify if SFTP Upload is complete
```c#
CCCApi client = new CCCApi("--- API Key ---");
client.NotifyOfSFTPComplete();
```

## Identity Verification
```c#
CCCApi client = new CCCApi("--- API Key ---");
Reassigned reassigned = new Reassigned {
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
```

## Residential or Business Phone Number Identification
```c#
CCCApi client = new CCCApi("--- API Key ---");
ResOrBusinessResponse resOrBusinessResponse = client.ResOrBusiness("7072842774");
```

## ID Premium
```c#
CCCApi client = new CCCApi("--- API Key ---");
IDPremiumResponse idPremiumResponse = client.IDPremium("7072842774");
```