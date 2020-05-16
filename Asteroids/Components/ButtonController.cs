using MonoChrome.Core;
using MonoChrome.SceneSystem.Input;
using System;

namespace Asteroids.Components
{
    internal class ButtonController : Component, IPointerClickHandler
    {
        public Action OnClick { get; set; }

        public void OnPointerClick(PointerEventData pointerEventData)
        {
            OnClick?.Invoke();
        }
    }
}