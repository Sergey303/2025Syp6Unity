using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class PhotoURL : MonoBehaviour
{
    public List<string> photo2011url;
    public const string photurl = "http://syp.iis.nsk.su/sypwebapi/photo";
    public const string xml_url = "http://syp.iis.nsk.su/sypwebapi/xml/tree/";
    public List<Texture2D> textures = new List<Texture2D>();

    public Camera camm;
    public GameObject target;
    public List<int> cats_nambers;
    public int kartina_id;
    public Image_class[] Img_class;
    public List<SpriteRenderer> images;
    public SpriteRenderer image;

    public Jam main_script;

    public void Start_Script()
    {
        main_script.Img_class.Clear();
        //for (int i = 0; i < photo2011url.Count; i++)
        //{
        //    Image_class TTT = new Image_class();
        //    TTT.ID = i;
        //    TTT.Images = new List<Texture2D>();
        //    main_script.Img_class.Add(TTT);
        //}
        //StartCoroutine(LoadFromServer(photo2011url[3]));
        //StartCoroutine(Start_Loading());
    }

    IEnumerator LoadFromServer(int ID ,string url)
    {
        var request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
        //Debug.Log(request.downloadHandler.text);
        string result = request.downloadHandler.text;
        if (string.IsNullOrWhiteSpace(result))
        {
            yield break;
        }
        XElement root = XElement.Parse(result);
        request.Dispose();
        List<string> uris = root.Descendants().Where(x => x.Attribute("prop")?.Value == "uri").Select(x => x.Value).ToList();
        List<Texture2D> texturesNEW = new List<Texture2D>();

        foreach (var item in uris)
        {
            UnityWebRequest req = UnityWebRequestTexture.GetTexture(photurl + "?uri=" + item + "&s=normal");
            yield return req.SendWebRequest();
            Texture2D myTexture = DownloadHandlerTexture.GetContent(req);
            //texturesNEW.Add(myTexture);
            List<Texture2D> images1 = main_script.Img_class[ID].Images;
            if(images1 == null)
            {
                images1 = main_script.Img_class[ID].Images = new List<Texture2D>();
            }
            images1.Add(myTexture);
            texturesNEW.Add(myTexture);
        }

        for (int i = 0; i < texturesNEW.Count; i++)
        {
            //main_script.Img_class[i].cats.Add(Sprite.Create(texturesNEW[i], new Rect(0.0f, 0.0f, texturesNEW[i].width, texturesNEW[i].height), new Vector2(0.5f, 0.5f), 100f));
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        main_script.Img_class.Clear();
        for (int i = 0; i < photo2011url.Count; i++)
        {
            Image_class TTT = new Image_class();
            TTT.ID = i;
            TTT.Images = new List<Texture2D>();
            main_script.Img_class.Add(TTT);
        }
        //StartCoroutine(LoadFromServer(photo2011url[3]));
        StartCoroutine(Start_Loading());
    }

    private IEnumerator Start_Loading()
    {
        for (int i = 0; i < photo2011url.Count; i++)
        {
            yield return(LoadFromServer(i, photo2011url[i]));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
            Ray ray = camm.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.tag == "Strelka")
                {
                    target = hitInfo.collider.gameObject;
                    //kartina_id = target.GetComponent<StrelkaID>().ID;
                }
                else
                {
                    target = null;
                }
            }

            if (target != null)
            {
                //if(textures.Count == 0)
                //{
                //    return;
                //}

                //if (target.name == "left")
                //{
                //    kartina_id -= 1;
                //    if (kartina_id < 0)
                //    {
                //        kartina_id = textures.Count - 1;
                //    }
                //}
                //if (target.name == "right")
                //{
                //    kartina_id += 1;
                //    if (kartina_id > textures.Count - 1)
                //    {
                //        kartina_id = 0;
                //    }
                //}
                //image.sprite = Sprite.Create(textures[kartina_id], new Rect(0.0f, 0.0f, textures[kartina_id].width, textures[kartina_id].height), new Vector2(0.5f, 0.5f), 100f);
            }
        }
    }
}
