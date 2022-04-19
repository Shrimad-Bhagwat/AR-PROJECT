using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void Scene1loader()
    {
        SceneManager.LoadScene(1);
    }

    public void Scene2loader()
    {
        SceneManager.LoadScene(2);
    }
}
