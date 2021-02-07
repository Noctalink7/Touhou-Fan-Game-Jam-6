using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TakingDmg1 : MonoBehaviour
{
    public PV pV;
    public GameObject WhiteFade;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Shot"))
        {
            pV.HP -= 1;
        }
        if (pV.HP <= 0)
        {
            StartCoroutine(FadeCo());
        }
    }

    public IEnumerator FadeCo()
    {
        if (WhiteFade != null)
        {
            Instantiate(WhiteFade, Vector3.zero, Quaternion.identity);
        }
        yield return new WaitForSeconds(1f);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("GameOver");
        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }
}
