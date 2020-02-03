using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class goals : MonoBehaviour
{
    public static bool arrumarCabos = false;
    public static bool apagarFogo = false;
    public static bool concertarVasos = false;
    public static bool silverTapear = false;
    public GameObject[] fogos;
    public GameObject[] vasos;
    public GameObject[] fugas;
    public GameObject[] cabos;
    public static int totalFires;
    public static int totalVasos;
    public static int totalFugas;
    public static bool fireTaskExists = false;
    public static bool vasoTaskExists = false;
    public static bool fugaTaskExists = false;
    public static bool caboTaskExists = false;
    public List<int> toDo = new List<int>();

    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        arrumarCabos = false;
        apagarFogo = false;
        concertarVasos = false;
        silverTapear = false;

        fogos = GameObject.FindGameObjectsWithTag("fire");
        if(fogos.Length > 0)
        {
            fireTaskExists = true;
            totalFires = fogos.Length;
            toDo.Add(1);

        }

        vasos = GameObject.FindGameObjectsWithTag("vaso");
        if (vasos.Length > 0)
        {
            vasoTaskExists = true;
            totalVasos = vasos.Length;
            toDo.Add(2);

        }

        fugas = GameObject.FindGameObjectsWithTag("fuga");
        if (fugas.Length > 0)
        {
            fugaTaskExists = true;
            totalFugas = fugas.Length;
            toDo.Add(3);

        }

        cabos = GameObject.FindGameObjectsWithTag("energyReactor");
        if (cabos.Length > 0)
        {
            caboTaskExists = true;
            toDo.Add(4);
        }

    }

   /* void task()
    {
        for(int i = 0; i < toDo.Count; i++)
        {
            if(toDo[i] == 1)
            {

            }
        }
    }
    */

    void Passar()
    {
        SceneManager.LoadScene(1);
    }
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 15)
        {
            //SceneManager.LoadScene(2);
        }

        //AQUI COMEÇA O MIGUÉ DO DESESPERO
        if(fireTaskExists && !vasoTaskExists && !fugaTaskExists && !caboTaskExists)
        {
            if(apagarFogo == true)
            {
                Passar();
            }
        }

        if (!fireTaskExists && vasoTaskExists && !fugaTaskExists && !caboTaskExists)
        {
            if (concertarVasos == true)
            {
                Passar();
            }
        }

        if (!fireTaskExists && !vasoTaskExists && fugaTaskExists && !caboTaskExists)
        {
            if (silverTapear == true)
            {
                Passar();
            }
        }

        if (fireTaskExists && vasoTaskExists && !fugaTaskExists && !caboTaskExists)
        {
            if (apagarFogo && concertarVasos)
            {
                Passar();
            }
        }

        if (fireTaskExists && !vasoTaskExists && fugaTaskExists && !caboTaskExists)
        {
            if (apagarFogo && silverTapear)
            {
                Passar();
            }
        }

        if (fireTaskExists && vasoTaskExists && fugaTaskExists && !caboTaskExists)
        {
            if (apagarFogo && concertarVasos && silverTapear)
            {
                Passar();
            }
        }

        if (fireTaskExists && vasoTaskExists && fugaTaskExists && caboTaskExists)
        {
            if (apagarFogo && concertarVasos && silverTapear && arrumarCabos)
            {
                Passar();
            }
        }

        if (totalFires == 0 && fireTaskExists == true)
        {
            apagarFogo = true;

            print("Concluiu a do FOGUINHOOO");
        }

        print(totalVasos);
        if (totalVasos == 0 && vasoTaskExists == true)
        {
            concertarVasos = true;
            print("Concluiu a do VASOOOOOOO");
        }

        if (totalFugas == 0 && fugaTaskExists == true)
        {
            silverTapear = true;
            print("Concluiu a da SILVERTAPEADOOOOOOOO");
        }

        
        
    }
}
