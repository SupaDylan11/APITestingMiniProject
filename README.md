<img src="https://boolerang.co.uk/wp-content/uploads/job-manager-uploads/company_logo/2018/04/SG-Logo-Black.png" alt="Sparta Logo" width="200"/>

# APITestingMiniProject
This is a api mini testing project.

>
# 1. Information

## 1.1 Using the API
Include the text for Instruction to the API here
  
Documentation for the API is available from https://musicbrainz.org/doc/MusicBrainz_API

## 1.2 Extensions
  
Adding a new service requires the addition of two Class files
- The Service class file (e.g. `MBSingleReleaseService.cs`)
- The Data Model class file (e.g. `SingleReleaseModel.cs`)

### 1.2.1 The Service class

#### Dependencies
```csharp
using MusicBrainzMiniAPiApp.DataHandling;
using MusicBrainzMiniAPiApp.HttpManager;
using Newtonsoft.Json.Linq;
```

#### Namespace
```csharp
namespace MusicBrainzMiniAPiApp.Services;
```

#### Public Properties

```csharp
public CallManager CallManager { get; set; }
public JObject JSonResponse { get; set; }
public DTO<SingleReleaseReponse> MusicBrainzDTO { get; set; }
public string MusicResponse { get; set; }
```
#### Public Methods
##### Constructor
```csharp
public MBSingleReleaseService()
{
    CallManager = new CallManager();
    MusicBrainzDTO = new DTO<SingleReleaseReponse>();
}
```
##### Requesting and Parsing the Data
```csharp
public async Task MakeMusicRequestAsync(string query)
{
    MusicResponse = await CallManager.MakeRequestAsync(query);
    JSonResponse = JObject.Parse(MusicResponse);
    MusicBrainzDTO.DeserialiseResponse(MusicResponse);
}
```

#### Helper Functions
Down to the user's discretion

### 1.2.2 The Data model class

#### Dependencies

```csharp
using MusicBrainzMiniAPiApp.DataHandling;
```
#### Namespace
```csharp
namespace MusicBrainzMiniAPiApp.Services;
```

#### Class signature/Interfaces
Models must implement the `IResponse` interface as below.
```csharp
public class SingleReleaseReponse : IResponse
```

## 1.3 Class Diagram

![ClassDiagram1](https://user-images.githubusercontent.com/106960721/183068795-583e2227-5992-4792-beba-9d9f740e8788.png)

## 1.4 Coverage
The only entities covered for now are <b>release</b> and <b>artist</b>.
We test against three different GET requests, as per the MusicBrainz documentation:
- lookup:   ```/<ENTITY_TYPE>/<MBID>?inc=<INC>```
- browse:   ```/<RESULT_ENTITY_TYPE>?<BROWSING_ENTITY_TYPE>=<MBID>&limit=<LIMIT>&offset=<OFFSET>&inc=<INC>```
- search:   ```/<ENTITY_TYPE>?query=<QUERY>&limit=<LIMIT>&offset=<OFFSET>```

### 1.4.1 Lookup Coverage
The lookup release tests check for the following properties:
- title
- date
- cover art
- country

### 1.4.2 Browse Coverage
The browse release tests check for the following properties:
- release count

### 1.4.3 Search Coverage
The search artist tests check for the following properties:
- artist name
- country
- disambiguation type
- group type

## 1.5 Found Defects

- The 'status' property is poorly named / confusing
- The 'date' property is formatted inconsistently
- Empty search results return with 200 OK
