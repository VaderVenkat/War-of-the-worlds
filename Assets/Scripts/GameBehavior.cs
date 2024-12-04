public class GameBehavior : MonoBehaviour
{
 private int _itemsCollected = 0; 
 private int _playerHP = 10;
 // 1
 public int Items
{
 // 2
 get { return _itemsCollected; }
 // 3
 set { 
 _itemsCollected = value; 
 Debug.LogFormat("Items: {0}", _itemsCollected);
 }
 }
 // 4
 public int HP 
 {
 get { return _playerHP; }
 set { 
 _playerHP = value; 
 Debug.LogFormat("Lives: {0}", _playerHP);
 }
 }
}