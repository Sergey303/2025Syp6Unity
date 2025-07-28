using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    public Rigidbody rigidbody; //физика
    public Transform man; //игрок (мы)
    public Transform camera; //камера от 1 лица
    public Transform camera2; //камера от 3 лица
    public float horisont;
    public float verical; 
    public float speed; //скорость передвижения
    public float speedConstant; //скорость константа (нужна для ускорения)
    public float speedjump; //скорость прыгания (на сколько мы прыгаем)
    public float mouseX; 
    public float mouseY;
    public float minVericalAngle; // максимальный угол поворота
    public float maxVericalAngle; // минимальный угол поворота
    public float xRotation;
    public float yRotation;
    public float sensitivity; //чувствительность
    public bool IsCameraActive; //отвечает за камеру F5
    public bool IsCameraChanged; //поменяли ли мы камеру в этот раз
    public GameObject target;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>(); //получаем компонент Rigidbody с нашего объекта
        rigidbody.ToString(); //делаем rigidbody строкой
    }
    
    void FixedUpdate()
    {
        //ходьба (движение влево-вправо)
        horisont = Input.GetAxis("Horizontal");
        verical = Input.GetAxis("Vertical");
        Vector3 mov = new Vector3(horisont, 0, verical);
        mov = man.TransformDirection(mov) * speed; //поворот в нужное направление
        rigidbody.velocity = speed * mov; //двигаемся

        //прыжок
        if (Input.GetKeyDown(KeyCode.Space)) //если нажат пробел
        {
            man.transform.position = new Vector3(man.transform.position.x, man.transform.position.y + speedjump, man.transform.position.z); //прыжок (телепортация)
            //rigidbody.velocity = transform.up * speedjump; //прыжок (перемещение)
        }

        //ускорение
        if (Input.GetKey(KeyCode.LeftShift)) //если нажат левый шифт
           speed = speedConstant + 5; //прибавляем к скорости 5
        if (Input.GetKeyUp(KeyCode.LeftShift)) //обратно к обычной скорости
            speed = speedConstant;
    }

    //ломание блоков
    public void OnTriggerEnter(Collider other) //наше поле соприкосается или пересекается с объектом
    {
        if (other.tag == "Block") //если нажали и там был предмет тагом "Block"
        {
            target = other.gameObject; //записываем target
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Block")
        {
            target = null; //обнуляем target
        }
    }

    void Update()
    {
        //ломание блоков
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(target); //уничтожаем цель
        }

        // функция F5
        if ((Input.GetKeyUp(KeyCode.F5)) && !IsCameraChanged)  //проверяем нажата ли (отпустили ли) F5 и не меняли мы уже камеру
        {
            if (IsCameraActive) //если камера активна
            {
                var c1 = camera.gameObject.GetComponent<Camera>(); //берем объект c1 (камера 1) 
                var c2 = camera2.gameObject.GetComponent<Camera>(); //берем объект c2 (камера 2)
                c1.enabled = true;
                c2.enabled = false;
                IsCameraActive = false; //выключаем IsCameraActive
            }
            else
            {
                var c1 = camera.gameObject.GetComponent<Camera>();
                var c2 = camera2.gameObject.GetComponent<Camera>();
                c1.enabled = false;
                c2.enabled = true;
                IsCameraActive = true; //включаем IsCameraActive
            }
        }

        //двигание мышкой
        mouseX = Input.GetAxis("Mouse X") * sensitivity; //1 влево-вправо
        xRotation = man.localEulerAngles.y + mouseX;

        mouseY -= Input.GetAxis("Mouse Y") * sensitivity; //вверх-вниз
        yRotation = mouseY;
        yRotation = Mathf.Clamp(yRotation, minVericalAngle, maxVericalAngle); //3 ограничиваем поворот минимальным и максимальным углом поворота

        man.localEulerAngles = new Vector3(0, xRotation, 0); //меняем вектор направления 
        camera.localEulerAngles = new Vector3(yRotation, 0, 0); //меняем направление камеры ()
    }
}
