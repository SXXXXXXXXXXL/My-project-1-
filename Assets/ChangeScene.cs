using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public SceneController gameManager;

    public void NextScene()
    {
        SceneController.instance.NextLevel();
    }
}
