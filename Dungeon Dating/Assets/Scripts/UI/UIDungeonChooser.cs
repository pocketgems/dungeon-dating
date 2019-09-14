using UnityEngine;

public class UIDungeonChooser : MonoBehaviour
{
    public GameObject dungeonChoiceButtonPrefab;
    public Transform root;
    public Transform dungeonModelContainer;

    private void Start()
    {
        for (int childIndex = 0; childIndex < dungeonModelContainer.childCount; ++childIndex)
        {
            var dungeon = (dungeonModelContainer.GetChild(childIndex)).GetComponent<Dungeon>();
            var dungeonChoiceButtonGameObject = Instantiate(dungeonChoiceButtonPrefab);
            dungeonChoiceButtonGameObject.transform.SetParent(root, false);
            dungeonChoiceButtonGameObject.GetComponent<UIDungeonChoiceButton>().dungeon = dungeon;
        }
    }
}
