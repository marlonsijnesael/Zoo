using UnityEngine;

[CreateAssetMenu(menuName = "Animals/Actions/move")]
public class Action_Move : AnimalAction {


    public override void Init(Animal _o) {

        PickGoal(_o);
        }

    public override void DoAction(Animal _o) {
        Move(_o);
        }

    public void Move(Animal _o) {
        Vector3 direction = _o.animalInfo.goal - _o.gameObject.transform.localPosition;
        _o.GetComponent<SpriteRenderer>().flipX = RotateSprite(direction.x);
        _o.gameObject.transform.Translate(direction.normalized * _o.animalInfo.speed * Time.deltaTime);
       
        if (direction.magnitude < 0.05)
            PickGoal(_o);
        }

    //check if animal is moving left or right
    private bool RotateSprite(float _x) {
        if (_x < 0) {
            return false;
            }
        return true;
        }

    private void PickGoal(Animal _o) {
        _o.animalInfo.goal = new Vector2(
        Random.Range(_o.left, _o.right),
        Random.Range(_o.down, _o.top));
        }

    }


