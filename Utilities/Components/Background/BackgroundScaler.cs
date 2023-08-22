// ReSharper disable CommentTypo
// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - GitHub: https://github.com/RimuruDev
//          - Gists:    https://gist.github.com/RimuruDev/61e9f0111b35d3e67ef18fab611d7595
// **************************************************************** //

// ************************************************************************************************************************************************************************* //
//
// English:
// Important! Scale depends on the camera position. If the background goes outside the camera, pay attention to the camera position and Canvas settings. My email is listed above.
//
// Russian:
// Важно! Скейл зависит от позиции камеры. Если задний фон выйдет за пределы камеры, обратите внимание на позицию камеры а так же на настройки Canvas. Моя почта указана выше.
//
// ************************************************************************************************************************************************************************* //

using UnityEngine;

namespace External.RimuruDevUtilities.Utilities.Components.Background
{
    /// <summary>
    /// <code>English:</code>
    /// Automatically resize backgrounds based on SpriteRenderer. You can change the screen format any way you want, even 1920x1080 or 5000x800 the background will not go out of the screen.
    /// <code>Russian:</code>
    /// Автоматическое изменение размеров фонов на основе SpriteRenderer. Вы можете менять формат экрана как угодно, хоть 1920x1080, хоть 5000x800 - фон не будет выходить за пределы экрана.
    /// </summary>
    [SelectionBase]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SpriteRenderer))]
    public class BackgroundScaler : MonoBehaviour
    {
        [SerializeField] private Camera cameraRenderer;
        private SpriteRenderer backgroundSpriteRenderer;

        public virtual void Awake() =>
            backgroundSpriteRenderer = GetComponent<SpriteRenderer>();

        public virtual void Start() =>
            ScaleBackground();

        public virtual void LateUpdate() =>
            ScaleBackground();

        private void ScaleBackground()
        {
            var targetHeight = cameraRenderer.orthographicSize * 2;
            var targetWidth = targetHeight * Screen.width / Screen.height;

            var backgroundSize = backgroundSpriteRenderer.sprite.bounds.size;
            var targetScale = Vector3.one;

            var widthRatio = targetWidth / backgroundSize.x;
            var heightRatio = targetHeight / backgroundSize.y;

            if (widthRatio > heightRatio)
                targetScale *= widthRatio;
            else
                targetScale *= heightRatio;

            transform.localScale = targetScale;
        }
    }
}