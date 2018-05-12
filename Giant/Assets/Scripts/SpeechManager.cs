using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    private PillarManager pillarManager;

    // Use this for initialization
    void Start()
    {
        pillarManager = GameObject.Find("PillarManager").GetComponent<PillarManager>();
        keywords.Add("start", () =>
        {
            this.BroadcastMessage("GameStart");
        });

        keywords.Add("again", () =>
        {
            this.BroadcastMessage("GameAgain");
        });

        keywords.Add("OK", () =>
        {
            pillarManager.SendMessage("GameGo", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("first", () =>
        {
            
            pillarManager.SendMessage("SelectOne", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("second", () =>
        {
            
            pillarManager.SendMessage("SelectTwo", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("third", () =>
        {
            
            pillarManager.SendMessage("SelectThree", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("fourth", () =>
        {
            
            pillarManager.SendMessage("SelectFour", SendMessageOptions.DontRequireReceiver);
        });
        keywords.Add("fifth", () =>
        {
            
            pillarManager.SendMessage("SelectFive", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("sixth", () =>
        {
            
            pillarManager.SendMessage("SelectSix", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("seventh", () =>
        {
            
            pillarManager.SendMessage("SelectSeven", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("eighth", () =>
        {
            
            pillarManager.SendMessage("SelectEight", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("ninth", () =>
        {
            
            pillarManager.SendMessage("SelectNine", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("yellow", () =>
        {

            pillarManager.SendMessage("SelectYellow", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("blue", () =>
        {

            pillarManager.SendMessage("SelectBlue", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("red", () =>
        {

            pillarManager.SendMessage("SelectRed", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("green", () =>
        {

            pillarManager.SendMessage("SelectGreen", SendMessageOptions.DontRequireReceiver);
        });

        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}