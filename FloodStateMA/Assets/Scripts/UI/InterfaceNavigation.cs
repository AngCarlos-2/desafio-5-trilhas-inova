using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceNavigation : MonoBehaviour
{
    [SerializeField] private GameObject inicioCanvas;
    [SerializeField] private GameObject loginCanvas;

    private GameplayAudio sfx;
    [SerializeField] private AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        sfx = FindObjectOfType<GameplayAudio>();
        inicioCanvas.SetActive(true);
        loginCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InicioParaLogin()
    {
        if (inicioCanvas != null)
        {
            sfx.PlaySoundEffect(clip);
            inicioCanvas.SetActive(false);
            if (loginCanvas != null)
            {
                loginCanvas.SetActive(true);
            }
        }
    }

    public void EntrarNoJogo()
    {
        sfx.PlaySoundEffect(clip);
        StartCoroutine(HoldEffect());
    }

    IEnumerator HoldEffect()
    {
        float time = 0.1f;
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Gameplay");
    }
}
