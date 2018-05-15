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

        keywords.Add("e chee ban", () =>
        {
            
            pillarManager.SendMessage("SelectOne", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("knee ban", () =>
        {
            
            pillarManager.SendMessage("SelectTwo", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("sun ban", () =>
        {
            
            pillarManager.SendMessage("SelectThree", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("yong ban", () =>
        {
            
            pillarManager.SendMessage("SelectFour", SendMessageOptions.DontRequireReceiver);
        });
        keywords.Add("go ban", () =>
        {
            
            pillarManager.SendMessage("SelectFive", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("rock ban", () =>
        {
            
            pillarManager.SendMessage("SelectSix", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("nana ban", () =>
        {
            
            pillarManager.SendMessage("SelectSeven", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("ha chee ban", () =>
        {
            
            pillarManager.SendMessage("SelectEight", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("qew ban", () =>
        {
            
            pillarManager.SendMessage("SelectNine", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("key roe", () =>
        {

            pillarManager.SendMessage("SelectYellow", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("are o e-row", () =>
        {

            pillarManager.SendMessage("SelectBlue", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("archa e-row", () =>
        {

            pillarManager.SendMessage("SelectRed", SendMessageOptions.DontRequireReceiver);
        });

        keywords.Add("me dori e-row", () =>
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