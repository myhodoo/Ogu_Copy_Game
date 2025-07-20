using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CreateStone : MonoBehaviour
{

    public GameObject stone;
    public GameObject potion;

    public BoxCollider2D RandomCreateCollider; // ������ġ
    public BoxCollider2D IgnoreCreateCollider; // �����ϸ� �ȵǴ���ġ

    public BoxCollider2D HoleCollider;

    [Header("[Ȯ�ο�]")]
    [SerializeField]
    protected Bounds boundssize;
    [SerializeField]
    protected Bounds ignorebounds;
    

    

    IEnumerator PotionMake_Coroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(10f);

            potionNew();
        }
    }

    public void potionNew()
    {
        while (true)
        {
            Vector3 minpos = boundssize.min;
            Vector3 maxpos = boundssize.max;

            float xrandom = Random.Range(minpos.x, maxpos.x);
            float yrandom = Random.Range(minpos.y, maxpos.y);


            Vector3 ranpos = new Vector3(xrandom, yrandom, 0.5f);
            if (ignorebounds.Contains(ranpos))
            {
                continue;
            }

            GameObject potioncreate = Instantiate(potion);
            potioncreate.transform.position = ranpos;

            break;

        }
    }

    IEnumerator MakeStone_Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            stoneNew();
        }
    }


    // 3�ʿ� �ѹ��� ���� ���� �����
    // ���� ������ ��ġ�� �����̵ȴ�
    // ������ ��ġ ������ ��������
    // �����ȿ����� Ư�� ��ġ������ �ٽ� ���� ���� ����

    public void stoneNew()
    {

        StoneAttack[] atonearr = GameObject.FindObjectsByType<StoneAttack>( FindObjectsSortMode.None );
        if(atonearr.Length >= 5)
        {
            return;
        }

        //float ex_xrandom = Random.Range(-2.3f, 2.5f);
        //float ex_yrandom = Random.Range(-4.11f, -0.47f);

        while(true)
        {
            //Vector3 centerpos = new Vector3(ex_yrandom - ex_xrandom
            //        , ex_yrandom - ex_xrandom
            //        , 0f);
            //Vector3 boxsize = new Vector3()
            //Bounds bound = new Bounds(centerpos, )


            Vector3 minpos = boundssize.min;
            Vector3 maxpos = boundssize.max;

            float xrandom = Random.Range(minpos.x, maxpos.x);
            float yrandom = Random.Range(minpos.y, maxpos.y);


            Vector3 ranpos = new Vector3(xrandom, yrandom, 0f);
            if( ignorebounds.Contains(ranpos) )
            {
                continue;
            }
                
            // ���� �����ȿ� �ִ��� �ľǿ�
            if( false)
            {
                bool isstoneoverlap = false;
                foreach (StoneAttack attack in atonearr)
                {
                    if (attack.GetComponent<BoxCollider2D>().bounds.Contains(ranpos))
                    {
                        isstoneoverlap = true;
                        break;
                    }
                }

                if (isstoneoverlap)
                {
                    continue;
                }
            }
            

            GameObject createstone = Instantiate(stone);
            createstone.transform.position = ranpos;// new Vector3(xrandom, yrandom);
            createstone.GetComponent<StoneAttack>().Stonehole = HoleCollider.transform;

            break;

            //if ((xrandom >= minx && xrandom <= maxx)
            //    && (yrandom >= miny && yrandom <= maxy))
            //{
            //    continue;
            //}

        } 

    }


    void Start()
    {
        boundssize = RandomCreateCollider.bounds;
        ignorebounds = IgnoreCreateCollider.bounds;


        RandomCreateCollider.enabled = false;
        IgnoreCreateCollider.enabled = false;
        StartCoroutine(MakeStone_Coroutine());
        StartCoroutine(PotionMake_Coroutine());
    }

    void PotionRemove()
    {
        //if (potion.layer == 4)
        //{
        //    Destroy(potion,3f);
        //}

    }

    void Update()
    {
        PotionRemove();   
    }
}
