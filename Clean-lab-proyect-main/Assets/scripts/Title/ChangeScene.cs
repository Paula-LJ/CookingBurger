using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public string scene_win;
    public string scene_loose;

    //public Customer customer;
    public Spawn spawn; 
    public rotateScene rotatescene;

    private int customerOut = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//cambie de escena al final de la partida más 2

		if (rotatescene.time > 60 && spawn.clients[0].IngredientList.Count == 0 && spawn.clients[1].IngredientList.Count == 0 && spawn.clients[2].IngredientList.Count == 0) //al clients no tenen comandes
			SceneManager.LoadScene(scene_win);

		if (rotatescene.time >= (rotatescene.timeChange * 2 + 60))
			SceneManager.LoadScene(scene_loose);

	}
}
