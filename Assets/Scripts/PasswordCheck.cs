using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PasswordCheck : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

    public GameObject LinePrefab;
    public Canvas canvas;

    private Dictionary<int, NumIdentifier> nums;
    private List<NumIdentifier> lines;
    private List<int> correctPattern;

    public GameObject lineOnEdit;
    private RectTransform lineOnEditRcTs;
    private NumIdentifier numOnEdit;

    private bool unlocking;
    new bool enabled = true;

    // Start is called before the first frame update
    void Start()
    {
        nums = new Dictionary<int, NumIdentifier>();
        lines = new List<NumIdentifier>();

        for (int i = 0; i < transform.childCount; i++)
        {
            var num = transform.GetChild(i);

            var identifier = num.GetComponent<NumIdentifier>();

            identifier.id = i;

            nums.Add(i, identifier);
            // nums.Add(num.gameObject);
            // Debug.Log(nums[i].name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enabled == false)
        {
            return;
        }
        if(unlocking)
        {
            Vector3 mousePos = canvas.transform.InverseTransformPoint(Input.mousePosition);

            lineOnEditRcTs.sizeDelta = new Vector2(lineOnEditRcTs.sizeDelta.x, Vector3.Distance(mousePos, numOnEdit.transform.localPosition));
            lineOnEditRcTs.rotation = Quaternion.FromToRotation(
                Vector3.up,
                (mousePos - numOnEdit.transform.localPosition).normalized);
        }
    }

    IEnumerator Release()
    {
        enabled = false;

        yield return new WaitForSeconds(3);

        foreach(var num in nums)
        {
            num.Value.GetComponent<UnityEngine.UI.Image>().color = Color.white;
            num.Value.GetComponent<Animator>().enabled = false;
        }

        foreach(var line in lines)
        {
            Destroy(line.gameObject);
        }

        lines.Clear();

        lineOnEdit = null;
        lineOnEditRcTs = null;
        numOnEdit = null;

        enabled = true;
    }

    GameObject CreateLine(Vector3 pos, int id)
    {
        var line = GameObject.Instantiate(LinePrefab, canvas.transform);

        line.transform.localPosition = pos;

        var lineIdf = line.AddComponent<NumIdentifier>();

        lineIdf.id = id;

        lines.Add(lineIdf);

        return line;
    }

    void TrySetLineEdit(NumIdentifier num)
    {
        foreach (var line in lines)
        {
            if (line.id == num.id)
            {
                return;
            }
        }
        lineOnEdit = CreateLine(num.transform.localPosition, num.id);
        lineOnEditRcTs = lineOnEdit.GetComponent<RectTransform>();
        numOnEdit = num;
    }
    void EnableColorFade(Animator anim)
    {
        anim.enabled = true;
        anim.Rebind();
    }

    public void OnMouseEnterNum(NumIdentifier idf)
    {
        if (enabled == false)
        {
            return;
        }

        /*Debug.Log(idf.id);*/

        if (unlocking)
        {
            lineOnEditRcTs.sizeDelta = new Vector2(lineOnEditRcTs.sizeDelta.x, Vector3.Distance(numOnEdit.transform.localPosition, idf.transform.localPosition));
            lineOnEditRcTs.rotation = Quaternion.FromToRotation(
                Vector3.up,
                (idf.transform.localPosition - numOnEdit.transform.localPosition).normalized);

            TrySetLineEdit(idf);
        }
    }
    public void OnMouseExitNum(NumIdentifier idf)
    {
        if (enabled == false)
        {
            return;
        }

        /*Debug.Log(idf.id);*/
    }
    public void OnMouseDownNum(NumIdentifier idf)
    {
        if (enabled == false)
        {
            return;
        }

        /*Debug.Log(idf.id);*/
        unlocking = true;

        TrySetLineEdit(idf);
        /*CreateLine(idf.transform.localPosition, idf.id);*/
    }
    public void OnMouseUpNum(NumIdentifier idf)
    {
        if (enabled == false)
        {
            return;
        }

        /*Debug.Log(idf.id);*/

        if (unlocking)
        {
            foreach (var line in lines)
            {
                EnableColorFade(nums[line.id].gameObject.GetComponent<Animator>());
            }

            Destroy(lines[lines.Count - 1].gameObject);
            lines.RemoveAt(lines.Count - 1);
        }

        unlocking = false;

        foreach(var line in lines)
        {
            EnableColorFade(line.GetComponent<Animator>());
        }

        StartCoroutine(Release());
    }
}
