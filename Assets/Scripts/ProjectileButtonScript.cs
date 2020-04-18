using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileButtonScript : MonoBehaviour
{
    public GameObject theUI1;
    public GameObject theUI2;
    public InputField inputvelocity, inputmass, inputɸ,  inputtheta, inputgravity, inputgravityɸ, inputgravitytheta;
    string velocitystring, mass_string, ɸstring, thetastring, gravitystring, gravityɸstring,gravitythetastring;
    public float velocityvalue, massvalue, ɸvalue, thetavalue, gravityvalue, gravityɸvalue,gravitythetavalue;


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
        velocitystring = inputvelocity.text;
        velocityvalue = float.Parse(velocitystring);

        mass_string = inputmass.text;
        massvalue = float.Parse(mass_string);

        ɸstring = inputɸ.text;
        ɸvalue = float.Parse(ɸstring);

        thetastring = inputtheta.text;
        thetavalue = float.Parse(thetastring);

        gravitystring = inputgravity.text;
        gravityvalue = float.Parse(gravitystring);

        gravityɸstring = inputgravityɸ.text;
        gravityɸvalue = float.Parse(gravityɸstring);

        gravitythetastring = inputgravitytheta.text;
        gravitythetavalue = float.Parse(gravitythetastring);

    }
}
