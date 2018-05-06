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
        keywords.Add("すたーと", () =>
        {
            this.BroadcastMessage("GameStart");
        });

        keywords.Add("あげいん", () =>
        {
            this.BroadcastMessage("GameAgain");
        });

        keywords.Add("おーけー", () =>
        {
            pillarManager.SendMessage("GameGo", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("いちばん", () =>
        {
            
            pillarManager.SendMessage("SelectOne", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("にばん", () =>
        {
            
            pillarManager.SendMessage("SelectTwo", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("さんばん", () =>
        {
            
            pillarManager.SendMessage("SelectThree", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("よんばん", () =>
        {
            
            pillarManager.SendMessage("SelectFour", SendMessageOptions.DontRequireReceiver);
        });
        keywords.Add("ごばん", () =>
        {
            
            pillarManager.SendMessage("SelectFive", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("ろくばん", () =>
        {
            
            pillarManager.SendMessage("SelectSix", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("ななばん", () =>
        {
            
            pillarManager.SendMessage("SelectSeven", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("はちばん", () =>
        {
            
            pillarManager.SendMessage("SelectEight", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("きゅうばん", () =>
        {
            
            pillarManager.SendMessage("SelectNine", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("きいろ", () =>
        {

            pillarManager.SendMessage("SelectYellow", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("あお", () =>
        {

            pillarManager.SendMessage("SelectBlue", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("あか", () =>
        {

            pillarManager.SendMessage("SelectRed", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("みどり", () =>
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