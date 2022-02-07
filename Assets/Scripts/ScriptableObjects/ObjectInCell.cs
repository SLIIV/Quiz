using UnityEngine;

[CreateAssetMenu(fileName = "ObjectInCell", menuName = "ScriptableObjects/ObjectInCell", order = 1)]
public class ObjectInCell : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private float _rotation;

    public string Name { get { return _name; } }
    public Sprite Sprite { get { return _sprite; } }
    public float Rotation { get { return _rotation; } }

}
