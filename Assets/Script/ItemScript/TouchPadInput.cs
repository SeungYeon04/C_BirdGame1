using UnityEngine;

public class TouchPadInput : MonoBehaviour
{
    // �÷��̾� �̵� �ӵ�
    public float moveSpeed = 5f;
    // �÷��̾��� ��ǥ ��ġ
    private Vector3 targetPosition;
    // �̵� ������ ����
    private bool isMoving = false;

    public Animator MoveAni; 

    // �÷��̾��� �κ��丮
    public Inventory inventory;

    void Update()
    {
        // ��ġ �Է� �Ǵ� ���콺 �Է� ����
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            // ��ġ �Է��� �ִ� ���
            if (Input.touchCount > 0)
            {
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPosition.z = transform.position.z; // �÷��̾��� Z�� ��ġ ���� 
                CheckAndHandleItem(targetPosition);
                MoveAni.SetBool("MoveAni", true); 
            }
            // ���콺 �Է��� �ִ� ���
            else if (Input.GetMouseButtonDown(0))
            {
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPosition.z = transform.position.z; // �÷��̾��� Z�� ��ġ ����
                CheckAndHandleItem(targetPosition);
                MoveAni.SetBool("MoveAni", true);
            }

            // �̵� ����
            isMoving = true;
        }

        // �÷��̾ ��ǥ ��ġ�� �̵�
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // �÷��̾ ��ǥ ��ġ�� �������� �� �̵� ����
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                //Debug.Log("����!");
                isMoving = false;
                MoveAni.SetBool("MoveAni", false);
            }
        }

        Vector3 direction = targetPosition - transform.position;
        if (direction.x < 0)
        {
            // �������� ������ ȸ��
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            // ������ ������ ȸ��
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    // �������� ��ġ�� ��ġ���� �����Ͽ� ó��
    void CheckAndHandleItem(Vector3 touchPosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Item"))
        {
            // �������� ȹ���ϰų� �������� ��ġ�� ��ġ�� �̵��ϴ� ���� �۾��� ����
            //Debug.Log("�������� ȹ���߽��ϴ�!");

            // �������� ȹ���� �Ŀ��� �������� �����ϰų� ��Ȱ��ȭ�� �� �ֽ��ϴ�.
            Destroy(hit.collider.gameObject);

            IObjectItem clickInterface = hit.transform.gameObject.GetComponent<IObjectItem>();

            if (clickInterface != null)
            {
                // Ŭ���� ��ü���� ������ ������ ������
                Item item = clickInterface.ClickItem();
                // ������ �̸� ���
                //print($"{item.itemName}");
                // �κ��丮�� ������ �߰�
                inventory.AddItem(item);
                Debug.Log(item);
           
            }
        }
    }
}
