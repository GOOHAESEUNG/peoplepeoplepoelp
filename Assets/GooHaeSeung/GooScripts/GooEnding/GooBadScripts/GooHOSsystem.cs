using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GooHOSsystem : MonoBehaviour
{
    public Text txtName;
    public Text txtSentence;
    public GameObject image;

    Queue<string> sentences = new Queue<string>();

    public Animator anim;

    public void Beign(GooBadDialogue2 info)
    {
        anim.SetBool("GooHOS", true);

        sentences.Clear();

        txtName.text = info.name;

        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }
        Next();
    }

    public void Next()
    {
        if (sentences.Count == 0)
        {
            End();
            return;
        }

        txtSentence.text = string.Empty;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentences.Dequeue()));
    }

    IEnumerator TypeSentence(string sentence)
    {
        foreach (var letter in sentence)
        {
            txtSentence.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void End()
    {
        anim.SetBool("GooHOS", false);
        txtSentence.text = string.Empty;
        image.GetComponent<GooFadeOut>().fadeout();
        StartCoroutine(Ending());
    }

    IEnumerator Ending()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GooEnding");
    }
}


