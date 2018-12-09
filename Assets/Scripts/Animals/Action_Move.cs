using UnityEngine;

[CreateAssetMenu(menuName = "Animals/Actions/move")]
public class Action_move : AnimalAction {


    public override void Init(Animal _o) {

        PickGoal(_o);
        }

    public override void DoAction(Animal _o) {
        Move(_o);
        }

    public void Move(Animal _o) {
        Vector3 direction = _o.goal - _o.gameObject.transform.localPosition;
        _o.gameObject.transform.Translate(direction.normalized * _o.speed * Time.deltaTime);
        if (direction.magnitude < 0.05)
            PickGoal(_o);
        }

    private void PickGoal(Animal _o) {
        _o.goal = new Vector2(
        Random.Range(_o.left, _o.right),
        Random.Range(_o.down, _o.top));
        }

    }


