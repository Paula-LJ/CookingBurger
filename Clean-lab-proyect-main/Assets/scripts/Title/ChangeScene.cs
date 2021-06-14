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


    void Update()
    {
		//cambie de escena al final de la partida más 2
		if (rotatescene.time > 60 && spawn.clients[0].IngredientList.Count == 0 && spawn.clients[1].IngredientList.Count == 0 && spawn.clients[2].IngredientList.Count == 0) //al clients no tenen comandes
			SceneManager.LoadScene(scene_win);

		if (rotatescene.time >= (rotatescene.timeChange * 2 + 60))
			SceneManager.LoadScene(scene_loose);
	}
}
