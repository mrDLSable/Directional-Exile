﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.World
{

    /// <summary>
    /// This component manages the interaction with the Hex Tiles
    /// </summary>
    public class HexMouse : MonoBehaviour
    {

        /// <summary>
        /// Calls the Hover function of the parent when the mouse enters
        /// </summary>
        private void OnMouseEnter()
        {
            if (!WindowManager.MouseOverUI)
                this.transform.parent.gameObject.GetComponent<HexComponent>().Hex.Hover();
        }

        /// <summary>
        /// Calls the Click function of the parent when the mouse is clicked and not on the Hex Info panel
        /// </summary>
        private void OnMouseDown()
        {
            if (!WindowManager.MouseOverUI)
                this.transform.parent.gameObject.GetComponent<HexComponent>().Hex.Click();
        }
    }
}