using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ground : MonoBehaviour
{
    public int indexThisScene;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(indexThisScene);// индекс задал со сцены, перезагружаю сцену после касания земли
    }
}
