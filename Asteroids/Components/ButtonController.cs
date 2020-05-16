using Microsoft.Xna.Framework.Graphics;
using MonoChrome.Core;
using MonoChrome.Core.Attributes;
using MonoChrome.Core.Components;
using MonoChrome.Core.Components.CollisionDetection;
using MonoChrome.Core.EntityManager;
using MonoChrome.SceneSystem.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Components
{
    class ButtonController : Component, IPointerClickHandler
    {
        public Action OnClick { get; set; }

        public void OnPointerClick(PointerEventData pointerEventData)
        {
            OnClick?.Invoke();
        }
    }
}
