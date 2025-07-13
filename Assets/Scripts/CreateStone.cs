using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CreateStone : MonoBehaviour
{

    public GameObject stone;
    public GameObject potion;
    public float delaytime = 3f;

    public BoxCollider2D RandomCreateCollider; // 생성위치
    public BoxCollider2D IgnoreCreateCollider; // 생성하면 안되는위치

    public BoxCollider2D HoleCollider;

    [Header("[확인용]")]
    [SerializeField]
    protected Bounds boundssize;
    [SerializeField]
    protected Bounds ignorebounds;

    IEnumerator PotionTime_Coroutine()
    {
        yield return new WaitForSeconds(delaytime);

        while (potion.layer == 4)
        {
            PotionRemove();
        }
        
    }

    void PotionRemove()
    {
        Destroy(potion);
    }

    IEnumerator MakeStone_Coroutine()
    {
        //stoneNew();
        //float posx = this.transform.position.x;
        //float posy = this.transform.position.y;

        //while (true)
        //{
        //    if (posx == ex_xrandom && posy == ex_yrandom)
        //    {
        //        continue;
        //    }

        //    yield return new WaitForSeconds(3f);
        //}


        while(true)
        {
            yield return new WaitForSeconds(3f);

            stoneNew();
        }
    }


    // 3초에 한번씩 랜덤 스톤 만들기
    // 스톤 랜덤한 위치에 지정이된다
    // 랜던함 위치 조건은 범위지정
    // 범윈안에서도 특정 위치에서는 다시 랜덤 조건 적용

    //public Transform Top;
    //public Transform Right;
    //public Transform Left;
    //public Transform Bottom;



    public void stoneNew()
    {

        StoneAttack[] atonearr = GameObject.FindObjectsByType<StoneAttack>( FindObjectsSortMode.None );
        if(atonearr.Length >= 5)
        {
            return;
        }

        //float ex_xrandom = Random.Range(-2.3f, 2.5f);
        //float ex_yrandom = Random.Range(-4.11f, -0.47f);

        //float minx = -2.3f;
        //float maxx = 2.5f;
        //float miny = -4.1f;
        //float maxy = 0.47f;

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

                
            // 스톤 범위안에 있는지 파악용
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


            //GameObject createstone = Instantiate(stone);
            //createstone.transform.position = new Vector3(xrandom, yrandom);
        }

    }


    void Start()
    {
        boundssize = RandomCreateCollider.bounds;
        ignorebounds = IgnoreCreateCollider.bounds;


        RandomCreateCollider.enabled = false;
        IgnoreCreateCollider.enabled = false;
        StartCoroutine(MakeStone_Coroutine());
        StartCoroutine(PotionTime_Coroutine());
    }


    void Update()
    {
        
    }
}
