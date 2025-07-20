using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    void Start()
    {
        
    }

    public void On_Cilck()
    {
        SceneManager.LoadScene("BattleScene");
    }


    void Update()
    {
        
    }
}
