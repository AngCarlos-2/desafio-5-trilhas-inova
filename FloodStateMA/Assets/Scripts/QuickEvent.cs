using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuickEvent : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recursos;
    [SerializeField] private TextMeshProUGUI pontuacao;
    [SerializeField] private Button[] cidade;
    [SerializeField] private ParticleSystem[] waterEffect;
    private GameplayAudio sfx;
    [SerializeField] private AudioClip clip;

    private int pontuacaoJogador;
    private int quantidadeRecursos = 0;
    private bool[] activatedWaterEffect;
    // Start is called before the first frame update
    void Start()
    {
        sfx = FindObjectOfType<GameplayAudio>();
        pontuacaoJogador = 0;
        activatedWaterEffect = new bool[waterEffect.Length];
        for (int i = 0; i < cidade.Length; i++)
        {
            int index = i;
            activatedWaterEffect[index] = true;
            cidade[i].onClick.AddListener(() => QuickTimeEvent(index));
            StartCoroutine(NewEvent(index));
        }
    }

    public void QuickTimeEvent(int index)
    {
        if (activatedWaterEffect[index] && waterEffect[index] != null)
        {
            waterEffect[index].gameObject.SetActive(false);
            sfx.PlaySoundEffect(clip);
            activatedWaterEffect[index] = false;
            pontuacaoJogador += 20;
            pontuacao.text = pontuacaoJogador.ToString();
            quantidadeRecursos++;
            recursos.text = quantidadeRecursos.ToString();
            StartCoroutine(NewEvent(index));
        }  
    }

    IEnumerator NewEvent(int index)
    {
        float time = Random.Range(1f, 20f);
        yield return new WaitForSeconds(time);

        if (waterEffect[index] != null)
        {
            waterEffect[index].gameObject.SetActive(true);
            activatedWaterEffect[index] = true;
        }
    }
}
