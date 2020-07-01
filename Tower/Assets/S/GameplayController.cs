using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour {

    public static GameplayController instance;

    public BoxSpawner box_Spawner;
    public int p;
    [HideInInspector]
    public BoxScript currentBox;

    public CameraFollow cameraScript;
    public int moveCount = 0 ;

    void Awake() {
        if (instance == null)
            instance = this;
    }

    void Start() {
        box_Spawner.SpawnBox();
    }

    void Update() {
        p = moveCount;
        DetectInput();
       
    }

    void DetectInput() {
        if (Input.GetMouseButtonDown(0)) {
            currentBox.DropBox();
        }    
    }

    public void SpawnNewBox() {

        if (p != 2)
        {
            Invoke("NewBox", 0.5f);
        }
        else
        {
            Invoke("NewBox", 2.0f);

        }
        
    }

    void NewBox() {
        box_Spawner.SpawnBox();

    }

    public void MoveCamera() {

        moveCount++;

        if(moveCount == 3) {
            moveCount = 0;
            cameraScript.targetPos.y += 2.6f;
        }

    }

    public void RestartGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

} // class














































