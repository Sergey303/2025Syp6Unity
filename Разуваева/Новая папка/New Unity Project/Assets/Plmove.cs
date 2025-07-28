using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plmove : MonoBehaviour
{
    public Transform pltransform;
    public float spead = 0.01f;

    public int timerstart = 1300;
    public int timer = 500;
    public int timer1 = 200;
    public int timer2 = 200;
    public int timer3 = 500;
    public int timer10 = 100;
    public int timer11 = 100;
    public int timer103 = 100;
    public int timer114 = 100;
    public int timer101 = 100;
    public int timer102 = 100;
    public int timer12 = 300;
    public int timer1222 = 200;

    public bool bykva_m;
    public bool bykva_y;
    public bool bykva_z;
    public bool bykva_e;
    public bool bykva_i;
    public bool toch;

    public List<Vector3> Points;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //pltransform.position = new Vector3(0, 0, pltransform.position.z + spead);
        if (bykva_m)
        {
            if (timer > 0)
            {
                timer = timer - 1;
                Moveup();
            }
            else
            {
                if (timer1 > 0)
                {
                    timer1 = timer1 - 1;
                    Movedown();
                    Moveright();
                }
                else
                {
                    if (timer2 > 0)
                    {
                        timer2 = timer2 - 1;
                        Moveup();
                        Moveright();
                    }
                    else
                    {
                        if (timer3 > 0)
                        {
                            timer3 = timer3 - 1;
                            Movedown();
                        }
                        else
                        {

                        }
                    }
                }
            }
        }

        if (bykva_y)
        {
            if (timerstart > 0)
            {
                timerstart = timerstart - 1;
            }
            else
            {
                if (timer10 > 0)
                {
                    timer10 = timer10 - 1;
                    Moveright();
                    Movedown();

                }
                else
                {
                    if (timer11 > 0)
                    {
                        timer11 = timer11 - 1;
                        Moveup();
                        Moveright();
                    }
                    else
                    {
                        if (timer12 > 0)
                        {
                            timer12 = timer12 - 1;
                            Movedown();
                            Moveleft();
                        }
                        else
                        {

                        }
                    }
                }
            }
        }

        if (bykva_z)
        {
            if (timerstart > 0)
            {
                timerstart = timerstart - 1;
            }
            else
            {
                if (timer103 > 0)
                {
                    timer103 = timer103 - 1;
                    Moveright();
                }
                else
                {
                    if (timer114 > 0)
                    {
                        timer114 = timer114 - 1;
                        Movedown();
                        Moveleft();
                    }
                    else
                    {
                        if (timer101 > 0)
                        {
                            timer101 = timer101 - 1;
                            Moveright();
                        }
                        else
                        {
                            if (timer102 > 0)
                            {
                                timer102 = timer102 - 1;
                                Movedown();
                                Moveleft();
                            }
                            else
                            {

                            }
                        }
                    }
                }
            }
        }

        if (bykva_e)
        {
            if (timerstart > 0)
            {
                timerstart = timerstart - 1;
            }
            else
            {
                if (timer10 > 0)
                {
                    timer10 = timer10 - 1;
                    Moveleft();
                }
                else
                {
                    if (timer11 > 0)
                    {
                        timer11 = timer11 - 1;
                        Moveup();
                    }
                    else
                    {
                        if (timer103 > 0)
                        {
                            timer103 = timer103 - 1;
                            Moveright();
                        }
                        else
                        {
                            if (timer114 > 0)
                            {
                                timer114 = timer114 - 1;
                                Moveleft();
                            }
                            else
                            {
                                if (timer101 > 0)
                                {
                                    timer101 = timer101 - 1;
                                    Moveup();
                                }
                                else
                                {
                                    if (timer102 > 0)
                                    {
                                        timer102 = timer102 - 1;
                                        Moveright();
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        if (bykva_i)
        {
            if (timerstart > 0)
            {
                timerstart = timerstart - 1;
            }
            else
            {
                if (timer1 > 0)
                {
                    timer1 = timer1 - 1;
                    Movedown();
                }
                else
                {
                    if (timer1222 > 0)
                    {
                        timer1222 = timer1222 - 1;
                        Moveup();
                        Moveright();
                    }
                    else
                    {
                        if (timer2 > 0)
                        {
                            timer2 = timer2 - 1;
                            Movedown();
                        }
                        else
                        {
                            
                        }
                    }
                }
            }
        }

        if (toch)
        {
            if (timerstart > 0)
            {
                timerstart = timerstart - 1;
            }
            else
            {
                if (timer1 > 0)
                {
                    timer1 = timer1 - 1;
                    Movedown();
                    Moveright();
                }
                else
                {
                    if (timer1222 > 0)
                    {
                        timer1222 = timer1222 - 1;
                        Moveup();
                        Moveright();
                    }
                    else
                    {
                     
                    }
                }
            }
        }

    }
    public void Moveup()
    {
        pltransform.position = new Vector3(pltransform.position.x, pltransform.position.y + spead, pltransform.position.z);
    }
    public void Movedown()
    {
        pltransform.position = new Vector3(pltransform.position.x, pltransform.position.y - spead, pltransform.position.z);
    }

    public void Moveleft()
    {
        pltransform.position = new Vector3(pltransform.position.x - spead, pltransform.position.y, pltransform.position.z);
    }
    public void Moveright()
    {
        pltransform.position = new Vector3(pltransform.position.x + spead, pltransform.position.y, pltransform.position.z);
    }


}
