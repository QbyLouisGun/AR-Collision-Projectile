using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;

public class Animation_Button : MonoBehaviour,IVirtualButtonEventHandler
{
    public GameObject virtualbuttonobj;
    public Animator cubeAni;
    public GameObject mygameobject1;
    public GameObject mygameobject2;
    public Collision collision;


    public TextMesh textmass01;
    public TextMesh textmass02;
    public TextMesh textvelocity01;
    public TextMesh textvelocity02;
    public TextMesh textmomentum01;
    public TextMesh textmomentum02;


    private CollisionDetectorCode DetectColide;

    private float vspeed1;
    private float vspeed2;


    private float _speed1;
    private float _speed2;
    private float _mass1;
    private float _mass2;
    private float ɸ1;
    private float ɸ2;
    private float theta1;
    private float theta2;
    private float u1_x,u2_x,v1_x,v2_x, u1_y, u2_y, v1_y, v2_y, u1_z, u2_z, v1_z, v2_z;


    public ButtonScript data_u1, data_u2, data_m1, data_m2, data_ɸ1, data_ɸ2, data_theta1, data_theta2;
    



    float xdistance1;
    float xdistance2;
    float zdistance1;
    float zdistance2;
    float ydistance1;
    float ydistance2;

    float x1, y1,z1, x2, y2,z2;

    int buttonpressed;

    


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Mathf.Cos(Mathf.PI));

        virtualbuttonobj = GameObject.Find("ActivateButton");
        virtualbuttonobj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        cubeAni.GetComponent<Animator>();


        //mygameobject1 = GameObject.Find("Cube 01");
        mygameobject1 = GameObject.Find("Sphere 01");
        mygameobject1.GetComponent<Transform>();
        DetectColide = mygameobject1.GetComponent<CollisionDetectorCode>();

        textmass01 = GameObject.Find("Text 01 mass").GetComponent<TextMesh>();
        textmass02 = GameObject.Find("Text 02 mass").GetComponent<TextMesh>();
        textvelocity01 = GameObject.Find("Text 01 velocity").GetComponent<TextMesh>();
        textvelocity02 = GameObject.Find("Text 02 velocity").GetComponent<TextMesh>();
        textmomentum01 = GameObject.Find("Text 01 momentum").GetComponent<TextMesh>();
        textmomentum02 = GameObject.Find("Text 02 momentum").GetComponent<TextMesh>();




        mygameobject2 = GameObject.Find("Sphere 02");
        mygameobject2.GetComponent<Transform>();


        mygameobject1.transform.localPosition = new Vector3(1, 0.5f, -1);
        mygameobject2.transform.localPosition = new Vector3(-1, 0.5f, -1);
    }
    
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        
            //mygameobject.transform.localPosition = mygameobject.transform.localPosition + new Vector3(0.01f, 0, 0);
        
        
        //cubeAni.Play("Cube_Rotate");
        Debug.Log("ButtonPressed");
        buttonpressed = 1;

    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        //mygameobject.transform.localPosition = new Vector3(0, 0, 0);
        //cubeAni.Play("none");
        Debug.Log("ButtonRelease");
        buttonpressed = 2;
    }
    // Update is called once per frame


    void Update()
    {

    }

    void FixedUpdate()
    {
        _speed1 = data_u1.u1value;
        _speed2 = data_u2.u2value;
        _mass1 = data_m1.m1value;
        _mass2 = data_m2.m2value;
        ɸ1 = data_ɸ1.ɸ1value;
        ɸ2 = data_ɸ2.ɸ2value;
        theta1 = data_theta1.theta1value;
        theta2 = data_theta2.theta2value;


        u1_x = _speed1 * Mathf.Cos(ɸ1 * Mathf.PI / 180) * Mathf.Sin(theta1 * Mathf.PI/180);
        u1_y = _speed1 * Mathf.Sin(ɸ1 * Mathf.PI / 180) * Mathf.Sin(theta1 * Mathf.PI / 180);
        u1_z = _speed1 * Mathf.Cos(theta1 * Mathf.PI / 180);

        u2_x = _speed2 * Mathf.Cos(ɸ2 * Mathf.PI / 180) * Mathf.Sin(theta2 * Mathf.PI / 180);
        u2_y = _speed2 * Mathf.Sin(ɸ2 * Mathf.PI / 180) * Mathf.Sin(theta2 * Mathf.PI / 180);
        u2_z = _speed1 * Mathf.Cos(theta2 * Mathf.PI / 180);

        v2_x = 2 * _mass1 * u1_x / (_mass1 + _mass2) + (_mass1-_mass2)/(_mass1+_mass2) * u2_x;
        v1_x = (_mass1 - _mass2) * u1_x / (_mass1 + _mass2) + 2 * _mass2 * u2_x / (_mass1+_mass2);

        v2_y = 2 * _mass1 * u1_y / (_mass1 + _mass2) + (_mass1 - _mass2) / (_mass1 + _mass2) * u2_y;
        v1_y = (_mass1 - _mass2) * u1_y / (_mass1 + _mass2) + 2 * _mass2 * u2_y / (_mass1 + _mass2);

        v2_z = 2 * _mass1 * u1_z / (_mass1 + _mass2) + (_mass1 - _mass2) / (_mass1 + _mass2) * u2_z;
        v1_z = (_mass1 - _mass2) * u1_z / (_mass1 + _mass2) + 2 * _mass2 * u2_z / (_mass1 + _mass2);

        vspeed1 = Mathf.Sqrt((v1_x) * (v1_x) + (v1_y) * (v1_y)+ (v1_z) * (v1_z));
        vspeed2 = Mathf.Sqrt((v2_x) * (v2_x) + (v2_y) * (v2_y)+ (v2_z) * (v2_z));

        x1 = u1_x * -1;
        x2 = u2_x * -1;
        y1 = u1_y * -1;
        y2 = u2_y * -1;
        z1 = u1_z * -1;
        z2 = u2_z * -1;

        //vspeed2 = 2 * _mass1 * _speed1 / (_mass1 + _mass2);
        // vspeed1 = (_mass1 - _mass2) * _speed1 / (_mass1 + _mass2);

        // Debug.Log("v1 " + vspeed1);
        // Debug.Log("v2 " + vspeed2);
        Debug.Log(u1_x +" u1x  "+ u1_y +" u1y  "+ u2_x +" u2x  u2y "+ u2_y + "  "+ u1_z + "  "+ u2_z);
        Debug.Log(v1_x +" v1x  "+ v1_y +" v1y  "+ v2_x +" v2x  v2y "+ v2_y + "  " + v1_z + "  " + v2_z);
        Debug.Log(x1 + " x1  " + x2 + " x2  " + y1 + " y1  y2 " + y2 + "  " + z1 + "  " + z2);


        textmass01.text = "mass1= " + _mass1 + "kg";
        textmass02.text = "mass2= " + _mass2 + "kg";

        textvelocity01.text = "velocity1= " + Mathf.Round(_speed1 * 100f) / 100f + "ms-1";
        textmomentum01.text = "momentum1= " + Mathf.Round(_mass1 * _speed1 * 100f) / 100f + "kgms-1";
        textvelocity02.text = "velocity2= " + Mathf.Round(_speed2 * 100f) / 100f + "ms-1";
        textmomentum02.text = "momentum2= " + Mathf.Round(_mass2 * _speed2 * 100f) / 100f + "kgms-1";


        


        if (buttonpressed == 1)
        {
            //Vector3 moveVector = new Vector3(1, 0, 0) * (Time.deltaTime * _speed);
            //mygameobject.transform.Translate(moveVector, Space.World);
            Debug.Log("Orig "+DetectColide.Collided);

            
            



            if (DetectColide.Collided == 1)
            {

                xdistance1 += Time.deltaTime * v1_x;
                xdistance2 += Time.deltaTime * v2_x;

                zdistance1 += Time.deltaTime * v1_y;
                zdistance2 += Time.deltaTime * v2_y;

                ydistance1 += Time.deltaTime * v1_z;
                ydistance2 += Time.deltaTime * v2_z;


                textvelocity01.text = "velocity1= " + Mathf.Round(vspeed1 * 100f)/100f + "ms-1";
                textmomentum01.text = "momentum1= " + Mathf.Round(_mass1 * vspeed1 * 100f) / 100f + "kgms-1";
                textvelocity02.text = "velocity2= " + Mathf.Round(vspeed2 * 100f) / 100f + "ms-1";
                textmomentum02.text = "momentum2= " + Mathf.Round(_mass2 * vspeed2 * 100f) / 100f + "kgms-1";

            }
            else if (DetectColide.Collided == 0)
            {

                xdistance1 += Time.deltaTime * u1_x;
                xdistance2 += Time.deltaTime * u2_x;

                zdistance1 += Time.deltaTime * u1_y;
                zdistance2 += Time.deltaTime * u2_y;

                ydistance1 += Time.deltaTime * u1_z;
                ydistance2 += Time.deltaTime * u2_z;

                textvelocity01.text = "velocity1= " + Mathf.Round(_speed1 * 100f) / 100f + "ms-1";
                textmomentum01.text = "momentum1= " + Mathf.Round(_mass1 * _speed1 * 100f) / 100f + "kgms-1";
                textvelocity02.text = "velocity2= " + Mathf.Round(_speed2 *100f) / 100f + "ms-1";
                textmomentum02.text = "momentum2= " + Mathf.Round(_mass2 * _speed2 * 100f) / 100f + "kgms-1";
            }
            //xdistance1 += Time.deltaTime * _speed1;
            mygameobject1.transform.localPosition = new Vector3(0 + x1 + xdistance1, 0.5f + z1 + ydistance1, -1 + y1 + zdistance1);

            //xdistance2 += Time.deltaTime * _speed2;
            mygameobject2.transform.localPosition = new Vector3(0 + x2 + xdistance2, 0.5f + z2 + ydistance2, -1 + y2 + zdistance2);
            
            

        }
        else if(buttonpressed == 2)
        {
            mygameobject1.transform.localPosition = new Vector3 (0 + x1, 0.5f + z1, -1 + y1);
            xdistance1 = 0;
            mygameobject2.transform.localPosition = new Vector3 (0 + x2, 0.5f + z2, -1 + y2);
            xdistance2 = 0;
            zdistance1 = 0;
            zdistance2 = 0;
            ydistance1 = 0;
            ydistance2 = 0;


            DetectColide.Collided = 0;


            textvelocity01.text = "velocity1= " + Mathf.Round(_speed1 * 100f) / 100f + "ms-1";
            textmomentum01.text = "momentum1= " + Mathf.Round(_mass1 * _speed1 * 100f) / 100f + "kgms-1";
            textvelocity02.text = "velocity2= " + Mathf.Round(_speed2 * 100f) / 100f + "ms-1";
            textmomentum02.text = "momentum2= " + Mathf.Round(_mass2 * _speed2 * 100f) / 100f + "kgms-1";
        }
    }
        
}
