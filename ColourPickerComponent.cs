using GameCreator.Variables;
using System;
using UnityEngine;
using UnityEngine.UI;


namespace GameCreator.UIComponents
{ 
public class ColourPickerComponent : MonoBehaviour
{ 
public Image colorPalette;

public Image thumb;

[HideInInspector]
private Vector2 SpectrumXY;

private Bounds PictureBounds;

private Vector3 Max;

private Vector3 Min;

private CanvasScaler myScale;

[VariableFilter(new Variable.DataType[]
{ 
Variable.DataType.Color
})]
public VariableProperty variable;

private void Start()
{ 
this.myScale = this.colorPalette.canvas.transform.GetComponent<CanvasScaler>();
this.SpectrumXY = new Vector2(this.colorPalette.GetComponent<RectTransform>().rect.width * this.myScale.transform.localScale.x, this.colorPalette.GetComponent<RectTransform>().rect.height * this.myScale.transform.localScale.y);
this.PictureBounds = this.colorPalette.GetComponent<Collider2D>().bounds;
this.Max = this.PictureBounds.max;
this.Min = this.PictureBounds.min;
}

public static Vector3 MultiplyVectors(Vector3 V1, Vector3 V2)
{ 
float[] array = new float[]
{ 
V1.x,
V2.x
};
float[] array2 = new float[]
{ 
V1.y,
V2.y
};
float[] array3 = new float[]
{ 
V1.z,
V2.z
};
return new Vector3(array[0] * array[1], array2[0] * array2[1], array3[0] * array3[1]);
array
array2
array3
}

public void OnMouseDown()
{ 
this.UpdateThumbPosition();
}

public void OnMouseDrag()
{ 
this.UpdateThumbPosition();
}

public void OnMouseUp()
{ 
this.variable.Set(this.Getcolor(), null);
}

private Color Getcolor()
{ 
Vector2 b = this.colorPalette.transform.position;
Vector2 vector = this.thumb.transform.position - b + this.SpectrumXY * 0.5f;
Texture2D arg_18E_0 = this.colorPalette.mainTexture as Texture2D;
this.myScale = this.colorPalette.canvas.transform.GetComponent<CanvasScaler>();
this.SpectrumXY = new Vector2(this.colorPalette.GetComponent<RectTransform>().rect.width * this.myScale.transform.localScale.x, this.colorPalette.GetComponent<RectTransform>().rect.height * this.myScale.transform.localScale.y);
this.PictureBounds = this.colorPalette.GetComponent<Collider2D>().bounds;
this.Max = this.PictureBounds.max;
this.Min = this.PictureBounds.min;
vector = new Vector2(vector.x / this.colorPalette.GetComponent<RectTransform>().rect.width, vector.y / this.colorPalette.GetComponent<RectTransform>().rect.height);
Color pixelBilinear = arg_18E_0.GetPixelBilinear(vector.x / this.myScale.transform.localScale.x, vector.y / this.myScale.transform.localScale.y);
pixelBilinear.a = 1f;
return pixelBilinear;
b
vector
arg_18E_0
pixelBilinear
}

private void UpdateThumbPosition()
{ 
this.SpectrumXY = new Vector2(this.colorPalette.GetComponent<RectTransform>().rect.width * this.myScale.transform.localScale.x, this.colorPalette.GetComponent<RectTransform>().rect.height * this.myScale.transform.localScale.y);
this.PictureBounds = this.colorPalette.GetComponent<Collider2D>().bounds;
this.Max = this.PictureBounds.max;
this.Min = this.PictureBounds.min;
float x = Mathf.Clamp(Input.mousePosition.x, this.Min.x, this.Max.x + 1f);
float y = Mathf.Clamp(Input.mousePosition.y, this.Min.y, this.Max.y);
Vector3 vector = new Vector3(x, y, base.transform.position.z);
if (this.thumb.transform.position != vector)
{ 
this.thumb.transform.position = vector;
}
x
y
vector
}
}
}
