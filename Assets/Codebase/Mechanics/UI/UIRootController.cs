using System;
using UnityEngine;
using UnityEngine.UI;
using VContainer.Unity;
using Infrastructure.Events;
using Infrastructure.States;
using Infrastructure.Unity;

namespace Mechanics.UI
{
    public class UIRootController : IStartable, IDisposable
    {
        //TODO: Разделение на HUD'а на Debug и Release
        private readonly UIFactory _uiFactory;
        private readonly EventBus _eventBus;

        private Text _stateLabel;

        public UIRootController(UIFactory uiFactory, EventBus eventBus)
        {
            _uiFactory = uiFactory;
            _eventBus = eventBus;
        }

        void IStartable.Start()
        {
            var canvas = _uiFactory.CreateCanvas();
            _uiFactory.CreateEventSystem();
            _stateLabel = CreateStateLabel(canvas.transform);
            _stateLabel.text = "State: FreeRoam";
            _eventBus.Subscribe<GameStateChangedEvent>(OnStateChanged);
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<GameStateChangedEvent>(OnStateChanged);
        }

        private void OnStateChanged(GameStateChangedEvent gameEvent)
        {
            _stateLabel.text = $"State: {gameEvent.To.GetType().Name}";
        }

        private Text CreateStateLabel(Transform parent)
        {
            var go = new GameObject("HUD", typeof(RectTransform));
            go.transform.SetParent(parent, false);

            var rect = go.GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0f, 1f);
            rect.anchorMax = new Vector2(0f, 1f);
            rect.pivot = new Vector2(0f, 1f);
            rect.anchoredPosition = new Vector2(16f, -16f);
            rect.sizeDelta = new Vector2(400f, 40f);

            var text = go.AddComponent<Text>();
            text.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            text.fontSize = 28;
            text.color = Color.white;
            return text;
        }
    }
}