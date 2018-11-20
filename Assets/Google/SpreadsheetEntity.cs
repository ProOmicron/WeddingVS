using UnityEngine;
using Google.GData.Client; 
using Google.GData.Spreadsheets;
using UnityEngine.UI;

public class SpreadsheetEntity : MonoBehaviour
{
    public Text text;

    const string _ClientId = "159933133177-obpisk9ajkol5rarvn1bdt04l2m5577s.apps.googleusercontent.com";
    const string _ClientSecret = "GlwLiXPd9OZPxf_WqR9P3_Vl";
    // enter Access Code after getting it from auth url
    const string _AccessCode = "4/mwAqwOMc2xos9mty7AG9gQ7dQwjgx1JZ-M32ZW6opQXKRGDVtTbHdoI";
    // enter Auth 2.0 Refresh Token and AccessToken after succesfully authorizing with Access Code
    const string _RefreshToken = "1/z6Ocr_E01RrlTJpM10qd6l-YgXndwWgTjSKgM1ole17Waztip39h3WjFi2Z7mnbK";
    const string _AccessToken = "ya29.GltaBgt8DeADQIjS3x7Q5NIMabLRzOvACXO4CnppxfTTNRUp5MUbA9uxhkvYgyaaS6JFlVybCHMjm-x1ONQeC7ThC0VIxKvggA7Zpt-vfCL2g1-gjvHOMvjB4ktW";

    const string _SpreadsheetName = "Wedding_Score";


    static SpreadsheetsService service;


    public static GOAuth2RequestFactory RefreshAuthenticate()
    {
        OAuth2Parameters parameters = new OAuth2Parameters()
        {
            RefreshToken = _RefreshToken,
            AccessToken = _AccessToken,
            ClientId = _ClientId,
            ClientSecret = _ClientSecret,
            Scope = "https://www.googleapis.com/auth/drive https://spreadsheets.google.com/feeds",
            AccessType = "offline",
            TokenType = "refresh"
        };
        string authUrl = OAuthUtil.CreateOAuth2AuthorizationUrl(parameters);
        return new GOAuth2RequestFactory("spreadsheet", "walkerwedding", parameters);
    }

    static void Auth()
    {
        GOAuth2RequestFactory requestFactory = RefreshAuthenticate();

        service = new SpreadsheetsService("walkerwedding");
        service.RequestFactory = requestFactory;
    }
    
    // Use this for initialization
    void Start()
    {
        Auth();

        SpreadsheetQuery query = new SpreadsheetQuery();

        // Make a request to the API and get all spreadsheets.
        SpreadsheetFeed feed = service.Query(query);

        if (feed.Entries.Count == 0)
        {
            Debug.Log("There are no spreadsheets in your docs.");
            return;
        }

        AccessSpreadsheet(feed);
    }

    void AccessSpreadsheet(SpreadsheetFeed feed)
    {

        string name = _SpreadsheetName;
        SpreadsheetEntry spreadsheet = null;

        foreach (AtomEntry sf in feed.Entries)
        {
            if (sf.Title.Text == name)
            {               
                spreadsheet = (SpreadsheetEntry)sf;
            }
        }

        if (spreadsheet == null)
        {
            Debug.Log("There is no such spreadsheet with such title in your docs.");
            return;
        }


        // Get the first worksheet of the first spreadsheet.
        WorksheetFeed wsFeed = spreadsheet.Worksheets;
        WorksheetEntry worksheet = (WorksheetEntry)wsFeed.Entries[0];

        // Define the URL to request the list feed of the worksheet.
        AtomLink listFeedLink = worksheet.Links.FindService(GDataSpreadsheetsNameTable.ListRel, null);

        // Fetch the list feed of the worksheet.
        ListQuery listQuery = new ListQuery(listFeedLink.HRef.ToString());
        ListFeed listFeed = service.Query(listQuery);

        string stringText = "";

        foreach (ListEntry row in listFeed.Entries)
        {
            stringText += "Element: " + row.Elements[0].Value + ", " + row.Elements[1].Value + '\n';
            Debug.Log("Element: " + row.Elements[0].Value + ", " + row.Elements[1].Value);
        }
        text.text = stringText;

    }
}

