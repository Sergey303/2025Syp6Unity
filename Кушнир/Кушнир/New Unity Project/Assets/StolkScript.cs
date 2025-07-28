using UnityEngine;
using UnityEngine.UI;
public class StolkScript : MonoBehaviour
{
    public int count;
    public Text TextCount;


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Объект столкнулся с: " + collision.gameObject.name);
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Столкновение со стеной!");
            count += 1;
            TextCount.text = count.ToString();
            

            Debug.Log(count);
        }
    }
}  

