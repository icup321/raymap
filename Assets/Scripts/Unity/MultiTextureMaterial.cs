﻿using OpenSpace;
using OpenSpace.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MultiTextureMaterial : MonoBehaviour {
    public VisualMaterial r3mat;
    public Material mat;
    public string[] textureNames = { "Placeholder" };
    int currentTexture = 0;
    public int textureIndex = 0;
    public bool animate = true;
    float currentTime = 0f;

    public void Start() {
        textureNames = r3mat.animTextures.Select(a => (a == null || a.texture == null) ? "Null" : a.texture.name).ToArray();
        SetTexture(r3mat.currentAnimTexture);
    }

    public void SetTexture(int index) {
        if (index < 0 || index > r3mat.animTextures.Count) return;
        textureIndex = index;
        currentTexture = index;
        TextureInfo tex = r3mat.animTextures[index].texture;
        if (tex != null) {
            mat.SetTexture("_Tex0", tex.Texture);
        }
    }

    public void Update() {
        if (animate && !r3mat.IsLockedAnimatedTexture) {
            if (textureIndex >= 0 && textureIndex < r3mat.animTextures.Count) {
                currentTime += Time.deltaTime * Mathf.Abs(Settings.s.textureAnimationSpeedModifier);
                float time = r3mat.animTextures[currentTexture].time;
                //float time = 1f / 30f;
                while (currentTime >= time) {
                    if (time <= 0) {
                        animate = false;
                        break;
                    }
                    currentTime -= time;
                    textureIndex = ++textureIndex % r3mat.animTextures.Count;
                    time = r3mat.animTextures[textureIndex].time;
                }
            } else {
                textureIndex = 0;
            }
        }
        if (textureIndex != currentTexture) {
            currentTexture = textureIndex;
            SetTexture(currentTexture);
        }
    }
}
