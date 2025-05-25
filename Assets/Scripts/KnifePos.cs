using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class KnifePos : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Animator = GetComponent<Animator>();

        Knife.SetActive(false);
        
    }

    
    public Animator m_Animator = null;
    public GameObject Knife = null;


    public void K_Move()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Knife.SetActive(true);

            if (Input.GetKey(KeyCode.D))
            {
                //p(0.15, 0, 0.07)
                //r(0, 0, -41)
                Knife.transform.localPosition = new Vector3(0.150000006f, 0, 0.07f);
                Knife.transform.eulerAngles = new Vector3(0, 0, -41);
            }
            if(Input.GetKey(KeyCode.A))
            {
                //p(0.00700000022,-0.00100000005,0.629999995)
                //r(0,0,133.473175)
                Knife.transform.localPosition = new Vector3(0.00700000022f, -0.00100000005f, 0.629999995f);
                Knife.transform.eulerAngles = new Vector3(0, 0, 133.473175f);
            }
            if(Input.GetKey(KeyCode.W))
            {
                //Vector3(0.0130000003,0.0329999998,-0.639999986)
                //Vector3(0,0,44.2298279)
                Knife.transform.localPosition = new Vector3(0.0130000003f, 0.0329999998f, -0.639999986f);
                Knife.transform.eulerAngles = new Vector3(0, 0, 44.2298279f);

            }
            if (Input.GetKey(KeyCode.S))
            {
                //Vector3(0.0579999983,-0.0359999985,0.629999995)
                //Vector3(0,0,226.732224)
                Knife.transform.localPosition = new Vector3(0.0579999983f, -0.0359999985f, 0.629999995f);
                Knife.transform.eulerAngles = new Vector3(0, 0, 226.732224f);
            }


        }


        if (Input.GetKeyUp(KeyCode.Space))
        {
            Knife.SetActive(false);
        }


    }

 

    // Update is called once per frame
    void Update()
    {
        K_Move();
     
    }
}
