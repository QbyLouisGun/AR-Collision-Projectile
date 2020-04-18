using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class ProjectileScript : MonoBehaviour, IVirtualButtonEventHandler
{

    public GameObject virtualbuttonobj;
    public GameObject mygameobject1;
    int buttonpressed;

    public TextMesh textmass;
    public TextMesh textvelocity;
    public TextMesh textmomentum;


    private float gravity;
    private float u;
    private float timer;

    private float xdistance1,xdistance2,ydistance1,ydistance2,zdistance1,zdistance2;
    private float testgravity;

    public ProjectileButtonScript data_velocity, data_mass, data_ɸ, data_theta, data_gravity, data_gravityɸ,data_gravitytheta;
    private float velocity, mass, ɸ, theta, vgravity, gravityɸ, gravitytheta; //vgravity = variablegravity

    private float v_x, v_y, v_z;
    private float vgravity_x, vgravity_y, vgravity_z;
    private float totalvelocity,totalvelocitynew;

    // Start is called before the first frame update
    void Start()
    {
        virtualbuttonobj = GameObject.Find("ActivateButtonProjectile");
        virtualbuttonobj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

        mygameobject1 = GameObject.Find("ProjectileCube");
        mygameobject1.GetComponent<Transform>();

        textmass = GameObject.Find("Text projectile mass").GetComponent<TextMesh>();
        textvelocity = GameObject.Find("Text projectile velocity").GetComponent<TextMesh>();
        textmomentum = GameObject.Find("Text projectile momentum").GetComponent<TextMesh>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("ButtonPressed");
        buttonpressed = 1;

    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("ButtonRelease");
        buttonpressed = 2;
    }
    void FixedUpdate()
    {
        velocity = data_velocity.velocityvalue;
        mass = data_mass.massvalue;
        ɸ = data_ɸ.ɸvalue;
        theta = data_theta.thetavalue;
        vgravity = data_gravity.gravityvalue;
        gravityɸ = data_gravityɸ.gravityɸvalue;
        gravitytheta = data_gravitytheta.gravitythetavalue;

        u = 0.5f;
        gravity = 5;



        v_x = velocity * Mathf.Cos(ɸ * Mathf.PI / 180) * Mathf.Sin(theta * Mathf.PI / 180);
        v_y = velocity * Mathf.Sin(ɸ * Mathf.PI / 180) * Mathf.Sin(theta * Mathf.PI / 180);
        v_z = velocity * Mathf.Cos(theta * Mathf.PI / 180);

        vgravity_x = vgravity * Mathf.Cos(gravityɸ * Mathf.PI / 180) * Mathf.Sin(gravitytheta * Mathf.PI / 180);
        vgravity_y = vgravity * Mathf.Sin(gravityɸ * Mathf.PI / 180) * Mathf.Sin(gravitytheta * Mathf.PI / 180);
        vgravity_z = vgravity * Mathf.Cos(gravitytheta * Mathf.PI / 180);

        totalvelocity = Mathf.Sqrt((v_x) * (v_x) + (v_y) * (v_y) + (v_z) * (v_z));

        //Debug.Log(buttonpressed);
        
        textmass.text = "mass= " + mass + "kg";

        textvelocity.text = "velocity= " + Mathf.Round(totalvelocity * 100f) / 100f + "ms-1";
        textmomentum.text = "momentum= " + Mathf.Round(mass * totalvelocity * 100f) / 100f + "kgms-1";



        if (buttonpressed == 1) // Activate Animation
        {
            //xdistance += Time.deltaTime * v_x;
            //ydistance += Time.deltaTime * v_z;
            //zdistance1 += Time.deltaTime * v_y;
            //zdistance2 += 0.5f * Time.deltaTime * Time.deltaTime * gravity;

            timer += Time.deltaTime;

            xdistance1 = timer * v_x;
            xdistance2 = 0.5f * timer * timer * vgravity_x;
            ydistance1 = timer * v_z;
            ydistance2 = 0.5f * timer * timer * vgravity_z;
            zdistance1 = timer * v_y;
            zdistance2 = 0.5f * timer * timer * vgravity_y;

            mygameobject1.transform.localPosition = new Vector3(0 + xdistance1 + xdistance2, 0.5f + ydistance1 + ydistance2, 1 + zdistance1 +zdistance2 );
            totalvelocitynew = Mathf.Sqrt((v_x + vgravity_x * timer) * (v_x + vgravity_x * timer) + (v_y + vgravity_y * timer) * (v_y + vgravity_y * timer) + (v_z + vgravity_z * timer) * (v_z + vgravity_z * timer));
            textvelocity.text = "velocity= " + Mathf.Round(totalvelocitynew * 100f) / 100f + "ms-1";
            textmomentum.text = "momentum= " + Mathf.Round(mass * totalvelocitynew * 100f) / 100f + "kgms-1";

        }
        else if (buttonpressed == 2) // Reset Animation
        {
            xdistance1 = 0;
            ydistance1 = 0;
            zdistance1 = 0;
            xdistance2 = 0;
            ydistance2 = 0;
            zdistance2 = 0;
            timer = 0;
            mygameobject1.transform.localPosition = new Vector3(0 , 0.5f, 1);

            totalvelocity = Mathf.Sqrt((v_x) * (v_x) + (v_y) * (v_y) + (v_z) * (v_z));
            textvelocity.text = "velocity= " + Mathf.Round(totalvelocity * 100f) / 100f + "ms-1";
            textmomentum.text = "momentum= " + Mathf.Round(mass * totalvelocity * 100f) / 100f + "kgms-1";

        }
        //Debug.Log("zdistance= " + zdistance1 + "zdistance2 = " + zdistance2);
        Debug.Log("vx, vy, vz " + v_x +"  "+ v_y +"  "+ v_z);
        Debug.Log(Time.deltaTime);

        
    }
}
