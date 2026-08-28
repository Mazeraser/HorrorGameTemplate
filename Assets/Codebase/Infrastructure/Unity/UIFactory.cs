using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

namespace Infrastructure.Unity
{
    public class UIFactory
    {
        public const string CanvasName = "UI Canvas";
        public const string EventSystemName = "EventSystem";

        public Canvas CreateCanvas()
        {
            if (Object.FindFirstObjectByType<Canvas>() is { } existing)
                return existing;

            var go = new GameObject(CanvasName);
            var canvas = go.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            var scaler = go.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1920f, 1080f);

            go.AddComponent<GraphicRaycaster>();
            return canvas;
        }

        public EventSystem CreateEventSystem()
        {
            if (Object.FindFirstObjectByType<EventSystem>() is { } existing)
                return existing;

            var go = new GameObject(EventSystemName);
            var module = go.AddComponent<InputSystemUIInputModule>();
            module.AssignDefaultActions();
            return go.AddComponent<EventSystem>();
        }
    }
}