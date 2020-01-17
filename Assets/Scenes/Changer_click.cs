using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Changer_click : MonoBehaviour
{

    public Text Change;
    Renderer Renderer;

    public Color color;
    public string data;
    public GameObject gameObject;

    public Button button;


    // загрузка данных из файла, загрузка предыдущей сцены
    void Awake()
    {
        data = File.ReadAllText(gameObject.GetInstanceID() + ".txt");
        JsonUtility.FromJsonOverwrite(data, this);
        gameObject.GetComponent<Renderer>().material.color = color;
    }


    void Start()
    {
        Renderer = GetComponent<Renderer>();
       // Renderer.material.color = Color.white;
    }

    /*
     * Метод нажатия кнопкой мыши
     * Метод OnMouseDown - возращает true, при однократном нажати
     *
    */

    public void OnMouseDown()
    {
    
            if(GetComponent<Renderer>().material.color != Color.blue)
            {
                GetComponent<Renderer>().material.color = Color.blue;
            }
            else
            {
                GetComponent<Renderer>().material.color = Color.white;
            }
    }


    private void Update()
    {
        if (gameObject.GetComponent<Renderer>().material.color == Color.white)
        {
            button.GetComponentInChildren<Text>().text = "White";
        }
        else
        {
            button.GetComponentInChildren<Text>().text = "Blue";
        }
 
    }

    public void Color_chart()
    {
        if(gameObject.GetComponent<Renderer>().material.color != Color.blue)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    /// <summary>
    /// CollectionInfo() - метод получения цвета объектов на сцене
    /// </summary>
    void OnApplicationQuit()
    {
        color = gameObject.GetComponent<Renderer>().material.color;
        data = JsonUtility.ToJson(this, true);
        File.WriteAllText(gameObject.GetInstanceID() + ".txt", data);
    }


    
    

}
