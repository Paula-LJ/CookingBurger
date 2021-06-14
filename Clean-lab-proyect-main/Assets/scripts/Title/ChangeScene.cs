using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public string scene_win;
    public string scene_loose;

    public Spawn spawn; 
    public rotateScene rotatescene;

    // Update is called once per frame
    void Update()
    {
        //Si los juegadores no tienen pedidos
        if (rotatescene.time > 10 && spawn.clients[0].IngredientList.Count == 0 && spawn.clients[1].IngredientList.Count == 0 && spawn.clients[2].IngredientList.Count == 0) 
            SceneManager.LoadScene(scene_win);
     
        //Si los jugadores se quedan sin tiempo
        if ( rotatescene.time >= (rotatescene.timeChange * 2 + 60))
            SceneManager.LoadScene(scene_loose);
    }
}
