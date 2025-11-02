using System.Collections.Generic;
using UnityEngine;

public class QuestionPanelContent : MonoBehaviour
{
    [SerializeField] private List<GameObject> _panelObjectReferences;
    public List<GameObject> PanelObjectReferences => _panelObjectReferences;

}
