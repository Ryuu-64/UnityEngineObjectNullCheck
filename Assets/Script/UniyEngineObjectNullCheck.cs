using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Script
{
    public class UniyEngineObjectNullCheck : MonoBehaviour
    {
        public GameObject go;
        public Text textUi;

        private void Start() => StartCoroutine(NullCheckTest());

        private IEnumerator NullCheckTest()
        {
            var stringBuilder = new StringBuilder();
            WaitForSeconds waitTime = new WaitForSeconds(2);
            yield return waitTime;
#if UNITY_EDITOR
            stringBuilder.Append("UNITY EDITOR").Append("\n");
#else
            stringBuilder.Append("BUILD").Append("\n");
#endif
            stringBuilder.Append("go not set").Append("\n");
            stringBuilder.Append($"Reference Equals null: {ReferenceEquals(go, null).ToString()}").Append("\n");
            stringBuilder.Append($"UnityEngine Object null: {(go == null).ToString()}").Append("\n");
            stringBuilder.Append("go set").Append("\n");
            go = GameObject.Find("GoForNullTest");
            stringBuilder.Append($"Reference Equals null: {ReferenceEquals(go, null).ToString()}").Append("\n");
            stringBuilder.Append($"UnityEngine Object null: {(go == null).ToString()}").Append("\n");
            stringBuilder.Append("Destroy(go)").Append("\n");
            Destroy(go);
            // Destroy is not execute immediately, wait for it.
            yield return waitTime;
            stringBuilder.Append($"Reference Equals null: {ReferenceEquals(go, null).ToString()}").Append("\n");
            stringBuilder.Append($"UnityEngine Object null: {(go == null).ToString()}").Append("\n");
            go = null;
            stringBuilder.Append("go null").Append("\n");
            stringBuilder.Append($"Reference Equals null: {ReferenceEquals(go, null).ToString()}").Append("\n");
            stringBuilder.Append($"UnityEngine Object null: {(go == null).ToString()}").Append("\n");
            textUi.text = stringBuilder.ToString();
        }
    }
}