using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Xml.Linq;
using System.Linq;

public class Write : MonoBehaviour
{
    public InputField text; //текст, который ввел пользователь
    //public GameObject loading; //картинка загрузка
    public Queue<Texture2D> textures = new Queue<Texture2D>();
    public List<string> uries;
    public GameObject Coridor; //коридор (наша комната, которую мы копируем)
    public List<GameObject> coridores = new List<GameObject>(); //список коридоров


    //resultSearch - строка с XML
    public IEnumerator ProcessingSearchResult(string resultSearch)
    {
        //проверяем, заполнен ли resultSearch
        if (string.IsNullOrWhiteSpace(resultSearch))
        {
            yield break;
        }

        XElement root = XElement.Parse(resultSearch); //Parse() - функция для создания XElement

        //ToArray - создание массива
        //Elements() - фунция, возращающая все вложенные элементы (тип XElement)
        //Select() - преобразует каждый пэлемент потока
        //Value - находим значение Attribute("id")
        string[] ids = root.Elements().Select(record => record.Attribute("id")?.Value).ToArray(); //создаем массив строк ids

        foreach (var item in ids) //проходимся по айдишникам
        {
            UnityWebRequest webRequest = UnityWebRequest.Get("http://syp.iis.nsk.su/sypwebapi/xml/tree/" + item);
            yield return webRequest.SendWebRequest(); //распаралеливаем запуск webRequest-а
            string userXML = webRequest.downloadHandler.text; //все, что выдается по ссылки сверху
            XElement user = XElement.Parse(userXML);

            //AddRange() - добавление коллекции
            //Descendants() - возращает коллекцию со всеми ее дочерними элементами
            //Where() - фильтрует поток по условию (у нас это лямбда функция)
            uries.AddRange(user.Descendants().Where(XMLItem => XMLItem.Attribute("prop")?.Value == "uri").Select(XMLS => XMLS.Value)); //последним Select() выбираем текст
        }
        foreach (var item in uries) //проходимся по uries
        {
            yield return ChangePhoto("http://syp.iis.nsk.su/sypwebapi/photo?uri=" + item + "&s=normal"); //делаем запрос на создание текстуры
        }
        
        int countTextures = textures.Count; //находим колличество текстур

        //находим нужное нам колличество коридоров
        int countCoridores = countTextures / 4;
        if (countTextures % 4 != 0)
        {
            countCoridores++; //увеличивает countCoridores
        }
        
        for (int i = 0; i < countCoridores; i++)
        {
            GameObject newCoridor = Instantiate(Coridor); //создаем новый коридор
            newCoridor.transform.position = new Vector3(-20 - (i*20), 4, 0); //смещаем коридор
            coridores.Add(newCoridor); //добавляем новый коридор

            ComnataInfo comnata = newCoridor.GetComponent<ComnataInfo>(); //получаем компонент с GameObject newCoridor

            float x = 0;
            float y = 0;
            float xy = 0;

            Texture2D texture = textures.Dequeue(); //вынимаем текстуру (и используем ее), чтоб ее больше не было в очереди (textures)
            x = texture.width; //присваивоем переменной x ширину текстуры
            y = texture.height; //присваивоем переменной x длину текстуры

            //подгон пропорций размеров картин
            if (x > y)
            {
                xy = y / x; //пропорция
                comnata.pictures[0].size = new Vector2(1.4f, 1.4f*xy);  //меняем размер фото
                comnata.ramks[0].transform.localScale = new Vector3(1, xy, 1); //меняем размер рамки
            } else
            {
                xy = x / y;
                comnata.pictures[0].size = new Vector2(1.4f * xy, 1.4f);
                comnata.ramks[0].transform.localScale = new Vector3(xy, 1, 1);
            }
            
            comnata.pictures[0].sprite = Sprite.Create(texture, new Rect(0f,0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100f); //присваиваем первой картине в одно коридоре(комнате) текстуру (нужную нам картину)

            Texture2D texture1 = textures.Dequeue();

            x = texture1.width; //присваивоем переменной x ширину текстуры
            y = texture1.height; //присваивоем переменной x длину текстуры

            //подгон пропорций размеров картин
            if (x > y)
            {
                xy = y / x; //пропорция
                comnata.pictures[1].size = new Vector2(1.4f, 1.4f * xy);
                comnata.ramks[1].transform.localScale = new Vector3(1, xy, 1);
            }
            else
            {
                xy = x / y;
                comnata.pictures[1].size = new Vector2(1.4f * xy, 1.4f);
                comnata.ramks[1].transform.localScale = new Vector3(xy, 1, 1);
            }

            comnata.pictures[1].sprite = Sprite.Create(texture1, new Rect(0f, 0f, texture1.width, texture1.height), new Vector2(0.5f, 0.5f), 100f); //присваиваем второй картине в одно коридоре(комнате) текстуру (нужную нам картину)

            Texture2D texture2 = textures.Dequeue();

            x = texture2.width; //присваивоем переменной x ширину текстуры
            y = texture2.height; //присваивоем переменной x длину текстуры

            //подгон пропорций размеров картин
            if (x > y)
            {
                xy = y / x; //пропорция
                comnata.pictures[2].size = new Vector2(1.4f, 1.4f * xy);
                comnata.ramks[2].transform.localScale = new Vector3(1, xy, 1);
            }
            else
            {
                xy = x / y;
                comnata.pictures[2].size = new Vector2(1.4f * xy, 1.4f);
                comnata.ramks[2].transform.localScale = new Vector3(xy, 1, 1);
            }
            comnata.pictures[2].sprite = Sprite.Create(texture2, new Rect(0f, 0f, texture2.width, texture2.height), new Vector2(0.5f, 0.5f), 100f);

            Texture2D texture3 = textures.Dequeue();
            x = texture3.width; //присваивоем переменной x ширину текстуры
            y = texture3.height; //присваивоем переменной x длину текстуры

            //подгон пропорций размеров картин
            if (x > y)
            {
                xy = y / x; //пропорция
                comnata.pictures[3].size = new Vector2(1.4f, 1.4f * xy);
                comnata.ramks[3].transform.localScale = new Vector3(1, xy, 1);
            }
            else
            {
                xy = x / y;
                comnata.pictures[3].size = new Vector2(1.4f * xy, 1.4f);
                comnata.ramks[3].transform.localScale = new Vector3(xy, 1, 1);
            }
            comnata.pictures[3].sprite = Sprite.Create(texture3, new Rect(0f, 0f, texture3.width, texture3.height), new Vector2(0.5f, 0.5f), 100f);
        }
        //loading.SetActive(false); //окно загрузки
    }

    public IEnumerator ChangePhoto(string url)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url); //отправляет запрос на скачивание тексуры
        yield return www.SendWebRequest(); //отправляет запрос на url
        Texture2D texture2D = DownloadHandlerTexture.GetContent(www); //скачивает изображение
        textures.Enqueue(texture2D); //добавляем в textures (очередь) texture2D
    }

    IEnumerator GetRequest(string uri) //делает запросы
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(uri);  
        yield return webRequest.SendWebRequest(); //SendWebRequest() - отправляет запрос
        string text1 = webRequest.downloadHandler.text; //в  webRequest.downloadHandler.text unity сохраняет результаты web-запросов, мы его записываем в text1 
        yield return StartCoroutine(ProcessingSearchResult(text1)); //передаем text1 в ProcessingSearchResult
    }
    
    public void IFWrite() //ввел ли пользователь текст
    {
        //loading.SetActive(true); //делаем окно загрузки активным
        textures.Clear(); //чистим текстуры
        uries.Clear(); //чистим uries

        //уничтожаем коридоры с карты
        foreach (var item in coridores)
        {
            Destroy(item); //уничтожаем очередной коридор
        }

        coridores.Clear(); //чистим coridores

        //text.text - текст, который ввел пользователь
        //StartCoroutine, yield return - запускает другой метод асинхронно распаралеивает процессы. Если долго выполняется, он его бросает и потом возращается
        StartCoroutine(GetRequest("http://syp.iis.nsk.su/sypwebapi/xml/search/" + text.text)); //заходим на сайт, с поиском ФИО, и вбиваем туда наше ФИО
    }
}
