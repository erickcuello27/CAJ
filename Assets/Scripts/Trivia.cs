using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Trivia : MonoBehaviour
{
    public Text Pregunta;
    public Text RespuestaA;
    public Text RespuestaB;
    public Text RespuestaC;
    public Text RespuestaD;

    public Text ButtonA;
    public Text ButtonB;
    public Text ButtonC;
    public Text ButtonD;

    public Text TiempoText;

    public GameObject PantallaPuntos;
    public GameObject PantallaTrivia;
    public GameObject Pantalla;

    private int[] preguntasID = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    private string[] respuestaCorrecta = { "B", "D", "D", "D", "A", "C", "B", "B", "C", "C" };
    private string[] preguntasTrivia =
    {
        "¿Qué medidas podemos tomar para evitar el contagio?",
        "¿Cuál de estos articulos de compra es más esencial?",
        "¿Cuáles son los síntomas del COVID-19?",
        "¿Cuáles articulos se utilizan para protegerse del COVID-19?",
        "¿Cuál es el horario del toque de queda?",
        "¿Para qué fue establecido el toque de queda?",
        "¿En qué parte de China se originó el virus?",
        "¿A quienes afecta más el Covid-19?",
        "¿Donde debes comprar los insumos para protegerte del Covid-19?",
        "¿Cuánto dura el periodo de incubación del virus?"
    };
    private string[] respuestasA =
    {
        "Cubrirse la boca.",
        "Papel de baño.",
        "Fiebre, dolor de cabeza y dolor muscular.",
        "Casco.",
        "5:00pm - 6:00am",
        "Para que puedas ver Netflix.",
        "Shangai.",
        "Personas jóvenes.",
        "Colmados.",
        "1-10 dias."
    };
    private string[] respuestasB =
    {
        "Distanciamiento social.",
        "Snacks.",
        "Congestión nasal, fiebre y tos.",
        "Camisas manga larga.",
        "8:00pm - 6:00am",
        "Para tener un control del tránsito.",
        "Wuhan.",
        "Personas mayores.",
        "Fantasias.",
        "1-2 dias."
    };
    private string[] respuestasC =
    {
        "Buscar amigos.",
        "Refrescos.",
        "Dolor de cabeza, vomito y diarrea.",
        "Botas.",
        "7:00pm - 8:00am",
        "Para prevenir el tumulto de personas y evitar la propagación del virus.",
        "Zhejiang.",
        "Niños.",
        "Farmacias.",
        "1-14 dias."
    };
    private string[] respuestasD =
    {
        "No estornudar.",
        "Agua",
        "Fiebre, dolor de cabeza, tos seca e incapacidad para respirar.",
        "Mascarilla.",
        "5:00pm - 7:00am",
        "Para que disfrutes en familia.",
        "Jiangsu.",
        "Adulto promedio.",
        "Vendedores ambulantes.",
        "1-12 dias."
    };

    private int a = 0;
    private int b;
    private string respuestaCorrectaV;
    private float TimeLeft = 10;

    // Start is called before the first frame update
    void Start()
    {
        _preguntas();
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft -= Time.deltaTime;
        TiempoText.text = TimeLeft.ToString("0");

        if (TimeLeft <= 0)
        {
            _preguntas();
        }
    }

    //Funcion para generar las preguntas
    public void _preguntas()
    {
        if (a >= preguntasID.Length)
        {
            Debug.Log("Esta mierda se corrio");
            Pantalla.GetComponent<Animator>().Play("PantallaPuntos_In");
        }
        Debug.Log(a);
        Debug.Log(preguntasID.Length);

        TimeLeft = 10;

        RespuestaA.color = Color.white;
        RespuestaB.color = Color.white;
        RespuestaC.color = Color.white;
        RespuestaD.color = Color.white;

        respuestaCorrectaV = respuestaCorrecta[a];

        Pregunta.text = preguntasTrivia[a];
        RespuestaA.text = respuestasA[a];
        RespuestaB.text = respuestasB[a];
        RespuestaC.text = respuestasC[a];
        RespuestaD.text = respuestasD[a];

        a = a + 1;
    }

    public void _checkA()
    {
        if( ButtonA.text == respuestaCorrectaV )
        {
            RespuestaA.color = Color.green;
            PantallaPuntos.GetComponent<Puntos>().puntos += 1f;
            Invoke("_preguntas", 1);
        }
        else
        {
            RespuestaA.color = Color.red;

            switch(respuestaCorrectaV)
            {
                case "B":
                    RespuestaB.color = Color.green;
                    break;
                case "C":
                    RespuestaC.color = Color.green;
                    break;
                case "D":
                    RespuestaD.color = Color.green;
                    break;
            }
            Invoke("_preguntas", 1);
        }
    }

    public void _checkB()
    {
        if (ButtonB.text == respuestaCorrectaV)
        {
            RespuestaB.color = Color.green;
            PantallaPuntos.GetComponent<Puntos>().puntos += 1f;
            Invoke("_preguntas", 1);
        }
        else
        {
            RespuestaB.color = Color.red;

            switch (respuestaCorrectaV)
            {
                case "A":
                    RespuestaA.color = Color.green;
                    break;
                case "C":
                    RespuestaC.color = Color.green;
                    break;
                case "D":
                    RespuestaD.color = Color.green;
                    break;
            }
            Invoke("_preguntas", 1);
        }
    }

    public void _checkC()
    {
        if (ButtonC.text == respuestaCorrectaV)
        {
            RespuestaC.color = Color.green;
            PantallaPuntos.GetComponent<Puntos>().puntos += 1f;
            Invoke("_preguntas", 1);
        }
        else
        {
            RespuestaC.color = Color.red;

            switch (respuestaCorrectaV)
            {
                case "A":
                    RespuestaA.color = Color.green;
                    break;
                case "B":
                    RespuestaB.color = Color.green;
                    break;
                case "D":
                    RespuestaD.color = Color.green;
                    break;
            }
            Invoke("_preguntas", 1);
        }
    }

    public void _checkD()
    {
        if (ButtonD.text == respuestaCorrectaV)
        {
            RespuestaD.color = Color.green;
            PantallaPuntos.GetComponent<Puntos>().puntos += 1f;
            Invoke("_preguntas", 1);
        }
        else
        {
            RespuestaD.color = Color.red;

            switch (respuestaCorrectaV)
            {
                case "A":
                    RespuestaA.color = Color.green;
                    break;
                case "B":
                    RespuestaB.color = Color.green;
                    break;
                case "C":
                    RespuestaC.color = Color.green;
                    break;
            }
            Invoke("_preguntas", 1);
        }
    }

    void GameOver()
    {
        PantallaPuntos.SetActive(true);
        PantallaTrivia.SetActive(false);
    }
}