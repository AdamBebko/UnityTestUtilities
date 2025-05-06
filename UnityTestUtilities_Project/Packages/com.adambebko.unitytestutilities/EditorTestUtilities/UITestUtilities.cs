using UnityEngine;
using UnityEngine.UI;

namespace EditorTestUtilities
{
    public class UITestUtilities
    {
        public static GameObject SetupNewPanel(Canvas canvasParent)
        {
            GameObject panelObject = new GameObject("Panel");
            panelObject.AddComponent<CanvasRenderer>();
            panelObject.AddComponent<Image>();
            panelObject.transform.SetParent(canvasParent.transform, false);
            return panelObject;
        }

        public static Canvas SetupNewCanvas()
        {
            GameObject canvasObject = new GameObject("Canvas");
            Canvas canvas = canvasObject.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasObject.AddComponent<CanvasScaler>();
            canvasObject.AddComponent<GraphicRaycaster>();
            return canvas;
        }
    }
}