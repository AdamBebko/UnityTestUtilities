using UnityEngine;

namespace EditorTestUtilities
{
    public class CameraTestUtilities
    {
        public static Camera SetupNewMainCamera()
        {
            GameObject cameraGameObject = new GameObject {
                tag = "MainCamera"
            };
            Camera mainCamera = cameraGameObject.AddComponent<Camera>();
            mainCamera.enabled = true;
            return mainCamera;
        }
    }
}
