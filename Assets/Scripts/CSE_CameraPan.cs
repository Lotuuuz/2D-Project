using System.Collections;
using UnityEngine;

public class CSE_CameraPan : CutsceneElementBase
{
    private Camera cam;

    [SerializeField] private Vector2 distanceToMove;

    public override void Execute()
    {
        cam = cutsceneHandler.cam;
        StartCoroutine(PanCoroutine());
    }

    private IEnumerator PanCoroutine()
    {
        Vector3 originalLocalPosition = cam.transform.localPosition;

        Vector3 targetLocalPosition = originalLocalPosition + new Vector3(
            -distanceToMove.x,
            distanceToMove.y,
            0
        );

        float elapsedTime = 0f;

        // Pan away
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            float t = Mathf.Clamp01(elapsedTime / duration);

            cam.transform.localPosition = Vector3.Lerp(
                originalLocalPosition,
                targetLocalPosition,
                t
            );

            yield return null;
        }

        cam.transform.localPosition = targetLocalPosition;

        //pause
        yield return new WaitForSeconds(1.5f);

        // Pan back
        elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            float t = Mathf.Clamp01(elapsedTime / duration);

            cam.transform.localPosition = Vector3.Lerp(
                targetLocalPosition,
                originalLocalPosition,
                t
            );

            yield return null;
        }

        cam.transform.localPosition = originalLocalPosition;

        cutsceneHandler.PlayNextElement();
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}