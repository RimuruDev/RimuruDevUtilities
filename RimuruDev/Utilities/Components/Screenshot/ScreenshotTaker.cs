// ReSharper disable All
// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - Gists:    https://gist.github.com/RimuruDev/0f064261fe501dbfe894d0ec6c18ca67
// **************************************************************** //

#if UNITY_EDITOR
using System;
using UnityEngine;

namespace External.RimuruDev.Utilities
{
    /// <summary>
    /// <code>English:</code>
    /// Script for creating screenshots of the Game screen. It is intended to make it more convenient to work with the creation of promotional materials of games.
    /// <code>Russian:</code>
    /// Скрипт для создания скриншотов игрового экрана. Он призван сделать более удобной работу по созданию рекламных материалов игр.
    /// </summary>
    [SelectionBase]
    [DisallowMultipleComponent]
    [HelpURL("https://gist.github.com/RimuruDev/0f064261fe501dbfe894d0ec6c18ca67")]
    public sealed class ScreenshotTaker : MonoBehaviour
    {
        [SerializeField] private string folderName = "Screenshots";

        private void Awake()
        {
            // If you forget to remove this script in the Relese version, it will be automatically removed from the scene at startup.
#if !UNITY_EDITOR
            Destroy(gameObject);
#endif
        }

        [System.Diagnostics.Conditional("DEBUG")]
        private void Update() =>
            ReadInput();

        [System.Diagnostics.Conditional("DEBUG")]
        private void ReadInput()
        {
            if (Input.GetKeyDown(KeyCode.F1))
                CaptureScreenshot("ru");

            if (Input.GetKeyDown(KeyCode.F2))
                CaptureScreenshot("en");

            if (Input.GetKeyDown(KeyCode.F3))
                CaptureScreenshot("tr");
        }

        [ContextMenu("Take Screenshot")]
        [System.Diagnostics.Conditional("DEBUG")]
        private void CaptureScreenshot(string language)
        {
            var folderPath = Application.dataPath + "/" + folderName;

            if (!System.IO.Directory.Exists(folderPath))
                System.IO.Directory.CreateDirectory(folderPath);

            var screenshotPath = folderPath + $"/{language}_screenshot_" +
                                 System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";

            ScreenCapture.CaptureScreenshot(screenshotPath, 1);

            Debug.Log($"<color=magenta>Screenshot saved: {screenshotPath}</color>");
        }
    }
}
#endif