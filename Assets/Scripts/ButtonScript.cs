using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonScript : MonoBehaviour
{
    public GameObject theUI1;
    public GameObject theUI2;
    public InputField inputu1, inputu2, inputm1, inputm2, inputɸ1, inputɸ2, inputtheta1, inputtheta2;
    string u1string, u2string, m1string, m2string, ɸ1string, ɸ2string, theta1string, theta2string;
    public float u1value, u2value, m1value, m2value, ɸ1value, ɸ2value, theta1value, theta2value;
    


    public void ToggleText()
    {
        if (theUI1 != null)
        {
            bool isActive1 = theUI1.activeSelf;
            theUI1.SetActive(!isActive1);
            bool isActive2 = theUI2.activeSelf;
            theUI2.SetActive(!isActive2);


        }




    }
    public void transfervalue()
    {
        u1string = inputu1.text;
        u1value = float.Parse(u1string);
        u2string = inputu2.text;
        u2value = float.Parse(u2string);

        m1string = inputm1.text;
        m1value = float.Parse(m1string);
        m2string = inputm2.text;
        m2value = float.Parse(m2string);

        ɸ1string = inputɸ1.text;
        ɸ1value = float.Parse(ɸ1string);
        ɸ2string = inputɸ2.text;
        ɸ2value = float.Parse(ɸ2string);

        theta1string = inputtheta1.text;
        theta1value = float.Parse(theta1string);
        theta2string = inputtheta2.text;
        theta2value = float.Parse(theta2string);

    }

}

