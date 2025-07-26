using UnityEngine;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Collections;
using System.Xml.Linq;
using System.Linq;
using System.Net;
using static System.Net.WebRequestMethods;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Text;

public class NameToCorridor : MonoBehaviour
{
    private const string searchName = "http://syp.iis.nsk.su/sypwebapi/xml/search/";
    // Url that returns people's ID's (takes human's name in RUS)
    private const string getPhotoURL = "http://syp.iis.nsk.su/SypWebApi/photo?uri=";
    // Url that returns all photos with person in it (takes human's Id)
    public InputField inputField;
    private readonly List<Texture2D> textures = new List<Texture2D>();
    // List with all textures
    public GameObject start;
    // Start of corridor
    public GameObject Section;
    // Section of corridor
    public List<GameObject> sections;
    // List with all sections (and end)
    public List<string> photoInfo;
    // List with information about photo (element i of photoInfo corresponds to element i of textures)
    private readonly List<string> photoIds = new List<string>();
    // List with Ids of photoes
    private readonly List<string> list_url = new List<string>();
    // List with all urls of photoes
    public MainMenu mainMenuScript;
    // Main script on Main

    public IEnumerator ImportPicture(string humanName)
    {
        mainMenuScript.TurnOnLoading();

        list_url.Clear();
        photoIds.Clear();
        //Clears all lists

        using (var client = new HttpClient())
        {

            string apiUrl = searchName + humanName;
            HttpResponseMessage response = client.GetAsync(apiUrl).GetAwaiter().GetResult();
            // Get response from Url that returns people's ID's

            string Response = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            // Turns response into string

            XElement XResp;
            XResp = XElement.Parse(Response);
            // Turns response into XElement

            string[] records = XResp.Elements("record").Select(x => x.Attribute("id").Value).Take(5).ToArray();
            // Makes an array of people IDs
            string photoSites; // Url with urls of photoes

            

            
            foreach (string id in records)
            {
                photoSites = "http://syp.iis.nsk.su/Sypwebapi/xml/tree/" + id; // Url with urls of photoes

                HttpResponseMessage photoURLs = client.GetAsync(photoSites).GetAwaiter().GetResult();
                string PhotoURLs = photoURLs.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                // Turns response ito string

                var XPhotoes = XElement.Parse(PhotoURLs); // turns string into XElement

                var potomki_inversa = XPhotoes.Elements("inverse").First().Descendants();
                var filtrovanye_potomki = potomki_inversa.Where(x => x.Attribute("prop")?.Value == "uri");
                // Takes all elements with attribute "prop" == uri

                string[] inverse5 = filtrovanye_potomki.Select(x => x?.Value).ToArray();
                // Takes all values from elements
                string[] pIds = potomki_inversa.Where(x => x.Attribute("tp")?.Value == "photo-doc").Select(y => y.Attribute("id")?.Value).ToArray();
                // takes all IDs of photoes

                for (int i = 0; i < inverse5.Count(); i++)
                {
                    list_url.Add(inverse5[i]);
                    photoIds.Add(pIds[i]);
                    photoInfo.Add("Loading");
                    // appends values to lists
                }


            }
            
            for (int i = 0; i < list_url.Count; i++)
            {
                yield return Change_Photo(i);
                // calls Change_Photo() for each element
            }
        }
        mainMenuScript.TurnOffLoading();
        if (list_url.Count == 0)
        {
            MakeZeroCorridor();
        }
    }
    public IEnumerator Change_Photo(int ind)
    {
        string url = getPhotoURL + list_url[ind] + "&s=normal"; // makes url with photo
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        // sends request to download photo
        Texture2D texture2D = DownloadHandlerTexture.GetContent(www); // downloads content (photo)
        textures.Add(texture2D); // adds photo to list

        int currentLengthTextures = textures.Count - 1;
        photoInfo[currentLengthTextures] = GetPhotoInfo(photoIds[ind]);
        // adds to photoInfo information about current photo
        if (textures.Count == list_url.Count) // if all textures are downloaded
        {
            Section.SetActive(true);
            CorridorMake();
            Section.SetActive(false);
            // makes corridor
        }

    }

    public string GetPhotoInfo(string photoId)
    {
        string[] humans; // people on photo
        string[] orgs; // organisations on photo
        photoId = "http://syp.iis.nsk.su/Sypwebapi/xml/tree/" + photoId; // Id of photo
        using (var client = new HttpClient())
        {
            HttpResponseMessage response = client.GetAsync(photoId).GetAwaiter().GetResult();
            string Response = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            // Turns response ito string

            var XResp = XElement.Parse(Response).Elements("inverse").Descendants();
            // Get xml from server and take all descendants from it.

            orgs = XResp.Where(x => x.Attribute("tp")?.Value == "org-sys").Select(y => y.Value).ToArray();
            //Take all elements with value of attribute tp == org-sys, get text from them and make an array.
            humans = XResp.Where(x => x.Attribute("tp")?.Value == "person").Select(y => y.Value).ToArray();
            //Take all elements with value of attribute tp == person, get text from them and make an array.
        }

        StringBuilder text = new StringBuilder("Мастерская: ");
        // StringBuilder is string, but more flexable.
        foreach (string org in orgs)
        {
            text.Append(org + ", ");
        }
        text.Append('\n' + "Участники фото: ");
        foreach (string person in humans)
        {
            text.Append(person + ", ");
        }
        // Make text
        return text.ToString();
    }

    public void CorridorMake()
    {
        

        foreach (GameObject section in sections)
        {
            Destroy(section);
        }
        sections.Clear();
        // Destroys all previous copies

        float Scaler(float width, float height) // Makes that photo fits the frame
        {
            float scale;

            if (width > height)
            {
                scale = (float)(67.2 / width);
            }
            else
            {
                scale = (float)(67.2 / height);
            }
            // 67.2 is ppcu
            return scale;
        } 


        float sizer; // Scale of photo
        int SecNum = (int)((float)textures.Count / 2 + 0.5); // Number of sections

        for (int i = 0; i < SecNum; i++)
        {
            
            GameObject copy = Instantiate(Section);
            copy.name = "SectionCopy" + i;
            copy.transform.position = new Vector3(0, 0, i * 10 - 5);
            sections.Add(copy);
            // Creates, renames, positions and adds copy to list

            SectoreBase bases = copy.GetComponent<SectoreBase>();
            // Gets component with photo frames and photo info signs

            Rect rec1 = new Rect(0, 0, textures[i * 2].width, textures[i * 2].height);
            bases.img1.sprite = Sprite.Create(textures[i * 2], rec1, new Vector2(0.5f, 0.5f));
            // Turns images into textures
            sizer = Scaler(textures[i * 2].width, textures[i * 2].height);
            bases.img1.transform.localScale = new Vector3(sizer, sizer, 1);
            // Scales the image
            bases.pic1info.text = photoInfo[i * 2];
            // Sets text

            if (i * 2 + 1 < textures.Count) // if there are are odd amount of textures and even amount of frames, one frame will remain untouched 
            {
                Rect rec2 = new Rect(0, 0, textures[i * 2 + 1].width, textures[i * 2 + 1].height);
                bases.img2.sprite = Sprite.Create(textures[i * 2 + 1], rec2, new Vector2(0.5f, 0.5f));
                sizer = Scaler(textures[i * 2 + 1].width, textures[i * 2 + 1].height);
                bases.img2.transform.localScale = new Vector3(sizer, sizer, 1);
                bases.pic2info.text = photoInfo[i * 2 + 1];
                // the same as 207-214
            }
            

        }
        GameObject end = Instantiate(start);
        end.transform.position = new Vector3(0, 0, SecNum * 10 - 5);
        end.transform.rotation = new Quaternion(0, 180, 0, 0);
        sections.Add(end);
        // makes an end of corridor (almost the same as with sections)
        
    }

    public void NameChanged() // if input field gets a new name (if Enter is pressed)
    {
        photoInfo.Clear();
        textures.Clear();
        StartCoroutine(ImportPicture(inputField.text));
    }
    public void MakeZeroCorridor() // Makes corridor with 0 sections
    {
        foreach (GameObject section in sections)
        {
            Destroy(section);
        }
        sections.Clear();

        GameObject end = Instantiate(start);
        end.transform.position = new Vector3(0, 0, -5);
        end.transform.rotation = new Quaternion(0, 180, 0, 0);
        sections.Add(end);
    }

    void Start()
    {
        Section.SetActive(false);
        MakeZeroCorridor();
    }

}
/*
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
Лосось
В томате
*/
