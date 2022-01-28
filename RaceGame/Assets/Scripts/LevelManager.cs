using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public checkPoint[] checkPoints;
    public List<CarController> racers;
    
    public void start()
    {
        racers = new List<CarController>();
        GameObject[] objects = GameObject.FindGameObjectsWithTag("player");
        foreach (GameObject object_ in objects) 
        {
            Debug.Log(object_.name);
            CarController check = object_.GetComponent<CarController>();
            racers.Add(check);
        } 
    }

    public void update()
    {
        Debug.Log("help");
    }

}
